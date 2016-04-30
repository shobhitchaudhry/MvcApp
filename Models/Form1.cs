using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MvcApplicationTest.Models
{
    public class Form1
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        public string City { get; set; }

        [Display(Name = "Postal Code")]
        public string Postal { get; set; }

        [StringLength(1000, ErrorMessage = "Name cannot be longer than 1000 characters.")]
        [Display(Name = "Cover Letter")]
        public string CoverLetter { get; set; }
        public string Resume { get; set; }
    }

    public class Form1DBContext : DbContext
    {
        public DbSet<Form1> Forms { get; set; }
    }
}