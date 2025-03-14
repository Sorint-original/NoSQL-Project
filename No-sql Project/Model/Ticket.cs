﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Model
{
    public class Ticket
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("Employee_id")]
        public ObjectId EmployeeId { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Status")]
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Status Status { get; set; }

        [BsonElement("Priority")]
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Priority Priority { get; set; }

        [BsonElement("Creation_Date")]
        public DateTime CreationTime { get; set; }

        [BsonElement("Solution_Date")]
        public DateTime SolutionTime { get; set; }

        [BsonIgnoreIfNull]// this is used only in the database is null 100% in the database, and used only for crazy sorts that use enums
        [BsonElement("_order")]
        public int _order;
       

        public Ticket(ObjectId id, ObjectId Employeeid, string Title, string Description, Status Status, Priority Priority, DateTime CreationTime, DateTime SolutionTime)
        {
            this.Id = id;
            this.EmployeeId = Employeeid;
            this.Title = Title;
            this.Description = Description;
            this.Status = Status;
            this.Priority = Priority;
            this.CreationTime = CreationTime;
            this.SolutionTime = SolutionTime;
        }
    }
}


public enum Status
{
    open=1, pending, resolved, closed
}

public enum Priority
{
    low=1,normal,high
}