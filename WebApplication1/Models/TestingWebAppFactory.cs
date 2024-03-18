using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;

namespace WebApplication1.Models
{
    public class TestingWebAppFactory<TEntryPoint> :
WebApplicationFactory<Program> where TEntryPoint : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<ApplicationContext>));
                if (descriptor != null)
                    services.Remove(descriptor);
                services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryEmployeeTest");
                });
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext =
                scope.ServiceProvider.GetRequiredService<ApplicationContext>())
                {
                    try
                    {
                        appContext.Database.EnsureCreated();
                        Seed(appContext);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            });

        }
        private void Seed(ApplicationContext context)
        {
            var one = new User()
            {
                Id=1,
                Name = "Kete",
                Phone= "89465783674",
                Age = 40
            };

            var two = new User()
            {
                Id = 2,
                Name = "Lol",
                Phone = "89465783674",
                Age = 30
            };

            var three = new User()
            {
                Id = 3,
                Name = "Testa",
                Phone = "89465783674",
                Age = 20
            };
            var four = new User()
            {
                Id = 4,
                Name = "Rolka",
                Phone = "89465783674",
                Age = 10
            };
            context.AddRange(one, two, three,four);
            context.SaveChanges();
        }
    }
}
