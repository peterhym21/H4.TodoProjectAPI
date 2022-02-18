using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoWebClient.Pages.Models;
using TodoWebClient.Pages.Services;

namespace TodoWebClient.Pages.TodoPages
{
    public class EditTodoModel : PageModel
    {
        private readonly ITodoService _todoService;

        public EditTodoModel(ITodoService todoService)
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
            if (ModelState.IsValid)
            {
                await _todoService.Update(Todoitem.Id, Todoitem);
            }
            
            return RedirectToPage("./GetTodos");
        }
    }
}
