using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CCSS_Repository.Migrations
{
    /// <inheritdoc />
    public partial class dbinit : Migration
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
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
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
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CraeteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    { "ACT001", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8684), "A relaxing yoga session", "Yoga Class", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8685) },
                    { "ACT002", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8688), "Learn to cook delicious meals", "Cooking Workshop", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8688) },
                    { "ACT003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8692), "Live music performance", "Music Concert", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8693) },
                    { "ACT004", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8695), "Showcase of local artists", "Art Exhibition", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8695) },
                    { "ACT005", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8698), "Discussion on latest technology trends", "Tech Talk", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8698) },
                    { "ACT006", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8701), "5K run for a good cause", "Charity Run", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8701) },
                    { "ACT007", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8703), "Monthly book discussion", "Book Club", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8704) },
                    { "ACT008", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8706), "Learn photography skills", "Photography Workshop", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8706) },
                    { "ACT009", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8708), "Dance battle for all ages", "Dance Competition", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8709) },
                    { "ACT010", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8711), "Competitive chess matches", "Chess Tournament", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8713) },
                    { "ACT011", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8719), "Outdoor movie screening", "Movie Night", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8720) },
                    { "ACT012", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8724), "Showcase of scientific projects", "Science Fair", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8724) },
                    { "ACT013", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8727), "Intensive coding workshop", "Coding Bootcamp", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8727) },
                    { "ACT014", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8729), "Learn gardening techniques", "Gardening Workshop", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8730) },
                    { "ACT015", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8732), "Guided meditation practice", "Meditation Session", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8732) }
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
                columns: new[] { "CouponId", "Amount", "Condition", "EndDate", "Percent", "StartDate", "Type" },
                values: new object[,]
                {
                    { "CP001", 50000.0, "Min order 500", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP002", 150000.0, "Min order 1000", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP003", 400000.0, "Min contract 2000", new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP004", 180000.0, "Min order 1500", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 12f, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP005", 750000.0, "Min contract 3000", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP006", 100000.0, "New customers only", new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP007", 200000.0, "Holiday Special", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP008", 600000.0, "VIP customers", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP009", 120000.0, "Summer Sale", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP010", 1000000.0, "Black Friday", new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP011", 75000.0, "Back to School", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP012", 1750000.0, "Min contract 5000", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP013", 250000.0, "Loyal Customers", new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP014", 800000.0, "Cyber Monday", new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP015", 50000.0, "Referral Bonus", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "CreateBy", "CreateDate", "Description", "EndDate", "EventName", "IsActive", "Location", "StartDate", "UpdateDate" },
                values: new object[,]
                {
                    { "E001", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7162), "A grand celebration to welcome the new year", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Year Festival", true, "Times Square, New York", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E002", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7167), "Experience the beauty of cherry blossoms", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring Blossom Fest", true, "Kyoto, Japan", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E003", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7170), "Showcasing the latest in technology and AI", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Innovation Summit", true, "Silicon Valley", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E004", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7173), "Live performances from top artists", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music Fest", true, "Coachella, California", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E005", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7178), "A must-attend event for comic book fans", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comic-Con International", true, "San Diego Convention Center", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E006", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7208), "Largest anime convention in the world", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anime Expo", true, "Los Angeles Convention Center", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E007", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7211), "Latest trends and releases in gaming", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Expo", true, "Las Vegas Convention Center", new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E008", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7214), "A fun-filled summer celebration", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Festival", true, "Miami Beach, Florida", new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E009", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7217), "A paradise for cosplayers", new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosplay Festival", true, "Tokyo Big Sight", new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E010", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7220), "Showcasing the best movies of the year", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Festival", true, "Cannes, France", new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E011", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7223), "Spooky celebrations and costume parties", new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween Night", true, "Salem, Massachusetts", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E012", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7227), "Festive shopping and holiday cheer", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Market", true, "Nuremberg, Germany", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
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
                columns: new[] { "ProductId", "CreateDate", "Description", "IsActive", "Price", "ProductName", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { "P001", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7000), "A wig for Naruto cosplay", true, 30000.0, "Naruto Wig", 10, null },
                    { "P002", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7004), "A hat for Mario cosplay", true, 20000.0, "Mario Hat", 15, null },
                    { "P003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7007), "Complete costume for Sasuke cosplay", true, 80000.0, "Sasuke Costume", 5, null },
                    { "P004", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7011), "Replica sword from The Legend of Zelda", true, 100000.0, "Zelda Sword", 7, null },
                    { "P005", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7014), "Iconic straw hat from One Piece", true, 25000.0, "One Piece Straw Hat", 20, null },
                    { "P006", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7017), "Hatsune Miku blue twin-tail wig", true, 40000.0, "Miku Wig", 12, null },
                    { "P007", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7019), "Tanjiro's iconic hanafuda earrings", true, 15000.0, "Demon Slayer Earrings", 30, null },
                    { "P008", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7022), "Survey Corps uniform jacket", true, 50000.0, "Attack on Titan Jacket", 10, null },
                    { "P009", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7025), "Cozy Pikachu-themed onesie", true, 60000.0, "Pikachu Onesie", 8, null },
                    { "P010", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7027), "Final Fantasy VII replica sword", true, 120000.0, "Cloud's Buster Sword", 4, null },
                    { "P011", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7030), "LED Vision accessory from Genshin Impact", true, 35000.0, "Genshin Impact Vision", 25, null },
                    { "P012", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7034), "Jinx cosplay wig from Arcane", true, 45000.0, "Jinx Wig", 6, null },
                    { "P013", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7037), "Golden tiara from Sailor Moon", true, 18000.0, "Sailor Moon Tiara", 15, null },
                    { "P014", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7039), "High-quality Spider-Man suit", true, 90000.0, "Spider-Man Suit", 3, null },
                    { "P015", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7042), "Replica wand from Harry Potter series", true, 22000.0, "Harry Potter Wand", 50, null }
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
                    { "S001", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6956), "Rent characters for events and parties", "Character Rental", null },
                    { "S002", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6962), "Live cosplay performances at events", "Cosplay Rental", null },
                    { "S003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6963), "Professional photoshoot with cosplayers", "Create event", null }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AverageStar", "Birthday", "Code", "Description", "Email", "GoogleId", "Height", "IsActive", "Leader", "Name", "OnTask", "Password", "Phone", "RoleId", "SalaryIndex", "TaskQuantity", "UserName", "Weight" },
                values: new object[,]
                {
                    { "A001", 4.5, null, null, null, "john@example.com", null, 180f, true, null, "John Doe", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 45000.0, null, null, 75f },
                    { "A002", null, null, null, null, "jane@example.com", null, null, true, null, "Jane Smith", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R001", null, null, null, null },
                    { "A003", null, null, null, null, "phuongnam26012002@gmail.com", null, null, true, null, "Nammmmmmmm", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A004", 4.2000000000000002, null, null, null, "bob@example.com", null, 175f, true, null, "Bob Brown", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 42000.0, null, null, 80f },
                    { "A005", 3.5, null, null, null, "charlie@example.com", null, 182f, true, null, "Charlie White", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 35000.0, null, null, 78f },
                    { "A006", null, null, null, null, "david@example.com", null, null, true, null, "David Black", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A007", 4.0999999999999996, null, null, null, "emma@example.com", null, 168f, true, null, "Emma Green", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 41000.0, null, null, 60f },
                    { "A008", 4.5999999999999996, null, null, null, "frank@example.com", null, 185f, true, null, "Frank Blue", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 46000.0, null, null, 85f },
                    { "A009", null, null, null, null, "grace@example.com", null, null, true, null, "Grace Pink", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R001", null, null, null, null },
                    { "A010", 2.5, null, null, null, "henry@example.com", null, 178f, true, null, "Henry Purple", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 25000.0, null, null, 77f },
                    { "A011", null, null, null, null, "isla@example.com", null, null, true, null, "Isla Red", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A012", 3.7999999999999998, null, null, null, "jack@example.com", null, 172f, true, null, "Jack Yellow", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 38000.0, null, null, 70f },
                    { "A013", 2.5, null, null, null, "katie@example.com", null, 165f, true, null, "Katie Orange", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 25000.0, null, null, 55f },
                    { "A014", null, null, null, null, "liam@example.com", null, null, true, null, "Liam Gray", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A015", 1.5, null, null, null, "mia@example.com", null, 170f, true, null, "Mia Cyan", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 15000.0, null, null, 65f },
                    { "A016", 3.7000000000000002, null, null, null, "noah@example.com", null, 175f, true, null, "Noah Silver", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 37000.0, null, null, 70f },
                    { "A017", 4.7999999999999998, null, null, null, "olivia@example.com", null, 168f, true, null, "Olivia Gold", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 48000.0, null, null, 55f },
                    { "A018", 3.2000000000000002, null, null, null, "william@example.com", null, 180f, true, null, "William Amber", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 32000.0, null, null, 75f },
                    { "A019", 3.2999999999999998, null, null, null, "sophia@example.com", null, 165f, true, null, "Sophia Ivory", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 33000.0, null, null, 50f },
                    { "A020", 3.3999999999999999, null, null, null, "james@example.com", null, 178f, true, null, "James Navy", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 34000.0, null, null, 72f },
                    { "A021", 3.5, null, null, null, "ava@example.com", null, 162f, true, null, "Ava Teal", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 35000.0, null, null, 48f },
                    { "A022", 3.6000000000000001, null, null, null, "benjamin@example.com", null, 177f, true, null, "Benjamin Lime", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 36000.0, null, null, 70f },
                    { "A023", 3.7000000000000002, null, null, null, "charlotte@example.com", null, 164f, true, null, "Charlotte Beige", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 37000.0, null, null, 52f },
                    { "A024", 3.7999999999999998, null, null, null, "lucas@example.com", null, 180f, true, null, "Lucas Maroon", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 38000.0, null, null, 74f },
                    { "A025", 3.8999999999999999, null, null, null, "mia@example.com", null, 159f, true, null, "Mia Pearl", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 39000.0, null, null, 47f },
                    { "A026", 2.5, null, null, null, "ethan@example.com", null, 176f, true, null, "Ethan Olive", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 25000.0, null, null, 71f },
                    { "A027", 2.6000000000000001, null, null, null, "amelia@example.com", null, 167f, true, null, "Amelia Ruby", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 26000.0, null, null, 53f },
                    { "A028", 2.7000000000000002, null, null, null, "henry@example.com", null, 182f, true, null, "Henry Saffron", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 27000.0, null, null, 76f },
                    { "A029", 2.7999999999999998, null, null, null, "ella@example.com", null, 160f, true, null, "Ella Coral", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 28000.0, null, null, 49f },
                    { "A030", 2.8999999999999999, null, null, null, "daniel@example.com", null, 175f, true, null, "Daniel Cyan", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 29000.0, null, null, 72f },
                    { "A031", 3.0, null, null, null, "logan@example.com", null, 180f, true, null, "Logan Indigo", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 30000.0, null, null, 73f },
                    { "A032", 4.0, null, null, null, "lily@example.com", null, 165f, true, null, "Lily Violet", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 40000.0, null, null, 52f },
                    { "A033", 4.0999999999999996, null, null, null, "mason@example.com", null, 178f, true, null, "Mason Turquoise", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 41000.0, null, null, 74f },
                    { "A034", 4.2000000000000002, null, null, null, "zoe@example.com", null, 160f, true, null, "Zoe Lavender", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 42000.0, null, null, 48f },
                    { "A035", 4.2999999999999998, null, null, null, "elijah@example.com", null, 182f, true, null, "Elijah Crimson", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 43000.0, null, null, 77f },
                    { "A036", 4.4000000000000004, null, null, null, "aria@example.com", null, 164f, true, null, "Aria Mint", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 44000.0, null, null, 50f },
                    { "A037", 4.5, null, null, null, "sebastian@example.com", null, 179f, true, null, "Sebastian Bronze", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 45000.0, null, null, 72f },
                    { "A038", 4.5999999999999996, null, null, null, "harper@example.com", null, 168f, true, null, "Harper Rose", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 46000.0, null, null, 53f },
                    { "A039", 4.7000000000000002, null, null, null, "caleb@example.com", null, 181f, true, null, "Caleb Onyx", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 47000.0, null, null, 75f },
                    { "A040", 4.7999999999999998, null, null, null, "scarlett@example.com", null, 162f, true, null, "Scarlett Magenta", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 48000.0, null, null, 51f }
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "CategoryId", "CharacterName", "CreateDate", "Description", "IsActive", "MaxHeight", "MaxWeight", "MinHeight", "MinWeight", "Price", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { "CH001", "C3", "Naruto", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6831), "Ninja from Konoha", true, 180f, 80f, 160f, 50f, 100000.0, 5, null },
                    { "CH002", "C3", "Sasuke", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6838), "Naruto’s rival", true, 185f, 85f, 165f, 55f, 120000.0, 3, null },
                    { "CH003", "C3", "Goku", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6844), "Saiyan warrior", true, 190f, 90f, 170f, 60f, 150000.0, 4, null },
                    { "CH004", "C4", "Luffy", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6848), "Pirate King", true, 175f, 70f, 155f, 45f, 110000.0, 6, null },
                    { "CH005", "C4", "Ichigo", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6852), "Soul Reaper", true, 185f, 85f, 165f, 55f, 130000.0, 3, null },
                    { "CH006", "C14", "Mario", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6856), "Plumber hero", true, 160f, 70f, 140f, 50f, 80000.0, 5, null },
                    { "CH007", "C14", "Luigi", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6860), "Mario’s brother", true, 170f, 75f, 150f, 55f, 85000.0, 4, null },
                    { "CH008", "C14", "Link", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6863), "Hero of Hyrule", true, 180f, 80f, 160f, 50f, 140000.0, 2, null },
                    { "CH009", "C16", "Zelda", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6867), "Hyrule princess", true, 175f, 70f, 155f, 50f, 135000.0, 3, null },
                    { "CH010", "C16", "Samus", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6872), "Bounty hunter", true, 185f, 85f, 165f, 55f, 145000.0, 3, null },
                    { "CH011", "C13", "Cloud", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6877), "Ex-SOLDIER", true, 185f, 85f, 165f, 55f, 125000.0, 3, null },
                    { "CH012", "C13", "Sephiroth", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6881), "One-Winged Angel", true, 190f, 90f, 170f, 60f, 155000.0, 2, null },
                    { "CH013", "C8", "Kratos", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6885), "God of War", true, 195f, 100f, 175f, 70f, 160000.0, 2, null },
                    { "CH014", "C8", "Pikachu", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6888), "Electric Pokemon", true, 50f, 20f, 30f, 10f, 90000.0, 10, null },
                    { "CH015", "C8", "Kirby", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(6892), "Pink puffball", true, 60f, 25f, 40f, 15f, 95000.0, 8, null }
                });

            migrationBuilder.InsertData(
                table: "EventActivity",
                columns: new[] { "EventActivityId", "ActivityId", "CreateBy", "CreateDate", "Description", "EventId", "UpdateDate" },
                values: new object[,]
                {
                    { "EA001", "ACT001", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8457), "Yoga for a fresh start", "E001", null },
                    { "EA002", "ACT005", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8461), "Tech trends in the new year", "E001", null },
                    { "EA003", "ACT004", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8463), "Painting cherry blossoms", "E002", null },
                    { "EA004", "ACT013", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8466), "AI and future coding", "E003", null },
                    { "EA005", "ACT009", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8468), "Dance battles live", "E004", null },
                    { "EA006", "ACT003", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8469), "Comic-Con live music", "E005", null },
                    { "EA007", "ACT007", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8472), "Anime and book discussions", "E006", null },
                    { "EA008", "ACT010", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8475), "Chess and gaming", "E007", null },
                    { "EA009", "ACT011", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8482), "Outdoor movie fun", "E008", null },
                    { "EA010", "ACT015", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8484), "Meditation for cosplayers", "E009", null },
                    { "EA011", "ACT012", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8485), "Science in filmmaking", "E010", null },
                    { "EA012", "ACT006", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8487), "Halloween charity run", "E011", null },
                    { "EA013", "ACT014", "Admin", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8489), "Christmas gardening", "E012", null },
                    { "EA014", "ACT002", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8491), "Cooking for music lovers", "E004", null },
                    { "EA015", "ACT008", "Manager", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8492), "Photography in tech", "E003", null }
                });

            migrationBuilder.InsertData(
                table: "EventImage",
                columns: new[] { "ImageId", "CreateDate", "EventId", "ImageUrl", "IsAvatar", "UpdateDate" },
                values: new object[,]
                {
                    { "EI001", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8942), "E001", "https://example.com/event1.jpg", null, null },
                    { "EI002", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8971), "E002", "https://example.com/event2.jpg", null, null },
                    { "EI003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8973), "E003", "https://example.com/event3.jpg", null, null },
                    { "EI004", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8975), "E004", "https://example.com/event4.jpg", null, null },
                    { "EI005", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8980), "E005", "https://example.com/event5.jpg", null, null },
                    { "EI006", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8982), "E006", "https://example.com/event6.jpg", null, null },
                    { "EI007", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8984), "E007", "https://example.com/event7.jpg", null, null },
                    { "EI008", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8986), "E008", "https://example.com/event8.jpg", null, null },
                    { "EI009", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8988), "E009", "https://example.com/event9.jpg", null, null },
                    { "EI010", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8990), "E010", "https://example.com/event10.jpg", null, null },
                    { "EI011", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8992), "E011", "https://example.com/event11.jpg", null, null },
                    { "EI012", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8994), "E012", "https://example.com/event12.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "ProductImageId", "CreateDate", "IsAvatar", "ProductId", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "IMG001", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9245), null, "P001", null, "https://example.com/images/naruto_wig.jpg" },
                    { "IMG002", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9247), null, "P002", null, "https://example.com/images/mario_hat.jpg" },
                    { "IMG003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9249), null, "P003", null, "https://example.com/images/sasuke_costume.jpg" },
                    { "IMG004", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9251), null, "P004", null, "https://example.com/images/zelda_sword.jpg" },
                    { "IMG005", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9290), null, "P005", null, "https://example.com/images/one_piece_hat.jpg" },
                    { "IMG006", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9294), null, "P006", null, "https://example.com/images/miku_wig.jpg" },
                    { "IMG007", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9295), null, "P007", null, "https://example.com/images/demon_slayer_earrings.jpg" },
                    { "IMG008", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9297), null, "P008", null, "https://example.com/images/aot_jacket.jpg" },
                    { "IMG009", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9299), null, "P009", null, "https://example.com/images/pikachu_onesie.jpg" },
                    { "IMG010", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9301), null, "P010", null, "https://example.com/images/buster_sword.jpg" },
                    { "IMG011", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9302), null, "P011", null, "https://example.com/images/genshin_vision.jpg" },
                    { "IMG012", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9304), null, "P012", null, "https://example.com/images/jinx_wig.jpg" },
                    { "IMG013", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9306), null, "P013", null, "https://example.com/images/sailor_moon_tiara.jpg" },
                    { "IMG014", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9310), null, "P014", null, "https://example.com/images/spiderman_suit.jpg" },
                    { "IMG015", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9312), null, "P015", null, "https://example.com/images/harry_potter_wand.jpg" }
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
                    { "AI1", "A001", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8620), null, null, "https://example.com/admin.jpg" },
                    { "AI10", "A010", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8642), null, null, "https://example.com/user8.jpg" },
                    { "AI11", "A011", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8644), null, null, "https://example.com/user9.jpg" },
                    { "AI12", "A012", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8646), null, null, "https://example.com/user10.jpg" },
                    { "AI13", "A013", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8648), null, null, "https://example.com/user11.jpg" },
                    { "AI14", "A014", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8650), null, null, "https://example.com/user12.jpg" },
                    { "AI15", "A015", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8652), null, null, "https://example.com/user13.jpg" },
                    { "AI2", "A002", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8624), null, null, "https://example.com/manager.jpg" },
                    { "AI3", "A003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8626), null, null, "https://example.com/user1.jpg" },
                    { "AI4", "A004", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8628), null, null, "https://example.com/user2.jpg" },
                    { "AI5", "A005", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8630), null, null, "https://example.com/user3.jpg" },
                    { "AI6", "A006", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8632), null, null, "https://example.com/user4.jpg" },
                    { "AI7", "A007", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8634), null, null, "https://example.com/user5.jpg" },
                    { "AI8", "A008", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8636), null, null, "https://example.com/user6.jpg" },
                    { "AI9", "A009", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8639), null, null, "https://example.com/user7.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "AccountId", "CreateDate", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "C001", "A003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7911), 0.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7912) },
                    { "C002", "A006", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7914), 0.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7915) },
                    { "C003", "A011", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7917), 0.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7917) },
                    { "C004", "A014", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7919), 0.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7920) }
                });

            migrationBuilder.InsertData(
                table: "CharacterImage",
                columns: new[] { "CharacterImageId", "CharacterId", "CreateDate", "IsAvatar", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "CI001", "CH001", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8879), null, null, "https://example.com/img1.jpg" },
                    { "CI002", "CH002", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8882), null, null, "https://example.com/img2.jpg" },
                    { "CI003", "CH003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8884), null, null, "https://example.com/img3.jpg" },
                    { "CI004", "CH004", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8888), null, null, "https://example.com/img4.jpg" },
                    { "CI005", "CH005", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8890), null, null, "https://example.com/img5.jpg" },
                    { "CI006", "CH006", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8892), null, null, "https://example.com/img6.jpg" },
                    { "CI007", "CH007", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8894), null, null, "https://example.com/img7.jpg" },
                    { "CI008", "CH008", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8896), null, null, "https://example.com/img8.jpg" },
                    { "CI009", "CH009", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8898), null, null, "https://example.com/img9.jpg" },
                    { "CI010", "CH010", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8900), null, null, "https://example.com/img10.jpg" },
                    { "CI011", "CH011", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8902), null, null, "https://example.com/img11.jpg" },
                    { "CI012", "CH012", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8906), null, null, "https://example.com/img12.jpg" },
                    { "CI013", "CH013", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8908), null, null, "https://example.com/img13.jpg" },
                    { "CI014", "CH014", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8910), null, null, "https://example.com/img14.jpg" },
                    { "CI015", "CH015", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8911), null, null, "https://example.com/img15.jpg" }
                });

            migrationBuilder.InsertData(
                table: "EventCharacter",
                columns: new[] { "EventCharacterId", "CharacterId", "CreateDate", "Description", "EventId", "IsAssign", "UpdateDate" },
                values: new object[,]
                {
                    { "EC001", "CH001", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8366), null, "E001", true, null },
                    { "EC002", "CH002", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8369), null, "E002", true, null },
                    { "EC003", "CH003", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8371), null, "E003", true, null },
                    { "EC004", "CH004", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8375), null, "E004", true, null },
                    { "EC005", "CH005", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8377), null, "E005", true, null },
                    { "EC006", "CH006", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8410), null, "E006", true, null },
                    { "EC007", "CH007", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8414), null, "E007", true, null },
                    { "EC008", "CH008", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8417), null, "E008", true, null },
                    { "EC009", "CH009", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8419), null, "E009", true, null },
                    { "EC010", "CH010", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8421), null, "E010", true, null },
                    { "EC011", "CH011", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8423), null, "E011", true, null },
                    { "EC012", "CH012", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8427), null, "E012", true, null }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "AccountId", "CreatedAt", "IsRead", "IsSentMail", "Message" },
                values: new object[,]
                {
                    { "N001", "A001", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7844), false, true, "Welcome to the system!" },
                    { "N002", "A002", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7847), false, true, "Your account has been upgraded." },
                    { "N003", "A003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7849), true, true, "New promotional offer available!" },
                    { "N004", "A004", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7851), false, true, "Your request has been approved." },
                    { "N005", "A005", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7853), true, true, "System maintenance scheduled." },
                    { "N006", "A006", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7855), false, true, "Your order has been shipped!" },
                    { "N007", "A007", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7857), false, true, "New event registration open." },
                    { "N008", "A008", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7863), true, true, "Reminder: Payment due soon." },
                    { "N009", "A009", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7865), false, true, "Your password was changed." },
                    { "N010", "A010", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7867), false, true, "Admin announcement update." },
                    { "N011", "A011", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7869), true, true, "New message from support." },
                    { "N012", "A012", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7871), false, true, "Upcoming event invitation." },
                    { "N013", "A013", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7873), false, true, "New cosplayer contest." },
                    { "N014", "A014", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7876), true, true, "Loyalty points updated." },
                    { "N015", "A015", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(7878), false, true, "Your subscription expired." }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "AccountId", "OrderDate", "OrderStatus", "TotalPrice" },
                values: new object[,]
                {
                    { "O001", "A003", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 250000.0 },
                    { "O002", "A006", new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 150000.5 },
                    { "O003", "A011", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 300000.0 },
                    { "O004", "A014", new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 400000.0 },
                    { "O005", "A003", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 175000.0 },
                    { "O006", "A006", new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 225000.0 },
                    { "O007", "A011", new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 350000.0 },
                    { "O008", "A014", new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 275000.0 },
                    { "O009", "A003", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 500000.0 },
                    { "O010", "A006", new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 125000.0 },
                    { "O011", "A011", new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 325000.0 },
                    { "O012", "A014", new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 410000.0 },
                    { "O013", "A003", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 280000.0 },
                    { "O014", "A006", new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 350000.0 },
                    { "O015", "A011", new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200000.0 }
                });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "RequestId", "AccountCouponId", "AccountId", "CreatedDate", "Deposit", "Description", "EndDate", "Location", "Name", "PackageId", "Price", "Reason", "ServiceId", "StartDate", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { "R001", null, "A001", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(7941), null, "RentCostumes", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Naruto Costume", "PKG001", 100000.0, null, "S001", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R002", null, "A002", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(7968), null, "RentCosplayer", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ĐN", "Rent Cosplayer for Event", null, 500000.0, "Cosplayer is busy", "S002", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R003", null, "A003", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(7973), null, "CreateEvent", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "BD", "Create Anime Festival", null, 2000000.0, null, "S003", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R004", null, "A004", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(7976), null, "RentCostumes", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Rent Samurai Armor", null, 150000.0, null, "S002", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R005", null, "A005", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(7982), null, "RentCosplayer", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "BT", "Hire Professional Cosplayer", "PKG002", 700000.0, null, "S002", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R006", null, "A006", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(7987), null, "CreateEvent", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Organize Comic Convention", null, 5000000.0, null, "S001", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R007", null, "A007", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(7990), null, "RentCostumes", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Victorian Costume", null, 120000.0, "Cosplayer is busy", "S002", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R008", null, "A008", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(7994), null, "RentCosplayer", new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "QN", "Book Cosplayer for Birthday Party", null, 350000.0, null, "S003", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R009", null, "A009", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8033), null, "CreateEvent", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CM", "Plan Fantasy Fair", null, 3000000.0, null, "S003", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R010", null, "A010", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8038), null, "RentCostumes", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "LĐ", "Rent Halloween Costumes", null, 200000.0, null, "S001", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R011", null, "A011", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8041), null, "RentCosplayer", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "NT", "Hire Cosplayer for Wedding", "PKG010", 800000.0, null, "S001", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R012", null, "A012", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8045), null, "CreateEvent", new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "VT", "Create Sci-Fi Convention", null, 4500000.0, null, "S002", new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { "R013", null, "A013", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8051), null, "RentCostumes", new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Santa Claus Costume", null, 130000.0, null, "S003", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null },
                    { "R014", null, "A014", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8055), null, "RentCosplayer", new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Book Cosplayer for Product Launch", null, 600000.0, null, "S001", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null },
                    { "R015", null, "A015", new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8058), null, "CreateEvent", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Host Christmas Event", "PKG015", 5500000.0, null, "S002", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null }
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
                    { "0478ef76-e0d6-4d99-a993-d5a4cfa05977", "C001", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8806), 80000.0, "P003", 1 },
                    { "337f7b8e-5503-465e-af9c-5bfd805e728f", "C003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8828), 50000.0, "P008", 2 },
                    { "39ba5f84-0c86-4f41-b2fb-921e4d753b37", "C002", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8811), 100000.0, "P004", 1 },
                    { "55324675-152a-4591-8845-d1b7f2610fea", "C001", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8803), 20000.0, "P002", 1 },
                    { "6210f8df-a6de-43c4-83dc-fa217a1067a7", "C001", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8795), 30000.0, "P001", 2 },
                    { "6225009b-c9c3-4e8d-9e81-29c0b4fe441f", "C004", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8844), 45000.0, "P012", 1 },
                    { "67d42c9f-f867-4ad0-9d8e-295e2c9fcda9", "C004", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8841), 35000.0, "P011", 2 },
                    { "6ea00f5b-7369-4b41-9528-116cc9e0aab8", "C003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8831), 60000.0, "P009", 1 },
                    { "9e949848-1f95-4d89-8918-3cf90068d717", "C002", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8820), 40000.0, "P006", 2 },
                    { "a3e03258-adbc-40a9-a1e7-840ed5239069", "C004", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8837), 120000.0, "P010", 1 },
                    { "c61bb176-9838-489f-bfe8-414690471337", "C003", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8824), 15000.0, "P007", 5 },
                    { "f4b8b1d2-dc73-405a-96d5-225b486e886e", "C002", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(8815), 25000.0, "P005", 3 }
                });

            migrationBuilder.InsertData(
                table: "Contract",
                columns: new[] { "ContractId", "Amount", "ContractName", "ContractStatus", "CreateBy", "CreateDate", "DeliveryStatus", "Deposit", "Reason", "RequestId", "TotalPrice", "UrlPdf" },
                values: new object[,]
                {
                    { "CT002", 0.0, "Character rental", 1, "Admin", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "100", null, "R002", 500000.0, null },
                    { "CT005", 350000.0, "Character rental", 1, "Admin", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "50", null, "R005", 700000.0, null },
                    { "CT008", 175000.0, "Character rental", 1, "Admin", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "50", null, "R008", 350000.0, null },
                    { "CT010", 100000.0, "Character rental", 5, "Admin", new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "50", null, "R010", 200000.0, null },
                    { "CT014", 0.0, "Character rental", 1, "Admin", new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "100", null, "R014", 600000.0, null }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "1cc3296a-4618-4357-a641-e044b96d7aba", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9042), "O003", 40000.0, "P006", 3 },
                    { "1e5de41d-3571-4dda-83e4-c3d26762a51c", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9081), "O009", 20000.0, "P002", 6 },
                    { "1eec9cde-0e01-4e16-9c75-21c27ffdd067", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9140), "O014", 18000.0, "P013", 5 },
                    { "1f8b05e6-f54b-4d9e-867d-329f0acb45fc", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9039), "O003", 25000.0, "P005", 2 },
                    { "234ac410-da29-4dc0-94f9-e249c87aecf2", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9147), "O015", 22000.0, "P015", 4 },
                    { "322fe32d-79fe-46f0-8a8e-9eedaeff5fe2", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9030), "O002", 80000.0, "P003", 1 },
                    { "32f49069-b061-4de9-bc8b-936db2cacee9", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9084), "O009", 80000.0, "P003", 2 },
                    { "3334f1f9-26e0-434a-8364-51a34c864ec9", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9059), "O006", 35000.0, "P011", 2 },
                    { "3ab0450b-0325-4101-9431-1e6a880e453b", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9135), "O013", 35000.0, "P011", 2 },
                    { "44cd8db0-ea03-4f33-b5cc-db55fa9bafc7", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9026), "O001", 20000.0, "P002", 5 },
                    { "4be48e07-02f2-4aed-9f4f-01f616e061bb", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9045), "O004", 15000.0, "P007", 4 },
                    { "4f8ecff8-39e7-4705-b0b7-1fe3d1eee197", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9067), "O007", 18000.0, "P013", 5 },
                    { "58399f06-12be-474b-885e-95a2b3629e8a", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9053), "O005", 60000.0, "P009", 1 },
                    { "5bf991ae-9997-442b-969d-dca4da862388", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9123), "O011", 15000.0, "P007", 4 },
                    { "5d2d1d3c-2449-4c73-9713-2193b4c623ab", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9063), "O006", 45000.0, "P012", 3 },
                    { "627c957b-f555-4401-8e8c-193e6b9cb369", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9090), "O010", 25000.0, "P005", 3 },
                    { "7ab71283-dda9-4bff-93ed-8924ecb7ab47", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9087), "O010", 100000.0, "P004", 1 },
                    { "80626037-a915-4b54-9c49-422f4cbe8484", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9144), "O015", 90000.0, "P014", 2 },
                    { "9efd596d-4147-41a6-8cba-e3010f83d096", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9120), "O011", 40000.0, "P006", 2 },
                    { "9f501775-5b99-41bb-8f32-14e04ee21234", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9137), "O014", 45000.0, "P012", 3 },
                    { "ab38a42d-403d-41eb-882e-eedb0c4fffc1", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9126), "O012", 50000.0, "P008", 2 },
                    { "aed5c499-8ee9-4b7b-be22-b76cc2d00a66", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9132), "O013", 120000.0, "P010", 1 },
                    { "b0b4fbc7-02b4-4ea8-9e82-47c53fb93076", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9073), "O008", 22000.0, "P015", 4 },
                    { "b7b62373-0a41-46e8-b2f8-138c3a4c26e0", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9049), "O004", 50000.0, "P008", 2 },
                    { "b8d3b2a3-2307-489a-930d-a8784a39dc0b", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9128), "O012", 60000.0, "P009", 1 },
                    { "bd6fb81d-43d8-439d-8233-41faaef44df1", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9056), "O005", 120000.0, "P010", 1 },
                    { "e3f5dedd-e07c-49b7-8a57-b28ecb920c77", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9076), "O008", 30000.0, "P001", 1 },
                    { "e671b029-9609-4667-ad70-0add0675a9bd", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9022), "O001", 30000.0, "P001", 3 },
                    { "f5192e85-92b5-42e4-af67-959917c470b4", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9070), "O007", 90000.0, "P014", 2 },
                    { "f7a1f135-3169-4bba-9af6-b73e1a9c9f96", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9033), "O002", 100000.0, "P004", 1 }
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
                    { "RC01", "CH001", "A025", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9349), "Yêu cầu cosplay nhân vật CH001", 1, null, "R001", null, 50000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9349) },
                    { "RC02", "CH002", "A026", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9353), "Yêu cầu cosplay nhân vật CH002", 1, null, "R002", null, 60000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9354) },
                    { "RC03", "CH003", "A027", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9357), "Yêu cầu cosplay nhân vật CH003", 1, null, "R003", null, 70000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9358) },
                    { "RC04", "CH004", "A028", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9360), "Yêu cầu cosplay nhân vật CH004", 1, null, "R004", null, 80000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9361) },
                    { "RC05", "CH005", "A029", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9363), "Yêu cầu cosplay nhân vật CH005", 1, null, "R005", null, 90000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9364) },
                    { "RC06", "CH006", null, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9366), "Yêu cầu cosplay nhân vật CH006", 5, null, "R006", null, 100000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9366) },
                    { "RC07", "CH007", "A031", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9370), "Yêu cầu cosplay nhân vật CH007", 1, null, "R007", null, 110000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9371) },
                    { "RC08", "CH008", null, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9375), "Yêu cầu cosplay nhân vật CH008", 7, null, "R008", null, 120000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9376) },
                    { "RC09", "CH009", "A033", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9380), "Yêu cầu cosplay nhân vật CH009", 1, null, "R009", null, 130000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9381) },
                    { "RC10", "CH010", null, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9383), "Yêu cầu cosplay nhân vật CH010", 9, null, "R010", null, 140000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9384) },
                    { "RC11", "CH011", "A035", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9386), "Yêu cầu cosplay nhân vật CH011", 1, null, "R011", null, 150000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9386) },
                    { "RC12", "CH012", "A036", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9389), "Yêu cầu cosplay nhân vật CH012", 1, null, "R012", null, 160000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9391) },
                    { "RC13", "CH013", null, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9394), "Yêu cầu cosplay nhân vật CH013", 10, null, "R013", null, 170000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9394) },
                    { "RC14", "CH014", "A038", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9397), "Yêu cầu cosplay nhân vật CH014", 1, null, "R014", null, 180000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9398) },
                    { "RC15", "CH015", "A039", new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9401), "Yêu cầu cosplay nhân vật CH015", 1, null, "R015", null, 190000.0, new DateTime(2025, 4, 15, 18, 35, 30, 925, DateTimeKind.Utc).AddTicks(9402) }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "AccountId", "ContractCharacterId", "CreateDate", "Description", "EndDate", "EventCharacterId", "IsActive", "Location", "StartDate", "Status", "TaskName", "Type", "UpdateDate" },
                values: new object[,]
                {
                    { "T001", "A001", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8109), "Cosplay as anime characters", new DateTime(2025, 4, 19, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8108), "EC001", true, "Tokyo", new DateTime(2025, 4, 18, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8101), 0, "CH001", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8109) },
                    { "T002", "A004", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8116), "Join cosplay contest", new DateTime(2025, 4, 21, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8115), "EC002", true, "Los Angeles", new DateTime(2025, 4, 20, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8115), 1, "CH002", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8117) },
                    { "T003", "A005", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8122), "Teach costume making", new DateTime(2025, 4, 23, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8120), "EC003", true, "New York", new DateTime(2025, 4, 22, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8120), 2, "CH003", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8122) },
                    { "T004", "A007", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8126), "Host a live event", new DateTime(2025, 4, 17, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8126), "EC004", true, "Online", new DateTime(2025, 4, 17, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8125), 3, "CH004", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8127) },
                    { "T005", "A008", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8131), "Professional cosplay photoshoot", new DateTime(2025, 4, 25, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8130), "EC005", true, "Paris", new DateTime(2025, 4, 24, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8130), 0, "CH005", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8132) },
                    { "T006", "A010", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8137), "Evaluate contestants", new DateTime(2025, 4, 27, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8137), "EC006", true, "Berlin", new DateTime(2025, 4, 26, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8136), 1, "CH006", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8138) },
                    { "T007", "A012", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8142), "Walk in parade", new DateTime(2025, 4, 29, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8141), "EC007", true, "Seoul", new DateTime(2025, 4, 28, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8141), 2, "CH007", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8142) },
                    { "T008", "A013", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8146), "Perform on live TV", new DateTime(2025, 5, 1, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8146), "EC008", true, "London", new DateTime(2025, 4, 30, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8145), 3, "CH008", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8148) },
                    { "T009", "A015", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8152), "Perform for charity", new DateTime(2025, 5, 3, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8151), "EC009", true, "Sydney", new DateTime(2025, 5, 2, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8150), 4, "CH008", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8152) },
                    { "T010", "A005", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8157), "Talk about cosplay industry", new DateTime(2025, 5, 5, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8157), "EC010", true, "San Diego", new DateTime(2025, 5, 4, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8156), 0, "CH009", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8158) },
                    { "T011", "A008", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8162), "New character shoot", new DateTime(2025, 5, 7, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8161), "EC011", true, "Bangkok", new DateTime(2025, 5, 6, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8161), 1, "CH010", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8162) },
                    { "T012", "A007", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8166), "Host main event", new DateTime(2025, 5, 9, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8166), "EC012", true, "Jakarta", new DateTime(2025, 5, 8, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8165), 2, "CH011", null, new DateTime(2025, 4, 16, 1, 35, 30, 925, DateTimeKind.Local).AddTicks(8167) }
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
                    { "RD02", null, new DateTime(2025, 1, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, "RC01", new DateTime(2025, 1, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD03", null, new DateTime(2025, 1, 13, 14, 30, 0, 0, DateTimeKind.Unspecified), null, "RC01", new DateTime(2025, 1, 13, 14, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD04", null, new DateTime(2025, 1, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), null, "RC01", new DateTime(2025, 1, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "RD05", null, new DateTime(2025, 1, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), null, "RC01", new DateTime(2025, 1, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), 2 },
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
                    { "21766a0f-e756-48d1-a0a2-3f250eca88f8", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", null, null },
                    { "36050d5a-634f-4468-8b9f-66ca8be8e0dd", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", null, null },
                    { "548bd741-4e6e-45bd-838a-f217ac4cb8cb", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", null, null },
                    { "5b3a30f5-d157-47df-9b9c-41b413bff2a8", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", null, null },
                    { "7017004d-e616-4dc9-84df-728bce35d43f", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", null, null },
                    { "9bf5becb-68aa-4df1-80b5-47d4143bc05c", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", null, null },
                    { "a8bae293-e0e8-4603-9888-31b67b9d2454", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", null, null },
                    { "a9ec2733-1ce6-4341-ac9d-fd27e59053ef", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", null, null },
                    { "bf87d32b-652d-40eb-b7c4-d9486f8facf4", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", null, null }
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
                column: "ContractCharacterId",
                unique: true,
                filter: "[ContractCharacterId] IS NOT NULL");

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
