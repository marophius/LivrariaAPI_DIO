using LivrariaAPI_DIO.Data;
using LivrariaAPI_DIO.Notification;
using LivrariaAPI_DIO.Repositories;
using LivrariaAPI_DIO.Repositories.Interfaces;
using LivrariaAPI_DIO.Services;
using LivrariaAPI_DIO.Validators;
using Microsoft.EntityFrameworkCore;
namespace LivrariaAPI_DIO
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ProdutoValidator>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LivrariaDatabase")));

        }


        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
