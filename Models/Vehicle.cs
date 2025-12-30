using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Models
{
    /// <summary>
    /// Clase base abstracta para todos los vehículos.
    /// Implementa propiedades por defecto y comportamiento común.
    /// MEJORA: Se agregó la propiedad Year y estructura para 20 propiedades futuras.
    /// </summary>
    public abstract class Vehicle : IVehicle
    {
        #region Private properties
        private bool _isEngineOn { get; set; }
        #endregion

        #region Properties
        public readonly Guid ID;
        public virtual int Tires { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Gas { get; set; }
        public double FuelLimit { get; set; }

        public int Year { get; set; }
        public string VIN { get; set; }
        public string LicensePlate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string InsurancePolicy { get; set; }
        public int Mileage { get; set; }
        public string TransmissionType { get; set; } 
        public string EngineType { get; set; } 
        public double EngineDisplacement { get; set; }
        public int Horsepower { get; set; }
        public string DriveType { get; set; } 
        public int Doors { get; set; }
        public int Seats { get; set; }
        public string BodyStyle { get; set; } 
        public string InteriorColor { get; set; }
        public string ExteriorColor { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasABS { get; set; }
        public bool HasAirbags { get; set; }
        public string AudioSystem { get; set; }
        public double TrunkCapacity { get; set; } 
        public string FuelType { get; set; } 
        #endregion

        #region Constructors

   
        public Vehicle(string color, string brand, string model, double fuelLimit = 10, int year = 0)
        {
            ID = Guid.NewGuid();
            Color = color;
            Brand = brand;
            Model = model;
            FuelLimit = fuelLimit;

            Year = year > 0 ? year : DateTime.Now.Year;

            InitializeDefaultProperties();
        }

        protected virtual void InitializeDefaultProperties()
        {

            Mileage = 0;
            Doors = 4;
            Seats = 5;
            HasAirConditioning = true;
            HasABS = true;
            HasAirbags = true;
            FuelType = "Regular";
            TransmissionType = "Automatic";
            DriveType = "FWD";
        }

        #endregion

        #region Methods

        public void AddGas()
        {
            if (Gas <= FuelLimit)
            {
                Gas += 0.1;
            }
            else
            {
                throw new Exception("Gas Full");
            }
        }


        public void StartEngine()
        {
            if (_isEngineOn)
            {
                throw new Exception("Engine is already on");
            }
            if (NeedsGas())
            {
                throw new Exception("No enough gas. You need to go to Gas Station");
            }
            _isEngineOn = true;
        }

        public bool NeedsGas()
        {
            return !(Gas > 0);
        }


        public bool IsEngineOn()
        {
            return _isEngineOn;
        }

        public void StopEngine()
        {
            if (!_isEngineOn)
            {
                throw new Exception("Engine already stopped");
            }

            _isEngineOn = false;
        }

        #endregion
    }
}