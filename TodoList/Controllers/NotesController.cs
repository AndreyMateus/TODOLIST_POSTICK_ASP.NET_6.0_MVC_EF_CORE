using Microsoft.AspNetCore.Mvc;
using TodoList.Database;
using TodoList.Models;

namespace TodoList.Controllers;

public class NotesController : Controller
{
    private readonly ApplicationDbContext _applicationDbContext;

    public NotesController(ApplicationDbContext applicationDbContext)
    {
        this._applicationDbContext = applicationDbContext;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var notes = _applicationDbContext.Notes.ToList();

        return View(notes);
    }

    public IActionResult AdicionarNota(Note note)
    {
        return View("AddNote",note);
    }

    public IActionResult Excluir(int id)
    {
        Note note = _applicationDbContext.Notes.First(n => n.Id == id);
        _applicationDbContext.Remove(note);
        _applicationDbContext.SaveChanges();
        return RedirectToAction("index");
    }

    public IActionResult Editar(int id)
    {
        Note note = _applicationDbContext.Notes.First(n => n.Id == id);
        return RedirectToAction("AdicionarNota", note);
    }

    public IActionResult Salvar(Note note)
    {
        // Se o ID da Note que vem via parâmetro for IGUAL a 0, significa que o usuário não existia e foi criado agora, pois como o campo de Id está como hidden, e o id não será populado no formulário, o valor retornado será o valor padrão do TIPO, que nesse caso é o valor 0.
        if (note.Id == 0)
        {
            _applicationDbContext.Notes.Add(note);
        }
        // Caso o Id que veio seja DIFERENTE de 0, sabemos que o usuário já existia e então fazemos as alterações a partir do REGISTRO dele já EXISTENTE no banco de dados.
        else
        {
            // Editando
            // Você SÓ EDITAR um REGISTRO já EXISTENTE, você NÃO ADICIONA de novo.
            Note noteReturnedBanco = _applicationDbContext.Notes.First(n => n.Id == note.Id);
            noteReturnedBanco.DataDeCriacao = note.DataDeCriacao;
            noteReturnedBanco.Obervacao = note.Obervacao;
            noteReturnedBanco.Texto = note.Texto;
        }
        
        _applicationDbContext.SaveChanges();
        
        return RedirectToAction("Index");
    }
}