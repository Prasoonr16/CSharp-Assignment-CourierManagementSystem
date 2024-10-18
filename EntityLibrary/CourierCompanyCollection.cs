using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class CourierCompanyCollection
    {
        public List<CourierCompany> couriercompanies { get; set; }
        public CourierCompanyCollection(CourierCompany company)
        {
            this.couriercompanies.Add(company); // Add the provided company
        }

        
    }
}
