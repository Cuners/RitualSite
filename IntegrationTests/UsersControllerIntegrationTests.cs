using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using WebApplication1.Controllers;
using WebApplication1.Models;
using Moq;
using System.Net;
using Microsoft.AspNetCore;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace IntegrationTests
{
    public class UserControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _user;
        private readonly TestingWebAppFactory<Program> _factory;

        public UserControllerIntegrationTests(TestingWebAppFactory<Program> factory)
        {
            _factory = factory;
            _user = factory.CreateClient();

        }
        [Fact]
        public async Task Create_WhenCalled_ReturnsCreateForm()
        {
            var response = await _user.GetAsync("/Home/Create");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Пожалуйста, введите данные нового пользователя",
            responseString);
        }
        [Fact]
        public async Task Create_WhenCalled2_ReturnsCreateForm()
        {
            var id = 3;
            var response = await _user.GetAsync($"/Home/Delete/{id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Удалите пользователя",
            responseString);
        }
        [Fact]
        public async Task Create_WhenCalled3_ReturnsCreateForm()
        {
            var id = 1;
            var response = await _user.GetAsync($"/Home/Edit/{id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Отредактируйте пользователя",
            responseString);
        }
        [Fact]
        public async Task Create_SentWrongModel_ReturnsViewWithErrorMessages()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Home/create");
            var formModel = new Dictionary<string, string>
                {
                { "Email", "User@mail.ru" },
                { "Phone", "89465783674" },
                { "Age", "25" }
                };
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _user.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Введены не все данные", responseString);
        }
        [Fact]
        public async Task Create_WhenPOSTExecuted_ReturnsToIndexViewWithCreatedUser()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Home/create");
            var formModel = new Dictionary<string, string>
                {
                { "Name", "Kate" },
                { "Email", "Kate@mail.ru" },
                { "Phone", "89465783674" },
                { "Age", "25" }
                };
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _user.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Kate", responseString);
        }
        [Fact]
        public async Task Create_WhenPOSTExecuted2_ReturnsToIndexViewWithCreatedUser()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Home/create");
            var formModel = new Dictionary<string, string>
                {
                { "Name", "Lolka" },
                { "Email", "Kate@mail.ru" },
                { "Phone", "894653674" },
                { "Age", "25" }
                };
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _user.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Номер телефона должен содержать 11 цифр", responseString);
        }
        [Fact]
        public async Task WhenEditExecuted()
        {
            int testId = 1;
       
            var postRequest = new HttpRequestMessage(HttpMethod.Post, $"/Home/Edit/{testId}");

            var formModel = new Dictionary<string, string>
                        {
                            { "Name", "Lolka" },
                            { "Email", "Kate@mail.ru" },
                            { "Phone", "89465783674" },
                            { "Age", "25" }
                        };
            postRequest.Content = new FormUrlEncodedContent(formModel);
            var response = await _user.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Lolka", responseString);
        }


        [Fact]
        public async Task WhenDeleteExecuted()
        {

            int testId = 4;
            var postRequest = new HttpRequestMessage(HttpMethod.Post, $"/Home/Delete/{testId}");
            var response = await _user.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.DoesNotContain("Rolka", responseString);
        }
    }
}