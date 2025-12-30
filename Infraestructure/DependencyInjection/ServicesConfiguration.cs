using Best_Practices.Controllers;
using Best_Practices.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Infraestructure.DependencyInjection
{
    /// <summary>
    /// PATRÓN: Strategy + Dependency Injection
    /// Configura los servicios de la aplicación con inyección de dependencias.
    /// MEJORA: Implementa Strategy Pattern para seleccionar el repositorio dinámicamente.
    /// </summary>
    public class ServicesConfiguration
    {
        /// <summary>
        /// Configura los servicios de la aplicación.
        /// MEJORA: Ahora lee la configuración desde appsettings.json para decidir
        /// qué implementación de IVehicleRepository usar (Memory vs Database).
        /// Esto implementa el patrón Strategy.
        /// </summary>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Leer configuración del tipo de repositorio desde appsettings.json
            var repositoryType = configuration.GetValue<string>("RepositorySettings:RepositoryType");

            // PATRÓN STRATEGY: Seleccionar la implementación según configuración
            // Esto permite cambiar entre Memory y Database sin modificar código
            switch (repositoryType?.ToLower())
            {
                case "database":
                case "db":
                    // Cuando la base de datos esté lista, usar esta implementación
                    // Por ahora lanza NotImplementedException
                    services.AddScoped<IVehicleRepository, DBVehicleRepository>();
                    Console.WriteLine("📊 Repositorio configurado: BASE DE DATOS");
                    break;

                case "memory":
                case "mem":
                default:
                    // Implementación en memoria usando Singleton
                    // MEJORA: Cambiado de Transient a Scoped para mejor gestión de ciclo de vida
                    // Scoped es mejor que Transient porque mantiene la misma instancia
                    // durante toda la petición HTTP, evitando múltiples accesos innecesarios
                    services.AddScoped<IVehicleRepository, MyVehiclesRepository>();
                    Console.WriteLine("💾 Repositorio configurado: MEMORIA (Singleton)");
                    break;
            }

            // NOTA: Si en el futuro necesitas agregar más implementaciones
            // (por ejemplo, un repositorio de caché Redis), simplemente:
            // 1. Crea la clase que implemente IVehicleRepository
            // 2. Agrega un nuevo case aquí
            // 3. Configura el valor en appsettings.json
            // Esto ejemplifica el principio Open/Closed: abierto para extensión, cerrado para modificación
        }
    }
}