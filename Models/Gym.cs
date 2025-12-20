using System.ComponentModel.DataAnnotations;

namespace FCenter.Models
{
    public class Gym
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Salon adı zorunludur.")]
        [Display(Name = "Spor Salonu Adı")]
        public string Name { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Çalışma Saatleri")]
        public string WorkingHours { get; set; } // Örn: 08:00 - 22:00
    }
}