using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gada.Infrastructure.Data.Dapper.Queries
{
    public class PostQueries
    {
        #region GET

        public const string Get = @"
            SELECT 
				*
            FROM 
				[Posts]
            WHERE
				[Id] = @Id";

        public const string GetLatest = @"
            SELECT TOP 10
				p.[Content]
				,p.[PostedOn]
                ,p.[PostedBy_Id]
				,u.[Username]
                ,p.[Discussion_Id]
                ,d.[Id]
                ,d.[Title]
            FROM 
				[Posts] p
			INNER JOIN
				[Users] u
            		ON
				p.[PostedBy_Id] = u.[Id]
            INNER JOIN
                [Discussions] d
                    ON
                p.[Discussion_Id] = d.[Id]
            ORDER BY
				p.[PostedOn] DESC";

        #endregion
    }
}
