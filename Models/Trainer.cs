using System.ComponentModel.DataAnnotations;

public class Trainer
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }

    public string Expertise { get; set; }
}
