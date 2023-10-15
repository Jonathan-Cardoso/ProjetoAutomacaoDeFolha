using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using ProjetoFolha.Data;
using ProjetoFolha.Repositorio;

namespace ProjetoFolha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var connectionString = builder.Configuration.GetConnectionString("FolhaPagamentoConnection");

            builder.Services.AddDbContext<CadastroFuncionarioContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddScoped<ICadastroFuncionarioRepositorio, CadastroFuncionarioRepositorio>();

            builder.Services.AddScoped<ILoginViewRepositorio, LoginViewRepositorio>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // IoC
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // Configurar servi�os de autentica��o
            /*builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Logar"; // login
                    options.AccessDeniedPath = "/Login/Error"; // acesso negado
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnSignedIn = context =>
                        {
                            // Configurar a sess�o com o marcador de autentica��o
                            context.HttpContext.Session.SetString("IsAuthenticated", "true");
                            return Task.CompletedTask;
                        },
                        
                    };
                });*/

            // Adicionar servi�os de sess�o
            builder.Services.AddSession();

            var app = builder.Build();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Login/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}