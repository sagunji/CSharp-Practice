using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkManager
{
    class Program
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("\n\n\t\t****** Car Park Manager ******");
            Console.WriteLine("1. Register a car");
            Console.WriteLine("2. Seach all cars");
            Console.WriteLine("3. Check in a car");
            Console.WriteLine("4. Check a car out");
            Console.WriteLine("5. Checked in report");
            Console.WriteLine("6. Exit");
        } 
        public static Car RegisterACar ()
        {
            Car car = new Car();

            Console.Write("Enter Number Plate: ");
            car.NumberPlate = Console.ReadLine();
            Console.Write("\nEnter car make: ");
            car.Make= Console.ReadLine();
            Console.Write("\nEnter car model: ");
            car.Model= Console.ReadLine();
            Console.Write("\nEnter car color: ");
            car.Color = Console.ReadLine();
            Console.Write("\nEnter Owner Name: ");
            car.OwnerName = Console.ReadLine();
            Console.Write("\nEnter Owner Number: ");
            car.OwnerContactNumber = Console.ReadLine();
            return car;
        }


        public static void ShowCarDetails (CarStatus carStatus)
        {
            Console.WriteLine($"ID: {carStatus.car.ID}");
            Console.WriteLine($"Number Plate: {carStatus.car.NumberPlate}");
            Console.WriteLine($"Make: {carStatus.car.Make}");
            Console.WriteLine($"Model: {carStatus.car.Model}");
            Console.WriteLine($"Color: {carStatus.car.Color}");
            Console.WriteLine($"Owner Name: {carStatus.car.OwnerName}");
            Console.WriteLine($"Owner Contant Number: {carStatus.car.OwnerContactNumber}");
            Console.WriteLine($"Checked in status: {carStatus.checkInStatus}");
        }
        public static void ShowCheckedInCars (List<Car> cars)
        {
            Console.WriteLine("/nList of all cars that are checked in.");
            foreach (var car in cars)
            {
                Console.WriteLine($"Number Plate: {car.NumberPlate}");
            }
        }

        static void Main(string[] args)
        {
            bool exitCommand = false;
            ParkingLot parkingLot = new ParkingLot();
            List<Car> dummyCars = DummyCars.CreateDummyCars();
            parkingLot.RegisterCar(dummyCars);
            char[] availableCases =  { '1', '2', '3', '4', '5', '6' };
            do
            {
                DisplayMenu();
                char selection = new char();
                do
                {
                    Console.Write("Select any one option: ");
                    selection = Console.ReadKey().KeyChar;
                } while (!availableCases.Contains(selection));
                Console.WriteLine();
                switch (selection)
                {
                    case '1':
                        Car newCarEntry = RegisterACar();
                        parkingLot.RegisterCar(newCarEntry);
                        break;
                    case '2':
                        Console.Write("Enter number plate to be searched: ");
                        string searchText = Console.ReadLine();
                        Console.WriteLine();
                        List<CarStatus> cars = parkingLot.SearchBy(searchText);
                        foreach (var car in cars)
                        {
                            ShowCarDetails(car);
                        }
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Write("Enter the number plate of the car to check in: ");
                        string chkNumberPlate = Console.ReadLine();
                        parkingLot.CheckCarIn(chkNumberPlate);
                        break;
                    case '4':
                        Console.Write("Enter the number plate of the car to check out: ");
                        string coutNumplate = Console.ReadLine();
                        parkingLot.checkOutCar(coutNumplate);
                        break;
                    case '5':
                        List<Car> checkInCars = parkingLot.getAllCheckedInCars();
                        foreach (var checkedIns in checkInCars)
                        {
                            Console.WriteLine("Cars which have parked in: ");
                            Console.WriteLine(checkedIns.NumberPlate);
                        }
                        break;
                    case '6':
                        exitCommand = true;
                        break;
                    default:
                        continue;
                }
            } while (!exitCommand);
            Console.WriteLine("You have exited the program.");
            Console.ReadKey();
        }
    }
}
