using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGameScore.Data.Entity
{
    public class GameScore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime GameDate { get; set; }
    }
}
