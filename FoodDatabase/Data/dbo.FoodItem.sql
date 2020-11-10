CREATE TABLE [dbo].[FoodItem] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX)  NULL,
    [ReleaseDate] DATETIME2 (7)   NOT NULL,
    [Calories]    DECIMAL (18, 2) NULL,
    [Protein]     DECIMAL (18, 2) NOT NULL,
    [Carbs] DECIMAL(18, 2) NULL, 
    [Lipids] DECIMAL(18, 2) NULL, 
    CONSTRAINT [PK_FoodItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);

