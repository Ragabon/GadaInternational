using Gada.Domain;
using System;

namespace Gada.Skills.Entities
{
    public class SkillCategory : IEntity
    {
        public Guid Id { get; private set; }

        public string CategoryName { get; private set; }

        public static SkillCategory CreateSkillCategory(string categoryName)
        {
            return new SkillCategory { Id = Guid.NewGuid(), CategoryName = categoryName };
        }
    }
}