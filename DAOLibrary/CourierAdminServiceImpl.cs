using EntityLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary
{
    public class CourierAdminServiceImpl : CourierUserServiceImpl, ICourierAdminService
    {
        public CourierAdminServiceImpl(CourierCompany company) : base(company)
        {
        }

        public int addCourierStaff(string name, string contactNumber)
        {
            CourierServiceDB db = new CourierServiceDB();
            int staffID = db.addCourierStaff(name, contactNumber);
            return staffID;
        }

    }
}
