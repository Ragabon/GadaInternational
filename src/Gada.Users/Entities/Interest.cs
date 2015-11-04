using System;
using Gada.Domain;

namespace Gada.Accounts.Entities
{
    public class Interest : IEntity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }

        public static Interest CreateInterest(string interest)
        {
            return new Interest() { Id = Guid.NewGuid(), Title = interest };
        }
    }
}
