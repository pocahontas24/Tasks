using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Data
{

    public static class DbInitializer
    {
        public static void Initialize(UserTaskContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{FirstName="Rade",LastName="Laketic",BankNumber=1234567891234567,Email = "RadeL@yahoo.com",PhoneNumber = "0038765748578",Birthday=DateTime.Parse("2001-08-02"), Address = "Ravnogorska 19"},
            new User{FirstName="Gorica",LastName="Mijatovic",BankNumber=1234567891234567,Email = "goricam@yahoo.com",PhoneNumber = "00387654547384",Birthday=DateTime.Parse("2002-09-11"), Address = "Ravnogorska 17"},
            new User{FirstName="Nemanja",LastName="Jakovljevic",BankNumber=1234567891234567,Email = "jnemanja@yahoo.com",PhoneNumber = "0038765998776",Birthday=DateTime.Parse("2000-12-01"), Address = "Ravnogorska 12" }

            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var tasks = new Models.Task[]
            {
            new Models.Task{ Title="FinishTask", Description="Please finish task to the end", Status="New"},
            new Models.Task{ Title="Begin", Description="Please let us know when you begin task", Status = "New"},
            new Models.Task{ Title="Finish homework", Description="Please finish homework", Status = "New"},
            new Models.Task{ Title="Open new ticket", Description="Please open new ticket", Status = "New"}

            };
            foreach (Models.Task t in tasks)
            {
                context.Tasks.Add(t);
            }
            context.SaveChanges();

        }
    }
}
