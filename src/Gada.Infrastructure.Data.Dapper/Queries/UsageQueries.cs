using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gada.Infrastructure.Data.Dapper.Queries
{
    public class UsageQueries
    {
        #region Log

        public const string FindByUserIdAndTypeId = @"
            SELECT *
            FROM [Logs]
            WHERE [UserId] = @UserId AND [LogType_Id] = @TypeId";

        #endregion

        #region LogType

        public const string GetAllLogTypes = @"
            SELECT *
            FROM [LogTypes]";

        public const string GetLogTypeByName = @"
            SELECT *
            FROM [LogTypes]
            WHERE [Type] = @Type";

        #endregion
    }
}
