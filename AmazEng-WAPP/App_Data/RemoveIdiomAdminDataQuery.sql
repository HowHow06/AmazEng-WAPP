DELETE FROM [dbo].Admins;
DELETE FROM [dbo].AdminRoles;


DBCC CHECKIDENT ('Admins', RESEED, 0);
DBCC CHECKIDENT ('AdminRoles', RESEED, 0);