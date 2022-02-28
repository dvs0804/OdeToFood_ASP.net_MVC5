using OdetoFood.data.Models;
using OdetoFood.data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace OdetoFood.web.API
{
    public class RestaurantesController : ApiController
    {
        private readonly IRestauranteData db;

        public RestaurantesController(IRestauranteData db)
        {
            this.db = db;
        }
        public IEnumerable<Restaurante> get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
