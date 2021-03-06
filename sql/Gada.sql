USE [master]
GO
/****** Object:  Database [Gada]    Script Date: 08/06/2015 20:02:56 ******/
CREATE DATABASE [Gada]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Gada', FILENAME = N'F:\Databases\Gada.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Gada_log', FILENAME = N'F:\Databases\Logs\Gada_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Gada] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Gada].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Gada] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Gada] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Gada] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Gada] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Gada] SET ARITHABORT OFF 
GO
ALTER DATABASE [Gada] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Gada] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Gada] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Gada] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Gada] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Gada] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Gada] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Gada] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Gada] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Gada] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Gada] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Gada] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Gada] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Gada] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Gada] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Gada] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Gada] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Gada] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Gada] SET  MULTI_USER 
GO
ALTER DATABASE [Gada] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Gada] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Gada] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Gada] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Gada]
GO
/****** Object:  User [GadaDbLogin]    Script Date: 08/06/2015 20:02:56 ******/
CREATE USER [GadaDbLogin] FOR LOGIN [GadaDbLogin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [GadaDbLogin]
GO
/****** Object:  Table [dbo].[DiscussionGroups]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DiscussionGroups](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [varchar](300) NOT NULL,
	[Information] [varchar](4000) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[DateTimeCreated] [datetime] NOT NULL,
	[ApprovedRejected] [bit] NULL,
	[ApprovedRejectedBy] [uniqueidentifier] NULL,
	[DateTimeApprovedRejected] [datetime] NULL,
 CONSTRAINT [PK_DiscussionGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DiscussionPost]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscussionPost](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[DiscussionGroupId] [uniqueidentifier] NOT NULL,
	[Post] [nvarchar](4000) NOT NULL,
	[DateTimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_DiscussionPost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DiscussionPostComments]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DiscussionPostComments](
	[Id] [uniqueidentifier] NOT NULL,
	[DiscussionPostId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Comment] [varchar](4000) NOT NULL,
	[DateTimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_DiscussionComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DiscussionPostUpVotes]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscussionPostUpVotes](
	[Id] [uniqueidentifier] NOT NULL,
	[DiscussionPostId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DiscussionCommentUpVotes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Interests]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Interests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InterestName] [varchar](200) NOT NULL,
	[InterestDescription] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Interests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PollAnswers]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PollAnswers](
	[Id] [uniqueidentifier] NOT NULL,
	[PollId] [uniqueidentifier] NOT NULL,
	[Answer] [varchar](200) NOT NULL,
 CONSTRAINT [PK_PollAnswers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PollResponses]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PollResponses](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[PollAnswerId] [uniqueidentifier] NOT NULL,
	[DateTimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_PollResponses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Polls]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Polls](
	[Id] [uniqueidentifier] NOT NULL,
	[Question] [varchar](800) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ExpiryDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Polls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionTypes]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuestionTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[QuestionType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_QuestionTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReportedComments]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportedComments](
	[Id] [uniqueidentifier] NOT NULL,
	[CommentId] [uniqueidentifier] NOT NULL,
	[ReportedBy] [uniqueidentifier] NOT NULL,
	[DateTimeStamp] [datetime] NOT NULL,
	[BannedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ReportedDiscussionComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Skills]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SkillName] [varchar](200) NOT NULL,
	[SkillDescription] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SurveyQuestionAnswers]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SurveyQuestionAnswers](
	[Id] [uniqueidentifier] NOT NULL,
	[SurveyQuestionId] [uniqueidentifier] NOT NULL,
	[Answer] [varchar](500) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_SurveyQuestionAnswers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SurveyQuestions]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyQuestions](
	[Id] [uniqueidentifier] NOT NULL,
	[SurveyId] [uniqueidentifier] NOT NULL,
	[QuestionTypeId] [uniqueidentifier] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_SurveyQuestions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SurveyResponseAnswers]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SurveyResponseAnswers](
	[Id] [uniqueidentifier] NOT NULL,
	[SurveyResponseId] [uniqueidentifier] NOT NULL,
	[SurveyQuestionId] [uniqueidentifier] NOT NULL,
	[Response] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_SurveyResponseAnswers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SurveyResponses]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyResponses](
	[Id] [uniqueidentifier] NOT NULL,
	[SurveyId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[DateTimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_SurveyResponses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Surveys]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Surveys](
	[Id] [uniqueidentifier] NOT NULL,
	[SurveyTitle] [varchar](500) NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Surveys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserFollowers]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFollowers](
	[Id] [uniqueidentifier] NOT NULL,
	[FollowerId] [uniqueidentifier] NOT NULL,
	[PersonFollowing] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserFollowers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserInterests]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInterests](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[InterestId] [int] NOT NULL,
 CONSTRAINT [PK_UserInterests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Forename] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](2000) NOT NULL,
	[Password] [nvarchar](2000) NOT NULL,
	[Registered] [datetime] NOT NULL,
	[LastLogin] [datetime] NOT NULL,
	[AuthCode] [nvarchar](50) NOT NULL,
	[Authenticated] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSkills]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSkills](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[SkillId] [int] NOT NULL,
 CONSTRAINT [PK_UserSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DiscussionGroups]  WITH CHECK ADD  CONSTRAINT [FK_DiscussionGroups_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[DiscussionGroups] CHECK CONSTRAINT [FK_DiscussionGroups_Users]
GO
ALTER TABLE [dbo].[DiscussionGroups]  WITH CHECK ADD  CONSTRAINT [FK_DiscussionGroups_Users1] FOREIGN KEY([ApprovedRejectedBy])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[DiscussionGroups] CHECK CONSTRAINT [FK_DiscussionGroups_Users1]
GO
ALTER TABLE [dbo].[DiscussionPost]  WITH CHECK ADD  CONSTRAINT [FK_DiscussionPost_DiscussionGroups] FOREIGN KEY([DiscussionGroupId])
REFERENCES [dbo].[DiscussionGroups] ([Id])
GO
ALTER TABLE [dbo].[DiscussionPost] CHECK CONSTRAINT [FK_DiscussionPost_DiscussionGroups]
GO
ALTER TABLE [dbo].[DiscussionPost]  WITH CHECK ADD  CONSTRAINT [FK_DiscussionPost_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[DiscussionPost] CHECK CONSTRAINT [FK_DiscussionPost_Users]
GO
ALTER TABLE [dbo].[DiscussionPostComments]  WITH CHECK ADD  CONSTRAINT [FK_DiscussionComments_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[DiscussionPostComments] CHECK CONSTRAINT [FK_DiscussionComments_Users]
GO
ALTER TABLE [dbo].[DiscussionPostUpVotes]  WITH CHECK ADD  CONSTRAINT [FK_DiscussionCommentUpVotes_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[DiscussionPostUpVotes] CHECK CONSTRAINT [FK_DiscussionCommentUpVotes_Users]
GO
ALTER TABLE [dbo].[DiscussionPostUpVotes]  WITH CHECK ADD  CONSTRAINT [FK_DiscussionPostUpVotes_DiscussionPost] FOREIGN KEY([DiscussionPostId])
REFERENCES [dbo].[DiscussionPost] ([Id])
GO
ALTER TABLE [dbo].[DiscussionPostUpVotes] CHECK CONSTRAINT [FK_DiscussionPostUpVotes_DiscussionPost]
GO
ALTER TABLE [dbo].[PollAnswers]  WITH CHECK ADD  CONSTRAINT [FK_PollAnswers_Polls] FOREIGN KEY([PollId])
REFERENCES [dbo].[Polls] ([Id])
GO
ALTER TABLE [dbo].[PollAnswers] CHECK CONSTRAINT [FK_PollAnswers_Polls]
GO
ALTER TABLE [dbo].[PollResponses]  WITH CHECK ADD  CONSTRAINT [FK_PollResponses_PollAnswers] FOREIGN KEY([PollAnswerId])
REFERENCES [dbo].[PollAnswers] ([Id])
GO
ALTER TABLE [dbo].[PollResponses] CHECK CONSTRAINT [FK_PollResponses_PollAnswers]
GO
ALTER TABLE [dbo].[PollResponses]  WITH CHECK ADD  CONSTRAINT [FK_PollResponses_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PollResponses] CHECK CONSTRAINT [FK_PollResponses_Users]
GO
ALTER TABLE [dbo].[Polls]  WITH CHECK ADD  CONSTRAINT [FK_Polls_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Polls] CHECK CONSTRAINT [FK_Polls_Users]
GO
ALTER TABLE [dbo].[ReportedComments]  WITH CHECK ADD  CONSTRAINT [FK_ReportedDiscussionComments_DiscussionComments] FOREIGN KEY([CommentId])
REFERENCES [dbo].[DiscussionPostComments] ([Id])
GO
ALTER TABLE [dbo].[ReportedComments] CHECK CONSTRAINT [FK_ReportedDiscussionComments_DiscussionComments]
GO
ALTER TABLE [dbo].[ReportedComments]  WITH CHECK ADD  CONSTRAINT [FK_ReportedDiscussionComments_Users] FOREIGN KEY([ReportedBy])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ReportedComments] CHECK CONSTRAINT [FK_ReportedDiscussionComments_Users]
GO
ALTER TABLE [dbo].[SurveyQuestionAnswers]  WITH CHECK ADD  CONSTRAINT [FK_SurveyQuestionAnswers_SurveyQuestions] FOREIGN KEY([SurveyQuestionId])
REFERENCES [dbo].[SurveyQuestions] ([Id])
GO
ALTER TABLE [dbo].[SurveyQuestionAnswers] CHECK CONSTRAINT [FK_SurveyQuestionAnswers_SurveyQuestions]
GO
ALTER TABLE [dbo].[SurveyQuestions]  WITH CHECK ADD  CONSTRAINT [FK_SurveyQuestions_QuestionTypes] FOREIGN KEY([QuestionTypeId])
REFERENCES [dbo].[QuestionTypes] ([Id])
GO
ALTER TABLE [dbo].[SurveyQuestions] CHECK CONSTRAINT [FK_SurveyQuestions_QuestionTypes]
GO
ALTER TABLE [dbo].[SurveyQuestions]  WITH CHECK ADD  CONSTRAINT [FK_SurveyQuestions_Surveys] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Surveys] ([Id])
GO
ALTER TABLE [dbo].[SurveyQuestions] CHECK CONSTRAINT [FK_SurveyQuestions_Surveys]
GO
ALTER TABLE [dbo].[SurveyResponseAnswers]  WITH CHECK ADD  CONSTRAINT [FK_SurveyResponseAnswers_SurveyQuestions] FOREIGN KEY([SurveyQuestionId])
REFERENCES [dbo].[SurveyQuestions] ([Id])
GO
ALTER TABLE [dbo].[SurveyResponseAnswers] CHECK CONSTRAINT [FK_SurveyResponseAnswers_SurveyQuestions]
GO
ALTER TABLE [dbo].[SurveyResponseAnswers]  WITH CHECK ADD  CONSTRAINT [FK_SurveyResponseAnswers_SurveyResponses] FOREIGN KEY([SurveyResponseId])
REFERENCES [dbo].[SurveyResponses] ([Id])
GO
ALTER TABLE [dbo].[SurveyResponseAnswers] CHECK CONSTRAINT [FK_SurveyResponseAnswers_SurveyResponses]
GO
ALTER TABLE [dbo].[SurveyResponses]  WITH CHECK ADD  CONSTRAINT [FK_SurveyResponses_Surveys] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Surveys] ([Id])
GO
ALTER TABLE [dbo].[SurveyResponses] CHECK CONSTRAINT [FK_SurveyResponses_Surveys]
GO
ALTER TABLE [dbo].[SurveyResponses]  WITH CHECK ADD  CONSTRAINT [FK_SurveyResponses_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[SurveyResponses] CHECK CONSTRAINT [FK_SurveyResponses_Users]
GO
ALTER TABLE [dbo].[Surveys]  WITH CHECK ADD  CONSTRAINT [FK_Surveys_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Surveys] CHECK CONSTRAINT [FK_Surveys_Users]
GO
ALTER TABLE [dbo].[UserFollowers]  WITH CHECK ADD  CONSTRAINT [FK_UserFollowers_Users] FOREIGN KEY([FollowerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserFollowers] CHECK CONSTRAINT [FK_UserFollowers_Users]
GO
ALTER TABLE [dbo].[UserFollowers]  WITH CHECK ADD  CONSTRAINT [FK_UserFollowers_Users1] FOREIGN KEY([PersonFollowing])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserFollowers] CHECK CONSTRAINT [FK_UserFollowers_Users1]
GO
ALTER TABLE [dbo].[UserInterests]  WITH CHECK ADD  CONSTRAINT [FK_UserInterests_Interests] FOREIGN KEY([InterestId])
REFERENCES [dbo].[Interests] ([Id])
GO
ALTER TABLE [dbo].[UserInterests] CHECK CONSTRAINT [FK_UserInterests_Interests]
GO
ALTER TABLE [dbo].[UserInterests]  WITH CHECK ADD  CONSTRAINT [FK_UserInterests_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserInterests] CHECK CONSTRAINT [FK_UserInterests_Users]
GO
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_Skills] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skills] ([Id])
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_Skills]
GO
ALTER TABLE [dbo].[UserSkills]  WITH CHECK ADD  CONSTRAINT [FK_UserSkills_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserSkills] CHECK CONSTRAINT [FK_UserSkills_Users]
GO
/****** Object:  StoredProcedure [dbo].[CreateInterest]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateInterest]
@InterestName varchar(200),
@InterestDescription varchar(1000)
AS
BEGIN
	INSERT INTO Interests(InterestName, InterestDescription)
	VALUES (@InterestName, @InterestDescription)  
END



GO
/****** Object:  StoredProcedure [dbo].[CreatePoll]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreatePoll]
@Id uniqueidentifier,
@Question varchar(800),
@CreatedBy uniqueidentifier,
@CreatedDate datetime,
@ExpiryDate datetime
AS
BEGIN
	INSERT INTO Polls (Id, Question, CreatedBy, CreatedDate, ExpiryDate)
	VALUES (@Id, @Question, @CreatedBy, @CreatedDate, @ExpiryDate)
END



GO
/****** Object:  StoredProcedure [dbo].[CreatePollAnswer]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreatePollAnswer]
@Id uniqueidentifier,
@PollId uniqueidentifier,
@Answer varchar(200)
AS
BEGIN
	INSERT INTO PollAnswers (Id, PollId, Answer)
	VALUES (@Id, @PollId, @Answer)
END



GO
/****** Object:  StoredProcedure [dbo].[CreateSkill]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateSkill]
@SkillName varchar(200),
@SkillDescription varchar(1000)
AS
BEGIN
	INSERT INTO Skills(SkillName, SkillDescription)
	VALUES (@SkillName, @SkillDescription)  
END



GO
/****** Object:  StoredProcedure [dbo].[FollowUser]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FollowUser]
@Id uniqueidentifier,
@FollowerId uniqueidentifier,
@PersonFollowingId uniqueidentifier
AS
BEGIN
	INSERT INTO UserFollowers(Id, FollowerId, PersonFollowing)
	VALUES (@Id, @FollowerId, @PersonFollowingId)
END



GO
/****** Object:  StoredProcedure [dbo].[GetDiscussionGroup]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetDiscussionGroup]
@DiscussionGroupId uniqueidentifier
AS
BEGIN
	SELECT dg.Id, dg.Title, dg.Information, u.Forename + ' ' + u.Surname as CreatedBy, dg.DateTimeCreated, dg.ApprovedRejected, ar.Forename + ' ' + ar.Surname as ApprovedRejectedBy, dg.DateTimeApprovedRejected
	FROM DiscussionGroups dg
	LEFT JOIN users u on dg.CreatedBy = u.Id
	LEFT JOIN users ar on dg.ApprovedRejectedBy = u.Id
	WHERE dg.Id = @DiscussionGroupId
END



GO
/****** Object:  StoredProcedure [dbo].[GetPeopleFollowing]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPeopleFollowing]
@UserId uniqueidentifier
AS
BEGIN
	SELECT u.Forename, u.Surname
	FROM Users u
	LEFT JOIN UserFollowers uf on u.Id = uf.PersonFollowing
	WHERE uf.FollowerId = @UserId
END



GO
/****** Object:  StoredProcedure [dbo].[GetPoll]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPoll]
@PollId uniqueidentifier
AS
BEGIN
	SELECT p.Id, p.Question, p.CreatedBy, p.CreatedDate, p.ExpiryDate
	FROM Polls p
	Where p.Id = @PollId  
END



GO
/****** Object:  StoredProcedure [dbo].[GetPollAnswers]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPollAnswers]
@PollId uniqueidentifier
AS
BEGIN
	SELECT pa.Id, pa.Answer
	FROM PollAnswers pa
	Where pa.PollId = @PollId  
END



GO
/****** Object:  StoredProcedure [dbo].[GetPollResults]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPollResults]
@PollId uniqueidentifier
AS
BEGIN
	SELECT pa.Id, pa.Answer, count(pr.Id)
	FROM PollAnswers pa 
	LEFT JOIN PollResponses pr on pa.Id = pr.PollAnswerId
	WHERE pa.PollId = @PollId
	GROUP BY pa.Id, pa.Answer  
END



GO
/****** Object:  StoredProcedure [dbo].[GetUserSkillsInterests]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserSkillsInterests]
	@UserId uniqueidentifier
AS
BEGIN
	SELECT s.Id as Id, s.SkillName as Name from Skills s
	LEFT JOIN UserSkills us on s.Id = us.SkillId
	WHERE us.UserId = @UserId

	UNION

	SELECT i.Id as Id, i.InterestName as Name from Interests i
	LEFT JOIN UserInterests ui on i.Id = ui.InterestId
	WHERE ui.UserId = @UserId

	ORDER BY Name
END

GO
/****** Object:  StoredProcedure [dbo].[InsertDiscussionCommentUpVote]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertDiscussionCommentUpVote]
@Id uniqueidentifier,
@CommentId uniqueidentifier,
@UserId uniqueidentifier
AS
BEGIN
	INSERT INTO DiscussionCommentUpVotes(Id, CommentId, UserId)
	VALUES (@Id, @CommentId, @UserId)  
END



GO
/****** Object:  StoredProcedure [dbo].[InsertPollResponse]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPollResponse]
@Id uniqueidentifier,
@UserId uniqueidentifier,
@PollAnswerId uniqueidentifier,
@DateTimeStamp datetime
AS
BEGIN
	INSERT INTO PollResponses (Id, UserId, PollAnswerId, DateTimeStamp)
	VALUES (@Id, @UserId, @PollAnswerId, @DateTimeStamp)
END



GO
/****** Object:  StoredProcedure [dbo].[ListAllDiscussionGroups]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListAllDiscussionGroups]
AS
BEGIN
	SELECT dg.Id, dg.Title, dg.Information, u.Forename + ' ' + u.Surname as CreatedBy, dg.DateTimeCreated, dg.ApprovedRejected
	FROM DiscussionGroups dg
	LEFT JOIN Users u on dg.CreatedBy = u.Id
END



GO
/****** Object:  StoredProcedure [dbo].[ListApprovedDiscussionGroups]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListApprovedDiscussionGroups]
AS
BEGIN
	SELECT dg.Id, dg.Title, dg.Information, u.Forename + ' ' + u.Surname as CreatedBy, dg.DateTimeCreated
	FROM DiscussionGroups dg
	LEFT JOIN Users u on dg.CreatedBy = u.Id
	WHERE dg.ApprovedRejected = 1	
END



GO
/****** Object:  StoredProcedure [dbo].[ListDiscussionComments]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListDiscussionComments]
@DiscussionGroupId uniqueidentifier
AS
BEGIN
	SELECT dgc.Id, u.Forename + ' ' + u.Surname as commentor, dgc.comment, dgc.dateTimeStamp, 
		(SELECT count(uv.Id) FROM DiscussionGroupCommentUpVotes uv where uv.CommentId = dgc.Id) as UpVotes
	FROM DiscussionGroupComments dgc
	LEFT JOIN Users u on dgc.UserId = u.Id
	WHERE dgc.DiscussionGroupId = @DiscussionGroupId
	
END



GO
/****** Object:  StoredProcedure [dbo].[ListInterests]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListInterests]
AS
BEGIN
	SELECT i.Id, i.InterestName as Name, i.InterestDescription as [Description] from Interests i
END



GO
/****** Object:  StoredProcedure [dbo].[ListPolls]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListPolls]
AS
BEGIN
	SELECT p.Id, p.Question, u.Forename + ' ' + u.Surname as CreatedBy, p.CreatedDate, p.ExpiryDate
	FROM Polls p
	LEFT JOIN Users u on p.CreatedBy = u.Id
END



GO
/****** Object:  StoredProcedure [dbo].[ListSkills]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListSkills]
AS
BEGIN
	SELECT s.Id, s.SkillName as Name, s.SkillDescription as [Description] from Skills s
END



GO
/****** Object:  StoredProcedure [dbo].[RegisterUser]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterUser]
@Forename nvarchar(50),
@Surname nvarchar(50),
@EmailAddress nvarchar(2000),
@Password nvarchar(2000)
AS
BEGIN
	--Check to see if the user already exists
	DECLARE @Id uniqueidentifier
	set @Id = (SELECT Id FROM Users where EmailAddress = @EmailAddress)
	if(@Id is null)
	begin
		SET @Id = NEWID()
		INSERT INTO Users(Id, Forename, Surname, EmailAddress, [Password], Registered, LastLogin)
		VALUES (@Id, @Forename, @Surname, @EmailAddress, @Password, GetDate(), GetDate())
	end
END

GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 08/06/2015 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserLogin]
@EmailAddress nvarchar(2000),
@Password nvarchar(2000)
AS
BEGIN
	SELECT Id, Forename, Surname, EmailAddress FROM Users where EmailAddress = @EmailAddress and [Password] = @Password
END

GO
USE [master]
GO
ALTER DATABASE [Gada] SET  READ_WRITE 
GO
