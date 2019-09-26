using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext() : base("name=WebAPIContext")
        {
        }

        public DbSet<HotDog> HotDogs { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
