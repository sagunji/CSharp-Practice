using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkManager
{
    class Car
    {
        Guid id = Guid.Empty;
        string numberPlate = "";
        string make = "";
        string model = "";
        string color = "";
        string ownerName = "";
        string ownerContactNumber = "";

        public Car()
        {
                
        }
        public Guid ID
        {
            get
            {
                if (id == Guid.Empty)
                {
                    id = Guid.NewGuid();
                }
                return id;
            }
        }
        public void generateID()
        {
            id = Guid.NewGuid();
        }
        public string NumberPlate
        {
            get
            {
                return numberPlate;
            }
            set
            {
                numberPlate = value;
            }
        }
        public string Make
        {
            get
            {
                return make;
            }
            set
            {
                make = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public string OwnerName
        {
            get
            {
                return ownerName;
            }
            set
            {
                ownerName = value;
            }
        }
        public string OwnerContactNumber
        {
            get
            {
                return ownerContactNumber;
            }
            set
            {
                ownerContactNumber = value;
            }
        }
    }
}
