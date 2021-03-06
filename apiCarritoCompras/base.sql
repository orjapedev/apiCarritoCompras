USE [cartshop]
GO
/****** Object:  Table [dbo].[Planes]    Script Date: 18/10/2021 23:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planes](
	[IdPlan] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](max) NULL,
	[icono] [varchar](max) NULL,
	[descripcion] [varchar](max) NULL,
	[valor] [decimal](18, 0) NULL,
	[frecuencia] [varchar](max) NULL,
	[codigo] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanesProductos]    Script Date: 18/10/2021 23:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanesProductos](
	[idPlan] [int] NULL,
	[idProducto] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 18/10/2021 23:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](max) NULL,
	[precio] [decimal](18, 0) NULL,
	[estado] [bit] NULL,
	[detalle] [varchar](max) NULL,
	[imagen] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/10/2021 23:36:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](max) NULL,
	[email] [varchar](50) NOT NULL,
	[planId] [int] NULL,
	[telefono] [varchar](max) NULL,
	[clave] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Planes] ON 

INSERT [dbo].[Planes] ([IdPlan], [nombre], [icono], [descripcion], [valor], [frecuencia], [codigo]) VALUES (1, N'Primer plan', N'primer.jpg', N'Plan de prueba', CAST(100 AS Decimal(18, 0)), N'Baja', N'0001')
SET IDENTITY_INSERT [dbo].[Planes] OFF
GO
INSERT [dbo].[PlanesProductos] ([idPlan], [idProducto]) VALUES (1, 1)
INSERT [dbo].[PlanesProductos] ([idPlan], [idProducto]) VALUES (1, 2)
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([id], [descripcion], [precio], [estado], [detalle], [imagen]) VALUES (1, N'Camisa blanca', CAST(40 AS Decimal(18, 0)), 1, N'Camisa', N'camisa.jpg')
INSERT [dbo].[Productos] ([id], [descripcion], [precio], [estado], [detalle], [imagen]) VALUES (2, N'Pantalon', CAST(20 AS Decimal(18, 0)), 1, N'Pantalon', NULL)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id], [nombre], [email], [planId], [telefono], [clave]) VALUES (1, N'Orly Peña', N'orjape95@gmail.com', 1, N'937364', N'123')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[PlanesProductos]  WITH CHECK ADD FOREIGN KEY([idPlan])
REFERENCES [dbo].[Planes] ([IdPlan])
GO
ALTER TABLE [dbo].[PlanesProductos]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[Productos] ([id])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([planId])
REFERENCES [dbo].[Planes] ([IdPlan])
GO
