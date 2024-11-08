USE [master]
GO
/****** Object:  Database [sharabanyDBorderNew]    Script Date: 2/16/2024 10:47:34 PM ******/
CREATE DATABASE [sharabanyDBorderNew]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SharabanyOrder', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SharabanyOrder.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SharabanyOrder_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SharabanyOrder_log.ldf' , SIZE = 663552KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [sharabanyDBorderNew] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sharabanyDBorderNew].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sharabanyDBorderNew] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET ARITHABORT OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sharabanyDBorderNew] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sharabanyDBorderNew] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET  DISABLE_BROKER 
GO
ALTER DATABASE [sharabanyDBorderNew] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sharabanyDBorderNew] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET RECOVERY FULL 
GO
ALTER DATABASE [sharabanyDBorderNew] SET  MULTI_USER 
GO
ALTER DATABASE [sharabanyDBorderNew] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sharabanyDBorderNew] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sharabanyDBorderNew] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sharabanyDBorderNew] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [sharabanyDBorderNew] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [sharabanyDBorderNew] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'sharabanyDBorderNew', N'ON'
GO
ALTER DATABASE [sharabanyDBorderNew] SET QUERY_STORE = ON
GO
ALTER DATABASE [sharabanyDBorderNew] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [sharabanyDBorderNew]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/16/2024 10:47:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[identityNumber] [nvarchar](50) NULL,
	[PhoneNumbe] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[CompanyNumber] [int] NULL,
	[AccountantNumber] [int] NULL,
	[PhoneNumbe2] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK__Coustome__3214EC27266A1F00] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2/16/2024 10:47:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[ProjectID] [int] NULL,
	[Marketer] [nvarchar](50) NULL,
	[OrderNumber] [int] NULL,
	[DateManual] [date] NULL,
 CONSTRAINT [PK__Orders__3214EC27EC7A59F3] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Orders] UNIQUE NONCLUSTERED 
(
	[OrderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 2/16/2024 10:47:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](200) NULL,
	[ProjectNumber] [int] NULL,
	[Notes] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[IDcustomer] [int] NOT NULL,
	[Manger] [nvarchar](50) NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[ContactPhone] [nvarchar](50) NULL,
	[DateOfCreate] [datetime] NULL,
	[DateOfUpdate] [datetime] NULL,
 CONSTRAINT [PK__Projects__3214EC27F740F0D9] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[SearchGlobal]    Script Date: 2/16/2024 10:47:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SearchGlobal]
AS
SELECT        dbo.Customers.ID AS IDCUSTOMER, dbo.Projects.ID AS IDPROJECT, dbo.Customers.CompanyName, dbo.Customers.PhoneNumbe, dbo.Customers.FullName, dbo.Customers.CompanyNumber, 
                         dbo.Customers.AccountantNumber, dbo.Projects.ProjectName, dbo.Projects.ProjectNumber, dbo.Projects.Notes, dbo.Projects.Address, dbo.Projects.Manger, dbo.Orders.OrderNumber, dbo.Orders.ID AS IDORDER
FROM            dbo.Customers INNER JOIN
                         dbo.Projects ON dbo.Customers.ID = dbo.Projects.IDcustomer INNER JOIN
                         dbo.Orders ON dbo.Projects.ID = dbo.Orders.ProjectID
GO
/****** Object:  Table [dbo].[ColorSide]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorSide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ColorSide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormicaColor]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormicaColor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](50) NULL,
 CONSTRAINT [PK_FormicaColor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FrameAdvanced]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FrameAdvanced](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FrameID] [int] NOT NULL,
	[FromAbove] [int] NULL,
	[FromBottom] [int] NULL,
	[HiddenOil] [bit] NULL,
	[ManualSize] [bit] NULL,
 CONSTRAINT [PK_FrameAdvanced] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_FrameAdvanced] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FrameDefault]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FrameDefault](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Dec] [nvarchar](max) NULL,
	[A1] [decimal](12, 3) NOT NULL,
	[A2] [decimal](12, 3) NOT NULL,
	[B1] [decimal](12, 3) NOT NULL,
	[B2] [decimal](12, 3) NOT NULL,
	[C1] [decimal](12, 3) NOT NULL,
	[C2] [decimal](12, 3) NOT NULL,
	[D1] [decimal](12, 3) NOT NULL,
	[D2] [decimal](12, 3) NOT NULL,
	[E1] [decimal](12, 3) NOT NULL,
	[E2] [decimal](12, 3) NOT NULL,
	[F1] [decimal](12, 3) NOT NULL,
	[F2] [decimal](12, 3) NOT NULL,
	[G1] [decimal](12, 3) NOT NULL,
	[G2] [decimal](12, 3) NOT NULL,
	[Bends] [decimal](12, 3) NOT NULL,
	[F1A] [decimal](12, 3) NOT NULL,
	[F1B] [decimal](12, 3) NOT NULL,
	[F2A] [decimal](12, 3) NOT NULL,
	[F2B] [decimal](12, 3) NOT NULL,
	[MG] [decimal](12, 3) NOT NULL,
	[K125] [decimal](12, 3) NOT NULL,
	[K15] [decimal](12, 3) NOT NULL,
	[K2] [decimal](12, 3) NOT NULL,
 CONSTRAINT [PK_FrameDefault] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FrameLockType]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FrameLockType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LockType] [nvarchar](50) NULL,
	[LockMeasure] [int] NULL,
	[LockMeasureFloor] [int] NULL,
	[UpperLockMeasure] [int] NULL,
	[UpperLockMeasureFloor] [int] NULL,
	[FrameHiegth] [int] NULL,
	[FrameId] [int] NOT NULL,
	[NoCalcu] [bit] NULL,
	[SlipCan] [bit] NULL,
 CONSTRAINT [PK_FrameLockType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[FrameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Frames]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Frames](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FrameType] [nvarchar](100) NULL,
	[Width] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[WallThickness] [int] NULL,
	[IronThickness] [float] NULL,
	[Date] [date] NULL,
	[Direction] [nvarchar](20) NULL,
	[Notes] [nvarchar](max) NULL,
	[Quantity] [int] NULL,
	[LockType] [nvarchar](50) NULL,
	[MaterialType] [nvarchar](50) NULL,
	[OrderID] [int] NOT NULL,
	[FrameThickness] [int] NULL,
	[DoorNumber] [int] NOT NULL,
	[Meksher] [bit] NULL,
	[RHS70] [bit] NULL,
	[DoubleDoor] [bit] NULL,
	[FlakhGV] [bit] NULL,
	[Location] [nvarchar](300) NULL,
	[DoorIdentity] [nvarchar](50) NULL,
	[FactoryNotes] [nvarchar](max) NULL,
	[FrameUnderFloor] [int] NULL,
	[isHand] [bit] NULL,
	[tbPrintAmount] [int] NULL,
	[tbStickers] [int] NULL,
	[tbAmount] [int] NULL,
 CONSTRAINT [PK__Frames__3214EC27E9C25228] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FrameType]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FrameType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AgroupOfDoorFrames] [nvarchar](500) NULL,
	[TypeOfDoorFrame] [nvarchar](500) NULL,
	[LevelType] [nvarchar](500) NULL,
	[WallType] [nvarchar](500) NULL,
	[FrameID] [int] NOT NULL,
 CONSTRAINT [PK_FrameType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[FrameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[FrameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FrameUpperPart]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FrameUpperPart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Kitum] [bit] NULL,
	[Nerousta] [bit] NULL,
	[BottomSize] [int] NULL,
	[upperPartType] [nvarchar](50) NULL,
	[upperPartSize] [int] NULL,
	[FrameID] [int] NOT NULL,
 CONSTRAINT [PK_FrameUpperPart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[FrameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[FrameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hingesFrames]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hingesFrames](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HingeDimension] [int] NULL,
	[Hinge1] [int] NULL,
	[Hinge2] [int] NULL,
	[Hinge3] [int] NULL,
	[Hinge4] [int] NULL,
	[Hinge5] [int] NULL,
	[Hinge6] [int] NULL,
	[HeightToBottomHinge] [int] NULL,
	[HingeAmount] [int] NULL,
	[TopMeddleHinge] [bit] NULL,
	[HingeMetal] [nvarchar](50) NULL,
	[HingeType] [nvarchar](50) NULL,
	[HingeConnection] [nvarchar](50) NULL,
	[FrameID] [int] NOT NULL,
	[NoCalcu] [bit] NULL,
 CONSTRAINT [PK__hingesFr__3214EC2718A24C1E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[FrameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[FrameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KantWingDefault]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KantWingDefault](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[KantA] [decimal](12, 3) NULL,
	[KantB] [decimal](12, 3) NULL,
	[KantC] [decimal](12, 3) NULL,
	[KantD] [decimal](12, 3) NULL,
	[KantE] [decimal](12, 3) NULL,
	[KantF] [decimal](12, 3) NULL,
	[KantG] [decimal](12, 3) NULL,
	[KantH] [decimal](12, 3) NULL,
	[KantI] [decimal](12, 3) NULL,
 CONSTRAINT [PK_KantWing] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KantWingManual]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KantWingManual](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KantA] [decimal](12, 3) NULL,
	[KantB] [decimal](12, 3) NULL,
	[KantC] [decimal](12, 3) NULL,
	[KantD] [decimal](12, 3) NULL,
	[KantE] [decimal](12, 3) NULL,
	[KantF] [decimal](12, 3) NULL,
	[KantG] [decimal](12, 3) NULL,
	[KantH] [decimal](12, 3) NULL,
	[KantI] [decimal](12, 3) NULL,
	[WingID] [int] NOT NULL,
 CONSTRAINT [PK_KantWingManual] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prisa]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prisa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[magnet] [decimal](12, 3) NULL,
	[corner1] [decimal](12, 3) NULL,
	[corner2] [decimal](12, 3) NULL,
	[corner3] [decimal](12, 3) NULL,
	[corner4] [decimal](12, 3) NULL,
	[corner5] [decimal](12, 3) NULL,
	[corner6] [decimal](12, 3) NULL,
	[corner7] [decimal](12, 3) NULL,
	[corner8] [decimal](12, 3) NULL,
	[corner9] [decimal](12, 3) NULL,
	[corner10] [decimal](12, 3) NULL,
	[corner11] [decimal](12, 3) NULL,
	[corner12] [decimal](12, 3) NULL,
	[corner13] [decimal](12, 3) NULL,
	[corner14] [decimal](12, 3) NULL,
	[corner15] [decimal](12, 3) NULL,
	[corner16] [decimal](12, 3) NULL,
	[corner17] [decimal](12, 3) NULL,
	[corner18] [decimal](12, 3) NULL,
	[corner19] [decimal](12, 3) NULL,
	[corner20] [decimal](12, 3) NULL,
	[FrameID] [int] NOT NULL,
 CONSTRAINT [PK__Corners__3214EC27193CA882] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Corners] UNIQUE NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StickerAmountPerDoor_Frame] [tinyint] NULL,
	[StickerAmountPerDoor_F] [tinyint] NULL,
	[StickerAmountPerDoor_A] [tinyint] NULL,
	[StickerAmountPerDoor_Alpha] [tinyint] NULL,
	[StickerAmountPerDoor_Windo] [tinyint] NULL,
	[StickerAmountPerDoor_Tris] [tinyint] NULL,
	[PaperAmountPerDoor_Frame] [tinyint] NULL,
	[PaperAmountPerDoor_F] [tinyint] NULL,
	[PaperAmountPerDoor_A] [tinyint] NULL,
	[PaperAmountPerDoor_Alpha] [tinyint] NULL,
	[PaperAmountPerDoor_Windo] [tinyint] NULL,
	[PaperAmountPerDoor_Tris] [tinyint] NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WingAddon]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WingAddon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StainlessBand] [nvarchar](50) NULL,
	[Offirt] [nvarchar](50) NULL,
	[ThicknessOffirt] [float] NULL,
	[PullHandle] [bit] NULL,
	[ReturnHidden] [bit] NULL,
	[PullHandleHeight] [int] NULL,
	[PullHandleWidth] [int] NULL,
	[PullHandleLocationFromBottom] [int] NULL,
	[PullHandleLocationFromabove] [int] NULL,
	[WingID] [int] NULL,
 CONSTRAINT [PK_WingAddon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WingAdvanced]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WingAdvanced](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WingShorteningFromBottom] [int] NULL,
	[WingShorteningFromAbove] [int] NULL,
	[ThicknessWing] [int] NULL,
	[EvacuationHandle] [bit] NULL,
	[PushSideLever] [bit] NULL,
	[PushHandle] [bit] NULL,
	[PullSideLever] [bit] NULL,
	[PullHandle] [bit] NULL,
	[HandleHoles] [bit] NULL,
	[ClearanceTheCylinder] [bit] NULL,
	[Cylinder] [bit] NULL,
	[HolesCylinder] [bit] NULL,
	[WingID] [int] NOT NULL,
	[woodLockBasic] [bit] NULL,
	[woodUpeerLock] [bit] NULL,
	[woodBehalaLock] [bit] NULL,
	[woodSpeacilCasesHingeUP] [bit] NULL,
	[woodSpeacilCasesHingeDN] [bit] NULL,
	[woodLockBasicWidth] [int] NULL,
	[woodLockBasicHeight] [int] NULL,
	[woodLockBasicLocation] [int] NULL,
	[woodUpeerWidth] [int] NULL,
	[woodUpeerHeight] [int] NULL,
	[woodUpeerLockLocation] [int] NULL,
	[woodBehalaLockWidth] [int] NULL,
	[woodBehalaLockHeight] [int] NULL,
	[woodBehalaLockLocation] [int] NULL,
	[woodSpeacilCasesHingeUPWidth] [int] NULL,
	[woodSpeacilCasesHingeUPHeight] [int] NULL,
	[woodSpeacilCasesHingeUPLocation] [int] NULL,
	[woodSpeacilCasesHingeDNWidth] [int] NULL,
	[woodSpeacilCasesHingeDNHeight] [int] NULL,
	[woodSpeacilCasesHingeDNLocation] [int] NULL,
	[KantA] [int] NULL,
	[KantB] [int] NULL,
	[woodBehalaLockManual] [bit] NULL,
 CONSTRAINT [PK_WingAdvanced_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WingHinge]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WingHinge](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[H1] [int] NULL,
	[H2] [int] NULL,
	[H3] [int] NULL,
	[H4] [int] NULL,
	[H5] [int] NULL,
	[H6] [int] NULL,
	[Amount] [int] NULL,
	[Size] [int] NULL,
	[HeightToBottomHinge] [int] NULL,
	[HingeType] [nvarchar](50) NULL,
	[UpperMid] [bit] NULL,
	[WingID] [int] NULL,
 CONSTRAINT [PK_WingHinge] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_WingHinge] UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WingLock]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WingLock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LockType] [nvarchar](50) NULL,
	[UpperLock] [bit] NULL,
	[LockMeasure] [int] NULL,
	[UpperLockMeasure] [int] NULL,
	[LockMeasureFrame] [int] NULL,
	[UpperLockMeasureFrame] [int] NULL,
	[WingID] [int] NULL,
 CONSTRAINT [PK_WingLock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wings]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OdrerId] [int] NULL,
	[DoorNumber] [nvarchar](30) NULL,
	[DateAdded] [date] NULL,
	[DoorType] [nvarchar](100) NULL,
	[Direction] [nvarchar](50) NULL,
	[LockType] [nvarchar](50) NULL,
	[Location] [nvarchar](200) NULL,
	[FactoryNotes] [nvarchar](200) NULL,
	[Notes] [nvarchar](200) NULL,
	[tbPrintAmount] [int] NULL,
	[tbStickers] [int] NULL,
	[tbAmount] [int] NULL,
	[AccID] [nvarchar](50) NULL,
	[UpdateDate] [date] NULL,
	[ColorDoor] [nvarchar](50) NULL,
	[ColorSide] [nvarchar](50) NULL,
	[FormaicaThickness] [float] NULL,
	[WidthFinal] [int] NULL,
	[HeightFinal] [int] NULL,
	[WidthCut] [int] NULL,
	[HeightCut] [int] NULL,
	[DoubleDoor] [bit] NULL,
	[SupportHelpless] [bit] NULL,
	[MakhzerShemen] [bit] NULL,
	[Atmer] [bit] NULL,
	[Side] [bit] NULL,
	[DDWingID] [int] NULL,
	[DDAK] [nvarchar](5) NULL,
 CONSTRAINT [PK_Wings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wingType]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wingType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TEST1] [nvarchar](50) NOT NULL,
	[TEST2] [nvarchar](50) NOT NULL,
	[TEST3] [nvarchar](50) NOT NULL,
	[TEST4] [nvarchar](50) NOT NULL,
	[WingID] [int] NOT NULL,
 CONSTRAINT [PK_wingType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_wingType] UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WingWindows]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WingWindows](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WindowType] [nvarchar](50) NULL,
	[GlassType] [nvarchar](50) NULL,
	[TrisType] [nvarchar](50) NULL,
	[OpeningDirection] [nvarchar](50) NULL,
	[CircleDiameter] [int] NULL,
	[CircleLocationFromBottom] [int] NULL,
	[WindowHeight] [int] NULL,
	[WindowWidth] [int] NULL,
	[WindowPositionFromAbove] [int] NULL,
	[WindowPositionFromHandle] [int] NULL,
	[TrisHeight] [int] NULL,
	[TrisWidth] [int] NULL,
	[TrisPositionFromHandle] [int] NULL,
	[TrisPositionFromAbove] [int] NULL,
	[TrisPositionFromBottom] [int] NULL,
	[WingID] [int] NULL,
	[WindoInCenter] [bit] NULL,
	[TrisInCenter] [bit] NULL,
	[AorHole] [bit] NULL,
 CONSTRAINT [PK_WingWindows] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[WingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FrameAdvanced]  WITH CHECK ADD  CONSTRAINT [FK_FrameAdvanced_Frames] FOREIGN KEY([FrameID])
REFERENCES [dbo].[Frames] ([ID])
GO
ALTER TABLE [dbo].[FrameAdvanced] CHECK CONSTRAINT [FK_FrameAdvanced_Frames]
GO
ALTER TABLE [dbo].[FrameLockType]  WITH CHECK ADD  CONSTRAINT [FK_FrameLockType_Frames] FOREIGN KEY([FrameId])
REFERENCES [dbo].[Frames] ([ID])
GO
ALTER TABLE [dbo].[FrameLockType] CHECK CONSTRAINT [FK_FrameLockType_Frames]
GO
ALTER TABLE [dbo].[Frames]  WITH CHECK ADD  CONSTRAINT [FK_Frames_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[Frames] CHECK CONSTRAINT [FK_Frames_Orders]
GO
ALTER TABLE [dbo].[FrameType]  WITH CHECK ADD  CONSTRAINT [FK_FrameType_Frames1] FOREIGN KEY([FrameID])
REFERENCES [dbo].[Frames] ([ID])
GO
ALTER TABLE [dbo].[FrameType] CHECK CONSTRAINT [FK_FrameType_Frames1]
GO
ALTER TABLE [dbo].[FrameUpperPart]  WITH CHECK ADD  CONSTRAINT [FK_FrameUpperPart_Frames] FOREIGN KEY([FrameID])
REFERENCES [dbo].[Frames] ([ID])
GO
ALTER TABLE [dbo].[FrameUpperPart] CHECK CONSTRAINT [FK_FrameUpperPart_Frames]
GO
ALTER TABLE [dbo].[hingesFrames]  WITH CHECK ADD  CONSTRAINT [FK_hingesFrames_Frames] FOREIGN KEY([FrameID])
REFERENCES [dbo].[Frames] ([ID])
GO
ALTER TABLE [dbo].[hingesFrames] CHECK CONSTRAINT [FK_hingesFrames_Frames]
GO
ALTER TABLE [dbo].[KantWingManual]  WITH CHECK ADD  CONSTRAINT [FK_KantWingManual_Wings] FOREIGN KEY([WingID])
REFERENCES [dbo].[Wings] ([ID])
GO
ALTER TABLE [dbo].[KantWingManual] CHECK CONSTRAINT [FK_KantWingManual_Wings]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Projects] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Projects]
GO
ALTER TABLE [dbo].[Prisa]  WITH CHECK ADD  CONSTRAINT [FK_Corners_Frames] FOREIGN KEY([FrameID])
REFERENCES [dbo].[Frames] ([ID])
GO
ALTER TABLE [dbo].[Prisa] CHECK CONSTRAINT [FK_Corners_Frames]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Customers] FOREIGN KEY([IDcustomer])
REFERENCES [dbo].[Customers] ([ID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Customers]
GO
ALTER TABLE [dbo].[WingAddon]  WITH CHECK ADD  CONSTRAINT [FK_WingAddon_Wings] FOREIGN KEY([WingID])
REFERENCES [dbo].[Wings] ([ID])
GO
ALTER TABLE [dbo].[WingAddon] CHECK CONSTRAINT [FK_WingAddon_Wings]
GO
ALTER TABLE [dbo].[WingHinge]  WITH CHECK ADD  CONSTRAINT [FK_WingHinge_Wings] FOREIGN KEY([WingID])
REFERENCES [dbo].[Wings] ([ID])
GO
ALTER TABLE [dbo].[WingHinge] CHECK CONSTRAINT [FK_WingHinge_Wings]
GO
ALTER TABLE [dbo].[WingLock]  WITH CHECK ADD  CONSTRAINT [FK_WingLock_Wings] FOREIGN KEY([WingID])
REFERENCES [dbo].[Wings] ([ID])
GO
ALTER TABLE [dbo].[WingLock] CHECK CONSTRAINT [FK_WingLock_Wings]
GO
ALTER TABLE [dbo].[wingType]  WITH CHECK ADD  CONSTRAINT [FK_wingType_Wings] FOREIGN KEY([WingID])
REFERENCES [dbo].[Wings] ([ID])
GO
ALTER TABLE [dbo].[wingType] CHECK CONSTRAINT [FK_wingType_Wings]
GO
ALTER TABLE [dbo].[WingWindows]  WITH CHECK ADD  CONSTRAINT [FK_WingWindows_Wings] FOREIGN KEY([WingID])
REFERENCES [dbo].[Wings] ([ID])
GO
ALTER TABLE [dbo].[WingWindows] CHECK CONSTRAINT [FK_WingWindows_Wings]
GO
/****** Object:  StoredProcedure [dbo].[SP_Add_KantWingManual]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Add_KantWingManual]
    
	@KantA decimal(12,3),
	@KantB decimal(12,3),
	@KantC decimal(12,3),
	@KantD decimal(12,3),
	@KantE decimal(12,3),
	@KantF decimal(12,3),
	@KantG decimal(12,3),
	@KantH decimal(12,3),
	@KantI decimal(12,3),
	@WingID INT ,
	 @NewID INT OUTPUT


AS
BEGIN
INSERT INTO [dbo].[KantWingManual]
           ([KantA]
           ,[KantB]
           ,[KantC]
           ,[KantD]
           ,[KantE]
           ,[KantF]
           ,[KantG]
           ,[KantH]
           ,[KantI]
           ,[WingID])
     VALUES
           (

@KantA,
@KantB,
@KantC,
@KantD,
@KantE,
@KantF,
@KantG,
@KantH,
@KantI,
@WingID
);

SET @NewID = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[SP_FindWingByID]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_FindWingByID]
@id INT
As
BEGIN
SELECT * FROM Wings WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAll_KantWingDefault]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAll_KantWingDefault]

AS
BEGIN
select * from KantWingDefault;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_KantWingDefault_FindByID]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_KantWingDefault_FindByID]
@id INT
As
BEGIN
SELECT * FROM KantWingDefault WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_KantWingManual_FindByID]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_KantWingManual_FindByID]
@id INT
As
BEGIN
SELECT * FROM KantWingManual WHERE ID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_KantWingManual_FindByWingID]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_KantWingManual_FindByWingID]
@id INT
As
BEGIN
SELECT * FROM KantWingManual WHERE WingID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_KantWingDefault]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Update_KantWingDefault]
    @ID INT,   
    @Name NVARCHAR(100),
    @Description NVARCHAR(max),
	@KantA decimal(12,3),
	@KantB decimal(12,3),
	@KantC decimal(12,3),
	@KantD decimal(12,3),
	@KantE decimal(12,3),
	@KantF decimal(12,3),
	@KantG decimal(12,3),
	@KantH decimal(12,3),
	@KantI decimal(12,3)


AS
BEGIN
UPDATE KantWingDefault SET 
Name =@Name,
Description =@Description,
KantA =@KantA,
KantB =@KantB,
KantC =@KantC,
KantD =@KantD,
KantE =@KantE,
KantF =@KantF,
KantG =@KantG,
KantH =@KantH,
KantI =@KantI

WHERE ID=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_KantWingManual]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Update_KantWingManual]
    @ID INT,   
	@KantA decimal(12,3),
	@KantB decimal(12,3),
	@KantC decimal(12,3),
	@KantD decimal(12,3),
	@KantE decimal(12,3),
	@KantF decimal(12,3),
	@KantG decimal(12,3),
	@KantH decimal(12,3),
	@KantI decimal(12,3),
	@WingID int


AS
BEGIN
UPDATE KantWingManual SET 

KantA =@KantA,
KantB =@KantB,
KantC =@KantC,
KantD =@KantD,
KantE =@KantE,
KantF =@KantF,
KantG =@KantG,
KantH =@KantH,
KantI =@KantI,
WingID =@WingID

WHERE ID=@ID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateWings]    Script Date: 2/16/2024 10:47:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SP_UpdateWings]
    @ID INT,
    @OdrerId INT,
    @DoorNumber NVARCHAR(30),
    @DateAdded date,
    @DoorType NVARCHAR(100),
	@Direction NVARCHAR(50),
	@LockType NVARCHAR(50),
	@Location NVARCHAR(200),
	@FactoryNotes NVARCHAR(200),
	@Notes NVARCHAR(200),
	@tbPrintAmount INT,
	@tbStickers INT,
	@tbAmount INT,
	@AccID NVARCHAR(50),
	@UpdateDate date,
	@ColorDoor NVARCHAR(50),
	@ColorSide NVARCHAR(50),
	@FormaicaThickness float,
	@WidthFinal INT,
	@HeightFinal INT,
	@WidthCut INT,
	@HeightCut INT,
	@DoubleDoor bit,
	@SupportHelpless bit,
	@MakhzerShemen bit,
	@Atmer bit,
	@Side bit,
	@DDWingID INT,
	@DDAK NVARCHAR(5)

AS
BEGIN
UPDATE Wings SET 
OdrerId =@OdrerId,
DoorNumber =@DoorNumber,
DateAdded =@DateAdded,
DoorType =@DoorType,
Direction =@Direction,
LockType =@LockType,
Location =@Location,
FactoryNotes =@FactoryNotes,
Notes =@Notes,
tbPrintAmount =@tbPrintAmount,
tbStickers =@tbStickers,
tbAmount =@tbAmount,
AccID =@AccID,
UpdateDate =@UpdateDate,
ColorDoor =@ColorDoor,
ColorSide =@ColorSide,
FormaicaThickness =@FormaicaThickness,
WidthFinal =@WidthFinal,
HeightFinal =@HeightFinal,
WidthCut =@WidthCut,
HeightCut =@HeightCut,
DoubleDoor =@DoubleDoor,
SupportHelpless =@SupportHelpless,
MakhzerShemen =@MakhzerShemen,
Atmer =@Atmer,
Side=@Side,
DDWingID=@DDWingID,
DDAK=@DDAK
WHERE ID=@ID
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Customers"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 202
               Right = 250
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Projects"
            Begin Extent = 
               Top = 6
               Left = 271
               Bottom = 238
               Right = 489
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Orders"
            Begin Extent = 
               Top = 0
               Left = 562
               Bottom = 284
               Right = 892
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SearchGlobal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SearchGlobal'
GO
USE [master]
GO
ALTER DATABASE [sharabanyDBorderNew] SET  READ_WRITE 
GO
