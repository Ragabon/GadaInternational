using System;
using Gada.Domain;

namespace Gada.Discussions.Entities
{
    public class Area : IEntity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }

        public static Area Create(string title, string description, string icon)
        {
            return new Area
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                Icon = icon
            };
        }
    }
}
