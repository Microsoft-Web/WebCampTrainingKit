using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeekQuiz.Models
{
    public class TriviaOption
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("TriviaQuestion")]
        public int QuestionId { get; set; }

        public virtual TriviaQuestion TriviaQuestion { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsCorrect { get; set; }
    }
}
