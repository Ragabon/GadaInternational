using Gada.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gada.Interests.Entities
{
    public class Interest : IEntity
    {
        public Guid Id { get; private set; }

        public InterestCategory Category { get; private set; }

        public string Title { get; private set; }


        public static Interest CreateInterest(string interest)
        {
            return new Interest { Id = Guid.NewGuid(), Title = interest};
        }

        public void SetCategory(InterestCategory category)
        {
            Category = category;
        }
    }
}
