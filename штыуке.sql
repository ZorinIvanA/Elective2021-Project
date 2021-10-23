USE [Books]
GO

INSERT INTO [dbo].[Books]
           ([name]
           ,[published_year]
           ,[pages_count]
           ,[author_id]
           ,[publisher_id])
     VALUES
           ('Преступление и наказание'
           ,2020
           ,150
           ,4
           ,2)
GO
UPDATE [dbo].[Books]
   SET 
	[published_year] = 2018
WHERE id=5
GO
DELETE FROM [dbo].[Books]
WHERE id=5

