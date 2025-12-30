using Best_Practices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.ModelBuilders
{
    /// <summary>
    /// PATRÓN: Builder
    /// Construye objetos Car de manera fluida y con propiedades por defecto.
    /// MEJORA: Se agregaron métodos para todas las propiedades nuevas.
    /// Esto permite agregar las 20 propiedades del siguiente sprint sin modificar la lógica del Factory.
    /// </summary>
    public class CarBuilder
    {
        // Propiedades básicas con valores por defecto
        private string Brand = "Ford";
        private string Model = "Mustang";
        private string Color = "Red";
        private int Year = DateTime.Now.Year; // Año actual por defecto
        private double FuelLimit = 10;

        // Propiedades extendidas para el siguiente sprint
        private string VIN;
        private string LicensePlate;
        private DateTime? RegistrationDate;
        private string InsurancePolicy;
        private int Mileage = 0;
        private string TransmissionType = "Automatic";
        private string EngineType = "Gasoline";
        private double EngineDisplacement = 2.0;
        private int Horsepower = 150;
        private string DriveType = "FWD";
        private int Doors = 4;
        private int Seats = 5;
        private string BodyStyle = "Sedan";
        private string InteriorColor = "Black";
        private string ExteriorColor;
        private bool HasAirConditioning = true;
        private bool HasABS = true;
        private bool HasAirbags = true;
        private string AudioSystem = "Standard";
        private double TrunkCapacity = 400;
        private string FuelType = "Regular";

        #region Métodos Builder Fluidos

        /// <summary>
        /// Establece la marca del vehículo.
        /// </summary>
        public CarBuilder SetBrand(string brand)
        {
            Brand = brand;
            return this;
        }

        /// <summary>
        /// Establece el modelo del vehículo.
        /// </summary>
        public CarBuilder SetModel(string model)
        {
            Model = model;
            return this;
        }

        /// <summary>
        /// Establece el color del vehículo.
        /// </summary>
        public CarBuilder SetColor(string color)
        {
            Color = color;
            ExteriorColor = color; // También actualizar el color exterior
            return this;
        }

        /// <summary>
        /// Establece el año del vehículo.
        /// NUEVO: Requisito del sprint actual.
        /// </summary>
        public CarBuilder SetYear(int year)
        {
            Year = year;
            return this;
        }

        /// <summary>
        /// Establece el límite de combustible.
        /// </summary>
        public CarBuilder SetFuelLimit(double fuelLimit)
        {
            FuelLimit = fuelLimit;
            return this;
        }

        // MÉTODOS PARA PROPIEDADES DEL SIGUIENTE SPRINT
        // Estos métodos facilitan la extensión sin romper el código existente

        public CarBuilder SetVIN(string vin)
        {
            VIN = vin;
            return this;
        }

        public CarBuilder SetLicensePlate(string licensePlate)
        {
            LicensePlate = licensePlate;
            return this;
        }

        public CarBuilder SetRegistrationDate(DateTime registrationDate)
        {
            RegistrationDate = registrationDate;
            return this;
        }

        public CarBuilder SetInsurancePolicy(string insurancePolicy)
        {
            InsurancePolicy = insurancePolicy;
            return this;
        }

        public CarBuilder SetMileage(int mileage)
        {
            Mileage = mileage;
            return this;
        }

        public CarBuilder SetTransmissionType(string transmissionType)
        {
            TransmissionType = transmissionType;
            return this;
        }

        public CarBuilder SetEngineType(string engineType)
        {
            EngineType = engineType;
            return this;
        }

        public CarBuilder SetEngineDisplacement(double engineDisplacement)
        {
            EngineDisplacement = engineDisplacement;
            return this;
        }

        public CarBuilder SetHorsepower(int horsepower)
        {
            Horsepower = horsepower;
            return this;
        }

        public CarBuilder SetDriveType(string driveType)
        {
            DriveType = driveType;
            return this;
        }

        public CarBuilder SetDoors(int doors)
        {
            Doors = doors;
            return this;
        }

        public CarBuilder SetSeats(int seats)
        {
            Seats = seats;
            return this;
        }

        public CarBuilder SetBodyStyle(string bodyStyle)
        {
            BodyStyle = bodyStyle;
            return this;
        }

        public CarBuilder SetInteriorColor(string interiorColor)
        {
            InteriorColor = interiorColor;
            return this;
        }

        public CarBuilder SetAirConditioning(bool hasAirConditioning)
        {
            HasAirConditioning = hasAirConditioning;
            return this;
        }

        public CarBuilder SetABS(bool hasABS)
        {
            HasABS = hasABS;
            return this;
        }

        public CarBuilder SetAirbags(bool hasAirbags)
        {
            HasAirbags = hasAirbags;
            return this;
        }

        public CarBuilder SetAudioSystem(string audioSystem)
        {
            AudioSystem = audioSystem;
            return this;
        }

        public CarBuilder SetTrunkCapacity(double trunkCapacity)
        {
            TrunkCapacity = trunkCapacity;
            return this;
        }

        public CarBuilder SetFuelType(string fuelType)
        {
            FuelType = fuelType;
            return this;
        }

        #endregion

        /// <summary>
        /// Construye el objeto Car con todas las propiedades configuradas.
        /// MEJORA: Aplica todas las propiedades nuevas al objeto construido.
        /// </summary>
        public Car Build()
        {
            var car = new Car(Color, Brand, Model, FuelLimit, Year);

            // Aplicar propiedades extendidas
            car.VIN = VIN;
            car.LicensePlate = LicensePlate;
            car.RegistrationDate = RegistrationDate;
            car.InsurancePolicy = InsurancePolicy;
            car.Mileage = Mileage;
            car.TransmissionType = TransmissionType;
            car.EngineType = EngineType;
            car.EngineDisplacement = EngineDisplacement;
            car.Horsepower = Horsepower;
            car.DriveType = DriveType;
            car.Doors = Doors;
            car.Seats = Seats;
            car.BodyStyle = BodyStyle;
            car.InteriorColor = InteriorColor;
            car.ExteriorColor = ExteriorColor ?? Color;
            car.HasAirConditioning = HasAirConditioning;
            car.HasABS = HasABS;
            car.HasAirbags = HasAirbags;
            car.AudioSystem = AudioSystem;
            car.TrunkCapacity = TrunkCapacity;
            car.FuelType = FuelType;

            return car;
        }
    }
}