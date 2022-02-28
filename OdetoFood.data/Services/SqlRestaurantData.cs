using OdetoFood.data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdetoFood.data.Services
{
    public class SqlRestaurantData : IRestauranteData
    {
        private readonly OdeToFoodDBContext db;

        public SqlRestaurantData(OdeToFoodDBContext db)
        {
            this.db = db;
        }
        public void add(Restaurante restaurante)
        {
            db.Restaurantes.Add(restaurante);
            db.SaveChanges();
        }

        public void delete(int id)
        {
            var restaurante =db.Restaurantes.Find(id);
            db.Restaurantes.Remove(restaurante);
            db.SaveChanges();
        }

        public Restaurante Get(int id)
        {
            return db.Restaurantes.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurante> GetAll()
        {
            return from r in db.Restaurantes
                   orderby r.Nombre 
                   select r;
        }

        public void update(Restaurante restaurante)
        {
            var entry = db.Entry(restaurante);
            entry.State =EntityState.Modified;
            db.SaveChanges();
        }
    }
}
