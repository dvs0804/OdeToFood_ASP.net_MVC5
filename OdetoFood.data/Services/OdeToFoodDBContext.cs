using OdetoFood.data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdetoFood.data.Services
{
    public class OdeToFoodDBContext : DbContext
    {
        public DbSet<Restaurante> Restaurantes { get; set; }
    }
}
