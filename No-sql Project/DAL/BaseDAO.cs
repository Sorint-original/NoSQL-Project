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
        protected IMongoDatabase database;

        public BaseDAO()
        {
            //client = new MongoClient(ConfigurationManager.ConnectionStrings["mongoconnectionstring"].ConnectionString);
            client = new MongoClient("mongodb+srv://Group4:123123123@cluster0.zgkxj.mongodb.net/");
            //connect to a specific database

            database = client.GetDatabase("ManagementSystem");
        }

        //method to allow the ticket and employee classes  to access collection
        protected IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return database.GetCollection<T>(collectionName);
        }


    }
}
