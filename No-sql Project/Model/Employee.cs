﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Model
{
    public class Employee
    {
        [BsonId]
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
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Role Role { get; set; }

        [BsonElement("IsActive")]
        public bool IsActive { get; set; }

        public Employee(ObjectId Id, string UserName, string Name, string Email, string Password, Role Role, bool IsActive = true)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            this.Role = Role;
            this.IsActive = IsActive;
        }

    }

    public enum Role
    {
        regular=1, admin
    }

}
