USE [master]
GO
/****** Object:  Database [StoreManagement]    Script Date: 1/16/2019 10:57:13 PM ******/
CREATE DATABASE [StoreManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoreManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StoreManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StoreManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\StoreManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StoreManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StoreManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [StoreManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StoreManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StoreManagement] SET  MULTI_USER 
GO
ALTER DATABASE [StoreManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [StoreManagement]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 1/16/2019 10:57:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[TotalAmount] [int] NOT NULL,
	[PromotionCode] [int] NOT NULL,
	[PayMethod] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/16/2019 10:57:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CodePromotion]    Script Date: 1/16/2019 10:57:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CodePromotion](
	[Code] [nvarchar](50) NOT NULL,
	[PromotionPrice] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_CodePromotion_1] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CouponPromotion]    Script Date: 1/16/2019 10:57:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CouponPromotion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PromotionPrice] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_CouponPromotion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 1/16/2019 10:57:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Adress] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetailBill]    Script Date: 1/16/2019 10:57:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailBill](
	[ID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [int] NOT NULL,
	[Promotion] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_DetailBill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 1/16/2019 10:57:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[OriginalPrice] [int] NOT NULL,
	[DisplayPrice] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[isDelete] [bit] NOT NULL,
	[ProductSource] [nvarchar](200) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalePercentPromotion]    Script Date: 1/16/2019 10:57:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalePercentPromotion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SalePercent] [float] NOT NULL,
	[isDelete] [bit] NOT NULL,
 CONSTRAINT [PK_SalePercentPromotion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([ID], [CustomerID], [Date], [TotalAmount], [PromotionCode], [PayMethod]) VALUES (8, 12, CAST(0x0000A9D600EA8123 AS DateTime), 153080000, 0, N'ATM')
INSERT [dbo].[Bill] ([ID], [CustomerID], [Date], [TotalAmount], [PromotionCode], [PayMethod]) VALUES (9, 13, CAST(0x0000A97A00ED533C AS DateTime), 55168000, 0, N'Money')
INSERT [dbo].[Bill] ([ID], [CustomerID], [Date], [TotalAmount], [PromotionCode], [PayMethod]) VALUES (10, 14, CAST(0x0000A99900ED5F07 AS DateTime), 66920000, 0, N'ATM')
INSERT [dbo].[Bill] ([ID], [CustomerID], [Date], [TotalAmount], [PromotionCode], [PayMethod]) VALUES (11, 15, CAST(0x0000A9B700ED74DD AS DateTime), 15984000, 0, N'Money')
INSERT [dbo].[Bill] ([ID], [CustomerID], [Date], [TotalAmount], [PromotionCode], [PayMethod]) VALUES (12, 16, CAST(0x0000A9D7002C74D4 AS DateTime), 48670000, 0, N'Money')
INSERT [dbo].[Bill] ([ID], [CustomerID], [Date], [TotalAmount], [PromotionCode], [PayMethod]) VALUES (13, 17, CAST(0x0000A9D7002CBEE8 AS DateTime), 40000000, 10000000, N'ATM')
INSERT [dbo].[Bill] ([ID], [CustomerID], [Date], [TotalAmount], [PromotionCode], [PayMethod]) VALUES (14, 18, CAST(0x0000A9D700B2F86B AS DateTime), 57360000, 0, N'Money')
INSERT [dbo].[Bill] ([ID], [CustomerID], [Date], [TotalAmount], [PromotionCode], [PayMethod]) VALUES (15, 19, CAST(0x0000A9D700FFC89A AS DateTime), 115200000, 0, N'Money')
INSERT [dbo].[Bill] ([ID], [CustomerID], [Date], [TotalAmount], [PromotionCode], [PayMethod]) VALUES (16, 20, CAST(0x0000A9D701680FB8 AS DateTime), 41352000, 10000000, N'Money')
INSERT [dbo].[Bill] ([ID], [CustomerID], [Date], [TotalAmount], [PromotionCode], [PayMethod]) VALUES (17, 21, CAST(0x0000A9D7016C865B AS DateTime), 45370000, 10000000, N'ATM')
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (4, N'Acer', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (5, N'Dell', 0)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (6, N'Macbook', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (7, N'Asus', 0)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (8, N'HP', 0)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1002, N'TBN', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1003, N'TBN', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1004, N'ABC', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1005, N'ABC', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1006, N'qưe', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1007, N'ađ', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1008, N'123', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1009, N'12333', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1010, N'4444', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1011, N'000', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1012, N'123456789', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1013, N'v', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1014, N'0', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1015, N'ádyyuk', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1016, N'123', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1017, N'BCC', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1018, N'100', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1019, N'', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1020, N'', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1021, N'', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1022, N'', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1023, N'', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1024, N'', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1025, N'', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1026, N'', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1027, N'a', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1028, N'a', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1029, N'a', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1030, N'a', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1031, N'a', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1032, N'a', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1033, N'a', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1034, N'a', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1035, N'ád', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1036, N'BAC', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1037, N'MSI', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1038, N'Macbook', 0)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1039, N'Lenovo', 0)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1040, N'Acer', 0)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1041, N'ABC', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1042, N'1612431', 1)
INSERT [dbo].[Category] ([ID], [Name], [isDelete]) VALUES (1043, N'Chrome book', 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
INSERT [dbo].[CodePromotion] ([Code], [PromotionPrice], [isDelete]) VALUES (N'ABC', 10000000, 1)
INSERT [dbo].[CodePromotion] ([Code], [PromotionPrice], [isDelete]) VALUES (N'NGOCTHAO', 10000000, 0)
INSERT [dbo].[CodePromotion] ([Code], [PromotionPrice], [isDelete]) VALUES (N'NT0204', 10000000, 0)
INSERT [dbo].[CodePromotion] ([Code], [PromotionPrice], [isDelete]) VALUES (N'VNPTBTSV', 1000000, 1)
SET IDENTITY_INSERT [dbo].[CouponPromotion] ON 

INSERT [dbo].[CouponPromotion] ([ID], [PromotionPrice], [isDelete]) VALUES (1, 500000, 1)
INSERT [dbo].[CouponPromotion] ([ID], [PromotionPrice], [isDelete]) VALUES (2, 500000, 1)
INSERT [dbo].[CouponPromotion] ([ID], [PromotionPrice], [isDelete]) VALUES (3, 1000000, 1)
INSERT [dbo].[CouponPromotion] ([ID], [PromotionPrice], [isDelete]) VALUES (4, 10000000, 1)
INSERT [dbo].[CouponPromotion] ([ID], [PromotionPrice], [isDelete]) VALUES (5, 100000000, 1)
INSERT [dbo].[CouponPromotion] ([ID], [PromotionPrice], [isDelete]) VALUES (6, 1000000, 1)
INSERT [dbo].[CouponPromotion] ([ID], [PromotionPrice], [isDelete]) VALUES (7, 1200000, 1)
INSERT [dbo].[CouponPromotion] ([ID], [PromotionPrice], [isDelete]) VALUES (8, 2100000, 0)
SET IDENTITY_INSERT [dbo].[CouponPromotion] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([ID], [Name], [Adress], [Phone]) VALUES (12, N'a', N'a', N'a')
INSERT [dbo].[Customer] ([ID], [Name], [Adress], [Phone]) VALUES (13, N'a', N'd', N'a')
INSERT [dbo].[Customer] ([ID], [Name], [Adress], [Phone]) VALUES (14, N'a', N'd', N'd')
INSERT [dbo].[Customer] ([ID], [Name], [Adress], [Phone]) VALUES (15, N'a', N'a', N'a')
INSERT [dbo].[Customer] ([ID], [Name], [Adress], [Phone]) VALUES (16, N'Trần Bá Ngọc', N'Phường 2, Quận 8, TP.HCM', N'0344636377')
INSERT [dbo].[Customer] ([ID], [Name], [Adress], [Phone]) VALUES (17, N'Trần Huy Hùng', N'Phường 3, Quận 7, TP.HCM', N'01234567898')
INSERT [dbo].[Customer] ([ID], [Name], [Adress], [Phone]) VALUES (18, N'a', N'a', N'a')
INSERT [dbo].[Customer] ([ID], [Name], [Adress], [Phone]) VALUES (19, N'a', N'a', N'a')
INSERT [dbo].[Customer] ([ID], [Name], [Adress], [Phone]) VALUES (20, N'Trần Bá Ngọc', N'100/53 Phường 2, Quận 8, TP.HCM', N'0344636377')
INSERT [dbo].[Customer] ([ID], [Name], [Adress], [Phone]) VALUES (21, N'Trần Bá Ngọc', N'100/53 Dương Bá Trạc, Phường 2, Quận 8, TP.HCM', N'0344636377')
SET IDENTITY_INSERT [dbo].[Customer] OFF
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (8, 2, 2, 14690000, 2938000, 23504000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (8, 4, 2, 15990000, 3198000, 25584000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (8, 5, 1, 9990000, 1998000, 7992000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (8, 1004, 1, 120000000, 24000000, 96000000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (9, 4, 1, 15990000, 3198000, 12792000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (9, 6, 1, 20990000, 4198000, 16792000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (9, 7, 2, 15990000, 3198000, 25584000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (10, 2, 1, 14690000, 2938000, 11752000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (10, 6, 1, 20990000, 4198000, 16792000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (10, 7, 3, 15990000, 3198000, 38376000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (11, 5, 2, 9990000, 1998000, 15984000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (12, 2, 1, 14690000, 1000000, 13690000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (12, 4, 1, 15990000, 1000000, 14990000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (12, 6, 1, 20990000, 1000000, 19990000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (13, 1008, 1, 41000000, 1000000, 40000000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (14, 2, 2, 14690000, 1000000, 27380000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (14, 4, 2, 15990000, 1000000, 29980000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (15, 1015, 6, 24000000, 4800000, 115200000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (16, 2, 1, 14690000, 2938000, 11752000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (16, 1012, 1, 9000000, 1800000, 7200000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (16, 1017, 2, 14000000, 2800000, 22400000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (17, 2, 1, 14690000, 2100000, 12590000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (17, 4, 1, 15990000, 2100000, 13890000)
INSERT [dbo].[DetailBill] ([ID], [ProductID], [Quantity], [UnitPrice], [Promotion], [Amount]) VALUES (17, 6, 1, 20990000, 2100000, 18890000)
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (2, 5, N'Dell Inspiron 3576', 14690000, 14690000, 87, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\dell-inspiron-3576.png')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (4, 7, N'Asus VivoBook S15', 15990000, 15990000, 88, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\asus-s510ua-i5.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (5, 4, N'Acer Aspire E5 476', 9990000, 9990000, 93, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\acer-aspire-e5.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (6, 8, N'HP Envy 13', 20990000, 20990000, 106, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\hp-envy-13.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (7, 5, N'Dell Vostro 5568', 15990000, 15990000, 95, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\dell-vostro-5568.png')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1002, 4, N'aceer', 123, 1111, 12, 1, N'C:\Users\TBN\Pictures\Camera Roll\WIN_20180715_11_05_01_Pro.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1003, 5, N'123', 333, 444, 2, 1, N'C:\Users\TBN\Pictures\Camera Roll\WIN_20180714_09_16_30_Pro.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1004, 5, N'Dell Bá Ngọc', 10000000, 12000000, 2, 1, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\login\background.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1005, 1036, N'Bá Ngọc', 1000, 10000, 12, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\login\fb.png')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1006, 5, N'MSI GF63', 54000000, 47000000, 4, 1, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\msi-gf63-8rd.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1007, 1037, N'MSI GF63', 57000000, 47000000, 14, 1, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\msi-gf63-8rd.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1008, 1038, N'Apple Macbook Pro 2017', 41000000, 50000000, 8, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\apple-macbook-pro.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1009, 1039, N'Lenovo Ideapad 330s', 12000000, 16000000, 12, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\lenovo-ideapad-330s.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1010, 5, N'Dell Inspiron 7373', 15000000, 20000000, 15, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\dell-inspiron-7373.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1011, 1040, N'Acer Aspire A715', 9000000, 13000000, 12, 1, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\acer-aspire-a715.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1012, 1040, N'Acer Aspire E5', 7000000, 9000000, 10, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\acer-aspire-e5.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1013, 1040, N'Acer Nitro 5', 30000000, 40000000, 10, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\acer-nitro-5.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1014, 1040, N'Acer Swift SF315', 17000000, 21000000, 10, 1, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\acer-swift-sf315.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1015, 7, N'Asus GL504gm', 18500000, 24000000, 4, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\asus-gl504gm.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1016, 1041, N'Lenovo', 100000000, 120000000, 7, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\lenovo-ideapad-330s.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1017, 1042, N'Acer Swift SF315', 17000000, 14000000, 2, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\acer-swift-sf315.jpg')
INSERT [dbo].[Product] ([ID], [CategoryID], [Name], [OriginalPrice], [DisplayPrice], [Quantity], [isDelete], [ProductSource]) VALUES (1018, 1043, N'Chrome book 12A3', 16000000, 20000000, 210, 0, N'E:\IT\HK_5\Project\LapTrinhWindows\Final\1612431_Final_2018_Management_app\1612431_Final_2018_Management_app\image\dashboard\dell-inspiron-3576.png')
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[SalePercentPromotion] ON 

INSERT [dbo].[SalePercentPromotion] ([ID], [Name], [SalePercent], [isDelete]) VALUES (1, N'Black Friday', 0.2, 1)
INSERT [dbo].[SalePercentPromotion] ([ID], [Name], [SalePercent], [isDelete]) VALUES (2, N'Black Sunday', 0.15, 1)
INSERT [dbo].[SalePercentPromotion] ([ID], [Name], [SalePercent], [isDelete]) VALUES (3, N'', 0, 1)
INSERT [dbo].[SalePercentPromotion] ([ID], [Name], [SalePercent], [isDelete]) VALUES (4, N'123', 0.12, 1)
INSERT [dbo].[SalePercentPromotion] ([ID], [Name], [SalePercent], [isDelete]) VALUES (5, N'Black Friday', 0.2, 1)
INSERT [dbo].[SalePercentPromotion] ([ID], [Name], [SalePercent], [isDelete]) VALUES (6, N'BlackFriday', 1000000, 1)
INSERT [dbo].[SalePercentPromotion] ([ID], [Name], [SalePercent], [isDelete]) VALUES (7, N'BlackFriday', 1000000, 1)
INSERT [dbo].[SalePercentPromotion] ([ID], [Name], [SalePercent], [isDelete]) VALUES (8, N'BlackFriday', 0.2, 1)
INSERT [dbo].[SalePercentPromotion] ([ID], [Name], [SalePercent], [isDelete]) VALUES (9, N'Black Sunday', 0.2, 1)
INSERT [dbo].[SalePercentPromotion] ([ID], [Name], [SalePercent], [isDelete]) VALUES (10, N'BlackSunday', 0.3, 1)
SET IDENTITY_INSERT [dbo].[SalePercentPromotion] OFF
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Customer]
GO
ALTER TABLE [dbo].[DetailBill]  WITH CHECK ADD  CONSTRAINT [FK_DetailBill_Bill] FOREIGN KEY([ID])
REFERENCES [dbo].[Bill] ([ID])
GO
ALTER TABLE [dbo].[DetailBill] CHECK CONSTRAINT [FK_DetailBill_Bill]
GO
ALTER TABLE [dbo].[DetailBill]  WITH CHECK ADD  CONSTRAINT [FK_DetailBill_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[DetailBill] CHECK CONSTRAINT [FK_DetailBill_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [StoreManagement] SET  READ_WRITE 
GO
