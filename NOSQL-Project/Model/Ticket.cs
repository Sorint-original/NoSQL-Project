using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Ticket
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("Employee_id")]
        public ObjectId EmployeeId { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Status")]
        [BsonRepresentation(BsonType.String)]
        public Status Status { get; set; }

        [BsonElement("Creation_Time")]
        public DateTime CreationTime { get; set; }

        [BsonElement("Solution_Time")]
        public DateTime SolutionTime { get; set; }

        public Ticket(ObjectId id, ObjectId Employeeid, string Title, string Description, Status Status, DateTime CreationTime, DateTime SolutionTime)
        {
            this.Id = id;
            this.EmployeeId = Employeeid;
            this.Title = Title;
            this.Description = Description;
            this.Status = Status;
            this.CreationTime = CreationTime;
            this.SolutionTime = SolutionTime;
        }
    }
}


enum Status
{
    open,pending,closed
}