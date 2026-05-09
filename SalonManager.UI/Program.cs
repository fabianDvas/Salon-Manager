using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalonManager.Datos;
using SalonManager.Datos.Repositorio;

namespace SalonManager.UI
{
    internal static class Program
    {
        public static ServiceProvider ServiceProvider { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Crear el contenedor de servicios
            var services = new ServiceCollection();

            // 2. Registrar el DbContext con SQLite
            services.AddDbContext<SalonDbContext>(options =>
                options.UseSqlite("Data Source=salon.db"));

            // 3. Registrar el repositorio genérico
            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));

            // 4. Construir el proveedor
            ServiceProvider = services.BuildServiceProvider();

            // 5. Crear la BD y abrir el formulario en el mismo scope
            using var appScope = ServiceProvider.CreateScope();
            var db = appScope.ServiceProvider.GetRequiredService<SalonDbContext>();
            db.Database.EnsureCreated();

            Application.Run(new FormClientes());
        }
    }
}