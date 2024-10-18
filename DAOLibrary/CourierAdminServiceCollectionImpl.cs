using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary
{
    public class CourierAdminServiceCollectionImpl : CourierUserServiceCollectionImpl, ICourierAdminService
    {
        public int addCourierStaff(string name, string contactNumber)
        {
            CourierServiceDB db = new CourierServiceDB();
            int staffID = db.addCourierStaff(name, contactNumber);
            return staffID;
        }
    }
}
