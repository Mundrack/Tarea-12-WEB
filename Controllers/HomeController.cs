using Best_Practices.Infraestructure.Factories;
using Best_Practices.Infraestructure.Singletons;
using Best_Practices.Models;
using Best_Practices.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Controllers
{
    /// <summary>
    /// Controlador principal de la aplicación.
    /// MEJORA: Se agregó el método AddEscape para el nuevo modelo Ford Escape.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Constructor con inyección de dependencias.
        /// PATRÓN: Dependency Injection
        /// </summary>
        public HomeController(IVehicleRepository vehicleRepository, ILogger<HomeController> logger)
        {
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }

        /// <summary>
        /// Acción principal que muestra todos los vehículos.
        /// </summary>
        public IActionResult Index()
        {
            var model = new HomeViewModel();
            model.Vehicles = VehicleCollection.Instance.Vehicles;
            string error = Request.Query.ContainsKey("error") ? Request.Query["error"].ToString() : null;
            ViewBag.ErrorMessage = error;

            return View(model);
        }

        /// <summary>
        /// PATRÓN: Factory Method
        /// Crea y agrega un Ford Mustang a la colección.
        /// Utiliza FordMustangCreator para crear el vehículo con propiedades por defecto.
        /// </summary>
        [HttpGet]
        public IActionResult AddMustang()
        {
            try
            {
                _logger.LogInformation("🚗 Creando Ford Mustang...");

                var factory = new FordMustangCreator();
                var vehicle = factory.Create();
                _vehicleRepository.AddVehicle(vehicle);

                _logger.LogInformation($"✅ Ford Mustang {vehicle.Year} agregado exitosamente. ID: {vehicle.ID}");

                return Redirect("/");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al agregar Mustang: {ex.Message}");
                return Redirect($"/?error={ex.Message}");
            }
        }

        /// <summary>
        /// PATRÓN: Factory Method
        /// Crea y agrega un Ford Explorer a la colección.
        /// Utiliza FordExplorerCreator para crear el vehículo con propiedades por defecto.
        /// </summary>
        [HttpGet]
        public IActionResult AddExplorer()
        {
            try
            {
                _logger.LogInformation("🚙 Creando Ford Explorer...");

                var factory = new FordExplorerCreator();
                var vehicle = factory.Create();
                _vehicleRepository.AddVehicle(vehicle);

                _logger.LogInformation($"✅ Ford Explorer {vehicle.Year} agregado exitosamente. ID: {vehicle.ID}");

                return Redirect("/");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al agregar Explorer: {ex.Message}");
                return Redirect($"/?error={ex.Message}");
            }
        }

        /// <summary>
        /// PATRÓN: Factory Method
        /// NUEVO: Crea y agrega un Ford Escape a la colección.
        /// Implementa el requisito de agregar el modelo Ford Escape (Rojo).
        /// Utiliza FordEscapeCreator para crear el vehículo con propiedades por defecto.
        /// </summary>
        [HttpGet]
        public IActionResult AddEscape()
        {
            try
            {
                _logger.LogInformation("🚗 Creando Ford Escape...");

                // PATRÓN FACTORY METHOD: Usar el creator específico para Ford Escape
                var factory = new FordEscapeCreator();
                var vehicle = factory.Create();
                _vehicleRepository.AddVehicle(vehicle);

                _logger.LogInformation($"✅ Ford Escape {vehicle.Year} agregado exitosamente. ID: {vehicle.ID}");
                _logger.LogInformation($"   📋 Detalles: Color={vehicle.Color}, Motor={vehicle.EngineType}, HP={vehicle.Horsepower}");

                return Redirect("/");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al agregar Escape: {ex.Message}");
                return Redirect($"/?error={ex.Message}");
            }
        }

        /// <summary>
        /// Enciende el motor de un vehículo específico.
        /// </summary>
        [HttpGet]
        public IActionResult StartEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StartEngine();
                _logger.LogInformation($"🔥 Motor encendido: {vehicle.Brand} {vehicle.Model}");
                return Redirect("/");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al encender motor: {ex.Message}");
                return Redirect($"/?error={ex.Message}");
            }
        }

        /// <summary>
        /// Agrega gasolina a un vehículo específico.
        /// </summary>
        [HttpGet]
        public IActionResult AddGas(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.AddGas();
                _logger.LogInformation($"⛽ Gasolina agregada: {vehicle.Brand} {vehicle.Model}");
                return Redirect("/");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al agregar gasolina: {ex.Message}");
                return Redirect($"/?error={ex.Message}");
            }
        }

        /// <summary>
        /// Apaga el motor de un vehículo específico.
        /// </summary>
        [HttpGet]
        public IActionResult StopEngine(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                vehicle.StopEngine();
                _logger.LogInformation($"🛑 Motor apagado: {vehicle.Brand} {vehicle.Model}");
                return Redirect("/");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error al apagar motor: {ex.Message}");
                return Redirect($"/?error={ex.Message}");
            }
        }

        /// <summary>
        /// Muestra la página de privacidad.
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Maneja los errores de la aplicación.
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}