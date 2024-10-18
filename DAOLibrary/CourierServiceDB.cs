using EntityLibrary;
using Microsoft.Data.SqlClient;
using ExceptionLibrary;
using Microsoft.IdentityModel.Tokens;
using System.Xml;
using UtilLibrary;
using System.ComponentModel.DataAnnotations;

namespace DAOLibrary
{
    public interface ICourierService
    {
        public bool InsertCourierData(Courier courier);
        public bool UpdateCourier(int c_id, Courier courier);

        public bool DeleteCourier(int c_id);

        public Courier FindCourier(int c_id);

        public List<Courier> ShowAllCouriers();

        public string GetOrderStatus(string trackingNumber);

        public bool CancelOrder(string trackingNumber);

    }

    public interface IAdminService
    {
        public int addCourierStaff(string name, string contactNumber);
    } 

    public class CourierServiceDB : ICourierService, IAdminService
    {
        public bool DeleteCourier(int c_id)
        {
            bool status = false;
            status = DeleteCourierRecord(c_id, status);
            return status;
        }

        private static bool DeleteCourierRecord(int c_id, bool status)
        {
            SqlConnection cn = DBConnection.GetConnectionString();
            try
            {
                SqlCommand cmd = new SqlCommand("delete from Couriers where CourierID = " + c_id, cn);
                cn.Open();
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    status = true;
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }

        public Courier FindCourier(int c_id)
        {
            try
            {
                return SearchCourierByID(c_id);
            }
            catch (CourierNotFoundException ex)
            {
                throw new CourierNotFoundException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred while serching for the courier.",ex);
            }

        }
        private static Courier SearchCourierByID(int c_id)
        {
            SqlConnection cn = DBConnection.GetConnectionString();
            SqlCommand cmd = new SqlCommand("select * from Couriers where CourierID=" + c_id, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Courier c_found = new Courier();
            if (dr.HasRows)
            {
                dr.Read();//readonly forward only
                c_found.CourierID = Convert.ToInt32(dr["CourierID"]);
                c_found.SenderName = dr["SenderName"].ToString();
                c_found.SenderAddress = dr["SenderAddress"].ToString();
                c_found.ReceiverName = dr["ReceiverName"].ToString();
                c_found.ReceiverAddress = dr["ReceiverAddress"].ToString();
                c_found.Weight = Convert.ToDouble(dr["Weight"]);
                c_found.Status = dr["Status"].ToString();
                c_found.TrackingNumber = dr["TrackingNumber"].ToString();
                c_found.DeliveryDate = Convert.ToDateTime(dr["DeliveryDate"]);
                c_found.UserID = Convert.ToInt32(dr["UserID"]);

            }
            else
            {
                throw new CourierNotFoundException("Such a CourierID doesnot exists......");
            }
            cn.Close();
            cn.Dispose();
            return c_found;
        }

        public List<Courier> ShowAllCouriers()
        {
            SqlConnection cn = DBConnection.GetConnectionString();
            List<Courier> courierList = new List<Courier>();

            try
            {
                SqlCommand cmd = new SqlCommand("select * from Couriers", cn);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    Courier courier = new Courier();
                    courier.CourierID = Convert.ToInt32(dr["CourierID"]);
                    courier.SenderName = dr["SenderName"].ToString();
                    courier.SenderAddress = dr["SenderAddress"].ToString();
                    courier.ReceiverName = dr["ReceiverName"].ToString();
                    courier.ReceiverAddress = dr["ReceiverAddress"].ToString();
                    courier.Weight = Convert.ToDouble(dr["Weight"]);
                    courier.Status = dr["Status"].ToString();
                    courier.TrackingNumber = dr["TrackingNumber"].ToString();
                    courier.DeliveryDate = Convert.ToDateTime(dr["DeliveryDate"]);
                    courier.UserID = Convert.ToInt32(dr["UserID"]);

                    courierList.Add(courier);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while fetching all courier.", ex);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return courierList;
        }

        public bool InsertCourierData(Courier courier)
        {
            bool status = false;
            return InsertCourierRecord(courier, status);
        }

        private static bool InsertCourierRecord(Courier courier, bool status)
        {
            SqlConnection cn = DBConnection.GetConnectionString();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Couriers values(@CourierID,@SenderName,@SenderAddress,@ReceiverName,@ReceiverAddress,@Weight,@Status,@TrackingNumber,@DeliveryDate,@UserID)", cn);
                cmd.Parameters.AddWithValue("@CourierID", courier.CourierID);
                cmd.Parameters.AddWithValue("@SenderName", courier.SenderName); ;
                cmd.Parameters.AddWithValue("@SenderAddress", courier.SenderAddress);
                cmd.Parameters.AddWithValue("@ReceiverName", courier.ReceiverName);
                cmd.Parameters.AddWithValue("@ReceiverAddress", courier.ReceiverAddress);
                cmd.Parameters.AddWithValue("@Weight", courier.Weight);
                cmd.Parameters.AddWithValue("@Status", courier.Status);
                cmd.Parameters.AddWithValue("@TrackingNumber", courier.TrackingNumber);
                cmd.Parameters.AddWithValue("@DeliveryDate", courier.DeliveryDate);
                cmd.Parameters.AddWithValue("@UserID", courier.UserID);


                cn.Open();
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while inserting the courier data.", ex);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

            return status;
        }

        public bool UpdateCourier(int c_id, Courier courier)
        {
            bool status = false;
            SqlConnection cn = DBConnection.GetConnectionString();

            try
            {
                SqlCommand cmd = new SqlCommand("update Couriers set SenderName = @senderName, SenderAddress = @senderAddress, ReceiverName = @receiverName, ReceiverAddress = @receiverAddress, Weight = @weight, Status = @status, TrackingNumber = @trackingNumber, DeliveryDate = @deliveryDate, UserID = @userID where CourierID =  " + c_id, cn);

                cn.Open();

                cmd.Parameters.AddWithValue("@senderName", courier.SenderName);
                cmd.Parameters.AddWithValue("@senderAddress", courier.SenderAddress);
                cmd.Parameters.AddWithValue("@receiverName", courier.ReceiverName);
                cmd.Parameters.AddWithValue("@receiverAddress", courier.ReceiverAddress);
                cmd.Parameters.AddWithValue("@weight", courier.Weight);
                cmd.Parameters.AddWithValue("@status", courier.Status);
                cmd.Parameters.AddWithValue("@trackingNumber", courier.TrackingNumber);
                cmd.Parameters.AddWithValue("@deliveryDate", courier.DeliveryDate);
                cmd.Parameters.AddWithValue("@userID", courier.UserID);

                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the courier.", ex);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return status;

        }

        public string GetOrderStatus(string trackingNumber)
        {
            string status = null;

            SqlConnection cn = DBConnection.GetConnectionString();

            try
            {
                // SQL query to get the status based on the tracking number
                SqlCommand cmd = new SqlCommand("SELECT Status FROM Couriers WHERE TrackingNumber = @TrackingNumber", cn);
                cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                cn.Open();
                object result = cmd.ExecuteScalar(); // Execute the query and get the first column of the first row

                if (result != null)
                {
                    status = result.ToString(); // Convert the result to string if not null
                }
                else
                {
                    throw new TrackingNumberNotFoundException($"Tracking number '{trackingNumber}' not found.");
                }
            }
            catch (TrackingNumberNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return status;

        }

        public bool CancelOrder(string trackingNumber)
        {
            bool isCancelled = false;
            SqlConnection cn = DBConnection.GetConnectionString();

            try
            {
                
                SqlCommand cmd = new SqlCommand("update Couriers set Status =  'Cancelled' WHERE TrackingNumber = @TrackingNumber", cn);
                cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                cn.Open();
                int cnt = cmd.ExecuteNonQuery();

                if (cnt > 0)
                {
                    isCancelled = true;
                }
                else
                {
                    throw new TrackingNumberNotFoundException($"Tracking number '{trackingNumber}' not found.");
                }
            }
            catch (TrackingNumberNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            return isCancelled;
        }

        public List<Courier> GetAssignedOrders(int courierStaffId)
        {
            List<Courier> assignedOrders = new List<Courier>(); // List to hold assigned orders

            SqlConnection cn = DBConnection.GetConnectionString();
            try
            {
                // SQL query to retrieve couriers assigned to the specific courier staff ID
                SqlCommand cmd = new SqlCommand("SELECT * FROM Courier WHERE UserID = @CourierStaffId", cn);
                cmd.Parameters.AddWithValue("@CourierStaffId", courierStaffId);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Courier courier = new Courier();
                    courier.CourierID = Convert.ToInt32(dr["CourierID"]);
                    courier.SenderName = dr["SenderName"].ToString();
                    courier.SenderAddress = dr["SenderAddress"].ToString();
                    courier.ReceiverName = dr["ReceiverName"].ToString();
                    courier.ReceiverAddress = dr["ReceiverAddress"].ToString();
                    courier.Weight = Convert.ToDouble(dr["Weight"]);
                    courier.Status = dr["Status"].ToString();
                    courier.TrackingNumber = dr["TrackingNumber"].ToString();
                    courier.DeliveryDate = Convert.ToDateTime(dr["DeliveryDate"]);
                    courier.UserID = Convert.ToInt32(dr["UserID"]);

                    // Add the populated courier object to the list
                    assignedOrders.Add(courier);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return assignedOrders; 
        }

        public int addCourierStaff(string name, string contactNumber)
        {
            int newEmployeeId = 0; // To hold the newly generated EmployeeID
            SqlConnection cn = DBConnection.GetConnectionString();           try
            {
                string query = "INSERT INTO Employee (Name, Email, ContactNumber, Role, Salary) " +
                               "OUTPUT INSERTED.EmployeeID " +  // Retrieve the newly inserted EmployeeID
                               "VALUES (@Name, @Email, @ContactNumber, @Role, @Salary)";

                // Assuming default values for email, role, and salary (these could also be provided as parameters)
                string email = name.ToLower().Replace(" ", ".") + "@gmail.com"; // Generate dummy email
                string role = "CourierStaff";  // Default role
                decimal salary = 30000;        // Default salary

                SqlCommand cmd = new SqlCommand(query, cn);

                // Add parameters to the query
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@Salary", salary);

                cn.Open();

                // Execute the query and get the generated EmployeeID
                newEmployeeId = (int)cmd.ExecuteScalar(); // Returns the EmployeeID from the OUTPUT clause
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            finally
            {
                cn.Close(); 
                cn.Dispose();
            }

            return newEmployeeId; // Return the generated EmployeeID
        }
    }
}

   
