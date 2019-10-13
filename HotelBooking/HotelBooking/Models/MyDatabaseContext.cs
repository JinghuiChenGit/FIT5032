using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HotelBooking.Models
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext() : base("name=MyDbConnection")
        { }
        public System.Data.Entity.DbSet<HotelBooking.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<HotelBooking.Models.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<HotelBooking.Models.role> roles { get; set; }
        public System.Data.Entity.DbSet<HotelBooking.Models.Image> images { get; set; }
    }

        
    
}
