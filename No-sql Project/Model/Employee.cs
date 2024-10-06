using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class Employee
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("UserName")]
        public string UserName { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Role")]
        [BsonRepresentation(BsonType.String)]
        public Role Role { get; set; }

        public Employee(ObjectId Id, string UserName, string Name, string Email, string Password, Role Role)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.Role = Role;
        }

    }

    enum Role
    {
        regular, admin
    }
}
