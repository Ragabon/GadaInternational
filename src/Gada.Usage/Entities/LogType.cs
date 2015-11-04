using System;
using Gada.Domain;

namespace Gada.Usage.Entities
{
    public class LogType : IEntity
    {
        public Guid Id { get; private set; }
        public string Type { get; private set; }


        public static LogType Create(string type)
        {
            return new LogType()
            {
                Id = Guid.NewGuid(),
                Type = type
            };
        }
    }
}
