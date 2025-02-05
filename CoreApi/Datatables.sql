CREATE TABLE [dbo].[USERS]
(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[isActive] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[Dummies]
(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[isActive] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[Product]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProdName] [nvarchar](max) NULL,
	[ProdDesc] [nvarchar](max) NULL,
	[ProdPrice] [int] NULL,
	[UpdatedAt] [DateTime] NULL
)
GO


