using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTasks
{
    public class Task1
    {
        public static void Main(string[] args)
        {
            // 1. Write a program that checks whether a given order is delivered or not based on its status (e.g., 
            //    "Processing," "Delivered," "Cancelled"). Use if-else statements for this.

            Console.WriteLine("Enter order status (Processing, Delivered, Cancelled): ");
            string status = Console.ReadLine();

            if (status == "Processing")
            {
                Console.WriteLine("Your order is still being processed.");
            }
            else if (status == "Delivered")
            {
                Console.WriteLine("Your order has been delivered.");
            }
            else if (status == "Cancelled")
            {
                Console.WriteLine("Your order has been cancelled.");
            }
            else
            {
                Console.WriteLine("Invalid order status.");
            }

            // 2. Implement a switch-case statement to categorize parcels based on their weight into "Light," 
            //    "Medium," or "Heavy."

            Console.WriteLine("Enter parcel weight (in kg): ");
            double weight = Convert.ToDouble(Console.ReadLine());

            switch (weight)
            {
                case < 5.0:
                    Console.WriteLine("The parcel is categorized as Light.");
                    break;
                case < 20.0:
                    Console.WriteLine("The parcel is categorized as Medium.");
                    break;
                case >= 20.0:
                    Console.WriteLine("The parcel is categorized as Heavy.");
                    break;
                default:
                    Console.WriteLine("Invalid weight.");
                    break;
            }

            // 3. Implement User Authentication 1. Create a login system for employees and customers using Java 
            //    control flow statements.

            string employeeUsername = "Raj123";
            string employeePassword = "empPass";
            string customerUsername = "Ankit123";
            string customerPassword = "custPass";

            Console.WriteLine("Enter your role (Employee - E or Customer - C):");
            char role = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            if (role == 'E')
            {
                if (username == employeeUsername && password == employeePassword)
                {
                    Console.WriteLine("Employee login successful.");
                }
                else
                {
                    Console.WriteLine("Invalid Credentials!!");
                }
            }
            else if (role == 'U')
            {
                if (username == customerUsername && password == customerPassword)
                {
                    Console.WriteLine("Customer login successful.");
                }
                else
                {
                    Console.WriteLine("Invalid Credentials!!");
                }
            }
            else
            {
                Console.WriteLine("Invalid login.");
            }
        }

        // 4. Implement Courier Assignment Logic 1. Develop a mechanism to assign couriers to shipments based 
        //    on predefined criteria(e.g., proximity, load capacity) using loops

        public class Courier
        {
            public int CourierID { get; set; }
            public string SenderName { get; set; }
            public string SenderAddress { get; set; }
            public string ReceiverName { get; set; }
            public string ReceiverAddress { get; set; }
            public decimal Weight { get; set; }
            public string Status { get; set; }
            public string TrackingNumber { get; set; }
            public DateTime DeliveryDate { get; set; }
            public decimal LoadCapacity { get; set; } // Maximum weight the courier can carry
            public bool IsAvailable { get; set; } = true; // Courier availability
            public string CurrentLocation { get; set; }
            public Courier(int id, string senderName, string senderAddress, string receiverName, string receiverAddress, decimal weight, string status, string trackingNumber, DateTime deliveryDate, decimal loadCapacity)
            {
                CourierID = id;
                SenderName = senderName;
                SenderAddress = senderAddress;
                ReceiverName = receiverName;
                ReceiverAddress = receiverAddress;
                Weight = weight;
                Status = status;
                TrackingNumber = trackingNumber;
                DeliveryDate = deliveryDate;
                LoadCapacity = loadCapacity;
                CurrentLocation = senderAddress;

            }
        }
        public class Shipment
        {
            public int ShipmentID { get; set; }
            public string Description { get; set; }
            public decimal Weight { get; set; }
            public string Destination { get; set; }

            public Shipment(int shipmentID, string description, decimal weight, string destination)
            {
                ShipmentID = shipmentID;
                Description = description;
                Weight = weight;
                Destination = destination;
            }
        }

        public class CourierAssignment
        {
            public static void AssignCouriersToShipments(List<Courier> couriers, List<Shipment> shipments)
            {
                foreach (var shipment in shipments)
                {
                    foreach (var courier in couriers)
                    {
                        // Check if the courier can carry the shipment weight and is available
                        if (courier.IsAvailable && courier.LoadCapacity >= shipment.Weight)
                        {

                            Console.WriteLine($"Assigned Courier {courier.SenderName} (ID: {courier.CourierID}) to Shipment {shipment.Description} (ID: {shipment.ShipmentID})");
                            courier.IsAvailable = false;
                            shipment.Weight = 0;
                            break;
                        }
                    }
                }
            }


        }
    }
}