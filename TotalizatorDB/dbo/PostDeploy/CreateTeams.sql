IF NOT EXISTS(SELECT TOP 1 * FROM Teams WHERE Name = 'Chelsea')
Begin
INSERT INTO Teams (Name) VALUES ('Chelsea')
End 
GO

IF NOT EXISTS(SELECT TOP 1 * FROM Teams WHERE Name = 'Liverpool')
Begin
INSERT INTO Teams (Name) VALUES ('Liverpool')
End 
GO

IF NOT EXISTS(SELECT TOP 1 * FROM Teams WHERE Name = 'Rangers')
Begin
INSERT INTO Teams (Name) VALUES ('Rangers')
End 
GO