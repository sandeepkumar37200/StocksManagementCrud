using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plugins.DataStore.SQL;
using Plugins.DataStore.SQL.Repository;
using Plugins.DateStore.InMemory;
using StocksAnalysis.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.CategoriesUseCases;
using UseCases.Interfaces;
using UseCases.ProductsUseCase;
using UseCases.TransactionsUseCases;

namespace StocksAnalysis
{
    public class Startup
    {
        

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // dependency injection to provide oobject to dbContext Class
            services.AddDbContext<MarketDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("MarketManagement"));
            });
            services.AddControllersWithViews();

            //If we want to test our logic using TestCases it we dont't want to use our database in testing for that we are writing a logic which make choices in case of QA we will use our InMemory Data
            //if (Env.IsEnvironment("QA"))
            //{
            //    services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
            //    services.AddSingleton<IProductRepository, ProductsInMemoryRepository>();
            //    services.AddSingleton<ITransactionRepository, TransactionsInMemoryRepository>();
            //}
            //else
            //{
            //    services.AddTransient<ICategoryRepository, CategorySQLRepository>();
            //    services.AddTransient<IProductRepository, ProductSQLRepository>();
            //    services.AddTransient<ITransactionRepository, TransactionSQLRepository>();
            //}

            services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
            services.AddSingleton<IProductRepository, ProductsInMemoryRepository>();
            services.AddSingleton<ITransactionRepository, TransactionsInMemoryRepository>();

            services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
            services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
            services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();
            services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
            services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();

            services.AddTransient<IAddProductUseCase, AddProductUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddTransient<IEditProductUseCase, EditProductUseCase>();
            services.AddTransient<ISellProductUseCase, SellProductUseCase>();
            services.AddTransient<IViewProductsInCategoryUseCase, ViewProductsInCategoryUseCase>();
            services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
            services.AddTransient<IViewSelectedProductUseCase, ViewSelectedProductUseCase>();

            services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
            services.AddTransient<ISearchTransactionsUseCase, SearchTransactionsUseCase>();
            services.AddTransient<IViewTransactionsByDateAndCashier, ViewTransactionsByDateAndCashier>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
