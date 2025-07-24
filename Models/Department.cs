using System.ComponentModel.DataAnnotations;

namespace TaskStudDeptCore.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}
