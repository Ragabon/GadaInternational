using System;
using System.Collections.Generic;
using Gada.Domain;

namespace Gada.Usage.Entities
{
    public class Log : IEntity
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public LogType LogType { get; private set; } 
        public DateTime LoggedOn { get; private set; }
        public string LogData { get; private set; }

        public static Log Create(Guid userId, LogType logType, string logData)
        {
            return new Log()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                LogType = logType,
                LoggedOn = DateTime.Now,
                LogData = logData
            };
        }
    }
}
