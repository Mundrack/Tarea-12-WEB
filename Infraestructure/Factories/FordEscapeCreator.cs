using Best_Practices.ModelBuilders;
using Best_Practices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Infraestructure.Factories
{
    /// <summary>
    /// PATRÓN: Factory Method
    /// Crea instancias específicas de Ford Escape con configuración por defecto.
    /// NUEVO: Implementación del requisito de agregar el modelo Ford Escape.
    /// </summary>
    public class FordEscapeCreator : Creator
    {
        /// <summary>
        /// Crea un Ford Escape con configuración por defecto según especificaciones del requisito.
        /// Configuración: Rojo, modelo Escape, año actual, tracción FWD, configuración SUV compacto.
        /// </summary>
        public override Vehicle Create()
        {
            var builder = new CarBuilder();
            return builder
                .SetBrand("Ford")
                .SetModel("Escape")
                .SetColor("Red") // Según requisito
                .SetYear(DateTime.Now.Year) // Año actual
                .SetEngineType("Gasoline")
                .SetEngineDisplacement(2.0) // Motor 2.0L Turbo
                .SetHorsepower(250) // 250 HP
                .SetTransmissionType("Automatic")
                .SetDriveType("FWD") // Tracción delantera (puede ser AWD opcional)
                .SetDoors(4) // SUV compacto de 4 puertas
                .SetSeats(5) // 5 pasajeros
                .SetBodyStyle("SUV")
                .SetFuelType("Regular") // Acepta gasolina regular
                .SetTrunkCapacity(965) // Litros
                .SetFuelLimit(12) // Tanque mediano para SUV compacto
                .Build();
        }
    }
}