USE [SmartVideoBD]
GO

/****** Object:  Table [dbo].[Hit]    Script Date: 23-11-17 13:42:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Hit](
	[id] [int] NOT NULL,
	[type] [varchar](100) NOT NULL,
	[date] [date] NOT NULL,
	[hit] [int] NOT NULL,
 CONSTRAINT [PK_Hit] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[type] ASC,
	[date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Hit]  WITH CHECK ADD  CONSTRAINT [CK_Hit] CHECK  (([type]='Acteur' OR [type]='Film'))
GO

ALTER TABLE [dbo].[Hit] CHECK CONSTRAINT [CK_Hit]
GO

