IF NOT EXISTS(SELECT TOP 1 * FROM Users WHERE UserName = 'Herman')
Begin
INSERT INTO Users (UserName, Email, Password) VALUES ('Herman', 'herman@gmail.com', 'qwerty123')
End
GO