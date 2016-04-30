namespace MvcApplicationTest.Migrations
{
    using MvcApplicationTest.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    internal sealed class Configuration : DbMigrationsConfiguration<MvcApplicationTest.Models.Form1DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcApplicationTest.Models.Form1DBContext context)
        {
            context.Forms.AddOrUpdate(i => i.FirstName,
                    new Form1
                    {
                        FirstName = "Shobhit",
                        LastName = "Chaudhry",
                        Phone = "+1 226-606-4260",
                        Address1 = "Romantic Comedy",
                        Address2 = "add2",
                        City="Chd",
                        Postal="n2l3b8",
                        CoverLetter="c1",
                        Resume="r1"
                    }
               );
        }
    }
}
