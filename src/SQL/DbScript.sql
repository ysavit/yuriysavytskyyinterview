USE [master]
GO
/****** Object:  Database [RentlerInterview]    Script Date: 12/13/2023 5:20:33 PM ******/
CREATE DATABASE [RentlerInterview]
GO
ALTER DATABASE [RentlerInterview] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RentlerInterview].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RentlerInterview] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RentlerInterview] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RentlerInterview] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RentlerInterview] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RentlerInterview] SET ARITHABORT OFF 
GO
ALTER DATABASE [RentlerInterview] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RentlerInterview] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RentlerInterview] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RentlerInterview] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RentlerInterview] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RentlerInterview] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RentlerInterview] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RentlerInterview] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RentlerInterview] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RentlerInterview] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RentlerInterview] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [RentlerInterview] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RentlerInterview] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RentlerInterview] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RentlerInterview] SET  MULTI_USER 
GO
ALTER DATABASE [RentlerInterview] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RentlerInterview] SET ENCRYPTION ON
GO
ALTER DATABASE [RentlerInterview] SET QUERY_STORE = ON
GO
ALTER DATABASE [RentlerInterview] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO)
GO
USE [RentlerInterview]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 12/13/2023 5:20:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[Id] [uniqueidentifier] NOT NULL,
	[Brand] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[ServiceSize] [int] NOT NULL,
	[Calories] [int] NOT NULL,
	[Fat] [int] NOT NULL,
	[CarboHydrates] [int] NOT NULL,
	[Proteint] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Foods]    Script Date: 12/13/2023 5:20:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_Foods] ON [dbo].[Foods]
(
	[Description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE [dbo].[Foods] ADD  CONSTRAINT [DF_Foods_ServiceSize]  DEFAULT ((1)) FOR [ServiceSize]
GO
ALTER TABLE [dbo].[Foods] ADD  CONSTRAINT [DF_Foods_DateCreated]  DEFAULT (getutcdate()) FOR [DateCreated]
GO
USE [master]
GO
ALTER DATABASE [RentlerInterview] SET  READ_WRITE 
GO
