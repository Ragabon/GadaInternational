using Gada.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gada.Accounts.Entities
{
    public class Skill : IEntity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }

        public static Skill CreateSkill(string skill, string category)
        {
            return new Skill() { Id = Guid.NewGuid(), Title = skill };
        }
    }
}
