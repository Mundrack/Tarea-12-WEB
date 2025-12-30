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
    /// Crea instancias específicas de Ford Mustang con configuración por defecto.
    /// MEJORA: Se agregó configuración del año y propiedades específicas del modelo.
    /// </summary>
    public class FordMustangCreator : Creator
    {
        /// <summary>
        /// Crea un Ford Mustang con configuración por defecto.
        /// Configuración: Rojo, modelo Mustang, año actual, motor V8, tracción trasera.
        /// </summary>
        public override Vehicle Create()
        {
            var builder = new CarBuilder();
            return builder
                .SetBrand("Ford")
                .SetModel("Mustang")
                .SetColor("Red")
                .SetYear(DateTime.Now.Year) // Año actual
                .SetEngineType("Gasoline")
                .SetEngineDisplacement(5.0) // Motor V8 5.0L
                .SetHorsepower(450) // 450 HP
                .SetTransmissionType("Manual")
                .SetDriveType("RWD") // Tracción trasera
                .SetDoors(2) // Coupé
                .SetSeats(4)
                .SetBodyStyle("Coupe")
                .SetFuelType("Premium")
                .SetTrunkCapacity(380) // Litros
                .Build();
        }
    }
}