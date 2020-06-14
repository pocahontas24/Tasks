
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication5.Repository.IRepository;

namespace WebApplication5.Models
{
    public class User : IEntity
    {
        public User(){
            Tasks = new HashSet<Task>();
            Logs = new HashSet<Log>();
        }

        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }
         
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public double BankNumber { get; set; }

        public String Email { get; set; }

        public String PhoneNumber { get; set; }

        public String Address { get; set; }
        [JsonIgnore]

        public virtual ICollection<Task> Tasks { get; set; }

        [JsonIgnore]

        public virtual ICollection<Log> Logs { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
