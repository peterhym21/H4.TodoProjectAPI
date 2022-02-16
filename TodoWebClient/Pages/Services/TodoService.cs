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

        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(AppConstants.BaseUrl);
        }


        public async Task<TodoItem> CreateAsync(TodoItem todoItem)
        {
            var response = await _httpClient.PostAsJsonAsync(AppConstants.TodoAPI, todoItem);
            response.EnsureSuccessStatusCode();
            TodoItem createdTodoItem = await response.Content.ReadFromJsonAsync<TodoItem>();
            return createdTodoItem;
        }

        public async Task Update(int id, TodoItem todoItem)
        {
            var response = await _httpClient.PutAsJsonAsync($"{AppConstants.TodoAPI}/{id}", todoItem);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{AppConstants.TodoAPI}/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            List<TodoItem> items = await _httpClient.GetFromJsonAsync<List<TodoItem>>($"{AppConstants.TodoAPI}");
            return items;
        }

        public async Task<TodoItem> GetItemByIdAsync(int id)
        {
            TodoItem todoItem = await _httpClient.GetFromJsonAsync<TodoItem>($"{AppConstants.TodoAPI}/{id}");
            return todoItem;
        }


    }
}
