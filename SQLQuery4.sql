USE [master]
GO
/****** Object:  Database [UserSearch]    Script Date: 9/21/2017 9:15:23 AM ******/
CREATE DATABASE [UserSearch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserSearch', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UserSearch.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UserSearch_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UserSearch_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UserSearch] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserSearch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserSearch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserSearch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserSearch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserSearch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserSearch] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserSearch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserSearch] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UserSearch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserSearch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserSearch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserSearch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserSearch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserSearch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserSearch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserSearch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserSearch] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UserSearch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserSearch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserSearch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserSearch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserSearch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserSearch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserSearch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserSearch] SET RECOVERY FULL 
GO
ALTER DATABASE [UserSearch] SET  MULTI_USER 
GO
ALTER DATABASE [UserSearch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserSearch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserSearch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserSearch] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UserSearch', N'ON'
GO
USE [UserSearch]
GO
/****** Object:  StoredProcedure [dbo].[spAddAccount]    Script Date: 9/21/2017 9:15:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddAccount]
(@Account VARCHAR(100), @Currency VARCHAR(5))
AS 
INSERT INTO UserAccount(Account, Currency, Balans, UserID) 
VALUES (@Account, @Currency, 0, (select MAX(UserID) from [User]))
GO
/****** Object:  StoredProcedure [dbo].[spAddUser]    Script Date: 9/21/2017 9:15:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddUser]
(@UserName VARCHAR(100), @Name VARCHAR(100), @SurName varchar (100), @UserPassword varchar(100), @EMail varchar (100))
AS
INSERT INTO [User](UserName, Name, SurName, UserPassword,[E-Mail]) 
VALUES(@UserName, @Name, @SurName, @UserPassword, @EMail)
GO
/****** Object:  StoredProcedure [dbo].[spSearch]    Script Date: 9/21/2017 9:15:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spSearch](
@UserName varchar (100)=null)
AS
BEGIN
SELECT UserID,UserName, Name, SurName, UserPassword, [E-Mail]
FROM [User]
WHERE (@UserName is null or UserName LIKE '%' + @UserName +'%')
ORDER BY UserID
END
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/21/2017 9:15:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[SurName] [varchar](100) NOT NULL,
	[UserPassword] [varchar](100) NOT NULL,
	[E-Mail] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 9/21/2017 9:15:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAccount](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](100) NOT NULL,
	[Balans] [int] NULL,
	[Currency] [varchar](5) NOT NULL,
	[UserID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[UserAccount]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
USE [master]
GO
ALTER DATABASE [UserSearch] SET  READ_WRITE 
GO
