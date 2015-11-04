namespace Gada.Infrastructure.Data.Dapper.Queries
{
    public class InterestQueries
    {
        #region Interests

        public const string Get = @"
            SELECT
                *
            FROM
                [Interests]
            WHERE
                Id = @Id";

        public const string GetAll = @"
            SELECT
                *
            FROM
				[Interests]";

        public const string FindByTitle = @"
            SELECT *
            FROM [Interests]
            WHERE Title LIKE @Title + '%'";

        public const string GetByTitles = @"
            SELECT *
            FROM [Interests]
            WHERE Title IN @Titles";

        public const string GetUserInterests = @"
            SELECT i.Id, i.Title
            FROM UserInterests ui
            JOIN Interests i on ui.interestId = i.Id
            WHERE ui.UserId = @UserId";

        #endregion Interests

        #region InterestCategories

        public const string GetCategory = @"
            SELECT
                *
            FROM
                [InterestCategories]
            WHERE
                Id = @Id";

        public const string GetAllCategories = @"
            SELECT
                *
            FROM
				[InterestCategories]";

        public const string FindCategory = @"
            SELECT *
            FROM [InterestCategories]
            WHERE CategoryName LIKE @CategoryName + '%'";

        #endregion InterestCategories
    }
}