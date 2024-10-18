using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary
{
    public class CourierUserServiceImpl : ICourierUserService
    {
        protected CourierCompany companyObj;

        public CourierUserServiceImpl(CourierCompany company)
        {
            this.companyObj = company;
        }

        // Static variable for unique tracking number
        private static int trackingNumberCounter = 1000; // Starting value for tracking numbers


        public string PlaceOrder(Courier courierObj)
        {
            CourierServiceDB db = new CourierServiceDB();

            // Generate a unique tracking number
            string trackingNumber = GenerateTrackingNumber();

            // Set the tracking number in the courier object
            courierObj.TrackingNumber = trackingNumber;

            // Set the initial status of the order
            courierObj.Status = "Yet to Transit";

            // Insert the courier order into the database
            bool isInserted = db.InsertCourierData(courierObj);

            // Return the tracking number if insertion is successful
            if (isInserted)
            {
                return trackingNumber;
            }
            else
            {
                throw new Exception("Failed to place the order.");
            }
        }

        private string GenerateTrackingNumber()
        {
            trackingNumberCounter++; // Increment the counter
            return "TRK" + trackingNumberCounter.ToString(); // Create a tracking number string
        }

        public string GetOrderStatus(string trackingNumber)
            {
                CourierServiceDB db = new CourierServiceDB();

                string status = db.GetOrderStatus(trackingNumber);

                return status;
            }

        public bool CancelOrder(string trackingNumber)
        {
            CourierServiceDB db = new CourierServiceDB();
            bool isCancelled;
            isCancelled = db.CancelOrder(trackingNumber);
            return isCancelled;
        }

        public List<Courier> GetAssignedOrders(int courierStaffId)
        {
            CourierServiceDB db = new CourierServiceDB();
            List<Courier> assignedOrders = new List<Courier>();
            assignedOrders = db.GetAssignedOrders(courierStaffId);
            return assignedOrders;
        }
    }
}
