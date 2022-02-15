using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoWebClient.Pages.Models;

namespace TodoWebClient.Pages.Services
{
    public class TodoService : ITodoService
    {
        // .\Todo.WebAPI.exe --urls "http://*:4020"    Start API on Port 4020 localhost
        // C:\skole\eux\H4\FagligOpdatering\Todo.WebAPI\bin\Debug\net6.0

        private static readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri(AppConstants.BaseUrl) };
        private readonly JsonSerializerOptions _options;

        public TodoService()
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<TodoItem> CreateAsync(TodoItem todoItem)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.TodoAPI, todoItem);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            TodoItem createdTodoItem = JsonSerializer.Deserialize<TodoItem>(content, _options);
            return createdTodoItem;
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            List<TodoItem> items = await _httpClient.GetFromJsonAsync<List<TodoItem>>($"{AppConstants.TodoAPI}");

            return items;
        }
    }
}
