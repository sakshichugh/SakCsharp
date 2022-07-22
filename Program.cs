using System;
using System.IO;

    
    


namespace Assessment2
{ 
 

  public class Vehicles
  {
    public string registration;
    public string make;
    public string model;
    public int kilometers;
    public Drivers driver;                   

    public Vehicles(string registration, string make, string model, int kilometers, Drivers driver)
    {
        this.registration = registration;
        this.make = make;
        this.model = model;
        this.kilometers = kilometers;
        this.driver = driver;                          //Aggregating a driver object with Vehicle object
    }
    
    public void UpdateKilometer(int newKilometer)     //Method to update the kilometer readings
    {
            

        if (newKilometer < 0)
        {
            Console.WriteLine("ERROR::INVALID KILOMETER READINGS,PlEASE! ENTER THE VALID VALUE AGAIN.");
        }

        else 
        {
          kilometers = newKilometer + kilometers; 
        }

    }

    public virtual void DisplayAll()                       //A Base Class Containing a Virtual Method      
    {
        Console.WriteLine("-------------------------------------------------------------------------------------------");
        Console.WriteLine("Vehicle Details::");           //Method to display Vehicle general details
        Console.WriteLine("\n Rego is " + registration + " . " + " Make is " + make + " . " + " Model is " + model + " . " + " Kilometer's are " + kilometers);
    }

    public void DisplayGenandDriver()      //Method to display vehicle and driver details
    {
        Console.WriteLine("Vehicle Details::" );
        Console.WriteLine("\n Rego is " + registration + " . " + " Make is " + make + " . " + " Model is " + model + " . " + " Kilometer's are " + kilometers);
        Console.Write("Driver Details:: ");
        driver.DisplayDriver();


    }
  }

    //-----------------------------------Class Cars---------------------------------------------------//
    public class Cars : Vehicles
    {
        public string bodyType;
        public string colour;
        public string upholstery;
        public int doors;

         public Cars(string bodyType, string colour, string upholstery, int doors, string registration, string make, string model, int kilometers, Drivers driver)
           : base(registration, make, model, kilometers, driver)


         {
            this.bodyType = bodyType;
            this.colour = colour;
            this.upholstery = upholstery;
            this.doors = doors;

         }

        public void ChangeColour(string newColour)                   //Method to display changed Car Colour
        {
            colour = newColour;
        }

        public void DisplayCarSpecific()                           // Method to display Specific Details of Cars
        {
            Console.WriteLine(" ");
            Console.WriteLine("Car Specific Data::");
            Console.WriteLine("Body type is: " + bodyType + " . Colour is:  " + colour + " . Upholsestery is:  " + upholstery + " .Number of Doors is:  " + doors);
        }


        public void DisplayCarGeneral()                      //Method to display General details of cars   
        {
            base.DisplayAll();
        }                                                                        
                                                           
        public override void DisplayAll()                      //Method to display All Cars Details with Driver Details
        {
        
            base.DisplayAll();                                 //Override the Virtual Method
            driver.DisplayDriver();
            DisplayCarSpecific();
        }
        public void DisplayCarGenSpec()                        //Method to display Specific and General Details of Cars
        {
            base.DisplayAll();
            DisplayCarSpecific();
        }

                                   
        
            

        
    }
    //-----------------------------------Class Truck------------------------------------------------//
    public class Trucks : Vehicles
    {
        public int load;
        public int axels;
        public int wheels;


        public Trucks(int load, int axels, int wheels, string registration, string make, string model, int kilometers, Drivers driver)
           : base(registration, make, model, kilometers, driver)


        {
            this.load = load;
            this.axels = axels;
            this.wheels = wheels;


        }

        public void DisplayTruckSpecific()                               // Method to display Specific Details of Truck
        {
            Console.WriteLine();
            Console.WriteLine("Truck Specific Data::");
            Console.WriteLine(" Max Load Capacity: " + load + " . No.of Axels  " + axels + " . No.of Wheels:  " + wheels);
        }
        public override void DisplayAll()                                   //Method to display All Truck details with Driver
        {
            base.DisplayAll();
            driver.DisplayDriver();                                      //Override the Virtual Method(Polymorphism)
            DisplayTruckSpecific();

        }

        public void DisplayTruckGeneral()                                  //Method to display General details of Trucks
        {
            base.DisplayAll();
        }

        public void DisplayTruckGenSpec()                                 //Method to display General and Specific details of Truck
        {
            base.DisplayAll();
            DisplayTruckSpecific();
        }
    }
    //----------------------------------Class Driver--------------------------------------------------//
    public class Drivers
    {
        public int licenceNo;
        public string firstname;
        public string lastname;
        public int mobileNo;
        public string[] address;
        public string[] states;
        public int demerit;
        static int maxDemeritPoint = 12;                              // Static Variable

        public Drivers(int licenceNo, string firstname, string lastname, int mobileNo, string[] address, string[] states, int demerit)
        {
            this.licenceNo = licenceNo;
            this.firstname = firstname;
            this.lastname = lastname;
            this.mobileNo = mobileNo;
            this.address = address;
            this.states = states;
            this.demerit = demerit;
        }
        public void DisplayDriver()
        {
            Console.WriteLine(" Driver's Licence No.:    " +  licenceNo + ",   FirstName: " + firstname + ",   LastName: " + lastname + ",   MobileNumber: " + mobileNo + ",   DemeritPoints: " + demerit);

            Console.WriteLine("The driver is licenced to drive in the following states : ");
            foreach (string item in states)
            {
                Console.WriteLine(item);



            }

            Console.Write("\n Driver's Address:  ");

            for (int i = 0; i < address.Length; i++)
            {
                Console.WriteLine(address[i]);
            }
        }
        public int UpdatePoint(int demeritPoint)
        {
            demerit = demerit + demeritPoint;

            if (demeritPoint >= maxDemeritPoint)
            {
                Console.WriteLine("***Warning::Suspended Licenced***");
            }
            else if (demeritPoint >= 9)
            {
                Console.WriteLine("***Licence suspension is imminent***");

            }
            return demerit;
        }

        public void WriteDriver()
        {
           File.AppendAllText(@"C:\\abc\\csc.txt", licenceNo + "   " + firstname + "  " + lastname + "  " + mobileNo + "   " + demerit + "\n"); 
           File.AppendAllLines(@"C:\\abc\\csc.txt", states);
           File.AppendAllLines(@"C:\\abc\\csc.txt", address);
        }
        

        public void ReadDriver()
        {
            string contents = File.ReadAllText(@"C:\\abc\\csc.txt");
            Console.WriteLine(contents);

    }   }



    
//---------------------------------------Class Program-------------------------------------------------//

 
    class Program
    {

        static void Main(string[] args)
        {
            string[] address1 = { "Street: 111 King St", "City:  Melbourne", "State:  Victoria", "Postcode:  3000" };
            string[] address2 = { "Street: 23 Queens St", "City:  Brisbane", "State:  Queensland", "Postcode:  5000" };
                       
            string[] state1 = { "QLD :", "VIC :"};
            string[] state2 = { "TAS :", "VIC :"};
            
            Drivers driver1 = new Drivers(12121, "Tom", "Jones", 049899889, address1, state1, 5);
            Drivers driver2 = new Drivers(12876, "John", "Brown", 0487877898, address2, state2, 8);
            
            Cars car1 = new Cars("Sedan", "blue", "leather", 4, "123ABC", "Honda", "SuperDuper", 4000 ,driver1);
            Cars car2 = new Cars( "Hatchback", "silver", "leather", 4, "XYZ987", "Toyota", "Altis", 3000, driver2);

            Trucks truck1 = new Trucks( 40, 15, 6, "1199AZ", "HONDA", "Hybrid", 10000, driver1);
            Trucks truck2 = new Trucks( 50, 13, 8, "EFG456", "VOLVO", "Z Series", 50000, driver2);

            // Read and Write Driver Details to a File

            driver1.WriteDriver();
            driver2.WriteDriver();
            
            driver1.ReadDriver();
            driver2.ReadDriver();

            //Display General Information

            Console.WriteLine("\n* ********************************Display Driver Details:******************************************************");
            
            driver1.DisplayDriver();
            driver2.DisplayDriver();

            Console.WriteLine("\n*********************************Display Cars General Details:**************************************************");
            car1.DisplayCarGeneral();
            car2.DisplayCarGeneral();
            
            Console.WriteLine("\n**********************************Display Trucks General Detail:*************************************************");

            truck1.DisplayTruckGeneral();
            truck2.DisplayTruckGeneral();
            
            Console.WriteLine("\n***********************************Display Cars Specific Details:**********************************************");

             car1.DisplayCarSpecific();
             car2.DisplayCarSpecific();

            Console.WriteLine("\n*********************************Display Truck Specific Details:************************************************");

            truck1.DisplayTruckSpecific();
            truck2.DisplayTruckSpecific();

            //Display General and Specific Information

            Console.WriteLine("\n**********************************Display Cars General and Specific Details:***************************************");

            car1.DisplayCarGenSpec();
            car2.DisplayCarGenSpec();

            Console.WriteLine("\n**********************************Display Truck General and Specific Details:**************************************");

            truck1.DisplayTruckGenSpec();
            truck2.DisplayTruckGenSpec();

            //Display All Cars Details with Driver Details

            Console.WriteLine("\n************************************Display Car All Detailswith Driver:********************************************");

            car1.DisplayAll();
            

            car2.DisplayAll();


            //Display All Trucks  Details with Driver Details

            
            Console.WriteLine("\n*************************************Display Truck All Details with Driver:***************************************");

             truck1.DisplayAll();
             truck2.DisplayAll();

            // Make Changes in Car Colour,Update Kilometers and Display Again

            Console.WriteLine("\n**************************************Display Car Updated Details:*************************************************");

            car1.DisplayCarGenSpec();
            car2.DisplayCarGenSpec();

            car1.ChangeColour("Black");
            car2.ChangeColour("White");

            car1.UpdateKilometer(75);
            car2.UpdateKilometer(80);

            car1.DisplayCarGenSpec();
            car2.DisplayCarGenSpec();


            Console.WriteLine("\n*************************************Display Truck Updated Details:************************************************");

            truck1.DisplayTruckGenSpec();
            truck2.DisplayTruckGenSpec();

            truck1.UpdateKilometer(-60);
            truck2.UpdateKilometer(100);

            truck1.DisplayTruckGenSpec();
            truck2.DisplayTruckGenSpec();
            
            // Make Changes in Driver Update Demeritpoints and Display Again

            Console.WriteLine("\n***********************************Display Driver Updated Details:************************************************");
            
            //Display before Update
            driver1.DisplayDriver();
            driver2.DisplayDriver();

            driver1.UpdatePoint(4);
            driver2.UpdatePoint(13);
            
            // Display after Update
            driver1.DisplayDriver();
            driver2.DisplayDriver();







        }


    }

}

    

