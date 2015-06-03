using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeekQuiz.Models
{
    public class TriviaOption
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Key, Column(Order = 0), ForeignKey("TriviaQuestion")]
        public int QuestionId { get; set; }

        [JsonIgnore]
        public virtual TriviaQuestion TriviaQuestion { get; set; }

        [JsonIgnore]
        public bool IsCorrect { get; set; }
    }
}