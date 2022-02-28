using OdetoFood.data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdetoFood.data.Services
{
    public interface IRestauranteData
    {
        IEnumerable<Restaurante> GetAll();
        Restaurante Get(int id);
        void add(Restaurante restaurante);
        void update(Restaurante restaurante);
        void delete(int id);
    }
}
