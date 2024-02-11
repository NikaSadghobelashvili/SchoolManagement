using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; } 
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        public virtual School school { get; set; } = null!;
        public int SchoolId { get; set; }

        public List<Grade> Grades { get; set; } = new List<Grade>(); 

        [ForeignKey("Classroom")]
        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; } = null!;
        
    }
}
