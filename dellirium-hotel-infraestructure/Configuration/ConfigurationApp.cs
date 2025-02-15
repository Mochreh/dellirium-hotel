using Microsoft.Extensions.Configuration;

namespace dellirium_hotel_infraestructure.Configuration
{
    public class ConfigurationApp : IConfigurationApp
    {
        private readonly IConfiguration _configuration;

        public ConfigurationApp()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(GetInfraestructuraPath()) // Ruta correcta del proyecto Infraestructura
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

        }
        private string GetInfraestructuraPath()
        {
            // Ubicación del proyecto de Infraestructura relativo a la API
            //return Path.Combine(Directory.GetCurrentDirectory(), "..", "ProyectoInfraestructura");
            return AppDomain.CurrentDomain.BaseDirectory;
        }


        public string GetConnectionString(string name)
        {
            return _configuration.GetConnectionString(name) ?? throw new Exception("Cadena de conexión no encontrada.");

        }
    }
}
