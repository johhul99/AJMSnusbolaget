using AJMSnusbolaget.Components;
using AJMSnusbolaget.Services;

namespace AJMSnusbolaget
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // Lägg till Razor Components och Blazor Server interaktiv rendering
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
          
            // Registrera HttpClient och ApiService korrekt
            builder.Services.AddHttpClient<ApiService>(client =>
            {
                client.BaseAddress = new Uri("https://ajm-snus.azurewebsites.net");
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.UseCors("AllowAll");

            // Mappa Razor Components
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }

    }
}
