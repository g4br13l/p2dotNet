CREATE TABLE [dbo].[Table]
(
	[IdLivro] INT NOT NULL PRIMARY KEY, 
    [Nome] NVARCHAR(MAX) NULL, 
    [Preco] DECIMAL(14, 2) NULL, 
    [DataPublicacao] DATETIME NULL
)
