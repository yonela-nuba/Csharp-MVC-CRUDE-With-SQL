using System.ComponentModel.DataAnnotations;

namespace ConnectingToSQL.Models
{
    public class CourseToDb
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        [Required, MaxLength(100)]
        public string ModuleName { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";
    }
}
