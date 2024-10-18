using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTasks
{
    public class Task3
    {
        // Task 3: Arrays and Data Structures

        public static void Main(string[] args)
        {
            //  7. Create an array to store the tracking history of a parcel, where each entry represents a location
            //     update

            string[] trackingHistory = new string[5];

            trackingHistory[0] = "Parcel picked up from sender";
            trackingHistory[1] = "Arrived at local sorting center";
            trackingHistory[2] = "In transit to destination city";
            trackingHistory[3] = "Arrived at destination sorting center";
            trackingHistory[4] = "Out for delivery";

            Console.WriteLine("Tracking History for the Parcel:");
            for (int i = 0; i < trackingHistory.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {trackingHistory[i]}");
            }


            // 8. Implement a method to find the nearest available courier for a new order using an array of couriers.

            // Array of couriers using tuples
            var couriers = new (string Name, double Latitude, double Longitude, bool IsAvailable)[]
             {
                ("Courier A", 37.7749, -122.4194, true),
                ("Courier B", 40.7128, -74.0060, false),
                ("Courier C", 34.0522, -118.2437, true)
             };

            var nearest = FindNearestCourier(couriers, 36.7783, -119.4179);  // Example user's location

            // Output the result
            if (nearest != null)
                Console.WriteLine("Nearest available courier: " + nearest.Value.Name);
            else
                Console.WriteLine("No available couriers.");

            // Method to find the nearest available courier

            static (string Name, double Latitude, double Longitude, bool IsAvailable)? FindNearestCourier(
                (string Name, double Latitude, double Longitude, bool IsAvailable)[] couriers,
                double userLat, double userLong)

            {
                (string Name, double Latitude, double Longitude, bool IsAvailable)? nearest = null;  // To store the nearest available courier
                double minDistance = double.MaxValue;  // Start with a large number for the minimum distance

                foreach (var courier in couriers)  // Loop through all couriers
                {
                    if (!courier.IsAvailable)  // Skip if the courier is not available
                        continue;

                    // Calculate the distance using the Euclidean distance formula
                    double distance = Math.Sqrt(
                        Math.Pow(courier.Latitude - userLat, 2) +
                        Math.Pow(courier.Longitude - userLong, 2));

                    // If this courier is closer, update the nearest courier and the minimum distance
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearest = courier;
                    }
                }

                return nearest;
            }
        }
    }
}