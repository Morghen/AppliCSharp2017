USE [SmartVideoBD]
GO

/****** Object:  Table [dbo].[Statistiques]    Script Date: 23-11-17 15:04:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Statistiques](
	[id] [int] NOT NULL,
	[date] [date] NOT NULL,
	[type] [int] NOT NULL,
	[position] [int] NOT NULL,
 CONSTRAINT [PK_Statistiques] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[date] ASC,
	[type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

