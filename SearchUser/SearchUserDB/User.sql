CREATE TABLE [dbo].[User](
	[UserID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[SurName] [varchar](100) NOT NULL,	
	[UserPassword] [varchar](100) NOT NULL,
	[E-Mail] [varchar](100) NOT NULL,
)