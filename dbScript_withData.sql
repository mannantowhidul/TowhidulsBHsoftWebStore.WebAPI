/****** Object:  Table [dbo].[Admin]    Script Date: 17-Sep-19 4:04:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminID] [int] NOT NULL,
	[AdminName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buyer]    Script Date: 17-Sep-19 4:04:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buyer](
	[BuyerID] [int] IDENTITY(1,1) NOT NULL,
	[BuyerName] [nvarchar](100) NOT NULL,
	[CompanyID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuyerRequestSubmission]    Script Date: 17-Sep-19 4:04:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyerRequestSubmission](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[ReuestDetails] [nvarchar](500) NOT NULL,
	[BuyerID] [int] NOT NULL,
	[SupplierID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
 CONSTRAINT [PK_BuyerRequestSubmission] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 17-Sep-19 4:04:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 17-Sep-19 4:04:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[PermissionID] [int] NOT NULL,
	[BuyerNOS] [int] NOT NULL,
	[SupplierNOS] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 17-Sep-19 4:04:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [int] NOT NULL,
	[SupplierName] [nvarchar](100) NOT NULL,
	[BuyerID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierProcessNpractice]    Script Date: 17-Sep-19 4:04:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierProcessNpractice](
	[ProcessID] [int] IDENTITY(1,1) NOT NULL,
	[ProcessName] [nvarchar](100) NOT NULL,
	[Practice] [nvarchar](500) NOT NULL,
	[SupplierID] [int] NOT NULL,
 CONSTRAINT [PK_SupplierProcessNpractice] PRIMARY KEY CLUSTERED 
(
	[ProcessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Admin] ([AdminID], [AdminName]) VALUES (1, N'Tran Vu Viet Anh')
GO
SET IDENTITY_INSERT [dbo].[Buyer] ON 
GO
INSERT [dbo].[Buyer] ([BuyerID], [BuyerName], [CompanyID]) VALUES (3, N'Malaysia', 1)
GO
INSERT [dbo].[Buyer] ([BuyerID], [BuyerName], [CompanyID]) VALUES (4, N'Bangladesh', 1)
GO
INSERT [dbo].[Buyer] ([BuyerID], [BuyerName], [CompanyID]) VALUES (5, N'China', 1)
GO
INSERT [dbo].[Buyer] ([BuyerID], [BuyerName], [CompanyID]) VALUES (6, N'Singapore', 1)
GO
SET IDENTITY_INSERT [dbo].[Buyer] OFF
GO
SET IDENTITY_INSERT [dbo].[BuyerRequestSubmission] ON 
GO
INSERT [dbo].[BuyerRequestSubmission] ([RequestID], [ReuestDetails], [BuyerID], [SupplierID], [CompanyID]) VALUES (1, N'Buyer 3 Test Request', 3, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[BuyerRequestSubmission] OFF
GO
SET IDENTITY_INSERT [dbo].[Company] ON 
GO
INSERT [dbo].[Company] ([CompanyID], [CompanyName]) VALUES (1, N'BH Tech Software')
GO
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [BuyerID]) VALUES (1, N'Towhidul Mannan', 1)
GO
SET IDENTITY_INSERT [dbo].[SupplierProcessNpractice] ON 
GO
INSERT [dbo].[SupplierProcessNpractice] ([ProcessID], [ProcessName], [Practice], [SupplierID]) VALUES (1, N'TEST 1', N'Supplier 1 Test 1 request', 1)
GO
SET IDENTITY_INSERT [dbo].[SupplierProcessNpractice] OFF
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_Users]
GO
