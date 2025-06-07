using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CCSS_Repository.Migrations
{
    /// <inheritdoc />
    public partial class test_1 : Migration
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
                name: "location",
                columns: table => new
                {
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacityMin = table.Column<int>(type: "int", nullable: false),
                    CapacityMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.LocationId);
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
                    Status = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "location",
                        principalColumn: "LocationId");
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipStatus = table.Column<int>(type: "int", nullable: true),
                    ShipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    to_ward_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    to_district_id = table.Column<int>(type: "int", nullable: true),
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
                    IsValidate = table.Column<bool>(type: "bit", nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PackageId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
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
                    IsValidate = table.Column<bool>(type: "bit", nullable: false),
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
                    { "ACT001", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8957), "A relaxing yoga session", "Yoga Class", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8958) },
                    { "ACT002", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8961), "Learn to cook delicious meals", "Cooking Workshop", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8962) },
                    { "ACT003", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8964), "Live music performance", "Music Concert", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8965) },
                    { "ACT004", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8967), "Showcase of local artists", "Art Exhibition", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8968) },
                    { "ACT005", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8970), "Discussion on latest technology trends", "Tech Talk", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8971) },
                    { "ACT006", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8974), "5K run for a good cause", "Charity Run", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8974) },
                    { "ACT007", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8977), "Monthly book discussion", "Book Club", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8977) },
                    { "ACT008", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8980), "Learn photography skills", "Photography Workshop", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8981) },
                    { "ACT009", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8985), "Dance battle for all ages", "Dance Competition", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8986) },
                    { "ACT010", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8989), "Competitive chess matches", "Chess Tournament", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8989) },
                    { "ACT011", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8992), "Outdoor movie screening", "Movie Night", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8992) },
                    { "ACT012", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8995), "Showcase of scientific projects", "Science Fair", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8995) },
                    { "ACT013", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8998), "Intensive coding workshop", "Coding Bootcamp", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8998) },
                    { "ACT014", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9001), "Learn gardening techniques", "Gardening Workshop", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9002) },
                    { "ACT015", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9004), "Guided meditation practice", "Meditation Session", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9005) }
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
                table: "Package",
                columns: new[] { "PackageId", "Description", "PackageName", "Price" },
                values: new object[,]
                {
                    { "PKG001", "A great starter package for those looking to rent a single character. Includes a quality costume, basic props, and a 2-hour appearance—perfect for birthdays, intimate gatherings, or themed surprises.", "Basic Character Rental", 100000.0 },
                    { "PKG002", "Enjoy up to 3 professionally dressed characters with premium costumes, interactive props, and professional makeup. Ideal for corporate functions, community festivals, and mid-sized celebrations.", "Deluxe Character Rental", 250000.0 },
                    { "PKG003", "An all-inclusive full-day rental featuring unlimited character changes, deluxe costumes, a full prop set, professional photography, and a dedicated event coordinator. Best suited for conventions and large-scale events.", "Ultimate Character Rental", 500000.0 },
                    { "PKG004", "A 30-minute interactive performance with character-based skits, simple choreography, themed props, and basic audio coordination. Great for smaller events or stage programs.", "Standard Cosplay Performance", 150000.0 },
                    { "PKG005", "A dynamic 60-minute show featuring advanced choreography, custom soundtracks, special effects, and audience engagement. Includes costume changes and immersive storytelling.", "Premium Cosplay Performance", 300000.0 },
                    { "PKG006", "An exclusive 90-minute theatrical show with cinematic lighting, live music, meet-and-greet opportunities, personalized character moments, and high-end production. Tailored for VIP audiences or gala events.", "VIP Cosplay Performance", 500000.0 },
                    { "PKG007", "A fast and fun 30-minute shoot perfect for social media. Includes basic lighting, up to 3 outfit changes, and 15 edited high-resolution photos delivered within 48 hours.", "Mini Photography Session", 80000.0 },
                    { "PKG008", "A full 1-hour session with professional lighting, unlimited costume changes, multiple backdrop options, and 50 edited images with creative enhancements and color grading.", "Standard Photography Session", 150000.0 },
                    { "PKG009", "An immersive 3-hour shoot across multiple locations with pro lighting, makeup artist support, unlimited outfits, over 100 edited photos, and exclusive behind-the-scenes footage.", "Full Photography Package", 300000.0 },
                    { "PKG010", "A fun starter bundle including character keychains, stickers, trading cards, mini-figures, and limited-edition pins. Perfect for beginner collectors or fans.", "Basic Merchandise Pack", 50000.0 },
                    { "PKG011", "A premium collection of figures, exclusive artwork prints, custom accessories, special edition posters, and signed memorabilia from popular cosplayers.", "Deluxe Merchandise Pack", 150000.0 },
                    { "PKG012", "A rare collector’s edition set featuring limited-production statues, handmade accessories, signed artworks, exclusive packaging, and one-of-a-kind items unavailable elsewhere.", "Ultimate Merchandise Pack", 300000.0 },
                    { "PKG013", "A 4-hour beginner workshop introducing costume creation, makeup basics, character posing, and simple prop making. Includes a starter kit with essential tools and materials.", "Cosplay Basics Workshop", 100000.0 },
                    { "PKG014", "A 2-day intensive masterclass covering advanced sewing, pro makeup, wig styling, armor building, cosplay photography, and performance coaching with expert instructors.", "Advanced Cosplay Training", 2500000.0 },
                    { "PKG015", "A 5-day professional training program for serious cosplayers. Covers craftsmanship, branding, competition readiness, portfolio building, and mentorship from award-winning artists.", "Master Cosplay Workshop", 500000.0 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreateDate", "Description", "IsActive", "Price", "ProductName", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { "P001", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6539), "A wig for Naruto cosplay", true, 30000.0, "Naruto Wig", 10, null },
                    { "P002", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6546), "A hat for Mario cosplay", true, 20000.0, "Mario Hat", 15, null },
                    { "P003", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6550), "Complete costume for Sasuke cosplay", true, 80000.0, "Sasuke Costume", 5, null },
                    { "P004", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6554), "Replica sword from The Legend of Zelda", true, 100000.0, "Zelda Sword", 7, null },
                    { "P005", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6557), "Iconic straw hat from One Piece", true, 25000.0, "One Piece Straw Hat", 20, null },
                    { "P006", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6561), "Hatsune Miku blue twin-tail wig", true, 40000.0, "Miku Wig", 12, null },
                    { "P007", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6565), "Tanjiro's iconic hanafuda earrings", true, 15000.0, "Demon Slayer Earrings", 30, null },
                    { "P008", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6569), "Survey Corps uniform jacket", true, 50000.0, "Attack on Titan Jacket", 10, null },
                    { "P009", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6572), "Cozy Pikachu-themed onesie", true, 60000.0, "Pikachu Onesie", 8, null },
                    { "P010", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6619), "Final Fantasy VII replica sword", true, 120000.0, "Cloud's Buster Sword", 4, null },
                    { "P011", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6623), "LED Vision accessory from Genshin Impact", true, 35000.0, "Genshin Impact Vision", 25, null },
                    { "P012", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6627), "Jinx cosplay wig from Arcane", true, 45000.0, "Jinx Wig", 6, null },
                    { "P013", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6631), "Golden tiara from Sailor Moon", true, 18000.0, "Sailor Moon Tiara", 15, null },
                    { "P014", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6635), "High-quality Spider-Man suit", true, 90000.0, "Spider-Man Suit", 3, null },
                    { "P015", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6638), "Replica wand from Harry Potter series", true, 22000.0, "Harry Potter Wand", 50, null }
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
                    { "S001", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6489), "Rent characters for events and parties", "Character Rental", null },
                    { "S002", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6492), "Live cosplay performances at events", "Cosplay Rental", null },
                    { "S003", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6493), "Professional photoshoot with cosplayers", "Create event", null }
                });

            migrationBuilder.InsertData(
                table: "location",
                columns: new[] { "LocationId", "Address", "CapacityMax", "CapacityMin" },
                values: new object[,]
                {
                    { "L001", "76 Lê Lai, P. Bến Thành, Quận 1", 2000, 0 },
                    { "L002", "Góc Hai Bà Trưng & Lê Duẩn, Quận 1", 600, 0 },
                    { "L003", "6 Thái Văn Lung, P. Bến Nghé, Quận 1", 500, 0 },
                    { "L004", "102 Lê Thị Hồng Gấm, Quận 1", 300, 0 },
                    { "L005", "33 Cao Thắng, P. 2, Quận 3", 250, 0 },
                    { "L006", "39 Trần Quốc Thảo, P. 6, Quận 3", 160, 0 },
                    { "L007", "24 Đường 3/2, Quận 10", 500, 0 },
                    { "L008", "280 Tô Hiến Thành, P. 15, Quận 10", 250, 0 },
                    { "L009", "03 Nguyễn Cơ Thạch, Khu đô thị Sala, P. An Lợi Đông, Quận 2", 30, 0 },
                    { "L010", "Neo đậu tại Cảng Sài Gòn, Quận 4", 900, 0 }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AverageStar", "Birthday", "Code", "Description", "Email", "GoogleId", "Height", "IsActive", "IsLock", "Leader", "Name", "OnTask", "Password", "Phone", "RoleId", "SalaryIndex", "TaskQuantity", "UserName", "Weight" },
                values: new object[,]
                {
                    { "A001", 4.5, null, null, null, "tuananh123tuankiet@gmail.com", null, 180f, true, false, null, "TuanAnh", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 45000.0, null, null, 75f },
                    { "A002", null, null, null, null, "admin@gmail.com", null, null, true, false, null, "Admin", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R001", null, null, null, null },
                    { "A003", null, null, null, null, "phuongnam26012002@gmail.com", null, null, true, false, null, "Nam", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A004", 4.2000000000000002, null, null, null, "bob@gmail.com", null, 175f, true, false, null, "Bob Brown", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 42000.0, null, null, 80f },
                    { "A005", 3.5, null, null, null, "charlie@gmail.com", null, 182f, true, false, null, "Charlie White", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 35000.0, null, null, 78f },
                    { "A006", null, null, null, null, "david@gmail.com", null, null, true, false, null, "David Black", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A007", 4.0999999999999996, null, null, null, "emma@gmail.com", null, 168f, true, false, null, "Emma Green", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 41000.0, null, null, 60f },
                    { "A008", 4.5999999999999996, null, null, null, "frank@gmail.com", null, 185f, true, false, null, "Frank Blue", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 46000.0, null, null, 85f },
                    { "A009", null, null, null, null, "grace@gmail.com", null, null, true, false, null, "Grace Pink", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R001", null, null, null, null },
                    { "A010", 2.5, null, null, null, "henry@gmail.com", null, 178f, true, false, null, "Henry Purple", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 25000.0, null, null, 77f },
                    { "A011", 2.5, null, null, null, "isla@gmail.com", null, 178f, true, false, null, "Isla Red", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 25000.0, null, null, 77f },
                    { "A012", 3.7999999999999998, null, null, null, "jack@gmail.com", null, 172f, true, false, null, "Jack Yellow", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 38000.0, null, null, 70f },
                    { "A013", 2.5, null, null, null, "katie@gmail.com", null, 165f, true, false, null, "Katie Orange", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 25000.0, null, null, 55f },
                    { "A014", null, null, null, null, "liam@gmail.com", null, null, true, false, null, "Liam Gray", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A015", 1.5, null, null, null, "miac@gmail.com", null, 170f, true, false, null, "Mia Cyan", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 15000.0, null, null, 65f },
                    { "A016", 3.7000000000000002, null, null, null, "noah@gmail.com", null, 175f, true, false, null, "Noah Silver", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 37000.0, null, null, 70f },
                    { "A017", 4.7999999999999998, null, null, null, "olivia@gmail.com", null, 168f, true, null, null, "Olivia Gold", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 48000.0, null, null, 55f },
                    { "A018", 3.2000000000000002, null, null, null, "william@gmail.com", null, 180f, true, false, null, "William Amber", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 32000.0, null, null, 75f },
                    { "A019", 3.2999999999999998, null, null, null, "sophia@gmail.com", null, 165f, true, false, null, "Sophia Ivory", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 33000.0, null, null, 50f },
                    { "A020", 3.3999999999999999, null, null, null, "james@gmail.com", null, 178f, true, false, null, "James Navy", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 34000.0, null, null, 72f },
                    { "A021", 3.5, null, null, null, "ava@gmail.com", null, 162f, true, false, null, "Ava Teal", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 35000.0, null, null, 48f },
                    { "A022", 3.6000000000000001, null, null, null, "benjamin@gmail.com", null, 177f, true, false, null, "Benjamin Lime", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 36000.0, null, null, 70f },
                    { "A023", 3.7000000000000002, null, null, null, "charlotte@gmail.com", null, 164f, true, false, null, "Charlotte Beige", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 37000.0, null, null, 52f },
                    { "A024", 3.7999999999999998, null, null, null, "lucas@gmail.com", null, 180f, true, false, null, "Lucas Maroon", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 38000.0, null, null, 74f },
                    { "A025", 3.8999999999999999, null, null, null, "mia@gmail.com", null, 159f, true, false, null, "Mia Pearl", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 39000.0, null, null, 47f },
                    { "A026", 2.5, null, null, null, "ethan@gmail.com", null, 176f, true, false, null, "Ethan Olive", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 25000.0, null, null, 71f },
                    { "A027", 2.6000000000000001, null, null, null, "amelia@gmail.com", null, 167f, true, false, null, "Amelia Ruby", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 26000.0, null, null, 53f },
                    { "A028", 2.7000000000000002, null, null, null, "henrys@gmail.com", null, 182f, true, false, null, "Henry Saffron", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 27000.0, null, null, 76f },
                    { "A029", 2.7999999999999998, null, null, null, "ella@gmail.com", null, 160f, true, false, null, "Ella Coral", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 28000.0, null, null, 49f },
                    { "A030", 2.8999999999999999, null, null, null, "daniel@gmail.com", null, 175f, true, false, null, "Daniel Cyan", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 29000.0, null, null, 72f },
                    { "A031", 3.0, null, null, null, "logan@gmail.com", null, 180f, true, false, null, "Logan Indigo", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 30000.0, null, null, 73f },
                    { "A032", 4.0, null, null, null, "lily@gmail.com", null, 165f, true, false, null, "Lily Violet", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 40000.0, null, null, 52f },
                    { "A033", 4.0999999999999996, null, null, null, "mason@gmail.com", null, 178f, true, false, null, "Mason Turquoise", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 41000.0, null, null, 74f },
                    { "A034", 4.2000000000000002, null, null, null, "zoe@gmail.com", null, 160f, true, false, null, "Zoe Lavender", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 42000.0, null, null, 48f },
                    { "A035", 4.2999999999999998, null, null, null, "elijah@gmail.com", null, 182f, true, false, null, "Elijah Crimson", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 43000.0, null, null, 77f },
                    { "A036", 4.4000000000000004, null, null, null, "aria@gmail.com", null, 164f, true, false, null, "Aria Mint", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 44000.0, null, null, 50f },
                    { "A037", 4.5, null, null, null, "sebastian@gmail.com", null, 179f, true, false, null, "Sebastian Bronze", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 45000.0, null, null, 72f },
                    { "A038", 4.5999999999999996, null, null, null, "harper@gmail.com", null, 168f, true, false, null, "Harper Rose", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 46000.0, null, null, 53f },
                    { "A039", 4.7000000000000002, null, null, null, "caleb@gmail.com", null, 181f, true, false, null, "Caleb Onyx", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 47000.0, null, null, 75f },
                    { "A040", 4.7999999999999998, null, null, null, "scarlett@gmail.com", null, 162f, true, false, null, "Scarlett Magenta", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 48000.0, null, null, 51f },
                    { "A041", null, null, null, null, "manager@gmail.com", null, null, true, false, null, "Manager", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R002", null, null, null, null },
                    { "A042", null, null, null, null, "consultant@gmail.com", null, null, true, false, null, "Consultant", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R003", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "CategoryId", "CharacterName", "CreateDate", "Description", "IsActive", "MaxHeight", "MaxWeight", "MinHeight", "MinWeight", "Price", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { "CH001", "C3", "Naruto", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6320), "The energetic and determined ninja from Hidden Leaf Village who dreams of becoming Hokage. Known for his signature jutsu, Nine-Tails chakra, and never-give-up attitude.", true, 180f, 80f, 160f, 50f, 100000.0, 15, null },
                    { "CH002", "C3", "Sasuke", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6326), "The last surviving member of the Uchiha clan and Naruto's eternal rival. A skilled ninja wielding the Sharingan and seeking to restore his clan's honor.", true, 185f, 85f, 165f, 55f, 120000.0, 11, null },
                    { "CH003", "C3", "Goku", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6332), "The pure-hearted Saiyan warrior from Planet Vegeta who protects Earth. Master of martial arts with incredible transformations including Super Saiyan forms.", true, 190f, 90f, 170f, 60f, 150000.0, 13, null },
                    { "CH004", "C4", "Luffy", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6337), "The rubber-powered captain of the Straw Hat Pirates on a quest to become the Pirate King. Possesses the Gum-Gum Devil Fruit powers and boundless optimism.", true, 175f, 70f, 155f, 45f, 110000.0, 14, null },
                    { "CH005", "C4", "Ichigo", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6341), "The orange-haired Soul Reaper with the power to see spirits. Wields the massive Zangetsu sword and protects both the living and spirit worlds.", true, 185f, 85f, 165f, 55f, 130000.0, 13, null },
                    { "CH006", "C14", "Mario", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6386), "The heroic Italian plumber who saves Princess Peach from Bowser. Famous for jumping on enemies, collecting coins, and navigating through pipes in the Mushroom Kingdom.", true, 180f, 80f, 160f, 60f, 80000.0, 15, null },
                    { "CH007", "C14", "Luigi", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6392), "Mario's younger twin brother, the green-clad plumber known for his higher jumps and slightly nervous personality. Often the hero of Luigi's Mansion adventures.", true, 170f, 75f, 150f, 55f, 85000.0, 13, null },
                    { "CH008", "C14", "Link", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6397), "The legendary Hero of Hyrule who wields the Master Sword. Silent protagonist on epic quests to save Princess Zelda and defeat the evil Ganon across multiple timelines.", true, 180f, 80f, 160f, 50f, 140000.0, 15, null },
                    { "CH009", "C16", "Zelda", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6404), "The wise and powerful Princess of Hyrule who possesses the Triforce of Wisdom. Often aids Link in his quests while protecting her kingdom from dark forces.", true, 175f, 70f, 155f, 50f, 135000.0, 9, null },
                    { "CH010", "C16", "Samus", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6409), "The intergalactic bounty hunter in her iconic Power Suit. Expert in combat and exploration, known for battling Space Pirates and the dangerous Metroids.", true, 185f, 85f, 165f, 55f, 145000.0, 14, null },
                    { "CH011", "C13", "Cloud", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6413), "The spiky-haired ex-SOLDIER mercenary wielding the massive Buster Sword. Former member of AVALANCHE fighting against the Shinra Corporation to save the planet.", true, 185f, 85f, 165f, 55f, 125000.0, 16, null },
                    { "CH012", "C13", "Sephiroth", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6419), "The legendary SOLDIER First Class known as the One-Winged Angel. Cloud's nemesis with silver hair, wielding the long Masamune katana and possessing god-like powers.", true, 190f, 90f, 170f, 60f, 155000.0, 15, null },
                    { "CH013", "C8", "Kratos", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6423), "The Ghost of Sparta, former God of War seeking redemption. A fierce warrior with the Blades of Chaos, now living in Norse mythology with his son Atreus.", true, 195f, 100f, 175f, 70f, 160000.0, 18, null },
                    { "CH014", "C8", "Pikachu", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6428), "The beloved Electric-type Pokémon and franchise mascot. Known for storing electricity in its cheek pouches and being Ash Ketchum's loyal partner.", true, 180f, 80f, 160f, 60f, 90000.0, 11, null },
                    { "CH015", "C8", "Kirby", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6433), "The pink puffball hero of Dream Land with the ability to inhale enemies and copy their powers. Known for his cheerful personality and incredible appetite.", true, 180f, 80f, 160f, 60f, 95000.0, 14, null }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "CreateBy", "CreateDate", "Description", "EndDate", "EventName", "IsActive", "Location", "LocationId", "StartDate", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { "E001", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6703), "A grand celebration to welcome the new year", new DateTime(2025, 1, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), "New Year Festival", true, "Times Square, New York", "L001", new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "E002", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6711), "Experience the beauty of cherry blossoms", new DateTime(2025, 2, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), "Spring Blossom Fest", true, "Kyoto, Japan", "L002", new DateTime(2025, 2, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "E003", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6718), "Showcasing the latest in technology and AI", new DateTime(2025, 3, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), "Tech Innovation Summit", true, "Silicon Valley", "L003", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), 3, null },
                    { "E004", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6723), "Live performances from top artists", new DateTime(2025, 4, 17, 17, 0, 0, 0, DateTimeKind.Unspecified), "Music Fest", true, "Coachella, California", "L004", new DateTime(2025, 4, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "E005", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6727), "A must-attend event for comic book fans", new DateTime(2025, 5, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), "Comic-Con International", true, "San Diego Convention Center", "L005", new DateTime(2025, 5, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), 3, null },
                    { "E006", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6732), "Largest anime convention in the world", new DateTime(2025, 6, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), "Anime Expo", true, "Los Angeles Convention Center", "L006", new DateTime(2025, 6, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "E007", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6737), "Latest trends and releases in gaming", new DateTime(2025, 7, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Expo", true, "Las Vegas Convention Center", "L007", new DateTime(2025, 7, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "E008", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6741), "A fun-filled summer celebration", new DateTime(2025, 8, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), "Summer Festival", true, "Miami Beach, Florida", "L008", new DateTime(2025, 8, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "E009", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6745), "A paradise for cosplayers", new DateTime(2025, 9, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), "Cosplay Festival", true, "Tokyo Big Sight", "L009", new DateTime(2025, 9, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "E010", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6750), "Showcasing the best movies of the year", new DateTime(2025, 10, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), "Film Festival", true, "Cannes, France", "L010", new DateTime(2025, 10, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "E011", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6756), "Spooky celebrations and costume parties", new DateTime(2025, 11, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), "Halloween Night", true, "Salem, Massachusetts", "L010", new DateTime(2025, 11, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "E012", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(6761), "Festive shopping and holiday cheer", new DateTime(2025, 12, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Market", true, "Nuremberg, Germany", "L007", new DateTime(2025, 12, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), 0, null }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "ProductImageId", "CreateDate", "IsAvatar", "ProductId", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "IMG001", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9906), true, "P001", null, "https://i.pinimg.com/736x/5b/d5/22/5bd522817214385b4673af094a9ddb25.jpg" },
                    { "IMG0010", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9934), false, "P003", null, "https://i.pinimg.com/736x/d4/ce/c3/d4cec31b0cadfc10a6a10fa560260b65.jpg" },
                    { "IMG002", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9910), false, "P001", null, "https://i.pinimg.com/736x/6e/22/65/6e22657c7a91292b46fb727671e2e3f2.jpg" },
                    { "IMG003", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9913), false, "P001", null, "https://i.pinimg.com/736x/7d/c0/97/7dc09783c0757b5761a327e0f1908b8a.jpg" },
                    { "IMG004", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9915), false, "P001", null, "https://i.pinimg.com/736x/c3/9b/87/c39b87b5994c805893e36939ea71f4d8.jpg" },
                    { "IMG005", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9918), true, "P002", null, "https://i.pinimg.com/736x/c2/83/bd/c283bd289da144479eba982d37a21023.jpg" },
                    { "IMG006", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9921), false, "P002", null, "https://i.pinimg.com/736x/da/6e/9c/da6e9c955676f70ee5ea549866f68b8e.jpg" },
                    { "IMG007", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9923), false, "P002", null, "https://i.pinimg.com/736x/17/33/0a/17330a9c865ea4116ea4f4531bbaaaa3.jpg" },
                    { "IMG008", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9928), false, "P002", null, "https://i.pinimg.com/736x/87/5f/2c/875f2c6e0ddc5fa194c072be3f0a620f.jpg" },
                    { "IMG009", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9931), true, "P003", null, "https://i.pinimg.com/736x/6d/e7/eb/6de7eb00ca29991cc8c01f24ef66ee01.jpg" },
                    { "IMG011", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9937), false, "P003", null, "https://i.pinimg.com/736x/78/97/12/78971296728a3b39b8de627a6993e110.jpg" },
                    { "IMG012", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9939), false, "P003", null, "https://i.pinimg.com/736x/c7/77/37/c77737d95e245f66d50cd681705d6d94.jpg" },
                    { "IMG013", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9942), true, "P004", null, "https://i.pinimg.com/736x/6d/ff/62/6dff62b556d097a31cacb345051b6a51.jpg" },
                    { "IMG014", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9944), false, "P004", null, "https://i.pinimg.com/736x/cf/1c/63/cf1c63218c1c3b6b0c3133c9d18eeb65.jpg" },
                    { "IMG015", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9947), false, "P004", null, "https://i.pinimg.com/736x/fd/62/37/fd62370a4e5c8487aa7375a94b1a1cd4.jpg" },
                    { "IMG016", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9952), false, "P004", null, "https://i.pinimg.com/736x/d9/f4/65/d9f4652af418f7f08e9c0dd20cd48e38.jpg" },
                    { "IMG017", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9954), true, "P005", null, "https://i.pinimg.com/736x/0f/a9/75/0fa9756da968f296b0652351c88359bb.jpg" },
                    { "IMG018", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9957), false, "P005", null, "https://i.pinimg.com/736x/a1/89/af/a189af181a4b9368d3a07281077446e5.jpg" },
                    { "IMG019", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(20), false, "P005", null, "https://i.pinimg.com/736x/59/98/2d/59982d1537b336ab322e6d4e0177cf97.jpg" },
                    { "IMG020", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(23), false, "P005", null, "https://i.pinimg.com/736x/2c/65/70/2c65702a200aec274b0ada18203b2711.jpg" },
                    { "IMG021", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(26), true, "P006", null, "https://i.pinimg.com/736x/b0/39/73/b039737d55a68818f0ac547fdbaf7815.jpg" },
                    { "IMG022", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(29), false, "P006", null, "https://i.pinimg.com/736x/a3/31/81/a331810d4d85ae1fa1df5fe83b53b74c.jpg" },
                    { "IMG023", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(31), false, "P006", null, "https://i.pinimg.com/736x/13/1e/f5/131ef5b06ee95d29011cb76aff94ef63.jpg" },
                    { "IMG024", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(36), false, "P006", null, "https://i.pinimg.com/736x/16/49/09/164909996c0e0c6dc1d68e278efbc04c.jpg" },
                    { "IMG025", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(39), true, "P007", null, "https://i.pinimg.com/736x/f6/b4/2b/f6b42bd8c809edc47c8095776c22a283.jpg" },
                    { "IMG026", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(41), false, "P007", null, "https://i.pinimg.com/736x/db/f9/d9/dbf9d9ed33a32f4c71f68f9c1b578104.jpg" },
                    { "IMG027", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(44), false, "P007", null, "https://i.pinimg.com/736x/ca/70/a3/ca70a3442377fad4cc2cd1be7648dcba.jpg" },
                    { "IMG028", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(47), false, "P007", null, "https://i.pinimg.com/736x/1d/34/a9/1d34a9e9bc035715cfd19023287ea85f.jpg" },
                    { "IMG029", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(50), true, "P008", null, "https://i.pinimg.com/736x/b1/da/b9/b1dab9d33e6d035bdde006a105eeadef.jpg" },
                    { "IMG030", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(53), false, "P008", null, "https://i.pinimg.com/736x/62/ac/61/62ac610d8bc2584d633d1814fb6b18b7.jpg" },
                    { "IMG031", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(56), false, "P008", null, "https://i.pinimg.com/736x/75/26/76/752676ee949f782d4cadc0d999195ce6.jpg" },
                    { "IMG032", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(61), false, "P008", null, "https://i.pinimg.com/736x/01/1d/61/011d614a9a40efeb72f96008ed501e24.jpg" },
                    { "IMG033", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(64), true, "P009", null, "https://i.pinimg.com/736x/65/d7/2e/65d72ed8d39d3b65d1c13e621ad12dff.jpg" },
                    { "IMG034", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(66), false, "P009", null, "https://i.pinimg.com/736x/9e/9a/7e/9e9a7eb75a0f0f438cdaa417d9ed598d.jpg" },
                    { "IMG035", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(69), false, "P009", null, "https://i.pinimg.com/736x/fa/c1/6d/fac16d229965d9e35ad9e15d7f8737bc.jpg" },
                    { "IMG036", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(71), false, "P009", null, "https://i.pinimg.com/736x/41/64/bc/4164bcd05287c90a6ba3452f3c0620dd.jpg" },
                    { "IMG037", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(74), true, "P010", null, "https://i.pinimg.com/736x/76/b5/f4/76b5f4bce572053343da266875956ee7.jpg" },
                    { "IMG038", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(76), false, "P010", null, "https://i.pinimg.com/736x/6e/80/32/6e8032f27f8eadd8be17bf84f0d3eb1d.jpg" },
                    { "IMG039", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(79), false, "P010", null, "https://i.pinimg.com/736x/ad/97/ed/ad97ed1142ab1af8a4f2aa72bc9929df.jpg" },
                    { "IMG040", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(84), false, "P010", null, "https://i.pinimg.com/736x/29/39/80/293980992371bec074c437a122cf50a6.jpg" },
                    { "IMG041", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(86), true, "P011", null, "https://i.pinimg.com/736x/c2/78/46/c2784664ee92b7b68d13636a1bb225ba.jpg" },
                    { "IMG042", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(89), false, "P011", null, "https://i.pinimg.com/736x/7b/79/8b/7b798b0b6f554f39fc3c627896d10505.jpg" },
                    { "IMG043", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(92), false, "P011", null, "https://i.pinimg.com/736x/48/a2/39/48a23998808e6bc0cebedda709b1bc09.jpg" },
                    { "IMG044", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(95), false, "P011", null, "https://i.pinimg.com/736x/82/af/d0/82afd0193f6db6964ed98f70377907aa.jpg" },
                    { "IMG045", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(97), true, "P012", null, "https://i.pinimg.com/736x/75/5b/05/755b05d7e05e3fddf7ce40087954c291.jpg" },
                    { "IMG046", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(100), false, "P012", null, "https://i.pinimg.com/736x/c0/00/22/c000227c9f4552613b74e05abb01ff39.jpg" },
                    { "IMG047", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(102), false, "P012", null, "https://i.pinimg.com/736x/1f/46/00/1f4600b358bd2c80841a8de451c8d9e8.jpg" },
                    { "IMG048", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(107), false, "P012", null, "https://i.pinimg.com/736x/3d/82/2f/3d822ffe72bc0e042e05d880cff43b80.jpg" },
                    { "IMG049", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(110), true, "P013", null, "https://i.pinimg.com/736x/53/aa/1d/53aa1d016627f6aa7a93dd5ac0eaa6d6.jpg" },
                    { "IMG050", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(112), false, "P013", null, "https://i.pinimg.com/736x/b6/f5/4d/b6f54d32184f0180a19ede274b2ef3e8.jpg" },
                    { "IMG051", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(115), false, "P013", null, "https://i.pinimg.com/736x/4d/3c/92/4d3c92588e4300ff2f078018f12932a6.jpg" },
                    { "IMG052", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(118), false, "P013", null, "https://i.pinimg.com/736x/bb/d5/38/bbd53811a73fdeee8a1beb431ad98dec.jpg" },
                    { "IMG053", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(120), true, "P014", null, "https://i.pinimg.com/736x/01/7e/88/017e8893693250c62ee4dc8a059fc28f.jpg" },
                    { "IMG054", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(123), false, "P014", null, "https://i.pinimg.com/736x/bf/f9/8c/bff98c45138233055df0518b98ba1c8a.jpg" },
                    { "IMG055", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(126), false, "P014", null, "https://i.pinimg.com/736x/62/c1/6a/62c16adfe9d21528e4fbda326c7f9c4e.jpg" },
                    { "IMG056", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(131), false, "P014", null, "https://i.pinimg.com/736x/41/dc/84/41dc846bb27211bf1ee05868b3d9d913.jpg" },
                    { "IMG057", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(133), true, "P015", null, "https://i.pinimg.com/736x/2b/fc/86/2bfc86cdf9e672dd654eccc1b39e2aa2.jpg" },
                    { "IMG058", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(136), false, "P015", null, "https://i.pinimg.com/736x/b4/9a/fb/b49afbd899c56e9ea9cd4b7b157766e5.jpg" },
                    { "IMG059", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(139), false, "P015", null, "https://i.pinimg.com/736x/d0/6c/1b/d06c1b7556183644da554ba5c9bafddc.jpg" },
                    { "IMG060", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(141), false, "P015", null, "https://i.pinimg.com/736x/33/1d/1b/331d1bbe075950dce9c99b6736fba3ae.jpg" }
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
                    { "AI01", "A001", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5352), true, null, "https://tftravel.com.vn/wp-content/uploads/2021/02/team-1.jpg" },
                    { "AI02", "A001", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5369), false, null, "https://i.pinimg.com/originals/a6/bc/25/a6bc259bd4209b1f9dddf93607f68644.jpg" },
                    { "AI03", "A001", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5372), false, null, "https://i.pinimg.com/736x/a9/2a/9e/a92a9ed46b8cc1067dc20840d3c4fee5.jpg" },
                    { "AI04", "A001", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5375), false, null, "https://i.pinimg.com/736x/4e/86/e2/4e86e2cfd4b1b45e5faa6cf872b1a905.jpg" },
                    { "AI05", "A002", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5378), true, null, "https://i.pinimg.com/736x/f1/82/ce/f182ce676795a62d00036da861a90c33.jpg" },
                    { "AI06", "A002", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5381), false, null, "https://i.pinimg.com/736x/aa/95/35/aa953549f4b2bb159d9e726e3ff3a2ed.jpg" },
                    { "AI07", "A002", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5384), false, null, "https://i.pinimg.com/736x/3b/d8/1b/3bd81b616374e74b3fa33dbc916dbfcc.jpg" },
                    { "AI08", "A002", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5389), false, null, "https://i.pinimg.com/736x/93/f9/d8/93f9d842e536468ff7503d6ceda91dca.jpg" },
                    { "AI09", "A005", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5392), true, null, "https://i.pinimg.com/736x/15/f5/46/15f546b7df5498113d23bb5b02497548.jpg" },
                    { "AI10", "A005", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5395), false, null, "https://i.pinimg.com/736x/b0/8c/a9/b08ca9db4b5c47fe25428da2823c9a41.jpg" },
                    { "AI100", "A036", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5799), false, null, "https://i.pinimg.com/736x/af/be/4f/afbe4f62dff502301f9548ac69878f58.jpg" },
                    { "AI101", "A037", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5802), true, null, "https://i.pinimg.com/736x/74/2b/1e/742b1ee0648e30cf46515a001b69e950.jpg" },
                    { "AI102", "A037", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5805), false, null, "https://i.pinimg.com/736x/43/25/52/432552136be3eec79b86c1612918718d.jpg" },
                    { "AI103", "A037", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5808), false, null, "https://i.pinimg.com/736x/66/da/19/66da19604347b4eb703df694703dbafe.jpg" },
                    { "AI104", "A037", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5815), false, null, "https://i.pinimg.com/736x/09/85/bd/0985bdb9abb1ba2006ea5bbaa0156216.jpg" },
                    { "AI105", "A038", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5818), true, null, "https://i.pinimg.com/736x/32/af/33/32af3330425fb3506f3dc3b26f42977d.jpg" },
                    { "AI106", "A038", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5821), false, null, "https://i.pinimg.com/736x/51/f6/0f/51f60f776fd573c1a5c0e0c40dea6ce4.jpg" },
                    { "AI107", "A038", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5823), false, null, "https://i.pinimg.com/736x/bc/01/96/bc019677d32019f157b65a1b52cf8525.jpg" },
                    { "AI108", "A038", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5826), false, null, "https://i.pinimg.com/736x/21/ab/2e/21ab2ea44c87f1ccb5a045fbc108fd5b.jpg" },
                    { "AI109", "A039", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5830), true, null, "https://i.pinimg.com/736x/ea/0d/7d/ea0d7d7bea568bb90db6249962a47e44.jpg" },
                    { "AI11", "A005", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5397), false, null, "https://i.pinimg.com/736x/fb/ec/67/fbec67d903362ff4ffd6bc4489f4910d.jpg" },
                    { "AI110", "A039", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5833), false, null, "https://i.pinimg.com/736x/83/ee/3f/83ee3fabf7711cf45ffe138f56e721cb.jpg" },
                    { "AI111", "A039", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5836), false, null, "https://i.pinimg.com/736x/7d/e4/20/7de420bbb605367225dcf49c8bc1dfc5.jpg" },
                    { "AI112", "A039", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5841), false, null, "https://i.pinimg.com/736x/cd/1e/69/cd1e695a7a4975899d35355af795a1b4.jpg" },
                    { "AI113", "A040", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5844), true, null, "https://i.pinimg.com/736x/96/5f/0d/965f0d17bb49f04319ff92d8386f376b.jpg" },
                    { "AI114", "A040", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5899), false, null, "https://i.pinimg.com/736x/44/87/2d/44872d8ee209e36937d28ce37d9185b2.jpg" },
                    { "AI115", "A040", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5903), false, null, "https://i.pinimg.com/736x/2c/a9/7f/2ca97f876142eb705b5e7b4f2575921f.jpg" },
                    { "AI116", "A040", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5906), false, null, "https://i.pinimg.com/736x/28/3a/6f/283a6fe7b75a8fac14f39e455c5ddf3e.jpg" },
                    { "AI117", "A013", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5909), true, null, "https://i.pinimg.com/736x/61/d6/b1/61d6b1e5b709639b723bb5089152d6d3.jpg" },
                    { "AI118", "A013", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5912), false, null, "https://i.pinimg.com/736x/50/ae/27/50ae27b2034b85d2a7bf4d034d5e572a.jpg" },
                    { "AI119", "A013", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5915), false, null, "https://i.pinimg.com/736x/39/16/78/391678508450a4ee33776c39fdf2c1ef.jpg" },
                    { "AI12", "A005", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5400), false, null, "https://i.pinimg.com/736x/6f/86/0a/6f860aa99e78fdd33ad516dfb84fb13f.jpg" },
                    { "AI120", "A013", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5921), false, null, "https://i.pinimg.com/736x/69/15/b9/6915b9ffa19b89e6f1543e05b5b26f70.jpg" },
                    { "AI121", "A028", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5924), true, null, "https://i.pinimg.com/736x/14/ca/61/14ca61522c3d813c3ea62c4710828ce2.jpg" },
                    { "AI122", "A028", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5927), false, null, "https://i.pinimg.com/736x/4e/97/cc/4e97ccc8f6959a693ac2ad75c13604c7.jpg" },
                    { "AI123", "A028", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5930), false, null, "https://i.pinimg.com/474x/d0/47/cb/d047cbd5b9af39284b7196b273d133a3.jpg" },
                    { "AI124", "A028", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5933), false, null, "https://i.pinimg.com/736x/dc/61/5d/dc615d9f585f76243510fb7e8c7af1d8.jpg" },
                    { "AI125", "A029", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5936), true, null, "https://i.pinimg.com/736x/16/d8/88/16d8888fe52fedf56766a7511c42be69.jpg" },
                    { "AI126", "A029", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5940), false, null, "https://i.pinimg.com/736x/e0/e1/0a/e0e10ace79a99cc678fe9aedfbfdfa83.jpg" },
                    { "AI127", "A029", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5943), false, null, "https://i.pinimg.com/736x/3e/6c/cd/3e6ccdb41eed4ac91ac04b39a4b15694.jpg" },
                    { "AI128", "A029", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5948), false, null, "https://i.pinimg.com/736x/eb/58/42/eb58427dffb8c0c20637df1713a583a8.jpg" },
                    { "AI129", "A025", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5951), true, null, "https://i.pinimg.com/736x/cd/ab/48/cdab4817b7b49287dc3a9531ac99dfae.jpg" },
                    { "AI13", "A007", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5403), true, null, "https://i.pinimg.com/736x/ca/42/d9/ca42d9541580d5542fa29a568a68a714.jpg" },
                    { "AI130", "A025", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5954), false, null, "https://i.pinimg.com/736x/30/34/ea/3034ea8302054e693520957c194decae.jpg" },
                    { "AI131", "A025", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5957), false, null, "https://i.pinimg.com/736x/f4/4b/de/f44bdec05cf7826b67c2030613374ecb.jpg" },
                    { "AI132", "A025", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5960), false, null, "https://i.pinimg.com/736x/fa/c1/ef/fac1efe39388d64003b1ec4c7d2d05e8.jpg" },
                    { "AI133", "A015", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5963), true, null, "https://i.pinimg.com/736x/94/c2/69/94c269ee90d0d8a5584a7a48207f50ca.jpg" },
                    { "AI134", "A015", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5966), false, null, "https://i.pinimg.com/736x/2d/96/29/2d96299467843d2876516493ade1eea3.jpg" },
                    { "AI135", "A015", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5969), false, null, "https://i.pinimg.com/736x/e4/df/f6/e4dff6f0e30260a73019f5d1a44cd8ec.jpg" },
                    { "AI136", "A015", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5974), false, null, "https://i.pinimg.com/736x/9e/4f/2a/9e4f2ab84f5d8e3c4e36ad2c5c3962e2.jpg" },
                    { "AI137", "A011", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5977), true, null, "https://i.pinimg.com/736x/fc/32/5f/fc325f1a000313529aaf6dd0653bfaca.jpg" },
                    { "AI138", "A011", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5980), false, null, "https://i.pinimg.com/736x/a5/e2/55/a5e255b0fe8d64fd9178b912069c13c4.jpg" },
                    { "AI139", "A011", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5983), false, null, "https://i.pinimg.com/736x/39/bc/ca/39bccadc5344e7e653c21c8b8722d0d7.jpg" },
                    { "AI14", "A007", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5406), false, null, "https://i.pinimg.com/736x/3e/ba/30/3eba305131695dd20a6a1203fe955c04.jpg" },
                    { "AI140", "A011", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5986), false, null, "https://i.pinimg.com/736x/13/12/c1/1312c16d2b1ad283e850918f0e7910b2.jpg" },
                    { "AI141", "A004", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5989), true, null, "https://i.pinimg.com/736x/f7/a0/a1/f7a0a12009495691b37fe0a388f714df.jpg" },
                    { "AI142", "A004", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5992), false, null, "https://i.pinimg.com/736x/82/57/b0/8257b0609792600a36c8bf5359871043.jpg" },
                    { "AI143", "A004", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5996), false, null, "https://i.pinimg.com/736x/3e/b1/fd/3eb1fde341c2fdbe68cff2d69953250d.jpg" },
                    { "AI144", "A004", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(6000), false, null, "https://i.pinimg.com/736x/12/7a/6d/127a6dcfb566347f69bdc9635929e59b.jpg" },
                    { "AI15", "A007", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5409), false, null, "https://i.pinimg.com/736x/15/0c/3c/150c3c6df16d0f3b976f07529801a8e5.jpg" },
                    { "AI16", "A007", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5414), false, null, "https://i.pinimg.com/736x/04/56/a8/0456a8ccfe96917fdc56703d2e3cca17.jpg" },
                    { "AI17", "A008", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5417), true, null, "https://i.pinimg.com/736x/4a/1d/4d/4a1d4d05f09b833adb9a78af8be2137f.jpg" },
                    { "AI18", "A008", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5419), false, null, "https://i.pinimg.com/736x/2b/80/60/2b8060ca82bfb42642f1ec4aefe39428.jpg" },
                    { "AI19", "A008", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5422), false, null, "https://i.pinimg.com/736x/81/6b/79/816b79ab93e73d6240177d7da8e345a8.jpg" },
                    { "AI20", "A008", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5425), false, null, "https://i.pinimg.com/736x/da/69/57/da695796f69212dfb2440d2b2e3f6800.jpg" },
                    { "AI21", "A010", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5428), true, null, "https://i.pinimg.com/736x/a5/67/52/a56752ef994d5c6cf6499b4cef52e2f7.jpg" },
                    { "AI22", "A010", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5430), false, null, "https://i.pinimg.com/736x/e8/79/74/e87974221b2c629e6b8652d69e8d137d.jpg" },
                    { "AI23", "A010", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5433), false, null, "https://i.pinimg.com/736x/99/84/d9/9984d9e425ac3663fe5d24e49cb38eed.jpg" },
                    { "AI24", "A010", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5438), false, null, "https://i.pinimg.com/736x/47/ec/be/47ecbea5cfac28fafe8e19faaa355342.jpg" },
                    { "AI25", "A012", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5441), true, null, "https://i.pinimg.com/736x/ef/ba/25/efba25ef9c63e7294340de6f14048795.jpg" },
                    { "AI26", "A012", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5473), false, null, "https://i.pinimg.com/736x/93/d2/55/93d2552c5c6a0f90d867c4617f33d0d1.jpg" },
                    { "AI27", "A012", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5477), false, null, "https://i.pinimg.com/736x/7e/62/d7/7e62d70e323b92b166026ab145e1703e.jpg" },
                    { "AI28", "A012", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5480), false, null, "https://i.pinimg.com/736x/42/de/11/42de11b557fe83b3040178671db20b73.jpg" },
                    { "AI29", "A016", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5482), true, null, "https://i.pinimg.com/736x/c6/49/e8/c649e8f88170ebf177e6910bfc518696.jpg" },
                    { "AI30", "A016", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5503), false, null, "https://i.pinimg.com/736x/77/3d/e8/773de85e694e8f88ed08ff5509ae4355.jpg" },
                    { "AI31", "A016", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5520), false, null, "https://i.pinimg.com/736x/26/94/bd/2694bd3519bcfd0cdf518d6b5ead8684.jpg" },
                    { "AI32", "A016", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5526), false, null, "https://i.pinimg.com/736x/83/67/8f/83678f4941b8d106136201deebb26bc7.jpg" },
                    { "AI33", "A017", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5528), true, null, "https://i.pinimg.com/736x/95/57/ce/9557ce89bef894c11242f90d0e11ed88.jpg" },
                    { "AI34", "A017", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5531), false, null, "https://i.pinimg.com/736x/6c/3d/32/6c3d329db2a87ce681754b0a70040d07.jpg" },
                    { "AI35", "A017", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5534), false, null, "https://i.pinimg.com/736x/04/5b/91/045b9179ebdede69c3aba42195fd47b2.jpg" },
                    { "AI36", "A017", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5537), false, null, "https://i.pinimg.com/736x/05/7c/0a/057c0a4c922c6f98b8d9715bb537ab83.jpg" },
                    { "AI37", "A018", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5540), true, null, "https://i.pinimg.com/736x/8a/ef/b2/8aefb28db28939806440e3de90c5b029.jpg" },
                    { "AI38", "A018", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5543), false, null, "https://i.pinimg.com/736x/53/75/08/537508f69d893602a3cbb031ae699ba5.jpg" },
                    { "AI39", "A018", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5546), false, null, "https://i.pinimg.com/736x/0f/f2/67/0ff26774a0f4fd7745a77d92dc1a3443.jpg" },
                    { "AI40", "A018", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5550), false, null, "https://i.pinimg.com/736x/dd/a5/9b/dda59b436bb82a60da6910e9b556b932.jpg" },
                    { "AI41", "A019", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5553), true, null, "https://i.pinimg.com/736x/6b/c9/c4/6bc9c4075b37202e3bdaa445e0337b13.jpg" },
                    { "AI42", "A019", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5557), false, null, "https://i.pinimg.com/736x/14/a7/87/14a7874490c3b61fab4651ae5ff4112f.jpg" },
                    { "AI43", "A019", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5559), false, null, "https://i.pinimg.com/736x/20/54/f4/2054f48bdc17b91f279938674cbd33ad.jpg" },
                    { "AI44", "A019", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5562), false, null, "https://i.pinimg.com/736x/60/9c/43/609c434fb92fa95266c7be06fe96efbc.jpg" },
                    { "AI45", "A020", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5565), true, null, "https://i.pinimg.com/736x/b8/27/d8/b827d8c8a295985347865df94088c597.jpg" },
                    { "AI46", "A020", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5568), false, null, "https://i.pinimg.com/736x/7b/34/c1/7b34c1cd28ce80067fa749c5009ac7c7.jpg" },
                    { "AI47", "A020", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5570), false, null, "https://i.pinimg.com/736x/95/88/d1/9588d11d286959114820ba9db75495dd.jpg" },
                    { "AI48", "A020", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5575), false, null, "https://i.pinimg.com/736x/6e/2d/24/6e2d2433a754c2c40da9b43a8f8ddeb5.jpg" },
                    { "AI49", "A021", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5578), true, null, "https://i.pinimg.com/736x/5e/42/2d/5e422d974040651b04ed142b92b458dc.jpg" },
                    { "AI50", "A021", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5581), false, null, "https://i.pinimg.com/736x/38/9f/7b/389f7b75e44c3ac7b6a88822fc750a07.jpg" },
                    { "AI51", "A021", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5584), false, null, "https://i.pinimg.com/736x/20/47/c7/2047c724f925d1245fa8fe16d2358e34.jpg" },
                    { "AI52", "A021", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5586), false, null, "https://i.pinimg.com/736x/81/99/9a/81999a3e8311019965629487ead07a76.jpg" },
                    { "AI53", "A022", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5589), true, null, "https://i.pinimg.com/736x/cd/87/ed/cd87ed57b54707beda273ab7859e0aa2.jpg" },
                    { "AI54", "A022", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5592), false, null, "https://i.pinimg.com/736x/9a/38/21/9a3821d24193b383790a027b4010a90e.jpg" },
                    { "AI55", "A022", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5595), false, null, "https://i.pinimg.com/736x/e8/29/e0/e829e0a56266a7ad2e1cb246d3ae8485.jpg" },
                    { "AI56", "A022", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5600), false, null, "https://i.pinimg.com/736x/62/b2/41/62b241944f967787d4f42e1bb8f39150.jpg" },
                    { "AI57", "A023", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5603), true, null, "https://i.pinimg.com/736x/06/fc/aa/06fcaa6e24a14618e2b311626f0e1731.jpg" },
                    { "AI58", "A023", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5605), false, null, "https://i.pinimg.com/736x/c9/1b/40/c91b40ea5039f9ba77c6818c562c5e03.jpg" },
                    { "AI59", "A023", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5608), false, null, "https://i.pinimg.com/736x/12/bc/af/12bcaf16db2536b5efcd0151e4b3961f.jpg" },
                    { "AI60", "A023", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5611), false, null, "https://i.pinimg.com/736x/da/0e/62/da0e62808a44ae34ea64fbed4d53d985.jpg" },
                    { "AI61", "A024", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5614), true, null, "https://i.pinimg.com/736x/62/28/d6/6228d67af0d1ec8fb29c6c2a4caab140.jpg" },
                    { "AI62", "A024", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5616), false, null, "https://i.pinimg.com/736x/16/f2/ed/16f2ed550316d9b9e6b711bf5db48199.jpg" },
                    { "AI63", "A024", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5619), false, null, "https://i.pinimg.com/736x/24/0c/a6/240ca6f928fd4a14f5d374587a79ca15.jpg" },
                    { "AI64", "A024", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5624), false, null, "https://i.pinimg.com/736x/08/5b/6f/085b6fea8dec2b94ae9f61b7371bd673.jpg" },
                    { "AI65", "A026", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5626), true, null, "https://i.pinimg.com/736x/29/27/31/29273169c4efa0a8e6046a12f2da2acc.jpg" },
                    { "AI66", "A026", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5629), false, null, "https://i.pinimg.com/736x/ac/88/35/ac88358182a19358f733c55167609eca.jpg" },
                    { "AI67", "A026", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5632), false, null, "https://i.pinimg.com/736x/77/62/ab/7762abfda62f20753c0178876c1d2502.jpg" },
                    { "AI68", "A026", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5635), false, null, "https://i.pinimg.com/736x/04/12/23/041223a462f501f104f50ff14db702f6.jpg" },
                    { "AI69", "A027", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5637), true, null, "https://i.pinimg.com/736x/1f/ab/c6/1fabc6a5b521f216a23f342e4a0d6693.jpg" },
                    { "AI70", "A027", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5706), false, null, "https://i.pinimg.com/736x/16/8b/93/168b93c1d23074062772105e918cc6fb.jpg" },
                    { "AI71", "A027", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5710), false, null, "https://i.pinimg.com/736x/5d/b4/0f/5db40fd8b35c811b26766a82b7bdc3fe.jpg" },
                    { "AI72", "A027", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5715), false, null, "https://i.pinimg.com/736x/db/7c/11/db7c11ca40d3a7a298b5883f59212e6f.jpg" },
                    { "AI73", "A030", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5718), true, null, "https://i.pinimg.com/736x/4c/4d/f1/4c4df13ca300caf1b6b44e04d7bc850b.jpg" },
                    { "AI74", "A030", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5720), false, null, "https://i.pinimg.com/736x/01/3b/f2/013bf2519246b18ad649a2b46fb555fb.jpg" },
                    { "AI75", "A030", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5723), false, null, "https://i.pinimg.com/736x/92/c0/94/92c094471ff7fd4f62c5ffb60ecbb631.jpg" },
                    { "AI76", "A030", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5726), false, null, "https://i.pinimg.com/736x/8b/5f/c4/8b5fc4a0731c8f1b2e0a260990f4a652.jpg" },
                    { "AI77", "A031", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5728), true, null, "https://i.pinimg.com/736x/fa/11/d0/fa11d0ff1344020f8836c36a65750588.jpg" },
                    { "AI78", "A031", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5731), false, null, "https://i.pinimg.com/736x/32/2e/c3/322ec31c264453cb1cefe341c33bab47.jpg" },
                    { "AI79", "A031", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5734), false, null, "https://i.pinimg.com/736x/a9/76/07/a97607d31abf66ac67fe1e98cca5b1d5.jpg" },
                    { "AI80", "A031", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5738), false, null, "https://i.pinimg.com/736x/b0/45/2d/b0452d15257ce22d4c714cb3256f5223.jpg" },
                    { "AI81", "A032", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5741), true, null, "https://i.pinimg.com/736x/b9/ba/fd/b9bafd46360e4fe812a98b64959eacaf.jpg" },
                    { "AI82", "A032", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5745), false, null, "https://i.pinimg.com/736x/b8/e6/76/b8e67682a4b3d90285c1c703b1ab09eb.jpg" },
                    { "AI83", "A032", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5747), false, null, "https://i.pinimg.com/736x/b3/74/c4/b374c47dd21214efb855a4f4549c41c4.jpg" },
                    { "AI84", "A032", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5750), false, null, "https://i.pinimg.com/736x/5b/7c/54/5b7c54189d8ce4d3bf9b2cc01eeef1fc.jpg" },
                    { "AI85", "A033", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5753), true, null, "https://i.pinimg.com/736x/34/18/22/34182254b22d2132d36b4d78a6b263e5.jpg" },
                    { "AI86", "A033", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5756), false, null, "https://i.pinimg.com/736x/d2/37/86/d237864b3e34810b5433b9526ae4ad0b.jpg" },
                    { "AI87", "A033", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5758), false, null, "https://i.pinimg.com/736x/54/cd/6c/54cd6c312e0dc5066d2c9fbdf6f43868.jpg" },
                    { "AI88", "A033", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5763), false, null, "https://i.pinimg.com/736x/63/71/9c/63719c13e8f733cdd977a4b53aaba0b3.jpg" },
                    { "AI89", "A034", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5766), true, null, "https://i.pinimg.com/736x/eb/a4/99/eba4995776296a9e7976cfd8910fe89d.jpg" },
                    { "AI90", "A034", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5769), false, null, "https://i.pinimg.com/736x/56/07/bf/5607bf1c6dccf0b3ebc2c4c6d7a52acf.jpg" },
                    { "AI91", "A034", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5771), false, null, "https://i.pinimg.com/736x/2e/e6/50/2ee650a3044c4874fdc1179c25f4fa6c.jpg" },
                    { "AI92", "A034", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5774), false, null, "https://i.pinimg.com/736x/9f/86/9a/9f869a68e316f2ee6e38fe0f0e8526d4.jpg" },
                    { "AI93", "A035", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5777), true, null, "https://i.pinimg.com/736x/c0/95/f2/c095f2e3430c2558ad3c8df49c97637b.jpg" },
                    { "AI94", "A035", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5780), false, null, "https://i.pinimg.com/736x/c6/43/a4/c643a40e94d0a38453ea5de5fd25258d.jpg" },
                    { "AI95", "A035", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5783), false, null, "https://i.pinimg.com/736x/84/d2/49/84d249395f122117ecebd58329c4f6fa.jpg" },
                    { "AI96", "A035", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5788), false, null, "https://i.pinimg.com/736x/3b/e4/2f/3be42fafce1256eb99727fcb3b6ef6c9.jpg" },
                    { "AI97", "A036", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5791), true, null, "https://i.pinimg.com/736x/9b/00/c0/9b00c0393fa9b8b34fc0646984c0cd28.jpg" },
                    { "AI98", "A036", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5794), false, null, "https://i.pinimg.com/736x/c4/ef/c4/c4efc41aa1272888f3900a4e84c11050.jpg" },
                    { "AI99", "A036", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(5797), false, null, "https://i.pinimg.com/736x/2e/aa/04/2eaa0421302548f3844c2cb37f0c8d26.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "AccountId", "CreateDate", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "C001", "A003", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7843), 0.0, new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7844) },
                    { "C002", "A006", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7848), 0.0, new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7848) },
                    { "C003", "A011", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7851), 0.0, new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7851) },
                    { "C004", "A014", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7854), 0.0, new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7854) }
                });

            migrationBuilder.InsertData(
                table: "CharacterImage",
                columns: new[] { "CharacterImageId", "CharacterId", "CreateDate", "IsAvatar", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "CI001", "CH001", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9203), null, null, "https://ae01.alicdn.com/kf/HTB1gQt5aO6guuRkSnb4q6zu4XXaw/Naruto-Cosplay-Costumes-Anime-Naruto-Outfit-For-Man-Show-Suits-Japanese-Cartoon-Costumes-Naruto-Coat-Top.jpg" },
                    { "CI002", "CH002", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9210), null, null, "https://lzd-img-global.slatic.net/g/ff/kf/Sfedbbf9e61af4bc5a4ce107829ab12ffP.jpg_720x720q80.jpg" },
                    { "CI003", "CH003", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9213), null, null, "https://tse2.mm.bing.net/th/id/OIP.7wO0lin122XZz8cW6QwMPwHaNK?rs=1&pid=ImgDetMain" },
                    { "CI004", "CH004", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9215), null, null, "https://th.bing.com/th/id/R.a547136c5dc32ca575032d919b616c81?rik=QB63jSYlpxVIDg&pid=ImgRaw&r=0" },
                    { "CI005", "CH005", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9218), null, null, "https://tse3.mm.bing.net/th/id/OIP.Iv-VMJCvgXjXP3seS54VUQHaIj?rs=1&pid=ImgDetMain" },
                    { "CI006", "CH006", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9221), null, null, "https://i.pinimg.com/736x/88/67/c2/8867c200a089728d7e5fc0893c4b768d.jpg" },
                    { "CI007", "CH007", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9223), null, null, "https://tse1.explicit.bing.net/th/id/OIP.v9qz5NCIL7XhgBUU1rnkLQHaKL?rs=1&pid=ImgDetMain" },
                    { "CI008", "CH008", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9226), null, null, "https://cdn.openart.ai/stable_diffusion/43d1f34dddfdcdfefa54b8984be0a96159b200a8_2000x2000.webp" },
                    { "CI009", "CH009", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9229), null, null, "https://tse1.mm.bing.net/th/id/OIP.dX8f8uziv7-sVE-MGmiKMwHaHa?rs=1&pid=ImgDetMain" },
                    { "CI010", "CH010", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9234), null, null, "https://tse3.mm.bing.net/th/id/OIP.GLTrvuL5642aAYTOFxC0eAHaJQ?rs=1&pid=ImgDetMain" },
                    { "CI011", "CH011", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9236), null, null, "https://th.bing.com/th/id/R.1a1aeceee8146ba95dd2a8f69c3f182f?rik=T9YeKcs%2b27tcsg&pid=ImgRaw&r=0" },
                    { "CI012", "CH012", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9240), null, null, "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/7b60d23e-2e8e-44da-a221-dc39a83c4f3f/der5hqx-ee11482f-b214-4b25-bfee-88dc11a8c4fe.jpg/v1/fill/w_1280,h_1814,q_75,strp/sephiroth__full_body__by_akonyah_der5hqx-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzdiNjBkMjNlLTJlOGUtNDRkYS1hMjIxLWRjMzlhODNjNGYzZlwvZGVyNWhxeC1lZTExNDgyZi1iMjE0LTRiMjUtYmZlZS04OGRjMTFhOGM0ZmUuanBnIiwiaGVpZ2h0IjoiPD0xODE0Iiwid2lkdGgiOiI8PTEyODAifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6aW1hZ2Uud2F0ZXJtYXJrIl0sIndtayI6eyJwYXRoIjoiXC93bVwvN2I2MGQyM2UtMmU4ZS00NGRhLWEyMjEtZGMzOWE4M2M0ZjNmXC9ha29ueWFoLTQucG5nIiwib3BhY2l0eSI6OTUsInByb3BvcnRpb25zIjowLjQ1LCJncmF2aXR5IjoiY2VudGVyIn19.e9IstlpQcF1QRaMoUKkr41MQ7pekjWh_iOje74x3coY" },
                    { "CI013", "CH013", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9242), null, null, "https://tse1.mm.bing.net/th/id/OIP.uCp4Whd_B4z4Zw8C7wvjxwHaLH?rs=1&pid=ImgDetMain" },
                    { "CI014", "CH014", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9245), null, null, "https://tse3.mm.bing.net/th/id/OIP.3ADDr3lt8PYxM6KP10OtwwAAAA?rs=1&pid=ImgDetMain" },
                    { "CI015", "CH015", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9247), null, null, "https://thatparkplace.com/wp-content/uploads/2023/04/kirby-e1681312791814.jpg" }
                });

            migrationBuilder.InsertData(
                table: "EventActivity",
                columns: new[] { "EventActivityId", "ActivityId", "CreateBy", "CreateDate", "Description", "EventId", "UpdateDate" },
                values: new object[,]
                {
                    { "EA001", "ACT001", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8679), "Yoga for a fresh start", "E001", null },
                    { "EA002", "ACT005", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8684), "Tech trends in the new year", "E001", null },
                    { "EA003", "ACT004", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8687), "Painting cherry blossoms", "E002", null },
                    { "EA004", "ACT013", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8690), "AI and future coding", "E003", null },
                    { "EA005", "ACT009", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8693), "Dance battles live", "E004", null },
                    { "EA006", "ACT003", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8696), "Comic-Con live music", "E005", null },
                    { "EA007", "ACT007", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8701), "Anime and book discussions", "E006", null },
                    { "EA008", "ACT010", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8704), "Chess and gaming", "E007", null },
                    { "EA009", "ACT011", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8707), "Outdoor movie fun", "E008", null },
                    { "EA010", "ACT015", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8710), "Meditation for cosplayers", "E009", null },
                    { "EA011", "ACT012", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8713), "Science in filmmaking", "E010", null },
                    { "EA012", "ACT006", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8716), "Halloween charity run", "E011", null },
                    { "EA013", "ACT014", "Admin", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8719), "Christmas gardening", "E012", null },
                    { "EA014", "ACT002", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8722), "Cooking for music lovers", "E004", null },
                    { "EA015", "ACT008", "Manager", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(8727), "Photography in tech", "E003", null }
                });

            migrationBuilder.InsertData(
                table: "EventCharacter",
                columns: new[] { "EventCharacterId", "CharacterId", "CreateDate", "Description", "EventId", "IsAssign", "UpdateDate" },
                values: new object[,]
                {
                    { "EC001", "CH001", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8598), null, "E001", true, null },
                    { "EC002", "CH002", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8603), null, "E002", true, null },
                    { "EC003", "CH003", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8608), null, "E003", true, null },
                    { "EC004", "CH004", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8611), null, "E004", true, null },
                    { "EC005", "CH005", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8614), null, "E005", true, null },
                    { "EC006", "CH006", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8617), null, "E006", true, null },
                    { "EC007", "CH007", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8620), null, "E007", true, null },
                    { "EC008", "CH008", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8623), null, "E008", true, null },
                    { "EC009", "CH009", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8626), null, "E009", true, null },
                    { "EC010", "CH010", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8629), null, "E010", true, null },
                    { "EC011", "CH011", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8634), null, "E011", true, null },
                    { "EC012", "CH012", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8637), null, "E012", true, null }
                });

            migrationBuilder.InsertData(
                table: "EventImage",
                columns: new[] { "ImageId", "CreateDate", "EventId", "ImageUrl", "IsAvatar", "UpdateDate" },
                values: new object[,]
                {
                    { "EI001", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9294), "E001", "https://cdn-i.vtcnews.vn/resize/th/upload/2020/01/20/1-08485735.jpg", true, null },
                    { "EI002", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9298), "E001", "https://file.hstatic.net/200000833669/article/1_d82dc925795b42c29f8bd09558e1e0f9.png", false, null },
                    { "EI003", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9304), "E001", "https://mcdn.coolmate.me/image/May2022/top-le-hoi-cosplay-festival-noi-tieng_735.jpg", false, null },
                    { "EI004", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9307), "E001", "https://i.vietgiaitri.com/2011/7/0/chien-binh-king-of-fighters-giuong-oai-o-le-hoi-cosplay-26cc13.jpg", false, null },
                    { "EI005", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9310), "E002", "https://media.wnyc.org/i/1500/996/l/80/1/BBG_SakuraMatsuri_CosplayFashions_Ratliff.jpg", true, null },
                    { "EI006", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9312), "E002", "https://www.vice.com/wp-content/uploads/sites/2/2024/07/photos-of-cherry-blossoms-and-cosplay-costumes-at-a-kawaii-festival-592-1462476637.jpg", false, null },
                    { "EI007", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9315), "E002", "https://www.vice.com/wp-content/uploads/sites/2/2016/05/photos-of-cherry-blossoms-and-cosplay-costumes-at-a-kawaii-festival-1462476813.jpg", false, null },
                    { "EI008", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9318), "E002", "https://s.hdnux.com/photos/01/37/11/15/24941427/3/ratio3x2_960.jpg", false, null },
                    { "EI009", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9320), "E003", "https://capetownguy.co.za/wp-content/uploads/2023/02/Comic-Con-Cape-Town-2023-Cosplay.png", true, null },
                    { "EI010", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9323), "E003", "https://i.pinimg.com/736x/63/77/6f/63776facb73bf3f2ed8530a94cf592ca.jpg", false, null },
                    { "EI011", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9332), "E003", "https://i.pinimg.com/736x/2f/94/3c/2f943c92510f7ad55e221289a9534a48.jpg", false, null },
                    { "EI012", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9373), "E003", "https://i.pinimg.com/736x/5a/25/ce/5a25ce753b5fbcf92653809ca3325adb.jpg", false, null },
                    { "EI013", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9377), "E004", "https://i.pinimg.com/736x/82/2e/55/822e554280de23126220adeeaf6a7631.jpg", true, null },
                    { "EI014", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9380), "E004", "https://i.pinimg.com/736x/0a/73/7b/0a737b3f0f73fcf845a1311f73077bdf.jpg", false, null },
                    { "EI015", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9383), "E004", "https://i.pinimg.com/736x/c1/e1/61/c1e161a1e6b1f27ab79100674ce715c2.jpg", false, null },
                    { "EI016", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9386), "E004", "https://i.pinimg.com/736x/ff/29/f7/ff29f7e84980b8f649a0b655013e6afa.jpg", false, null },
                    { "EI017", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9388), "E005", "https://i.pinimg.com/736x/64/91/68/649168c18bd7d4665c4bfe032a2e3cb1.jpg", true, null },
                    { "EI018", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9391), "E005", "https://i.pinimg.com/736x/c3/ee/73/c3ee73dc1432a9aefe4bc23ca9205b49.jpg", false, null },
                    { "EI019", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9396), "E005", "https://i.pinimg.com/736x/f4/2f/f0/f42ff0521385be118d2ed5ca19fa7416.jpg", false, null },
                    { "EI020", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9399), "E005", "https://i.pinimg.com/736x/59/80/d6/5980d6150aff50f385f509c75d9b9cb5.jpg", false, null },
                    { "EI021", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9402), "E006", "https://i.pinimg.com/736x/1f/b6/b4/1fb6b49b7e7b1faa3743a74d631f8ee0.jpg", true, null },
                    { "EI022", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9405), "E006", "https://i.pinimg.com/736x/6f/2a/1c/6f2a1c31e1caab9245f4ee67bbff1a8a.jpg", false, null },
                    { "EI023", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9408), "E006", "https://i.pinimg.com/736x/5e/2a/37/5e2a375a7bc3bc8f53a3bda093685afc.jpg", false, null },
                    { "EI024", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9410), "E006", "https://i.pinimg.com/736x/1e/23/fc/1e23fcbdbe84a87de180f1214ab970df.jpg", false, null },
                    { "EI025", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9413), "E007", "https://i.pinimg.com/736x/e0/52/52/e052529f9d0df8ca08e0bfd0d609ff33.jpg", true, null },
                    { "EI026", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9416), "E007", "https://i.pinimg.com/736x/79/b5/6f/79b56f067960f2f8780c87d6d1be5f69.jpg", false, null },
                    { "EI027", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9421), "E007", "https://i.pinimg.com/736x/89/a1/8f/89a18f6bfb85722c64bcfa4b687c4502.jpg", false, null },
                    { "EI028", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9424), "E007", "https://i.pinimg.com/736x/7c/57/da/7c57dac7ca005402b824f56c44e4ac7b.jpg", false, null },
                    { "EI029", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9427), "E008", "https://i.pinimg.com/736x/f3/4d/ca/f34dcaadcedb9848b6ac6419f65c3b9d.jpg", true, null },
                    { "EI030", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9430), "E008", "https://i.pinimg.com/736x/98/a0/ed/98a0ed924ea799cd3612a3bb5e3aee61.jpg", false, null },
                    { "EI031", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9433), "E008", "https://i.pinimg.com/736x/73/1c/f4/731cf48f181b3bf7fc71d80baa3656f1.jpg", false, null },
                    { "EI032", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9436), "E008", "https://i.pinimg.com/736x/a3/50/52/a35052bc18722657ab0db440e4f8a8e5.jpg", false, null },
                    { "EI033", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9439), "E009", "https://i.pinimg.com/736x/7f/bd/72/7fbd72289fecd220453a16d062273ee5.jpg", true, null },
                    { "EI034", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9441), "E009", "https://i.pinimg.com/736x/34/d1/4a/34d14a51253bb4e9ff3ae3134ec76b68.jpg", false, null },
                    { "EI035", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9446), "E009", "https://i.pinimg.com/736x/b0/34/df/b034df343ed32c11f2d62e07420e1998.jpg", false, null },
                    { "EI036", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9449), "E009", "https://i.pinimg.com/736x/ec/0e/36/ec0e363bf99880faa216b6152819ee83.jpg", false, null },
                    { "EI037", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9452), "E010", "https://i.pinimg.com/736x/a2/7b/b5/a27bb57604f07d1346d91d5fbd15f4a3.jpg", true, null },
                    { "EI038", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9455), "E010", "https://i.pinimg.com/736x/6d/be/09/6dbe0978d8e5cc1c3a471588b38249aa.jpg", false, null },
                    { "EI039", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9457), "E010", "https://i.pinimg.com/736x/dd/66/1b/dd661b664fe68d74c187f35a5246e36a.jpg", false, null },
                    { "EI040", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9460), "E010", "https://i.pinimg.com/736x/8f/30/f3/8f30f3582ba3ad998c74ee5e771eb364.jpg", false, null },
                    { "EI041", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9463), "E011", "https://i.pinimg.com/736x/20/3e/88/203e883cc5ac82f26e2bf8a1d4eefe36.jpg", true, null },
                    { "EI042", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9466), "E011", "https://i.pinimg.com/736x/60/fc/fd/60fcfd76e8b418743b04d4347459cb37.jpg", false, null },
                    { "EI043", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9470), "E011", "https://i.pinimg.com/736x/e2/48/6d/e2486ddc382f7b87edfb422e46de3aca.jpg", false, null },
                    { "EI044", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9473), "E011", "https://i.pinimg.com/736x/ce/2a/c5/ce2ac53f28e0dccf609b835418cdff89.jpg", false, null },
                    { "EI045", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9476), "E012", "https://i.pinimg.com/736x/5b/17/a0/5b17a0593a7e9b7d69d9b6cceef06897.jpg", true, null },
                    { "EI046", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9478), "E012", "https://i.pinimg.com/736x/09/68/8b/09688bd8893f39a83e0e9e6b3073f2de.jpg", false, null },
                    { "EI047", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9481), "E012", "https://i.pinimg.com/736x/73/9f/ad/739fad57ea629dc30f5bfc5a2ae0052b.jpg", false, null },
                    { "EI048", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9484), "E012", "https://i.pinimg.com/736x/d1/a9/d5/d1a9d54239ffab7c036f7b5b6853f204.jpg", false, null }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "AccountId", "CreatedAt", "IsRead", "IsSentMail", "Message" },
                values: new object[,]
                {
                    { "N001", "A001", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7742), false, true, "Welcome to the system!" },
                    { "N002", "A002", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7745), false, true, "Your account has been upgraded." },
                    { "N003", "A003", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7749), true, true, "New promotional offer available!" },
                    { "N004", "A004", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7754), false, true, "Your request has been approved." },
                    { "N005", "A005", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7756), true, true, "System maintenance scheduled." },
                    { "N006", "A006", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7760), false, true, "Your order has been shipped!" },
                    { "N007", "A007", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7763), false, true, "New event registration open." },
                    { "N008", "A008", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7766), true, true, "Reminder: Payment due soon." },
                    { "N009", "A009", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7768), false, true, "Your password was changed." },
                    { "N010", "A010", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7771), false, true, "Admin announcement update." },
                    { "N011", "A011", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7774), true, true, "New message from support." },
                    { "N012", "A012", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7779), false, true, "Upcoming event invitation." },
                    { "N013", "A013", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7782), false, true, "New cosplayer contest." },
                    { "N014", "A014", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7785), true, true, "Loyalty points updated." },
                    { "N015", "A015", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(7787), false, true, "Your subscription expired." }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "AccountId", "Address", "CancelDate", "CancelReason", "Description", "OrderDate", "OrderStatus", "Phone", "ShipCode", "ShipStatus", "TotalPrice", "to_district_id", "to_ward_code" },
                values: new object[,]
                {
                    { "O001", "A003", "123 Main St", null, null, null, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0901234567", "S001", 1, 250000.0, 3695, "90767" },
                    { "O002", "A006", "456 Elm St", null, null, null, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0902345678", "S002", 4, 150000.5, 3695, "90767" },
                    { "O003", "A011", "789 Pine St", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "0903456789", "S003", 2, 300000.0, 3695, "90767" },
                    { "O004", "A014", "101 Oak St", null, null, null, new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0904567890", "S004", 0, 400000.0, 3695, "90767" },
                    { "O005", "A003", "123 Main St", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "0901234567", "S005", 1, 175000.0, 3695, "90767" },
                    { "O006", "A006", "456 Elm St", null, null, null, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0902345678", "S006", 1, 225000.0, 3695, "90767" },
                    { "O007", "A011", "789 Pine St", null, null, null, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0903456789", "S007", 1, 350000.0, 3695, "90767" },
                    { "O008", "A014", "101 Oak St", new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "0904567890", "S008", 1, 275000.0, 3695, "90767" },
                    { "O009", "A003", "123 Main St", null, null, null, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0901234567", "S009", 1, 500000.0, 3695, "90767" },
                    { "O010", "A006", "456 Elm St", new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "0902345678", "S010", 1, 125000.0, 3695, "90767" },
                    { "O011", "A011", "789 Pine St", null, null, null, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0903456789", "S011", 1, 325000.0, 3695, "90767" },
                    { "O012", "A014", "101 Oak St", null, null, null, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0904567890", "S012", 1, 410000.0, 3695, "90767" },
                    { "O013", "A003", "123 Main St", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "0901234567", "S013", 1, 280000.0, 3695, "90767" },
                    { "O014", "A006", "456 Elm St", null, null, null, new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0902345678", "S014", 1, 350000.0, 3695, "90767" },
                    { "O015", "A011", "789 Pine St", null, null, null, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0903456789", "S015", 1, 200000.0, 3695, "90767" }
                });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "RequestId", "AccountId", "CreatedDate", "Deposit", "Description", "EndDate", "IsValidate", "Location", "Name", "PackageId", "Price", "Range", "Reason", "ServiceId", "StartDate", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { "R001", "A001", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(7894), null, "RentCostumes", new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "HCM", "Rent Naruto Costume", "PKG001", 100000.0, null, null, "S003", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R002", "A002", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(7917), null, "RentCosplayer", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ĐN", "Rent Cosplayer for Event", null, 500000.0, null, "Cosplayer is busy", "S002", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R003", "A003", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(7923), null, "CreateEvent", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "BD", "Create Anime Festival", null, 2000000.0, null, null, "S003", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R004", "A004", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(7927), null, "RentCostumes", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "HN", "Rent Samurai Armor", null, 150000.0, null, null, "S002", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R005", "A002", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(7932), null, "RentCosplayer", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "BT", "Hire Professional Cosplayer", "PKG002", 700000.0, null, null, "S002", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R006", "A006", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(7937), null, "CreateEvent", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "HCM", "Organize Comic Convention", null, 5000000.0, null, null, "S001", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R007", "A007", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(7941), null, "RentCostumes", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "HCM", "Rent Victorian Costume", null, 120000.0, null, "Cosplayer is busy", "S002", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R008", "A008", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(7948), null, "RentCosplayer", new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "QN", "Book Cosplayer for Birthday Party", null, 350000.0, null, null, "S003", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R009", "A009", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(7954), null, "CreateEvent", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "CM", "Plan Fantasy Fair", null, 3000000.0, null, null, "S003", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R010", "A010", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8024), null, "RentCostumes", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "LĐ", "Rent Halloween Costumes", null, 200000.0, null, null, "S001", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R011", "A011", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8030), null, "RentCosplayer", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "NT", "Hire Cosplayer for Wedding", "PKG010", 800000.0, null, null, "S001", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R012", "A012", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8035), null, "CreateEvent", new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "VT", "Create Sci-Fi Convention", null, 4500000.0, null, null, "S002", new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R013", "A013", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8039), null, "RentCostumes", new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "HCM", "Rent Santa Claus Costume", null, 130000.0, null, null, "S003", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R014", "A014", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8044), null, "RentCosplayer", new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "HN", "Book Cosplayer for Product Launch", null, 600000.0, null, null, "S001", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R015", "A015", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8050), null, "CreateEvent", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "HCM", "Host Christmas Event", "PKG015", 5500000.0, null, null, "S002", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null }
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
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "02749d5c-36bd-4f46-a654-48b67516760d", "C003", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9136), 60000.0, "P009", 1 },
                    { "03da5e10-c9f3-4301-b000-f12870aae6c8", "C003", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9129), 50000.0, "P008", 2 },
                    { "17c010a6-45b5-4677-9424-4f469212aaa4", "C004", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9149), 45000.0, "P012", 1 },
                    { "2f5e6b22-33fb-4031-9cb7-6fe599264bde", "C002", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9120), 40000.0, "P006", 2 },
                    { "4aa07b54-9cde-4e68-b4cf-539b62473706", "C002", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9071), 100000.0, "P004", 1 },
                    { "79b31418-1d63-455b-a55d-d382ff8dfa41", "C001", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9066), 80000.0, "P003", 1 },
                    { "7ccd60e8-9b74-4199-b79c-08edd3ce0dc5", "C001", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9056), 30000.0, "P001", 2 },
                    { "7ed60b78-aef5-4b4a-bd43-22176e698701", "C004", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9145), 35000.0, "P011", 2 },
                    { "a61bc586-4138-4947-be3d-6b3d1af296cd", "C002", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9078), 25000.0, "P005", 3 },
                    { "ab5729ba-fe00-48e8-ab4d-3f01612e4daf", "C004", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9140), 120000.0, "P010", 1 },
                    { "b64e09fe-3f35-40a7-8627-06a80d6bbe17", "C001", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9062), 20000.0, "P002", 1 },
                    { "cc53ab7b-d741-4317-a9b4-f696622318fa", "C003", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9125), 15000.0, "P007", 5 }
                });

            migrationBuilder.InsertData(
                table: "Contract",
                columns: new[] { "ContractId", "Amount", "ContractName", "ContractStatus", "CreateBy", "CreateDate", "DeliveryStatus", "Deposit", "Reason", "RequestId", "TotalPrice", "UrlPdf" },
                values: new object[,]
                {
                    { "CT002", 0.0, "Character rental", 5, "A002", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "100", null, "R002", 500000.0, null },
                    { "CT005", 350000.0, "Character rental", 5, "A005", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "50", null, "R005", 700000.0, null },
                    { "CT008", 175000.0, "Character rental", 1, "A008", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "50", null, "R008", 350000.0, null },
                    { "CT010", 100000.0, "Character rental", 2, "A010", new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "50", null, "R010", 200000.0, null },
                    { "CT014", 0.0, "Character rental", 1, "A014", new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "100", null, "R014", 600000.0, null }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "069c6686-e8a7-4699-bbe8-b73c2177ab4a", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9705), "O012", 60000.0, "P009", 1 },
                    { "0a08ebbd-8a69-48a2-8fc0-88bef6032fd6", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9610), "O001", 20000.0, "P002", 5 },
                    { "0b9641c1-fa74-4439-ad04-987ab272eaf7", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9631), "O004", 15000.0, "P007", 4 },
                    { "0e34c6c1-59b2-4043-96f9-8101aeae3621", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9698), "O011", 15000.0, "P007", 4 },
                    { "22a7faf9-0cfc-43bb-9eac-1e919723d883", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9723), "O014", 18000.0, "P013", 5 },
                    { "247c147c-db99-4f50-bd0e-f26e68b1fbeb", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9662), "O007", 90000.0, "P014", 2 },
                    { "3610f3cb-6aa1-4cdc-92ba-62ae3547c091", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9603), "O001", 30000.0, "P001", 3 },
                    { "3c2a5deb-6ed7-402b-9cf4-144daef84d89", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9709), "O013", 120000.0, "P010", 1 },
                    { "404b8656-689c-4529-94fa-765a9e41860f", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9692), "O011", 40000.0, "P006", 2 },
                    { "493fba9c-60d7-49c7-aca3-2330e27fabc0", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9669), "O008", 30000.0, "P001", 1 },
                    { "4b5f22e9-86d1-4e23-8a5e-23044cba4ff6", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9635), "O004", 50000.0, "P008", 2 },
                    { "516010b5-25b5-452d-8f9f-23dca5e73f1f", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9684), "O010", 100000.0, "P004", 1 },
                    { "61b3aaeb-738b-49d4-bc99-506b8d5445ae", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9673), "O009", 20000.0, "P002", 6 },
                    { "629312ae-a26b-49c1-9ee4-01099d3c876f", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9688), "O010", 25000.0, "P005", 3 },
                    { "634bc390-63c1-4972-b447-7585ba25ff6d", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9727), "O015", 90000.0, "P014", 2 },
                    { "67250a71-6284-4d16-94e7-2bf1ff2d803b", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9656), "O007", 18000.0, "P013", 5 },
                    { "75205808-6165-4be6-8f29-a9d41c5b3759", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9715), "O013", 35000.0, "P011", 2 },
                    { "7a9f4e6b-69ce-4fbf-aca0-0f48e0aa13fb", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9614), "O002", 80000.0, "P003", 1 },
                    { "7c5096ab-03e9-4af2-8ae5-21dd3b70e9b4", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9644), "O005", 120000.0, "P010", 1 },
                    { "834ecf34-f6de-4b86-91cb-4b5ecadd9501", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9618), "O002", 100000.0, "P004", 1 },
                    { "8473a25d-3867-4566-8575-976ba008edc1", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9719), "O014", 45000.0, "P012", 3 },
                    { "8d24dca1-b538-4fe1-8972-8e7d166f0f1c", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9648), "O006", 35000.0, "P011", 2 },
                    { "9fc55d54-92f6-4720-9720-46c7771e2be6", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9733), "O015", 22000.0, "P015", 4 },
                    { "ab7dfbe6-d26a-442a-9462-2b4b2cc6a756", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9639), "O005", 60000.0, "P009", 1 },
                    { "b34061e4-e9ef-43f6-aeba-d9592e5f3aea", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9680), "O009", 80000.0, "P003", 2 },
                    { "bfab78e2-8a22-4a50-86a6-2b8c1c0c4df4", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9622), "O003", 25000.0, "P005", 2 },
                    { "da5275ae-bce3-43f7-991c-1689b9c37390", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9702), "O012", 50000.0, "P008", 2 },
                    { "fa6c11ee-b865-464a-a85d-8e05da0ff7eb", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9627), "O003", 40000.0, "P006", 3 },
                    { "fc9ef4d6-fd88-4d93-8a14-9f4292dea62c", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9665), "O008", 22000.0, "P015", 4 },
                    { "fd56ea7b-baf4-4c92-ae24-78dd7c96a76e", new DateTime(2025, 6, 7, 6, 59, 53, 801, DateTimeKind.Utc).AddTicks(9652), "O006", 45000.0, "P012", 3 }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "AccountCouponID", "Amount", "ContractId", "CreatAt", "OrderId", "Purpose", "Status", "TicketAccountId", "TransactionId", "Type" },
                values: new object[,]
                {
                    { "P006", "AC003", 225000.0, null, new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "O006", 3, 1, null, "TXN006", "VNPay" },
                    { "P007", null, 350000.0, null, new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "O007", 3, 0, null, "TXN007", "VNPay" },
                    { "P008", null, 150000.0, null, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "O008", 3, 1, null, "TXN008", "VNPay" },
                    { "P009", null, 500000.0, null, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "O009", 3, 1, null, "TXN009", "VNPay" },
                    { "P010", "AC004", 125000.0, null, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "O010", 3, 2, null, "TXN010", "VNPay" }
                });

            migrationBuilder.InsertData(
                table: "RequestCharacter",
                columns: new[] { "RequestCharacterId", "CharacterId", "CosplayerId", "CreateDate", "Description", "Quantity", "Reason", "RequestId", "Status", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "RC01", "CH001", "A025", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(315), "Yêu cầu cosplay nhân vật CH001", 1, null, "R001", null, 50000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(315) },
                    { "RC02", "CH002", "A026", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(320), "Yêu cầu cosplay nhân vật CH002", 1, null, "R002", null, 60000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(321) },
                    { "RC03", "CH003", "A027", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(325), "Yêu cầu cosplay nhân vật CH003", 1, null, "R003", null, 70000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(325) },
                    { "RC04", "CH004", "A028", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(331), "Yêu cầu cosplay nhân vật CH004", 1, null, "R004", null, 80000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(331) },
                    { "RC05", "CH005", "A029", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(334), "Yêu cầu cosplay nhân vật CH005", 1, null, "R005", null, 90000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(335) },
                    { "RC06", "CH006", null, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(338), "Yêu cầu cosplay nhân vật CH006", 5, null, "R006", null, 100000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(339) },
                    { "RC07", "CH007", "A031", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(342), "Yêu cầu cosplay nhân vật CH007", 1, null, "R007", null, 110000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(343) },
                    { "RC08", "CH008", null, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(346), "Yêu cầu cosplay nhân vật CH008", 7, null, "R008", null, 120000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(346) },
                    { "RC09", "CH009", "A033", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(349), "Yêu cầu cosplay nhân vật CH009", 1, null, "R009", null, 130000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(350) },
                    { "RC10", "CH010", null, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(353), "Yêu cầu cosplay nhân vật CH010", 9, null, "R010", null, 140000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(353) },
                    { "RC11", "CH011", "A035", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(357), "Yêu cầu cosplay nhân vật CH011", 1, null, "R011", null, 150000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(357) },
                    { "RC12", "CH012", "A036", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(362), "Yêu cầu cosplay nhân vật CH012", 1, null, "R012", null, 160000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(363) },
                    { "RC13", "CH013", null, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(366), "Yêu cầu cosplay nhân vật CH013", 10, null, "R013", null, 170000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(367) },
                    { "RC14", "CH014", "A038", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(370), "Yêu cầu cosplay nhân vật CH014", 1, null, "R014", null, 180000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(370) },
                    { "RC15", "CH015", "A039", new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(373), "Yêu cầu cosplay nhân vật CH015", 1, null, "R015", null, 190000.0, new DateTime(2025, 6, 7, 6, 59, 53, 802, DateTimeKind.Utc).AddTicks(374) }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "AccountId", "ContractCharacterId", "CreateDate", "Description", "EndDate", "EventCharacterId", "IsActive", "IsValidate", "Location", "StartDate", "Status", "TaskName", "Type", "UpdateDate" },
                values: new object[,]
                {
                    { "T001", "A001", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8112), "Cosplay as anime characters", new DateTime(2025, 6, 10, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8111), "EC001", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 9, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8106), 0, "CH001", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8113) },
                    { "T002", "A004", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8126), "Join cosplay contest", new DateTime(2025, 6, 12, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8125), "EC002", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 11, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8123), 1, "CH002", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8127) },
                    { "T003", "A005", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8133), "Teach costume making", new DateTime(2025, 6, 14, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8132), "EC003", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 13, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8131), 2, "CH003", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8134) },
                    { "T004", "A007", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8139), "Host a live event", new DateTime(2025, 6, 8, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8139), "EC004", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 8, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8137), 3, "CH004", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8140) },
                    { "T005", "A008", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8146), "Professional cosplay photoshoot", new DateTime(2025, 6, 16, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8145), "EC005", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 15, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8144), 0, "CH005", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8146) },
                    { "T006", "A010", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8152), "Evaluate contestants", new DateTime(2025, 6, 18, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8151), "EC006", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 17, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8150), 1, "CH006", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8153) },
                    { "T007", "A012", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8159), "Walk in parade", new DateTime(2025, 6, 20, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8158), "EC007", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 19, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8157), 2, "CH007", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8160) },
                    { "T008", "A013", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8166), "Perform on live TV", new DateTime(2025, 6, 22, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8165), "EC008", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 21, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8164), 3, "CH008", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8166) },
                    { "T009", "A015", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8173), "Perform for charity", new DateTime(2025, 6, 24, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8172), "EC009", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 23, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8171), 4, "CH008", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8173) },
                    { "T010", "A005", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8181), "Talk about cosplay industry", new DateTime(2025, 6, 26, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8180), "EC010", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 25, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8179), 0, "CH009", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8182) },
                    { "T011", "A008", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8187), "New character shoot", new DateTime(2025, 6, 28, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8186), "EC011", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 27, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8185), 1, "CH010", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8188) },
                    { "T012", "A007", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8193), "Host main event", new DateTime(2025, 6, 30, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8192), "EC012", true, true, "Ho Chi Minh city", new DateTime(2025, 6, 29, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8192), 2, "CH011", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8194) }
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
                    { "P001", "AC001", 250000.0, null, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, "TA001", "TXN001", "VNPay" },
                    { "P002", null, 150000.0, null, new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, "TA002", "TXN002", "VNPay" },
                    { "P003", null, 90000.0, null, new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, "TA003", "TXN003", "VNPay" },
                    { "P004", "AC012", 400000.0, null, new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, "TA004", "TXN004", "VNPay" },
                    { "P005", null, 175000.0, null, new DateTime(2025, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 2, "TA005", "TXN005", "VNPay" },
                    { "P011", null, 325000.0, "CT002", new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, null, "TXN011", "VNPay" },
                    { "P012", null, 410000.0, "CT005", new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0, null, "TXN012", "VNPay" },
                    { "P013", null, 90000.0, "CT008", new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, null, "TXN013", "VNPay" },
                    { "P014", null, 350000.0, "CT010", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, null, "TXN014", "VNPay" },
                    { "P015", null, 200000.0, "CT002", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, null, "TXN015", "VNPay" }
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
                    { "267a1084-f792-43ec-b8af-ec8c486c2281", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", 5, null },
                    { "2e1ad94e-baf7-4c18-80e9-0aecabeed7e6", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", 5, null },
                    { "6d649b9b-ef93-4d02-8619-06ad6baed98d", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", 5, null },
                    { "74298b63-d4fb-44a5-8d52-cfce38689f06", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", 5, null },
                    { "7bcc094f-2126-4078-8ec5-8630609ff994", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", 5, null },
                    { "7f8779f1-dbf8-4d91-83d4-7533149a8ed8", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", 5, null },
                    { "810c3beb-4cf0-4e5e-a129-729b67b68dc1", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", 5, null },
                    { "954a5acb-362c-4e70-8601-24129f2dffe5", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", 5, null },
                    { "9df5ea0a-a4c0-4d58-8856-b9f4735a7197", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", 5, null }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "AccountId", "ContractCharacterId", "CreateDate", "Description", "EndDate", "EventCharacterId", "IsActive", "IsValidate", "Location", "StartDate", "Status", "TaskName", "Type", "UpdateDate" },
                values: new object[,]
                {
                    { "T013", "A013", "CC0021", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8200), "Contract cosplay event", new DateTime(2025, 7, 2, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8200), null, true, true, "Ho Chi Minh city", new DateTime(2025, 7, 1, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8198), 3, "CH012", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8202) },
                    { "T014", "A011", "CC0051", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8208), "Contract cosplay photoshoot", new DateTime(2025, 7, 4, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8207), null, true, true, "Ho Chi Minh city", new DateTime(2025, 7, 3, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8206), 3, "CH013", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8208) },
                    { "T015", "A012", "CC0081", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8219), "Contract character performance", new DateTime(2025, 7, 6, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8213), null, true, true, "Ho Chi Minh city", new DateTime(2025, 7, 5, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8212), 2, "CH014", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8220) },
                    { "T016", "A013", "CC0101", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8226), "Contract parade participation", new DateTime(2025, 7, 8, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8225), null, true, true, "Ho Chi Minh city", new DateTime(2025, 7, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8224), 3, "CH015", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8226) },
                    { "T017", "A014", "CC0141", new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8231), "Contract cosplay workshop", new DateTime(2025, 7, 10, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8231), null, true, true, "Ho Chi Minh city", new DateTime(2025, 7, 9, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8230), 0, "CH015", null, new DateTime(2025, 6, 7, 13, 59, 53, 801, DateTimeKind.Local).AddTicks(8232) }
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
                name: "IX_Event_LocationId",
                table: "Event",
                column: "LocationId");

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
                name: "AccountCoupon");

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
                name: "Coupon");

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
                name: "location");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
