USE [master]
GO
/****** Object:  Database [MyBankingAppDB]    Script Date: 26/01/2025 3:11:09 p. m. ******/
CREATE DATABASE [MyBankingAppDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyBankingAppDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MyBankingAppDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyBankingAppDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MyBankingAppDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MyBankingAppDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyBankingAppDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyBankingAppDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyBankingAppDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyBankingAppDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyBankingAppDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyBankingAppDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MyBankingAppDB] SET  MULTI_USER 
GO
ALTER DATABASE [MyBankingAppDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyBankingAppDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyBankingAppDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyBankingAppDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyBankingAppDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyBankingAppDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyBankingAppDB', N'ON'
GO
ALTER DATABASE [MyBankingAppDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [MyBankingAppDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MyBankingAppDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/01/2025 3:11:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankAccounts]    Script Date: 26/01/2025 3:11:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankAccounts](
	[BankAccountId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[AccountNumber] [nvarchar](max) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_BankAccounts] PRIMARY KEY CLUSTERED 
(
	[BankAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 26/01/2025 3:11:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 26/01/2025 3:11:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[BankAccountOriginId] [int] NULL,
	[BankAccountDestinationId] [int] NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[TransactionDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_BankAccounts_CustomerId]    Script Date: 26/01/2025 3:11:09 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_BankAccounts_CustomerId] ON [dbo].[BankAccounts]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_BankAccountDestinationId]    Script Date: 26/01/2025 3:11:09 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_BankAccountDestinationId] ON [dbo].[Transactions]
(
	[BankAccountDestinationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_BankAccountOriginId]    Script Date: 26/01/2025 3:11:09 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_BankAccountOriginId] ON [dbo].[Transactions]
(
	[BankAccountOriginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BankAccounts]  WITH CHECK ADD  CONSTRAINT [FK_BankAccounts_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BankAccounts] CHECK CONSTRAINT [FK_BankAccounts_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_BankAccounts_BankAccountDestinationId] FOREIGN KEY([BankAccountDestinationId])
REFERENCES [dbo].[BankAccounts] ([BankAccountId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_BankAccounts_BankAccountDestinationId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_BankAccounts_BankAccountOriginId] FOREIGN KEY([BankAccountOriginId])
REFERENCES [dbo].[BankAccounts] ([BankAccountId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_BankAccounts_BankAccountOriginId]
GO
USE [master]
GO
ALTER DATABASE [MyBankingAppDB] SET  READ_WRITE 
GO
