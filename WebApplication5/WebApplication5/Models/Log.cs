
using System;
using System.Collections.Generic;
using WebApplication5.Repository.IRepository;

namespace WebApplication5.Models
{
    public partial class Log : IEntity
    {
        public int ID { get; set; }
        public int? UserId { get; set; }
        public string ActionType { get; set; }
        public string ActionDetails { get; set; }
        public DateTime Created { get; set; }

        public virtual User User { get; set; }
    }
}
