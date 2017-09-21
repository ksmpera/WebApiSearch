CREATE PROCEDURE spSearch(
@UserName varchar (100)=null)
AS
BEGIN
SELECT UserID,UserName, Name, SurName, UserPassword, [E-Mail]
FROM [User]
WHERE (@UserName is null or UserName LIKE '%' + @UserName +'%')
ORDER BY UserID
END
