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

        [Fact]
        public async Task Call_GetTasks_Should_Return_TaskList()
        {
            var response = await _client.GetAsync("/Tasks");
            var value = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<GetTasksResponse>(value);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
