using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;


namespace DAL
{
    public class BaseDAO
    {
        private MongoClient client;
        protected IMongoDatabase database;

        public BaseDAO()
        {
            //client = new MongoClient(ConfigurationManager.ConnectionStrings["mongoconnectionstring"].ConnectionString);
             string connectionString = ConfigurationManager.AppSettings["mongoconnectionstring"];
            IMongoClient mongoClient = new MongoClient(connectionString);
            database = mongoClient.GetDatabase("ManagementSystem");
        }

        //method to allow the ticket and employee classes  to access collection
        protected IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return database.GetCollection<T>(collectionName);
        }

    }
}
