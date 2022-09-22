using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortune.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cultures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokenIdentities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Identity = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenIdentities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardComments_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardNames_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardComments_CardId",
                table: "CardComments",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardNames_CardId",
                table: "CardNames",
                column: "CardId");

            migrationBuilder.Sql(@"

INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'd41ed510-da32-ed11-91bb-cc15312ce92f', N'The Fool', N'', N'01.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'd51ed510-da32-ed11-91bb-cc15312ce92f', N'The Magician', N'', N'02.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'd61ed510-da32-ed11-91bb-cc15312ce92f', N'The HighPriestess', N'', N'03.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'd71ed510-da32-ed11-91bb-cc15312ce92f', N'The Empress', N'', N'04.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'd81ed510-da32-ed11-91bb-cc15312ce92f', N'The Emperor', N'', N'05.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'd91ed510-da32-ed11-91bb-cc15312ce92f', N'The Hierophant', N'', N'06.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'da1ed510-da32-ed11-91bb-cc15312ce92f', N'The Lovers', N'', N'07.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'db1ed510-da32-ed11-91bb-cc15312ce92f', N'The Chariot', N'', N'08.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'dc1ed510-da32-ed11-91bb-cc15312ce92f', N'Strength', N'', N'09.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'dd1ed510-da32-ed11-91bb-cc15312ce92f', N'The Hermit', N'', N'10.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'de1ed510-da32-ed11-91bb-cc15312ce92f', N'Whell Fortune', N'', N'11.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'df1ed510-da32-ed11-91bb-cc15312ce92f', N'Justice', N'', N'12.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'e01ed510-da32-ed11-91bb-cc15312ce92f', N'The Hanged Man', N'', N'13.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'e11ed510-da32-ed11-91bb-cc15312ce92f', N'Death', N'', N'14.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'e21ed510-da32-ed11-91bb-cc15312ce92f', N'Temperance', N'', N'15.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'e31ed510-da32-ed11-91bb-cc15312ce92f', N'The Devil', N'', N'16.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'e41ed510-da32-ed11-91bb-cc15312ce92f', N'The Tower', N'', N'17.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'e51ed510-da32-ed11-91bb-cc15312ce92f', N'The Star', N'', N'18.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'e61ed510-da32-ed11-91bb-cc15312ce92f', N'The Moon', N'', N'19.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'e71ed510-da32-ed11-91bb-cc15312ce92f', N'The Sun', N'', N'20.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'e81ed510-da32-ed11-91bb-cc15312ce92f', N'Judgement', N'', N'21.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'e91ed510-da32-ed11-91bb-cc15312ce92f', N'The World', N'', N'22.jpg', 0)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'ea1ed510-da32-ed11-91bb-cc15312ce92f', N'Ace of Wands', N'', N'23.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'eb1ed510-da32-ed11-91bb-cc15312ce92f', N'Wand Duo', N'', N'24.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'ec1ed510-da32-ed11-91bb-cc15312ce92f', N'Trio of Wands', N'', N'25.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'ed1ed510-da32-ed11-91bb-cc15312ce92f', N'The Wand Quartet', N'', N'26.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'ee1ed510-da32-ed11-91bb-cc15312ce92f', N'Five of Wands', N'', N'27.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'ef1ed510-da32-ed11-91bb-cc15312ce92f', N'Six of Wands', N'', N'28.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'f01ed510-da32-ed11-91bb-cc15312ce92f', N'Seven of Wands', N'', N'29.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'f11ed510-da32-ed11-91bb-cc15312ce92f', N'Octet of Wands', N'', N'30.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'f21ed510-da32-ed11-91bb-cc15312ce92f', N'Nine of Wands', N'', N'31.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'f31ed510-da32-ed11-91bb-cc15312ce92f', N'Ten of Wands', N'', N'32.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'f41ed510-da32-ed11-91bb-cc15312ce92f', N'Page Wands', N'', N'33.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'f51ed510-da32-ed11-91bb-cc15312ce92f', N'Knight Wands', N'', N'34.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'f61ed510-da32-ed11-91bb-cc15312ce92f', N'Queen Wands', N'', N'35.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'f71ed510-da32-ed11-91bb-cc15312ce92f', N'King Wands', N'', N'36.jpg', 1)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'f81ed510-da32-ed11-91bb-cc15312ce92f', N'Ace of Swords', N'', N'37.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'f91ed510-da32-ed11-91bb-cc15312ce92f', N'Sword Duo', N'', N'38.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'fa1ed510-da32-ed11-91bb-cc15312ce92f', N'Trio of Swords', N'', N'39.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'fb1ed510-da32-ed11-91bb-cc15312ce92f', N'The sword querted', N'', N'40.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'fc1ed510-da32-ed11-91bb-cc15312ce92f', N'Quintet of Swords', N'', N'41.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'fd1ed510-da32-ed11-91bb-cc15312ce92f', N'Six of Swords', N'', N'42.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'fe1ed510-da32-ed11-91bb-cc15312ce92f', N'Seven of Swords', N'', N'43.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'ff1ed510-da32-ed11-91bb-cc15312ce92f', N'Octet of Swords', N'', N'44.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'001fd510-da32-ed11-91bb-cc15312ce92f', N'Nine of Swords', N'', N'45.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'011fd510-da32-ed11-91bb-cc15312ce92f', N'Ten of Swords', N'', N'46.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'021fd510-da32-ed11-91bb-cc15312ce92f', N'Page of Swords', N'', N'47.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'031fd510-da32-ed11-91bb-cc15312ce92f', N'Knight of Swords', N'', N'48.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'041fd510-da32-ed11-91bb-cc15312ce92f', N'Queen of Swords', N'', N'49.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'051fd510-da32-ed11-91bb-cc15312ce92f', N'King of Swords', N'', N'50.jpg', 2)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'061fd510-da32-ed11-91bb-cc15312ce92f', N'Ace of Cups', N'', N'51.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'071fd510-da32-ed11-91bb-cc15312ce92f', N'Trophy duo', N'', N'52.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'081fd510-da32-ed11-91bb-cc15312ce92f', N'Trio of Cups', N'', N'53.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'091fd510-da32-ed11-91bb-cc15312ce92f', N'Quartet of Cups', N'', N'54.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'0a1fd510-da32-ed11-91bb-cc15312ce92f', N'Quintet of Cups', N'', N'55.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'0b1fd510-da32-ed11-91bb-cc15312ce92f', N'Six of Cups', N'', N'56.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'0c1fd510-da32-ed11-91bb-cc15312ce92f', N'Seven of Cups', N'', N'57.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'0d1fd510-da32-ed11-91bb-cc15312ce92f', N'Eight of Cups', N'', N'58.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'0e1fd510-da32-ed11-91bb-cc15312ce92f', N'Nine of Cups', N'', N'59.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'0f1fd510-da32-ed11-91bb-cc15312ce92f', N'Ten of Cups', N'', N'60.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'101fd510-da32-ed11-91bb-cc15312ce92f', N'Page of Cups', N'', N'61.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'111fd510-da32-ed11-91bb-cc15312ce92f', N'Knight of Cups', N'', N'62.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'121fd510-da32-ed11-91bb-cc15312ce92f', N'Queen of Cups', N'', N'63.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'131fd510-da32-ed11-91bb-cc15312ce92f', N'King of Cups', N'', N'64.jpg', 3)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'141fd510-da32-ed11-91bb-cc15312ce92f', N'Ace of Pentacles', N'', N'65.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'151fd510-da32-ed11-91bb-cc15312ce92f', N'Pentacles duo', N'', N'66.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'161fd510-da32-ed11-91bb-cc15312ce92f', N'Trio of Pentacles', N'', N'67.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'171fd510-da32-ed11-91bb-cc15312ce92f', N'Quartet of Pentacles', N'', N'68.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'181fd510-da32-ed11-91bb-cc15312ce92f', N'Quintet of Pentacles', N'', N'69.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'191fd510-da32-ed11-91bb-cc15312ce92f', N'Six of Pentacles', N'', N'70.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'1a1fd510-da32-ed11-91bb-cc15312ce92f', N'Seven of Pentacles', N'', N'71.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'1b1fd510-da32-ed11-91bb-cc15312ce92f', N'Eight of Pentacles', N'', N'72.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'1c1fd510-da32-ed11-91bb-cc15312ce92f', N'Nine of Pentacles', N'', N'73.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'1d1fd510-da32-ed11-91bb-cc15312ce92f', N'Ten of Pentacles', N'', N'74.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'1e1fd510-da32-ed11-91bb-cc15312ce92f', N'Page of Pentacles', N'', N'75.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'1f1fd510-da32-ed11-91bb-cc15312ce92f', N'Knight of Pentacles', N'', N'76.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'201fd510-da32-ed11-91bb-cc15312ce92f', N'Queen of Pentacles', N'', N'77.jpg', 4)
GO
INSERT [dbo].[Cards] ([Id], [Name], [Description], [ImageUrl], [Type]) VALUES (N'211fd510-da32-ed11-91bb-cc15312ce92f', N'King of Pentacles', N'', N'78.jpg', 4)
GO

GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'48c94db4-1d38-ed11-91bc-cc15312ce92f', N'The Fool', N'en-US', N'd41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'49c94db4-1d38-ed11-91bc-cc15312ce92f', N'The Magician', N'en-US', N'd51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4ac94db4-1d38-ed11-91bc-cc15312ce92f', N'The HighPriestess', N'en-US', N'd61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4bc94db4-1d38-ed11-91bc-cc15312ce92f', N'The Empress', N'en-US', N'd71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4cc94db4-1d38-ed11-91bc-cc15312ce92f', N'The Emperor', N'en-US', N'd81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4dc94db4-1d38-ed11-91bc-cc15312ce92f', N'The Hierophant', N'en-US', N'd91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4ec94db4-1d38-ed11-91bc-cc15312ce92f', N'The Lovers', N'en-US', N'da1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4fc94db4-1d38-ed11-91bc-cc15312ce92f', N'The Chariot', N'en-US', N'db1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'50c94db4-1d38-ed11-91bc-cc15312ce92f', N'Strength', N'en-US', N'dc1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'51c94db4-1d38-ed11-91bc-cc15312ce92f', N'The Hermit', N'en-US', N'dd1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'52c94db4-1d38-ed11-91bc-cc15312ce92f', N'Whell Fortune', N'en-US', N'de1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'53c94db4-1d38-ed11-91bc-cc15312ce92f', N'Justice', N'en-US', N'df1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'54c94db4-1d38-ed11-91bc-cc15312ce92f', N'The Hanged Man', N'en-US', N'e01ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'55c94db4-1d38-ed11-91bc-cc15312ce92f', N'Death', N'en-US', N'e11ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'56c94db4-1d38-ed11-91bc-cc15312ce92f', N'Temperance', N'en-US', N'e21ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'57c94db4-1d38-ed11-91bc-cc15312ce92f', N'The Devil', N'en-US', N'e31ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'58c94db4-1d38-ed11-91bc-cc15312ce92f', N'The Tower', N'en-US', N'e41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'59c94db4-1d38-ed11-91bc-cc15312ce92f', N'The Star', N'en-US', N'e51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5ac94db4-1d38-ed11-91bc-cc15312ce92f', N'The Moon', N'en-US', N'e61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5bc94db4-1d38-ed11-91bc-cc15312ce92f', N'The Sun', N'en-US', N'e71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5cc94db4-1d38-ed11-91bc-cc15312ce92f', N'Judgement', N'en-US', N'e81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5dc94db4-1d38-ed11-91bc-cc15312ce92f', N'The World', N'en-US', N'e91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5ec94db4-1d38-ed11-91bc-cc15312ce92f', N'Ace of Wands', N'en-US', N'ea1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5fc94db4-1d38-ed11-91bc-cc15312ce92f', N'Wand Duo', N'en-US', N'eb1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'60c94db4-1d38-ed11-91bc-cc15312ce92f', N'Trio of Wands', N'en-US', N'ec1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'61c94db4-1d38-ed11-91bc-cc15312ce92f', N'The Wand Quartet', N'en-US', N'ed1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'62c94db4-1d38-ed11-91bc-cc15312ce92f', N'Five of Wands', N'en-US', N'ee1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'63c94db4-1d38-ed11-91bc-cc15312ce92f', N'Six of Wands', N'en-US', N'ef1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'64c94db4-1d38-ed11-91bc-cc15312ce92f', N'Seven of Wands', N'en-US', N'f01ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'65c94db4-1d38-ed11-91bc-cc15312ce92f', N'Octet of Wands', N'en-US', N'f11ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'66c94db4-1d38-ed11-91bc-cc15312ce92f', N'Nine of Wands', N'en-US', N'f21ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'67c94db4-1d38-ed11-91bc-cc15312ce92f', N'Ten of Wands', N'en-US', N'f31ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'68c94db4-1d38-ed11-91bc-cc15312ce92f', N'Page Wands', N'en-US', N'f41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'69c94db4-1d38-ed11-91bc-cc15312ce92f', N'Knight Wands', N'en-US', N'f51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'6ac94db4-1d38-ed11-91bc-cc15312ce92f', N'Queen Wands', N'en-US', N'f61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'6bc94db4-1d38-ed11-91bc-cc15312ce92f', N'King Wands', N'en-US', N'f71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'6cc94db4-1d38-ed11-91bc-cc15312ce92f', N'Ace of Swords', N'en-US', N'f81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'6dc94db4-1d38-ed11-91bc-cc15312ce92f', N'Sword Duo', N'en-US', N'f91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'6ec94db4-1d38-ed11-91bc-cc15312ce92f', N'Trio of Swords', N'en-US', N'fa1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'6fc94db4-1d38-ed11-91bc-cc15312ce92f', N'The sword querted', N'en-US', N'fb1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'70c94db4-1d38-ed11-91bc-cc15312ce92f', N'Quintet of Swords', N'en-US', N'fc1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'71c94db4-1d38-ed11-91bc-cc15312ce92f', N'Six of Swords', N'en-US', N'fd1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'72c94db4-1d38-ed11-91bc-cc15312ce92f', N'Seven of Swords', N'en-US', N'fe1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'73c94db4-1d38-ed11-91bc-cc15312ce92f', N'Octet of Swords', N'en-US', N'ff1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'74c94db4-1d38-ed11-91bc-cc15312ce92f', N'Nine of Swords', N'en-US', N'001fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'75c94db4-1d38-ed11-91bc-cc15312ce92f', N'Ten of Swords', N'en-US', N'011fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'76c94db4-1d38-ed11-91bc-cc15312ce92f', N'Page of Swords', N'en-US', N'021fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'77c94db4-1d38-ed11-91bc-cc15312ce92f', N'Knight of Swords', N'en-US', N'031fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'78c94db4-1d38-ed11-91bc-cc15312ce92f', N'Queen of Swords', N'en-US', N'041fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'79c94db4-1d38-ed11-91bc-cc15312ce92f', N'King of Swords', N'en-US', N'051fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'7ac94db4-1d38-ed11-91bc-cc15312ce92f', N'Ace of Cups', N'en-US', N'061fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'7bc94db4-1d38-ed11-91bc-cc15312ce92f', N'Trophy duo', N'en-US', N'071fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'7cc94db4-1d38-ed11-91bc-cc15312ce92f', N'Trio of Cups', N'en-US', N'081fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'7dc94db4-1d38-ed11-91bc-cc15312ce92f', N'Quartet of Cups', N'en-US', N'091fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'7ec94db4-1d38-ed11-91bc-cc15312ce92f', N'Quintet of Cups', N'en-US', N'0a1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'7fc94db4-1d38-ed11-91bc-cc15312ce92f', N'Six of Cups', N'en-US', N'0b1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'80c94db4-1d38-ed11-91bc-cc15312ce92f', N'Seven of Cups', N'en-US', N'0c1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'81c94db4-1d38-ed11-91bc-cc15312ce92f', N'Eight of Cups', N'en-US', N'0d1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'82c94db4-1d38-ed11-91bc-cc15312ce92f', N'Nine of Cups', N'en-US', N'0e1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'83c94db4-1d38-ed11-91bc-cc15312ce92f', N'Ten of Cups', N'en-US', N'0f1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'84c94db4-1d38-ed11-91bc-cc15312ce92f', N'Page of Cups', N'en-US', N'101fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'85c94db4-1d38-ed11-91bc-cc15312ce92f', N'Knight of Cups', N'en-US', N'111fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'86c94db4-1d38-ed11-91bc-cc15312ce92f', N'Queen of Cups', N'en-US', N'121fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'87c94db4-1d38-ed11-91bc-cc15312ce92f', N'King of Cups', N'en-US', N'131fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'88c94db4-1d38-ed11-91bc-cc15312ce92f', N'Ace of Pentacles', N'en-US', N'141fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'89c94db4-1d38-ed11-91bc-cc15312ce92f', N'Pentacles duo', N'en-US', N'151fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'8ac94db4-1d38-ed11-91bc-cc15312ce92f', N'Trio of Pentacles', N'en-US', N'161fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'8bc94db4-1d38-ed11-91bc-cc15312ce92f', N'Quartet of Pentacles', N'en-US', N'171fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'8cc94db4-1d38-ed11-91bc-cc15312ce92f', N'Quintet of Pentacles', N'en-US', N'181fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'8dc94db4-1d38-ed11-91bc-cc15312ce92f', N'Six of Pentacles', N'en-US', N'191fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'8ec94db4-1d38-ed11-91bc-cc15312ce92f', N'Seven of Pentacles', N'en-US', N'1a1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'8fc94db4-1d38-ed11-91bc-cc15312ce92f', N'Eight of Pentacles', N'en-US', N'1b1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'90c94db4-1d38-ed11-91bc-cc15312ce92f', N'Nine of Pentacles', N'en-US', N'1c1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'91c94db4-1d38-ed11-91bc-cc15312ce92f', N'Ten of Pentacles', N'en-US', N'1d1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'92c94db4-1d38-ed11-91bc-cc15312ce92f', N'Page of Pentacles', N'en-US', N'1e1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'93c94db4-1d38-ed11-91bc-cc15312ce92f', N'Knight of Pentacles', N'en-US', N'1f1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'94c94db4-1d38-ed11-91bc-cc15312ce92f', N'Queen of Pentacles', N'en-US', N'201fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'95c94db4-1d38-ed11-91bc-cc15312ce92f', N'King of Pentacles', N'en-US', N'211fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'21e91d14-2038-ed11-91bc-cc15312ce92f', N'Mecnun', N'tr-TR', N'd41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'22e91d14-2038-ed11-91bc-cc15312ce92f', N'Büyücü', N'tr-TR', N'd51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'23e91d14-2038-ed11-91bc-cc15312ce92f', N'Baş Rahibe', N'tr-TR', N'd61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'24e91d14-2038-ed11-91bc-cc15312ce92f', N'İmparatoriçe', N'tr-TR', N'd71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'25e91d14-2038-ed11-91bc-cc15312ce92f', N'Imparator', N'tr-TR', N'd81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'26e91d14-2038-ed11-91bc-cc15312ce92f', N'Baş Rahip', N'tr-TR', N'd91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'27e91d14-2038-ed11-91bc-cc15312ce92f', N'Aşıklar', N'tr-TR', N'da1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'28e91d14-2038-ed11-91bc-cc15312ce92f', N'Savaş Arabası', N'tr-TR', N'db1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'29e91d14-2038-ed11-91bc-cc15312ce92f', N'Güç', N'tr-TR', N'dc1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'2ae91d14-2038-ed11-91bc-cc15312ce92f', N'Münzevi', N'tr-TR', N'dd1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'2be91d14-2038-ed11-91bc-cc15312ce92f', N'Kader Çarkı', N'tr-TR', N'de1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'2ce91d14-2038-ed11-91bc-cc15312ce92f', N'Adalet', N'tr-TR', N'df1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'2de91d14-2038-ed11-91bc-cc15312ce92f', N'Asılmış Adam', N'tr-TR', N'e01ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'2ee91d14-2038-ed11-91bc-cc15312ce92f', N'Ölüm', N'tr-TR', N'e11ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'2fe91d14-2038-ed11-91bc-cc15312ce92f', N'Denge', N'tr-TR', N'e21ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'30e91d14-2038-ed11-91bc-cc15312ce92f', N'Şeytan', N'tr-TR', N'e31ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'31e91d14-2038-ed11-91bc-cc15312ce92f', N'Kule', N'tr-TR', N'e41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'32e91d14-2038-ed11-91bc-cc15312ce92f', N'Yıldız', N'tr-TR', N'e51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'33e91d14-2038-ed11-91bc-cc15312ce92f', N'Ay', N'tr-TR', N'e61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'34e91d14-2038-ed11-91bc-cc15312ce92f', N'Güneş', N'tr-TR', N'e71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'35e91d14-2038-ed11-91bc-cc15312ce92f', N'Son Hüküm', N'tr-TR', N'e81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'36e91d14-2038-ed11-91bc-cc15312ce92f', N'Dünya', N'tr-TR', N'e91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'37e91d14-2038-ed11-91bc-cc15312ce92f', N'Asaların Ası', N'tr-TR', N'ea1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'38e91d14-2038-ed11-91bc-cc15312ce92f', N'Asa İkilisi', N'tr-TR', N'eb1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'39e91d14-2038-ed11-91bc-cc15312ce92f', N'Asa Üçlüsü', N'tr-TR', N'ec1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'3ae91d14-2038-ed11-91bc-cc15312ce92f', N'Asa Dörtlüsü', N'tr-TR', N'ed1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'3be91d14-2038-ed11-91bc-cc15312ce92f', N'Asa Beşlisi', N'tr-TR', N'ee1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'3ce91d14-2038-ed11-91bc-cc15312ce92f', N'Asa Altılısı', N'tr-TR', N'ef1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'3de91d14-2038-ed11-91bc-cc15312ce92f', N'Asa Yedilisi', N'tr-TR', N'f01ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'3ee91d14-2038-ed11-91bc-cc15312ce92f', N'Asa Sekizlisi', N'tr-TR', N'f11ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'3fe91d14-2038-ed11-91bc-cc15312ce92f', N'Asa Dokuzlusu', N'tr-TR', N'f21ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'40e91d14-2038-ed11-91bc-cc15312ce92f', N'Asa Onlusu', N'tr-TR', N'f31ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'41e91d14-2038-ed11-91bc-cc15312ce92f', N'Asaların Uşağı', N'tr-TR', N'f41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'42e91d14-2038-ed11-91bc-cc15312ce92f', N'Asaların Sövalyesi', N'tr-TR', N'f51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'43e91d14-2038-ed11-91bc-cc15312ce92f', N'Asaların Kraliçesi', N'tr-TR', N'f61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'44e91d14-2038-ed11-91bc-cc15312ce92f', N'Asaların Kralı', N'tr-TR', N'f71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'45e91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıçların Ası', N'tr-TR', N'f81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'46e91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıç Ikilisi', N'tr-TR', N'f91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'47e91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıç Üçlüsü', N'tr-TR', N'fa1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'48e91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıç Dörtlüsü', N'tr-TR', N'fb1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'49e91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıç Beşlisi', N'tr-TR', N'fc1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4ae91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıç Altılısı', N'tr-TR', N'fd1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4be91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıç Yedilisi', N'tr-TR', N'fe1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4ce91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıç Sekizlisi', N'tr-TR', N'ff1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4de91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıç Dokuzlusu', N'tr-TR', N'001fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4ee91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıç Onlusu', N'tr-TR', N'011fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'4fe91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıçların Uşağı', N'tr-TR', N'021fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'50e91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıçların Şövalyesi', N'tr-TR', N'031fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'51e91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıçların Kraliçesi', N'tr-TR', N'041fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'52e91d14-2038-ed11-91bc-cc15312ce92f', N'Kılıçların Kralı', N'tr-TR', N'051fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'53e91d14-2038-ed11-91bc-cc15312ce92f', N'Kupaların Ası', N'tr-TR', N'061fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'54e91d14-2038-ed11-91bc-cc15312ce92f', N'Kupa Ikilisi', N'tr-TR', N'071fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'55e91d14-2038-ed11-91bc-cc15312ce92f', N'Kupa Üçlüsü', N'tr-TR', N'081fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'56e91d14-2038-ed11-91bc-cc15312ce92f', N'Kupa Dörtlüsü', N'tr-TR', N'091fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'57e91d14-2038-ed11-91bc-cc15312ce92f', N'Kupa Beslisi', N'tr-TR', N'0a1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'58e91d14-2038-ed11-91bc-cc15312ce92f', N'Kupa Altılısı', N'tr-TR', N'0b1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'59e91d14-2038-ed11-91bc-cc15312ce92f', N'Kupa Yedilisi', N'tr-TR', N'0c1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5ae91d14-2038-ed11-91bc-cc15312ce92f', N'Kupa Sekizlisi', N'tr-TR', N'0d1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5be91d14-2038-ed11-91bc-cc15312ce92f', N'Kupa Dokuzlusu', N'tr-TR', N'0e1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5ce91d14-2038-ed11-91bc-cc15312ce92f', N'Kupa Onlusu', N'tr-TR', N'0f1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5de91d14-2038-ed11-91bc-cc15312ce92f', N'Kupaların Uşağı', N'tr-TR', N'101fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5ee91d14-2038-ed11-91bc-cc15312ce92f', N'Kupaların Şovalyesi', N'tr-TR', N'111fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'5fe91d14-2038-ed11-91bc-cc15312ce92f', N'Kupaların Kraliçesi', N'tr-TR', N'121fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'60e91d14-2038-ed11-91bc-cc15312ce92f', N'Kupaların Kralı', N'tr-TR', N'131fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'61e91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Ası', N'tr-TR', N'141fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'62e91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların İkilisi', N'tr-TR', N'151fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'63e91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Üçlüsü', N'tr-TR', N'161fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'64e91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Dörtlüsü', N'tr-TR', N'171fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'65e91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Beşlisi', N'tr-TR', N'181fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'66e91d14-2038-ed11-91bc-cc15312ce92f', N'Tilsımların Altılısı', N'tr-TR', N'191fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'67e91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Yedilisi', N'tr-TR', N'1a1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'68e91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Sekizlisi', N'tr-TR', N'1b1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'69e91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Dokuzlusu', N'tr-TR', N'1c1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'6ae91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Onlusu', N'tr-TR', N'1d1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'6be91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Uşağı', N'tr-TR', N'1e1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'6ce91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Sövalyesi', N'tr-TR', N'1f1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'6de91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Kraliçesi', N'tr-TR', N'201fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardNames] ([Id], [Name], [Culture], [CardId]) VALUES (N'6ee91d14-2038-ed11-91bc-cc15312ce92f', N'Tılsımların Kralı', N'tr-TR', N'211fd510-da32-ed11-91bb-cc15312ce92f')
GO

GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'c4733ba8-2838-ed11-91bc-cc15312ce92f', N'Bu kart önemli tercihler doğurur, yaşama büyük değişiklikler getirir. Burada, anahtar kelime fırsattır. Farklı bir çevre sizi bekliyor olacaktır. Bu kart, yeni başlangıçlara, fırsatlara işaret eder. Bu kartı seçen kişi, aşk konusunda hayatının fırsatını yakalayabilir.', N'tr-TR', N'd41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'c5733ba8-2838-ed11-91bc-cc15312ce92f', N'Hırsı, arzuyu temsil eder. Düşünce gücü önemlidir bunun yanında yetenek de kendini gösterir. Bu kartı seçen erkek, hırslı bir kişiliğe sahiptir. Kendine güveni yüksektir. Bu kartı seçen kadın da kendine güvenir ve karşısındaki erkek kendini ona adar. Bu kartı seçen kişi; moda veya serbest işle uğraşır.', N'tr-TR', N'd51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'c6733ba8-2838-ed11-91bc-cc15312ce92f', N'Aklınızdaki soruları temsil eder, gelecek kaygıları içerir. Koşullar değişkenlik gösterebilir. Sezgisel güçler kuvvetlidir. Bu kart, rastgele olacak değişimlere işaret eder. Bu kartı seçen kişi, içinden gelen sesi dinlemelidir. Burada kadın, hislerine dayanarak hareket eder, uyumludur ve mutludur. ', N'tr-TR', N'd61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'c7733ba8-2838-ed11-91bc-cc15312ce92f', N'Aşka işaret eder, evlilik kartı olabilir. Duygusallığa, aşka, sevgiye, sevilmeye dikkat çeker. Ayrıca bu kart, anneliği ifade eder. Bu kartı seçen kadın; duygusal, ruhsal, psikolojik, zihinsel ve ekonomik açıdan güçlerine önem verir. Dekorasyon ve yaratıcı işler kendini gösterir.', N'tr-TR', N'd71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'c8733ba8-2838-ed11-91bc-cc15312ce92f', N'Tüm planların gerçekleşeceğine işaret eder. Liderlik ve güç bu karttadır. Mantık ön plandadır. Bu kartı seçenin analiz yeteneği güçlüdür, sorumluluk sahibidir ve öz güveni yüksektir. İmparator, tam disiplinli bir babayı simgeler. Bu kişiler genelde yüksek makama gelecektir.', N'tr-TR', N'd81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'c9733ba8-2838-ed11-91bc-cc15312ce92f', N'Bu kart, tutuculuğa, düzenli aile yaşamına ve gelenekselliğe işaret eder. Evlilikte ise birlik ve beraberliği simgeler. Baş Rahip, içten gelen sesin dinlenmesini ifade eder.', N'tr-TR', N'd91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'ca733ba8-2838-ed11-91bc-cc15312ce92f', N'Bu karttaki kişi kendini iyi bilmelidir. Bu kart, evliliğin ve dengeli bir ilişkinin simgesidir. Tam bir sağlık kartı diyebiliriz bu kart için. Bu kart, ikizler burcuna adanmıştır. Bu yüzden mantık ön plandadır. Dengeli ve uyumlu olduğundan şanslı sayısı 6’dır. Duygusal ve zihinsel görüşler kişiyi mutlu eder.', N'tr-TR', N'da1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'cb733ba8-2838-ed11-91bc-cc15312ce92f', N'Hislerin ve isteklerin kontrolü anlamına gelir. Bu kart, sorunların çözüldüğüne ve sıkıntılardan zaferle çıkıldığına işaret eder. Bu kartı seçen kişiler, düşüncelerinin duyarlılığını, kendilerini sorgularlar. Savaş arabası, negatif düşüncelerden uzak, tehlikenin üstesinden gelen kişilere yöneliktir. Kartın ana teması, tüm zorluklardan başarıyla çıkmaktır.', N'tr-TR', N'db1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'cc733ba8-2838-ed11-91bc-cc15312ce92f', N'Ruhsal sevginin kullanımını simgeler. Güç, sevgi ve anlayıştan oluşur bu kart. Bu kartı seçen kişi kendini bilir, korku ve komplekslerinden arınır. Kibarca, sakin bir şekilde amacına ulaşır.', N'tr-TR', N'dc1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'cd733ba8-2838-ed11-91bc-cc15312ce92f', N'Bu kart akıl verme anlamını taşır. Kartı seçen kişi, kendi kararlarını tek başına ve mantıklı bir şekilde veren biridir. Kendi fikirlerine ve kararlarına güvenir. Sadece güvenilir birinin size yol göstermesine izin verirsiniz.', N'tr-TR', N'dd1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'ce733ba8-2838-ed11-91bc-cc15312ce92f', N'Ödüllere ve fırsatlara işarettir. Bu kartı seçen kişi olayları kendi lehine çevirebilir. Bu kart, başarıyı simgeler. Pek çok fırsat doğacak anlamına gelir.', N'tr-TR', N'de1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'cf733ba8-2838-ed11-91bc-cc15312ce92f', N'Dengeyi ve olumlu kararları simgeler. Özellikle hayatın dengesini kuran hareket, bu kartı ifade eder. Bu kartı seçen kişi; kalp, zihin, ruh sağlığı, materyalizm, iş ve hareket için eşit zaman garantisiyle hayatını düzenlemeye başlar. Bu kişi, adaleti sağlamak için iç dürtülerini kullanır. “Ne ekersen onu biçersin” adalet kartının temel anlamıdır. Ayrıca bu kart, okulu sembolize eder.', N'tr-TR', N'df1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'd0733ba8-2838-ed11-91bc-cc15312ce92f', N'Bu kart; vazgeçişi, daha iyiye ulaşmak için elindekini kurban etme anlamını taşır. Ruhsal açıdan kurban etme ise kendini ibadete adamayı gösterir. Bu inanç sistemi ve olaylara bakış açısı tamamen değişebilir. Mesela özel hayatı ve iş hayatı baştan aşağıya değişebilir. Kişi, bireysel ihtiyaçlarını öne alarak diğerlerine öncelik vermekten vazgeçebilir. Yalnız bu kart diğer olumsuz kartlarla birlikte görüldüğünde cezaevine girmek ya da herhangi bir konuda suçlanmak şeklinde yorumlanabilir.', N'tr-TR', N'e01ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'd1733ba8-2838-ed11-91bc-cc15312ce92f', N'Güzel, yeni başlangıçları ifade eder. Bu kart, değişiklik getiren bir açılım için çok iyi bir karttır. Yeni bir hayat ve farklı bir yaşam tarzı başlar. Eski olaylar bu kartı seçen kişiyi artık üzmez, duygusallığından kurtulmuştur. Üzüntüler arkada bırakılır, artık mutlu, sevgi dolu günler başlar.', N'tr-TR', N'e11ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'd2733ba8-2838-ed11-91bc-cc15312ce92f', N'Tam bir sanat kartıdır. Sabit bir durumu ifade eder. Bu kartı seçen kişiden orta bir yol bulunması için uzlaşmacı bir tavır beklenir. Ana temel, orta yolu bulmaktır, dengeyi kurmaktır. Bu kart, doğru uyuma işaret eder. Bu kartı seçen kişi, zor bir ikilem yaşarsa inançlarını pratiğe dökmek zorunda kalabilir.', N'tr-TR', N'e21ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'd3733ba8-2838-ed11-91bc-cc15312ce92f', N'Korku kartıdır. Bir karar verileceği zaman korkular, hatalara yol açar. Bu kart, yüzeysellik, materyalizm ve dış görünüşü simgeler. Bu kartı seçen kişi, para konusunda iyi bir işe sahip olabilir ve dış görünüşü bunda etkilidir. Bu kart, şatafat, güvence ve para için kurulan evlilikleri gösterir. Kendi çıkarı ve para için insanları kullanır.', N'tr-TR', N'e31ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'd4733ba8-2838-ed11-91bc-cc15312ce92f', N'Bu kartı seçen kişi eğer bir şeyin karşısında değilse bu kart güçlüklere işaret eder. Bu kartı seçen kişi için dürüstlüğü simgeler. Yoldan çıkarıcı eğilimler olacak ama doğru yol bulunacaktır. Kişisel bilgiyi arzuluyorsanız bu kart olumlu bir kart olabilir. Sağlık açısından hastalığa işaret edebilir. Yıkımlar daha çok iş, aile, ev ve psikolojik açıdan olabilir.', N'tr-TR', N'e41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'd5733ba8-2838-ed11-91bc-cc15312ce92f', N'Yıldız kartı, kartı seçen kişinin arzularını ve düşlerini ifade eder. Güven ile doğal yetenekleri aramayı gösterir. Olumlu, pozitif düşünce, iyi ruh ve fiziksel sağlığı simgeler. Meditasyon, bu kart ile sembolize edilir. Bu kartı seçen kişiyi, yeni yetenekler bulması, yaratıcı hedeflere ulaşması için destekleyin. ', N'tr-TR', N'e51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'd6733ba8-2838-ed11-91bc-cc15312ce92f', N'Ay kartı, kişinin kendinden ya da başkalarından kaynaklanan namussuzluğu temsil eder. Bu kartı seçen kişi, aldatılmış, kendine yalan söylüyor olabilir veya başkalarına karşı sahtekarca davranıyor olabilir. Ay, titreşimleri temsil ettiğinden ayrılığı, ani değişimleri ifade ediyor olabilir. Kartı seçen kişi, hayal kırıklığına uğrayabilir. Dikkatli olun, sizin bilmediğiniz çok şey etrafınızda yaşanıyor olabilir. Ayrıca ay kartı, telepati kartıdır. Bu kişinin sezgileri güçlüdür. Uyku ve rüya görmeyi de ifade ediyor olabilir. Telepatik aktiviteyi sembolize eder.', N'tr-TR', N'e61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'd7733ba8-2838-ed11-91bc-cc15312ce92f', N'Yeniden doğuş anlamını taşır. Bu kart, başarı ve mutluluğu getirir. Eğitimde, kariyer ve sanatsal alanda başarı sağlanacağı anlamına gelir. Aile ve aşk ele alındığında bir evlilik kartı olabilir. Sağlığın iyi olması demektir. Liderlik kavramı bu kartla bağdaştırılır. Sorunların üstesinden gelinir adeta yeniden doğulur. Bu yeniden doğuş fiziksel değişimle de kendini gösterir. Öz güven bu kartın simgesidir.', N'tr-TR', N'e71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'd8733ba8-2838-ed11-91bc-cc15312ce92f', N'Kişisel güçlerin daha çok farkına varılması ve kullanılması anlamına gelir. Bu kartı seçen kişi artık korkularından ve problemlerinden kurtulmuştur. Kendi gücünü ve enerjisini kullanarak mutluluğa kavuşur. Bu kartın ödülleri; ruh, akıl ve kalp arasındaki uyumdur. Kurtulma, bu kartı simgeler. Bu kartı seçen kişi, birinden kurtulmuş olabilir. Bu kurtuluş her alanda olabilir. Bu kişi, önemli konularda kendi iç sesini dinlemeli ve başkalarına aldırış etmemelidir. ', N'tr-TR', N'e81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'd9733ba8-2838-ed11-91bc-cc15312ce92f', N'Başarı, zafer ve rahat bir hayatı simgeler. Planların hayata geçirilmesi demektir. Bu kartı seçen kişi sorumluluk almayı bilir. Bu nedenle nasıl başarılı olacağını da öğrenir. Kendisine ve başkalarına saygı duyar. Kendinizi tanıma ve güzel ifade etme, maddi ve manevi mutluluğa ulaşmanızı sağlar. Bu kart, dünya seyahati anlamına da gelebilir. ', N'tr-TR', N'e91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'da733ba8-2838-ed11-91bc-cc15312ce92f', N'Asaların ası bir istek, girişim, enerji ya da cesaretin içinde yer aldığı bir başlangıçla karşılaşacağınızı ifade eder.', N'tr-TR', N'ea1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'db733ba8-2838-ed11-91bc-cc15312ce92f', N'Kartta simgelenen tüccar ve arkasındaki asa, başlamayı düşündüğünüz girişimler ile daha önce elde ettiğiniz başarıların dengesini anlatır. Tüccarın geleceğine güvenle bakan bakışları sizin içinde bulunduğunuz duruma işarettir. Amaçladığınız şey sizin için fazlasıyla anlamlıdır ve karttaki asa dünya gerçekliğini simgeleyerek, hedefiniz ile gerçekliğinizi dengelemektedir. Bu kart iş, okul ile ilgili ya da bir cevabın beklendiği aşamayı ifade eder.', N'tr-TR', N'eb1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'dc733ba8-2838-ed11-91bc-cc15312ce92f', N'Daha önce alınan riskler, gelişme olarak geri dönmektedir. Kart size başarı, gelişim, olumlu sonuçlar, paylaşım dolu çabalar ve yardımsever öğütleri haber vermektedir.', N'tr-TR', N'ec1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'dd733ba8-2838-ed11-91bc-cc15312ce92f', N'Kartınız size mutluluk getirecek bir başarının, hedefinize ulaşmanın getireceği keyfin habercisidir. Her ne konuda bir umdunuz varsa onun meyvelerini toplayacağınız an yakındır. Bu konular bir ilişki, iş, arkadaşlık ya da bir sağlık konusu olabilir.', N'tr-TR', N'ed1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'de733ba8-2838-ed11-91bc-cc15312ce92f', N'Bu kartın hakim olduğu duygu rekabet ve çekişmedir. Karşılaşma olasılığınız olan tartışma ve kışkırtmalara karşı güçlü durmanız faydanıza olacaktır. İş, aşk ya da aile yaşamınızda ciddi uyuşmazlıklar ve düşünce ayrılıkları yaşanabilir. Karşınızdakiler bencilce davranabilir.', N'tr-TR', N'ee1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'df733ba8-2838-ed11-91bc-cc15312ce92f', N'Başarı ve zaferi müjdeleyen bu kart, harcanılan emeklerin ödülleneceğini anlatır. Seçimlerinizin ya da çaba harcadığınız bir idealin daha iyi konumlarda çözümlenmesi beklenir. Azimli tavrınız ve güçlü isteğiniz yüzünüzü güldürecektir.', N'tr-TR', N'ef1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'e0733ba8-2838-ed11-91bc-cc15312ce92f', N'Girişimlerinizde inişler-çıkışlar yaşadığınız bir dönem ardından, düşüncelerinizde ısrarcı olmaya devam edebilirsiniz. Hatta kendi içinizdeki mücadele ciddi savunma örnekleri göstermenizi ve inatçı olmanızı beraberinde getirir.', N'tr-TR', N'f01ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'e1733ba8-2838-ed11-91bc-cc15312ce92f', N'Kendinize çizdiğiniz hedefe doğru oldukça yaklaşıyorsunuz. Hayalleriniz, umutlarınız ve duyduğunuz özlemler hızlı bir gerçekleşme dönemine girmiş durumda. Bu amaç doğrultusunda çok derin bağlılıklar yaşayabilirsiniz. Bu bağlılık aşk hayatınızla ilgili de olabilir. Spor gibi fiziksel anlamda sizi formda tutacak aktivitelere yönelebilirsiniz. Tüm bunların dışında uçakla gerçekleştireceğiniz bir yolculuk ile karşılaşabilirsiniz.', N'tr-TR', N'f11ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'e2733ba8-2838-ed11-91bc-cc15312ce92f', N'Daha önceki deneyimlerinizden ötürü biraz daha temkinli ve savunma halinde olduğunuz söylenebilir. Öyle ki, kendinizi savunmak için ciddi bir tartışma veya kavgaya bile hazırlıklısınız. Halihazırda mücadele ettiğiniz bir sorununuz varsa henüz halledemediğiniz için biraz dikkatli olmanızda fayda var. Geçmişteki bir ilişki ya da sağlık sorunu tekrar gündeme gelebilir, hazırlıklı olmalısınız.', N'tr-TR', N'f21ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'e3733ba8-2838-ed11-91bc-cc15312ce92f', N'Kapasitenizin ya da koşullarınızın çok üstüne bir işe giriştiğiniz ya da girişmeyi düşündüğünüz bir dönemdesiniz. Bu kart bazen bir baskıyı bazen de hırstan kaynaklanan başarısızlığı ifade etmektedir. Gerçekleştirmeyi düşündüğünüz girişimlerin başarısızlığa uğrama nedenlerinin başında yeterli zaman ayırmayışınız ve fazla vaat sunuyor olmanız geliyor. Sağlık açısından ise belkemiği, sırt, iskelet, kas ve bazen de kalbinizle ilgili sorunlar yaşayabilirsiniz. Sağlık sorunları ise kendinize fazlasıyla sorumluluk ve iş yüklemeyle alakalı olabilir. Kendinize fazla yüklenmemeniz faydanıza olacaktır.', N'tr-TR', N'f31ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'e4733ba8-2838-ed11-91bc-cc15312ce92f', N'Gayret, hırs, cesaret, enerji ve kişilik bu karta özgü unsurladır. Herkesin içinde fark edilmeyi ve doğal liderlik yeteneklerinizi sergilemeyi seviyorsunuz. Eğer ki, içinde bulunduğunuz yeni bir durum varsa bu konuda kararlı ve risk alır konumda olduğunuzu söylemek mümkün. Farklılığınızı öne çıkarmak için bu aralar antrenörlük, atletizm, satış ve öğretmenlik gibi konularda girişimlerde bulunabilirsiniz.', N'tr-TR', N'f41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'e5733ba8-2838-ed11-91bc-cc15312ce92f', N'Eğer odağınız bir kişi değilse, bu kart size hayatınızda meydana gelecek çok önemli olayları haber vermektedir. Kartın vurguladığı karakter özellikleri ise açık sözlü, komik, insanları seven bir profildir.', N'tr-TR', N'f51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'e6733ba8-2838-ed11-91bc-cc15312ce92f', N'İktidar ve sıcaklığın olağanüstü harmanı görülür. Başarı ve daha iyiye ulaşma iş ve özel hayatta motivasyonu getirmektedir. Sosyal hayat, politika, spor ve yaratıcılık isteyen alanlarda sürekli bir gelişim isteği vardır. Bu karta tiyatro, özgürlük ve kendini ifade etmeye yarayan her şey ilgi alanına dahildir. Aile ve arkadaşlarınız içinde sevilen ve imrenilen biri olmak bu tür isteklerden ve yeteneklerden ileri gelmektedir. Zaten bunlar büyük ölçüde başarılmış şeylerdir. ', N'tr-TR', N'f61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'e7733ba8-2838-ed11-91bc-cc15312ce92f', N'Asaların Kralı, dürüsttür ve çok yaratıcıdır. Eğlence için tartışmalı ortamlar bile yaratır, insanlara sataşmaktan keyif alır. Rekabet ortamını sever. İnsanlara sıcak davranır, yardımcı olmayı sever. Fazla hırslıdır, başarıya ulaşmak için elinden geleni yapar. Başka kişinin boyunduruğu altına giremez, kendi kendinin patronu olmak ister. Neşelidir, macerayı sever, sürekli yenilik peşindedir, girişimcidir. Gezmeyi, eğlenceyi ve sporu çok sever. Siyasette ve iletişimde iyidir. Evini seven bir erkek ve iyi bir kocadır. Meslek hayatında başarılıdır ve ileri görüşlüdür.', N'tr-TR', N'f71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'e8733ba8-2838-ed11-91bc-cc15312ce92f', N'Gücü temsil eden bu kart, kendinizi her zamankinden daha güçlü hissedeceğiniz bir döneme işaret eder. Kartta görülen dağlar bazı engelleri ifade etse de krallığın sembolizmi, bu sorunların çözülmeye başladığını ya da çözüleceğini ifade eder. Sorun her neyse zihin gücüyle zafere ulaşmanız mümkündür, üstelik komplike kurgulara ihtiyaç duymadan. Aksine bu süreçte gayet dürüst ve ilkeli bir dengede sorunları barışçıl bir şekilde çözmeniz mümkün.', N'tr-TR', N'f81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'e9733ba8-2838-ed11-91bc-cc15312ce92f', N'Duyguların yoğunluğu göze çarpmaktadır. Duygularınıza sırtınızı döndüğünüz, olan biteni tam anlamıyla göremediğiniz bu dönemde, içinde bulunduğunuz durumun netleşmesini beklediğiniz söylenebilir. Hareketten ziyade durgunluğun hakim bu süreçte bir dengeye ihtiyaç duyabilirsiniz. Dolayısıyla gerçeklikler ve duygularla yüz yüze gelmekten kaçınmaktasınız. Alacağınız kararları bir şekilde erteleme meyili görülmektedir. Ancak bu durum alınacak kesin bir kararla sona erecektir.', N'tr-TR', N'f91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'ea733ba8-2838-ed11-91bc-cc15312ce92f', N'Dramatik sahnelerin habercisi olan bu kart, hayatta bazen karşılaşmak zorunda olduğumuz talihsiz durumların her ne kadar atlatılabileceğini bilse de sıkıntılı günlere karşı uyarır. Şu anda hayatınızda bulunan bir durum sizden uzaklaşmaktadır. Şöyle düşünmek gerekir ki; size faydası olmayan bir şey ya da kişi kaybedilmelidir zaten. ', N'tr-TR', N'fa1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'eb733ba8-2838-ed11-91bc-cc15312ce92f', N'Hayatınızda atılıma geçmeyi düşündüğünüz herhangi bir şey için biraz dinlenmeye ve zamana ihtiyacınız olacaktır. Bir yandan da bunun geçici bir dönem olduğunu unutmamalısınız. Bir geri çekilmeyi ifade eden bu kart, çevreden soyutlanmayı bile beraberinde getirebilir.', N'tr-TR', N'fb1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'ec733ba8-2838-ed11-91bc-cc15312ce92f', N'Etrafınızdaki birini incitebilirsiniz. Birini incittiğinizde aslında kendinizi inciteceğinizi aklınızda bulundurmalısınız. Kartın ifade ettiği bir diğer anlam ise elde etmeyi istediğiniz şeylere ulaşma ve bunu yaparken biraz hile kullanabilme durumunuzun olmasıdır. Bu kurnazca tutum bir başkasının sizi yönlendirmesiyle de olabilir. ', N'tr-TR', N'fc1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'ed733ba8-2838-ed11-91bc-cc15312ce92f', N'Yaşadığınız korkunç ve hatta küçük düşürücü olaylardan sonra artık yeniden durumunuzu dengeleme zamanı gelmiştir. Bu dengeyi kurmanın tek yolu ise tüm bu yaşananlardan hızla uzaklaşmaktır. Kartınız size daha olumlu gelişmelerin haberini de vermektedir. Tüm zorlukları geride bırakıp ilerleyeceğiniz bir gelişmedir bu. Taşınma gibi fiziksel değişimler de bu dönemde karşınıza çıkar. Güçlüklerle savaşma dönemi geride kalmıştır.', N'tr-TR', N'fd1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'ee733ba8-2838-ed11-91bc-cc15312ce92f', N'Her ne kadar farkında olmasanız da kendi kendinizin en büyük düşmanı haline geldiğiniz bir döneme doğru giriyorsunuz. Bu dönem, ruhun ihtiyaçları üzerinde kazanılan zihinsel oyunlar ve güçlüklerle sonuçlanacaktır. Yakın geçmişinizdeki sorunların tekrarlanması olasıdır. Kendine ihanet etme durumu bu kartın en belirgin mesajıdır. Bu yüzden alacağınız kararlarda çok dikkatli olmalısınız. Kendinize zarar vermemek için içinde bulunduğunuz durumlara ve etrafınızdakilere karşı biraz daha dikkatli olmalısınız.', N'tr-TR', N'fe1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'ef733ba8-2838-ed11-91bc-cc15312ce92f', N'Kendi ihtiyaç ve düşüncelerinizi ikinci plana attığınız ve başkalarının sizi yönlendirmesine izin verdiğiniz bir dönemdesiniz. Daha önce kararlılıkla hareket ettiğiniz tutumunuz artık yerini kararsızlığa bırakmıştır. Bu durum sizin önceki tutumlarınızda çok fazla hırslı olmanızdan da ileri gelebilir. Dolayısıyla seçim yapmaktan korktuğunuz bir durumda olduğunuz bile söylenebilir. Düşünsel anlamda huzura ulaşmanız biraz zaman alacaktır. ', N'tr-TR', N'ff1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'f0733ba8-2838-ed11-91bc-cc15312ce92f', N'Psikolojiniz ile ilgili sıkıntılar baş gösterebilir;  bunalım, paranoya gibi. Bu sorunların kaynaklandığı kişi sevgiliniz ya da size ruhsal anlamda zarar verebilecek kadar sizi etkisi altında bulunduran biri olabilir. Karşılaşacağınız tehdit ve suçlamalara hazır olmalısınız. Bu durumlara göstereceğiniz zayıflık, sizi kendinizden utanma ve nefret etme gibi duygulara sürükleyebilir. ', N'tr-TR', N'001fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'f1733ba8-2838-ed11-91bc-cc15312ce92f', N'Umulmadık bir olumsuzluk ya da yürümeyen planlar görülebilir. Başarısızlıklar sizin geçmişte temelini attığınız bir durumdan kaynaklanabildiği gibi sizin dışınızdaki bir nedenden de kaynaklanabilir. ', N'tr-TR', N'011fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'f2733ba8-2838-ed11-91bc-cc15312ce92f', N'Bu kartın odağı uyum, çeviklik ve esnekliktir. Bu nedenle matematik, teknoloji, yabancı dil ve mühendislik gibi konularda kariyer edinme olasılığınız yüksek denebilir. Aynı anda iki işe birden sahip olma özelliğini de taşıyan bu kart, zihinsel meşguliyet ve oyunlardan hoşlandığınızı da ortaya koyar. Bu özellikler başladığınız bir projeden çabuk sıkılma ve yeni arayışlar içine girme sinyallerini de verir.', N'tr-TR', N'021fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'f3733ba8-2838-ed11-91bc-cc15312ce92f', N'Hiç beklemediğiniz olaylara hazır olun. Saldırgan, alaycı ve ukala tavırlar hakim olabilir. İş alanlarınız hukuk, mühendislik, ekonomi ve teknoloji gibi heyecan verici alanlar olabilir.', N'tr-TR', N'031fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'f4733ba8-2838-ed11-91bc-cc15312ce92f', N'Kendine hakim olma özelliğini vurgulayan bu kart, evli ya da herhangi bir beraberliği olanı ilişkisinde kendine fazla güvenen bir profille sunar. Kalbinden çok aklı onu yönetir. Keskin ve eleştirici, çözümleyici ve kavrayışı güçlü olabilir. Doğruluk, serbestlik, eşitlik ve eğitim en temel amaçları ifade eder. Gazetecilikten teknolojiye kadar birçok iletişim mecrası bu tip kişilerin ilgi alanıdır.', N'tr-TR', N'041fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'f5733ba8-2838-ed11-91bc-cc15312ce92f', N'Kılıçların Kralı, tam bir şampiyondur. Yaşadığı tüm zorlukların üstesinden gelir. Kararlarını, tecrübesine dayanarak sağlıklı bir şekilde verir. Dürüsttür, tarafsızdır. Genellikle eğitimci, doktor veya avukat olurlar. Olayları filozofik açıdan ele alır. Sevecen ve şefkatlidir. ', N'tr-TR', N'051fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'f6733ba8-2838-ed11-91bc-cc15312ce92f', N'Duygusal konuların başlangıcı olan Kupaların Ası, size yeni bir aşk ya da sevginin haberini getirir. Kendini anlamaya odaklı bu karttaki su imgesi, duyguların dışa yansımasını ve akışını anlatır.', N'tr-TR', N'061fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'f7733ba8-2838-ed11-91bc-cc15312ce92f', N'Mantık ve duyguyu dengeleyen bu kart, dostluk, aşk ya da herhangi bir ilişkideki paylaşımın önem ve dengesini ifade eder. Yani maddiyatla dengelenmiş bir aşk ya da dostluk gibi bir dengeden bahsedilir. Ayrıca semboller çift arasındaki çekimi de anlatmaktadır.', N'tr-TR', N'071fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'f8733ba8-2838-ed11-91bc-cc15312ce92f', N'Gelişen ve hızla ilerleyen bir ilişkinin habercisi olan bu kart, mutlu sonuçlar doğuracak ya da uzun vadeli ve ciddi bir ilişkinin temellerinin atılacağı bir dönemi ifade eder. Hayatınızda olan biriyle gelişen bir ilişki beklentisi ile hayatınızda biri yoksa doğru adayın çıkacağını söylemek mümkündür. Hatta evlilik, nişan ya da söz gibi planların yapılacağı bir süreç başlamaktadır. Diğer yandan başarı ile sonuçlanmış bir mezuniyet, kariyerde yükseliş, doğum, önemli bir gününü yıldönümü ya da bir iş sahibi olma gibi gelişmeler de bu kartın verdiği haberler içindedir. Dolayısıyla sahip olduğunuz yeteneklerin en olumlu yanlarıyla tanışmanızdan söz edilebilir.', N'tr-TR', N'081fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'f9733ba8-2838-ed11-91bc-cc15312ce92f', N'Artık dünyevi olaylardan uzaklaştığınız, duygusal anlamda da çaba harcamaktan yorulduğunuz bir dönemdesiniz. Dolayısıyla yeni ortam ve durumlara kapalı olduğunuzu ifade eden bu kart, kabuğunuza çekileceğiniz bir dönemin yaklaştığını söyler. İşin iyi yanı, bu dönemin işinizi hatta yaşam tarzınızı yeniden gözden geçirmeye müsait olduğudur. ', N'tr-TR', N'091fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'fa733ba8-2838-ed11-91bc-cc15312ce92f', N'Bir konunun bitmesine ilişkin aldığınız kararların ve bu kararın getirdiği kayıpların habercisi olan bu kart, bitişlerin biraz can sıkıcı ve kırıcı olması yönünde sizi uyarmaktadır. Yaşayacağınız bu kayıpların üzerinde fazla durmamalı ve umutsuzluğa kapılmamalısınız. Hala elinizde bulunan değerlere odaklanmanız daha doğru olacaktır. Bazen bu kayıpların daha sonra kazanca dönüşebileceğini hatırlatan kart, aynı zamanda büyük değişimlerin de sözcüsüdür. ', N'tr-TR', N'0a1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'fb733ba8-2838-ed11-91bc-cc15312ce92f', N'Çocukluğunuza dair mutlu anılar, geçmişten gelen hayalleriniz ve mutlu bir araya gelişler bu kartın vazgeçilmez mesajlarıdır. Duygusal ve ailevi konular çok güzel bir uyum içine girmektedir. Evinize alacağınız yeni eşyalar olabilir veya evinizde vereceğiniz eğlenceli toplantılar bu dönemde yaşanabilir. Özel gün kutlamaları da bu dönemin içindedir. ', N'tr-TR', N'0b1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'fc733ba8-2838-ed11-91bc-cc15312ce92f', N'Sizi tetikleyen ve motive eden şeylerin etkisinden uzak hatta onların ne olduğunu bile bilmediğiniz bir dönemdesiniz. Gerçekte var olmayan sadece hayal ürünü olan şeyleri de ifade eden bu kart, bu hayaller için fazla zaman harcadığınızı da bildirmektedir. Tüm bunlara sizi dış dünyadan koparan aşırı alkol tüketimi ya da bilgisayar ve televizyon gibi unsurlar neden olabilir. ', N'tr-TR', N'0c1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'fd733ba8-2838-ed11-91bc-cc15312ce92f', N'Hayatınızda bazı vazgeçişler ortaya çıkabilir. Yeni bir anlam ve amacın peşine düşebilirsiniz. Duygusal ve ailevi konular geride kalmaya başlamıştır ve ilişkileriniz zayıflayıp kopma noktasına dahi gelebilir. Toplum hayatı ile ters düşerek kendiniz için yeni bir araştırmaya başlamayı tercih edebilirsiniz. ', N'tr-TR', N'0d1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'fe733ba8-2838-ed11-91bc-cc15312ce92f', N'Hayatın eğlenceli yüzüyle yeniden buluştuğunuzu müjdeleyen bu kart, size bol para ve sağlık getirmektedir. Yaşamdan keyif almak için tüm şartlar tamamlanmıştır. ', N'tr-TR', N'0e1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'ff733ba8-2838-ed11-91bc-cc15312ce92f', N'Aile, uyum ve gerçek sevginin yoğunluğu söz konusudur. İçinde bulunduğunuz durum olumluluğunu korumaya devam edecektir. İlişkilerde sürekliliği sağlamak adına evlilik ya da ortaklıklar gibi durumlar ortaya çıkabilir.', N'tr-TR', N'0f1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'00743ba8-2838-ed11-91bc-cc15312ce92f', N'Duygular dünyasında huzur ve mutluluk veren, cezbeden ve karşılık bulacağınız günler sizi bekliyor. Bu kart kibarlık, sempati, sanat yeteneği, hasiyet, hayal gücü, sevme ve önsezinin sizinle olduğunu ifade eder. Özellikle sanatla ilgili atacağınız adımlarda disiplini elden bırakmamanız gerekiyor. ', N'tr-TR', N'101fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'01743ba8-2838-ed11-91bc-cc15312ce92f', N'Heyecan ve önseziyi içinde barındıran bir kişiliği ifade eden bu kart, hassasiyeti ve sanat eğilimini de ifade eder. Aklınızdan geçen olay romantizm ve duygusallık kuşağındadır denebilir.', N'tr-TR', N'111fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'02743ba8-2838-ed11-91bc-cc15312ce92f', N'Çok hassas, sezgisi güçlü, karşısındaki fazlasıyla önemseyen bir profil çizen özellikler bu kartın odak noktasıdır. Dolayısıyla duyguların çevrelediği bu özellikler duygusal çalkantılara zemin hazırlamaktadır. ', N'tr-TR', N'121fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'03743ba8-2838-ed11-91bc-cc15312ce92f', N'Kupaların Kralı, hayatın anlamını bilir, zekidir. Samimi bir kişiliği vardır. Kart üzerinde dalgalar halinde akan su, yaptıklarının ne kadar anlamlı olduğunu ve duygusal yönünü simgeler. Hukuk, tıp ve danışmanlık ilgi alanlarıdır. Ayrıca sanatla ilgilenir, yaratıcıdır. Psikolojiye meraklıdır. Duygusal enerjisi yüksektir, inançlıdır, maneviyata önem verir. Hayal gücü kuvvetlidir. Sorumluluk sahibidir, ilk bakışta sessiz görünür ama zamanla samimiyeti ortaya çıkar. ', N'tr-TR', N'131fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'04743ba8-2838-ed11-91bc-cc15312ce92f', N'Somut olayların habercisi olan tılsımların ası, sabreden ve bilgi biriktirenlerin mükafatına ulaşacağını ifade eder. Hayatınızdaki herhangi bir başlangıç ki bunlar; iş, mülkiyet, bir şeye sahip olma ya da satın alma olabilir, gerçekliği olan sonuçlara işaret eder.', N'tr-TR', N'141fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'05743ba8-2838-ed11-91bc-cc15312ce92f', N'Hayattaki değişikliklerin sonsuz olduğunu ifade eden bu kart, yaşamınız süresince karşılaşacağınız tüm değişimlerin normal olduğunu ve bu tip dalgalanmalar hazırlıklı olmanız gerektiğini hatırlatır. Yaşadığınız olaylar sizi atlattığınızı düşündüğünüz noktalara geri döndürebilir. Genellikle sizin elinizde olmayan bu akışın hayatınıza bir anlam ve hareket kattığını düşünmelisiniz. Günlük yaşamda farklı sorumluluklar, parayı değerlendirme ya da halihazırda var olan iş ya da bir değeri riske atarak yeni başlangıçlara yol alma da bu değişimlerin içindedir. Dolayısıyla alacağınız tutum esnek olmalıdır çünkü hayat iniş ve çıkışları içinde barındırır.', N'tr-TR', N'151fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'06743ba8-2838-ed11-91bc-cc15312ce92f', N'Tılsımların Üçlüsü, iş, yetenek, eğitim ve parasal konulardaki gelişmeyi gösterir. Bu kartta, yetenekleri ile çalışan usta bir zanaatkarı görürüz. Bir caminin iç kısmındaki işçiliği, hayattaki bir olayı başarmayı, beceriyi gösterir. Bu kart aynı zamanda, terfi, tanınma, ün, derece ve sertifika gibi seçilen bir alanda başarabilme gücünü ifade eder.', N'tr-TR', N'161fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'07743ba8-2838-ed11-91bc-cc15312ce92f', N'Kararlılığınızın ve ekonomik gücünüzün göstergesi olan bu kart, paranın güçle eşdeğer olduğunu aktarır. Parayı elinizde tutmanızın olumlu etkilerini yaşayabilirsiniz. Diğer yandan ilişkilerde sahiplenmeyi ifade eden kartınız, genel olarak bencil ve kapalı tutuma karşı bireysel kontrol ve öz güveni temsil etmektedir.', N'tr-TR', N'171fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'08743ba8-2838-ed11-91bc-cc15312ce92f', N'Fiziksel ya da ruhsal açıdan sorunların yaşanması, bazı kayıpların ortaya çıkması beklenen olumsuz gelişmelerdir. Bunların bencilliğin bir cezası olarak yorumlanması da muhtemeldir. Parasal konularda ise gelir düşüklüğünün bir göstergesi olan bu kart, aşk hayatında da yalnızlığın habercisidir. Önceden güvendiğiniz şeylere olan inancınızı da kaybedebilirsiniz. ', N'tr-TR', N'181fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'09743ba8-2838-ed11-91bc-cc15312ce92f', N'Size sıkıntı yaratan olayların bitmesi ve parasal anlamda yaşayacağınız bir ferahlamanın dengesi göze çarpıyor. Bu dönemde yapılacak yatırımlar, katlanarak geri dönecektir. Yatırımı sadece iş anlamında düşünmemek gerekir. Bir kişiye hatta eğitim alan birine yapılacak yardım da olabilir bu. Dolayısıyla sadece parasal anlamda bir kar değil, manevi anlamda da iç huzur sağlayacak karlılık da söz konusudur. ', N'tr-TR', N'191fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'0a743ba8-2838-ed11-91bc-cc15312ce92f', N'Başarısızlık ve tatminsizlik duygusu hakim olabilir bu dönemde. Çok fazla önem verilen bir şey, hissettiğiniz bir memnuniyet duygusu veya bir başarıyı kaybetme olasılığınız var. İçinizden bir his sizi kariyer, eğitim, maddi ve manevi amaçlarla ilgili daha ileri hedeflere doğru itiyor olabilir. ', N'tr-TR', N'1a1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'0b743ba8-2838-ed11-91bc-cc15312ce92f', N'Herhangi bir konuda eğitime hazır olduğunuz söylenebilir. Kendinizi keşfetme, bir iş ya da meslek için eğitilme, bu kartta var olan ihtimallerden bazılarıdır. Bu bir şey üzerinde çalışma şeklinde de olabilir. Daha iyi koşullarda çalışma ya da daha fazla para kazanma için kararlı olduğunuzun habercisi olan bu kart, etkinliği yüksek kişilerle tanışacağınızı da müjdeler. Şimdiden kuracağınız tüm ilişkiler ileride size parasal olarak da katlanarak geri dönecektir.', N'tr-TR', N'1b1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'0c743ba8-2838-ed11-91bc-cc15312ce92f', N'Parasal kazanç, güven artışı, kararlılık, kendine güven ve bağımsızlık hakimdir. Hayatın güzel şeylerinden yalnız başına zevk alma, bahçe ve ev sevgisi de bu kartın sunduğu haberlerdendir.', N'tr-TR', N'1c1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'0d743ba8-2838-ed11-91bc-cc15312ce92f', N'Bu kart sağlam ve iyi koşulların habercisidir. Aklınızdan geçen fikirlerde kararlılık ve güven hakimdir. Bu kart aynı zamanda hayatınızın bir aşamasından diğerine geçişi de ifade eder. Bu ilişki durumunda bekarlıktan evliliğe, işsizlikten iş sahibi olmaya gibi birçok konuda olabilir. ', N'tr-TR', N'1d1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'0e743ba8-2838-ed11-91bc-cc15312ce92f', N'Sabır ve diğerlerinin görüşlerine saygı, bu kartın ifade ettiği özelliklerdir. Her şeyden ders alınabileceğini söyleyen bu kart, öğretici yapıdaki mesajlarla doludur. Açık fikirlilik tüm bu öğretileri doğru bir şekilde almayı sağlayacaktır.', N'tr-TR', N'1e1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'0f743ba8-2838-ed11-91bc-cc15312ce92f', N'Projelerinize yapılacak maddi ya da manevi yardımlarla paylaşıma gidebilirsiniz. Para ve sağduyuyu ifade eden bu kart, güvenilirlik, kararlılık ve dürüstlüğü anlatır. Hayatınızda temel ve rutin mutlulukları istemeniz, para ve herhangi bir şeye sahip olma eğiliminizle örtüşür. Çok konuşkan olmamayı anlatan bu kart, tercih edilen işleri endüstri sektörü, makineler, fabrikalar ve matematik bilgisi isteyen alanlarla ifade etmiştir.', N'tr-TR', N'1f1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'10743ba8-2838-ed11-91bc-cc15312ce92f', N'Koruyuculuk, tecrübe ve ihtiyatlılığı ifade eden bu kart, kişinin kendi yarattığı sağlamlığa daha fazla güvendiğini söyler. Finansal özgürlük söz konusu olduğunda, oldukça sabırlı ve metin olmayı anlatır. Meslek hayatında başarı, lükse olan ilgi, güzel bir ortam, sevdiği kişi ya da şeye karşı sahiplik duygusu yine kartın olmazsa olmaz unsurlarıdır. ', N'tr-TR', N'201fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'11743ba8-2838-ed11-91bc-cc15312ce92f', N'Tılsımların Kralı, azimlidir, çok çalışkandır. Maddi açıdan durumu iyidir. Kazanmayı ve harcamayı iyi bilir. Doğayı ve toprağı sever. Gözüyle görmediği şeylere inanmaz, şüpheyle yaklaşır. Tutucudur, geleneklerine bağlıdır. Çevresinden bağlılık ve saygı görmek ister. Sevgisini para harcayarak gösterir.', N'tr-TR', N'211fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'4bf2ea4a-2d38-ed11-91bc-cc15312ce92f', N'This card brings important choices, brings great changes in life. The keyword here is opportunity. A different environment will be waiting for you. This card indicates new beginnings, opportunities. The person who chooses this card can seize the opportunity of a lifetime in love.', N'en-US', N'd41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'4cf2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It represents ambition, desire. The power of thought is important, besides, talent also shows itself. The man who chooses this card has an ambitious personality. He has high self-confidence. The woman who chooses this card is also self-confident and the man opposite is devoted to her. The person who chose this card; engages in fashion or freelance business.', N'en-US', N'd51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'4df2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It represents the questions in your mind, includes future concerns. Conditions may vary. Intuitive powers are strong. This card represents changes that will be random. The person who chooses this card should listen to the voice coming from within. Here, the woman acts on the basis of her feelings, is harmonious and happy.', N'en-US', N'd61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'4ef2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It indicates love, it can be a marriage card. It draws attention to sensuality, love, affection, being loved. Also, this card represents motherhood. The woman who chose this card; gives importance to their emotional, spiritual, psychological, mental and economic strength. Decoration and creative works show themselves.', N'en-US', N'd71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'4ff2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It indicates that all plans will come true. Leadership and power are in this card. Logic is in the foreground. The person who chooses this card has strong analytical skills, is responsible and has high self-confidence. The emperor symbolizes a fully disciplined father. These people will often rise to high office.', N'en-US', N'd81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'50f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'This card indicates conservatism, orderly family life and tradition. In marriage, it symbolizes unity and togetherness. High Priest means listening to the inner voice.', N'en-US', N'd91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'51f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The person on this card should know himself well. This card is a symbol of marriage and a balanced relationship. We can say that this card is a complete health card. This card is dedicated to Gemini. That''s why logic is at the forefront. The lucky number is 6 as it is balanced and harmonious. Emotional and mental views make the person happy.', N'en-US', N'da1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'52f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It means control of feelings and desires. This card indicates that problems are solved and that troubles are overcome with victory. People who choose this card question the sensitivity of their thoughts, themselves. The chariot is for those who overcome danger, free from negative thoughts. The main theme of the card is to get out of all difficulties successfully.', N'en-US', N'db1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'53f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It symbolizes the use of spiritual love. This card consists of power, love and understanding. The person who chooses this card knows himself and gets rid of his fears and complexes. He calmly achieves his goal.', N'en-US', N'dc1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'54f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'This card means giving mind. The person who chooses the card is someone who makes his own decisions alone and logically. He trusts his own ideas and decisions. You only let a trusted person guide you.', N'en-US', N'dd1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'55f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Indicates rewards and opportunities. The person who chooses this card can turn the events in his favor. This card symbolizes success. It means that many opportunities will arise.', N'en-US', N'de1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'56f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It symbolizes balance and positive decisions. Especially the movement that establishes the balance of life expresses this card. The person who chose this card; heart, mind, mental health, materialism, he begins to organize his life with the guarantee of equal time for work and action. This person uses their inner urge to get justice. “You reap what you sow” is the basic meaning of the justice card. Also, this card symbolizes school.', N'en-US', N'df1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'57f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'This card; Giving up means sacrificing what you have in order to achieve the better. Spiritual sacrifice, on the other hand, shows devotion to worship. This belief system and perspective on events can completely change. For example, his private life and business life can change completely. The person may stop giving priority to others by putting their individual needs first. However, when this card is seen together with other negative cards, it can be interpreted as going to prison or being accused of anything.', N'en-US', N'e01ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'58f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Beautiful signifies new beginnings. This card is a very good card for a change-making expansion. A new life and a different lifestyle begins. The old events no longer upset the person who chose this card, he got rid of his emotionality. Sadness is left behind, happy, loving days begin.', N'en-US', N'e11ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'59f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It''s a true art card. Indicates a steady state. A conciliatory attitude is expected from the person who chooses this card to find a middle ground. The main foundation is to find the middle way, to establish the balance. This card indicates correct fit. The person choosing this card may have to put their beliefs into practice if they face a difficult dilemma.', N'en-US', N'e21ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'5af2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Horror card. Fears lead to mistakes when a decision has to be made. This card symbolizes superficiality, materialism, and appearance. The person who chooses this card may have a good job in money, and his appearance is effective in this. This card represents marriages for pomp, security, and money. He uses people for his own gain and money.', N'en-US', N'e31ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'5bf2ea4a-2d38-ed11-91bc-cc15312ce92f', N'If the person choosing this card is not against something, this card indicates difficulties. It symbolizes honesty for the person who chooses this card. There will be perverse tendencies, but the right path will be found. This card can be a positive card if you desire personal information. In terms of health, it may indicate illness. Destructions may be more in terms of work, family, home and psychological.', N'en-US', N'e41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'5cf2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The star card expresses the wishes and dreams of the person who chose the card. It shows the search for natural talents with confidence. It symbolizes positive, positive thinking, good mental and physical health. Meditation is symbolized by this card. Encourage the person who chooses this card to find new talents and achieve creative goals.', N'en-US', N'e51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'5df2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The Moon card represents dishonesty caused by one''s self or others. The person choosing this card may be deceived, lying to himself, or behaving dishonestly towards others. Since the Moon represents vibrations, it may represent separation, sudden changes. The person who chooses the card may be disappointed. Be careful, there may be many things happening around you that you don''t know about. Also, the moon card is the telepathy card. This person has a strong intuition. It can also refer to sleep and dreaming. It symbolizes telepathic activity.', N'en-US', N'e61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'5ef2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It means rebirth. This card brings success and happiness. It means success in education, career and artistic field. It can be a marriage card when dealing with family and love. It means good health. The concept of leadership is associated with this card. Problems are overcome and they are born again. This rebirth also manifests itself through physical change. Confidence is the symbol of this card.', N'en-US', N'e71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'5ff2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It means greater awareness and use of personal powers. The person who chooses this card is now free from his fears and problems. He attains happiness by using his own strength and energy. The rewards of this card; It is the harmony between the soul, the mind and the heart. Relief symbolizes this card. The person who chose this card may have gotten rid of someone. This salvation can be in any field. This person should listen to his own inner voice in important matters and should not care about others.', N'en-US', N'e81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'60f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It symbolizes success, victory and a comfortable life. It means realizing plans. The person who chooses this card knows how to take responsibility. Therefore, he also learns how to be successful. Respects himself and others. Knowing yourself and expressing yourself beautifully allows you to reach material and spiritual happiness. This card can also mean world travel.', N'en-US', N'e91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'61f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The ace of wands signifies that you will encounter a beginning involving desire, initiative, energy or courage.', N'en-US', N'ea1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'62f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The merchant symbolized on the card and the scepter behind it tell the balance of initiatives you are considering starting and your previous achievements. The gaze of the merchant that looks at his future with confidence is a sign of the situation you are in. What you aim for is very meaningful to you and the wand on the card symbolizes the reality of the world, balancing your aim with your reality. This card represents the stage at work, school, or where an answer is awaited.', N'en-US', N'eb1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'63f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Risks taken earlier return as progress. The card informs you of success, improvement, positive results, shared efforts and helpful advice.', N'en-US', N'ec1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'64f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Your card is a harbinger of success that will bring you happiness and the joy of reaching your goal. Whatever you have hope for, the moment is near when you will reap the fruits of it. These issues could be a relationship, a job, a friendship, or a health issue.', N'en-US', N'ed1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'65f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The emotion dominated by this card is competition and strife. It will be to your advantage to stand strong against the arguments and provocations that you may encounter. You may experience serious conflicts and differences of opinion in your work, love or family life. Others may act selfishly.', N'en-US', N'ee1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'66f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Heralding success and victory, this card tells that the effort will be rewarded. It is expected that your choices or an ideal you strive for will be resolved in better positions. Your determined attitude and strong will will put a smile on your face.', N'en-US', N'ef1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'67f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'After a period of ups and downs in your initiatives, you can continue to be persistent in your thoughts. In fact, the struggle within yourself brings you to show serious defense examples and to be stubborn.', N'en-US', N'f01ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'68f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'You are getting very close to the goal you have set for yourself. Your dreams, hopes and aspirations have entered a period of rapid realization. In line with this purpose, you can experience very deep commitments. This commitment can also be related to your love life. You can turn to activities that will keep you physically fit, such as sports. Apart from all these, you may encounter a journey by plane.', N'en-US', N'f11ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'69f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It can be said that you are a little more cautious and defensive due to your previous experiences. So much so that you are even prepared for a serious argument or fight to defend yourself. If you have a problem that you are already struggling with, it is useful to be a little careful as you have not been able to handle it yet. A past relationship or health problem may come up again, you should be prepared.', N'en-US', N'f21ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'6af2ea4a-2d38-ed11-91bc-cc15312ce92f', N'You are in a period when you are undertaking or considering undertaking a business that is beyond your capacity or conditions. This card sometimes represents pressure and sometimes failure due to greed. The main reasons for the failure of the initiatives you intend to realize are that you do not spare enough time and offer too much promise. In terms of health, you may experience problems with your spine, back, skeleton, muscles and sometimes your heart. Health problems, on the other hand, may be related to putting too much responsibility and work on yourself. It will be in your best interest not to overload yourself.', N'en-US', N'f31ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'6bf2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Diligence, ambition, courage, energy and personality are the elements unique to this card. You like to be noticed in public and show off your natural leadership abilities. If there is a new situation you are in, it is possible to say that you are determined and in a risk-taking position. In order to highlight your difference, you can take initiatives in areas such as coaching, athletics, sales and teaching these days.', N'en-US', N'f41ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'6cf2ea4a-2d38-ed11-91bc-cc15312ce92f', N'If your focus is not on the person, this card foretells very important events that will occur in your life. The character traits highlighted by the card are an outspoken, funny, people-loving profile.', N'en-US', N'f51ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'6df2ea4a-2d38-ed11-91bc-cc15312ce92f', N'An extraordinary blend of power and warmth is seen. Success and achieving better brings motivation in business and private life. There is a desire for continuous development in areas that require social life, politics, sports and creativity. Theater, freedom, and anything that serves self-expression are included in this card. Being loved and envied among family and friends comes from such desires and abilities. These are things that have already been accomplished to a large extent.', N'en-US', N'f61ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'6ef2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The King of Wands is honest and very creative. He even creates controversial environments for entertainment, enjoys teasing people. He likes a competitive environment. He treats people warmly and likes to help. He is very ambitious and does his best to achieve success. He cannot be dominated by another person, he wants to be his own boss. He is cheerful, loves adventure, is constantly in search of innovation, is entrepreneurial. He loves traveling, entertainment and sports. He is good at politics and communication. He is a home-loving man and a good husband. He is successful in his professional life and is forward-thinking.', N'en-US', N'f71ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'6ff2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Representing power, this card indicates a time when you will feel stronger than ever before. Although the mountains seen on the card represent some obstacles, the symbolism of the kingdom means that these problems are starting to be resolved or will be resolved. Whatever the problem is, it is possible to achieve victory with the power of mind, and without the need for complicated setups. On the contrary, in this process, it is possible to solve problems peacefully in a very honest and principled balance.', N'en-US', N'f81ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'70f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The intensity of the emotions is striking. It can be said that in this period when you turn your back on your emotions and cannot fully see what is happening, you are waiting for the situation you are in to become clear. You may need a balance in this process where stillness prevails rather than movement. So you avoid coming face to face with realities and emotions. There is a tendency to postpone the decisions you will make in some way. However, this situation will end with a definite decision to be taken.', N'en-US', N'f91ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'71f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'A harbinger of dramatic scenes, this card warns of troubled days, even though it knows that the unfortunate situations that we sometimes have to face in life can be overcome. Something in your life right now is moving away from you. It is necessary to think that; Something or a person that is of no use to you must be lost anyway.', N'en-US', N'fa1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'72f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'You will need some rest and time for anything you are thinking of making a breakthrough in your life. On the other hand, you should remember that this is a temporary period. Representing a retreat, this card can even bring about isolation from the environment.', N'en-US', N'fb1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'73f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'You can hurt someone around you. You have to keep in mind that when you hurt someone, you are actually hurting yourself. Another meaning of the card is that you can reach the things you want to achieve and use a little cheating while doing this. This cunning attitude can also be caused by someone else''s guidance.', N'en-US', N'fc1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'74f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'After the terrible and even humiliating events you''ve been through, it''s time to balance your situation again. The only way to establish this balance is to quickly get away from all these experiences. Your card also gives you the news of more positive developments. This is a development where you will leave all difficulties behind and move forward. Physical changes such as moving also occur during this period. The time of fighting hardships is over.', N'en-US', N'fd1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'75f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Although you may not be aware of it, you are entering a period where you become your own worst enemy. This period will result in mental games and challenges over the soul''s needs. Problems in your recent past are likely to recur. Self-betrayal is the most obvious message of this card. That''s why you have to be very careful in your decisions. In order not to harm yourself, you should be a little more careful about the situations you are in and those around you.', N'en-US', N'fe1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'76f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'You are in a period where you put your own needs and thoughts on the back burner and allow others to lead you. Your attitude, which you acted with determination before, has now left its place to indecision. This may also be due to your being too ambitious in your previous attitudes. Therefore, it can even be said that you are in a situation where you are afraid to make a choice. It will take some time for you to reach mental peace.', N'en-US', N'ff1ed510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'77f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Problems with your psychology may arise; like depression, paranoia. The person from whom these problems originate may be your lover or someone who influences you enough to harm you spiritually. You must be prepared for threats and accusations you will face. The weakness you will show in these situations can lead you to feelings of shame and self-loathing.', N'en-US', N'001fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'78f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Unexpected negativity or unworkable plans can be seen. Failures can be caused by a situation that you have laid the foundation for in the past, or they can be caused by a reason outside of you.', N'en-US', N'011fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'79f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The focus of this card is adaptability, agility and flexibility. For this reason, it can be said that you have a high probability of pursuing a career in subjects such as mathematics, technology, foreign language and engineering. This card, which has the feature of having two jobs at the same time, also reveals that you enjoy mindfulness and games. These features also give the signals of getting bored quickly from a project you have started and entering into new pursuits.', N'en-US', N'021fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'7af2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Get ready for unexpected events. Aggressive, sarcastic and arrogant attitudes may prevail. Your job fields may be exciting fields such as law, engineering, economics and technology.', N'en-US', N'031fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'7bf2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Emphasizing self-control, this card presents the married or in a relationship with a self-confident profile. His mind rules him more than his heart. He can be sharp and critical, analytical and insightful. Righteousness, freedom, equality and education express the most basic goals. Many communication channels, from journalism to technology, are the interests of these people.', N'en-US', N'041fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'7cf2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The King of Swords is a total champion. He overcomes all the difficulties he experiences. He makes his decisions in a healthy way based on his experience. He is honest and impartial. They often become educators, doctors or lawyers. It deals with the events from a philosophical point of view. He is kind and compassionate.', N'en-US', N'051fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'7df2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The Ace of Cups, the beginning of emotional matters, brings you news of a new love or affection. The water image on this card, focused on self-understanding, describes the outward reflection and flow of emotions.', N'en-US', N'061fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'7ef2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Balancing logic and emotion, this card represents the importance and balance of sharing in friendship, love or any relationship. In other words, a balance such as love or friendship balanced with materialism is mentioned. The symbols also describe the attraction between the couple.', N'en-US', N'071fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'7ff2ea4a-2d38-ed11-91bc-cc15312ce92f', N'This card, which is a harbinger of a developing and rapidly progressing relationship, represents a period that will bring happy results or the foundations of a long-term and serious relationship will be laid. It is possible to say that if there is no one in your life with the expectation of a developing relationship with someone in your life, the right candidate will come out. In fact, a process begins in which plans such as marriage, engagement or promise are made. On the other hand, developments such as a successful graduation, career advancement, birth, anniversary of an important day or having a job are also included in the news given by this card. Therefore, it can be said that you meet the most positive aspects of your talents.', N'en-US', N'081fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'80f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'You are now in a period when you get away from worldly events and get tired of making an emotional effort. Therefore, this card, which expresses that you are closed to new environments and situations, tells that a period of withdrawal is approaching. The good thing is that this period is apt to reconsider your work and even your lifestyle.', N'en-US', N'091fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'81f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'This card, which is the harbinger of the decisions you make regarding the ending of a topic and the losses that this decision brings, warns you that the endings will be a bit annoying and hurtful. You should not dwell too much on these losses you will experience and you should not despair. It would be better to focus on the values you still have. Reminding that sometimes these losses can turn into gains later, the card is also the spokesperson for big changes.', N'en-US', N'0a1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'82f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Happy memories of your childhood, dreams from the past and happy reunions are the indispensable messages of this card. Emotional and family issues go together very nicely. There may be new items you will buy for your home or fun meetings that you will have in your home may be experienced during this period. Special day celebrations are also included in this period.', N'en-US', N'0b1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'83f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'You are in a period where you are far from the influence of the things that trigger and motivate you, and you don''t even know what they are. This card, which also refers to things that do not exist in reality, are only imaginary, and it also states that you spend too much time on these dreams. All these can be caused by factors such as excessive alcohol consumption or computers and televisions that disconnect you from the outside world.', N'en-US', N'0c1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'84f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'There may be some setbacks in your life. You can pursue a new meaning and purpose. Emotional and family issues are starting to fall behind, and your relationships may even weaken and break apart. You may prefer to start a new research for yourself by contradicting the social life.', N'en-US', N'0d1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'85f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'This card, which heralds that you are reunited with the fun side of life, brings you plenty of money and health. All conditions are fulfilled to enjoy life.', N'en-US', N'0e1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'86f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'There is the intensity of family, harmony and true love. The situation you are in will continue to maintain its positivity. In order to ensure continuity in relationships, situations such as marriage or partnerships may arise.', N'en-US', N'0f1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'87f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'In the world of emotions, the days that bring peace and happiness, attract and reciprocate are waiting for you. This card expresses kindness, sympathy, artistic talent, dignity, imagination, love and intuition being with you. Especially in the steps you will take regarding art, you need to keep discipline.', N'en-US', N'101fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'88f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Expressing a personality that embodies excitement and intuition, this card also expresses sensitivity and artistic inclination. It can be said that the event in your mind is in the zone of romance and sensuality.', N'en-US', N'111fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'89f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'A very sensitive, intuitive, caring profile is the focus of this card. Therefore, these features surrounded by emotions pave the way for emotional turmoil.', N'en-US', N'121fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'8af2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The King of Cups knows the meaning of life, he is smart. He has a friendly personality. The water flowing in waves on the card symbolizes how meaningful what they do and their emotional side. His areas of interest are law, medicine and consulting. He is also interested in art and is creative. He is interested in psychology. He has high emotional energy, is faithful, gives importance to spirituality. Imagination is strong. He is responsible, seems quiet at first glance, but over time his sincerity emerges.', N'en-US', N'131fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'8bf2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The ace of talismans, which are the harbingers of concrete events, indicates that those who are patient and accumulate knowledge will be rewarded. Any beginning in your life that is; Whether it''s business, property, owning or buying something, it refers to results that have reality.', N'en-US', N'141fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'8cf2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Expressing that the changes in life are endless, this card reminds you that all the changes you will encounter in your life are normal and you should be prepared for such fluctuations. The events you experience can bring you back to the points you thought you got through. You should think that this flow, which is usually not in your hands, adds meaning and movement to your life. Different responsibilities in daily life, making use of money or risking an existing job or a value to start new beginnings are also included in these changes. Therefore, your attitude should be flexible because life has its ups and downs.', N'en-US', N'151fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'8df2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The Triad of Talismans indicates progress in business, talent, education, and monetary matters. In this card, we see a master craftsman working with his skills. Craftsmanship in the interior of a mosque indicates skill, accomplishing an event in life. This card also expresses the power to succeed in a chosen field such as promotion, recognition, fame, degree and certificate.', N'en-US', N'161fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'8ef2ea4a-2d38-ed11-91bc-cc15312ce92f', N'This card, which is an indicator of your determination and economic power, conveys that money is equivalent to power. You can experience the positive effects of holding money in your hands. On the other hand, your card, which expresses ownership in relationships, represents individual control and self-confidence against selfish and closed attitude in general.', N'en-US', N'171fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'8ff2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Experiencing physical or mental problems are negative developments that are expected to result in some losses. They are also likely to be interpreted as a punishment for selfishness. This card, which is an indicator of low income in monetary matters, is also a harbinger of loneliness in love life. You may also lose faith in things you previously trusted.', N'en-US', N'181fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'90f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The balance of the end of the events that cause you distress and the relief you will experience in monetary terms stands out. Investments to be made during this period will return exponentially. Investment should not be considered only in terms of business. It can be help to a person or even someone who is getting training. Therefore, there is not only a monetary profit, but also a profitability that will provide inner peace in a spiritual sense.', N'en-US', N'191fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'91f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'A sense of failure and dissatisfaction may prevail during this period. You are likely to lose something that is given too much importance, a sense of satisfaction you feel, or an achievement. A gut feeling may be pushing you towards further goals related to career, education, material and spiritual goals.', N'en-US', N'1a1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'92f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'It can be said that you are ready for education in any subject. Discovering yourself, being trained for a job or profession are some of the possibilities that exist on this card. It could also be in the form of working on something. This card, which heralds your determination to work in better conditions or earn more money, also heralds that you will meet people with high efficiency. All the relationships you will establish now will come back to you exponentially in the future.', N'en-US', N'1b1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'93f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Monetary gain, increased confidence, determination, self-confidence and independence prevail. Enjoying the beautiful things of life alone, love of garden and home are also the news of this card.', N'en-US', N'1c1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'94f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'This card is a harbinger of solid and good conditions. The ideas that cross your mind are dominated by determination and confidence. This card also signifies the transition from one stage of your life to the next. In the case of this relationship, it can be on many issues such as being single, being married, being unemployed or having a job.', N'en-US', N'1d1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'95f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Patience and respect for the opinions of others are the hallmarks of this card. Saying that lessons can be learned from anything, this card is full of instructive messages. Open-mindedness will ensure that you receive all these teachings correctly.', N'en-US', N'1e1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'96f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'You can share with financial or moral aids to your projects. Expressing money and common sense, this card speaks of reliability, determination and honesty. Your desire for basic and routine happiness in your life coincides with your tendency to have money and anything. This card, which tells about not being too talkative, expressed the preferred jobs with the industry sector, machinery, factories and fields that require mathematical knowledge.', N'en-US', N'1f1fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'97f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'Expressing protection, experience and prudence, this card tells that one is more confident in self-created solidity. When it comes to financial freedom, it speaks to being pretty patient and textual. Success in professional life, interest in luxury, a beautiful environment, a sense of ownership towards the person or thing he loves are also indispensable elements of the card.', N'en-US', N'201fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT [dbo].[CardComments] ([Id], [Comment], [Culture], [CardId]) VALUES (N'98f2ea4a-2d38-ed11-91bc-cc15312ce92f', N'The King of Talismans is determined, hardworking. He is in good financial condition. He knows how to earn and spend. He loves nature and soil. He does not believe in things he cannot see with his own eyes, he approaches with suspicion. It is conservative, it depends on its traditions. He wants loyalty and respect from those around him. He shows his love by spending money.', N'en-US', N'211fd510-da32-ed11-91bb-cc15312ce92f')
GO
INSERT INTO Cultures (Name) VALUES ('tr-TR')
Go
INSERT INTO Cultures (Name) VALUES ('en-US')
Go
            INSERT INTO AppUsers([Id],[Name],Email,Phone,[Password],PasswordSalt,Type,IsActive)
VALUES('171329C1-8B3A-ED11-91BD-CC15312CE92F', 'Admin', 'admin@fortune.com', '5534684489', '6A7077B2C58FD7D934521E6801730085D7B276467AF62A638CAF2335331FEA07', 'cz9mksvUKDTDOwPxGLwIrS21qXLpwV1lCzwZ3gqF668pfTWpfAznizeSFBnKeCmtJSYXGyOVOyAn61l4m+V1htxgbt0mFYl4cjTeEBIuuwyfpT9J+p0gaVv+oT8Vrl/ytnf91EVTaxnhD+AFbH3VfTCUINps1IRO6TfLa1U8Gts=', 1, 1)

");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "CardComments");

            migrationBuilder.DropTable(
                name: "CardNames");

            migrationBuilder.DropTable(
                name: "Cultures");

            migrationBuilder.DropTable(
                name: "TokenIdentities");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
