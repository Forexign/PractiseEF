using System.ComponentModel.DataAnnotations;

namespace TEST_EF.Models
{
    public class Course
    {
        public Course()
        {
            Students = new List<Student>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}

