﻿CREATE TABLE [dbo].[Logs] (
    [Id] [uniqueidentifier] NOT NULL,
    [UserId] [uniqueidentifier] NOT NULL,
    [LoggedOn] [datetime] NOT NULL,
    [LogData] [nvarchar](max) NOT NULL,
    [LogType_Id] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_dbo.Logs] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_LogType_Id] ON [dbo].[Logs]([LogType_Id])
CREATE TABLE [dbo].[LogTypes] (
    [Id] [uniqueidentifier] NOT NULL,
    [Type] [nvarchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.LogTypes] PRIMARY KEY ([Id])
)
ALTER TABLE [dbo].[Logs] ADD CONSTRAINT [FK_dbo.Logs_dbo.LogTypes_LogType_Id] FOREIGN KEY ([LogType_Id]) REFERENCES [dbo].[LogTypes] ([Id]) ON DELETE CASCADE
--CREATE TABLE [dbo].[__MigrationHistory] (
--    [MigrationId] [nvarchar](150) NOT NULL,
--    [ContextKey] [nvarchar](300) NOT NULL,
--    [Model] [varbinary](max) NOT NULL,
--    [ProductVersion] [nvarchar](32) NOT NULL,
--    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
--)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201510211242594_Intitial', N'Gada.Infrastructure.Data.EntityFramework.Usage.UsageMigrations.Configuration',  0x1F8B0800000000000400E559CB6EE33614DD17E83F105AB545C64A329BD6B067903AC920681207B133E82E60A46B85188AD490546AA3E89775D14FEA2FF4EA2D51B22D3B0FB428B2B149DEC3FB38BC0FE7EF3FFF1A7D5C869C3C81D24C8AB17334387408084FFA4C046327368B773F3A1F3F7CFBCDE8CC0F97E47371EE7D720E25851E3B8FC64443D7D5DE2384540F42E629A9E5C20C3C19BAD497EEF1E1E14FEED1910B08E1201621A3DB58181642FA05BF4EA4F0203231E557D207AEF375DC99A5A8E49A86A023EAC1D8F9447D3AB8100B45B551B167620583536AE8E00C21CDEA5CE1D1DFA4FAE29013CE28EA3703BE700815421A6A50FBE19D8699515204B30817289FAF22C0730BCA35E4560DABE37D0D3C3C4E0C742BC102CA8BB591E18E8047EF738FB9B6F85E7E774A8FA24F33472556A77E1D3B973270887DCF70C2557226F7F89DA601643E66A007287240AA8D83921AC8A0E4EF804C629EC4662C20368AF20372133F70E6FD02ABB9FC02622C62CEEB6AA162B8D758C0A51B25235066750B8B5CD90BDF216E53CEB5054BB19A4C6E4BCCF0F335DE4D1F38944177378A2361D43321D05F01F85351802063618E2F601FA084ED050E12195FAA43AEE8F21244601EC70E7E74C8395B825FACE4C07782E1C346217C373D2EBEA64F2C48A9D05621B9DC21B7C0D37DFDC8A2EC9D25BCB82FF7CF950C6F25CF448AE5FB998C9587BB73D9DE9B53158069AA32722BC26EA37176EFCE544E36FF3F74CE9CF4BAFC5917B413ADA5C7D2A854512B19D354FB4CF864037D32FD73D2A1051820166148F0D6B1F343CB09DD6805E19A6899879A88478E1DCCA938050E06C88997E5F509D51EF5DBFE475FF80DDFD4BCD06634164343990055661F6464B2084BD3C16D4C4E39BD751E19DBEE047406A6F2B77648159DBA0F5B2E6B89A6F7748B674EB3206A963670AA24513BD191436C9F6FE644A97061A6DB4FBE6041533EB7D50E66D3A40ECE9701ACDA1837EB638A7EC75DD3F08CAE6814E17BAC3540F90A9965DDCFE4DD6CF70620CC305C4F77F401A5B6E54D462A649CB58B57A3A6E74C6993D49F079ABCF8891FB68E35E8BA864FC5553546B6035530AC389C7CCE04FAB68029A92DE0CAA5782C084198D4606886BE2D95F6A29453D5918B2792C7A15897CF3749179D451DA158EB8F523517759C6A7527A4ACBBB080B2C536CEC8B59C6987D16DC5B1951A9B9CE8CB98EC71BE166BBA724F3FE6744BBE0E7BB2045A97EFCAC16F11A7664E6C05ABCAF6FB85A392EFF156931CDFA6B59DEBDB2EEA15A002A52B50699D2FE477532A2F607B2AB59B3276056B07B455C8EC23259DCA826615AE515E44B68FF3ADAA921D7108EAFEC4FCA4A2CC56DA40989163F6954F3843025707AEA8600BD026EBC31D9C9D8FADD9FFDF3387BB5AFB7CFB30FEE673442CD8D718D09BA8CD82817AE688FC6C387B5CF6715C362F302E8B27AABC47AABE0BE9F2FB7DC0CAC7BFCED0567F7E217C588E9DDF538C21B9F8F5BE82392053850C1E9243F2C79E03D5DA29F8BFC7A1FA5CBA4BA05E7CD66C0CC86F3212DA1AEC3EDE62144125AEA71CD33696544CDCAD2A7F83C3BEC722CA2D5BDB75A70F3912334A447BE714221009176A46F5B96673812D512D6F6EB37EC791BB3DEA6C1D8CD78DD45939C30CF62031A81987BB66D375C3F6A6597B0D76F7DCFAAA93785DD34627BC6502B7655E67DA6E3723C898DA7F2090AC9A051544F2FF08015E832BE5196C5965415B4BA3E28895D7AEC060AF6BE889C2C4483D83DB1E689DFEEEF699F2188F9C850FE05F88696CA2D8A0C9103EF055DD1909F537DD9FFEA4D0D479348DD21F675FC20454932535782A7E8E19F74BBDCF3BB2F11A88E44D7D025CCF62894FD440B02A91AEA5E80994BBAF4C057308238E607A2A66F409F6D10DBB974B08A8B72A7ACAF520DB03D174FBE894D10067199D6354F2F81539EC87CB0FFF00C2574008881B0000 , N'6.1.3-40302')

