using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gada.Infrastructure.Data.Dapper.Queries
{
    public class AreaQueries
    {
        #region GET

        public const string GetAll = @"
            SELECT
                *
            FROM 
				[Areas]";

        public const string GetById = @"
            SELECT
                *
            FROM 
				[Areas]
            WHERE
                [Id] = @Id
            ";

        #endregion
    }
}
