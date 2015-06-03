using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;
using GeekQuiz.Models;

namespace GeekQuiz.Utils
{
    public class DatabaseIssuerNameRegistry : ValidatingIssuerNameRegistry
    {
        public static bool ContainsTenant(string tenantId)
        {
            using (TenantDbContext context = new TenantDbContext())
            {
                return context.Tenants
                    .Where(tenant => tenant.Id == tenantId)
                    .Any();
            }
        }

        public static bool ContainsKey(string thumbprint)
        {
            using (TenantDbContext context = new TenantDbContext())
            {
                return context.IssuingAuthorityKeys
                    .Where(key => key.Id == thumbprint)
                    .Any();
            }
        }

        public static void RefreshKeys(string metadataLocation)
        {
            IssuingAuthority issuingAuthority = ValidatingIssuerNameRegistry.GetIssuingAuthority(metadataLocation);

            bool newKeys = false;
            foreach (string thumbprint in issuingAuthority.Thumbprints)
            {
                if (!ContainsKey(thumbprint))
                {
                    newKeys = true;
                    break;
                }
            }

            if (newKeys)
            {
                using (TenantDbContext context = new TenantDbContext())
                {
                    context.IssuingAuthorityKeys.RemoveRange(context.IssuingAuthorityKeys);
                    foreach (string thumbprint in issuingAuthority.Thumbprints)
                    {
                        context.IssuingAuthorityKeys.Add(new IssuingAuthorityKey { Id = thumbprint });
                    }
                    foreach (string issuer in issuingAuthority.Issuers)
                    {
                        context.Tenants.Add(new Tenant { Id = issuer.TrimEnd('/').Split('/').Last() });
                    }
                    context.SaveChanges();
                }
            }
        }

        protected override bool IsThumbprintValid(string thumbprint, string issuer)
        {
            string issuerID = issuer.TrimEnd('/').Split('/').Last();

            return ContainsTenant(issuerID)
                && ContainsKey(thumbprint);
        }
    }
}
