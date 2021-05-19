using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Security.Data;
using Telerik.Sitefinity.Security.Model;

namespace TheTrainingboss.SFADVDev.Providers
{
    public class CustomMembershipProvider : MembershipDataProvider
    {
        public override User GetUser(Guid id)
        {
            return this.GetUsers().First(u => u.Id == id);
        }

        public override IQueryable<User> GetUsers()
        {
            ////////////////// Static user data /////////////////////////
            var user1 = new User()
            {
                Email = "first@user.com",
                Id = Guid.Parse("23811D98-7072-47DE-8D08-F30DD8E0C61F"),
                FirstName = "Lino",
                LastName = "Tadros",
                Password = "lino1234",

                ApplicationName = this.ApplicationName
            };
            user1.SetUserName("first@user.com");
            ((IDataItem)user1).Provider = this;

            var user2 = new User()
            {
                Email = "second@user.com",
                Id = Guid.Parse("5b46c6e0-4655-4b5f-9e05-fdf655d63ec2"),
                FirstName = "John",
                LastName = "Smith",
                Password = "john1234",
                ApplicationName = this.ApplicationName
            };
            user2.SetUserName("second@user.com");
            ((IDataItem)user2).Provider = this;
            /////////////// End of static user data ////////////////////////

            return new List<User>()
            {
                user1,
                user2
            }
            .AsQueryable();
        }

        public override User CreateUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override User CreateUser(Guid id, string userName)
        {
            throw new NotImplementedException();
        }

        public override void Delete(User item)
        {
            throw new NotImplementedException();
        }
    }
}