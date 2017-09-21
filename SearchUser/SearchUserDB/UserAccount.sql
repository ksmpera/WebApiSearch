CREATE TABLE [dbo].[UserAccount](
	[AccountID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,	
	[Account] [varchar](100) NOT NULL,
	[Balans] [int] NULL,
	[Currency] [varchar](5)  NOT NULL,
	[UserID] [int] REFERENCES [User](UserID) NOT NULL,
)