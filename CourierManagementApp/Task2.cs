using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodingTasks.Task1;

namespace CodingTasks
{
    public class Task2
    {
        // Task 2: Loops and Iteration

            public static void Main(string[] args)
            {
                // 5.Write a program that uses a for loop to display all the orders for a specific customer

                List<(int orderid, int customerid, string orderdetails)> orders = new List<(int, int, string)>
            {
                (1, 101, "Courier from City A to City B"),
                (2, 102, "Courier from City C to City D"),
                (3, 101, "Courier from City E to City F"),
                (4, 103, "Courier from City G to City H"),
                (5, 101, "Courier from City I to City J")
            };

                Console.WriteLine("Enter CustomerID to display their orders:");
                int customerid = int.Parse(Console.ReadLine());

                Console.WriteLine($"Orders for CustomerID {customerid}: ");
                int count = 0;
                foreach (var order in orders)
                {
                    if (order.customerid == customerid)
                    {
                        Console.WriteLine($"Order ID: {order.orderid}, Details: {order.orderdetails}");
                        count++;
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("No order for this customer.");
                }

                // 6. Implement a while loop to track the real-time location of a courier until it reaches its destination.

        private static List<Courier> courierList = new List<Courier>
        {
            new Courier(1, "Alice", "123 Elm St", "Bob", "456 Oak St", 5.0m, "In Transit", "TRACK123", DateTime.Now.AddDays(3), 10.0m),
            new Courier(2, "Charlie", "789 Pine St", "Diana", "101 Maple St", 2.5m, "Delivered", "TRACK456", DateTime.Now.AddDays(2), 8.0m),

        };
        public static void TrackCourier(int courierID)
        {


            // Find the courier
            var courier = courierList.FirstOrDefault(c => c.CourierID == courierID);



            if (courier == null)
            {
                Console.WriteLine("Courier not found.");
                return;
            }

            Console.WriteLine($"Tracking Courier {courier.SenderName}...");


            while (courier.CurrentLocation != courier.ReceiverAddress)
            {

                if (courier.CurrentLocation == courier.SenderAddress)
                {
                    Console.WriteLine($"Courier {courier.SenderName} is en route to {courier.ReceiverAddress}.");
                    courier.CurrentLocation = "In Transit";
                }
                else if (courier.CurrentLocation == "In Transit")
                {

                    courier.CurrentLocation = courier.ReceiverAddress;
                    Console.WriteLine($"Courier {courier.SenderName} has reached the destination: {courier.ReceiverAddress}.");
                    break;
                }


                Thread.Sleep(2000);
            }
        }

    }
}
}
