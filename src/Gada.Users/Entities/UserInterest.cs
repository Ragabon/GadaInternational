using System;
using Gada.Accounts.Entities;

namespace Gada.Users.Entities
{
    public class UserInterest
    {
        public User User { get; private set; }
        public Guid User_Id { get; private set; }
        public Guid Interest_Id { get; private set; }

        public static UserInterest Create(User user, Guid interestId)
        {
            return new UserInterest()
            {
                User = user,
                User_Id = user.Id,
                Interest_Id = interestId
            };
        }
    }
}
