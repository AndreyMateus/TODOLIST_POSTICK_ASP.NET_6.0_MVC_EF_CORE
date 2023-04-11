namespace TodoList.Models;

public class Note
{
    public int Id { get; set; }
    public DateTime DataDeCriacao { get; set; }
    public string Obervacao { get; set; }
    public string Texto { get; set; }
}