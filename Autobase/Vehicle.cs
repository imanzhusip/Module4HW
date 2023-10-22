using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobase
{
    public class Vehicle
    {
        public string VehicleId { get; set; }
        public string VehicleType { get; set; }
    }

    public class Driver
    {
        public string DriverId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } // "Работает" или "Отстранен"
        public Vehicle AssignedVehicle { get; set; }
    }

    public class Dispatcher
    {
        public void AssignDriverToVehicle(Driver driver, Vehicle vehicle)
        {
            driver.AssignedVehicle = vehicle;
        }

        public void SuspendDriver(Driver driver)
        {
            driver.Status = "Отстранен";
        }

        public void RecordTripCompletion(Driver driver)
        {
            Console.WriteLine($"Водитель {driver.Name} выполнил рейс на автомобиле {driver.AssignedVehicle.VehicleId}");
        }
    }
}
