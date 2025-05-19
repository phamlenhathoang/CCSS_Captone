using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CCSS_Repository.Migrations
{
    /// <inheritdoc />
    public partial class CCSS_Migration_1 : Migration
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
                    { "ACT001", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6149), "A relaxing yoga session", "Yoga Class", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6149) },
                    { "ACT002", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6153), "Learn to cook delicious meals", "Cooking Workshop", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6154) },
                    { "ACT003", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6156), "Live music performance", "Music Concert", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6157) },
                    { "ACT004", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6159), "Showcase of local artists", "Art Exhibition", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6159) },
                    { "ACT005", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6161), "Discussion on latest technology trends", "Tech Talk", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6162) },
                    { "ACT006", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6163), "5K run for a good cause", "Charity Run", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6164) },
                    { "ACT007", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6166), "Monthly book discussion", "Book Club", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6166) },
                    { "ACT008", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6168), "Learn photography skills", "Photography Workshop", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6169) },
                    { "ACT009", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6171), "Dance battle for all ages", "Dance Competition", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6171) },
                    { "ACT010", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6175), "Competitive chess matches", "Chess Tournament", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6175) },
                    { "ACT011", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6177), "Outdoor movie screening", "Movie Night", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6177) },
                    { "ACT012", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6179), "Showcase of scientific projects", "Science Fair", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6179) },
                    { "ACT013", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6181), "Intensive coding workshop", "Coding Bootcamp", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6182) },
                    { "ACT014", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6183), "Learn gardening techniques", "Gardening Workshop", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6184) },
                    { "ACT015", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6186), "Guided meditation practice", "Meditation Session", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6186) }
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
                    { "E001", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4554), "A grand celebration to welcome the new year", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Year Festival", true, "Times Square, New York", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E002", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4558), "Experience the beauty of cherry blossoms", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring Blossom Fest", true, "Kyoto, Japan", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E003", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4561), "Showcasing the latest in technology and AI", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Innovation Summit", true, "Silicon Valley", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E004", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4592), "Live performances from top artists", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music Fest", true, "Coachella, California", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E005", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4597), "A must-attend event for comic book fans", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comic-Con International", true, "San Diego Convention Center", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E006", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4600), "Largest anime convention in the world", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anime Expo", true, "Los Angeles Convention Center", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E007", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4603), "Latest trends and releases in gaming", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Expo", true, "Las Vegas Convention Center", new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E008", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4606), "A fun-filled summer celebration", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Festival", true, "Miami Beach, Florida", new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E009", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4609), "A paradise for cosplayers", new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosplay Festival", true, "Tokyo Big Sight", new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E010", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4613), "Showcasing the best movies of the year", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Festival", true, "Cannes, France", new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E011", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4615), "Spooky celebrations and costume parties", new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween Night", true, "Salem, Massachusetts", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "E012", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4618), "Festive shopping and holiday cheer", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Market", true, "Nuremberg, Germany", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
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
                    { "P001", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4457), "A wig for Naruto cosplay", true, 30000.0, "Naruto Wig", 10, null, 10, 30, 200, 20 },
                    { "P002", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4463), "A hat for Mario cosplay", true, 20000.0, "Mario Hat", 15, null, 15, 25, 100, 25 },
                    { "P003", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4466), "Complete costume for Sasuke cosplay", true, 80000.0, "Sasuke Costume", 5, null, 15, 50, 800, 40 },
                    { "P004", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4471), "Replica sword from The Legend of Zelda", true, 100000.0, "Zelda Sword", 7, null, 5, 120, 1500, 15 },
                    { "P005", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4474), "Iconic straw hat from One Piece", true, 25000.0, "One Piece Straw Hat", 20, null, 10, 35, 300, 35 },
                    { "P006", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4477), "Hatsune Miku blue twin-tail wig", true, 40000.0, "Miku Wig", 12, null, 5, 40, 150, 25 },
                    { "P007", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4482), "Tanjiro's iconic hanafuda earrings", true, 15000.0, "Demon Slayer Earrings", 30, null, 3, 5, 50, 5 },
                    { "P008", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4485), "Survey Corps uniform jacket", true, 50000.0, "Attack on Titan Jacket", 10, null, 5, 50, 800, 40 },
                    { "P009", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4489), "Cozy Pikachu-themed onesie", true, 60000.0, "Pikachu Onesie", 8, null, 10, 60, 700, 50 },
                    { "P010", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4492), "Final Fantasy VII replica sword", true, 120000.0, "Cloud's Buster Sword", 4, null, 10, 160, 2000, 25 },
                    { "P011", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4495), "LED Vision accessory from Genshin Impact", true, 35000.0, "Genshin Impact Vision", 25, null, 5, 10, 100, 10 },
                    { "P012", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4499), "Jinx cosplay wig from Arcane", true, 45000.0, "Jinx Wig", 6, null, 10, 40, 250, 25 },
                    { "P013", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4502), "Golden tiara from Sailor Moon", true, 18000.0, "Sailor Moon Tiara", 15, null, 5, 15, 50, 15 },
                    { "P014", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4505), "High-quality Spider-Man suit", true, 90000.0, "Spider-Man Suit", 3, null, 5, 70, 1500, 40 },
                    { "P015", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4508), "Replica wand from Harry Potter series", true, 22000.0, "Harry Potter Wand", 50, null, 5, 35, 200, 5 }
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
                    { "S001", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4411), "Rent characters for events and parties", "Character Rental", null },
                    { "S002", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4414), "Live cosplay performances at events", "Cosplay Rental", null },
                    { "S003", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4415), "Professional photoshoot with cosplayers", "Create event", null }
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
                    { "CH001", "C3", "Naruto", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4197), "Ninja from Konoha", true, 180f, 80f, 160f, 50f, 100000.0, 100, null },
                    { "CH002", "C3", "Sasuke", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4202), "Naruto’s rival", true, 185f, 85f, 165f, 55f, 120000.0, 100, null },
                    { "CH003", "C3", "Goku", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4207), "Saiyan warrior", true, 190f, 90f, 170f, 60f, 150000.0, 100, null },
                    { "CH004", "C4", "Luffy", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4212), "Pirate King", true, 175f, 70f, 155f, 45f, 110000.0, 100, null },
                    { "CH005", "C4", "Ichigo", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4216), "Soul Reaper", true, 185f, 85f, 165f, 55f, 130000.0, 100, null },
                    { "CH006", "C14", "Mario", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4300), "Plumber hero", true, 180f, 80f, 160f, 60f, 80000.0, 100, null },
                    { "CH007", "C14", "Luigi", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4304), "Mario’s brother", true, 170f, 75f, 150f, 55f, 85000.0, 100, null },
                    { "CH008", "C14", "Link", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4307), "Hero of Hyrule", true, 180f, 80f, 160f, 50f, 140000.0, 100, null },
                    { "CH009", "C16", "Zelda", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4312), "Hyrule princess", true, 175f, 70f, 155f, 50f, 135000.0, 100, null },
                    { "CH010", "C16", "Samus", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4316), "Bounty hunter", true, 185f, 85f, 165f, 55f, 145000.0, 100, null },
                    { "CH011", "C13", "Cloud", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4321), "Ex-SOLDIER", true, 185f, 85f, 165f, 55f, 125000.0, 100, null },
                    { "CH012", "C13", "Sephiroth", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4325), "One-Winged Angel", true, 190f, 90f, 170f, 60f, 155000.0, 100, null },
                    { "CH013", "C8", "Kratos", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4328), "God of War", true, 195f, 100f, 175f, 70f, 160000.0, 100, null },
                    { "CH014", "C8", "Pikachu", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4332), "Electric Pokemon", true, 180f, 80f, 160f, 60f, 90000.0, 100, null },
                    { "CH015", "C8", "Kirby", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(4335), "Pink puffball", true, 180f, 80f, 160f, 60f, 95000.0, 100, null }
                });

            migrationBuilder.InsertData(
                table: "EventActivity",
                columns: new[] { "EventActivityId", "ActivityId", "CreateBy", "CreateDate", "Description", "EventId", "UpdateDate" },
                values: new object[,]
                {
                    { "EA001", "ACT001", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5986), "Yoga for a fresh start", "E001", null },
                    { "EA002", "ACT005", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5989), "Tech trends in the new year", "E001", null },
                    { "EA003", "ACT004", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5991), "Painting cherry blossoms", "E002", null },
                    { "EA004", "ACT013", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5993), "AI and future coding", "E003", null },
                    { "EA005", "ACT009", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5995), "Dance battles live", "E004", null },
                    { "EA006", "ACT003", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5997), "Comic-Con live music", "E005", null },
                    { "EA007", "ACT007", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5999), "Anime and book discussions", "E006", null },
                    { "EA008", "ACT010", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6002), "Chess and gaming", "E007", null },
                    { "EA009", "ACT011", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6004), "Outdoor movie fun", "E008", null },
                    { "EA010", "ACT015", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6006), "Meditation for cosplayers", "E009", null },
                    { "EA011", "ACT012", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6008), "Science in filmmaking", "E010", null },
                    { "EA012", "ACT006", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6010), "Halloween charity run", "E011", null },
                    { "EA013", "ACT014", "Admin", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6012), "Christmas gardening", "E012", null },
                    { "EA014", "ACT002", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6014), "Cooking for music lovers", "E004", null },
                    { "EA015", "ACT008", "Manager", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6016), "Photography in tech", "E003", null }
                });

            migrationBuilder.InsertData(
                table: "EventImage",
                columns: new[] { "ImageId", "CreateDate", "EventId", "ImageUrl", "IsAvatar", "UpdateDate" },
                values: new object[,]
                {
                    { "EI001", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6472), "E001", "https://example.com/event1.jpg", null, null },
                    { "EI002", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6475), "E002", "https://example.com/event2.jpg", null, null },
                    { "EI003", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6477), "E003", "https://example.com/event3.jpg", null, null },
                    { "EI004", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6480), "E004", "https://example.com/event4.jpg", null, null },
                    { "EI005", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6482), "E005", "https://example.com/event5.jpg", null, null },
                    { "EI006", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6483), "E006", "https://example.com/event6.jpg", null, null },
                    { "EI007", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6485), "E007", "https://example.com/event7.jpg", null, null },
                    { "EI008", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6548), "E008", "https://example.com/event8.jpg", null, null },
                    { "EI009", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6550), "E009", "https://example.com/event9.jpg", null, null },
                    { "EI010", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6551), "E010", "https://example.com/event10.jpg", null, null },
                    { "EI011", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6553), "E011", "https://example.com/event11.jpg", null, null },
                    { "EI012", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6556), "E012", "https://example.com/event12.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "ProductImageId", "CreateDate", "IsAvatar", "ProductId", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "IMG001", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6810), null, "P001", null, "https://example.com/images/naruto_wig.jpg" },
                    { "IMG002", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6813), null, "P002", null, "https://example.com/images/mario_hat.jpg" },
                    { "IMG003", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6814), null, "P003", null, "https://example.com/images/sasuke_costume.jpg" },
                    { "IMG004", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6816), null, "P004", null, "https://example.com/images/zelda_sword.jpg" },
                    { "IMG005", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6819), null, "P005", null, "https://example.com/images/one_piece_hat.jpg" },
                    { "IMG006", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6821), null, "P006", null, "https://example.com/images/miku_wig.jpg" },
                    { "IMG007", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6823), null, "P007", null, "https://example.com/images/demon_slayer_earrings.jpg" },
                    { "IMG008", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6824), null, "P008", null, "https://example.com/images/aot_jacket.jpg" },
                    { "IMG009", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6826), null, "P009", null, "https://example.com/images/pikachu_onesie.jpg" },
                    { "IMG010", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6828), null, "P010", null, "https://example.com/images/buster_sword.jpg" },
                    { "IMG011", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6829), null, "P011", null, "https://example.com/images/genshin_vision.jpg" },
                    { "IMG012", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6831), null, "P012", null, "https://example.com/images/jinx_wig.jpg" },
                    { "IMG013", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6866), null, "P013", null, "https://example.com/images/sailor_moon_tiara.jpg" },
                    { "IMG014", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6868), null, "P014", null, "https://example.com/images/spiderman_suit.jpg" },
                    { "IMG015", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6869), null, "P015", null, "https://example.com/images/harry_potter_wand.jpg" }
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
                    { "AI01", "A001", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3582), true, null, "https://tftravel.com.vn/wp-content/uploads/2021/02/team-1.jpg" },
                    { "AI02", "A001", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3608), false, null, "https://i.pinimg.com/originals/a6/bc/25/a6bc259bd4209b1f9dddf93607f68644.jpg" },
                    { "AI03", "A001", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3610), false, null, "https://i.pinimg.com/736x/a9/2a/9e/a92a9ed46b8cc1067dc20840d3c4fee5.jpg" },
                    { "AI04", "A001", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3612), false, null, "https://i.pinimg.com/736x/4e/86/e2/4e86e2cfd4b1b45e5faa6cf872b1a905.jpg" },
                    { "AI05", "A002", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3614), true, null, "https://i.pinimg.com/736x/f1/82/ce/f182ce676795a62d00036da861a90c33.jpg" },
                    { "AI06", "A002", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3616), false, null, "https://i.pinimg.com/736x/aa/95/35/aa953549f4b2bb159d9e726e3ff3a2ed.jpg" },
                    { "AI07", "A002", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3618), false, null, "https://i.pinimg.com/736x/3b/d8/1b/3bd81b616374e74b3fa33dbc916dbfcc.jpg" },
                    { "AI08", "A002", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3620), false, null, "https://i.pinimg.com/736x/93/f9/d8/93f9d842e536468ff7503d6ceda91dca.jpg" },
                    { "AI09", "A005", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3622), true, null, "https://i.pinimg.com/736x/15/f5/46/15f546b7df5498113d23bb5b02497548.jpg" },
                    { "AI10", "A005", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3626), false, null, "https://i.pinimg.com/736x/b0/8c/a9/b08ca9db4b5c47fe25428da2823c9a41.jpg" },
                    { "AI100", "A036", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3888), false, null, "https://i.pinimg.com/736x/af/be/4f/afbe4f62dff502301f9548ac69878f58.jpg" },
                    { "AI101", "A037", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3890), true, null, "https://i.pinimg.com/736x/74/2b/1e/742b1ee0648e30cf46515a001b69e950.jpg" },
                    { "AI102", "A037", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3892), false, null, "https://i.pinimg.com/736x/43/25/52/432552136be3eec79b86c1612918718d.jpg" },
                    { "AI103", "A037", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3894), false, null, "https://i.pinimg.com/736x/66/da/19/66da19604347b4eb703df694703dbafe.jpg" },
                    { "AI104", "A037", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3895), false, null, "https://i.pinimg.com/736x/09/85/bd/0985bdb9abb1ba2006ea5bbaa0156216.jpg" },
                    { "AI105", "A038", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3897), true, null, "https://i.pinimg.com/736x/32/af/33/32af3330425fb3506f3dc3b26f42977d.jpg" },
                    { "AI106", "A038", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3901), false, null, "https://i.pinimg.com/736x/51/f6/0f/51f60f776fd573c1a5c0e0c40dea6ce4.jpg" },
                    { "AI107", "A038", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3903), false, null, "https://i.pinimg.com/736x/bc/01/96/bc019677d32019f157b65a1b52cf8525.jpg" },
                    { "AI108", "A038", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3905), false, null, "https://i.pinimg.com/736x/21/ab/2e/21ab2ea44c87f1ccb5a045fbc108fd5b.jpg" },
                    { "AI109", "A039", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3908), true, null, "https://i.pinimg.com/736x/ea/0d/7d/ea0d7d7bea568bb90db6249962a47e44.jpg" },
                    { "AI11", "A005", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3627), false, null, "https://i.pinimg.com/736x/fb/ec/67/fbec67d903362ff4ffd6bc4489f4910d.jpg" },
                    { "AI110", "A039", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3910), false, null, "https://i.pinimg.com/736x/83/ee/3f/83ee3fabf7711cf45ffe138f56e721cb.jpg" },
                    { "AI111", "A039", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3912), false, null, "https://i.pinimg.com/736x/7d/e4/20/7de420bbb605367225dcf49c8bc1dfc5.jpg" },
                    { "AI112", "A039", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3914), false, null, "https://i.pinimg.com/736x/cd/1e/69/cd1e695a7a4975899d35355af795a1b4.jpg" },
                    { "AI113", "A040", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3916), true, null, "https://i.pinimg.com/736x/96/5f/0d/965f0d17bb49f04319ff92d8386f376b.jpg" },
                    { "AI114", "A040", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3920), false, null, "https://i.pinimg.com/736x/44/87/2d/44872d8ee209e36937d28ce37d9185b2.jpg" },
                    { "AI115", "A040", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3922), false, null, "https://i.pinimg.com/736x/2c/a9/7f/2ca97f876142eb705b5e7b4f2575921f.jpg" },
                    { "AI116", "A040", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3923), false, null, "https://i.pinimg.com/736x/28/3a/6f/283a6fe7b75a8fac14f39e455c5ddf3e.jpg" },
                    { "AI117", "A013", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3925), true, null, "https://i.pinimg.com/736x/61/d6/b1/61d6b1e5b709639b723bb5089152d6d3.jpg" },
                    { "AI118", "A013", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3927), false, null, "https://i.pinimg.com/736x/50/ae/27/50ae27b2034b85d2a7bf4d034d5e572a.jpg" },
                    { "AI119", "A013", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3930), false, null, "https://i.pinimg.com/736x/39/16/78/391678508450a4ee33776c39fdf2c1ef.jpg" },
                    { "AI12", "A005", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3629), false, null, "https://i.pinimg.com/736x/6f/86/0a/6f860aa99e78fdd33ad516dfb84fb13f.jpg" },
                    { "AI120", "A013", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3932), false, null, "https://i.pinimg.com/736x/69/15/b9/6915b9ffa19b89e6f1543e05b5b26f70.jpg" },
                    { "AI121", "A028", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3934), true, null, "https://i.pinimg.com/736x/14/ca/61/14ca61522c3d813c3ea62c4710828ce2.jpg" },
                    { "AI122", "A028", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3937), false, null, "https://i.pinimg.com/736x/4e/97/cc/4e97ccc8f6959a693ac2ad75c13604c7.jpg" },
                    { "AI123", "A028", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3941), false, null, "https://i.pinimg.com/474x/d0/47/cb/d047cbd5b9af39284b7196b273d133a3.jpg" },
                    { "AI124", "A028", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3943), false, null, "https://i.pinimg.com/736x/dc/61/5d/dc615d9f585f76243510fb7e8c7af1d8.jpg" },
                    { "AI125", "A029", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3945), true, null, "https://i.pinimg.com/736x/16/d8/88/16d8888fe52fedf56766a7511c42be69.jpg" },
                    { "AI126", "A029", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3947), false, null, "https://i.pinimg.com/736x/e0/e1/0a/e0e10ace79a99cc678fe9aedfbfdfa83.jpg" },
                    { "AI127", "A029", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3949), false, null, "https://i.pinimg.com/736x/3e/6c/cd/3e6ccdb41eed4ac91ac04b39a4b15694.jpg" },
                    { "AI128", "A029", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3968), false, null, "https://i.pinimg.com/736x/eb/58/42/eb58427dffb8c0c20637df1713a583a8.jpg" },
                    { "AI129", "A025", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3972), true, null, "https://i.pinimg.com/736x/cd/ab/48/cdab4817b7b49287dc3a9531ac99dfae.jpg" },
                    { "AI13", "A007", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3631), true, null, "https://i.pinimg.com/736x/ca/42/d9/ca42d9541580d5542fa29a568a68a714.jpg" },
                    { "AI130", "A025", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3975), false, null, "https://i.pinimg.com/736x/30/34/ea/3034ea8302054e693520957c194decae.jpg" },
                    { "AI131", "A025", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3977), false, null, "https://i.pinimg.com/736x/f4/4b/de/f44bdec05cf7826b67c2030613374ecb.jpg" },
                    { "AI132", "A025", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3979), false, null, "https://i.pinimg.com/736x/fa/c1/ef/fac1efe39388d64003b1ec4c7d2d05e8.jpg" },
                    { "AI133", "A015", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3981), true, null, "https://i.pinimg.com/736x/94/c2/69/94c269ee90d0d8a5584a7a48207f50ca.jpg" },
                    { "AI134", "A015", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3983), false, null, "https://i.pinimg.com/736x/2d/96/29/2d96299467843d2876516493ade1eea3.jpg" },
                    { "AI135", "A015", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3985), false, null, "https://i.pinimg.com/736x/e4/df/f6/e4dff6f0e30260a73019f5d1a44cd8ec.jpg" },
                    { "AI136", "A015", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3988), false, null, "https://i.pinimg.com/736x/9e/4f/2a/9e4f2ab84f5d8e3c4e36ad2c5c3962e2.jpg" },
                    { "AI14", "A007", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3633), false, null, "https://i.pinimg.com/736x/3e/ba/30/3eba305131695dd20a6a1203fe955c04.jpg" },
                    { "AI15", "A007", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3636), false, null, "https://i.pinimg.com/736x/15/0c/3c/150c3c6df16d0f3b976f07529801a8e5.jpg" },
                    { "AI16", "A007", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3638), false, null, "https://i.pinimg.com/736x/04/56/a8/0456a8ccfe96917fdc56703d2e3cca17.jpg" },
                    { "AI17", "A008", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3640), true, null, "https://i.pinimg.com/736x/4a/1d/4d/4a1d4d05f09b833adb9a78af8be2137f.jpg" },
                    { "AI18", "A008", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3644), false, null, "https://i.pinimg.com/736x/2b/80/60/2b8060ca82bfb42642f1ec4aefe39428.jpg" },
                    { "AI19", "A008", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3646), false, null, "https://i.pinimg.com/736x/81/6b/79/816b79ab93e73d6240177d7da8e345a8.jpg" },
                    { "AI20", "A008", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3647), false, null, "https://i.pinimg.com/736x/da/69/57/da695796f69212dfb2440d2b2e3f6800.jpg" },
                    { "AI21", "A010", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3650), true, null, "https://i.pinimg.com/736x/a5/67/52/a56752ef994d5c6cf6499b4cef52e2f7.jpg" },
                    { "AI22", "A010", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3652), false, null, "https://i.pinimg.com/736x/e8/79/74/e87974221b2c629e6b8652d69e8d137d.jpg" },
                    { "AI23", "A010", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3654), false, null, "https://i.pinimg.com/736x/99/84/d9/9984d9e425ac3663fe5d24e49cb38eed.jpg" },
                    { "AI24", "A010", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3656), false, null, "https://i.pinimg.com/736x/47/ec/be/47ecbea5cfac28fafe8e19faaa355342.jpg" },
                    { "AI25", "A012", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3658), true, null, "https://i.pinimg.com/736x/ef/ba/25/efba25ef9c63e7294340de6f14048795.jpg" },
                    { "AI26", "A012", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3661), false, null, "https://i.pinimg.com/736x/93/d2/55/93d2552c5c6a0f90d867c4617f33d0d1.jpg" },
                    { "AI27", "A012", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3663), false, null, "https://i.pinimg.com/736x/7e/62/d7/7e62d70e323b92b166026ab145e1703e.jpg" },
                    { "AI28", "A012", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3666), false, null, "https://i.pinimg.com/736x/42/de/11/42de11b557fe83b3040178671db20b73.jpg" },
                    { "AI29", "A016", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3668), true, null, "https://i.pinimg.com/736x/c6/49/e8/c649e8f88170ebf177e6910bfc518696.jpg" },
                    { "AI30", "A016", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3670), false, null, "https://i.pinimg.com/736x/77/3d/e8/773de85e694e8f88ed08ff5509ae4355.jpg" },
                    { "AI31", "A016", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3672), false, null, "https://i.pinimg.com/736x/26/94/bd/2694bd3519bcfd0cdf518d6b5ead8684.jpg" },
                    { "AI32", "A016", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3674), false, null, "https://i.pinimg.com/736x/83/67/8f/83678f4941b8d106136201deebb26bc7.jpg" },
                    { "AI33", "A017", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3676), true, null, "https://i.pinimg.com/736x/95/57/ce/9557ce89bef894c11242f90d0e11ed88.jpg" },
                    { "AI34", "A017", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3679), false, null, "https://i.pinimg.com/736x/6c/3d/32/6c3d329db2a87ce681754b0a70040d07.jpg" },
                    { "AI35", "A017", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3681), false, null, "https://i.pinimg.com/736x/04/5b/91/045b9179ebdede69c3aba42195fd47b2.jpg" },
                    { "AI36", "A017", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3683), false, null, "https://i.pinimg.com/736x/05/7c/0a/057c0a4c922c6f98b8d9715bb537ab83.jpg" },
                    { "AI37", "A018", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3685), true, null, "https://i.pinimg.com/736x/8a/ef/b2/8aefb28db28939806440e3de90c5b029.jpg" },
                    { "AI38", "A018", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3687), false, null, "https://i.pinimg.com/736x/53/75/08/537508f69d893602a3cbb031ae699ba5.jpg" },
                    { "AI39", "A018", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3717), false, null, "https://i.pinimg.com/736x/0f/f2/67/0ff26774a0f4fd7745a77d92dc1a3443.jpg" },
                    { "AI40", "A018", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3719), false, null, "https://i.pinimg.com/736x/dd/a5/9b/dda59b436bb82a60da6910e9b556b932.jpg" },
                    { "AI41", "A019", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3721), true, null, "https://i.pinimg.com/736x/6b/c9/c4/6bc9c4075b37202e3bdaa445e0337b13.jpg" },
                    { "AI42", "A019", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3727), false, null, "https://i.pinimg.com/736x/14/a7/87/14a7874490c3b61fab4651ae5ff4112f.jpg" },
                    { "AI43", "A019", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3729), false, null, "https://i.pinimg.com/736x/20/54/f4/2054f48bdc17b91f279938674cbd33ad.jpg" },
                    { "AI44", "A019", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3731), false, null, "https://i.pinimg.com/736x/60/9c/43/609c434fb92fa95266c7be06fe96efbc.jpg" },
                    { "AI45", "A020", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3733), true, null, "https://i.pinimg.com/736x/b8/27/d8/b827d8c8a295985347865df94088c597.jpg" },
                    { "AI46", "A020", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3736), false, null, "https://i.pinimg.com/736x/7b/34/c1/7b34c1cd28ce80067fa749c5009ac7c7.jpg" },
                    { "AI47", "A020", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3738), false, null, "https://i.pinimg.com/736x/95/88/d1/9588d11d286959114820ba9db75495dd.jpg" },
                    { "AI48", "A020", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3740), false, null, "https://i.pinimg.com/736x/6e/2d/24/6e2d2433a754c2c40da9b43a8f8ddeb5.jpg" },
                    { "AI49", "A021", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3742), true, null, "https://i.pinimg.com/736x/5e/42/2d/5e422d974040651b04ed142b92b458dc.jpg" },
                    { "AI50", "A021", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3746), false, null, "https://i.pinimg.com/736x/38/9f/7b/389f7b75e44c3ac7b6a88822fc750a07.jpg" },
                    { "AI51", "A021", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3747), false, null, "https://i.pinimg.com/736x/20/47/c7/2047c724f925d1245fa8fe16d2358e34.jpg" },
                    { "AI52", "A021", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3749), false, null, "https://i.pinimg.com/736x/81/99/9a/81999a3e8311019965629487ead07a76.jpg" },
                    { "AI53", "A022", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3751), true, null, "https://i.pinimg.com/736x/cd/87/ed/cd87ed57b54707beda273ab7859e0aa2.jpg" },
                    { "AI54", "A022", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3753), false, null, "https://i.pinimg.com/736x/9a/38/21/9a3821d24193b383790a027b4010a90e.jpg" },
                    { "AI55", "A022", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3756), false, null, "https://i.pinimg.com/736x/e8/29/e0/e829e0a56266a7ad2e1cb246d3ae8485.jpg" },
                    { "AI56", "A022", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3758), false, null, "https://i.pinimg.com/736x/62/b2/41/62b241944f967787d4f42e1bb8f39150.jpg" },
                    { "AI57", "A023", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3760), true, null, "https://i.pinimg.com/736x/06/fc/aa/06fcaa6e24a14618e2b311626f0e1731.jpg" },
                    { "AI58", "A023", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3765), false, null, "https://i.pinimg.com/736x/c9/1b/40/c91b40ea5039f9ba77c6818c562c5e03.jpg" },
                    { "AI59", "A023", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3767), false, null, "https://i.pinimg.com/736x/12/bc/af/12bcaf16db2536b5efcd0151e4b3961f.jpg" },
                    { "AI60", "A023", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3769), false, null, "https://i.pinimg.com/736x/da/0e/62/da0e62808a44ae34ea64fbed4d53d985.jpg" },
                    { "AI61", "A024", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3771), true, null, "https://i.pinimg.com/736x/62/28/d6/6228d67af0d1ec8fb29c6c2a4caab140.jpg" },
                    { "AI62", "A024", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3773), false, null, "https://i.pinimg.com/736x/16/f2/ed/16f2ed550316d9b9e6b711bf5db48199.jpg" },
                    { "AI63", "A024", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3775), false, null, "https://i.pinimg.com/736x/24/0c/a6/240ca6f928fd4a14f5d374587a79ca15.jpg" },
                    { "AI64", "A024", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3777), false, null, "https://i.pinimg.com/736x/08/5b/6f/085b6fea8dec2b94ae9f61b7371bd673.jpg" },
                    { "AI65", "A026", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3779), true, null, "https://i.pinimg.com/736x/29/27/31/29273169c4efa0a8e6046a12f2da2acc.jpg" },
                    { "AI66", "A026", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3782), false, null, "https://i.pinimg.com/736x/ac/88/35/ac88358182a19358f733c55167609eca.jpg" },
                    { "AI67", "A026", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3784), false, null, "https://i.pinimg.com/736x/77/62/ab/7762abfda62f20753c0178876c1d2502.jpg" },
                    { "AI68", "A026", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3786), false, null, "https://i.pinimg.com/736x/04/12/23/041223a462f501f104f50ff14db702f6.jpg" },
                    { "AI69", "A027", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3788), true, null, "https://i.pinimg.com/736x/1f/ab/c6/1fabc6a5b521f216a23f342e4a0d6693.jpg" },
                    { "AI70", "A027", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3790), false, null, "https://i.pinimg.com/736x/16/8b/93/168b93c1d23074062772105e918cc6fb.jpg" },
                    { "AI71", "A027", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3792), false, null, "https://i.pinimg.com/736x/5d/b4/0f/5db40fd8b35c811b26766a82b7bdc3fe.jpg" },
                    { "AI72", "A027", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3794), false, null, "https://i.pinimg.com/736x/db/7c/11/db7c11ca40d3a7a298b5883f59212e6f.jpg" },
                    { "AI73", "A030", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3796), true, null, "https://i.pinimg.com/736x/4c/4d/f1/4c4df13ca300caf1b6b44e04d7bc850b.jpg" },
                    { "AI74", "A030", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3799), false, null, "https://i.pinimg.com/736x/01/3b/f2/013bf2519246b18ad649a2b46fb555fb.jpg" },
                    { "AI75", "A030", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3802), false, null, "https://i.pinimg.com/736x/92/c0/94/92c094471ff7fd4f62c5ffb60ecbb631.jpg" },
                    { "AI76", "A030", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3804), false, null, "https://i.pinimg.com/736x/8b/5f/c4/8b5fc4a0731c8f1b2e0a260990f4a652.jpg" },
                    { "AI77", "A031", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3806), true, null, "https://i.pinimg.com/736x/fa/11/d0/fa11d0ff1344020f8836c36a65750588.jpg" },
                    { "AI78", "A031", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3808), false, null, "https://i.pinimg.com/736x/32/2e/c3/322ec31c264453cb1cefe341c33bab47.jpg" },
                    { "AI79", "A031", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3810), false, null, "https://i.pinimg.com/736x/a9/76/07/a97607d31abf66ac67fe1e98cca5b1d5.jpg" },
                    { "AI80", "A031", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3813), false, null, "https://i.pinimg.com/736x/b0/45/2d/b0452d15257ce22d4c714cb3256f5223.jpg" },
                    { "AI81", "A032", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3815), true, null, "https://i.pinimg.com/736x/b9/ba/fd/b9bafd46360e4fe812a98b64959eacaf.jpg" },
                    { "AI82", "A032", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3818), false, null, "https://i.pinimg.com/736x/b8/e6/76/b8e67682a4b3d90285c1c703b1ab09eb.jpg" },
                    { "AI83", "A032", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3820), false, null, "https://i.pinimg.com/736x/b3/74/c4/b374c47dd21214efb855a4f4549c41c4.jpg" },
                    { "AI84", "A032", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3849), false, null, "https://i.pinimg.com/736x/5b/7c/54/5b7c54189d8ce4d3bf9b2cc01eeef1fc.jpg" },
                    { "AI85", "A033", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3851), true, null, "https://i.pinimg.com/736x/34/18/22/34182254b22d2132d36b4d78a6b263e5.jpg" },
                    { "AI86", "A033", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3853), false, null, "https://i.pinimg.com/736x/d2/37/86/d237864b3e34810b5433b9526ae4ad0b.jpg" },
                    { "AI87", "A033", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3855), false, null, "https://i.pinimg.com/736x/54/cd/6c/54cd6c312e0dc5066d2c9fbdf6f43868.jpg" },
                    { "AI88", "A033", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3857), false, null, "https://i.pinimg.com/736x/63/71/9c/63719c13e8f733cdd977a4b53aaba0b3.jpg" },
                    { "AI89", "A034", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3859), true, null, "https://i.pinimg.com/736x/eb/a4/99/eba4995776296a9e7976cfd8910fe89d.jpg" },
                    { "AI90", "A034", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3863), false, null, "https://i.pinimg.com/736x/56/07/bf/5607bf1c6dccf0b3ebc2c4c6d7a52acf.jpg" },
                    { "AI91", "A034", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3865), false, null, "https://i.pinimg.com/736x/2e/e6/50/2ee650a3044c4874fdc1179c25f4fa6c.jpg" },
                    { "AI92", "A034", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3867), false, null, "https://i.pinimg.com/736x/9f/86/9a/9f869a68e316f2ee6e38fe0f0e8526d4.jpg" },
                    { "AI93", "A035", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3869), true, null, "https://i.pinimg.com/736x/c0/95/f2/c095f2e3430c2558ad3c8df49c97637b.jpg" },
                    { "AI94", "A035", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3871), false, null, "https://i.pinimg.com/736x/c6/43/a4/c643a40e94d0a38453ea5de5fd25258d.jpg" },
                    { "AI95", "A035", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3873), false, null, "https://i.pinimg.com/736x/84/d2/49/84d249395f122117ecebd58329c4f6fa.jpg" },
                    { "AI96", "A035", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3876), false, null, "https://i.pinimg.com/736x/3b/e4/2f/3be42fafce1256eb99727fcb3b6ef6c9.jpg" },
                    { "AI97", "A036", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3881), true, null, "https://i.pinimg.com/736x/9b/00/c0/9b00c0393fa9b8b34fc0646984c0cd28.jpg" },
                    { "AI98", "A036", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3884), false, null, "https://i.pinimg.com/736x/c4/ef/c4/c4efc41aa1272888f3900a4e84c11050.jpg" },
                    { "AI99", "A036", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(3886), false, null, "https://i.pinimg.com/736x/2e/aa/04/2eaa0421302548f3844c2cb37f0c8d26.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "AccountId", "CreateDate", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "C001", "A003", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5403), 0.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5403) },
                    { "C002", "A006", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5405), 0.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5406) },
                    { "C003", "A011", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5408), 0.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5408) },
                    { "C004", "A014", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5410), 0.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5411) }
                });

            migrationBuilder.InsertData(
                table: "CharacterImage",
                columns: new[] { "CharacterImageId", "CharacterId", "CreateDate", "IsAvatar", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "CI001", "CH001", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6412), null, null, "https://ae01.alicdn.com/kf/HTB1gQt5aO6guuRkSnb4q6zu4XXaw/Naruto-Cosplay-Costumes-Anime-Naruto-Outfit-For-Man-Show-Suits-Japanese-Cartoon-Costumes-Naruto-Coat-Top.jpg" },
                    { "CI002", "CH002", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6416), null, null, "https://lzd-img-global.slatic.net/g/ff/kf/Sfedbbf9e61af4bc5a4ce107829ab12ffP.jpg_720x720q80.jpg" },
                    { "CI003", "CH003", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6420), null, null, "https://tse2.mm.bing.net/th/id/OIP.7wO0lin122XZz8cW6QwMPwHaNK?rs=1&pid=ImgDetMain" },
                    { "CI004", "CH004", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6421), null, null, "https://th.bing.com/th/id/R.a547136c5dc32ca575032d919b616c81?rik=QB63jSYlpxVIDg&pid=ImgRaw&r=0" },
                    { "CI005", "CH005", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6423), null, null, "https://tse3.mm.bing.net/th/id/OIP.Iv-VMJCvgXjXP3seS54VUQHaIj?rs=1&pid=ImgDetMain" },
                    { "CI006", "CH006", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6425), null, null, "https://i.pinimg.com/736x/88/67/c2/8867c200a089728d7e5fc0893c4b768d.jpg" },
                    { "CI007", "CH007", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6427), null, null, "https://tse1.explicit.bing.net/th/id/OIP.v9qz5NCIL7XhgBUU1rnkLQHaKL?rs=1&pid=ImgDetMain" },
                    { "CI008", "CH008", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6428), null, null, "https://cdn.openart.ai/stable_diffusion/43d1f34dddfdcdfefa54b8984be0a96159b200a8_2000x2000.webp" },
                    { "CI009", "CH009", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6430), null, null, "https://tse1.mm.bing.net/th/id/OIP.dX8f8uziv7-sVE-MGmiKMwHaHa?rs=1&pid=ImgDetMain" },
                    { "CI010", "CH010", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6432), null, null, "https://tse3.mm.bing.net/th/id/OIP.GLTrvuL5642aAYTOFxC0eAHaJQ?rs=1&pid=ImgDetMain" },
                    { "CI011", "CH011", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6435), null, null, "https://th.bing.com/th/id/R.1a1aeceee8146ba95dd2a8f69c3f182f?rik=T9YeKcs%2b27tcsg&pid=ImgRaw&r=0" },
                    { "CI012", "CH012", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6437), null, null, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/7b60d23e-2e8e-44da-a221-dc39a83c4f3f/der5hqx-ee11482f-b214-4b25-bfee-88dc11a8c4fe.jpg/v1/fill/w_1280,h_1814,q_75,strp/sephiroth__full_body__by_akonyah_der5hqx-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzdiNjBkMjNlLTJlOGUtNDRkYS1hMjIxLWRjMzlhODNjNGYzZlwvZGVyNWhxeC1lZTExNDgyZi1iMjE0LTRiMjUtYmZlZS04OGRjMTFhOGM0ZmUuanBnIiwiaGVpZ2h0IjoiPD0xODE0Iiwid2lkdGgiOiI8PTEyODAifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6aW1hZ2Uud2F0ZXJtYXJrIl0sIndtayI6eyJwYXRoIjoiXC93bVwvN2I2MGQyM2UtMmU4ZS00NGRhLWEyMjEtZGMzOWE4M2M0ZjNmXC9ha29ueWFoLTQucG5nIiwib3BhY2l0eSI6OTUsInByb3BvcnRpb25zIjowLjQ1LCJncmF2aXR5IjoiY2VudGVyIn19.e9IstlpQcF1QRaMoUKkr41MQ7pekjWh_iOje74x3coY" },
                    { "CI013", "CH013", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6438), null, null, "https://tse1.mm.bing.net/th/id/OIP.uCp4Whd_B4z4Zw8C7wvjxwHaLH?rs=1&pid=ImgDetMain" },
                    { "CI014", "CH014", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6440), null, null, "https://tse3.mm.bing.net/th/id/OIP.3ADDr3lt8PYxM6KP10OtwwAAAA?rs=1&pid=ImgDetMain" },
                    { "CI015", "CH015", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6442), null, null, "https://thatparkplace.com/wp-content/uploads/2023/04/kirby-e1681312791814.jpg" }
                });

            migrationBuilder.InsertData(
                table: "EventCharacter",
                columns: new[] { "EventCharacterId", "CharacterId", "CreateDate", "Description", "EventId", "IsAssign", "UpdateDate" },
                values: new object[,]
                {
                    { "EC001", "CH001", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5925), null, "E001", true, null },
                    { "EC002", "CH002", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5930), null, "E002", true, null },
                    { "EC003", "CH003", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5932), null, "E003", true, null },
                    { "EC004", "CH004", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5935), null, "E004", true, null },
                    { "EC005", "CH005", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5938), null, "E005", true, null },
                    { "EC006", "CH006", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5940), null, "E006", true, null },
                    { "EC007", "CH007", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5942), null, "E007", true, null },
                    { "EC008", "CH008", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5944), null, "E008", true, null },
                    { "EC009", "CH009", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5946), null, "E009", true, null },
                    { "EC010", "CH010", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5948), null, "E010", true, null },
                    { "EC011", "CH011", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5950), null, "E011", true, null },
                    { "EC012", "CH012", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5954), null, "E012", true, null }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "AccountId", "CreatedAt", "IsRead", "IsSentMail", "Message" },
                values: new object[,]
                {
                    { "N001", "A001", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5335), false, true, "Welcome to the system!" },
                    { "N002", "A002", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5338), false, true, "Your account has been upgraded." },
                    { "N003", "A003", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5340), true, true, "New promotional offer available!" },
                    { "N004", "A004", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5342), false, true, "Your request has been approved." },
                    { "N005", "A005", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5344), true, true, "System maintenance scheduled." },
                    { "N006", "A006", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5346), false, true, "Your order has been shipped!" },
                    { "N007", "A007", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5348), false, true, "New event registration open." },
                    { "N008", "A008", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5352), true, true, "Reminder: Payment due soon." },
                    { "N009", "A009", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5354), false, true, "Your password was changed." },
                    { "N010", "A010", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5356), false, true, "Admin announcement update." },
                    { "N011", "A011", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5358), true, true, "New message from support." },
                    { "N012", "A012", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5360), false, true, "Upcoming event invitation." },
                    { "N013", "A013", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5362), false, true, "New cosplayer contest." },
                    { "N014", "A014", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5364), true, true, "Loyalty points updated." },
                    { "N015", "A015", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(5366), false, true, "Your subscription expired." }
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
                    { "R001", null, "A001", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5431), null, "RentCostumes", new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Naruto Costume", "PKG001", 100000.0, null, null, "S003", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R002", null, "A002", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5446), null, "RentCosplayer", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ĐN", "Rent Cosplayer for Event", null, 500000.0, null, "Cosplayer is busy", "S002", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R003", null, "A003", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5451), null, "CreateEvent", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "BD", "Create Anime Festival", null, 2000000.0, null, null, "S003", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R004", null, "A004", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5455), null, "RentCostumes", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Rent Samurai Armor", null, 150000.0, null, null, "S002", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R005", null, "A005", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5461), null, "RentCosplayer", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "BT", "Hire Professional Cosplayer", "PKG002", 700000.0, null, null, "S002", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R006", null, "A006", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5527), null, "CreateEvent", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Organize Comic Convention", null, 5000000.0, null, null, "S001", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R007", null, "A007", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5530), null, "RentCostumes", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Victorian Costume", null, 120000.0, null, "Cosplayer is busy", "S002", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R008", null, "A008", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5535), null, "RentCosplayer", new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "QN", "Book Cosplayer for Birthday Party", null, 350000.0, null, null, "S003", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R009", null, "A009", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5538), null, "CreateEvent", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CM", "Plan Fantasy Fair", null, 3000000.0, null, null, "S003", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R010", null, "A010", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5543), null, "RentCostumes", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "LĐ", "Rent Halloween Costumes", null, 200000.0, null, null, "S001", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R011", null, "A011", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5547), null, "RentCosplayer", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "NT", "Hire Cosplayer for Wedding", "PKG010", 800000.0, null, null, "S001", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R012", null, "A012", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5551), null, "CreateEvent", new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "VT", "Create Sci-Fi Convention", null, 4500000.0, null, null, "S002", new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R013", null, "A013", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5556), null, "RentCostumes", new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Santa Claus Costume", null, 130000.0, null, null, "S003", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R014", null, "A014", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5559), null, "RentCosplayer", new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Book Cosplayer for Product Launch", null, 600000.0, null, null, "S001", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R015", null, "A015", new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5563), null, "CreateEvent", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Host Christmas Event", "PKG015", 5500000.0, null, null, "S002", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null }
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
                    { "6b4f70bc-776e-4a6d-a7c4-1e24a7e8b4c0", "C003", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6296), 60000.0, "P009", 1 },
                    { "6d2730ba-44bc-48c4-b56a-abf6ecc2f890", "C003", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6289), 15000.0, "P007", 5 },
                    { "737b7ec7-0a30-4689-a5c4-f88163fc8486", "C001", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6274), 80000.0, "P003", 1 },
                    { "8f5c697b-1962-40eb-8e9c-37a731727431", "C002", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6281), 25000.0, "P005", 3 },
                    { "9343e3f6-fb22-4fa0-aec4-fd626b11f694", "C003", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6293), 50000.0, "P008", 2 },
                    { "979ad040-55ff-40ac-b06e-def800e7bc83", "C004", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6305), 45000.0, "P012", 1 },
                    { "b0305f70-6079-48d0-bb00-a8e372103eb9", "C001", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6227), 20000.0, "P002", 1 },
                    { "b26c1b6d-4617-4683-93e4-c2ab4caadc2b", "C004", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6303), 35000.0, "P011", 2 },
                    { "bc194d20-e7ef-4714-8d2d-49ba85803728", "C002", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6285), 40000.0, "P006", 2 },
                    { "d56ea989-9c2b-4aac-b073-808b210d9b6c", "C004", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6300), 120000.0, "P010", 1 },
                    { "e0a38791-1708-4b84-99c8-862eba64953c", "C001", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6221), 30000.0, "P001", 2 },
                    { "e503a2b7-c7fe-4f45-b718-7bdbc7ccc30f", "C002", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6278), 100000.0, "P004", 1 }
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
                    { "044565d8-965f-4e1e-8751-d3ddb9921809", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6643), "O009", 20000.0, "P002", 6 },
                    { "0c7e4605-8533-4118-9d71-51ef7fac3566", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6645), "O009", 80000.0, "P003", 2 },
                    { "12466dff-f8b4-4c69-9718-8cab8ea0517a", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6640), "O008", 30000.0, "P001", 1 },
                    { "15d71dff-8925-479e-9b15-cc18f8a85540", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6708), "O015", 90000.0, "P014", 2 },
                    { "163f40fd-904d-4536-9e4c-4537084a4447", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6608), "O003", 40000.0, "P006", 3 },
                    { "38524500-ec96-4724-b04d-5d56dd165c02", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6621), "O005", 120000.0, "P010", 1 },
                    { "3fbc8108-8d5f-4309-a1b9-fa2392827432", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6610), "O004", 15000.0, "P007", 4 },
                    { "4f12242e-48ae-4d50-a847-1f35d9d3a4bf", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6695), "O013", 120000.0, "P010", 1 },
                    { "5c600d0d-2ef9-4918-a8c9-dc13011743de", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6698), "O013", 35000.0, "P011", 2 },
                    { "5eeece81-d0c8-4f88-be86-730a74602f2d", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6657), "O011", 15000.0, "P007", 4 },
                    { "6321e69f-0e48-4a69-a1c1-b53b88c20252", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6648), "O010", 100000.0, "P004", 1 },
                    { "777563e1-0d64-4dd9-a724-152c4e671e72", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6705), "O014", 18000.0, "P013", 5 },
                    { "78eaae0a-b01b-4580-b19d-27b2287f4159", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6624), "O006", 35000.0, "P011", 2 },
                    { "84218330-cd38-4669-aeac-7efc413fc4a8", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6664), "O012", 60000.0, "P009", 1 },
                    { "93575a5f-690e-4f27-8538-1998efdab4d6", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6595), "O001", 20000.0, "P002", 5 },
                    { "9e460108-715f-4ab9-a2a8-bca1f4607bd0", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6592), "O001", 30000.0, "P001", 3 },
                    { "9f7c4c90-66dd-4a15-8968-ef1e8ee41a40", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6654), "O011", 40000.0, "P006", 2 },
                    { "a1fffc77-34bb-417a-b9b8-9d2b335b7435", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6605), "O003", 25000.0, "P005", 2 },
                    { "a669a321-c8c3-404e-93fa-9cc7c44972f2", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6652), "O010", 25000.0, "P005", 3 },
                    { "a947a33e-96f0-475a-bbdc-18a153e48d9f", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6603), "O002", 100000.0, "P004", 1 },
                    { "b9db0ddd-711d-485a-a8c6-3685a27a1365", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6618), "O005", 60000.0, "P009", 1 },
                    { "bb95550b-0ad1-44f4-830f-10296d2e91be", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6660), "O012", 50000.0, "P008", 2 },
                    { "ce223e5c-86f3-4cb9-9eb8-4bdd3b0b7144", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6636), "O008", 22000.0, "P015", 4 },
                    { "d0458710-f602-42fe-80f2-b878baceb803", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6598), "O002", 80000.0, "P003", 1 },
                    { "d969dd99-ceb9-4d2d-8a4d-147010b8c43f", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6631), "O007", 18000.0, "P013", 5 },
                    { "e51fd5be-ec33-4c7b-8388-724cad48c868", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6614), "O004", 50000.0, "P008", 2 },
                    { "ee1f6468-1228-4ead-9efe-d76a6058c8a1", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6634), "O007", 90000.0, "P014", 2 },
                    { "f5936b83-ea00-4e84-9632-1e88d1b2e0b9", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6711), "O015", 22000.0, "P015", 4 },
                    { "faef634d-4634-403f-82ea-3f4b7663cce6", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6701), "O014", 45000.0, "P012", 3 },
                    { "fd67ab57-37ed-4910-88c0-1e51062eeb71", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6628), "O006", 45000.0, "P012", 3 }
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
                    { "RC01", "CH001", "A025", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6908), "Yêu cầu cosplay nhân vật CH001", 1, null, "R001", null, 50000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6909) },
                    { "RC02", "CH002", "A026", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6916), "Yêu cầu cosplay nhân vật CH002", 1, null, "R002", null, 60000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6916) },
                    { "RC03", "CH003", "A027", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6919), "Yêu cầu cosplay nhân vật CH003", 1, null, "R003", null, 70000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6919) },
                    { "RC04", "CH004", "A028", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6922), "Yêu cầu cosplay nhân vật CH004", 1, null, "R004", null, 80000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6922) },
                    { "RC05", "CH005", "A029", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6925), "Yêu cầu cosplay nhân vật CH005", 1, null, "R005", null, 90000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6925) },
                    { "RC06", "CH006", null, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6930), "Yêu cầu cosplay nhân vật CH006", 5, null, "R006", null, 100000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6930) },
                    { "RC07", "CH007", "A031", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6933), "Yêu cầu cosplay nhân vật CH007", 1, null, "R007", null, 110000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6933) },
                    { "RC08", "CH008", null, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6935), "Yêu cầu cosplay nhân vật CH008", 7, null, "R008", null, 120000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6936) },
                    { "RC09", "CH009", "A033", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6938), "Yêu cầu cosplay nhân vật CH009", 1, null, "R009", null, 130000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6939) },
                    { "RC10", "CH010", null, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6941), "Yêu cầu cosplay nhân vật CH010", 9, null, "R010", null, 140000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6942) },
                    { "RC11", "CH011", "A035", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6944), "Yêu cầu cosplay nhân vật CH011", 1, null, "R011", null, 150000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6945) },
                    { "RC12", "CH012", "A036", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6947), "Yêu cầu cosplay nhân vật CH012", 1, null, "R012", null, 160000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6947) },
                    { "RC13", "CH013", null, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6950), "Yêu cầu cosplay nhân vật CH013", 10, null, "R013", null, 170000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6950) },
                    { "RC14", "CH014", "A038", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6954), "Yêu cầu cosplay nhân vật CH014", 1, null, "R014", null, 180000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6955) },
                    { "RC15", "CH015", "A039", new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6957), "Yêu cầu cosplay nhân vật CH015", 1, null, "R015", null, 190000.0, new DateTime(2025, 5, 18, 17, 6, 8, 815, DateTimeKind.Utc).AddTicks(6958) }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "AccountId", "ContractCharacterId", "CreateDate", "Description", "EndDate", "EventCharacterId", "IsActive", "Location", "StartDate", "Status", "TaskName", "Type", "UpdateDate" },
                values: new object[,]
                {
                    { "T001", "A001", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5616), "Cosplay as anime characters", new DateTime(2025, 5, 22, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5615), "EC001", true, "Tokyo", new DateTime(2025, 5, 21, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5608), 0, "CH001", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5617) },
                    { "T002", "A004", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5622), "Join cosplay contest", new DateTime(2025, 5, 24, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5621), "EC002", true, "Los Angeles", new DateTime(2025, 5, 23, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5621), 1, "CH002", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5623) },
                    { "T003", "A005", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5628), "Teach costume making", new DateTime(2025, 5, 26, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5627), "EC003", true, "New York", new DateTime(2025, 5, 25, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5627), 2, "CH003", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5628) },
                    { "T004", "A007", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5632), "Host a live event", new DateTime(2025, 5, 20, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5631), "EC004", true, "Online", new DateTime(2025, 5, 20, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5631), 3, "CH004", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5633) },
                    { "T005", "A008", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5637), "Professional cosplay photoshoot", new DateTime(2025, 5, 28, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5636), "EC005", true, "Paris", new DateTime(2025, 5, 27, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5635), 0, "CH005", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5637) },
                    { "T006", "A010", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5644), "Evaluate contestants", new DateTime(2025, 5, 30, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5643), "EC006", true, "Berlin", new DateTime(2025, 5, 29, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5643), 1, "CH006", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5644) },
                    { "T007", "A012", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5649), "Walk in parade", new DateTime(2025, 6, 1, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5649), "EC007", true, "Seoul", new DateTime(2025, 5, 31, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5647), 2, "CH007", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5650) },
                    { "T008", "A013", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5654), "Perform on live TV", new DateTime(2025, 6, 3, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5653), "EC008", true, "London", new DateTime(2025, 6, 2, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5652), 3, "CH008", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5654) },
                    { "T009", "A015", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5658), "Perform for charity", new DateTime(2025, 6, 5, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5657), "EC009", true, "Sydney", new DateTime(2025, 6, 4, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5657), 4, "CH008", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5659) },
                    { "T010", "A005", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5662), "Talk about cosplay industry", new DateTime(2025, 6, 7, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5662), "EC010", true, "San Diego", new DateTime(2025, 6, 6, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5661), 0, "CH009", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5663) },
                    { "T011", "A008", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5668), "New character shoot", new DateTime(2025, 6, 9, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5668), "EC011", true, "Bangkok", new DateTime(2025, 6, 8, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5666), 1, "CH010", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5669) },
                    { "T012", "A007", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5672), "Host main event", new DateTime(2025, 6, 11, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5672), "EC012", true, "Jakarta", new DateTime(2025, 6, 10, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5671), 2, "CH011", null, new DateTime(2025, 5, 19, 0, 6, 8, 815, DateTimeKind.Local).AddTicks(5673) }
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
                    { "0f57e9e8-b3e8-4a0b-ae62-59dacf19468e", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", 5, null },
                    { "1e9b82c0-8038-485d-a11a-c55e1b86d208", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", 5, null },
                    { "20ef8d0a-ffa6-482a-9df5-51ce84b230e4", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", 5, null },
                    { "2a075ed5-cd8e-4602-a08c-0dadb5122738", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", 5, null },
                    { "3a397474-91c9-4698-a0d2-2a346c09af01", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", 5, null },
                    { "4beafff8-3f01-447b-bc37-66951093f712", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", 5, null },
                    { "86de1d84-9b63-4045-b05c-b424067f1d9e", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", 5, null },
                    { "898c54de-4c9a-4b43-b679-cb0ee4793342", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", 5, null },
                    { "b12a1967-30ee-4e9c-a93e-7c45ba7fc5f8", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", 5, null }
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
