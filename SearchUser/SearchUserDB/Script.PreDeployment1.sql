/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [User](UserName, Name, SurName, UserPassword, [E-Mail])
VALUES ('Tom@1', 'Tom', 'Skagen', 'skagen1', 'Tom@gmail.com');

INSERT INTO [UserAccount](Account, Balans, Currency, UserID)
VALUES ('23-24455948-443', '1000', 'Eur', '1');

INSERT INTO [UserAccount](Account, Balans, Currency, UserID)
VALUES ('43-24321228-554', '1000', 'Eur', '1');