using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invidux_Data.Dtos.Response
{
    public class BvnResponse
    {
        public string Event { get; set; }
        public BvnData Data { get; set; }
    }

    public class BvnData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Bvn { get; set; }
    }

}
