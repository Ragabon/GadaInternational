using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gada.Infrastructure.Data.Dapper.Queries
{
    public class UserQueries
    {
        #region GET

        public const string FindByUsername = @"
            SELECT *
            FROM [Users]
            WHERE [Username] = @Username";

        public const string FindById = @"
            SELECT *
            FROM [Users]
            WHERE [Id] = @Id";

        public const string FindByEmail = @"
            SELECT *
            FROM [Users]
            WHERE [Email] = @Email";

        public const string GetCountOfUsernames = @"
            SELECT count(id)
            FROM [Users]
            WHERE [Username] like @Username + '%'";

        public const string Get = @"
            SELECT *
            FROM [Users]
            WHERE Id = @Id";

        #endregion
    }
}
