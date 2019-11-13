USE [master]
GO
/** Object:  Database [ProyectoJaveriana]    Script Date: 11/11/2019 5:22:41 p. m. **/
CREATE DATABASE [ProyectoJaveriana]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectoJaveriana', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ProyectoJaveriana.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProyectoJaveriana_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ProyectoJaveriana_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProyectoJaveriana] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoJaveriana].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoJaveriana] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoJaveriana] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectoJaveriana] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProyectoJaveriana] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectoJaveriana] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET RECOVERY FULL 
GO
ALTER DATABASE [ProyectoJaveriana] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectoJaveriana] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectoJaveriana] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectoJaveriana] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectoJaveriana] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProyectoJaveriana] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProyectoJaveriana', N'ON'
GO
ALTER DATABASE [ProyectoJaveriana] SET QUERY_STORE = OFF
GO
USE [ProyectoJaveriana]
GO
/** Object:  Table [dbo].[Curso]    Script Date: 11/11/2019 5:22:42 p. m. **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[IdCurso] [int] IDENTITY(1,1) NOT NULL,
	[NombreCurso] [nvarchar](150) NULL,
	[DescripcionCurso] [nvarchar](150) NULL,
	[AreaCurso] [nvarchar](150) NULL,
	[PresentacionExamen] [nvarchar](150) NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[IdCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[CursoEstudiante]    Script Date: 11/11/2019 5:22:45 p. m. **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursoEstudiante](
	[IdCurso] [int] NULL,
	[IdEstudiante] [int] NULL,
	[IDCurso_estudiante] [int] IDENTITY(1,1) NOT NULL,
	[FechaPresentacionExamen] [nvarchar](150) NULL,
	[PuntajeExamen] [decimal](18, 0) NULL,
	[EstadoAprovacionExamen] [nvarchar](150) NULL,
 CONSTRAINT [PK_CursoEstudiante] PRIMARY KEY CLUSTERED 
(
	[IDCurso_estudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[Pago]    Script Date: 11/11/2019 5:22:46 p. m. **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[IdPago] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[IdCurso] [int] NOT NULL,
	[EstadoPago] [bit] NOT NULL,
	[DescripcionPago] [nvarchar](150) NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[IdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[Persona]    Script Date: 11/11/2019 5:22:46 p. m. **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NULL,
	[Apellido] [nvarchar](150) NULL,
	[Rol] [nvarchar](150) NULL,
	[PuntajeGlobal] [int] NULL,
	[Grupo] [nvarchar](150) NULL,
	[Usuario] [nvarchar](150) NULL,
	[Contrasenia] [nvarchar](150) NULL,
	[Documento] [nvarchar](150) NULL,
 CONSTRAINT [PK_PersonaP] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[Pregunta]    Script Date: 11/11/2019 5:22:46 p. m. **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pregunta](
	[IdPregunta] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionPregunta] [nvarchar](150) NULL,
	[TipoPregunta] [nvarchar](150) NULL,
	[AreaPregunta] [nvarchar](150) NULL,
	[PuntajeMaximo] [int] NULL,
	[curso] [nvarchar](150) NULL,
 CONSTRAINT [PK_Pregunta] PRIMARY KEY CLUSTERED 
(
	[IdPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[Respuesta]    Script Date: 11/11/2019 5:22:46 p. m. **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuesta](
	[IdRespuesta] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionRespuesta] [nvarchar](150) NULL,
	[PuntajeRespuesta] [int] NULL,
	[IdPregunta] [int] NULL,
	[RespuestaCorrecta] [bit] NULL,
	[AreaRespuesta] [nvarchar](150) NULL,
	[TipoRespuesta] [nvarchar](150) NULL,
	[curso] [varchar](150) NULL,
 CONSTRAINT [PK_Respuesta] PRIMARY KEY CLUSTERED 
(
	[IdRespuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Curso] FOREIGN KEY([IdCurso])
REFERENCES [dbo].[Curso] ([IdCurso])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Curso]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Persona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Persona] ([IdPersona])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Persona]
GO
ALTER TABLE [dbo].[Respuesta]  WITH CHECK ADD  CONSTRAINT [FK_Respuesta_Respuesta] FOREIGN KEY([IdPregunta])
REFERENCES [dbo].[Pregunta] ([IdPregunta])
GO
ALTER TABLE [dbo].[Respuesta] CHECK CONSTRAINT [FK_Respuesta_Respuesta]
GO
USE [master]
GO
ALTER DATABASE [ProyectoJaveriana] SET  READ_WRITE 
GO