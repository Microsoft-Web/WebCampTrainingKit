using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeekQuiz.Models
{
    public class TriviaAnswer
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("TriviaOption"), Column(Order = 1)]
        public int OptionId { get; set; }

        [ForeignKey("TriviaOption"), Column(Order = 0)]
        public int QuestionId { get; set; }

        [JsonIgnore]
        public virtual TriviaOption TriviaOption { get; set; }
    }
}