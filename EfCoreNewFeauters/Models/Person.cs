using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_2._0___New_Features.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FisrtName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        private string _Email;
        public Address CurrentAddress { get; set; }
        public Address PermanentAddress { get; set; }

        public void SetEmail(string email)
        {
            _Email = email;
        }

        public string GetEmail()
        {
            return _Email;
        }

        private string _ContactNo;

        public void SetContactNo(string contact)
        {
            _ContactNo = contact;
        }

        public string GetContact()
        {
            return _ContactNo;
        }
    }
    public class Address
    {
        public string HouseNo { get; set; }
        public string Society { get; set; }
        public string Details { get; set; }
        public Region Region { get; set; }
    }

    public class Region
    {
        public int RegionId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }
    }

    public class Country
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
