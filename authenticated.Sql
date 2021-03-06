USE [authenticated]
GO
/****** Object:  StoredProcedure [dbo].[OnSave_SP_tblPolicyMaster]    Script Date: 11/19/2021 16:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[OnSave_SP_tblPolicyMaster]
	@Policy_No		Int ,
	@Date     Datetime,
	@Scheme_No	int=NULL,
	 @Agent_No  int=NULL,
	 @CustomerName Varchar(60),
	 @PolicyAmount Decimal(18,0),
	 @Commission Decimal(18,0)	 
AS
SET IDENTITY_INSERT Policy_Details ON
	Begin
		 INSERT INTO Policy_Details (
					   [Policy_No]
					   ,[Date]
					  ,[Scheme_No]
					  ,[Agent_No]
					  ,[CustomerName]
					  ,[PolicyAmount]
					  ,[Commission]
					  
					   
		)
		Values (
					@Policy_No
					,@Date
					  ,@Scheme_No
					  ,@Agent_No
					  ,@CustomerName,
					  @PolicyAmount
					,@Commission
		)
 
	End	
SET IDENTITY_INSERT Policy_Details OFF
GO
/****** Object:  Table [dbo].[Scheme_Master]    Script Date: 11/19/2021 16:03:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Scheme_Master](
	[Scheme_No] [int] IDENTITY(1,1) NOT NULL,
	[Scheme_Name] [varchar](60) NULL,
	[Commission] [decimal](18, 4) NULL,
 CONSTRAINT [PK_Scheme_Master] PRIMARY KEY CLUSTERED 
(
	[Scheme_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Scheme_Master] ON
INSERT [dbo].[Scheme_Master] ([Scheme_No], [Scheme_Name], [Commission]) VALUES (1, N'Long term', CAST(2.0000 AS Decimal(18, 4)))
INSERT [dbo].[Scheme_Master] ([Scheme_No], [Scheme_Name], [Commission]) VALUES (2, N'Short term', CAST(2.0200 AS Decimal(18, 4)))
SET IDENTITY_INSERT [dbo].[Scheme_Master] OFF
/****** Object:  Table [dbo].[Register]    Script Date: 11/19/2021 16:03:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Register](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Password] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Register] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Register] ON
INSERT [dbo].[Register] ([UserId], [Password], [UserName], [CreatedDate]) VALUES (1, N'12345', N'Test', CAST(0x0000ADE500C81AD9 AS DateTime))
INSERT [dbo].[Register] ([UserId], [Password], [UserName], [CreatedDate]) VALUES (2, N'12345', N'Bhavin', CAST(0x0000ADE500CA3628 AS DateTime))
INSERT [dbo].[Register] ([UserId], [Password], [UserName], [CreatedDate]) VALUES (4, N'1234', N'bdfbdfb', CAST(0x0000ADE500CF0C49 AS DateTime))
INSERT [dbo].[Register] ([UserId], [Password], [UserName], [CreatedDate]) VALUES (5, N'12345', N'admin', CAST(0x0000ADE500E5F11B AS DateTime))
INSERT [dbo].[Register] ([UserId], [Password], [UserName], [CreatedDate]) VALUES (6, N'1234', N'casas', CAST(0x0000ADE500E852CF AS DateTime))
INSERT [dbo].[Register] ([UserId], [Password], [UserName], [CreatedDate]) VALUES (7, N'12345', N'vsdvsdv', CAST(0x0000ADE500E8AD1D AS DateTime))
INSERT [dbo].[Register] ([UserId], [Password], [UserName], [CreatedDate]) VALUES (8, N'1234', N'nsfnfn', CAST(0x0000ADE500E9C49E AS DateTime))
INSERT [dbo].[Register] ([UserId], [Password], [UserName], [CreatedDate]) VALUES (9, N'12345', N'Harpal', CAST(0x0000ADE500F8C01B AS DateTime))
INSERT [dbo].[Register] ([UserId], [Password], [UserName], [CreatedDate]) VALUES (10, N'admin', N'admin', CAST(0x0000ADE500F92C76 AS DateTime))
SET IDENTITY_INSERT [dbo].[Register] OFF
/****** Object:  Table [dbo].[Agent_Master]    Script Date: 11/19/2021 16:03:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Agent_Master](
	[Agent_No] [int] IDENTITY(1,1) NOT NULL,
	[Agent_Name] [varchar](60) NULL,
 CONSTRAINT [PK_Agent_Master] PRIMARY KEY CLUSTERED 
(
	[Agent_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Agent_Master] ON
INSERT [dbo].[Agent_Master] ([Agent_No], [Agent_Name]) VALUES (1, N'Tushar Levua')
INSERT [dbo].[Agent_Master] ([Agent_No], [Agent_Name]) VALUES (2, N'Narendra Modi')
INSERT [dbo].[Agent_Master] ([Agent_No], [Agent_Name]) VALUES (3, N'Amit Shah')
INSERT [dbo].[Agent_Master] ([Agent_No], [Agent_Name]) VALUES (4, N'Nitin Gadakari')
INSERT [dbo].[Agent_Master] ([Agent_No], [Agent_Name]) VALUES (5, N'Jayesh Shah')
SET IDENTITY_INSERT [dbo].[Agent_Master] OFF
/****** Object:  Table [dbo].[Policy_Details]    Script Date: 11/19/2021 16:03:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Policy_Details](
	[Policy_No] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Scheme_No] [int] NULL,
	[Agent_No] [int] NULL,
	[CustomerName] [varchar](60) NULL,
	[PolicyAmount] [int] NULL,
	[Commission] [decimal](18, 3) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Policy_Details] ON
INSERT [dbo].[Policy_Details] ([Policy_No], [Date], [Scheme_No], [Agent_No], [CustomerName], [PolicyAmount], [Commission]) VALUES (0, CAST(0x0000ADD000000000 AS DateTime), 1, 1, N'asdbvsdvdsds', 15651, CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Policy_Details] ([Policy_No], [Date], [Scheme_No], [Agent_No], [CustomerName], [PolicyAmount], [Commission]) VALUES (1, CAST(0x0000ADD000000000 AS DateTime), 1, 2, N'ndfggfndfgn', 565654, CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Policy_Details] ([Policy_No], [Date], [Scheme_No], [Agent_No], [CustomerName], [PolicyAmount], [Commission]) VALUES (123, CAST(0x0000ADD000000000 AS DateTime), 1, 2, N'ndfggfndfgn', 565654, CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Policy_Details] ([Policy_No], [Date], [Scheme_No], [Agent_No], [CustomerName], [PolicyAmount], [Commission]) VALUES (1512, CAST(0x0000A97F00000000 AS DateTime), 1, 1, N'Bisag Levua', 5000, CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Policy_Details] ([Policy_No], [Date], [Scheme_No], [Agent_No], [CustomerName], [PolicyAmount], [Commission]) VALUES (1513, CAST(0x0000A97F00000000 AS DateTime), 2, 1, N'Bisag Tushar', 10000, CAST(3.000 AS Decimal(18, 3)))
INSERT [dbo].[Policy_Details] ([Policy_No], [Date], [Scheme_No], [Agent_No], [CustomerName], [PolicyAmount], [Commission]) VALUES (1514, CAST(0x0000A97F00000000 AS DateTime), 1, 1, N'Bisag Gandhinagar', 15000, CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Policy_Details] ([Policy_No], [Date], [Scheme_No], [Agent_No], [CustomerName], [PolicyAmount], [Commission]) VALUES (6519, CAST(0x0000ADD000000000 AS DateTime), 1, 2, N'ndfggfndfgn', 565654, CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Policy_Details] ([Policy_No], [Date], [Scheme_No], [Agent_No], [CustomerName], [PolicyAmount], [Commission]) VALUES (5161, CAST(0x0000ADD000000000 AS DateTime), 1, 3, N'Tushae', 5165161, CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Policy_Details] ([Policy_No], [Date], [Scheme_No], [Agent_No], [CustomerName], [PolicyAmount], [Commission]) VALUES (5161, CAST(0x0000ADD000000000 AS DateTime), 1, 3, N'Tushae', 5165161, CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Policy_Details] ([Policy_No], [Date], [Scheme_No], [Agent_No], [CustomerName], [PolicyAmount], [Commission]) VALUES (12345, CAST(0x0000ADD000000000 AS DateTime), 1, 1, N'Test', 1500, CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Policy_Details] ([Policy_No], [Date], [Scheme_No], [Agent_No], [CustomerName], [PolicyAmount], [Commission]) VALUES (12345, CAST(0x0000ADE500000000 AS DateTime), 1, 1, N'Harpal', 5000, CAST(2.000 AS Decimal(18, 3)))
SET IDENTITY_INSERT [dbo].[Policy_Details] OFF
/****** Object:  StoredProcedure [dbo].[GetAll_tblAgentcommission]    Script Date: 11/19/2021 16:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetAll_tblAgentcommission]
@UserCode bigint = 0  
AS

BEGIN
	SET NOCOUNT ON;

		SELECT a.Agent_Name as Agent,Count(s.Commission) as Commission from Policy_Details as p
		right join Agent_Master a on p.Agent_No = a.Agent_No
		left join Scheme_Master s on s.Scheme_No = p.Scheme_No
		Group by a.Agent_Name
		order by Count(s.Commission) desc
END
GO
/****** Object:  StoredProcedure [dbo].[GetAll_tblPolicyMaster]    Script Date: 11/19/2021 16:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAll_tblPolicyMaster]
@UserCode bigint = 0  	
AS
BEGIN
	SET NOCOUNT ON;

		SELECT * from Scheme_Master
		
END
GO
/****** Object:  StoredProcedure [dbo].[GetAll_tblAgentdnepolicy]    Script Date: 11/19/2021 16:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAll_tblAgentdnepolicy]
@UserCode bigint = 0  
AS

BEGIN
	SET NOCOUNT ON;

		SELECT a.Agent_Name as Agent,isnull(s.Scheme_Name,'N/A') as Scheme,Count(s.Scheme_No) as Policy from Policy_Details as p
		right join Agent_Master a on p.Agent_No = a.Agent_No
		left join Scheme_Master s on s.Scheme_No = p.Scheme_No
		Group by a.Agent_Name,s.Scheme_Name
		order by Count(s.Scheme_No) desc
END
GO
/****** Object:  StoredProcedure [dbo].[ComboFill_tblSchemeDetails]    Script Date: 11/19/2021 16:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ComboFill_tblSchemeDetails]
	@UserCode bigint = 1  
AS
BEGIN
	SET NOCOUNT ON;
    
    Select Scheme_No as [SchemeNo],
    Scheme_Name as [SchemeName] from Scheme_Master
    Union all
    select '0' as SchemeNo, '-- Select Scheme--' as Scheme_Master
    order by SchemeNo
   
END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 11/19/2021 16:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Login]
	@UserName nvarchar(50),
	@Password nvarchar(50)
AS
begin
select UserId,UserName from Register where UserName=@UserName and Password=@Password
end

--select * from Register
GO
/****** Object:  StoredProcedure [dbo].[OnSave_User]    Script Date: 11/19/2021 16:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [dbo].[OnSave_User] 1,'12345','test'
CREATE PROCEDURE [dbo].[OnSave_User]
	@UserName nvarchar(50),
	@Password nvarchar(50)	
AS
begin
	 INSERT INTO Register(Password,UserName,CreatedDate)
			Values(@Password,@UserName,GETDATE())
end
GO
/****** Object:  StoredProcedure [dbo].[ComboFill_tblAgentMaster]    Script Date: 11/19/2021 16:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [dbo].[ComboFill_tblAgentMaster] 1
CREATE PROCEDURE [dbo].[ComboFill_tblAgentMaster]
	@UserCode bigint = 1  
AS
BEGIN
	SET NOCOUNT ON;

		SELECT 
			Agent_No as [AgentNo], 			Agent_Name as [AgentName]
			
		FROM Agent_Master  
		Union all
		 Select '0' as AgentNo ,'-- Select --' as DeviceName
		 Order by AgentNo
END
GO
/****** Object:  ForeignKey [FK_Policy_Details_Agent_Master]    Script Date: 11/19/2021 16:03:12 ******/
ALTER TABLE [dbo].[Policy_Details]  WITH CHECK ADD  CONSTRAINT [FK_Policy_Details_Agent_Master] FOREIGN KEY([Agent_No])
REFERENCES [dbo].[Agent_Master] ([Agent_No])
GO
ALTER TABLE [dbo].[Policy_Details] CHECK CONSTRAINT [FK_Policy_Details_Agent_Master]
GO
/****** Object:  ForeignKey [FK_Policy_Details_Scheme_Master]    Script Date: 11/19/2021 16:03:12 ******/
ALTER TABLE [dbo].[Policy_Details]  WITH CHECK ADD  CONSTRAINT [FK_Policy_Details_Scheme_Master] FOREIGN KEY([Scheme_No])
REFERENCES [dbo].[Scheme_Master] ([Scheme_No])
GO
ALTER TABLE [dbo].[Policy_Details] CHECK CONSTRAINT [FK_Policy_Details_Scheme_Master]
GO
