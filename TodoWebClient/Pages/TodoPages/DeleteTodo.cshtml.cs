using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoWebClient.Pages.Models;
using TodoWebClient.Pages.Services;

namespace TodoWebClient.Pages.TodoPages
{
    public class DeleteTodoModel : PageModel
    {
        private readonly ITodoService _todoService;

        public DeleteTodoModel(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [BindProperty(SupportsGet = true)]
        public TodoItem Todoitem { get; set; }

        public async Task<IActionResult> OnGet(int TodoItemId)
        {
            Todoitem = await _todoService.GetItemByIdAsync(TodoItemId);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _todoService.Delete(Todoitem.Id);
            return RedirectToPage("/TodoPages/GetTodos");
        }
    }
}
