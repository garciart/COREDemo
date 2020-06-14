using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace COREDemo.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the COREDemoUser class
    public class COREDemoUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }

        [PersonalData]
        public string StreetAddress { get; set; }

        [PersonalData]
        public string City { get; set; }

        [PersonalData]
        public string State { get; set; }

        [PersonalData]
        public string ZipCode { get; set; }

        [PersonalData]
        public string SSN { get; set; }

        [PersonalData]
        public string InsCompany { get; set; }

        [PersonalData]
        public string InsPolicyNo { get; set; }

        [PersonalData]
        public string Doctor { get; set; }

        [PersonalData]
        [DataType(DataType.PhoneNumber)]
        public string DoctorPhone { get; set; }

        [PersonalData]
        public string AdditionalInfo { get; set; }
    }
}
