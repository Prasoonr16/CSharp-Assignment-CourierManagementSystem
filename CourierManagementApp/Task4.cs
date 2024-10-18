using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CodingTasks
{
    public class Task4
    {
        // Task 4: Strings,2d Arrays, user defined functions,Hashmap 
        public static void Main(string[] args)
        {
            //9. Parcel Tracking: Create a program that allows users to input a parcel tracking number.Store the
            //   tracking number and Status in 2d String Array. Initialize the array with values.Then, simulate the
            //   tracking process by displaying messages like "Parcel in transit," "Parcel out for delivery," or "Parcel 
            //   delivered" based on the tracking number's status. 

            string[,] parcels = new string[,]
            {
                {"T01","Parcel in transit" },
                {"T02","Parcel out for delivery" },
                {"T03","Parcel delivered" },
                {"T04","Parcel in transit" }

            };

            Console.Write("Enter the tracking number: ");
            string trackingNumber = Console.ReadLine();


            // Search for the tracking number in the array
            bool found = false;
            for (int i = 0; i < parcels.GetLength(0); i++)
            {
                if (parcels[i, 0] == trackingNumber)
                {
                    // Display the status of the parcel
                    Console.WriteLine("Tracking Number: " + parcels[i, 0] + "\nStatus: " + parcels[i, 1]);
                    found = true;
                    break;
                }
            }

            //If the tracking number was not found
            if (!found)
            {
                Console.WriteLine("Tracking number not found.");
            }


            //10.Customer Data Validation: Write a function which takes 2 parameters, data - denotes the data and
            //    detail - denotes if it is name addtress or phone number.Validate customer information based on
            //    following critirea.


            Console.Write("Enter the Data: ");
            string _data = Console.ReadLine();
            Console.Write("Enter the Details: ");
            string _detail = Console.ReadLine();
            ValidateCustomerInfo(_data, _detail);

            // Function to validate Customer Info

            void ValidateCustomerInfo(string data, string detail)
            {
                bool ans = true;
                if (detail.ToLower() == "name")
                {
                    foreach (char c in data)
                    {
                        if (!char.IsLetter(c) && (!char.IsUpper(data[0])))
                        {
                            Console.WriteLine("Data is not name");
                            ans = false;
                            break;
                        }
                    }
                    if (ans)
                    {
                        Console.WriteLine("Data is name.");
                    }

                }
                else if (detail.ToLower() == "address")
                {
                    foreach (char c in data)
                    {
                        if (!char.IsLetterOrDigit(c) && c != ' ')
                        {
                            Console.WriteLine("Data is not address.");
                            ans = false;
                            break;
                        }
                    }
                    if (ans)
                    {
                        Console.WriteLine("Data is address");
                    }
                }
                else if (detail.ToLower() == "phone number")
                {
                    if (data.Length != 10)
                    {
                        Console.WriteLine("Data is not Phone number");
                    }
                    foreach (char i in data)
                    {
                        if (Char.IsDigit(i))
                        {
                            continue;
                        }
                        else
                        {
                            if (!char.IsDigit(data[i]))
                                Console.WriteLine("Data is not Phone Number");
                        }
                    }
                    Console.WriteLine("Data is Phone number");
                }
                else
                {
                    Console.WriteLine("Invalid data and detail");
                }
            }




            //11. Address Formatting: Develop a function that takes an address as input (street, city, state, zip code) 
            //    and formats it correctly, including capitalizing the first letter of each word and properly formatting the
            //    zip code.


            Console.WriteLine("Enter the address:");
            string Address = Console.ReadLine();

            Console.WriteLine("Enter the City:");
            string City = Console.ReadLine();

            Console.WriteLine("Enter the State:");
            string State = Console.ReadLine();

            Console.WriteLine("Enter the zip code:");
            string zipCode = Console.ReadLine();

            string formattedAddress = FormatAddress(Address, City, State, zipCode);
            Console.WriteLine("\nFormatted Address:");
            Console.WriteLine(formattedAddress);

            // Function to format the entire address
            string FormatAddress(string address, string city, string state, string zipCode)
            {
                address = CapitalizeWords(address);
                city = CapitalizeWords(city);
                state = CapitalizeWords(state);
                zipCode = FormatZipCode(zipCode);

                return $"{address}, {city}, {state} {zipCode}";
            }

            // Function to capitalize words
            string CapitalizeWords(string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                    return input;

                string[] words = input.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (!string.IsNullOrEmpty(words[i]))
                    {
                        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                    }
                }

                return string.Join(" ", words);
            }

            // Function to format the zip code
            string FormatZipCode(string zipCode)
            {
                if (zipCode.Length == 6 && IsNumeric(zipCode))
                {
                    return zipCode;
                }
                else
                {
                    return ("Invalid ZIP code format. It must be a 6-digit number.");
                }


            }
            // Helper function to check if the string contains only numeric digits
            bool IsNumeric(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
                return true;
            }



            // 12. Order Confirmation Email: Create a program that generates an order confirmation email. The email 
            //     should include details such as the customer's name, order number, delivery address, and expected 
            //     delivery date.

            Console.WriteLine("Enter Customer Name :");
            string Customername = Console.ReadLine();

            Console.WriteLine("Enter Order Number :");
            string OrderNumber = Console.ReadLine();

            Console.WriteLine("Enter Delivery Address :");
            string DeliveryAddress = Console.ReadLine();

            Console.WriteLine("Enter City :");
            string DeliveryCity = Console.ReadLine();

            Console.WriteLine("Enter State :");
            string DeliveryState = Console.ReadLine();

            Console.WriteLine("Enter Zip Code :");
            string ZipCode = Console.ReadLine();

            Console.WriteLine("Enter Expected Delivery Date(MM/DD/YYYY) :");
            string ExpectedDeliveryDate = Console.ReadLine();

            string EmailMessage = GenerateOrderConfirmationMail(Customername, OrderNumber, DeliveryAddress, City, State, ZipCode, ExpectedDeliveryDate);

            Console.WriteLine("\nOrder Confirmation Email :");
            Console.WriteLine(EmailMessage);

            // Function to generate order confirmation mail

            String GenerateOrderConfirmationMail(string Customername, string OrderNumber, string DeliveryAddress, string City, string State, string ZipCode, string ExpectedDeliveryDate)
            {
                string Email = $"Dear {Customername},\n\n" +
                           $"Thank you for ordering from us!\n\n" +
                           $"Order Number: {OrderNumber}\n" +
                           $"Delivery Address: {DeliveryAddress}, {City}, {State} {ZipCode}\n" +
                           $"Expected Delivery Date: {ExpectedDeliveryDate}\n\n" +
                           $"Looking forward to delivering your order.";
                return Email;

            }

            //13. Calculate Shipping Costs: Develop a function that calculates the shipping cost based on the distance 
            //    between two locations and the weight of the parcel.You can use string inputs for the source and
            //    destination addresses.

            Console.WriteLine("Enter the Distance (in kilometers):");
            string distanceInput = Console.ReadLine();
            double dist;

            if (!double.TryParse(distanceInput, out dist) || dist <= 0)
            {
                Console.WriteLine("Invalid distance entered. Please enter a positive number.");
                return;
            }

            Console.WriteLine("Enter the weight of the parcel:");
            string weightInput = Console.ReadLine();
            double weight;

            if (!double.TryParse(weightInput, out weight) || weight <= 0)
            {
                Console.WriteLine("Invalid weight entered. Please enter a positive number.");
                return;
            }

            // Function to calculate Shipping cost

            CalculateShippingCost(dist, weight);

            double CalculateShippingCost(double distance, double weight)
            {
                const double baseRate = 50.00; // Base shipping cost
                const double ratePerKm = 10.00; // Cost per kilometer
                const double ratePerKg = 15.00; // Cost per kilogram

                double totalCost = baseRate + (ratePerKm * distance) + (ratePerKg * weight);
                return totalCost;
            }



            // 14. Password Generator: Create a function that generates secure passwords for courier system
            //     accounts.Ensure the passwords contain a mix of uppercase letters, lowercase letters, numbers, and
            //     special characters.


            Console.Write("Enter the lenthg of password you want: ");
            int passwordLength = Convert.ToInt32(Console.ReadLine());
            string randomPassword;
            randomPassword = CreateRandomPassword(passwordLength);
            Console.WriteLine(randomPassword);

            // Function to genrate random password

            string CreateRandomPassword(int passwordLength)
            {
                string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
                char[] chars = new char[passwordLength];
                Random rd = new Random();

                for (int i = 0; i < passwordLength; i++)
                {
                    chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
                }

                return new string(chars);
            }




            // 15. Find Similar Addresses: Implement a function that finds similar addresses in the system. This can be 
            //     useful for identifying duplicate customer entries or optimizing delivery routes.Use string functions to
            //     implement this.

            List<string> addresses = new List<string>
        {
            "Vallabh Nagar, Indore",
            "Vallabh Nagar, Indore",
            "Indrapuri, Bhopal",
            "Indrapuri, Bhopal, MP"

        };

            var similarAddresses = FindSimilarAddresses(addresses);
            foreach (var pair in similarAddresses)
            {
                Console.WriteLine($"Similar Addresses: \n1. {pair.Item1} \n2. {pair.Item2}\n");
            }

            List<Tuple<string, string>> FindSimilarAddresses(List<string> addresses)
            {
                var similarPairs = new List<Tuple<string, string>>();

                for (int i = 0; i < addresses.Count; i++)
                {
                    for (int j = i + 1; j < addresses.Count; j++)
                    {
                        // Normalize both addresses: trim spaces and convert to lowercase
                        string normalizedAddress1 = addresses[i].Trim().ToLower();
                        string normalizedAddress2 = addresses[j].Trim().ToLower();

                        // Compare normalized addresses
                        if (string.Equals(normalizedAddress1, normalizedAddress2))
                        {
                            similarPairs.Add(new Tuple<string, string>(addresses[i], addresses[j]));
                        }
                    }
                }

                return similarPairs;
            }
        }
    }
}

