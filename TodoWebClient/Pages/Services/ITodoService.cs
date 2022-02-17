using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebClient.Pages.Models;

namespace TodoWebClient.Pages.Services
{
    public interface ITodoService
    {
        public Task<List<TodoItem>> GetItemsAsync();
        public Task<TodoItem> CreateAsync(TodoItem todoItem);
        public Task Delete(int id);
        public Task<TodoItem> GetItemByIdAsync(int id);
        public Task Update(int id, TodoItem todoItem); 
        public Task InitializeHttpClient();
    }
}
