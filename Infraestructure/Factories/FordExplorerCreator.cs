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
    /// Crea instancias específicas de Ford Explorer con configuración por defecto.
    /// MEJORA: Se agregó configuración completa del modelo con propiedades específicas de SUV.
    /// </summary>
    public class FordExplorerCreator : Creator
    {
        /// <summary>
        /// Crea un Ford Explorer con configuración por defecto.
        /// Configuración: Negro, modelo Explorer, año actual, tracción 4WD, configuración SUV.
        /// </summary>
        public override Vehicle Create()
        {
            var builder = new CarBuilder();
            return builder
                .SetBrand("Ford")
                .SetModel("Explorer")
                .SetColor("Black")
                .SetYear(DateTime.Now.Year) // Año actual
                .SetEngineType("Gasoline")
                .SetEngineDisplacement(3.0) // Motor V6 3.0L Turbo
                .SetHorsepower(400) // 400 HP
                .SetTransmissionType("Automatic")
                .SetDriveType("4WD") // Tracción en las 4 ruedas
                .SetDoors(4) // SUV de 4 puertas
                .SetSeats(7) // 7 pasajeros
                .SetBodyStyle("SUV")
                .SetFuelType("Premium")
                .SetTrunkCapacity(595) // Litros (con asientos arriba)
                .SetFuelLimit(15) // Mayor capacidad de tanque para SUV
                .Build();
        }
    }
}