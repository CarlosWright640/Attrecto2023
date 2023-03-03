using System.ComponentModel.DataAnnotations;

namespace Academy_2023.Data
{
    public class Course
    {
        [Required]
        public int? Id { get; set; }

        [StringLength(10)]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [StringLength(50)]
        public string? Description { get; set; }
    }
}