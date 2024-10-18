using DAOLibrary;
using EntityLibrary;
using ExceptionLibrary;
using System.Threading.Channels;

Courier courier = new Courier();

CourierServiceDB service = new CourierServiceDB();

char ans = 'N';

do
{

    Console.WriteLine("1.Insert Courier Data");
    Console.WriteLine("2.Update Courier Data");
    Console.WriteLine("3.Delete Courier Data");
    Console.WriteLine("4.Find Courier Data by Courier ID");
    Console.WriteLine("5.ShowAll Courier Data");
    Console.WriteLine("6.Exit");

    Console.WriteLine("Enter your choice : ");
    int ch = Convert.ToInt32(Console.ReadLine());

    bool status = false;

    switch (ch)
    {
        case 1:
            Console.WriteLine("Enter CourierID : ");
            courier.CourierID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Sender Name : ");
            courier.SenderName = Console.ReadLine();
            Console.WriteLine("Enter Sender Address : ");
            courier.SenderAddress = Console.ReadLine();
            Console.WriteLine("Enter Receiver Name : ");
            courier.ReceiverName = Console.ReadLine();
            Console.WriteLine("Enter Receiver Address : ");
            courier.ReceiverAddress = Console.ReadLine();
            Console.WriteLine("Enter Weight : ");
            courier.Weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Status : ");
            courier.Status = Console.ReadLine();
            Console.WriteLine("Enter Tracking Number : ");
            courier.TrackingNumber = Console.ReadLine();
            Console.WriteLine("Enter Delivery Date : ");
            courier.DeliveryDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter UserID : ");
            courier.UserID = Convert.ToInt32(Console.ReadLine());
            try
            {
                status = service.InsertCourierData(courier);

                if (status)
                {
                    Console.WriteLine("Inserted Successfully...");
                }
                else
                {
                    Console.WriteLine("Insertion failed, please check the code...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            break;
        case 2:
            Console.WriteLine("Enter CourierID to update : ");
            courier.CourierID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Sender Name : ");
            courier.SenderName = Console.ReadLine();
            Console.WriteLine("Enter Sender Address : ");
            courier.SenderAddress = Console.ReadLine();
            Console.WriteLine("Enter Receiver Name : ");
            courier.ReceiverName = Console.ReadLine();
            Console.WriteLine("Enter Receiver Address : ");
            courier.ReceiverAddress = Console.ReadLine();
            Console.WriteLine("Enter Weight : ");
            courier.Weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Status : ");
            courier.Status = Console.ReadLine();
            Console.WriteLine("Enter Tracking Number : ");
            courier.TrackingNumber = Console.ReadLine();
            Console.WriteLine("Enter Delivery Date : ");
            courier.DeliveryDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter UserID : ");
            courier.UserID = Convert.ToInt32(Console.ReadLine());
            try
            {
                status = service.UpdateCourier(courier.CourierID, courier);

                if (status)
                {
                    Console.WriteLine("Updated Successfully...");
                }
                else
                {
                    Console.WriteLine("Update failed, please check the code...");
                }
            }
            catch (CourierNotFoundException ex)
            {
                Console.WriteLine("Courier Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during update: " + ex.Message);
            }
            break;
        case 3:
            Console.WriteLine("Enter CourierId to delete : ");
            int c_id = Convert.ToInt32(Console.ReadLine());
            try
            {
                status = service.DeleteCourier(c_id);
                if (status)
                {
                    Console.WriteLine("Deleted Successfully.");
                }
                else
                {
                    Console.WriteLine("Deletion failed.");
                }
            }
            catch (CourierNotFoundException ex)
            {
                Console.WriteLine("Error : ", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during delete : " + ex.Message);
            }

            break;
        case 4:
            Console.WriteLine("Enter CourierID to find : ");
            c_id = Convert.ToInt32(Console.ReadLine());
            try
            {
                courier = service.FindCourier(c_id);
                Console.WriteLine($"Courier ID : {courier.CourierID}");
                Console.WriteLine($"Sender Name : {courier.SenderName}");
                Console.WriteLine($"Sender Address : {courier.SenderAddress}");
                Console.WriteLine($"Reciver Name : {courier.ReceiverName}");
                Console.WriteLine($"Receiver Address : {courier.ReceiverAddress}");
                Console.WriteLine($"Weight : {courier.Weight}");
                Console.WriteLine($"Status : {courier.Status}");
                Console.WriteLine($"Tracking Number : {courier.TrackingNumber}");
                Console.WriteLine($"Delivery Date : {courier.DeliveryDate}");
                Console.WriteLine($"User ID : {courier.UserID}");
            }
            catch (CourierNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in deleteing: " + ex.Message);
            }
            break;
        case 5:
            try
            {
                List<Courier> courierList = new List<Courier>();
                courierList = service.ShowAllCouriers();
                foreach (Courier c in courierList)
                {
                    Console.WriteLine(c.CourierID + "|" + c.SenderName + "|" + c.SenderAddress + "|" + c.ReceiverName + "|" + c.ReceiverAddress + "|" + c.Weight + "|" + c.Status + "|" + c.TrackingNumber + "|" + c.DeliveryDate + "|" + c.UserID);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during listing: " + ex.Message);
            }
            break;
        case 6:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice!");
            break;

    }
    Console.WriteLine("Do you want to continue (Y/N) : ");
    ans = Convert.ToChar(Console.ReadLine());
} while (ans == 'Y');

Console.ReadLine();