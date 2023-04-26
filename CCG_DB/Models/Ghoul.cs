using System.ComponentModel.DataAnnotations;

namespace CCG_DB.Models
{
    public class Ghoul
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name not provided")]
        public string? Name { get; set; } 
        public string? Rank { get; set; } 
        [Required(ErrorMessage = "Description not set")]
        public string Description { get; set; } = "";
        [Required(ErrorMessage = "Choose photo")]
        public byte[]? Photo { get; set; }
    }
    
}

