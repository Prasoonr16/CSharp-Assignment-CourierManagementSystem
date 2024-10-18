using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary
{
    public interface ICourierUserService
    {

        string PlaceOrder(Courier courierObj);
        string GetOrderStatus(string trackingNumber);
        bool CancelOrder(string trackingNumber);
        List<Courier> GetAssignedOrders(int courierStaffId);
    }

    public interface ICourierAdminService
    {
        public int addCourierStaff(string name, string contactNumber);

    }
}

