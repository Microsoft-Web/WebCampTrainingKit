using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace GeekQuiz.Models
{
    public class TriviaOption
    {
        [Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Column(Order = 0), ForeignKey("TriviaQuestion")]
        public int QuestionId { get; set; }

        [JsonIgnore]
        public virtual TriviaQuestion TriviaQuestion { get; set; }

        [JsonIgnore]
        public bool IsCorrect { get; set; }
    }
}
