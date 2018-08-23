USE [master]
GO
/****** Object:  Database [OperationsITSM_Data]    Script Date: 2018/5/3 8:47:28 ******/
CREATE DATABASE [OperationsITSM_Data] ON  PRIMARY 
( NAME = N'OperationsITSM_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\OperationsITSM_Data.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OperationsITSM_Data_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\OperationsITSM_Data.ldf' , SIZE = 4672KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OperationsITSM_Data].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OperationsITSM_Data] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET ARITHABORT OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [OperationsITSM_Data] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OperationsITSM_Data] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OperationsITSM_Data] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OperationsITSM_Data] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OperationsITSM_Data] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OperationsITSM_Data] SET RECOVERY FULL 
GO
ALTER DATABASE [OperationsITSM_Data] SET  MULTI_USER 
GO
ALTER DATABASE [OperationsITSM_Data] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OperationsITSM_Data] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OperationsITSM_Data', N'ON'
GO
USE [OperationsITSM_Data]
GO
/****** Object:  Table [dbo].[Conf_Department]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conf_Department](
	[Id] [varchar](50) NOT NULL,
	[ParentId] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[EnCode] [varchar](50) NULL,
	[Address] [varchar](150) NULL,
	[SortCode] [int] NULL,
	[CreateTime] [datetime] NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Conf_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conf_Device]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conf_Device](
	[ID] [int] IDENTITY(100100,1) NOT NULL,
	[Label] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[TypeID] [int] NULL,
	[AffiliationDepartmentID] [int] NULL,
	[UsingDepartmentID] [int] NULL,
	[EmployeeID] [int] NULL,
	[SLAID] [int] NULL,
	[Firms] [varchar](150) NULL,
	[Models] [varchar](150) NULL,
	[AssetNumber] [varchar](150) NULL,
	[SerialNumber] [varchar](150) NULL,
	[Criticality] [int] NULL,
	[SupplierID] [int] NULL,
	[Warranty] [varchar](250) NULL,
	[BindingInfo] [varchar](2500) NULL,
	[Status] [int] NULL,
	[Description] [varchar](250) NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Conf_Device] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conf_Device_Type]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conf_Device_Type](
	[ID] [int] IDENTITY(100100,1) NOT NULL,
	[FID] [int] NULL,
	[Name] [varchar](50) NULL,
	[SortCode] [int] NULL,
	[State] [int] NULL,
 CONSTRAINT [PK_Conf_Device_Type] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conf_Employee]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conf_Employee](
	[ID] [int] IDENTITY(100100,1) NOT NULL,
	[RealName] [varchar](50) NULL,
	[EmployeeNo] [varchar](50) NULL,
	[DepartmentID] [int] NULL,
	[SLAID] [int] NULL,
	[Sex] [int] NULL,
	[Post] [varchar](250) NULL,
	[OfficeLocation] [varchar](250) NULL,
	[Telephone] [varchar](250) NULL,
	[Mobile] [varchar](250) NULL,
	[Email] [varchar](250) NULL,
	[Description] [varchar](250) NULL,
	[State] [int] NULL,
 CONSTRAINT [PK_Conf_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conf_Relations]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conf_Relations](
	[ID] [int] IDENTITY(100100,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[ForwardText] [varchar](250) NULL,
	[ReverseText] [varchar](250) NULL,
	[Description] [varchar](250) NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Conf_Relations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conf_Resource]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conf_Resource](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Label] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[TypeID] [int] NULL,
	[AffiliationDepartmentID] [int] NULL,
	[UsingDepartmentID] [int] NULL,
	[SLAID] [int] NULL,
	[Criticality] [int] NULL,
	[SupplierID] [int] NULL,
	[Warranty] [varchar](250) NULL,
	[BindingInfo] [varchar](2500) NULL,
	[Status] [int] NULL,
	[Description] [varchar](250) NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Conf_Resource] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conf_Resource_Type]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conf_Resource_Type](
	[ID] [int] IDENTITY(300090,1) NOT NULL,
	[FID] [int] NULL,
	[Name] [varchar](50) NULL,
	[SortCode] [int] NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Conf_Resource_Type] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conf_ServiceCatalog]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conf_ServiceCatalog](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Code] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Conf_ServiceCatalog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conf_Software]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conf_Software](
	[ID] [int] IDENTITY(100100,1) NOT NULL,
	[Label] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[TypeID] [int] NULL,
	[AffiliationDepartmentID] [int] NULL,
	[UsingDepartmentID] [int] NULL,
	[EmployeeID] [int] NULL,
	[SLAID] [int] NULL,
	[Version] [varchar](150) NULL,
	[UseTo] [varchar](150) NULL,
	[InstallPath] [varchar](250) NULL,
	[Criticality] [int] NULL,
	[SupplierID] [int] NULL,
	[Warranty] [varchar](250) NULL,
	[BindingInfo] [varchar](2500) NULL,
	[Status] [int] NULL,
	[Description] [varchar](250) NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Conf_Software] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conf_Software_Type]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conf_Software_Type](
	[ID] [int] IDENTITY(100100,1) NOT NULL,
	[FID] [int] NULL,
	[Name] [varchar](50) NULL,
	[SortCode] [int] NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Conf_Software_Type] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Conf_Supplier]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conf_Supplier](
	[ID] [int] IDENTITY(100100,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Telephone] [varchar](250) NULL,
	[Contact] [varchar](2500) NULL,
	[Description] [varchar](250) NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Conf_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Serv_SLA]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Serv_SLA](
	[ID] [int] IDENTITY(100100,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[MainContent] [varchar](250) NULL,
	[HourLimit] [int] NULL,
	[MinLimit] [int] NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_SYS_SLA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_Item]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_Item](
	[Id] [varchar](50) NOT NULL,
	[EnCode] [varchar](50) NULL,
	[ParentId] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Layer] [int] NULL,
	[SortCode] [int] NULL,
	[IsTree] [bit] NULL,
	[DeleteMark] [bit] NULL,
	[IsEnabled] [bit] NULL,
	[Remark] [varchar](500) NULL,
	[CreateUser] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUser] [varchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Sys_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_ItemsDetail]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_ItemsDetail](
	[Id] [varchar](50) NOT NULL,
	[ItemId] [varchar](50) NULL,
	[EnCode] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[IsDefault] [bit] NULL,
	[SortCode] [int] NULL,
	[DeleteMark] [bit] NULL,
	[IsEnabled] [bit] NULL,
	[CreateUser] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUser] [varchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Sys_ItemsDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_Log]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_Log](
	[Id] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NULL,
	[LogLevel] [varchar](50) NULL,
	[Operation] [varchar](50) NULL,
	[Message] [varchar](500) NULL,
	[Account] [varchar](50) NULL,
	[RealName] [varchar](50) NULL,
	[IP] [varchar](50) NULL,
	[IPAddress] [varchar](50) NULL,
	[Browser] [varchar](50) NULL,
	[StackTrace] [varchar](500) NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Sys_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_Permission]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_Permission](
	[Id] [varchar](50) NOT NULL,
	[ParentId] [varchar](50) NULL,
	[Layer] [int] NULL,
	[EnCode] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[JsEvent] [varchar](50) NULL,
	[Icon] [varchar](50) NULL,
	[Url] [varchar](300) NULL,
	[Remark] [varchar](500) NULL,
	[Type] [int] NULL,
	[SortCode] [int] NULL,
	[IsPublic] [bit] NULL,
	[IsEnable] [bit] NULL,
	[IsEdit] [bit] NULL,
	[DeleteMark] [bit] NULL,
	[CreateUser] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUser] [varchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Sys_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_Role]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_Role](
	[Id] [varchar](50) NOT NULL,
	[OrganizeId] [varchar](50) NULL,
	[EnCode] [varchar](50) NULL,
	[Type] [smallint] NULL,
	[Name] [varchar](50) NULL,
	[AllowEdit] [bit] NULL,
	[DeleteMark] [bit] NULL,
	[IsEnabled] [bit] NULL,
	[Remark] [varchar](500) NULL,
	[SortCode] [int] NULL,
	[CreateUser] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUser] [varchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Sys_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_RoleAuthorize]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_RoleAuthorize](
	[Id] [varchar](50) NOT NULL,
	[RoleId] [varchar](50) NULL,
	[ModuleId] [varchar](50) NULL,
	[CreateUser] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ChkState] [int] NULL,
	[SortCode] [int] NULL,
 CONSTRAINT [PK_Sys_RoleAuthorize] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_User]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_User](
	[Id] [varchar](50) NOT NULL,
	[Account] [varchar](50) NULL,
	[RealName] [varchar](50) NULL,
	[NickName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Avatar] [varchar](200) NULL,
	[Gender] [bit] NULL,
	[TelPhone] [varchar](50) NULL,
	[MobilePhone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
	[CompanyId] [varchar](50) NULL,
	[DepartmentId] [varchar](50) NULL,
	[IsEnabled] [bit] NULL,
	[IsOnLine] [bit] NULL,
	[AllowIPAddress] [varchar](50) NULL,
	[LoginCount] [int] NULL,
	[LastLoginTime] [datetime] NULL,
	[PrevLoginTime] [datetime] NULL,
	[LastLoginIP] [varchar](50) NULL,
	[SortCode] [int] NULL,
	[Theme] [varchar](50) NULL,
	[DeleteMark] [bit] NULL,
	[CreateUser] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUser] [varchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[ChkState] [int] NULL,
 CONSTRAINT [PK_Sys_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_UserLogOn]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_UserLogOn](
	[Id] [varchar](50) NOT NULL,
	[UserId] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[SecretKey] [varchar](50) NULL,
	[PrevVisitTime] [datetime] NULL,
	[LastVisitTime] [datetime] NULL,
	[ChangePwdTime] [datetime] NULL,
	[LoginCount] [int] NOT NULL,
	[AllowMultiUserOnline] [bit] NULL,
	[IsOnLine] [bit] NULL,
	[Question] [varchar](100) NULL,
	[AnswerQuestion] [varchar](200) NULL,
	[CheckIPAddress] [bit] NULL,
	[Language] [varchar](50) NULL,
	[Theme] [varchar](50) NULL,
	[ChkState] [int] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_Sys_UserLogOn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_UserRoleRelation]    Script Date: 2018/5/3 8:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_UserRoleRelation](
	[Id] [varchar](50) NOT NULL,
	[UserId] [varchar](50) NULL,
	[RoleId] [varchar](50) NULL,
	[CreateUser] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ChkState] [int] NULL,
	[SortCode] [int] NULL,
 CONSTRAINT [PK_Sys_UserRoleRelation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Conf_Department] ([Id], [ParentId], [Name], [EnCode], [Address], [SortCode], [CreateTime], [ChkState]) VALUES (N'339a409a-a5a6-49b4-9071-86d7699a9ddd', N'0', N'技术支持部', N'jishuzhichi', N'北京中关村东路1号院清华科技园8号楼9层', NULL, NULL, 1)
INSERT [dbo].[Conf_Department] ([Id], [ParentId], [Name], [EnCode], [Address], [SortCode], [CreateTime], [ChkState]) VALUES (N'3a83a048-8174-40e5-b24e-946db686b77e', N'0', N'运维业务部', N'yunwei', N'北京中关村东路1号院清华科技园8号楼9层', NULL, NULL, 1)
INSERT [dbo].[Conf_Department] ([Id], [ParentId], [Name], [EnCode], [Address], [SortCode], [CreateTime], [ChkState]) VALUES (N'5dbb4cd8-5e6c-4b7d-b266-4b14e6f20869', N'0', N'集成业务部', N'jicheng', N'北京中关村东路1号院清华科技园8号楼9层', NULL, NULL, 1)
INSERT [dbo].[Conf_Department] ([Id], [ParentId], [Name], [EnCode], [Address], [SortCode], [CreateTime], [ChkState]) VALUES (N'a93c66e2-b8dc-4d00-84ed-e6071b5f5318', N'0', N'客户服务部', N'kefu', N'北京中关村东路1号院清华科技园8号楼16层', NULL, NULL, 1)
INSERT [dbo].[Conf_Department] ([Id], [ParentId], [Name], [EnCode], [Address], [SortCode], [CreateTime], [ChkState]) VALUES (N'c5b73457-98e1-484d-919b-d979b1c70cd1', N'0', N'资产管理部', N'zichan', N'北京中关村东路1号院清华科技园8号楼28层', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Conf_Device_Type] ON 

INSERT [dbo].[Conf_Device_Type] ([ID], [FID], [Name], [SortCode], [State]) VALUES (100090, NULL, N'服务器', NULL, NULL)
INSERT [dbo].[Conf_Device_Type] ([ID], [FID], [Name], [SortCode], [State]) VALUES (100091, NULL, N'复印机', NULL, NULL)
INSERT [dbo].[Conf_Device_Type] ([ID], [FID], [Name], [SortCode], [State]) VALUES (100092, NULL, N'打印机', NULL, NULL)
INSERT [dbo].[Conf_Device_Type] ([ID], [FID], [Name], [SortCode], [State]) VALUES (100093, NULL, N'网络设备', NULL, NULL)
INSERT [dbo].[Conf_Device_Type] ([ID], [FID], [Name], [SortCode], [State]) VALUES (100094, NULL, N'台式机', NULL, NULL)
INSERT [dbo].[Conf_Device_Type] ([ID], [FID], [Name], [SortCode], [State]) VALUES (100095, NULL, N'笔记本', NULL, NULL)
INSERT [dbo].[Conf_Device_Type] ([ID], [FID], [Name], [SortCode], [State]) VALUES (100096, NULL, N'路由器', NULL, NULL)
INSERT [dbo].[Conf_Device_Type] ([ID], [FID], [Name], [SortCode], [State]) VALUES (100097, NULL, N'小型机', NULL, NULL)
INSERT [dbo].[Conf_Device_Type] ([ID], [FID], [Name], [SortCode], [State]) VALUES (100098, NULL, N'防火墙', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Conf_Device_Type] OFF
SET IDENTITY_INSERT [dbo].[Conf_Relations] ON 

INSERT [dbo].[Conf_Relations] ([ID], [Name], [ForwardText], [ReverseText], [Description], [ChkState]) VALUES (1, N'安装与运行关系', N'安装着#', N'运行在#上', N'适用于下面情况：1、服务器、台式机、笔记本、虚拟机跟业务系统、操作系统、数据库之间的关系', NULL)
INSERT [dbo].[Conf_Relations] ([ID], [Name], [ForwardText], [ReverseText], [Description], [ChkState]) VALUES (2, N'包含关系', N'包含#', N'是组成#的一部分', N'适用于下面情况：1、应用系统跟数据库之间的关系2、设备板卡与设备之间的关系', NULL)
SET IDENTITY_INSERT [dbo].[Conf_Relations] OFF
SET IDENTITY_INSERT [dbo].[Conf_Software_Type] ON 

INSERT [dbo].[Conf_Software_Type] ([ID], [FID], [Name], [SortCode], [ChkState]) VALUES (200090, NULL, N'操作系统', NULL, NULL)
INSERT [dbo].[Conf_Software_Type] ([ID], [FID], [Name], [SortCode], [ChkState]) VALUES (200091, NULL, N'数据库', NULL, NULL)
INSERT [dbo].[Conf_Software_Type] ([ID], [FID], [Name], [SortCode], [ChkState]) VALUES (200092, NULL, N'中间件', NULL, NULL)
INSERT [dbo].[Conf_Software_Type] ([ID], [FID], [Name], [SortCode], [ChkState]) VALUES (200093, NULL, N'业务软件', NULL, NULL)
INSERT [dbo].[Conf_Software_Type] ([ID], [FID], [Name], [SortCode], [ChkState]) VALUES (200094, NULL, N'办公软件', NULL, NULL)
INSERT [dbo].[Conf_Software_Type] ([ID], [FID], [Name], [SortCode], [ChkState]) VALUES (200095, NULL, N'Vmware', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Conf_Software_Type] OFF
INSERT [dbo].[Sys_Item] ([Id], [EnCode], [ParentId], [Name], [Layer], [SortCode], [IsTree], [DeleteMark], [IsEnabled], [Remark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'0e9a3b52-1cfc-41a4-8f6d-3ed8b321aecf', N'xueli', N'8238c495-8376-4004-9a34-56d0dcbd11ea', N'学历', 1, 3, NULL, 0, 1, NULL, NULL, NULL, N'admin', CAST(0x0000A772013D11F0 AS DateTime), NULL)
INSERT [dbo].[Sys_Item] ([Id], [EnCode], [ParentId], [Name], [Layer], [SortCode], [IsTree], [DeleteMark], [IsEnabled], [Remark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'7b247f60-4095-4ffe-96e0-1935a25852de', N'hunyin', N'8238c495-8376-4004-9a34-56d0dcbd11ea', N'婚姻', 1, 4, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Item] ([Id], [EnCode], [ParentId], [Name], [Layer], [SortCode], [IsTree], [DeleteMark], [IsEnabled], [Remark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'8238c495-8376-4004-9a34-56d0dcbd11ea', N'all_items', N'0', N'数据字典', 0, 0, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Item] ([Id], [EnCode], [ParentId], [Name], [Layer], [SortCode], [IsTree], [DeleteMark], [IsEnabled], [Remark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'9c51a17c-7afd-4986-bfc9-94f9dd818ecf', N'role_type', N'8238c495-8376-4004-9a34-56d0dcbd11ea', N'角色类型', 1, 1, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Item] ([Id], [EnCode], [ParentId], [Name], [Layer], [SortCode], [IsTree], [DeleteMark], [IsEnabled], [Remark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'd2f966ba-d541-4ac9-8837-b5303d5c3502', N'org_type', N'8238c495-8376-4004-9a34-56d0dcbd11ea', N'机构类型', 1, 2, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'14f0c64a-f3d8-439d-bc0a-d9a5a41a2d46', N'd2f966ba-d541-4ac9-8837-b5303d5c3502', N'org-team', N'小组', 0, 4, 0, 1, NULL, NULL, N'admin', CAST(0x0000A7AE00B57D7D AS DateTime), NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'16c3d367-d63e-4426-9745-ed6824e8454d', N'0e9a3b52-1cfc-41a4-8f6d-3ed8b321aecf', N'shuoshi', N'硕士', 0, 7, 0, 1, N'admin', CAST(0x0000A764011560CF AS DateTime), N'admin', CAST(0x0000A764011560CF AS DateTime), NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'557427ff-8bb7-4e8b-ba3d-91f31ab02b59', N'0e9a3b52-1cfc-41a4-8f6d-3ed8b321aecf', N'xiaoxue', N'小学及以下', 0, 1, 0, 1, N'admin', CAST(0x0000A7640113EA13 AS DateTime), N'admin', CAST(0x0000A76401157A3A AS DateTime), NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'738aee95-3597-412e-9a0a-e7e3161c86cf', N'9c51a17c-7afd-4986-bfc9-94f9dd818ecf', N'role-business', N'业务角色', 1, 2, 0, 1, NULL, NULL, N'admin', CAST(0x0000A7870122D19B AS DateTime), NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'7c51742f-fed3-48c4-8c5b-7f8b8c64cff0', N'0e9a3b52-1cfc-41a4-8f6d-3ed8b321aecf', N'benke', N'本科', 1, 5, 0, 1, N'admin', CAST(0x0000A76401146AA8 AS DateTime), N'admin', CAST(0x0000A764011585F5 AS DateTime), NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'85d02da8-06f2-4fba-9dcf-7e3b971f9028', N'd2f966ba-d541-4ac9-8837-b5303d5c3502', N'org-company', N'公司', 1, 1, 0, 1, NULL, NULL, N'admin', CAST(0x0000A78701232859 AS DateTime), NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'85e46a33-b065-4ba2-99da-c02947bfc5e6', N'd2f966ba-d541-4ac9-8837-b5303d5c3502', N'org-department', N'部门', 0, 2, 0, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'ac53424f-adbb-4477-b534-b0bc72ea5f41', N'0e9a3b52-1cfc-41a4-8f6d-3ed8b321aecf', N'chuzhong', N'初中', 0, 2, 0, 1, N'admin', CAST(0x0000A764011403ED AS DateTime), N'admin', CAST(0x0000A764011403ED AS DateTime), NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'C52CBE29-CB92-465F-9697-2AAB7C214FFD', N'd2f966ba-d541-4ac9-8837-b5303d5c3502', N'org-child-dept', N'子部门', 0, 3, 0, 1, N'admin', CAST(0x0000A7AE00B575E8 AS DateTime), N'admin', CAST(0x0000A7AE00B575E8 AS DateTime), NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'cb579de4-b816-435f-aaa5-f666a6838ca5', N'9c51a17c-7afd-4986-bfc9-94f9dd818ecf', N'role-system', N'系统角色', 0, 1, 0, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'cf5d4197-678f-47b9-8f35-ffc23ba68cee', N'9c51a17c-7afd-4986-bfc9-94f9dd818ecf', N'role-other', N'其他角色', 0, 3, 0, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'd327c3ca-a557-4f95-8bbf-659fcf09782d', N'0e9a3b52-1cfc-41a4-8f6d-3ed8b321aecf', N'dazhuan', N'大专', 0, 4, 0, 1, N'admin', CAST(0x0000A76401142837 AS DateTime), N'admin', CAST(0x0000A76401142837 AS DateTime), NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'f500ed63-e91a-40a5-8e80-6b58895007d3', N'0e9a3b52-1cfc-41a4-8f6d-3ed8b321aecf', N'yanjiusheng', N'研究生', 0, 6, 0, 1, N'admin', CAST(0x0000A76401148410 AS DateTime), N'admin', CAST(0x0000A76401148410 AS DateTime), NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'f51b746e-476a-4e39-839f-abed4be676cf', N'0e9a3b52-1cfc-41a4-8f6d-3ed8b321aecf', N'gaozhong', N'高中', 0, 3, 0, 1, N'admin', CAST(0x0000A76401140FDE AS DateTime), N'admin', CAST(0x0000A76401140FDE AS DateTime), NULL)
INSERT [dbo].[Sys_ItemsDetail] ([Id], [ItemId], [EnCode], [Name], [IsDefault], [SortCode], [DeleteMark], [IsEnabled], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'fff309f2-9baa-4283-84a8-74c97fcd83e2', N'0e9a3b52-1cfc-41a4-8f6d-3ed8b321aecf', N'boshi', N'博士', 0, 8, 0, 0, N'admin', CAST(0x0000A76401157360 AS DateTime), N'admin', CAST(0x0000A78901311729 AS DateTime), NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'003aa53e-cd6c-49b5-86f2-2cfef6939250', CAST(0x0000A8170170E4A4 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'030b0748-5ab9-4b2a-838d-6f924b3425bd', CAST(0x0000A8190102DC0D AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'04d50026-ca18-4576-abd2-bd4aac1c210c', CAST(0x0000A817017667CB AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'098fe3a0-e3bd-4f55-bc61-b5424aa6bb94', CAST(0x0000A81801711B29 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.3', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'0adeb639-f408-4f29-b18c-54450c366cd3', CAST(0x0000A81700F58DD1 AS DateTime), N'ERROR', N'系统登录', N'列名 ''RoleId'' 无效。', N'', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'0bda59a5-a4e9-4c1c-a573-a2e14532f175', CAST(0x0000A818014D6884 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'102fdf45-7ac4-4e2e-8f17-510cce98b3d6', CAST(0x0000A8170167B906 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'1c7d5e69-62f2-4670-b83a-d1dbec9aa2c6', CAST(0x0000A817014430F6 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'1cdcb94f-c37b-4a23-89a8-88efa456b8ab', CAST(0x0000A817016452E3 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'23c8c079-8aaf-4ce7-b1d5-6b3f361e5383', CAST(0x0000A81700F10958 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'27b3edf9-24c7-4f73-94c9-1bc70e78e0c7', CAST(0x0000A81700E7F76C AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'2a5e8143-d0b1-4874-a253-3028ced33894', CAST(0x0000A81701484185 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'2b852d82-dba5-45d1-8ca7-87bed6baa25f', CAST(0x0000A8170100E5DE AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'2d3101f2-a37b-4bd7-b531-4f7abce1ddbe', CAST(0x0000A818017BC789 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.3', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'3228bf1c-f815-41d2-bcc8-46ea820c49c7', CAST(0x0000A8170175DC3B AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'352a1b9e-45d6-4063-a912-ce532de491be', CAST(0x0000A8170167E21E AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'38097061-6749-4963-ae35-96d08ae8fcf5', CAST(0x0000A8170166258E AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'38170733-58ff-472c-a9de-06e68bd94e0f', CAST(0x0000A81700F58722 AS DateTime), N'ERROR', N'系统登录', N'列名 ''RoleId'' 无效。', N'', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'410e83ca-c42c-403e-84cf-4ecb9bfec20f', CAST(0x0000A81801796B83 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.3', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'44b0c8f3-52b2-4917-897d-60b6e82becb7', CAST(0x0000A817014D5B4E AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'4546859c-88fa-49ca-a687-e89d23ff781d', CAST(0x0000A81701666D81 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'4e41e938-3e99-4147-8a73-96e16c6edc2c', CAST(0x0000A8170116B730 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'4ec49e06-0b79-4b6b-90a0-24ac1a1aaefc', CAST(0x0000A8170149B509 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'53107017-bc00-44a4-afd4-b7dc0c07a7a4', CAST(0x0000A81701678277 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'555a9404-8882-456f-861a-5ea06ae5019d', CAST(0x0000A81701674A39 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'56e12050-d3f8-4f8e-b2e9-bff23f4a0964', CAST(0x0000A81700E56C06 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'6cbb8044-c9a5-410c-b219-00d7f0312c6a', CAST(0x0000A8190093AE59 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'6ec1b0d5-4239-4713-8750-45a5bbb75ce4', CAST(0x0000A817017111D4 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'71db4d52-481b-4ad1-abf7-758923aad028', CAST(0x0000A81900C6370A AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'71e1e59d-0b90-4bfb-9539-0d4a366d05d7', CAST(0x0000A81700DE6047 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'76116993-16ee-4f42-aa2c-e2cfbd3f27c1', CAST(0x0000A817016B4581 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'7a587225-ff54-4285-a93f-ef9c3a62dc79', CAST(0x0000A817016C2DB8 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'80812cbc-6eae-48da-8270-639059b48203', CAST(0x0000A81700E2F5A6 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'8125e6d3-36e9-4b5e-afe9-59b6414e983c', CAST(0x0000A81900DBA690 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'8300abbf-417e-4799-a946-ad99e554bb08', CAST(0x0000A8180144E8DF AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'88ba3ec7-4394-432d-9612-b6ce97ffbbde', CAST(0x0000A81900DC5C16 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'934b0674-d4a2-4dc9-b89c-92b98b0ad54d', CAST(0x0000A817014E57E4 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'98d217f9-0316-4504-8026-07a415d05fb3', CAST(0x0000A81900DCD900 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'9e53ef77-9c78-4017-a77c-967df5833052', CAST(0x0000A8170145175D AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'9ea0ea12-0107-468c-8ad0-1c191ee79af6', CAST(0x0000A81701433CE1 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'9f709d0f-94ae-439e-ba25-a082f351e95f', CAST(0x0000A81700E39357 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'9fca3742-8fca-4cff-8ac7-b55b2ffadfa8', CAST(0x0000A8190107F514 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'a0906123-b6fc-48af-816e-4b277fcc44ea', CAST(0x0000A81700D9296E AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'a23bd3fb-7fd7-4e58-9f79-2ed3e8f97fc3', CAST(0x0000A81900E8DDE8 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'a36a77ae-118a-4327-9f7c-ea1041f6bdf6', CAST(0x0000A8170165D4B9 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'a49d4ab7-372a-45e1-b4fa-8a3b7b848b3f', CAST(0x0000A8170154C0CF AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'a54abfbb-99d4-400f-97d0-d7ac041c7736', CAST(0x0000A81700F55E9E AS DateTime), N'ERROR', N'系统登录', N'列名 ''RoleId'' 无效。', N'', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'b7e8e037-ac11-48a8-beec-4e6182eec372', CAST(0x0000A8170176C6DB AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'c08d2f3c-c876-4108-804e-cc1e77a0befb', CAST(0x0000A81700DCDDD2 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'c82db101-369c-45e4-95bc-06f0893ac426', CAST(0x0000A8190143A953 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'101.4.63.166', N'中国 北京市 北京市', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'cde53b5e-c423-49ea-ad3d-9d9ef814e420', CAST(0x0000A81701604486 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'db1dd84a-19a2-4902-a426-acce2e5035cb', CAST(0x0000A81900F9CAB3 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'dcf18f1f-d9f8-4990-ba8d-9dbe78e952ab', CAST(0x0000A818016EF9DD AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.3', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'dcf3d084-3991-4b6c-bf31-0ec68c18c256', CAST(0x0000A81701658E97 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'e45af320-5fa2-485d-a8aa-d553402e1bc7', CAST(0x0000A81700DE230C AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'e4a8fed3-71a0-4fcf-be61-3cd990a810b4', CAST(0x0000A817016B6F48 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'e507df7a-dd99-4058-b0b6-e3143b93ee86', CAST(0x0000A81700D8B087 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'e762d818-0df9-4fb3-8771-225c0a5a510f', CAST(0x0000A817014D1743 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'e836bf78-41ee-410d-a3e8-e12d5df3f616', CAST(0x0000A81701540C9E AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'e96fe29a-c2aa-49a8-87d9-0bbc91b9f265', CAST(0x0000A81801678A18 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'f12ebda9-dfed-46d2-8ec9-f20bee5df06d', CAST(0x0000A817014A45D1 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'f2288580-0554-4ff8-a33f-fbe1da3df80b', CAST(0x0000A81700D7D3E8 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'f2e542bb-5248-4ebe-9242-952838faeca1', CAST(0x0000A81900A2199C AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'f6b2f634-86bb-47b2-87ee-7ebbf9a814f4', CAST(0x0000A817010625ED AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'fb82af44-d263-4eb9-92e6-c709c67e2e5f', CAST(0x0000A8170106C0CC AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'127.0.0.1', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Log] ([Id], [CreateTime], [LogLevel], [Operation], [Message], [Account], [RealName], [IP], [IPAddress], [Browser], [StackTrace], [ChkState]) VALUES (N'ff01fb88-aa20-4712-ba66-49a7968c33b7', CAST(0x0000A8170166D099 AS DateTime), N'INFO', N'系统登录', N'登录成功', N'admin', N'', N'192.168.1.6', N'内网IP  ', N'Firefox 56.0', N'<no type>.lambda_method => HomeController.CheckLogin => LogHelper.Write', NULL)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'026550fd-2578-42ae-a041-625cda12325f', N'855f3590-b233-4224-aaff-47fb95c8353d', 2, N'role-add', N'新增角色', N'btn_add()', N'
fa fa-plus-square-o', N'/System/Role/Form', NULL, 1, 10301, 0, 1, 1, 0, N'admin', CAST(0x0000A7440110024F AS DateTime), N'admin', CAST(0x0000A7440110024F AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'047A418D-BC7F-4BF6-BCDB-2214091B7764', N'0', 0, NULL, N'统计分析', NULL, N'fa fa-book', NULL, NULL, 0, 10010, 0, 1, 1, 0, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'069f00f6-2a82-4bbe-90d6-418f37d5ef1f', N'3c69e3fb-e1fe-4911-8417-6f6d55a1ce72', 2, N'item-detail', N'查看选项', N'btn_detail()', N'fa fa-eye', N'/System/ItemsDetail/Detail', NULL, 1, 10505, 0, 1, 1, 0, N'admin', CAST(0x0000A74B014DFEC0 AS DateTime), N'admin', CAST(0x0000A74B014E9876 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'086ee328-5a15-40b0-8e15-291093e2e8b1', N'10a708fc-9e0d-45c6-9247-cef0c5f506ec', 1, N'faq-manage', N'问答管理', N'btn_edit()', N'fa fa-pencil-square-o', N'/System/Organize/Form', NULL, 0, 10402, 0, 1, 1, 0, N'admin', CAST(0x0000A749009EE684 AS DateTime), N'admin', CAST(0x0000A749009EE684 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'09157352-1252-4964-8fee-479759a95db8', N'277c8647-ea81-42cf-8f7b-db353da95bbe', 1, N'department-manage', N'部门管理', N'btn_edit()', N'fa fa-building', N'/Manage/Department/Index', NULL, 0, 10400, 0, 1, 1, 0, N'admin', CAST(0x0000A749009CD589 AS DateTime), N'admin', CAST(0x0000A74901140F67 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'0d2ea3c9-5b29-4bb6-9f91-0322419ded8e', N'e5346fa2-76ec-498f-8f54-3b443959335a', 2, N'per-delete', N'删除权限', N'btn_delete()', N'fa fa-trash-o', N'/System/Permission/Delete', NULL, 1, 10100, 0, 1, 1, 0, N'admin', CAST(0x0000A72000A26898 AS DateTime), N'admin', NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'0EED8CA8-B499-4482-8839-47BF07C91EEB', N'e5346fa2-76ec-498f-8f54-3b443959335a', 2, NULL, N'修改权限', N'btn_edit()', N'fa fa-trash-o', N'/Manage/Permission/Form', NULL, 1, 10200, 0, 1, 1, 0, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'10a708fc-9e0d-45c6-9247-cef0c5f506ec', N'0', 0, N'knowledge-base', N'知识库', NULL, N'fa fa-book', NULL, NULL, 0, 10200, 0, 1, 1, 0, N'admin', NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'216d09a8-575f-43d1-85f6-acc025fa94b3', N'6d90439c-eb6b-4521-ab4d-5e481406a861', 2, N'user-detail', N'查看用户', N'btn_detail()', N'fa fa-eye', N'/System/User/Detail', NULL, 1, 10104, 0, 1, 1, 0, N'admin', CAST(0x0000A744010D3F25 AS DateTime), N'admin', CAST(0x0000A744010D3F25 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'233e50fd-4860-42f9-aa7a-93853ac0434b', N'277c8647-ea81-42cf-8f7b-db353da95bbe', 1, N'data-backup', N'数据备份', N'btn_edit()', N'fa fa-list', N'/System/Data/Index', NULL, 0, 20100, 0, 1, 1, 0, N'admin', NULL, N'admin', CAST(0x0000A7AE00B2C601 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'277c8647-ea81-42cf-8f7b-db353da95bbe', N'0', 0, N'sys-config', N'配置管理', NULL, N'fa fa-wrench', NULL, NULL, 0, 20000, 0, 1, 1, 0, N'admin', NULL, N'admin', NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'28a045a6-61f4-4784-8578-837ad307e4e3', N'0', 0, N'per-add', N'辅助工具', NULL, N'
fa fa-info-circle', NULL, NULL, 0, 10001, 0, 1, 1, 0, N'admin', CAST(0x0000A71900EE80D0 AS DateTime), N'admin', NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'2c24cdfc-8f26-4947-bcb2-0cb4d9111e80', N'2d0b02db-09f7-4404-bbdd-c8a516f48288', 1, N'per-detail', N'查看权限', N'btn_detail()', N'fa fa-eye', N'/System/Permission/Detail', NULL, 1, 10204, 0, 1, 1, 0, N'admin', CAST(0x0000A744010DBD6D AS DateTime), N'admin', CAST(0x0000A744010DBD6D AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'2d0b02db-09f7-4404-bbdd-c8a516f48288', N'0', 0, N'sys-manage', N'系统管理', NULL, N'fa fa-cog', NULL, NULL, 0, 10002, 0, 1, 1, 0, N'admin', NULL, N'admin', NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'328b5383-79be-4b34-b57a-49fa3ebc7803', N'855f3590-b233-4224-aaff-47fb95c8353d', 2, N'role-delete', N'删除角色', N'btn_delete()', N'fa fa-trash-o', N'/System/Role/Delete', NULL, 1, 10303, 0, 1, 1, 0, N'admin', CAST(0x0000A7440110A904 AS DateTime), N'admin', CAST(0x0000A7440110A904 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'3c69e3fb-e1fe-4911-8417-6f6d55a1ce72', N'2d0b02db-09f7-4404-bbdd-c8a516f48288', 1, N'lay-item', N'数据字典', N'btn_edit()', N'fa fa-file', N'/System/ItemsDetail/Index', NULL, 0, 10500, 0, 1, 1, 0, N'admin', CAST(0x0000A74A01004498 AS DateTime), N'admin', CAST(0x0000A74A01004498 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'3de13971-a51f-40f7-be40-eb035b7f0fae', N'6d90439c-eb6b-4521-ab4d-5e481406a861', 2, N'user-edit', N'修改用户', N'btn_edit()', N'fa fa-edit', N'/System/User/Edit', NULL, 1, 10102, 0, 1, 1, 0, N'admin', CAST(0x0000A755011E1E60 AS DateTime), N'admin', CAST(0x0000A78900B203D1 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'40B0E063-73F0-4D19-980B-49A52CA4DACF', N'0', 0, NULL, N'事件管理', NULL, N'fa fa-book', NULL, NULL, 0, 40000, 0, 1, 1, 0, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'46F30513-824B-48A4-A058-EBDBF341C9CE', N'28a045a6-61f4-4784-8578-837ad307e4e3', 1, N'mail-conf', N'邮箱配置', N'btn_edit()', N'fa fa-envelope', N'/System/Organize/Delete', NULL, 0, 10000, 0, 1, 1, 0, N'admin', NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'564684B4-B653-4918-92A0-5EDF662F0735', N'0', 0, NULL, N'问题管理', NULL, N'fa fa-envelope', NULL, NULL, 0, 30000, 0, 1, 1, 0, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'5fe0cee6-0452-493d-9b55-ff23a5da5e2d', N'e5346fa2-76ec-498f-8f54-3b443959335a', 2, N'per-edit', N'列表导出', N'btn_export()', N'fa fa-file-excel-o', N'/Manage/Permission/SaveFormww', NULL, 1, 10000, 0, 1, 1, 0, N'admin', CAST(0x0000A72000A14FC0 AS DateTime), N'admin', NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'625cf550-4aad-4158-aff4-2a63d4f25819', N'855f3590-b233-4224-aaff-47fb95c8353d', 2, N'role-detail', N'查看角色', N'btn_detail()', N'fa fa-eye', N'/System/Role/Detail', NULL, 1, 10304, 0, 1, 1, 0, N'admin', CAST(0x0000A74401110894 AS DateTime), N'admin', CAST(0x0000A74401110894 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'6d90439c-eb6b-4521-ab4d-5e481406a861', N'2d0b02db-09f7-4404-bbdd-c8a516f48288', 1, N'sys-user', N'系统用户', N'btn_edit()', N'fa fa-user-circle', N'/Manage/User/Index', NULL, 0, 10100, 0, 1, 1, 0, N'admin', NULL, N'admin', CAST(0x0000A78D010D8B48 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'752c9d3f-a744-42ba-87a2-79849fc3fc66', N'6d90439c-eb6b-4521-ab4d-5e481406a861', 2, N'user-delete', N'删除用户', N'btn_delete()', N'fa fa-trash-o', N'/System/User/Delete', NULL, 1, 10103, 0, 1, 1, 0, N'admin', CAST(0x0000A744010CBB54 AS DateTime), N'admin', CAST(0x0000A744010CBB54 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'7ae2e6aa-0433-4eaa-9357-1adec2507345', N'aeeb56d1-5f27-42df-9d34-97ac18078390', 2, N'log-delete', N'删除日志', N'btn_delete()', N'fa fa-trash-o', N'/System/Log/Delete', NULL, 1, 10601, 0, 1, 0, 0, N'admin', CAST(0x0000A75A00DC2793 AS DateTime), N'admin', CAST(0x0000A75A00DC7022 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'81d1cbf0-3cff-4cde-8128-7d0d844450de', N'855f3590-b233-4224-aaff-47fb95c8353d', 2, N'role-authorize', N'角色授权', N'btn_authorize()', N'fa fa-hand-pointer-o', N'/Manage/RoleAuthorize/Index', NULL, 1, 10305, 0, 1, 1, 0, N'admin', CAST(0x0000A7440111C130 AS DateTime), N'admin', CAST(0x0000A7440111C130 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'82b06e80-103e-4a38-b171-740d2b0e194b', N'10a708fc-9e0d-45c6-9247-cef0c5f506ec', 1, N'knowledge-search', N'知识检索', N'btn_add()', N'fa fa-search', N'/System/Organize/Form', NULL, 0, 10401, 0, 1, 1, 0, N'admin', CAST(0x0000A749009EB272 AS DateTime), N'admin', CAST(0x0000A749009EB272 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'85438f3b-0634-4b17-b778-aee3a5819669', N'855f3590-b233-4224-aaff-47fb95c8353d', 2, N'role-edit', N'修改角色', N'btn_edit()', N'fa fa-pencil-square-o', N'/System/Role/Form', NULL, 1, 10302, 0, 1, 1, 0, N'admin', CAST(0x0000A74401103C49 AS DateTime), N'admin', CAST(0x0000A74401103C49 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'855f3590-b233-4224-aaff-47fb95c8353d', N'2d0b02db-09f7-4404-bbdd-c8a516f48288', 1, N'sys-role', N'角色管理', N'btn_edit()', N'fa fa-check-square-o', N'/Manage/Role/Index', NULL, 0, 10300, 0, 1, 1, 0, N'admin', CAST(0x0000A744010F513F AS DateTime), N'admin', CAST(0x0000A7440116C5E9 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'87f0aa68-fa57-43cb-84d0-e979fc4af24c', N'b971f57e-d11f-409b-92ec-c76e98bbc7b1', 1, N'item-delete', N'服务请求', N'btn_delete()', N'fa fa-trash-o', N'/System/ItemsDetail/Delete', NULL, 0, 10504, 0, 1, 1, 0, N'admin', CAST(0x0000A74B014B659A AS DateTime), N'admin', CAST(0x0000A74B014E6459 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'8a7c09e3-ad4e-467a-b10d-a3823eeafacf', N'e5346fa2-76ec-498f-8f54-3b443959335a', NULL, N'skk111', N'分配', N'brt()', N'fa fa-pause-circle', N'得到的', NULL, 1, 10080, 0, 1, 0, 0, N'admin', CAST(0x0000A819009D5605 AS DateTime), N'admin', CAST(0x0000A819009D5605 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'aeeb56d1-5f27-42df-9d34-97ac18078390', N'2d0b02db-09f7-4404-bbdd-c8a516f48288', 1, N'sys-log', N'操作日志', N'btn_edit()', N'fa fa-file-text-o', N'/System/Log/Index', NULL, 0, 10600, 0, 1, 0, 0, N'admin', CAST(0x0000A75900DD5376 AS DateTime), N'admin', CAST(0x0000A75A00DC57BD AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'b971f57e-d11f-409b-92ec-c76e98bbc7b1', N'0', 0, N'my-work', N'服务台', NULL, N'fa fa-phone-square', NULL, NULL, 0, 60000, 0, 1, 1, 0, N'admin', NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'BE385E6A-0942-4112-9FAB-B0DC66196F81', N'e5346fa2-76ec-498f-8f54-3b443959335a', 2, NULL, N'新增权限', N'btn_add()', N'fa fa-hand-pointer-o', N'/Manage/Permission/Form', NULL, 1, 10300, 0, 1, 1, 0, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'c04bfd8f-7e2e-4312-9148-a2e14007fa46', N'b971f57e-d11f-409b-92ec-c76e98bbc7b1', 1, N'item-edit', N'待处理事件', N'btn_edit()', N'fa fa-pencil-square-o', N'/System/ItemsDetail/Form', NULL, 0, 10503, 0, 1, 1, 0, N'admin', CAST(0x0000A74B014B211D AS DateTime), N'admin', CAST(0x0000A74B014B211D AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'CF0A7A27-3EB9-4C65-BE66-4C0D730999DD', N'6d90439c-eb6b-4521-ab4d-5e481406a861', 2, NULL, N'导出用户', N'btn_excel()', N'fa fa-file-excel-o', N'/System/User/Edit', NULL, 1, 10010, 0, 1, 1, 0, N'admin', NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'd9cfc79d-55f6-4890-b604-49f1d2a0d971', N'6d90439c-eb6b-4521-ab4d-5e481406a861', 2, N'user-add', N'新增用户', N'btn_add()', N'
fa fa-plus-square-o', N'/System/User/Form', NULL, 1, 10101, 0, 1, 1, 0, N'admin', CAST(0x0000A744010BC872 AS DateTime), N'admin', CAST(0x0000A744010BC872 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'DD5D595F-9964-4941-A872-28694FD22FE2', N'0', 0, NULL, N'周报管理', NULL, N'fa fa-book', NULL, NULL, 0, 10020, 0, 1, 1, 0, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'e32b7507-aaf0-42dc-8008-139250c352ee', N'3c69e3fb-e1fe-4911-8417-6f6d55a1ce72', 2, N'item-manage', N'字典管理', N'btn_manage()', N'fa fa-folder-open-o', N'/System/Item/Index', NULL, 1, 10501, 0, 1, 1, 0, N'admin', CAST(0x0000A74A01629016 AS DateTime), N'admin', CAST(0x0000A74B00B23855 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'e5346fa2-76ec-498f-8f54-3b443959335a', N'2d0b02db-09f7-4404-bbdd-c8a516f48288', 1, N'sys-permission', N'权限管理', N'btn_edit()', N'fa fa-suitcase', N'/Manage/Permission/Index', NULL, 0, 10200, 0, 1, 1, 0, N'admin', NULL, N'admin', CAST(0x0000A7440117D593 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'e9478f45-0c00-435f-9a7a-35c7af1f86f7', N'10a708fc-9e0d-45c6-9247-cef0c5f506ec', 1, N'knowledge-manage', N'知识管理', N'btn_delete()', N'fa fa-check-circle', N'/System/Organize/Delete', NULL, 0, 10403, 0, 1, 1, 0, N'admin', CAST(0x0000A74900A0EE27 AS DateTime), N'admin', CAST(0x0000A74900A0EE27 AS DateTime), 1)
INSERT [dbo].[Sys_Permission] ([Id], [ParentId], [Layer], [EnCode], [Name], [JsEvent], [Icon], [Url], [Remark], [Type], [SortCode], [IsPublic], [IsEnable], [IsEdit], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'fbee5749-8694-495f-b140-b5b3399df7ee', N'3c69e3fb-e1fe-4911-8417-6f6d55a1ce72', 2, N'item-add', N'新增选项', N'btn_add()', N'fa fa-plus-square-o', N'/System/ItemsDetail/Form', NULL, 1, 10502, 0, 1, 1, 0, N'admin', CAST(0x0000A74B0145D3FE AS DateTime), N'admin', CAST(0x0000A74B0145F9FB AS DateTime), 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'287C73A0-4A42-401B-8D39-F494856ABFEF', NULL, NULL, NULL, N'事件经理', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'2E872862-B35B-4CB8-93BF-ECA7B6DE2FB8', NULL, NULL, NULL, N'资产配置管理员', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'34C8228F-00A8-49FF-AEA0-27F6E3DC9FC0', NULL, NULL, NULL, N'公告管理员', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'4058B7BE-5C32-4F0B-A266-35BA421A5CB6', NULL, NULL, NULL, N'运维客服', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'4DDCACCB-5FB0-4700-9527-B8B02B82B44A', NULL, NULL, NULL, N'一线工程师', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'55440eec-5622-491b-9ade-879dae179c23', N'67ccf447-0f20-4cf8-9159-a5552cf7dc10', N'implement', 1, N'实施人员', 1, 0, 0, NULL, 5, N'admin', NULL, N'admin', CAST(0x0000A789012146BB AS DateTime), 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'64A02D82-22E3-483C-AE4A-FEAC90289CBC', NULL, NULL, NULL, N'问题经理', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'745CEAE9-A967-48F5-8501-42F434DFC513', NULL, NULL, NULL, N'一般人员', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'78516ecc-e0ad-4f7a-a107-6a4a4ebe64a7', N'771b628b-e43c-4592-b1ef-70ea23b0e3f2', N'developer', 0, N'运维主管', 0, 0, 1, NULL, 3, N'admin', NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'857ABB81-DD3D-4AE9-8507-EEAB4D1F50DA', NULL, NULL, NULL, N'服务台经理', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'97223b06-6b7a-47fb-b74c-173f52c519c4', NULL, N'fileattache', 1, N'运维工程师', 1, 0, 1, NULL, 70, N'admin', CAST(0x0000A735010A1FF8 AS DateTime), N'admin', CAST(0x0000A81801713223 AS DateTime), 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'771b628b-e43c-4592-b1ef-70ea23b0e3f2', N'administrators', 0, N'超级管理员', 1, 0, 1, NULL, 1, N'admin', NULL, N'admin', CAST(0x0000A77400E17310 AS DateTime), 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'B33EC0C2-0D0A-40B0-AA71-F772E20355E0', NULL, NULL, NULL, N'资产配置经理', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'C0C1C04F-5921-4C0F-8938-3CE920B4847C', N'339a409a-a5a6-49b4-9071-86d7699a9ddd', NULL, NULL, N'巡检工程师', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'C1D88BD1-0CBD-4B03-BD9C-E3B0D86A9E37', N'339a409a-a5a6-49b4-9071-86d7699a9ddd', NULL, NULL, N'部门管理层', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'db60dc76-9632-44b3-ae4b-7177428bad35', N'771b628b-e43c-4592-b1ef-70ea23b0e3f2', N'configuration', 0, N'系统配置员', 0, 0, 1, NULL, 2, N'admin', NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'ed66f99c-d1bd-4fe3-948a-6520a5d6b7d9', N'339a409a-a5a6-49b4-9071-86d7699a9ddd', N'person', 1, N'服务台人员', 0, 0, 1, NULL, 6, N'admin', NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_Role] ([Id], [OrganizeId], [EnCode], [Type], [Name], [AllowEdit], [DeleteMark], [IsEnabled], [Remark], [SortCode], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'FD0B7A62-3C42-4124-A91C-AC4030A781E4', NULL, NULL, NULL, N'知识管理员', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'018c7b35-d79b-4b48-9fa5-dd44375875c4', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'87f0aa68-fa57-43cb-84d0-e979fc4af24c', N'admin', CAST(0x0000A74B015D153D AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'04a8f35b-e43b-4f06-aa08-2bfc272fe2a1', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'85438f3b-0634-4b17-b778-aee3a5819669', N'admin', CAST(0x0000A7440114DAD3 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'083f6bd4-c086-486c-b25a-1f2e8a3a9563', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'216d09a8-575f-43d1-85f6-acc025fa94b3', N'admin', CAST(0x0000A7440114DAC5 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'09ac4a11-2d50-48e6-b1ae-d9c18384fa5c', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'6d90439c-eb6b-4521-ab4d-5e481406a861', N'admin', CAST(0x0000A7440114DAAE AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'09d88a4f-ef46-4ca0-a95a-a1ce15aa91c0', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'82b06e80-103e-4a38-b171-740d2b0e194b', N'admin', CAST(0x0000A74900A1A66B AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'0fa5abf9-3be7-40a3-b79e-410cffdf5620', N'97223b06-6b7a-47fb-b74c-173f52c519c4', N'c04bfd8f-7e2e-4312-9148-a2e14007fa46', N'admin', CAST(0x0000A8190102F415 AS DateTime), 0, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'164ad154-21e5-48ab-8e27-1c0ea38d066d', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'e9478f45-0c00-435f-9a7a-35c7af1f86f7', N'admin', CAST(0x0000A74900A1A674 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'1adef545-559b-4cc3-b3c0-1debdce21f73', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'c04bfd8f-7e2e-4312-9148-a2e14007fa46', N'admin', CAST(0x0000A74B015D1538 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'1f5af2cf-3d4a-4af6-b4e2-4c3dd76627ea', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'09157352-1252-4964-8fee-479759a95db8', N'admin', CAST(0x0000A74900A1A665 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'23bbb1ff-9d3a-408a-a9fa-c203ef26c66a', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'fbee5749-8694-495f-b140-b5b3399df7ee', N'admin', CAST(0x0000A74B015D1530 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'2ba622d6-60e9-4918-a3cf-f634b969bc98', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'7ae2e6aa-0433-4eaa-9357-1adec2507345', N'admin', CAST(0x0000A75A00DC86A9 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'31BAFC79-A550-485F-A9CE-3332B5CD23DA', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'DD5D595F-9964-4941-A872-28694FD22FE2', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'3bd543bc-3e10-4bf8-96b3-c888987c636e', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'3c69e3fb-e1fe-4911-8417-6f6d55a1ce72', N'admin', CAST(0x0000A74A0100B1B5 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'3e7e6244-080b-49a6-9fb5-654af2e0fd33', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'855f3590-b233-4224-aaff-47fb95c8353d', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'3f5cf11a-4b6a-4e2f-94e5-dcc390374f75', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'086ee328-5a15-40b0-8e15-291093e2e8b1', N'admin', CAST(0x0000A74900A1A670 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'41b4ffda-cd44-4bad-90d0-0ebec361c35e', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'233e50fd-4860-42f9-aa7a-93853ac0434b', N'admin', CAST(0x0000A73700E158FC AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'45e1cd76-8c78-4158-a689-87c8d24ba024', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'752c9d3f-a744-42ba-87a2-79849fc3fc66', N'admin', CAST(0x0000A7440114DAC0 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'4f5bd239-c484-4518-85c3-2c8f65aebe52', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'cd4e9f8b-f56a-42dc-94e1-b76f3d0b38fc', N'admin', CAST(0x0000A74900A1A679 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'55293ca1-fabb-4bda-855b-37b808827110', N'97223b06-6b7a-47fb-b74c-173f52c519c4', N'b971f57e-d11f-409b-92ec-c76e98bbc7b1', N'admin', CAST(0x0000A8190102F3FC AS DateTime), 0, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'64DB98A9-0D63-4A96-8046-B1D74E2DC554', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'BE385E6A-0942-4112-9FAB-B0DC66196F81', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'68e36f44-9a77-4377-bb71-9af61adc7b11', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'2c24cdfc-8f26-4947-bcb2-0cb4d9111e80', N'admin', CAST(0x0000A7440114DAC9 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'6a8d7415-d228-4316-abdc-6465dd8baf60', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'3de13971-a51f-40f7-be40-eb035b7f0fae', N'admin', CAST(0x0000A755011FE8D8 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'6B1F4E8B-88AD-4108-BD33-5E9EDA21EF74', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'10a708fc-9e0d-45c6-9247-cef0c5f506ec', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'6bd7028f-00d1-4fd9-89d9-6ddc7ce822ce', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'2d0b02db-09f7-4404-bbdd-c8a516f48288', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'74604022-d5f2-4855-b07a-f7e1235e2ef6', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'e32b7507-aaf0-42dc-8008-139250c352ee', N'admin', CAST(0x0000A74A0162D654 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'76e9aef6-8030-4588-9a63-551a4a0b376e', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'0d2ea3c9-5b29-4bb6-9f91-0322419ded8e', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'78919e4f-e65d-461a-9af6-f8b5e13232e0', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'28a045a6-61f4-4784-8578-837ad307e4e3', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'7b3577cf-11d2-46a0-a859-9b17a07328c7', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'328b5383-79be-4b34-b57a-49fa3ebc7803', N'admin', CAST(0x0000A7440114DAD7 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'80b5d2c9-74b3-42d2-897d-70fffa050fa8', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'277c8647-ea81-42cf-8f7b-db353da95bbe', N'admin', CAST(0x0000A73700E158F5 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'810dddfa-870b-482f-a419-6326eea29c84', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'625cf550-4aad-4158-aff4-2a63d4f25819', N'admin', CAST(0x0000A7440114DADC AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'83c14f08-2046-4ea4-b01c-a7420a264b2b', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'e5346fa2-76ec-498f-8f54-3b443959335a', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'8B63FBEC-151E-4C7B-BBD0-D62A75844F9A', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'40B0E063-73F0-4D19-980B-49A52CA4DACF', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'982fd2e4-a023-4e34-b843-7c9ce5c84663', N'97223b06-6b7a-47fb-b74c-173f52c519c4', N'87f0aa68-fa57-43cb-84d0-e979fc4af24c', N'admin', CAST(0x0000A8190102F412 AS DateTime), 0, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'98885c60-d3bc-49df-8eaa-f8ccb7eafaa3', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'5fe0cee6-0452-493d-9b55-ff23a5da5e2d', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'A16A45D2-F6C1-4014-A63E-A1C3DB5AA9B6', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'047A418D-BC7F-4BF6-BCDB-2214091B7764', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'ad17561c-4aea-4eb3-8933-23670a0ee8bd', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'026550fd-2578-42ae-a041-625cda12325f', N'admin', CAST(0x0000A7440114DACE AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'b0fe6d22-f29b-4123-95d3-24a613e2e979', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'069f00f6-2a82-4bbe-90d6-418f37d5ef1f', N'admin', CAST(0x0000A74B015D1541 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'B6A2A9FF-059B-492B-9372-3B7273D0D146', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'b971f57e-d11f-409b-92ec-c76e98bbc7b1', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'CDD49232-4259-483B-9C02-80055655EAB6', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'10a708fc-9e0d-45c6-9247-cef0c5f506ec', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'D06D91DC-16D0-4B22-A3F8-28E4D2945790', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'0EED8CA8-B499-4482-8839-47BF07C91EEB', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'dc6d7e33-daaa-4df5-9561-cc912f3a26f6', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'46F30513-824B-48A4-A058-EBDBF341C9CE', N'admin', CAST(0x0000A75900DD5DD2 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'e5d6408b-c397-4895-bd00-ac5caffe3c4a', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'd9cfc79d-55f6-4890-b604-49f1d2a0d971', N'admin', CAST(0x0000A7440114DAB7 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'EC33DF8A-CD02-458E-8F1F-60F4FC483BAA', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'564684B4-B653-4918-92A0-5EDF662F0735', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_RoleAuthorize] ([Id], [RoleId], [ModuleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'f44cc7d8-4495-42bb-91a0-f56b539b6fc4', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'81d1cbf0-3cff-4cde-8128-7d0d844450de', NULL, NULL, 1, NULL)
INSERT [dbo].[Sys_User] ([Id], [Account], [RealName], [NickName], [Password], [Avatar], [Gender], [TelPhone], [MobilePhone], [Email], [Address], [CompanyId], [DepartmentId], [IsEnabled], [IsOnLine], [AllowIPAddress], [LoginCount], [LastLoginTime], [PrevLoginTime], [LastLoginIP], [SortCode], [Theme], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'897C3C01-ACAF-4169-AD2F-B3E101AAE3EA', N'xiaofei', N'王菲', N'菲菲菲菲菲', N'1e3d472896cff02f8281a86b70046377', N'/Images/avatar/user.png', 0, NULL, N'15622684596', N'jakhf@163.com', N'山东济南', NULL, N'339a409a-a5a6-49b4-9071-86d7699a9ddd', 1, NULL, NULL, 1040, NULL, NULL, NULL, 5, NULL, 0, N'admin', CAST(0x0000A73E00B4EC24 AS DateTime), N'admin', CAST(0x0000A78C011B7672 AS DateTime), 1)
INSERT [dbo].[Sys_User] ([Id], [Account], [RealName], [NickName], [Password], [Avatar], [Gender], [TelPhone], [MobilePhone], [Email], [Address], [CompanyId], [DepartmentId], [IsEnabled], [IsOnLine], [AllowIPAddress], [LoginCount], [LastLoginTime], [PrevLoginTime], [LastLoginIP], [SortCode], [Theme], [DeleteMark], [CreateUser], [CreateTime], [ModifyUser], [ModifyTime], [ChkState]) VALUES (N'D1EF3DCD-2C7D-4E8F-8F29-9F73625DD5DF', N'admin', N'小高', N'Esofar', N'1e3d472896cff02f8281a86b70046377', N'/Images/avatar/user.png', 1, NULL, N'13688888888', N'973095739@qq.com', N'山东济宁', NULL, N'a93c66e2-b8dc-4d00-84ed-e6071b5f5318', 1, 1, NULL, 89, CAST(0x0000A8190143A936 AS DateTime), CAST(0x0000A8190143A936 AS DateTime), NULL, 1, NULL, 0, N'admin', CAST(0x0000A73E00B4EC24 AS DateTime), N'admin', CAST(0x0000A7AE00B5C738 AS DateTime), 1)
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [Password], [SecretKey], [PrevVisitTime], [LastVisitTime], [ChangePwdTime], [LoginCount], [AllowMultiUserOnline], [IsOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme], [ChkState], [CreateTime]) VALUES (N'6bde15b3-88a9-4522-817e-3d5877130a05', N'd1ef3dcd-2c7d-4e8f-8f29-9f73625dd5df', N'1e3d472896cff02f8281a86b70046377', N'juhgtdjc', CAST(0x0000A7AE00AE8199 AS DateTime), CAST(0x0000A7AE00AE8199 AS DateTime), CAST(0x0000A7AD009EEF95 AS DateTime), 1040, 1, 1, N'lovecoding?', N'no', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_UserLogOn] ([Id], [UserId], [Password], [SecretKey], [PrevVisitTime], [LastVisitTime], [ChangePwdTime], [LoginCount], [AllowMultiUserOnline], [IsOnLine], [Question], [AnswerQuestion], [CheckIPAddress], [Language], [Theme], [ChkState], [CreateTime]) VALUES (N'e86c5360-b710-475a-8f80-6f7e0d0b0a1a', N'897c3c01-acaf-4169-ad2f-b3e101aae3ea', N'552547bc4c511ce82e66265e370d49b6', N'juhgtdjc', CAST(0x0000A74600EABA6A AS DateTime), CAST(0x0000A74600EABA6A AS DateTime), NULL, 3, 0, 1, N'我是谁？', N'王菲', 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_UserRoleRelation] ([Id], [UserId], [RoleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'45e0a953-fd82-42f4-afe5-cbbbd2a263b0', N'd1ef3dcd-2c7d-4e8f-8f29-9f73625dd5df', N'a3a3857c-51fb-43a6-a7b5-3a612e887b3a', N'admin', CAST(0x0000A701009E8417 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_UserRoleRelation] ([Id], [UserId], [RoleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'5c7b0e32-9dd5-40d8-82ec-e26a331d6059', N'897c3c01-acaf-4169-ad2f-b3e101aae3ea', N'ed66f99c-d1bd-4fe3-948a-6520a5d6b7d9', N'admin', CAST(0x0000A741010E40E7 AS DateTime), 1, NULL)
INSERT [dbo].[Sys_UserRoleRelation] ([Id], [UserId], [RoleId], [CreateUser], [CreateTime], [ChkState], [SortCode]) VALUES (N'b37e496a-918b-4876-a09e-22449aac1bb7', N'897c3c01-acaf-4169-ad2f-b3e101aae3ea', N'97223b06-6b7a-47fb-b74c-173f52c519c4', N'admin', CAST(0x0000A741010E40EF AS DateTime), 1, NULL)
ALTER TABLE [dbo].[Conf_Department] ADD  CONSTRAINT [DF_Conf_Department_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Sys_Item] ADD  CONSTRAINT [DF_Sys_Item_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Sys_ItemsDetail] ADD  CONSTRAINT [DF_Sys_ItemsDetail_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Sys_Permission] ADD  CONSTRAINT [DF_Sys_Permission_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Sys_Permission] ADD  CONSTRAINT [DF_Sys_Permission_IsPublic]  DEFAULT ((0)) FOR [IsPublic]
GO
ALTER TABLE [dbo].[Sys_Permission] ADD  CONSTRAINT [DF_Sys_Permission_IsEnable]  DEFAULT ((1)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Sys_Permission] ADD  CONSTRAINT [DF_Sys_Permission_IsEdit]  DEFAULT ((1)) FOR [IsEdit]
GO
ALTER TABLE [dbo].[Sys_Permission] ADD  CONSTRAINT [DF_Sys_Permission_DeleteMark]  DEFAULT ((0)) FOR [DeleteMark]
GO
ALTER TABLE [dbo].[Sys_Role] ADD  CONSTRAINT [DF_Sys_Role_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Sys_RoleAuthorize] ADD  CONSTRAINT [DF_Sys_RoleAuthorize_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Sys_User] ADD  CONSTRAINT [DF_Sys_User_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Sys_UserLogOn] ADD  CONSTRAINT [DF_Sys_UserLogOn_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Sys_UserLogOn] ADD  CONSTRAINT [DF_Sys_UserLogin_LoginCount]  DEFAULT ((0)) FOR [LoginCount]
GO
ALTER TABLE [dbo].[Sys_UserRoleRelation] ADD  CONSTRAINT [DF_Sys_UserRoleRelation_Id]  DEFAULT (newid()) FOR [Id]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'EnCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'层次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'Layer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'SortCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否树形菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'IsTree'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'IsEnabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Item', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'ItemId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'EnCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选项名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否默认' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'IsDefault'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'SortCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'IsEnabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ItemsDetail', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发生时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'LogLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作模块' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'Operation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志消息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'Message'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作账户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'Account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人IP归属地' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'IPAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'堆栈信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Log', @level2type=N'COLUMN',@level2name=N'StackTrace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'层次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'Layer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'事件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'JsEvent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块类型：1-菜单 2-按钮' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'SortCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否公开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'IsPublic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'IsEnable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'允许编辑' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'IsEdit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Permission', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'OrganizeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'EnCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类：1-角色2-岗位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可编辑' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'AllowEdit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'IsEnabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'SortCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleAuthorize', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleAuthorize', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleAuthorize', @level2type=N'COLUMN',@level2name=N'ModuleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleAuthorize', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_RoleAuthorize', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'Account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'NickName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'Avatar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'MobilePhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领导ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'CompanyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'DepartmentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'IsEnabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'SortCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'ModifyUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'ModifyTime'
GO
USE [master]
GO
ALTER DATABASE [OperationsITSM_Data] SET  READ_WRITE 
GO
