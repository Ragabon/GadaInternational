using Gada.Domain;
using System;

namespace Gada.Interests.Entities
{
    public class InterestCategory : IEntity
    {
        public Guid Id { get; private set; }

        public string CategoryName { get; private set; }

        public static InterestCategory CreateInterestCategory(string categoryName)
        {
            return new InterestCategory { Id = Guid.NewGuid(), CategoryName = categoryName };
        }
    }
}