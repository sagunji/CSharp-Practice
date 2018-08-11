using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace CarParkManager
{
    class DummyCars
    {
        static readonly List<string> carMakes = new List<string>()
        {
            "Abarth", "Alfa Romeo", "Aston Martin", "Audi","Australian Classic Car","Bentley","BMC","BMW","Bugatti",
            "Chevrolet","Daihatsu","Datsun","Ferrari","Fiat","Ford","Honda","Hummer","Hyundai","Lamborghini",
            "Mercedes-Benz","Nissan","Rolls-Royce", "SKODA", "Suzuki", "Tesla", "Toyota", "Volkswagen", "Volvo"
        };
        static readonly List<string> carModels = new List<string>()
        {
            "Model T","Imperial","2CV","Minx Magnificent","Corvette","Fleetwood","Thunderbird","600","Corvair","Mini",
            "Fleetwood","Rockette","Mini Cooper","Avanti","Tempest","Grand Prix","Special","E-Series","Classic","5000S",
            "F430","Phantom","Roadster","Jetta"
        };
        static readonly List<string> names = new List<string>()
        {
            "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian",
             "Mary", "Marie", "Mariam", "Marina", "Irene", "Malak", "Habiba", "Hana", "Farah", "Marwa", "Nada", "Salma"
        };

        static readonly List<string> numberPlates = new List<string>()
        {
            "ABC123", "XYZ987", "QWERTY", "ASDFGH", "ZXCVB", "123456", "987654", "QAZWSX", "EDCRFV"
        };

        static readonly List<string> color = new List<string>()
        {
            "red", "yellow", "green", "blue", "navy", "purple", "violet", "black", "gray", "white"
        };

        static string generatePhoneNumber(int length = 10)
        {
            var seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);
            Random rand = new Random(seed);
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, rand.Next(10).ToString());
            return s;
        }

        public static List<Car> CreateDummyCars(int n = 5)
        {
            List<Car> dummyCars = new List<Car>();
            
            Random rand;
            for (int i = 0; i < n; i++)
            {
                rand = new Random();
                Car car = new Car();
                car.Make = (string)(carMakes[rand.Next(carMakes.Count)]);
                car.Model = (string)(carModels[rand.Next(carModels.Count)]);
                car.Color = color[i];
                car.NumberPlate = numberPlates[i];
                car.OwnerName = (string)(names[rand.Next(names.Count)]);
                car.OwnerContactNumber = generatePhoneNumber();
                car.generateID();
                dummyCars.Add(car);
            }
            return dummyCars;
        }
    }
}
