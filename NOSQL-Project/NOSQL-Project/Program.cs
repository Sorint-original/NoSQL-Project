using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace NOSQL_Project
{
    // THIS SHOULD NORMALLY BE IN A SEPARATE FILE!!!
    internal class Program
    {
        // Define the User class for the MongoDB documents
        internal class User
        {
            [BsonId]
            public ObjectId Id { get; set; }

            [BsonElement("FirstName")]
            public string FirstName { get; set; }

            [BsonElement("LastName")]
            public string LastName { get; set; }

            public User(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
        }

        static async Task Main(string[] args)
        {
            try
            {
                // Retrieve MongoDB connection string from appSettings
                string connectionString = ConfigurationManager.AppSettings["mongoconnectionstring"];

                // Connect to MongoDB
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("nosql-demo");
                var userCollection = database.GetCollection<User>("users");

                // CREATE (Insert a new user)
                User testUser = new User("joe", "smith10");
                await userCollection.InsertOneAsync(testUser);
                Console.WriteLine($"Inserted User: {testUser.FirstName} {testUser.LastName}");

                // READ (Find users with the first name "joe")
                var filter = Builders<User>.Filter.Eq(u => u.FirstName, "joe");
                var usersWithNameJoe = await userCollection.Find(filter).ToListAsync();

                Console.WriteLine("\nUsers with FirstName 'joe':");
                foreach (var user in usersWithNameJoe)
                {
                    Console.WriteLine($"User: {user.FirstName} {user.LastName}, ID: {user.Id}");
                }

                // UPDATE (Update the last name of a user with the first name "joe")
                var update = Builders<User>.Update.Set(u => u.LastName, "johnson");
                var updateResult = await userCollection.UpdateOneAsync(filter, update);

                Console.WriteLine($"\nUpdate Result: Matched {updateResult.MatchedCount}, Modified {updateResult.ModifiedCount}");

                // READ (Verify update)
                var updatedUsers = await userCollection.Find(filter).ToListAsync();
                Console.WriteLine("\nUpdated Users:");
                foreach (var user in updatedUsers)
                {
                    Console.WriteLine($"User: {user.FirstName} {user.LastName}, ID: {user.Id}");
                }

                // DELETE (Delete a single user with the first name "joe")
                var deleteResult = await userCollection.DeleteOneAsync(filter);

                Console.WriteLine($"\nDeleted 1 user with FirstName 'joe'");

                // Final verification (Check remaining users)
                var remainingUsers = await userCollection.Find(new BsonDocument()).ToListAsync();
                Console.WriteLine("\nRemaining Users:");
                foreach (var user in remainingUsers)
                {
                    Console.WriteLine($"User: {user.FirstName} {user.LastName}, ID: {user.Id}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}\n{e.StackTrace}");
            }
        }
    }
}