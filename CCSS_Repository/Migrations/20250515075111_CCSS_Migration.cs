using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CCSS_Repository.Migrations
{
    /// <inheritdoc />
    public partial class CCSS_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    CouponId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Percent = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.CouponId);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    PackageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weight = table.Column<int>(type: "int", nullable: false),
                    length = table.Column<int>(type: "int", nullable: false),
                    width = table.Column<int>(type: "int", nullable: false),
                    height = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    MaxHeight = table.Column<float>(type: "real", nullable: true),
                    MaxWeight = table.Column<float>(type: "real", nullable: true),
                    MinHeight = table.Column<float>(type: "real", nullable: true),
                    MinWeight = table.Column<float>(type: "real", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Character_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerCharacter",
                columns: table => new
                {
                    CustomerCharacterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxHeight = table.Column<float>(type: "real", nullable: true),
                    MaxWeight = table.Column<float>(type: "real", nullable: true),
                    MinHeight = table.Column<float>(type: "real", nullable: true),
                    MinWeight = table.Column<float>(type: "real", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCharacter", x => x.CustomerCharacterId);
                    table.ForeignKey(
                        name: "FK_CustomerCharacter_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "EventActivity",
                columns: table => new
                {
                    EventActivityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ActivityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventActivity", x => x.EventActivityId);
                    table.ForeignKey(
                        name: "FK_EventActivity_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId");
                    table.ForeignKey(
                        name: "FK_EventActivity_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId");
                });

            migrationBuilder.CreateTable(
                name: "EventImage",
                columns: table => new
                {
                    ImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAvatar = table.Column<bool>(type: "bit", nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventImage", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_EventImage_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ticketType = table.Column<int>(type: "int", nullable: false),
                    ticketStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId");
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    ProductImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAvatar = table.Column<bool>(type: "bit", nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    OnTask = table.Column<bool>(type: "bit", nullable: true),
                    Leader = table.Column<bool>(type: "bit", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskQuantity = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    AverageStar = table.Column<double>(type: "float", nullable: true),
                    SalaryIndex = table.Column<double>(type: "float", nullable: true),
                    GoogleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLock = table.Column<bool>(type: "bit", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CharacterImage",
                columns: table => new
                {
                    CharacterImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAvatar = table.Column<bool>(type: "bit", nullable: true),
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterImage", x => x.CharacterImageId);
                    table.ForeignKey(
                        name: "FK_CharacterImage_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId");
                });

            migrationBuilder.CreateTable(
                name: "EventCharacter",
                columns: table => new
                {
                    EventCharacterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAssign = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCharacter", x => x.EventCharacterId);
                    table.ForeignKey(
                        name: "FK_EventCharacter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_EventCharacter_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerCharacterImage",
                columns: table => new
                {
                    CustomerCharacterImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerCharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCharacterImage", x => x.CustomerCharacterImageId);
                    table.ForeignKey(
                        name: "FK_CustomerCharacterImage_CustomerCharacter_CustomerCharacterId",
                        column: x => x.CustomerCharacterId,
                        principalTable: "CustomerCharacter",
                        principalColumn: "CustomerCharacterId");
                });

            migrationBuilder.CreateTable(
                name: "AccountCoupon",
                columns: table => new
                {
                    AccountCouponId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCoupon", x => x.AccountCouponId);
                    table.ForeignKey(
                        name: "FK_AccountCoupon_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_AccountCoupon_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "CouponId");
                });

            migrationBuilder.CreateTable(
                name: "AccountImage",
                columns: table => new
                {
                    AccountImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAvatar = table.Column<bool>(type: "bit", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountImage", x => x.AccountImageId);
                    table.ForeignKey(
                        name: "FK_AccountImage_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsSentMail = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    to_ward_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    to_district_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancelDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    RefreshTokenId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RefreshTokenValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: true),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "TicketAccount",
                columns: table => new
                {
                    TicketAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TicketCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    participantQuantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAccount", x => x.TicketAccountId);
                    table.ForeignKey(
                        name: "FK_TicketAccount_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_TicketAccount_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "TicketId");
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Range = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deposit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PackageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountCouponId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Request_AccountCoupon_AccountCouponId",
                        column: x => x.AccountCouponId,
                        principalTable: "AccountCoupon",
                        principalColumn: "AccountCouponId");
                    table.ForeignKey(
                        name: "FK_Request_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Request_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "PackageId");
                    table.ForeignKey(
                        name: "FK_Request_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    CartProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => x.CartProductId);
                    table.ForeignKey(
                        name: "FK_CartProduct_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_CartProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.OrderProductId);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Deposit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlPdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractStatus = table.Column<int>(type: "int", nullable: true),
                    DeliveryStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contract_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId");
                });

            migrationBuilder.CreateTable(
                name: "RequestCharacter",
                columns: table => new
                {
                    RequestCharacterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CosplayerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestCharacter", x => x.RequestCharacterId);
                    table.ForeignKey(
                        name: "FK_RequestCharacter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_RequestCharacter_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId");
                });

            migrationBuilder.CreateTable(
                name: "ContractCharacter",
                columns: table => new
                {
                    ContractCharacterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CosplayerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCharacter", x => x.ContractCharacterId);
                    table.ForeignKey(
                        name: "FK_ContractCharacter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_ContractCharacter_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateTable(
                name: "ContractImage",
                columns: table => new
                {
                    ContractImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractImage", x => x.ContractImageId);
                    table.ForeignKey(
                        name: "FK_ContractImage_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateTable(
                name: "ContractRefund",
                columns: table => new
                {
                    ContractRefundId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountBankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRefund", x => x.ContractRefundId);
                    table.ForeignKey(
                        name: "FK_ContractRefund_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Purpose = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TicketAccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountCouponID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_AccountCoupon_AccountCouponID",
                        column: x => x.AccountCouponID,
                        principalTable: "AccountCoupon",
                        principalColumn: "AccountCouponId");
                    table.ForeignKey(
                        name: "FK_Payment_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                    table.ForeignKey(
                        name: "FK_Payment_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_Payment_TicketAccount_TicketAccountId",
                        column: x => x.TicketAccountId,
                        principalTable: "TicketAccount",
                        principalColumn: "TicketAccountId");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContractCharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedback_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Feedback_ContractCharacter_ContractCharacterId",
                        column: x => x.ContractCharacterId,
                        principalTable: "ContractCharacter",
                        principalColumn: "ContractCharacterId");
                });

            migrationBuilder.CreateTable(
                name: "RequestDate",
                columns: table => new
                {
                    RequestDateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestCharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContractCharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDate", x => x.RequestDateId);
                    table.ForeignKey(
                        name: "FK_RequestDate_ContractCharacter_ContractCharacterId",
                        column: x => x.ContractCharacterId,
                        principalTable: "ContractCharacter",
                        principalColumn: "ContractCharacterId");
                    table.ForeignKey(
                        name: "FK_RequestDate_RequestCharacter_RequestCharacterId",
                        column: x => x.RequestCharacterId,
                        principalTable: "RequestCharacter",
                        principalColumn: "RequestCharacterId");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventCharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContractCharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Task_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Task_ContractCharacter_ContractCharacterId",
                        column: x => x.ContractCharacterId,
                        principalTable: "ContractCharacter",
                        principalColumn: "ContractCharacterId");
                    table.ForeignKey(
                        name: "FK_Task_EventCharacter_EventCharacterId",
                        column: x => x.EventCharacterId,
                        principalTable: "EventCharacter",
                        principalColumn: "EventCharacterId");
                });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "ActivityId", "CreateDate", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { "ACT001", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(325), "A relaxing yoga session", "Yoga Class", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(325) },
                    { "ACT002", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(329), "Learn to cook delicious meals", "Cooking Workshop", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(329) },
                    { "ACT003", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(331), "Live music performance", "Music Concert", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(332) },
                    { "ACT004", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(333), "Showcase of local artists", "Art Exhibition", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(334) },
                    { "ACT005", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(335), "Discussion on latest technology trends", "Tech Talk", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(336) },
                    { "ACT006", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(337), "5K run for a good cause", "Charity Run", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(338) },
                    { "ACT007", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(339), "Monthly book discussion", "Book Club", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(340) },
                    { "ACT008", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(343), "Learn photography skills", "Photography Workshop", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(343) },
                    { "ACT009", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(345), "Dance battle for all ages", "Dance Competition", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(345) },
                    { "ACT010", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(347), "Competitive chess matches", "Chess Tournament", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(347) },
                    { "ACT011", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(349), "Outdoor movie screening", "Movie Night", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(350) },
                    { "ACT012", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(351), "Showcase of scientific projects", "Science Fair", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(352) },
                    { "ACT013", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(353), "Intensive coding workshop", "Coding Bootcamp", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(354) },
                    { "ACT014", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(355), "Learn gardening techniques", "Gardening Workshop", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(356) },
                    { "ACT015", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(357), "Guided meditation practice", "Meditation Session", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(358) }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { "C10", "Villains", "Famous villain characters" },
                    { "C11", "Robot", "AI and robot characters" },
                    { "C12", "Historical", "Historical figures in fiction" },
                    { "C13", "Horror", "Horror and thriller characters" },
                    { "C14", "Detective", "Famous detective characters" },
                    { "C15", "Sports", "Characters from sports anime/manga" },
                    { "C16", "Magic", "Characters using magic or spells" },
                    { "C17", "Slice of Life", "Everyday life characters" },
                    { "C3", "Manga", "Manga characters" },
                    { "C4", "Movie", "Movie characters" },
                    { "C5", "Comic", "Comic book characters" },
                    { "C6", "Mythology", "Mythological characters" },
                    { "C7", "Fantasy", "Fantasy world characters" },
                    { "C8", "Sci-Fi", "Science fiction characters" },
                    { "C9", "Superhero", "Superhero characters" }
                });

            migrationBuilder.InsertData(
                table: "Coupon",
                columns: new[] { "CouponId", "Amount", "Condition", "CouponName", "EndDate", "Percent", "Quantity", "StartDate", "Type" },
                values: new object[,]
                {
                    { "CP001", 50000.0, "Min order 500", null, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, null, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP002", 150000.0, "Min order 1000", null, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, null, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP003", 400000.0, "Min contract 2000", null, new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, null, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP004", 180000.0, "Min order 1500", null, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 12f, null, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP005", 750000.0, "Min contract 3000", null, new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, null, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP006", 100000.0, "New customers only", null, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, null, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP007", 200000.0, "Holiday Special", null, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, null, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP008", 600000.0, "VIP customers", null, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, null, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP009", 120000.0, "Summer Sale", null, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, null, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP010", 1000000.0, "Black Friday", null, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, null, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP011", 75000.0, "Back to School", null, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, null, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP012", 1750000.0, "Min contract 5000", null, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, null, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP013", 250000.0, "Loyal Customers", null, new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, null, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP014", 800000.0, "Cyber Monday", null, new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, null, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP015", 50000.0, "Referral Bonus", null, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, null, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "CreateBy", "CreateDate", "Description", "EndDate", "EventName", "IsActive", "Location", "StartDate", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { "E001", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8942), "A grand celebration to welcome the new year", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Year Festival", true, "Times Square, New York", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E002", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8947), "Experience the beauty of cherry blossoms", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring Blossom Fest", true, "Kyoto, Japan", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E003", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8950), "Showcasing the latest in technology and AI", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Innovation Summit", true, "Silicon Valley", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E004", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8952), "Live performances from top artists", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music Fest", true, "Coachella, California", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E005", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8955), "A must-attend event for comic book fans", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comic-Con International", true, "San Diego Convention Center", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E006", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8960), "Largest anime convention in the world", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anime Expo", true, "Los Angeles Convention Center", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E007", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8963), "Latest trends and releases in gaming", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Expo", true, "Las Vegas Convention Center", new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E008", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8966), "A fun-filled summer celebration", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Festival", true, "Miami Beach, Florida", new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E009", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8968), "A paradise for cosplayers", new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosplay Festival", true, "Tokyo Big Sight", new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E010", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8972), "Showcasing the best movies of the year", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Festival", true, "Cannes, France", new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E011", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8975), "Spooky celebrations and costume parties", new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween Night", true, "Salem, Massachusetts", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E012", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8977), "Festive shopping and holiday cheer", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Market", true, "Nuremberg, Germany", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "PackageId", "Description", "PackageName", "Price" },
                values: new object[,]
                {
                    { "PKG001", "Rent a single character for an event", "Basic Character Rental", 100000.0 },
                    { "PKG002", "Rent multiple characters with costumes", "Deluxe Character Rental", 250000.0 },
                    { "PKG003", "Full-day character rental service", "Ultimate Character Rental", 500000.0 },
                    { "PKG004", "Basic cosplay performance at an event", "Standard Cosplay Performance", 150000.0 },
                    { "PKG005", "Advanced performance with choreography", "Premium Cosplay Performance", 300000.0 },
                    { "PKG006", "Exclusive show with audience interaction", "VIP Cosplay Performance", 500000.0 },
                    { "PKG007", "30-minute photoshoot with cosplayers", "Mini Photography Session", 80000.0 },
                    { "PKG008", "1-hour professional photoshoot", "Standard Photography Session", 150000.0 },
                    { "PKG009", "Complete photoshoot with editing", "Full Photography Package", 300000.0 },
                    { "PKG010", "Includes exclusive cosplay merchandise", "Basic Merchandise Pack", 50000.0 },
                    { "PKG011", "Premium cosplay collectibles", "Deluxe Merchandise Pack", 150000.0 },
                    { "PKG012", "Limited edition cosplay items", "Ultimate Merchandise Pack", 300000.0 },
                    { "PKG013", "Beginner-friendly cosplay training", "Cosplay Basics Workshop", 100000.0 },
                    { "PKG014", "In-depth cosplay and makeup course", "Advanced Cosplay Training", 2500000.0 },
                    { "PKG015", "Professional-level training for cosplayers", "Master Cosplay Workshop", 500000.0 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreateDate", "Description", "IsActive", "Price", "ProductName", "Quantity", "UpdateDate", "height", "length", "weight", "width" },
                values: new object[,]
                {
                    { "P001", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8825), "A wig for Naruto cosplay", true, 30000.0, "Naruto Wig", 10, null, 10, 30, 200, 20 },
                    { "P002", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8832), "A hat for Mario cosplay", true, 20000.0, "Mario Hat", 15, null, 15, 25, 100, 25 },
                    { "P003", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8836), "Complete costume for Sasuke cosplay", true, 80000.0, "Sasuke Costume", 5, null, 15, 50, 800, 40 },
                    { "P004", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8838), "Replica sword from The Legend of Zelda", true, 100000.0, "Zelda Sword", 7, null, 5, 120, 1500, 15 },
                    { "P005", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8842), "Iconic straw hat from One Piece", true, 25000.0, "One Piece Straw Hat", 20, null, 10, 35, 300, 35 },
                    { "P006", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8844), "Hatsune Miku blue twin-tail wig", true, 40000.0, "Miku Wig", 12, null, 5, 40, 150, 25 },
                    { "P007", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8847), "Tanjiro's iconic hanafuda earrings", true, 15000.0, "Demon Slayer Earrings", 30, null, 3, 5, 50, 5 },
                    { "P008", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8850), "Survey Corps uniform jacket", true, 50000.0, "Attack on Titan Jacket", 10, null, 5, 50, 800, 40 },
                    { "P009", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8854), "Cozy Pikachu-themed onesie", true, 60000.0, "Pikachu Onesie", 8, null, 10, 60, 700, 50 },
                    { "P010", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8857), "Final Fantasy VII replica sword", true, 120000.0, "Cloud's Buster Sword", 4, null, 10, 160, 2000, 25 },
                    { "P011", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8860), "LED Vision accessory from Genshin Impact", true, 35000.0, "Genshin Impact Vision", 25, null, 5, 10, 100, 10 },
                    { "P012", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8862), "Jinx cosplay wig from Arcane", true, 45000.0, "Jinx Wig", 6, null, 10, 40, 250, 25 },
                    { "P013", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8866), "Golden tiara from Sailor Moon", true, 18000.0, "Sailor Moon Tiara", 15, null, 5, 15, 50, 15 },
                    { "P014", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8868), "High-quality Spider-Man suit", true, 90000.0, "Spider-Man Suit", 3, null, 5, 70, 1500, 40 },
                    { "P015", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8902), "Replica wand from Harry Potter series", true, 22000.0, "Harry Potter Wand", 50, null, 5, 35, 200, 5 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "RoleName" },
                values: new object[,]
                {
                    { "R001", "System Administrator", 0 },
                    { "R002", "Event and Service Manager", 1 },
                    { "R003", "Customer Service Consultant", 2 },
                    { "R004", "Professional Cosplayer", 3 },
                    { "R005", "Regular Customer", 4 }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "ServiceId", "CreateDate", "Description", "ServiceName", "UpdateDate" },
                values: new object[,]
                {
                    { "S001", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8780), "Rent characters for events and parties", "Character Rental", null },
                    { "S002", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8785), "Live cosplay performances at events", "Cosplay Rental", null },
                    { "S003", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8786), "Professional photoshoot with cosplayers", "Create event", null }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AverageStar", "Birthday", "Code", "Description", "Email", "GoogleId", "Height", "IsActive", "IsLock", "Leader", "Name", "OnTask", "Password", "Phone", "RoleId", "SalaryIndex", "TaskQuantity", "UserName", "Weight" },
                values: new object[,]
                {
                    { "A001", 4.5, null, null, null, "john@example.com", null, 180f, true, false, null, "John Doe", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 45000.0, null, null, 75f },
                    { "A002", null, null, null, null, "jane@example.com", null, null, true, false, null, "Jane Smith", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R001", null, null, null, null },
                    { "A003", null, null, null, null, "phuongnam26012002@gmail.com", null, null, true, false, null, "Nammmmmmmm", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A004", 4.2000000000000002, null, null, null, "bob@example.com", null, 175f, true, false, null, "Bob Brown", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 42000.0, null, null, 80f },
                    { "A005", 3.5, null, null, null, "charlie@example.com", null, 182f, true, false, null, "Charlie White", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 35000.0, null, null, 78f },
                    { "A006", null, null, null, null, "david@example.com", null, null, true, false, null, "David Black", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A007", 4.0999999999999996, null, null, null, "emma@example.com", null, 168f, true, false, null, "Emma Green", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 41000.0, null, null, 60f },
                    { "A008", 4.5999999999999996, null, null, null, "frank@example.com", null, 185f, true, false, null, "Frank Blue", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 46000.0, null, null, 85f },
                    { "A009", null, null, null, null, "grace@example.com", null, null, true, false, null, "Grace Pink", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R001", null, null, null, null },
                    { "A010", 2.5, null, null, null, "henry@example.com", null, 178f, true, false, null, "Henry Purple", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 25000.0, null, null, 77f },
                    { "A011", null, null, null, null, "isla@example.com", null, null, true, false, null, "Isla Red", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A012", 3.7999999999999998, null, null, null, "jack@example.com", null, 172f, true, false, null, "Jack Yellow", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 38000.0, null, null, 70f },
                    { "A013", 2.5, null, null, null, "katie@example.com", null, 165f, true, false, null, "Katie Orange", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 25000.0, null, null, 55f },
                    { "A014", null, null, null, null, "liam@example.com", null, null, true, false, null, "Liam Gray", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A015", 1.5, null, null, null, "mia@example.com", null, 170f, true, false, null, "Mia Cyan", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 15000.0, null, null, 65f },
                    { "A016", 3.7000000000000002, null, null, null, "noah@example.com", null, 175f, true, false, null, "Noah Silver", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 37000.0, null, null, 70f },
                    { "A017", 4.7999999999999998, null, null, null, "olivia@example.com", null, 168f, true, null, null, "Olivia Gold", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 48000.0, null, null, 55f },
                    { "A018", 3.2000000000000002, null, null, null, "william@example.com", null, 180f, true, false, null, "William Amber", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 32000.0, null, null, 75f },
                    { "A019", 3.2999999999999998, null, null, null, "sophia@example.com", null, 165f, true, false, null, "Sophia Ivory", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 33000.0, null, null, 50f },
                    { "A020", 3.3999999999999999, null, null, null, "james@example.com", null, 178f, true, false, null, "James Navy", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 34000.0, null, null, 72f },
                    { "A021", 3.5, null, null, null, "ava@example.com", null, 162f, true, false, null, "Ava Teal", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 35000.0, null, null, 48f },
                    { "A022", 3.6000000000000001, null, null, null, "benjamin@example.com", null, 177f, true, false, null, "Benjamin Lime", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 36000.0, null, null, 70f },
                    { "A023", 3.7000000000000002, null, null, null, "charlotte@example.com", null, 164f, true, false, null, "Charlotte Beige", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 37000.0, null, null, 52f },
                    { "A024", 3.7999999999999998, null, null, null, "lucas@example.com", null, 180f, true, false, null, "Lucas Maroon", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 38000.0, null, null, 74f },
                    { "A025", 3.8999999999999999, null, null, null, "mia@example.com", null, 159f, true, false, null, "Mia Pearl", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 39000.0, null, null, 47f },
                    { "A026", 2.5, null, null, null, "ethan@example.com", null, 176f, true, false, null, "Ethan Olive", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 25000.0, null, null, 71f },
                    { "A027", 2.6000000000000001, null, null, null, "amelia@example.com", null, 167f, true, false, null, "Amelia Ruby", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 26000.0, null, null, 53f },
                    { "A028", 2.7000000000000002, null, null, null, "henry@example.com", null, 182f, true, false, null, "Henry Saffron", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 27000.0, null, null, 76f },
                    { "A029", 2.7999999999999998, null, null, null, "ella@example.com", null, 160f, true, false, null, "Ella Coral", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 28000.0, null, null, 49f },
                    { "A030", 2.8999999999999999, null, null, null, "daniel@example.com", null, 175f, true, false, null, "Daniel Cyan", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 29000.0, null, null, 72f },
                    { "A031", 3.0, null, null, null, "logan@example.com", null, 180f, true, false, null, "Logan Indigo", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 30000.0, null, null, 73f },
                    { "A032", 4.0, null, null, null, "lily@example.com", null, 165f, true, false, null, "Lily Violet", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 40000.0, null, null, 52f },
                    { "A033", 4.0999999999999996, null, null, null, "mason@example.com", null, 178f, true, false, null, "Mason Turquoise", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 41000.0, null, null, 74f },
                    { "A034", 4.2000000000000002, null, null, null, "zoe@example.com", null, 160f, true, false, null, "Zoe Lavender", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 42000.0, null, null, 48f },
                    { "A035", 4.2999999999999998, null, null, null, "elijah@example.com", null, 182f, true, false, null, "Elijah Crimson", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 43000.0, null, null, 77f },
                    { "A036", 4.4000000000000004, null, null, null, "aria@example.com", null, 164f, true, false, null, "Aria Mint", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 44000.0, null, null, 50f },
                    { "A037", 4.5, null, null, null, "sebastian@example.com", null, 179f, true, false, null, "Sebastian Bronze", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 45000.0, null, null, 72f },
                    { "A038", 4.5999999999999996, null, null, null, "harper@example.com", null, 168f, true, false, null, "Harper Rose", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 46000.0, null, null, 53f },
                    { "A039", 4.7000000000000002, null, null, null, "caleb@example.com", null, 181f, true, false, null, "Caleb Onyx", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 47000.0, null, null, 75f },
                    { "A040", 4.7999999999999998, null, null, null, "scarlett@example.com", null, 162f, true, false, null, "Scarlett Magenta", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 48000.0, null, null, 51f },
                    { "A041", null, null, null, null, "manager@example.com", null, null, true, false, null, "Manager", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R002", null, null, null, null },
                    { "A042", null, null, null, null, "consultant@example.com", null, null, true, false, null, "Consultant", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R003", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "CategoryId", "CharacterName", "CreateDate", "Description", "IsActive", "MaxHeight", "MaxWeight", "MinHeight", "MinWeight", "Price", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { "CH001", "C3", "Naruto", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8647), "Ninja from Konoha", true, 180f, 80f, 160f, 50f, 100000.0, 100, null },
                    { "CH002", "C3", "Sasuke", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8658), "Naruto’s rival", true, 185f, 85f, 165f, 55f, 120000.0, 100, null },
                    { "CH003", "C3", "Goku", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8662), "Saiyan warrior", true, 190f, 90f, 170f, 60f, 150000.0, 100, null },
                    { "CH004", "C4", "Luffy", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8666), "Pirate King", true, 175f, 70f, 155f, 45f, 110000.0, 100, null },
                    { "CH005", "C4", "Ichigo", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8669), "Soul Reaper", true, 185f, 85f, 165f, 55f, 130000.0, 100, null },
                    { "CH006", "C14", "Mario", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8673), "Plumber hero", true, 180f, 80f, 160f, 60f, 80000.0, 100, null },
                    { "CH007", "C14", "Luigi", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8677), "Mario’s brother", true, 170f, 75f, 150f, 55f, 85000.0, 100, null },
                    { "CH008", "C14", "Link", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8681), "Hero of Hyrule", true, 180f, 80f, 160f, 50f, 140000.0, 100, null },
                    { "CH009", "C16", "Zelda", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8684), "Hyrule princess", true, 175f, 70f, 155f, 50f, 135000.0, 100, null },
                    { "CH010", "C16", "Samus", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8688), "Bounty hunter", true, 185f, 85f, 165f, 55f, 145000.0, 100, null },
                    { "CH011", "C13", "Cloud", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8730), "Ex-SOLDIER", true, 185f, 85f, 165f, 55f, 125000.0, 100, null },
                    { "CH012", "C13", "Sephiroth", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8734), "One-Winged Angel", true, 190f, 90f, 170f, 60f, 155000.0, 100, null },
                    { "CH013", "C8", "Kratos", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8738), "God of War", true, 195f, 100f, 175f, 70f, 160000.0, 100, null },
                    { "CH014", "C8", "Pikachu", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8742), "Electric Pokemon", true, 180f, 80f, 160f, 60f, 90000.0, 100, null },
                    { "CH015", "C8", "Kirby", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(8746), "Pink puffball", true, 180f, 80f, 160f, 60f, 95000.0, 100, null }
                });

            migrationBuilder.InsertData(
                table: "EventActivity",
                columns: new[] { "EventActivityId", "ActivityId", "CreateBy", "CreateDate", "Description", "EventId", "UpdateDate" },
                values: new object[,]
                {
                    { "EA001", "ACT001", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(98), "Yoga for a fresh start", "E001", null },
                    { "EA002", "ACT005", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(100), "Tech trends in the new year", "E001", null },
                    { "EA003", "ACT004", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(102), "Painting cherry blossoms", "E002", null },
                    { "EA004", "ACT013", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(104), "AI and future coding", "E003", null },
                    { "EA005", "ACT009", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(107), "Dance battles live", "E004", null },
                    { "EA006", "ACT003", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(109), "Comic-Con live music", "E005", null },
                    { "EA007", "ACT007", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(111), "Anime and book discussions", "E006", null },
                    { "EA008", "ACT010", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(113), "Chess and gaming", "E007", null },
                    { "EA009", "ACT011", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(114), "Outdoor movie fun", "E008", null },
                    { "EA010", "ACT015", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(116), "Meditation for cosplayers", "E009", null },
                    { "EA011", "ACT012", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(118), "Science in filmmaking", "E010", null },
                    { "EA012", "ACT006", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(139), "Halloween charity run", "E011", null },
                    { "EA013", "ACT014", "Admin", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(142), "Christmas gardening", "E012", null },
                    { "EA014", "ACT002", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(145), "Cooking for music lovers", "E004", null },
                    { "EA015", "ACT008", "Manager", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(146), "Photography in tech", "E003", null }
                });

            migrationBuilder.InsertData(
                table: "EventImage",
                columns: new[] { "ImageId", "CreateDate", "EventId", "ImageUrl", "IsAvatar", "UpdateDate" },
                values: new object[,]
                {
                    { "EI001", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(542), "E001", "https://example.com/event1.jpg", null, null },
                    { "EI002", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(547), "E002", "https://example.com/event2.jpg", null, null },
                    { "EI003", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(549), "E003", "https://example.com/event3.jpg", null, null },
                    { "EI004", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(550), "E004", "https://example.com/event4.jpg", null, null },
                    { "EI005", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(552), "E005", "https://example.com/event5.jpg", null, null },
                    { "EI006", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(553), "E006", "https://example.com/event6.jpg", null, null },
                    { "EI007", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(555), "E007", "https://example.com/event7.jpg", null, null },
                    { "EI008", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(556), "E008", "https://example.com/event8.jpg", null, null },
                    { "EI009", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(558), "E009", "https://example.com/event9.jpg", null, null },
                    { "EI010", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(561), "E010", "https://example.com/event10.jpg", null, null },
                    { "EI011", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(563), "E011", "https://example.com/event11.jpg", null, null },
                    { "EI012", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(564), "E012", "https://example.com/event12.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "ProductImageId", "CreateDate", "IsAvatar", "ProductId", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "IMG001", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(805), null, "P001", null, "https://example.com/images/naruto_wig.jpg" },
                    { "IMG002", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(807), null, "P002", null, "https://example.com/images/mario_hat.jpg" },
                    { "IMG003", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(810), null, "P003", null, "https://example.com/images/sasuke_costume.jpg" },
                    { "IMG004", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(812), null, "P004", null, "https://example.com/images/zelda_sword.jpg" },
                    { "IMG005", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(813), null, "P005", null, "https://example.com/images/one_piece_hat.jpg" },
                    { "IMG006", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(815), null, "P006", null, "https://example.com/images/miku_wig.jpg" },
                    { "IMG007", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(816), null, "P007", null, "https://example.com/images/demon_slayer_earrings.jpg" },
                    { "IMG008", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(818), null, "P008", null, "https://example.com/images/aot_jacket.jpg" },
                    { "IMG009", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(819), null, "P009", null, "https://example.com/images/pikachu_onesie.jpg" },
                    { "IMG010", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(820), null, "P010", null, "https://example.com/images/buster_sword.jpg" },
                    { "IMG011", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(823), null, "P011", null, "https://example.com/images/genshin_vision.jpg" },
                    { "IMG012", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(825), null, "P012", null, "https://example.com/images/jinx_wig.jpg" },
                    { "IMG013", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(826), null, "P013", null, "https://example.com/images/sailor_moon_tiara.jpg" },
                    { "IMG014", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(828), null, "P014", null, "https://example.com/images/spiderman_suit.jpg" },
                    { "IMG015", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(829), null, "P015", null, "https://example.com/images/harry_potter_wand.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "TicketId", "Description", "EventId", "Price", "Quantity", "ticketStatus", "ticketType" },
                values: new object[,]
                {
                    { 1, "Được giao lưu với các idol cosplayer ", "E001", 50000.0, 500, 0, 0 },
                    { 2, "Được giao lưu với các idol cosplayer ", "E002", 40000.0, 300, 0, 0 },
                    { 3, "Được giao lưu với các idol cosplayer ", "E003", 30000.0, 200, 0, 0 },
                    { 4, "Được giao lưu với các idol cosplayer ", "E004", 60000.0, 600, 0, 0 },
                    { 5, "Được giao lưu với các idol cosplayer ", "E005", 45000.0, 400, 0, 0 },
                    { 6, "Được giao lưu với các idol cosplayer ", "E006", 55000.0, 350, 0, 0 },
                    { 7, "Được giao lưu với các idol cosplayer ", "E007", 35000.0, 250, 0, 0 },
                    { 8, "Được giao lưu với các idol cosplayer ", "E008", 50000.0, 450, 0, 0 },
                    { 9, "Được giao lưu với các idol cosplayer ", "E009", 65000.0, 550, 0, 0 },
                    { 10, "Được giao lưu với các idol cosplayer ", "E010", 70000.0, 700, 0, 0 },
                    { 11, "Được giao lưu với các idol cosplayer ", "E011", 25000.0, 150, 0, 0 },
                    { 12, "Được giao lưu với các idol cosplayer ", "E012", 75000.0, 800, 0, 0 },
                    { 13, "Được tham gia các hoạt động do chương trình tổ chức", "E001", 75000.0, 500, 0, 1 },
                    { 14, "Được tham gia các hoạt động do chương trình tổ chức", "E002", 60000.0, 500, 0, 1 },
                    { 15, "Được tham gia các hoạt động do chương trình tổ chức", "E003", 45000.0, 500, 0, 1 },
                    { 16, "Được tham gia các hoạt động do chương trình tổ chức", "E004", 90000.0, 500, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "AccountCoupon",
                columns: new[] { "AccountCouponId", "AccountId", "CouponId", "EndDate", "IsActive", "StartDate" },
                values: new object[,]
                {
                    { "AC001", "A001", "CP001", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC002", "A002", "CP002", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC003", "A003", "CP003", new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC004", "A004", "CP004", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC005", "A005", "CP005", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC006", "A001", "CP006", new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC007", "A002", "CP007", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC008", "A003", "CP008", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC009", "A004", "CP009", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC010", "A005", "CP010", new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC011", "A006", "CP011", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC012", "A007", "CP012", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC013", "A008", "CP013", new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC014", "A009", "CP014", new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "AC015", "A010", "CP015", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AccountImage",
                columns: new[] { "AccountImageId", "AccountId", "CreateDate", "IsAvatar", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "AI1", "A001", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(238), null, null, "https://example.com/admin.jpg" },
                    { "AI10", "A010", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(254), null, null, "https://example.com/user8.jpg" },
                    { "AI11", "A011", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(255), null, null, "https://example.com/user9.jpg" },
                    { "AI12", "A012", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(257), null, null, "https://example.com/user10.jpg" },
                    { "AI13", "A013", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(258), null, null, "https://example.com/user11.jpg" },
                    { "AI14", "A014", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(295), null, null, "https://example.com/user12.jpg" },
                    { "AI15", "A015", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(298), null, null, "https://example.com/user13.jpg" },
                    { "AI2", "A002", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(240), null, null, "https://example.com/manager.jpg" },
                    { "AI3", "A003", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(242), null, null, "https://example.com/user1.jpg" },
                    { "AI4", "A004", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(243), null, null, "https://example.com/user2.jpg" },
                    { "AI5", "A005", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(244), null, null, "https://example.com/user3.jpg" },
                    { "AI6", "A006", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(246), null, null, "https://example.com/user4.jpg" },
                    { "AI7", "A007", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(249), null, null, "https://example.com/user5.jpg" },
                    { "AI8", "A008", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(251), null, null, "https://example.com/user6.jpg" },
                    { "AI9", "A009", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(252), null, null, "https://example.com/user7.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "AccountId", "CreateDate", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "C001", "A003", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9636), 0.0, new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9636) },
                    { "C002", "A006", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9638), 0.0, new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9639) },
                    { "C003", "A011", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9640), 0.0, new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9641) },
                    { "C004", "A014", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9642), 0.0, new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9643) }
                });

            migrationBuilder.InsertData(
                table: "CharacterImage",
                columns: new[] { "CharacterImageId", "CharacterId", "CreateDate", "IsAvatar", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "CI001", "CH001", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(490), null, null, "https://ae01.alicdn.com/kf/HTB1gQt5aO6guuRkSnb4q6zu4XXaw/Naruto-Cosplay-Costumes-Anime-Naruto-Outfit-For-Man-Show-Suits-Japanese-Cartoon-Costumes-Naruto-Coat-Top.jpg" },
                    { "CI002", "CH002", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(494), null, null, "https://lzd-img-global.slatic.net/g/ff/kf/Sfedbbf9e61af4bc5a4ce107829ab12ffP.jpg_720x720q80.jpg" },
                    { "CI003", "CH003", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(495), null, null, "https://tse2.mm.bing.net/th/id/OIP.7wO0lin122XZz8cW6QwMPwHaNK?rs=1&pid=ImgDetMain" },
                    { "CI004", "CH004", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(497), null, null, "https://th.bing.com/th/id/R.a547136c5dc32ca575032d919b616c81?rik=QB63jSYlpxVIDg&pid=ImgRaw&r=0" },
                    { "CI005", "CH005", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(498), null, null, "https://tse3.mm.bing.net/th/id/OIP.Iv-VMJCvgXjXP3seS54VUQHaIj?rs=1&pid=ImgDetMain" },
                    { "CI006", "CH006", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(500), null, null, "https://i.pinimg.com/736x/88/67/c2/8867c200a089728d7e5fc0893c4b768d.jpg" },
                    { "CI007", "CH007", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(502), null, null, "https://tse1.explicit.bing.net/th/id/OIP.v9qz5NCIL7XhgBUU1rnkLQHaKL?rs=1&pid=ImgDetMain" },
                    { "CI008", "CH008", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(503), null, null, "https://cdn.openart.ai/stable_diffusion/43d1f34dddfdcdfefa54b8984be0a96159b200a8_2000x2000.webp" },
                    { "CI009", "CH009", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(506), null, null, "https://tse1.mm.bing.net/th/id/OIP.dX8f8uziv7-sVE-MGmiKMwHaHa?rs=1&pid=ImgDetMain" },
                    { "CI010", "CH010", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(508), null, null, "https://tse3.mm.bing.net/th/id/OIP.GLTrvuL5642aAYTOFxC0eAHaJQ?rs=1&pid=ImgDetMain" },
                    { "CI011", "CH011", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(510), null, null, "https://th.bing.com/th/id/R.1a1aeceee8146ba95dd2a8f69c3f182f?rik=T9YeKcs%2b27tcsg&pid=ImgRaw&r=0" },
                    { "CI012", "CH012", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(511), null, null, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/7b60d23e-2e8e-44da-a221-dc39a83c4f3f/der5hqx-ee11482f-b214-4b25-bfee-88dc11a8c4fe.jpg/v1/fill/w_1280,h_1814,q_75,strp/sephiroth__full_body__by_akonyah_der5hqx-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzdiNjBkMjNlLTJlOGUtNDRkYS1hMjIxLWRjMzlhODNjNGYzZlwvZGVyNWhxeC1lZTExNDgyZi1iMjE0LTRiMjUtYmZlZS04OGRjMTFhOGM0ZmUuanBnIiwiaGVpZ2h0IjoiPD0xODE0Iiwid2lkdGgiOiI8PTEyODAifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6aW1hZ2Uud2F0ZXJtYXJrIl0sIndtayI6eyJwYXRoIjoiXC93bVwvN2I2MGQyM2UtMmU4ZS00NGRhLWEyMjEtZGMzOWE4M2M0ZjNmXC9ha29ueWFoLTQucG5nIiwib3BhY2l0eSI6OTUsInByb3BvcnRpb25zIjowLjQ1LCJncmF2aXR5IjoiY2VudGVyIn19.e9IstlpQcF1QRaMoUKkr41MQ7pekjWh_iOje74x3coY" },
                    { "CI013", "CH013", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(513), null, null, "https://tse1.mm.bing.net/th/id/OIP.uCp4Whd_B4z4Zw8C7wvjxwHaLH?rs=1&pid=ImgDetMain" },
                    { "CI014", "CH014", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(514), null, null, "https://tse3.mm.bing.net/th/id/OIP.3ADDr3lt8PYxM6KP10OtwwAAAA?rs=1&pid=ImgDetMain" },
                    { "CI015", "CH015", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(516), null, null, "https://thatparkplace.com/wp-content/uploads/2023/04/kirby-e1681312791814.jpg" }
                });

            migrationBuilder.InsertData(
                table: "EventCharacter",
                columns: new[] { "EventCharacterId", "CharacterId", "CreateDate", "Description", "EventId", "IsAssign", "UpdateDate" },
                values: new object[,]
                {
                    { "EC001", "CH001", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(47), null, "E001", true, null },
                    { "EC002", "CH002", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(52), null, "E002", true, null },
                    { "EC003", "CH003", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(54), null, "E003", true, null },
                    { "EC004", "CH004", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(56), null, "E004", true, null },
                    { "EC005", "CH005", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(58), null, "E005", true, null },
                    { "EC006", "CH006", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(59), null, "E006", true, null },
                    { "EC007", "CH007", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(61), null, "E007", true, null },
                    { "EC008", "CH008", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(63), null, "E008", true, null },
                    { "EC009", "CH009", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(66), null, "E009", true, null },
                    { "EC010", "CH010", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(68), null, "E010", true, null },
                    { "EC011", "CH011", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(70), null, "E011", true, null },
                    { "EC012", "CH012", new DateTime(2025, 5, 15, 14, 51, 11, 277, DateTimeKind.Local).AddTicks(72), null, "E012", true, null }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "AccountId", "CreatedAt", "IsRead", "IsSentMail", "Message" },
                values: new object[,]
                {
                    { "N001", "A001", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9572), false, true, "Welcome to the system!" },
                    { "N002", "A002", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9574), false, true, "Your account has been upgraded." },
                    { "N003", "A003", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9576), true, true, "New promotional offer available!" },
                    { "N004", "A004", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9578), false, true, "Your request has been approved." },
                    { "N005", "A005", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9581), true, true, "System maintenance scheduled." },
                    { "N006", "A006", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9583), false, true, "Your order has been shipped!" },
                    { "N007", "A007", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9585), false, true, "New event registration open." },
                    { "N008", "A008", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9587), true, true, "Reminder: Payment due soon." },
                    { "N009", "A009", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9589), false, true, "Your password was changed." },
                    { "N010", "A010", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9591), false, true, "Admin announcement update." },
                    { "N011", "A011", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9592), true, true, "New message from support." },
                    { "N012", "A012", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9594), false, true, "Upcoming event invitation." },
                    { "N013", "A013", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9597), false, true, "New cosplayer contest." },
                    { "N014", "A014", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9599), true, true, "Loyalty points updated." },
                    { "N015", "A015", new DateTime(2025, 5, 15, 7, 51, 11, 276, DateTimeKind.Utc).AddTicks(9601), false, true, "Your subscription expired." }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "AccountId", "Address", "CancelDate", "OrderDate", "OrderStatus", "Phone", "ShipCode", "ShipStatus", "TotalPrice", "to_district_id", "to_ward_code" },
                values: new object[,]
                {
                    { "O001", "A003", "123 Main St", null, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0901234567", "S001", "Shipped", 250000.0, "District1", "Ward1" },
                    { "O002", "A006", "456 Elm St", null, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0902345678", "S002", "Shipped", 150000.5, "District2", "Ward2" },
                    { "O003", "A011", "789 Pine St", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "0903456789", "S003", "Canceled", 300000.0, "District3", "Ward3" },
                    { "O004", "A014", "101 Oak St", null, new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0904567890", "S004", "Shipped", 400000.0, "District4", "Ward4" },
                    { "O005", "A003", "123 Main St", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "0901234567", "S005", "Canceled", 175000.0, "District1", "Ward1" },
                    { "O006", "A006", "456 Elm St", null, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0902345678", "S006", "Shipped", 225000.0, "District2", "Ward2" },
                    { "O007", "A011", "789 Pine St", null, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0903456789", "S007", "Shipped", 350000.0, "District3", "Ward3" },
                    { "O008", "A014", "101 Oak St", new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "0904567890", "S008", "Canceled", 275000.0, "District4", "Ward4" },
                    { "O009", "A003", "123 Main St", null, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0901234567", "S009", "Shipped", 500000.0, "District1", "Ward1" },
                    { "O010", "A006", "456 Elm St", new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "0902345678", "S010", "Canceled", 125000.0, "District2", "Ward2" },
                    { "O011", "A011", "789 Pine St", null, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0903456789", "S011", "Shipped", 325000.0, "District3", "Ward3" },
                    { "O012", "A014", "101 Oak St", null, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0904567890", "S012", "Shipped", 410000.0, "District4", "Ward4" },
                    { "O013", "A003", "123 Main St", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "0901234567", "S013", "Canceled", 280000.0, "District1", "Ward1" },
                    { "O014", "A006", "456 Elm St", null, new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0902345678", "S014", "Shipped", 350000.0, "District2", "Ward2" },
                    { "O015", "A011", "789 Pine St", null, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0903456789", "S015", "Shipped", 200000.0, "District3", "Ward3" }
                });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "RequestId", "AccountCouponId", "AccountId", "CreatedDate", "Deposit", "Description", "EndDate", "Location", "Name", "PackageId", "Price", "Range", "Reason", "ServiceId", "StartDate", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { "R001", null, "A001", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9688), null, "RentCostumes", new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Naruto Costume", "PKG001", 100000.0, null, null, "S003", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R002", null, "A002", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9716), null, "RentCosplayer", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ĐN", "Rent Cosplayer for Event", null, 500000.0, null, "Cosplayer is busy", "S002", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R003", null, "A003", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9720), null, "CreateEvent", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "BD", "Create Anime Festival", null, 2000000.0, null, null, "S003", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R004", null, "A004", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9723), null, "RentCostumes", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Rent Samurai Armor", null, 150000.0, null, null, "S002", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R005", null, "A005", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9726), null, "RentCosplayer", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "BT", "Hire Professional Cosplayer", "PKG002", 700000.0, null, null, "S002", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R006", null, "A006", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9729), null, "CreateEvent", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Organize Comic Convention", null, 5000000.0, null, null, "S001", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R007", null, "A007", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9732), null, "RentCostumes", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Victorian Costume", null, 120000.0, null, "Cosplayer is busy", "S002", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R008", null, "A008", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9735), null, "RentCosplayer", new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "QN", "Book Cosplayer for Birthday Party", null, 350000.0, null, null, "S003", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R009", null, "A009", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9739), null, "CreateEvent", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CM", "Plan Fantasy Fair", null, 3000000.0, null, null, "S003", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R010", null, "A010", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9743), null, "RentCostumes", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "LĐ", "Rent Halloween Costumes", null, 200000.0, null, null, "S001", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R011", null, "A011", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9745), null, "RentCosplayer", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "NT", "Hire Cosplayer for Wedding", "PKG010", 800000.0, null, null, "S001", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R012", null, "A012", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9748), null, "CreateEvent", new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "VT", "Create Sci-Fi Convention", null, 4500000.0, null, null, "S002", new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R013", null, "A013", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9751), null, "RentCostumes", new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Santa Claus Costume", null, 130000.0, null, null, "S003", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R014", null, "A014", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9754), null, "RentCosplayer", new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Book Cosplayer for Product Launch", null, 600000.0, null, null, "S001", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R015", null, "A015", new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9756), null, "CreateEvent", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Host Christmas Event", "PKG015", 5500000.0, null, null, "S002", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null }
                });

            migrationBuilder.InsertData(
                table: "TicketAccount",
                columns: new[] { "TicketAccountId", "AccountId", "Quantity", "TicketCode", "TicketId", "TotalPrice", "participantQuantity" },
                values: new object[,]
                {
                    { "TA001", "A003", 2, "TC001", 1, 100000.0, 0 },
                    { "TA002", "A006", 1, "TC002", 2, 40000.0, 0 },
                    { "TA003", "A011", 3, "TC003", 3, 90000.0, 0 },
                    { "TA004", "A014", 2, "TC004", 4, 120000.0, 0 },
                    { "TA005", "A003", 4, "TC005", 5, 180000.0, 0 },
                    { "TA006", "A006", 2, "TC006", 6, 110000.0, 0 },
                    { "TA007", "A011", 1, "TC007", 7, 35000.0, 0 },
                    { "TA008", "A014", 3, "TC008", 8, 150000.0, 0 },
                    { "TA009", "A003", 2, "TC009", 9, 130000.0, 0 },
                    { "TA010", "A006", 1, "TC010", 10, 70000.0, 0 },
                    { "TA011", "A011", 5, "TC011", 11, 125000.0, 0 },
                    { "TA012", "A014", 2, "TC012", 12, 150000.0, 0 },
                    { "TA013", "A003", 3, "TC013", 3, 90000.0, 0 },
                    { "TA014", "A006", 2, "TC014", 5, 90000.0, 0 },
                    { "TA015", "A011", 1, "TC015", 7, 35000.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "07bd24b2-671f-48aa-949f-35b852552b19", "C001", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(398), 80000.0, "P003", 1 },
                    { "0ceefefd-5d72-4cba-ac7d-e410339da43f", "C001", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(395), 20000.0, "P002", 1 },
                    { "0e6ec344-d5f3-4102-b4e3-a4f3481e3cb9", "C002", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(407), 40000.0, "P006", 2 },
                    { "12e458a6-031a-48e0-a107-09259365470c", "C003", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(413), 50000.0, "P008", 2 },
                    { "158e8091-2da0-400c-ac59-8c00e1b7b5d1", "C004", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(422), 35000.0, "P011", 2 },
                    { "4630768e-a053-4caa-9393-c2c7145d8be8", "C002", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(404), 25000.0, "P005", 3 },
                    { "5892fe9d-f01d-402e-a883-4761d7efd76e", "C003", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(410), 15000.0, "P007", 5 },
                    { "651dc311-8325-4a03-bdd3-33855038ad18", "C004", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(424), 45000.0, "P012", 1 },
                    { "86482c30-c20a-46b0-b55c-3aa9e041b4e7", "C001", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(391), 30000.0, "P001", 2 },
                    { "872f5977-6737-45c4-ade2-bf9ae1a6d906", "C004", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(419), 120000.0, "P010", 1 },
                    { "f5a298ee-da87-487c-bd32-59cd38679c42", "C003", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(416), 60000.0, "P009", 1 },
                    { "f7cb57f1-cff1-4e34-8dae-506d9bc975b9", "C002", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(400), 100000.0, "P004", 1 }
                });

            migrationBuilder.InsertData(
                table: "Contract",
                columns: new[] { "ContractId", "Amount", "ContractName", "ContractStatus", "CreateBy", "CreateDate", "DeliveryStatus", "Deposit", "Reason", "RequestId", "TotalPrice", "UrlPdf" },
                values: new object[,]
                {
                    { "CT002", 0.0, "Character rental", 1, "A002", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "100", null, "R002", 500000.0, null },
                    { "CT005", 350000.0, "Character rental", 1, "A005", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "50", null, "R005", 700000.0, null },
                    { "CT008", 175000.0, "Character rental", 1, "A008", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "50", null, "R008", 350000.0, null },
                    { "CT010", 100000.0, "Character rental", 2, "A010", new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "50", null, "R010", 200000.0, null },
                    { "CT014", 0.0, "Character rental", 1, "A014", new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "100", null, "R014", 600000.0, null }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0a65b2b9-2235-490a-8c9d-75fbe6a460a2", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(632), "O004", 15000.0, "P007", 4 },
                    { "18c58437-e36d-4fed-91b8-35f8a151a6eb", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(589), "O001", 30000.0, "P001", 3 },
                    { "18caafee-badb-4e93-816f-fec4b56654a1", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(692), "O015", 90000.0, "P014", 2 },
                    { "1aded766-0c2a-46aa-8599-99c78815e6ff", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(668), "O010", 25000.0, "P005", 3 },
                    { "2943d5a3-5cc3-4f4e-9c19-19570e0fa0de", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(690), "O014", 18000.0, "P013", 5 },
                    { "2d4d02db-b365-4b22-8cd3-f347409c2c7d", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(639), "O005", 120000.0, "P010", 1 },
                    { "300f253f-d11b-419e-9a1f-bf45eb7eaac5", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(625), "O003", 25000.0, "P005", 2 },
                    { "31177067-2560-4cd4-8812-ab717798b8fe", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(673), "O011", 15000.0, "P007", 4 },
                    { "3bdddb81-62ea-4e8c-938e-8c77db4a6dc5", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(679), "O012", 60000.0, "P009", 1 },
                    { "4ff12c06-6578-4b38-9e9e-8fb79266bab0", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(695), "O015", 22000.0, "P015", 4 },
                    { "5e1ab330-129b-4526-a60a-23b812d7e2e8", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(676), "O012", 50000.0, "P008", 2 },
                    { "65db7f2b-fb6c-4705-9adc-791d95e42791", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(681), "O013", 120000.0, "P010", 1 },
                    { "678c3504-484e-4f31-88c5-ac39d80df079", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(599), "O002", 100000.0, "P004", 1 },
                    { "731449bd-85bd-49bf-a57d-a28abc9991ce", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(648), "O007", 18000.0, "P013", 5 },
                    { "75d76a54-d0b1-4690-a527-f36ee54dbf75", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(660), "O009", 20000.0, "P002", 6 },
                    { "7d8f59c6-bb26-491b-b5b2-684ddc7473db", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(657), "O008", 30000.0, "P001", 1 },
                    { "82675663-d60e-4455-9bd4-bd8bd4c4d81a", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(666), "O010", 100000.0, "P004", 1 },
                    { "a3f40753-f36d-4ce8-ab5b-c1d9d54656b5", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(662), "O009", 80000.0, "P003", 2 },
                    { "ad22a848-92f4-4f93-91d1-53fe24aca759", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(670), "O011", 40000.0, "P006", 2 },
                    { "bdcf8d07-bf8a-4b7c-9b9c-e55a2c5590e5", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(683), "O013", 35000.0, "P011", 2 },
                    { "c9611399-926d-4ccb-9800-06c6094e9874", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(688), "O014", 45000.0, "P012", 3 },
                    { "cdcce274-2bc5-4561-a648-3483b467173c", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(643), "O006", 35000.0, "P011", 2 },
                    { "cf51c09f-7201-4565-88c7-aebe94eaa57b", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(592), "O001", 20000.0, "P002", 5 },
                    { "d68c5c6b-152f-47aa-8773-06a97faf9b72", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(655), "O008", 22000.0, "P015", 4 },
                    { "d8e3ab00-dabb-4b9b-bad6-a5cfd631d2f6", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(628), "O003", 40000.0, "P006", 3 },
                    { "da884960-4ac2-4dbe-bcf0-1fe1b98e049c", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(634), "O004", 50000.0, "P008", 2 },
                    { "e8ab2f50-098a-4efd-9a28-01de385aa186", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(651), "O007", 90000.0, "P014", 2 },
                    { "f255c44a-a82b-4397-9198-8fef98f49ebe", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(637), "O005", 60000.0, "P009", 1 },
                    { "f6a182aa-9e99-428d-ba59-eebb92290a04", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(596), "O002", 80000.0, "P003", 1 },
                    { "f80b5796-655c-41d3-bf63-bd78db7d60d2", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(645), "O006", 45000.0, "P012", 3 }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "AccountCouponID", "Amount", "ContractId", "CreatAt", "OrderId", "Purpose", "Status", "TicketAccountId", "TransactionId", "Type" },
                values: new object[,]
                {
                    { "P001", "AC001", 250000.0, null, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, "TA001", "TXN001", "Online" },
                    { "P002", null, 150000.5, null, new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, "TA002", "TXN002", "Online" },
                    { "P003", null, 90000.0, null, new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, "TA003", "TXN003", "Cash" },
                    { "P004", "AC012", 400000.0, null, new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, "TA004", "TXN004", "Card" },
                    { "P005", null, 175000.0, null, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 2, "TA005", "TXN005", "Online" },
                    { "P006", "AC003", 225000.0, null, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "O006", 3, 1, null, "TXN006", "Cash" },
                    { "P007", null, 350000.0, null, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "O007", 3, 0, null, "TXN007", "Online" },
                    { "P008", null, 150000.0, null, new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "O008", 3, 1, null, "TXN008", "Card" },
                    { "P009", null, 500000.0, null, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "O009", 3, 1, null, "TXN009", "Cash" },
                    { "P010", "AC004", 125000.0, null, new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "O010", 3, 2, null, "TXN010", "Online" }
                });

            migrationBuilder.InsertData(
                table: "RequestCharacter",
                columns: new[] { "RequestCharacterId", "CharacterId", "CosplayerId", "CreateDate", "Description", "Quantity", "Reason", "RequestId", "Status", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "RC01", "CH001", "A025", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(858), "Yêu cầu cosplay nhân vật CH001", 1, null, "R001", null, 50000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(859) },
                    { "RC02", "CH002", "A026", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(862), "Yêu cầu cosplay nhân vật CH002", 1, null, "R002", null, 60000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(863) },
                    { "RC03", "CH003", "A027", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(865), "Yêu cầu cosplay nhân vật CH003", 1, null, "R003", null, 70000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(866) },
                    { "RC04", "CH004", "A028", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(870), "Yêu cầu cosplay nhân vật CH004", 1, null, "R004", null, 80000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(870) },
                    { "RC05", "CH005", "A029", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(873), "Yêu cầu cosplay nhân vật CH005", 1, null, "R005", null, 90000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(873) },
                    { "RC06", "CH006", null, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(897), "Yêu cầu cosplay nhân vật CH006", 5, null, "R006", null, 100000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(897) },
                    { "RC07", "CH007", "A031", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(900), "Yêu cầu cosplay nhân vật CH007", 1, null, "R007", null, 110000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(900) },
                    { "RC08", "CH008", null, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(903), "Yêu cầu cosplay nhân vật CH008", 7, null, "R008", null, 120000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(903) },
                    { "RC09", "CH009", "A033", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(905), "Yêu cầu cosplay nhân vật CH009", 1, null, "R009", null, 130000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(905) },
                    { "RC10", "CH010", null, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(908), "Yêu cầu cosplay nhân vật CH010", 9, null, "R010", null, 140000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(908) },
                    { "RC11", "CH011", "A035", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(910), "Yêu cầu cosplay nhân vật CH011", 1, null, "R011", null, 150000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(911) },
                    { "RC12", "CH012", "A036", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(915), "Yêu cầu cosplay nhân vật CH012", 1, null, "R012", null, 160000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(915) },
                    { "RC13", "CH013", null, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(917), "Yêu cầu cosplay nhân vật CH013", 10, null, "R013", null, 170000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(922) },
                    { "RC14", "CH014", "A038", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(924), "Yêu cầu cosplay nhân vật CH014", 1, null, "R014", null, 180000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(924) },
                    { "RC15", "CH015", "A039", new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(926), "Yêu cầu cosplay nhân vật CH015", 1, null, "R015", null, 190000.0, new DateTime(2025, 5, 15, 7, 51, 11, 277, DateTimeKind.Utc).AddTicks(927) }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "AccountId", "ContractCharacterId", "CreateDate", "Description", "EndDate", "EventCharacterId", "IsActive", "Location", "StartDate", "Status", "TaskName", "Type", "UpdateDate" },
                values: new object[,]
                {
                    { "T001", "A001", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9797), "Cosplay as anime characters", new DateTime(2025, 5, 18, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9796), "EC001", true, "Tokyo", new DateTime(2025, 5, 17, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9790), 0, "CH001", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9797) },
                    { "T002", "A004", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9803), "Join cosplay contest", new DateTime(2025, 5, 20, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9802), "EC002", true, "Los Angeles", new DateTime(2025, 5, 19, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9801), 1, "CH002", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9803) },
                    { "T003", "A005", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9809), "Teach costume making", new DateTime(2025, 5, 22, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9808), "EC003", true, "New York", new DateTime(2025, 5, 21, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9808), 2, "CH003", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9810) },
                    { "T004", "A007", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9813), "Host a live event", new DateTime(2025, 5, 16, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9813), "EC004", true, "Online", new DateTime(2025, 5, 16, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9812), 3, "CH004", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9814) },
                    { "T005", "A008", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9817), "Professional cosplay photoshoot", new DateTime(2025, 5, 24, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9817), "EC005", true, "Paris", new DateTime(2025, 5, 23, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9816), 0, "CH005", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9818) },
                    { "T006", "A010", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9823), "Evaluate contestants", new DateTime(2025, 5, 26, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9823), "EC006", true, "Berlin", new DateTime(2025, 5, 25, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9822), 1, "CH006", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9824) },
                    { "T007", "A012", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9849), "Walk in parade", new DateTime(2025, 5, 28, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9849), "EC007", true, "Seoul", new DateTime(2025, 5, 27, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9848), 2, "CH007", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9850) },
                    { "T008", "A013", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9854), "Perform on live TV", new DateTime(2025, 5, 30, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9853), "EC008", true, "London", new DateTime(2025, 5, 29, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9852), 3, "CH008", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9855) },
                    { "T009", "A015", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9858), "Perform for charity", new DateTime(2025, 6, 1, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9858), "EC009", true, "Sydney", new DateTime(2025, 5, 31, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9857), 4, "CH008", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9859) },
                    { "T010", "A005", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9862), "Talk about cosplay industry", new DateTime(2025, 6, 3, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9862), "EC010", true, "San Diego", new DateTime(2025, 6, 2, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9861), 0, "CH009", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9863) },
                    { "T011", "A008", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9869), "New character shoot", new DateTime(2025, 6, 5, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9868), "EC011", true, "Bangkok", new DateTime(2025, 6, 4, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9868), 1, "CH010", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9869) },
                    { "T012", "A007", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9873), "Host main event", new DateTime(2025, 6, 7, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9872), "EC012", true, "Jakarta", new DateTime(2025, 6, 6, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9872), 2, "CH011", null, new DateTime(2025, 5, 15, 14, 51, 11, 276, DateTimeKind.Local).AddTicks(9873) }
                });

            migrationBuilder.InsertData(
                table: "ContractCharacter",
                columns: new[] { "ContractCharacterId", "CharacterId", "ContractId", "CosplayerId", "CreateDate", "Description", "Quantity", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "CC0021", "CH001", "CT002", null, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT002", 1, 150000.0, null },
                    { "CC0022", "CH002", "CT002", null, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT002", 5, 180000.0, null },
                    { "CC0023", "CH003", "CT002", null, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT002", 3, 170000.0, null },
                    { "CC0051", "CH004", "CT005", null, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT005", 2, 200000.0, null },
                    { "CC0052", "CH005", "CT005", null, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT005", 4, 250000.0, null },
                    { "CC0053", "CH006", "CT005", null, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT005", 6, 250000.0, null },
                    { "CC0081", "CH007", "CT008", "A001", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT008", 1, 120000.0, null },
                    { "CC0082", "CH008", "CT008", "A008", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT008", 1, 130000.0, null },
                    { "CC0083", "CH009", "CT008", "A040", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT008", 1, 100000.0, null },
                    { "CC0101", "CH010", "CT010", "A040", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT010", 1, 70000.0, null },
                    { "CC0102", "CH011", "CT010", "A039", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT010", 1, 80000.0, null },
                    { "CC0103", "CH012", "CT010", "A038", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT010", 1, 50000.0, null },
                    { "CC0141", "CH013", "CT014", "A035", new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT014", 1, 200000.0, null },
                    { "CC0142", "CH014", "CT014", "A040", new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT014", 1, 250000.0, null },
                    { "CC0143", "CH015", "CT014", "A005", new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT014", 1, 150000.0, null }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "AccountCouponID", "Amount", "ContractId", "CreatAt", "OrderId", "Purpose", "Status", "TicketAccountId", "TransactionId", "Type" },
                values: new object[,]
                {
                    { "P011", null, 325000.0, "CT002", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, null, "TXN011", "Online" },
                    { "P012", null, 410000.0, "CT005", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0, null, "TXN012", "Card" },
                    { "P013", null, 90000.0, "CT008", new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, null, "TXN013", "Cash" },
                    { "P014", null, 350000.0, "CT010", new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, null, "TXN014", "Online" },
                    { "P015", null, 200000.0, "CT002", new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, null, "TXN015", "Card" }
                });

            migrationBuilder.InsertData(
                table: "RequestDate",
                columns: new[] { "RequestDateId", "ContractCharacterId", "EndDate", "Reason", "RequestCharacterId", "StartDate", "Status" },
                values: new object[,]
                {
                    { "RD01", null, new DateTime(2025, 1, 10, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC01", new DateTime(2025, 1, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD02", null, new DateTime(2025, 1, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, "RC01", new DateTime(2025, 1, 11, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD03", null, new DateTime(2025, 1, 12, 14, 30, 0, 0, DateTimeKind.Unspecified), null, "RC01", new DateTime(2025, 1, 12, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD04", null, new DateTime(2025, 1, 13, 14, 30, 0, 0, DateTimeKind.Unspecified), null, "RC01", new DateTime(2025, 1, 13, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD05", null, new DateTime(2025, 1, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), null, "RC01", new DateTime(2025, 1, 14, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD06", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosplayer is busy", "RC02", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "RD07", null, new DateTime(2025, 4, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), null, "RC04", new DateTime(2025, 4, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD08", null, new DateTime(2025, 4, 11, 17, 0, 0, 0, DateTimeKind.Unspecified), null, "RC04", new DateTime(2025, 4, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD09", null, new DateTime(2025, 4, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), null, "RC04", new DateTime(2025, 4, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD10", null, new DateTime(2025, 4, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), null, "RC04", new DateTime(2025, 4, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD11", null, new DateTime(2025, 4, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), null, "RC04", new DateTime(2025, 4, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD12", null, new DateTime(2025, 4, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), null, "RC04", new DateTime(2025, 4, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD13", null, new DateTime(2025, 5, 3, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC05", new DateTime(2025, 5, 3, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD14", null, new DateTime(2025, 5, 4, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC05", new DateTime(2025, 5, 4, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD15", null, new DateTime(2025, 5, 5, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC05", new DateTime(2025, 5, 5, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD16", null, new DateTime(2025, 5, 6, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC05", new DateTime(2025, 5, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD17", null, new DateTime(2025, 5, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC05", new DateTime(2025, 5, 7, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD18", null, new DateTime(2025, 6, 12, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC06", new DateTime(2025, 6, 12, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD19", null, new DateTime(2025, 6, 13, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC06", new DateTime(2025, 6, 13, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD20", null, new DateTime(2025, 6, 14, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC06", new DateTime(2025, 6, 14, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD21", null, new DateTime(2025, 6, 15, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC06", new DateTime(2025, 6, 15, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD22", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosplayer is busy", "RC07", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "RD23", null, new DateTime(2025, 10, 25, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC10", new DateTime(2025, 10, 25, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD24", null, new DateTime(2025, 11, 20, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC11", new DateTime(2025, 11, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD25", null, new DateTime(2025, 12, 5, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC12", new DateTime(2025, 12, 5, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD26", null, new DateTime(2025, 12, 6, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC12", new DateTime(2025, 12, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD27", null, new DateTime(2025, 12, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC12", new DateTime(2025, 12, 7, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD28", null, new DateTime(2025, 12, 8, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC12", new DateTime(2025, 12, 8, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD29", null, new DateTime(2025, 12, 9, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC12", new DateTime(2025, 12, 9, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD30", null, new DateTime(2025, 12, 10, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC12", new DateTime(2025, 12, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD31", null, new DateTime(2025, 6, 30, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC14", new DateTime(2025, 6, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD32", null, new DateTime(2025, 7, 1, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC14", new DateTime(2025, 7, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD33", null, new DateTime(2025, 7, 2, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC14", new DateTime(2025, 7, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD34", null, new DateTime(2025, 12, 15, 16, 30, 0, 0, DateTimeKind.Unspecified), null, "RC15", new DateTime(2025, 12, 15, 8, 30, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractCharacterId", "CreateBy", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "0c2db30e-f077-46e6-b7bf-aad7630bc158", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", 5, null },
                    { "1f10cd22-82e0-48f9-8dbc-312696f0ec50", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", 5, null },
                    { "31cfe1aa-9e47-4173-9475-ee7f844aecc5", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", 5, null },
                    { "6f013ec8-a3f3-45a0-ab8d-74b1963a4e54", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", 5, null },
                    { "8ea72bb6-fea4-40fd-bf2d-9674ce5a5f89", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", 5, null },
                    { "91402b6f-33d9-4458-b311-2614faada4a9", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", 5, null },
                    { "cead75a5-6c33-4f80-addd-7b0802b1e161", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", 5, null },
                    { "d0dfa937-ae91-435d-98ed-be024f4b6370", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", 5, null },
                    { "f77e0634-f341-4711-888e-59aa255c8d75", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCoupon_AccountId",
                table: "AccountCoupon",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCoupon_CouponId",
                table: "AccountCoupon",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountImage_AccountId",
                table: "AccountImage",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_AccountId",
                table: "Cart",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_CartId",
                table: "CartProduct",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductId",
                table: "CartProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_CategoryId",
                table: "Character",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterImage_CharacterId",
                table: "CharacterImage",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_RequestId",
                table: "Contract",
                column: "RequestId",
                unique: true,
                filter: "[RequestId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCharacter_CharacterId",
                table: "ContractCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCharacter_ContractId",
                table: "ContractCharacter",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractImage_ContractId",
                table: "ContractImage",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRefund_ContractId",
                table: "ContractRefund",
                column: "ContractId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCharacter_CategoryId",
                table: "CustomerCharacter",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCharacterImage_CustomerCharacterId",
                table: "CustomerCharacterImage",
                column: "CustomerCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_EventActivity_ActivityId",
                table: "EventActivity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventActivity_EventId",
                table: "EventActivity",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCharacter_CharacterId",
                table: "EventCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCharacter_EventId",
                table: "EventCharacter",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventImage_EventId",
                table: "EventImage",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_AccountId",
                table: "Feedback",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ContractCharacterId",
                table: "Feedback",
                column: "ContractCharacterId",
                unique: true,
                filter: "[ContractCharacterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_AccountId",
                table: "Notification",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AccountId",
                table: "Order",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AccountCouponID",
                table: "Payment",
                column: "AccountCouponID",
                unique: true,
                filter: "[AccountCouponID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ContractId",
                table: "Payment",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_TicketAccountId",
                table: "Payment",
                column: "TicketAccountId",
                unique: true,
                filter: "[TicketAccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_AccountCouponId",
                table: "Request",
                column: "AccountCouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_AccountId",
                table: "Request",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_PackageId",
                table: "Request",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ServiceId",
                table: "Request",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestCharacter_CharacterId",
                table: "RequestCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestCharacter_RequestId",
                table: "RequestCharacter",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDate_ContractCharacterId",
                table: "RequestDate",
                column: "ContractCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDate_RequestCharacterId",
                table: "RequestDate",
                column: "RequestCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_AccountId",
                table: "Task",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ContractCharacterId",
                table: "Task",
                column: "ContractCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_EventCharacterId",
                table: "Task",
                column: "EventCharacterId",
                unique: true,
                filter: "[EventCharacterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EventId",
                table: "Ticket",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAccount_AccountId",
                table: "TicketAccount",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAccount_TicketId",
                table: "TicketAccount",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountImage");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "CharacterImage");

            migrationBuilder.DropTable(
                name: "ContractImage");

            migrationBuilder.DropTable(
                name: "ContractRefund");

            migrationBuilder.DropTable(
                name: "CustomerCharacterImage");

            migrationBuilder.DropTable(
                name: "EventActivity");

            migrationBuilder.DropTable(
                name: "EventImage");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "RequestDate");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "CustomerCharacter");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "TicketAccount");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "RequestCharacter");

            migrationBuilder.DropTable(
                name: "ContractCharacter");

            migrationBuilder.DropTable(
                name: "EventCharacter");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "AccountCoupon");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
