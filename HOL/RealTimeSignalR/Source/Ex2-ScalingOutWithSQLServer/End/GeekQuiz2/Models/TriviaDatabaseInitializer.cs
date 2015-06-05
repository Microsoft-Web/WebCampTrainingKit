namespace GeekQuiz.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    public class TriviaDatabaseInitializer : CreateDatabaseIfNotExists<TriviaContext>
    {
        protected override void Seed(TriviaContext context)
        {
            base.Seed(context);

            var questions = new List<TriviaQuestion>();

            questions.Add(new TriviaQuestion
            {
                Title = "When was .NET first released?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "2000", IsCorrect = false },
                    new TriviaOption { Title = "2001", IsCorrect = false },
                    new TriviaOption { Title = "2002", IsCorrect = true },
                    new TriviaOption { Title = "2003", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What fictional company did Nancy Davolio work for?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "Contoso Ltd.", IsCorrect = false },
                    new TriviaOption { Title = "Initech", IsCorrect = false },
                    new TriviaOption { Title = "Fabrikam, Inc.", IsCorrect = false },
                    new TriviaOption { Title = "Northwind Traders", IsCorrect = true }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "The first and still the oldest domain name on the internet is:",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "Network.com", IsCorrect = false },
                    new TriviaOption { Title = "Alpha4.com", IsCorrect = false },
                    new TriviaOption { Title = "Symbolics.com", IsCorrect = true },
                    new TriviaOption { Title = "InterConnect.com", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Which is not actually a Thing.js?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "Mustache.js", IsCorrect = false },
                    new TriviaOption { Title = "Hammer.js", IsCorrect = false },
                    new TriviaOption { Title = "Horseradish.js", IsCorrect = true },
                    new TriviaOption { Title = "Uglify.js", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "In what year was the first Voice Over IP (VOIP) call made?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "1973", IsCorrect = true },
                    new TriviaOption { Title = "1982", IsCorrect = false },
                    new TriviaOption { Title = "1991", IsCorrect = false },
                    new TriviaOption { Title = "1994", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "\"Chicago\" was the codename for what Microsoft product?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "Visual Basic", IsCorrect = false },
                    new TriviaOption { Title = "Microsoft Surface", IsCorrect = false },
                    new TriviaOption { Title = "Windows 95", IsCorrect = true },
                    new TriviaOption { Title = "Xbox", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "How many loop constructs are there in C#?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "2", IsCorrect = false },
                    new TriviaOption { Title = "3", IsCorrect = false },
                    new TriviaOption { Title = "4", IsCorrect = true },
                    new TriviaOption { Title = "5", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What was the first CodePlex.com project?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "EntLib", IsCorrect = false },
                    new TriviaOption { Title = "IronPython", IsCorrect = true },
                    new TriviaOption { Title = "Ajax Toolkit", IsCorrect = false },
                    new TriviaOption { Title = "JSON.Net", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Last name of the employee who wears Microsoft badge 00001",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "McDonald", IsCorrect = true },
                    new TriviaOption { Title = "Gates", IsCorrect = false },
                    new TriviaOption { Title = "Ballmer", IsCorrect = false },
                    new TriviaOption { Title = "Allen", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "When did Scott Hanselman join Microsoft?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "2007", IsCorrect = true },
                    new TriviaOption { Title = "2000", IsCorrect = false },
                    new TriviaOption { Title = "2005", IsCorrect = false },
                    new TriviaOption { Title = "2009", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "How big is a nibble?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "4 bits", IsCorrect = true },
                    new TriviaOption { Title = "8 bits", IsCorrect = false },
                    new TriviaOption { Title = "16 bits", IsCorrect = false },
                    new TriviaOption { Title = "2 bits", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "How many function calls did Windows 1.0 approximately have?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "100", IsCorrect = false },
                    new TriviaOption { Title = "200", IsCorrect = false },
                    new TriviaOption { Title = "600", IsCorrect = false },
                    new TriviaOption { Title = "400", IsCorrect = true }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Which Star Wars movie was filmed entirely in the studio?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "1", IsCorrect = false },
                    new TriviaOption { Title = "2", IsCorrect = false },
                    new TriviaOption { Title = "3", IsCorrect = true },
                    new TriviaOption { Title = "4", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What is Superman's Kryptonian name?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "Jor-El", IsCorrect = false },
                    new TriviaOption { Title = "Zod", IsCorrect = false },
                    new TriviaOption { Title = "Kal-El", IsCorrect = true },
                    new TriviaOption { Title = "Jax-Ur", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What is the image name for the Windows Task Manager application?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "taskmgr", IsCorrect = true },
                    new TriviaOption { Title = "tmanager", IsCorrect = false },
                    new TriviaOption { Title = "wtaskmgr", IsCorrect = false },
                    new TriviaOption { Title = "wintaskm", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "When was the internet opened to commercial use?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "1989", IsCorrect = false },
                    new TriviaOption { Title = "1992", IsCorrect = false },
                    new TriviaOption { Title = "1990", IsCorrect = false },
                    new TriviaOption { Title = "1991", IsCorrect = true }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "When was the Xbox unveiled?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "2000", IsCorrect = false },
                    new TriviaOption { Title = "2001", IsCorrect = true },
                    new TriviaOption { Title = "2002", IsCorrect = false },
                    new TriviaOption { Title = "2003", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What is the value of an Object + Array in JavaScript?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "0", IsCorrect = true },
                    new TriviaOption { Title = "Array", IsCorrect = false },
                    new TriviaOption { Title = "Object", IsCorrect = false },
                    new TriviaOption { Title = "Type Error", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Why was the IBM PCjr despised by users?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "Chicklet keyboard", IsCorrect = false },
                    new TriviaOption { Title = "No Hard Disk", IsCorrect = false },
                    new TriviaOption { Title = "Not PC compatible", IsCorrect = false },
                    new TriviaOption { Title = "All the above", IsCorrect = true }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What was the max memory supported by MS-DOS?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "256K", IsCorrect = false },
                    new TriviaOption { Title = "512K", IsCorrect = false },
                    new TriviaOption { Title = "640K", IsCorrect = false },
                    new TriviaOption { Title = "1M", IsCorrect = true }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "When was the first laser mouse released?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "2001", IsCorrect = false },
                    new TriviaOption { Title = "2002", IsCorrect = false },
                    new TriviaOption { Title = "2003", IsCorrect = false },
                    new TriviaOption { Title = "2004", IsCorrect = true }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What was Microsoft's first product?",
                Options = (new TriviaOption[]
                {
                    new TriviaOption { Title = "DOS", IsCorrect = false },
                    new TriviaOption { Title = "Altair Basic", IsCorrect = true },
                    new TriviaOption { Title = "PC Basic", IsCorrect = false },
                    new TriviaOption { Title = "Windows", IsCorrect = false }
                }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What building does not exist on the Microsoft campus?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "1", IsCorrect = false },
                        new TriviaOption { Title = "7", IsCorrect = true },
                        new TriviaOption { Title = "99", IsCorrect = false },
                        new TriviaOption { Title = "115", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Who wrote the first computer program?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "Charles Babbage", IsCorrect = false },
                        new TriviaOption { Title = "Herman Hollerith", IsCorrect = false },
                        new TriviaOption { Title = "Ada Lovelace", IsCorrect = true },
                        new TriviaOption { Title = "Jakob Bernoulli", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Visual Basic was first released in what year?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "1990", IsCorrect = false },
                        new TriviaOption { Title = "1991", IsCorrect = true },
                        new TriviaOption { Title = "1992", IsCorrect = false },
                        new TriviaOption { Title = "1993", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Which of the following is NOT a prime number?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "257", IsCorrect = false },
                        new TriviaOption { Title = "379", IsCorrect = false },
                        new TriviaOption { Title = "571", IsCorrect = false },
                        new TriviaOption { Title = "697", IsCorrect = true }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Yukihiro Matsumoto conceived what programming language on February 24, 1993?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "Python", IsCorrect = false },
                        new TriviaOption { Title = "Ruby", IsCorrect = true },
                        new TriviaOption { Title = "Perl", IsCorrect = false },
                        new TriviaOption { Title = "Boo", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Which release of the .NET Framework introduced support for dynamic languages?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "1.1", IsCorrect = false },
                        new TriviaOption { Title = "2.0", IsCorrect = false },
                        new TriviaOption { Title = "3.5", IsCorrect = false },
                        new TriviaOption { Title = "4.0", IsCorrect = true }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What is the package manager for Node.js?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "npm", IsCorrect = true },
                        new TriviaOption { Title = "yum", IsCorrect = false },
                        new TriviaOption { Title = "rpm", IsCorrect = false },
                        new TriviaOption { Title = "PEAR", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "In the acronym PaaS, what does the P stand for?",
                Options = (
                    new TriviaOption[] 
                    {
                        new TriviaOption { Title = "Programming", IsCorrect = false },
                        new TriviaOption { Title = "Power", IsCorrect = false },
                        new TriviaOption { Title = "Platform", IsCorrect = true },
                        new TriviaOption { Title = "Pedestrian", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What is the speed of light in metres per second?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "299,792,458", IsCorrect = true },
                        new TriviaOption { Title = "312,123,156", IsCorrect = false },
                        new TriviaOption { Title = "100,000,000", IsCorrect = false },
                        new TriviaOption { Title = "541,123,102", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What was the original name of the C# programming language?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "Boo", IsCorrect = false },
                        new TriviaOption { Title = "C+++", IsCorrect = false },
                        new TriviaOption { Title = "Cool", IsCorrect = true },
                        new TriviaOption { Title = "Anders", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Which of the following is an example of Boxing in C#?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "int foo = 12;", IsCorrect = false },
                        new TriviaOption { Title = "System.Box(56);", IsCorrect = false },
                        new TriviaOption { Title = "int foo = (int)bar;", IsCorrect = false },
                        new TriviaOption { Title = "object bar = 42;", IsCorrect = true }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Which of the following was not an alternative name considered for XML?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "MAGMA", IsCorrect = false },
                        new TriviaOption { Title = "SGML", IsCorrect = true },
                        new TriviaOption { Title = "SLIM", IsCorrect = false },
                        new TriviaOption { Title = "MGML", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "How many HTML tags are defined in the original description of the markup language?",
                Options = (
                    new TriviaOption[] 
                    {
                        new TriviaOption { Title = "1", IsCorrect = false },
                        new TriviaOption { Title = "11", IsCorrect = false },
                        new TriviaOption { Title = "18", IsCorrect = true },
                        new TriviaOption { Title = "25", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Which of the following ECMA standards represents the standardization of JavaScript?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "ECMA-123", IsCorrect = false },
                        new TriviaOption { Title = "ECMA-262", IsCorrect = true },
                        new TriviaOption { Title = "ECMA-301", IsCorrect = false },
                        new TriviaOption { Title = "ECMA-431", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What was the first Web Browser called?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "WorldWideWeb", IsCorrect = true },
                        new TriviaOption { Title = "Mosaic", IsCorrect = false },
                        new TriviaOption { Title = "Lynx", IsCorrect = false },
                        new TriviaOption { Title = "Gopher", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "In version control systems, the process of bringing together two sets of changes is called what?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "Branch", IsCorrect = false },
                        new TriviaOption { Title = "Commit", IsCorrect = false },
                        new TriviaOption { Title = "Merge", IsCorrect = true },
                        new TriviaOption { Title = "Share", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "In 1980, Microsoft released their first operating system. What was it called?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "MS-DOS", IsCorrect = false },
                        new TriviaOption { Title = "Windows", IsCorrect = false },
                        new TriviaOption { Title = "Xenix", IsCorrect = true },
                        new TriviaOption { Title = "Altair OS", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Which ASCII code (in decimal) represents the character B?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "22", IsCorrect = false },
                        new TriviaOption { Title = "66", IsCorrect = true },
                        new TriviaOption { Title = "97", IsCorrect = false },
                        new TriviaOption { Title = "112", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Which are the first 6 decimal digits of Pi?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "3.14159", IsCorrect = true },
                        new TriviaOption { Title = "3.14195", IsCorrect = false },
                        new TriviaOption { Title = "3.14132", IsCorrect = false },
                        new TriviaOption { Title = "3.14123", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Internet Protocol v4 provides approximately how many addresses?",
                Options = (
                    new TriviaOption[] 
                    {
                        new TriviaOption { Title = "1.5 billion", IsCorrect = false },
                        new TriviaOption { Title = "4.3 billion", IsCorrect = true },
                        new TriviaOption { Title = "55 billion", IsCorrect = false },
                        new TriviaOption { Title = "3.4 trillion", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "What is Layer 4 of the OSI Model?",
                Options = (
                    new TriviaOption[] 
                    {
                        new TriviaOption { Title = "Network Layer", IsCorrect = false },
                        new TriviaOption { Title = "Transport Layer", IsCorrect = true },
                        new TriviaOption { Title = "Session Layer", IsCorrect = false },
                        new TriviaOption { Title = "Presentation Layer", IsCorrect = false }
                    }).ToList()
            });

            questions.Add(new TriviaQuestion
            {
                Title = "Which of the following is NOT a value type in the .NET Framework Common Type System?",
                Options = (
                    new TriviaOption[]
                    {
                        new TriviaOption { Title = "System.Integer", IsCorrect = false },
                        new TriviaOption { Title = "System.String", IsCorrect = true },
                        new TriviaOption { Title = "System.DateTime", IsCorrect = false },
                        new TriviaOption { Title = "System.Float", IsCorrect = false }
                    }).ToList()
            });

            questions.ForEach(a => context.TriviaQuestions.Add(a));

            context.SaveChanges();
        }
    }
}