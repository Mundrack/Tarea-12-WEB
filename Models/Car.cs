using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Models
{
    /// <summary>
    /// Representa un automóvil con 4 ruedas.
    /// Hereda de Vehicle y sobrescribe la propiedad Tires.
    /// </summary>
    public class Car : Vehicle
    {
        /// <summary>
        /// Los autos tienen 4 ruedas por defecto.
        /// </summary>
        public override int Tires { get => 4; }

        /// <summary>
        /// Constructor del auto.
        /// MEJORA: Se agregó el parámetro year para soportar la nueva propiedad.
        /// </summary>
        public Car(string color, string brand, string model, double fuelLimit = 10, int year = 0)
            : base(color, brand, model, fuelLimit, year)
        {
            // La inicialización se maneja en la clase base
        }

        /// <summary>
        /// Sobrescribe la inicialización de propiedades por defecto para autos.
        /// </summary>
        protected override void InitializeDefaultProperties()
        {
            base.InitializeDefaultProperties();

            // Configuración específica para autos (puede ser diferente a motos)
            Doors = 4;
            Seats = 5;
            BodyStyle = "Sedan";
        }
    }
}