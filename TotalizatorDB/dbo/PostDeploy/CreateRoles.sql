IF NOT EXISTS(SELECT TOP 1 * FROM Roles WHERE Name = 'Admin')
Begin
INSERT INTO Roles (Name) VALUES ('Admin')
End 
GO

IF NOT EXISTS(SELECT TOP 1 * FROM Roles WHERE Name = 'User')
Begin
INSERT INTO Roles (Name) VALUES ('User')
End 
GO

IF NOT EXISTS(SELECT TOP 1 * FROM Roles WHERE Name = 'Moderator')
Begin
INSERT INTO Roles (Name) VALUES ('Moderator')
End 
GO