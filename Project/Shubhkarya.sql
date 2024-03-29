USE [master]
GO
/****** Object:  Database [Shubhkarya]    Script Date: 03-01-2024 18:31:50 ******/
CREATE DATABASE [Shubhkarya]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Shubhkarya', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS02\MSSQL\DATA\Shubhkarya.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Shubhkarya_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS02\MSSQL\DATA\Shubhkarya_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Shubhkarya] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Shubhkarya].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Shubhkarya] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Shubhkarya] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Shubhkarya] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Shubhkarya] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Shubhkarya] SET ARITHABORT OFF 
GO
ALTER DATABASE [Shubhkarya] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Shubhkarya] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Shubhkarya] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Shubhkarya] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Shubhkarya] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Shubhkarya] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Shubhkarya] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Shubhkarya] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Shubhkarya] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Shubhkarya] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Shubhkarya] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Shubhkarya] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Shubhkarya] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Shubhkarya] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Shubhkarya] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Shubhkarya] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Shubhkarya] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Shubhkarya] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Shubhkarya] SET  MULTI_USER 
GO
ALTER DATABASE [Shubhkarya] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Shubhkarya] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Shubhkarya] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Shubhkarya] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Shubhkarya] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Shubhkarya] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Shubhkarya] SET QUERY_STORE = OFF
GO
USE [Shubhkarya]
GO
/****** Object:  Table [dbo].[tblMembership]    Script Date: 03-01-2024 18:31:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMembership](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NULL,
	[SubscriptionId] [int] NULL,
	[StartDate] [datetime] NULL,
	[DueDate] [datetime] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPackage]    Script Date: 03-01-2024 18:31:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPackage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Photo] [nvarchar](50) NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[Duration] [nvarchar](56) NULL,
	[Amount] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblReg]    Script Date: 03-01-2024 18:31:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblReg](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SrNo] [nvarchar](56) NULL,
	[OnBehalf] [nvarchar](56) NULL,
	[FullName] [nvarchar](56) NULL,
	[Gender] [nvarchar](20) NULL,
	[DOB] [datetime] NULL,
	[Mobile] [nvarchar](12) NULL,
	[Email] [nvarchar](255) NULL,
	[Height] [nvarchar](56) NULL,
	[Religion] [nvarchar](100) NULL,
	[Caste] [nvarchar](100) NULL,
	[MotherTongue] [nvarchar](100) NULL,
	[Country] [nvarchar](150) NULL,
	[State] [nvarchar](250) NULL,
	[City] [nvarchar](150) NULL,
	[Address] [nvarchar](500) NULL,
	[Landmark] [nvarchar](250) NULL,
	[PinCode] [nvarchar](15) NULL,
	[Education] [nvarchar](10) NULL,
	[Profession] [nvarchar](56) NULL,
	[Income] [nvarchar](100) NULL,
	[Img] [nvarchar](100) NULL,
	[MaritalStatus] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[ConfirmPassword] [nvarchar](50) NULL,
	[BloodGroup] [nvarchar](10) NULL,
	[SkinComp] [nvarchar](50) NULL,
	[TOB] [nvarchar](50) NULL,
	[POB] [nvarchar](50) NULL,
	[Rashi] [nvarchar](50) NULL,
	[Nakshatra] [nvarchar](50) NULL,
	[SubCaste] [nvarchar](50) NULL,
	[Gotra] [nvarchar](50) NULL,
	[Manglik] [nvarchar](50) NULL,
	[College] [nvarchar](50) NULL,
	[Organization] [nvarchar](50) NULL,
	[FatherName] [nvarchar](50) NULL,
	[FatherOccupation] [nvarchar](50) NULL,
	[MotherName] [nvarchar](50) NULL,
	[MotherOccupation] [nvarchar](50) NULL,
	[TotalFamilyMember] [nvarchar](56) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Shubhkarya] SET  READ_WRITE 
GO
