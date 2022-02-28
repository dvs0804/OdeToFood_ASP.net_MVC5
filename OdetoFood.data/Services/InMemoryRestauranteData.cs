using OdetoFood.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdetoFood.data.Services
{
    public class InMemoryRestauranteData : IRestauranteData
    {
       List<Restaurante> restauranteList;
        public InMemoryRestauranteData()
        {
            restauranteList = new List<Restaurante>()
            {
                new Restaurante { Id = 1, Nombre = "Scott Pizza", Cocina = tipoCocina.italiana },
                new Restaurante { Id = 2, Nombre = "Tersiguels", Cocina = tipoCocina.francesa },
                new Restaurante { Id = 3, Nombre = "Mango Grove", Cocina = tipoCocina.india },
            };
        }

        public Restaurante Get(int id)
        {
            return restauranteList.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurante> GetAll()
        {
            return restauranteList.OrderBy(r => r.Nombre);
        }
        public void add(Restaurante restaurante)
        {
            restauranteList.Add(restaurante);
            restaurante.Id = restauranteList.Max(r => r.Id) + 1;
        }
        public void update(Restaurante restaurante)
        {
            var existing = Get(restaurante.Id); 
            if (existing != null)
            {
                existing.Nombre = restaurante.Nombre;
                existing.Cocina = restaurante.Cocina;
            }
        }

        public void delete(int id)
        {
            var restaurante = Get(id);
            if (restaurante != null)
            {
                restauranteList.Remove(restaurante);
            }

            
        }
    }
}
