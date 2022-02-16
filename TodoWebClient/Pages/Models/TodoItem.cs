using System.ComponentModel.DataAnnotations;

namespace TodoWebClient.Pages.Models;

public class TodoItem
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public bool Completed { get; set; } = false;
    [StringLength(100)]
    public string? Description { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    [Required]
    public Priority Priority { get; set; }

}

public enum Priority
{
    High,
    Normal,
    Low
}