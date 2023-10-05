using Microsoft.AspNetCore.Authentication.Cookies;

namespace ProjetoFolha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // IoC
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // Configurar serviços de autenticação
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Logar"; // login
                    options.AccessDeniedPath = "/Login/Error"; // acesso negado
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnSignedIn = context =>
                        {
                            // Configurar a sessão com o marcador de autenticação
                            context.HttpContext.Session.SetString("IsAuthenticated", "true");
                            return Task.CompletedTask;
                        },
                        
                    };
                });

            // Adicionar serviços de sessão
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