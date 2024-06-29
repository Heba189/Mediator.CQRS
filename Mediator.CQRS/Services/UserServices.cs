using Mediator.CQRS.Interfaces;
using Mediator.CQRS.Models;

namespace Mediator.CQRS.Services
{
    public class UserServices : IUserServices
    {
        private static List<UserModel> _users = new List<UserModel>()
        {
            new UserModel()
            {
                Id = 1,
                FirstName = "Test1",
                LastName = "test1"
            },
              new UserModel()
            {
                Id = 2,
                FirstName = "Test2",
                LastName = "test2"
            },
                new UserModel()
            {
                Id = 3,
                FirstName = "Test3",
                LastName = "test3"
            }
        };
        public UserModel AddUser(UserModel user)
        {
           _users.Add(user);
            return user;
        } 

        public UserModel GetUserByIndex(int index)
        {
            return _users[index];
        }

        public List<UserModel> GetUsers()
        {
            return _users;
        }
    }
}
