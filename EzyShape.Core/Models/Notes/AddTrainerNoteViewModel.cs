using System.ComponentModel.DataAnnotations;

public class AddTrainerNoteViewModel
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public string ClientId { get; set; }

    public string TrainerId { get; set; }

}
