using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoWebClient.Pages.Models;
using TodoWebClient.Pages.Services;

namespace TodoWebClient.Pages.TodoPages
{
    public class GetTodosModel : PageModel
    {

        private readonly ITodoService _todoService;

        public GetTodosModel(ITodoService todoService)
        {
            _todoService = todoService;
        }


        [BindProperty(SupportsGet = true)]
        public List<TodoItem> TodoItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public TodoItem Todoitem { get; set; }

        public async Task<IActionResult> OnGet()
        {
            TodoItems = await _todoService.GetItemsAsync();
            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            Todoitem = await _todoService.CreateAsync(Todoitem);

            return RedirectToPage("./GetTodos");
        }


        public async Task<IActionResult> OnPostChecked()
        {
            TodoItem item = TodoItems.FirstOrDefault(x => x.Completed == true);
            try
            {
                await _todoService.Update(item.Id, item);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToPage("./GetTodos");
        }


    }
}
