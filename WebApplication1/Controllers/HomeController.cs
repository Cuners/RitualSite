using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RitualServer.Model;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text;
using WebApplication1.Models.APIModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        private readonly ApiClient _apiClient = new ApiClient();

        public HomeController()
        {
            
        }
        public async Task<IActionResult> Productss()
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getProducts");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Product>>();
                response.EnsureSuccessStatusCode();

                // Обработка данных, полученных от сервера WebApi
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public async Task<IActionResult> Categories()
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getCategories");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Category>>();
                response.EnsureSuccessStatusCode();

                // Обработка данных, полученных от сервера WebApi
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public IActionResult AboutCompany()
        {
            return View();
        }
        public IActionResult Cemetries()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Clothes()
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getClothes");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Clothe>>();
                response.EnsureSuccessStatusCode();

                // Обработка данных, полученных от сервера WebApi
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public async Task<IActionResult> Coffins()
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getCoffins");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Coffin>>();
                response.EnsureSuccessStatusCode();

                // Обработка данных, полученных от сервера WebApi
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public async Task<IActionResult> Crosses()
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getCrosses");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Cross>>();
                response.EnsureSuccessStatusCode();

                // Обработка данных, полученных от сервера WebApi
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public async Task<IActionResult> Monuments()
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getMonuments");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Monument>>();
                response.EnsureSuccessStatusCode();

                // Обработка данных, полученных от сервера WebApi
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public async Task<IActionResult> Tapes()
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getTapes");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Tape>>();
                response.EnsureSuccessStatusCode();

                // Обработка данных, полученных от сервера WebApi
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public async Task<IActionResult> Urns()
        {

            HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/getUrns");

            if (response.IsSuccessStatusCode)
            {
                var productList = await response.Content.ReadFromJsonAsync<List<Urn>>();
                response.EnsureSuccessStatusCode();

                // Обработка данных, полученных от сервера WebApi
                return View(productList);
            }
            else
            {
                // Обработка ошибки
                return View("Error");
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> InfoCoffin(int? id)
        {
            if (id != null)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Coffin/{id}");
                var productList = await response.Content.ReadFromJsonAsync<List<Coffin>>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        public async Task<IActionResult> InfoCloth(int? id)
        {
            if (id != null)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Cloth/{id}");
                var productList = await response.Content.ReadFromJsonAsync<Clothe>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        public async Task<IActionResult> InfoUrn(int? id)
        {
            if (id != null)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Urn/{id}");
                var productList = await response.Content.ReadFromJsonAsync<Urn>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        public async Task<IActionResult> InfoTape(int? id)
        {
            if (id != null)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Tape/{id}");
                var productList = await response.Content.ReadFromJsonAsync<Tape>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        public async Task<IActionResult> InfoMonument(int? id)
        {
            if (id != null)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Monument/{id}");
                var productList = await response.Content.ReadFromJsonAsync<Monument>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        public async Task<IActionResult> InfoCross(int? id)
        {
            if (id != null)
            {
                HttpResponseMessage response = await _apiClient.Client.GetAsync($"{_apiClient.BaseUrl}/api/Cross/{id}");
                var productList = await response.Content.ReadFromJsonAsync<Cross>();
                response.EnsureSuccessStatusCode();
                if (productList != null)
                    return View(productList);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Shipment shipment)
        {
            try
            {
                int productId = int.Parse(Request.Form["productId"]);
                var orderId = await CreateNewOrder();
                await AddOrderItem(orderId, productId);
                await CreateShipment(shipment);

                return RedirectToAction("Index"); 
            }
            catch (Exception ex)
            {
                return Content($"Произошла ошибка: {ex.Message}");
            }
        }

        private async Task<int> CreateNewOrder()
        {
            Order order = new Order()
            {
                UserId = null,
                OrderDate = DateTime.Now,
                Status = "Ожидает"
            };

            HttpResponseMessage response = await _apiClient.Client.PostAsync($"{_apiClient.BaseUrl}/api/Order",
                new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var createdProduct = JsonConvert.DeserializeObject<Order>(responseBody);
            return createdProduct.OrderId;
        }

        private async Task AddOrderItem(int orderId, int productId)
        {
            OrderItem orderItem = new OrderItem()
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = 1
            };

            HttpResponseMessage response = await _apiClient.Client.PostAsync($"{_apiClient.BaseUrl}/api/OrderItem",
                new StringContent(JsonConvert.SerializeObject(orderItem), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        private async Task CreateShipment(Shipment shipment)
        {
            HttpResponseMessage response = await _apiClient.Client.PostAsync($"{_apiClient.BaseUrl}/api/Shipment",
                new StringContent(JsonConvert.SerializeObject(shipment), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateOrder(Shipment shipment,int productid)
        //{

        //    Order order = new Order()
        //    {
        //        UserId = null,
        //        OrderDate = DateTime.Now,
        //        Status = "ожидает"
        //    };
        //    HttpResponseMessage response = await _apiClient.Client.PostAsync($"{_apiClient.BaseUrl}/api/Order", new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json"));
        //    response.EnsureSuccessStatusCode();
        //    var responseBody = await response.Content.ReadAsStringAsync();
        //    var createdProduct = JsonConvert.DeserializeObject<Order>(responseBody);
        //    var orderId = createdProduct.OrderId;
        //    OrderItem orderItem = new OrderItem()
        //    {
        //        OrderId = orderid,
        //        ProductId = productid,
        //        Quantity = 1
        //    };
        //    HttpResponseMessage response2 = await _apiClient.Client.PostAsync($"{_apiClient.BaseUrl}/api/OrderItem", new StringContent(JsonConvert.SerializeObject(orderItem), Encoding.UTF8, "application/json"));
        //    response2.EnsureSuccessStatusCode();
        //    HttpResponseMessage response3 = await _apiClient.Client.PostAsync($"{_apiClient.BaseUrl}/api/Shipment", new StringContent(JsonConvert.SerializeObject(shipment), Encoding.UTF8, "application/json"));
        //    response3.EnsureSuccessStatusCode();
        //    //if (shi.Phone == null || user.Age == 0 || user.Name == null || user.Email ==
        //    //null)
        //    //{
        //    //    return Content("Введены не все данные");
        //    //}
        //    //else
        //    //{
        //    //    bool result = user.IsValid(user.Phone);
        //    //    if (result == true)
        //    //    {
        //    //        db.Users.Add(user);
        //    //        await db.SaveChangesAsync();
        //    //        return RedirectToAction("Index");
        //    //    }
        //    //    else return Content("Номер телефона должен содержать 11 цифр");
        //    //}
        //}
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id != null)
        //    {
        //        User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
        //        if (user != null)
        //            return View(user);
        //    }
        //    return NotFound();
        //}
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id != null)
        //    {
        //        User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
        //        if (user != null)
        //            return View(user);
        //    }
        //    return NotFound();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(User user)
        //{
        //    if (user.Phone == null || user.Age == 0 || user.Name == null || user.Email ==
        //    null)
        //    {
        //        return Content("Введены не все данные");
        //    }
        //    else
        //    {
        //        bool msg = user.IsValid(user.Phone);
        //        if (msg == true)
        //        {
        //            db.Users.Update(user);
        //            await db.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }
        //        else return Content("Номер телефона должен содержать 11 цифр");
        //    }
        //}
        //[HttpGet]
        //[ActionName("Delete")]
        //public async Task<IActionResult> ConfirmDelete(int? id)
        //{
        //    if (id != null)
        //    {
        //        User user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
        //        if (user != null)
        //            return View(user);
        //    }
        //    return NotFound();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id != null)
        //    {
        //        User user = new User { Id = id.Value };
        //        db.Entry(user).State = EntityState.Deleted;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return NotFound();
        //}
    }


}
