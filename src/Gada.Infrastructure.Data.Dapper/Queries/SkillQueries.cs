namespace Gada.Infrastructure.Data.Dapper.Queries
{
    public class SkillQueries
    {
        #region Skills

        public const string Get = @"
            SELECT
                *
            FROM
                [Skills]
            WHERE
                Id = @Id";

        public const string GetAll = @"
            SELECT
                *
            FROM
				[Skills]";

        //        public const string Find = @"
        //            SELECT s.Id, s.Title
        //            FROM User_Skills us
        //            WHERE s.Title like '%' + @searchText + '%'";

        public const string FindByTitle = @"
            SELECT *
            FROM [Skills]
            WHERE Title LIKE @Title + '%'";

        public const string GetByTitles = @"
            SELECT *
            FROM [Skills]
            WHERE Title IN @Titles";

        public const string GetUserSkills = @"
            SELECT s.Id, s.Title
            FROM User_Skills us
            JOIN Skills s ON us.SkillId = s.Id
            WHERE us.UserId = @UserId";

        #endregion Skills

        #region SkillCategories

        public const string GetCategory = @"
            SELECT
                *
            FROM
                [SkillCategories]
            WHERE
                Id = @Id";

        public const string GetAllCategories = @"
            SELECT
                *
            FROM
				[SkillCategories]";

        public const string FindCategory = @"
            SELECT *
            FROM [SkillCategories]
            WHERE CategoryName LIKE @CategoryName + '%'";

        #endregion SkillCategories
    }
}