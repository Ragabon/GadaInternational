namespace Gada.Infrastructure.Data.Dapper.Queries
{
    public class DiscussionQueries
    {
        #region GET

        public const string FindById = @"
            SELECT 
				d.[Id]
				,d.[Title]
				,d.[Description]
				,d.[CreatedOn]
				,d.[Votes]
				,d.[Views]
				,d.[CreatedBy_Id]
				,u.[Username]
				,STUFF((SELECT ';' + c.[Title] 
                             FROM [Interests] c
                             INNER JOIN [DiscussionInterests] dc
							 ON c.[Id] = dc.[Interest_Id] AND dc.[Discussion_Id] = d.[Id]
                             FOR XML PATH('')), 
                            1, 1, '') AS Interests
				,p.[Discussion_Id]
                ,p.[Id] 
				,p.[Content]
				,p.[PostedOn]
				,p.[Votes]
				,p.[PostedBy_Id]
				,pu.[Username]
            FROM 
				[Discussions] d
			LEFT JOIN
				[Posts] p
			ON
				d.[Id] = p.[Discussion_Id]
            LEFT JOIN
				[Users] u
			ON
				d.[CreatedBy_Id] = u.[Id]
			LEFT JOIN
				[Users] pu
			ON
				p.[PostedBy_Id] = pu.[Id]
			WHERE 
				d.[Id] = @Id
					AND
				(p.[Show] IS NULL OR p.[Show] = 1)
            ORDER BY
                p.[PostedOn] DESC";

        public const string Get = @"
            SELECT 
				*
            FROM 
				[Discussions]
            WHERE
				[Id] = @Id";

        public const string GetAll = @"
            SELECT *
            FROM Discussions";

        public const string GetList = @"
            SELECT 
	            d.[Id]
	            ,d.[Title]
                ,d.[Description]
	            ,d.[Votes]
	            ,d.[Views]
                ,d.[PostCount]
	            ,d.[CreatedOn]
                ,d.[CreatedBy_Id]
                ,u.[Id]
                ,u.[Username]
				,STUFF((SELECT ';' + c.[Title] 
                             FROM [Interests] c
                             INNER JOIN [DiscussionInterests] dc
							 ON c.[Id] = dc.[Interest_Id] AND dc.[Discussion_Id] = d.[Id]
                             FOR XML PATH('')), 
                            1, 1, '') AS Interests
            FROM
	            [Discussions] d
            INNER JOIN
                [Users] u
            ON
                d.[CreatedBy_Id] = u.[Id]
			ORDER BY
				d.[CreatedOn] DESC";

        public const string GetListByArea = @"
            SELECT 
	            d.[Id]
	            ,d.[Title]
                ,d.[Description]
	            ,d.[Votes]
	            ,d.[Views]
                ,d.[PostCount]
	            ,d.[CreatedOn]
                ,d.[CreatedBy_Id]
                ,u.[Username]
				,STUFF((SELECT ';' + c.[Title] 
                             FROM [Interests] c
                             INNER JOIN [DiscussionInterests] dc
							 ON c.[Id] = dc.[Interest_Id] AND dc.[Discussion_Id] = d.[Id]
                             FOR XML PATH('')), 
                            1, 1, '') AS Interests
            FROM
	            [Discussions] d
            INNER JOIN
                [Users] u
                    ON
                d.[CreatedBy_Id] = u.[Id]
            WHERE
                d.[Area_Id] = @Area
			ORDER BY
				d.[CreatedOn] DESC";

        public const string GetRelated = @"
            WITH [RelatedDiscussionIds] AS (
	            SELECT TOP 5 
		            [Discussion_Id]
		            ,COUNT([Discussion_Id]) AS [Score]
	            FROM 
		            [Gada].[dbo].[DiscussionInterests]
	            WHERE
		            [Discussion_Id] != @Id
			            AND
		            [Interest_Id] IN (SELECT 
                                            [Interest_Id] 
                                        FROM 
                                            [Gada].[dbo].[DiscussionInterests] 
                                        WHERE 
                                            [Discussion_Id] = @Id)
	            GROUP BY
		            [Discussion_Id]
	            ORDER BY
		            COUNT([Discussion_Id]) DESC)
            SELECT
	            d.[Id]
                ,d.[Title]
                ,d.[Description]
                ,d.[CreatedOn]
                ,d.[CreatedBy_Id]
                ,u.[Username]
	            ,u.[Email]
            FROM 
	            [RelatedDiscussionIds] rd
            INNER JOIN
	            [Gada].[dbo].[Discussions] d
		            ON
	            rd.[Discussion_Id] = d.[Id]
            INNER JOIN
	            [Gada].[dbo].[Users] u
		            ON
	            d.[CreatedBy_Id] = u.[Id]
            ORDER BY
	            rd.[Score] DESC";

        public const string GetLatest = @"
            SELECT TOP 10
                d.[Id]
				,d.[Title]
                ,d.[Description]
				,d.[CreatedOn]
                ,d.[CreatedBy_Id]
				,u.[Username]
            FROM 
				[Discussions] d
			INNER JOIN
				[Users] u
			ON
				d.[CreatedBy_Id] = u.[Id]
            ORDER BY
				d.[CreatedOn] DESC";

        #endregion
    }
}
