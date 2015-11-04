using Gada.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gada.Skills.Entities
{
    public class Skill : IEntity
    {

        public Guid Id { get; private set; }

        public SkillCategory Category { get; private set; }

        public string Title { get; private set; }

        public static Skill CreateSkill(string skill)
        {
            return new Skill { Id = Guid.NewGuid(), Title = skill };
        }

        public void SetCategory(SkillCategory category)
        {
            Category = category;
        }
    }
}
