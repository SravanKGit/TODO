USE [TODO]
GO
/****** Object:  Table [dbo].[TodoTask]    Script Date: 26-07-2022 23:46:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TodoTask](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](100) NULL,
	[description] [varchar](max) NULL,
	[done] [bit] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
