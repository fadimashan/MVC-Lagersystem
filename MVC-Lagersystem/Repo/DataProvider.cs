using MVC_Lagersystem.Data;
using MVC_Lagersystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Lagersystem.Repo
{
    public class DataProvider
    {

        public readonly MVC_LagersystemContext _context;

       

        static public List<Product> GetAll(List<Product> productsList)
        {
            
            return productsList;
        }
    }
}
