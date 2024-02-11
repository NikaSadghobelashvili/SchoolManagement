using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradeId { get; set; } 
        [Required]
        public double Score { get; set; }
        public virtual Student Student { get; set; } = null!;
        public int StudentId { get; set; }
        public virtual Subject Subject { get; set; } = null!;
        public int SubjectId { get; set; }
    }
}
