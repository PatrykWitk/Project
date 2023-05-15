using System.ComponentModel.DataAnnotations;

namespace LibrariesPr.Models
{
    public class UpdateLibraryDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
