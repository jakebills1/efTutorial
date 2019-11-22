using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTutorial.Data
{
    public class SettingsDataModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(2048)]
        [Required]
        public string Value { get; set; }
    }
}
