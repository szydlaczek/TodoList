using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TodoList.Api;
using TodoList.Application.TaskItems.ModelsPreview;
using Xunit;

namespace TodoList.IntegrationTests
{
    public class TaskItemTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public TaskItemTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Theory]
        [InlineData("", 3)]
        [InlineData("Unit", 1)]
        [InlineData("test", 2)]
        public async Task Call_GetTasks_Should_Return_TaskList(string searchText, int expectedResultCount)
        {
            string url = "/Tasks";

            if (!string.IsNullOrEmpty(searchText))
                url = $"/Tasks?Temat={searchText}";

            var response = await _client.GetAsync(url);
            var value = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<GetTasksResponse>(value);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedResultCount, tasks.Data.Count);
        }

    }
}
