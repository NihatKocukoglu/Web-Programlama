using System.ComponentModel.DataAnnotations;

namespace FCenter.Models
{
    public class Gym
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Spor salonu adı boş bırakılamaz.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Salon adı 3 ile 100 karakter arasında olmalıdır.")]
        [Display(Name = "Salon Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adres bilgisi zorunludur.")]
        [MinLength(10, ErrorMessage = "Adres en az 10 karakter olmalıdır.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Çalışma Saatleri")]
        [RegularExpression(@"^([0-9]{2}:[0-9]{2})\s-\s([0-9]{2}:[0-9]{2})$",
            ErrorMessage = "Saat formatı '09:00 - 22:00' şeklinde olmalıdır.")]
        public string WorkingHours { get; set; }
    }
}