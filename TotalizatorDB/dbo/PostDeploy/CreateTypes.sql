IF NOT EXISTS(SELECT TOP 1 * FROM Types WHERE Name = 'Football')
Begin
INSERT INTO Types (Name) VALUES ('Football')
End 
GO

IF NOT EXISTS(SELECT TOP 1 * FROM Types WHERE Name = 'Basketball')
Begin
INSERT INTO Types (Name) VALUES ('Basketball')
End 
GO

IF NOT EXISTS(SELECT TOP 1 * FROM Types WHERE Name = 'Hockey')
Begin
INSERT INTO Types (Name) VALUES ('Hockey')
End 
GO