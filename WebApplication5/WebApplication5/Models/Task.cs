using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Repository.IRepository;
using Xunit;
using Xunit.Sdk;

namespace WebApplication5.Models
{

 
    public class Task : IEntity
    {

        [Key]
        public int ID { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }

        public String Status { get; set; }

        public int UserID { get; set; }
        [JsonIgnore]

        public virtual User User { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
