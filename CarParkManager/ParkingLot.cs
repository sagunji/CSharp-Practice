using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkManager
{
    class ParkingLot
    {
        string address = "";
        string name = "";
        List<Car> registeredCar = new List<Car>();
        List<Guid> checkedInCar = new List<Guid>();

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public List<Car> RegisteredCar
        {
            get
            {
                return registeredCar;
            }
            set
            {
                registeredCar = value;
            }
        }
        public List<Guid> CheckedInCar
        {
            get
            {
                return checkedInCar;
            }
            set
            {
                checkedInCar = value;
            }
        }
        public bool isCarRegistered(string numberPlate)
        {
            Car tempCar = RegisteredCar.Find(rcar => 
                          rcar.NumberPlate.ToLower() == numberPlate.ToLower());

            return tempCar != null;
        }

        public bool isCarCheckedIn(Guid id)
        {
            return CheckedInCar.Contains(id);
        }

        public void RegisterCar (Car car)
        {
            if (isCarRegistered(car.NumberPlate))
            {
                Console.WriteLine("The car is already registered!!");
                return;
            }
            RegisteredCar.Add(car);
            Console.WriteLine($"New Car Id: {car.ID}");
        }
        public void RegisterCar(List<Car> cars)
        {
            foreach (var item in cars)
            {
                if (!isCarRegistered(item.NumberPlate))
                {
                    RegisteredCar.Add(item);
                }
            }
        }
        public void CheckCarIn (string numberPlate)
        {
            if (!isCarRegistered(numberPlate))
            {
                Console.WriteLine("The car is not registered yet. You cannot check unregistered car!!");
                return;
            }
            Car foundCar = RegisteredCar.Find(car => car.NumberPlate.ToLower() == numberPlate.ToLower());
            if (isCarCheckedIn(foundCar.ID))
            {
                Console.WriteLine("The car is already checked in!!");
                return;
            }
            CheckedInCar.Add(foundCar.ID);
            Console.WriteLine("The car of number plate {0} has been registered.", numberPlate);
        }
        public void checkOutCar(string numberPlate)
        {
            if (!isCarRegistered(numberPlate))
            {
                Console.WriteLine("The car is not registered yet. You cannot check out unregistered car!!");
                return;
            }
            Car foundCar = RegisteredCar.Find(car => car.NumberPlate.ToLower() == numberPlate.ToLower());
            if (!isCarCheckedIn(foundCar.ID))
            {
                Console.WriteLine("The car is not checked in!!");
                return;
            }
            CheckedInCar.Remove(foundCar.ID);
            Console.WriteLine("The car of number plate {0} has checked out!!", numberPlate);
        }
        public List<CarStatus> SearchBy (string key)
        {
            List<Car> foundCars = RegisteredCar.FindAll(rcar => rcar.NumberPlate.ToLower() == key.ToLower());
            List<CarStatus> carStatus = new List<CarStatus>();
            CarStatus cs;
            foreach (var car in foundCars)
            {
                cs = new CarStatus();
                cs.car = car;
                cs.checkInStatus = isCarCheckedIn(car.ID);
                carStatus.Add(cs);
            }
            return carStatus;
        }
        public List<Car> getAllCheckedInCars()
        {
            return RegisteredCar.FindAll(rcar => CheckedInCar.Contains(rcar.ID));
        }
    }
}
