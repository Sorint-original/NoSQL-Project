using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;


namespace DAL
{
    public class BaseDAO
    {
        private MongoClient client;
      
        public BaseDAO()
        {
            client = new MongoClient(ConfigurationManager.ConnectionStrings["mongoconnectionstring"].ConnectionString);

        }

    }
}
