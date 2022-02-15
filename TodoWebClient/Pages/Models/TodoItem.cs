namespace TodoWebClient.Pages.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool Completed { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public Priority Priority { get; set; }

}

public enum Priority
{
    High,
    Normal,
    Low
}