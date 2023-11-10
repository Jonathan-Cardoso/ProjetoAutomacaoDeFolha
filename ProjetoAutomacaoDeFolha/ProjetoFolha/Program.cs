using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using ProjetoFolha.Data;
using ProjetoFolha.Helper;
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

            builder.Services.AddScoped<IRecibosDePagamentoRepositorio, RecibosDePagamentoRepositorio>();

            builder.Services.AddScoped<ILoginViewRepositorio, LoginViewRepositorio>();

            builder.Services.AddScoped<ISetorRepositorio, SetorRepositorio>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // IoC
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();// injetando na atraves da interface criada, quando ele chama a interface ele irá implmentar a classe 
            builder.Services.AddScoped<Helper.ISession, Session>();// injentar na classe, quando ele chama a interface ele irá implmentar a classe

            //Configuração da sessão
            builder.Services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });
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

            app.UseSession();//Para habilitar as sessões

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}