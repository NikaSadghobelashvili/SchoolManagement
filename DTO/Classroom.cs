using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class Classroom
    {
        [Key]
        public int ClassroomId { get; set; }
        [Required]
        public string ClassNo { get; set; } = null!;
        public List<Student> students { get; set; } = new List<Student>();
    }
}