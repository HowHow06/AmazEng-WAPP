﻿DELETE FROM [dbo].Idioms;
DELETE FROM [dbo].Tags;
DELETE FROM [dbo].IdiomTags;

DBCC CHECKIDENT ('Idioms', RESEED, 0);
DBCC CHECKIDENT ('Tags', RESEED, 0);
DBCC CHECKIDENT ('IdiomTags', RESEED, 0);