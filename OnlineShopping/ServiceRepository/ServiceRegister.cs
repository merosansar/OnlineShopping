using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.Utility.LoadDropdown;
using OnlineShopping.Web.Services.CategoryService;
using OnlineShopping.Web.Services.IService;
using OnlineShopping.Web.Services.Service;
using System.Configuration;
namespace OnlineShopping.Web.ServiceRepository

{
    public static class RepositoryServiceExtensions
    {                                                             
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            // Register repository services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILoadDropdownService, LoadDropdownService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailsService, ProductDetailsService>();

            services.AddScoped<ICartService, CartService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IUserShippingAddressService, UserShippingAddressService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDashboardService, DashboardService>();

            services.AddScoped<Dropdown>();
            services.AddScoped<EncryptionDecryptionFun>();


            services.AddDistributedMemoryCache(); // Store session in memory
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
                options.Cookie.HttpOnly = true; // Make session cookie accessible only via HTTP
                options.Cookie.IsEssential = true; // Ensure the session cookie is essential for GDPR compliance
            });




            // Add more repository services here

            return services;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              