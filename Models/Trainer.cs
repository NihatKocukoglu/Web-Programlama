using FCenter.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCenter.Models
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Antrenör adı zorunludur.")]
        [Display(Name = "Antrenör Adı Soyadı")]
        public string FullName { get; set; }

        [Display(Name = "Uzmanlık Alanı")]
        public string Specialization { get; set; } // Örn: Yoga, Crossfit, Kilo Verme

        [Display(Name = "Biyografi")]
        public string Bio { get; set; }

        // İlişki: Her antrenör bir spor salonuna aittir
        [Display(Name = "Bağlı Olduğu Salon")]
        public int GymId { get; set; }

        [ForeignKey("GymId")]
        public Gym? Gym { get; set; }
    }
}