using System.ComponentModel.DataAnnotations;

namespace Academy_2023.Data
{
    public class Course
    {
        [Required]
        public int? Id { get; set; }

        [StringLength(10)]
        public string? Title { get; set; }

        [StringLength(50)]
        public string? Description { get; set; }
        public string? Url { get; set; }


        public ICollection<User> Users { get; set; } = new HashSet<User>();     // navigation property
    }
}
