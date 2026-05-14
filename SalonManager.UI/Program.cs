using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalonManager.Datos;
using SalonManager.Datos.Repositorio;
using System;
using System.Windows.Forms;

namespace SalonManager.UI
{
    internal static class Program
    {
        public static ServiceProvider ServiceProvider { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            // 1. Configuración de la Base de Datos Única
            services.AddDbContext<SalonDbContext>(options =>
                options.UseSqlite("Data Source=SalonData.db"));

            // 2. Registro de Repositorios y Formularios
            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));

            services.AddTransient<Form1>();
            services.AddTransient<FormCita>();
            services.AddTransient<FormEstilistas>();

            ServiceProvider = services.BuildServiceProvider();

            // 3. Inicialización de la Estructura (Sincronización Forzada)
            using (var appScope = ServiceProvider.CreateScope())
            {
                var db = appScope.ServiceProvider.GetRequiredService<SalonDbContext>();
                db.Database.EnsureDeleted();

                // Crea la base de datos nueva con el modelo actualizado
                db.Database.EnsureCreated();

                // Asegura que las tablas manuales se inicialicen correctamente
                DatabaseHelper.InicializarBaseDeDatos();
            }

            // 4. Ejecución
            var mainForm = ServiceProvider.GetRequiredService<Form1>();
            Application.Run(mainForm);
        }
    }
}