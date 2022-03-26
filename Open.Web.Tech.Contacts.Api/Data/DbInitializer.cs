using Open.Web.Tech.Contacts.Api.Data.Models;
using System;
using System.Linq;

namespace Open.Web.Tech.Contacts.Api.Data
{
    /// <summary>
    /// DbInitializer
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(ApiContext context)
        {
            context.Database.EnsureCreated();

            // Look for any 
            if (context.Contacts.Any())
            {
                return;   // DB has been seeded
            }

            var contacts = new Contact[]
            {
            new Contact{Uid = Guid.NewGuid(), FirstName="Carson",LastName="Alexander",FullName ="Carson Alexander", Address ="21 avenue test",Email ="c.email@mail.com", Mobile="+57575757"},
            new Contact{Uid = Guid.NewGuid(),FirstName="Meredith",LastName="Alonso",FullName ="Alonso Meredith",Address ="22 rue Yan test",Email ="y.email@mail.com", Mobile="+7575757575"},
            new Contact{Uid = Guid.NewGuid(),FirstName="Arturo",LastName="Anand",FullName ="Anand Arturo",Address ="21 avenue Arturo",Email ="a.email@mail.com", Mobile="+7575575"},
            new Contact{Uid = Guid.NewGuid(),FirstName="Gytis",LastName="Barzdukas",FullName ="Gytis Barzdukas",Address ="21 avenue test",Email ="c.email@mail.com", Mobile="+755"},
            new Contact{Uid = Guid.NewGuid(),FirstName="Yan",LastName="Li",FullName ="Yan Li",Address ="21 avenue Laura",Email ="L.email@mail.com", Mobile="+75757557"},
            new Contact{Uid = Guid.NewGuid(),FirstName="Peggy",LastName="Justice",FullName ="Peggy Justice",Address ="21 avenue test",Email ="j.email@mail.com", Mobile="+75575"},
            new Contact{Uid = Guid.NewGuid(),FirstName="Laura",LastName="Norman",FullName ="Laura Norman",Address ="21 avenue Olivetto",Email ="n.email@mail.com", Mobile="+75557575"},
            new Contact{Uid = Guid.Parse("634442f3-c523-4a37-9235-d281a9e7ffeb"),FirstName="Nino",LastName="Olivetto",FullName ="Nino Olivetto",Address ="21 avenue Olivetto",Email ="o.email@mail.com", Mobile="+698674245"}
            };
            foreach (Contact c in contacts)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();

            var skills = new Skill[]
            {
            new Skill{SkillID=1050,Uid = Guid.NewGuid(),Name="Chemistry",Code="CH"},
            new Skill{SkillID=4022,Uid = Guid.NewGuid(),Name="Microeconomics",Code="MI"},
            new Skill{SkillID=4041,Uid = Guid.NewGuid(),Name="Macroeconomics",Code="MA"},
            new Skill{SkillID=1045,Uid = Guid.NewGuid(),Name="Calculus",Code="CA"},
            new Skill{SkillID=3141,Uid = Guid.NewGuid(),Name="Trigonometry",Code="TR"},
            new Skill{SkillID=2021,Uid = Guid.NewGuid(),Name="Composition",Code="CO"},
            new Skill{SkillID=2042,Uid = Guid.NewGuid(),Name="Literature",Code="LI"}
            };
            foreach (Skill s in skills)
            {
                context.Skills.Add(s);
            }
            context.SaveChanges();

            var contactSkills = new ContactSkill[]
            {
            new ContactSkill{ContactID=1,SkillID=1050,Level=Level.A},
            new ContactSkill{ContactID=1,SkillID=4022,Level=Level.C},
            new ContactSkill{ContactID=1,SkillID=4041,Level=Level.B},
            new ContactSkill{ContactID=2,SkillID=1045,Level=Level.B},
            new ContactSkill{ContactID=2,SkillID=3141,Level=Level.F},
            new ContactSkill{ContactID=2,SkillID=2021,Level=Level.F},
            new ContactSkill{ContactID=3,SkillID=1050,Level=Level.F},
            new ContactSkill{ContactID=4,SkillID=1050,Level=Level.B},
            new ContactSkill{ContactID=4,SkillID=4022,Level=Level.F},
            new ContactSkill{ContactID=5,SkillID=4041,Level=Level.C},
            new ContactSkill{ContactID=6,SkillID=1045,Level=Level.A},
            new ContactSkill{ContactID=7,SkillID=3141,Level=Level.A},
            };
            foreach (ContactSkill cs in contactSkills)
            {
                context.ContactSkills.Add(cs);
            }
            context.SaveChanges();

            var users = new User[]
            {
                new User{ContactUid = Guid.NewGuid(), UserName ="apiadmin",Password = "Passw0rd", EmailAddress = "api.admin@mail.com",  Role = "Administrator" },
                new User{ContactUid= Guid.NewGuid(), UserName ="apiuser1",  Password = "Passw0rd1", EmailAddress = "api.user1@mail.com", Role = "SimpleUser" },
                new User{ContactUid = Guid.Parse("634442f3-c523-4a37-9235-d281a9e7ffeb"),UserName ="Nino", Password = "Passw0rd2",  EmailAddress = "o.email@mail.com",  Role = "SimpleUser" }
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

        }
    }
}
