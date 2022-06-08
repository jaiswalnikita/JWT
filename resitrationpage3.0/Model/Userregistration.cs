using System;
using System.Collections.Generic;
using System.Web;

namespace resitrationpage3._0.Model
{
    public class Userregistration
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public string Roles { get; set; }
        public string IsActive { get; set; }
    }
}
