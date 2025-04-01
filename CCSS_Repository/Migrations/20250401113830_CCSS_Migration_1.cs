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
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    ContractStatus = table.Column<int>(type: "int", nullable: false)
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
                    { "ACT001", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(11), "A relaxing yoga session", "Yoga Class", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(13) },
                    { "ACT002", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(15), "Learn to cook delicious meals", "Cooking Workshop", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(16) },
                    { "ACT003", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(18), "Live music performance", "Music Concert", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(18) },
                    { "ACT004", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(20), "Showcase of local artists", "Art Exhibition", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(21) },
                    { "ACT005", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(23), "Discussion on latest technology trends", "Tech Talk", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(23) },
                    { "ACT006", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(25), "5K run for a good cause", "Charity Run", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(25) },
                    { "ACT007", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(29), "Monthly book discussion", "Book Club", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(29) },
                    { "ACT008", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(31), "Learn photography skills", "Photography Workshop", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(32) },
                    { "ACT009", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(34), "Dance battle for all ages", "Dance Competition", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(34) },
                    { "ACT010", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(36), "Competitive chess matches", "Chess Tournament", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(36) },
                    { "ACT011", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(38), "Outdoor movie screening", "Movie Night", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(38) },
                    { "ACT012", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(40), "Showcase of scientific projects", "Science Fair", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(40) },
                    { "ACT013", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(42), "Intensive coding workshop", "Coding Bootcamp", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(42) },
                    { "ACT014", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(44), "Learn gardening techniques", "Gardening Workshop", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(45) },
                    { "ACT015", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(48), "Guided meditation practice", "Meditation Session", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(49) }
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
                    { "CP001", 50.0, "Min order 500", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP002", 150.0, "Min order 1000", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP003", 400.0, "Min contract 2000", new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP004", 180.0, "Min order 1500", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 12f, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP005", 750.0, "Min contract 3000", new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP006", 100.0, "New customers only", new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP007", 200.0, "Holiday Special", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP008", 600.0, "VIP customers", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP009", 120.0, "Summer Sale", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP010", 1000.0, "Black Friday", new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP011", 75.0, "Back to School", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP012", 1750.0, "Min contract 5000", new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "CP013", 250.0, "Loyal Customers", new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP014", 800.0, "Cyber Monday", new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "CP015", 50.0, "Referral Bonus", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "CreateBy", "CreateDate", "Description", "EndDate", "EventName", "IsActive", "Location", "StartDate", "UpdateDate" },
                values: new object[,]
                {
                    { "E001", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7969), "A grand celebration to welcome the new year", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Year Festival", true, "Times Square, New York", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E002", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7972), "Experience the beauty of cherry blossoms", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring Blossom Fest", true, "Kyoto, Japan", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E003", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7975), "Showcasing the latest in technology and AI", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Innovation Summit", true, "Silicon Valley", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E004", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8030), "Live performances from top artists", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music Fest", true, "Coachella, California", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E005", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8034), "A must-attend event for comic book fans", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comic-Con International", true, "San Diego Convention Center", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E006", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8037), "Largest anime convention in the world", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anime Expo", true, "Los Angeles Convention Center", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E007", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8040), "Latest trends and releases in gaming", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Expo", true, "Las Vegas Convention Center", new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E008", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8045), "A fun-filled summer celebration", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Festival", true, "Miami Beach, Florida", new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E009", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8048), "A paradise for cosplayers", new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosplay Festival", true, "Tokyo Big Sight", new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E010", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8051), "Showcasing the best movies of the year", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Festival", true, "Cannes, France", new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E011", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8054), "Spooky celebrations and costume parties", new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween Night", true, "Salem, Massachusetts", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E012", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8057), "Festive shopping and holiday cheer", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Market", true, "Nuremberg, Germany", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "PackageId", "Description", "PackageName", "Price" },
                values: new object[,]
                {
                    { "PKG001", "Rent a single character for an event", "Basic Character Rental", 100.0 },
                    { "PKG002", "Rent multiple characters with costumes", "Deluxe Character Rental", 250.0 },
                    { "PKG003", "Full-day character rental service", "Ultimate Character Rental", 500.0 },
                    { "PKG004", "Basic cosplay performance at an event", "Standard Cosplay Performance", 150.0 },
                    { "PKG005", "Advanced performance with choreography", "Premium Cosplay Performance", 300.0 },
                    { "PKG006", "Exclusive show with audience interaction", "VIP Cosplay Performance", 500.0 },
                    { "PKG007", "30-minute photoshoot with cosplayers", "Mini Photography Session", 80.0 },
                    { "PKG008", "1-hour professional photoshoot", "Standard Photography Session", 150.0 },
                    { "PKG009", "Complete photoshoot with editing", "Full Photography Package", 300.0 },
                    { "PKG010", "Includes exclusive cosplay merchandise", "Basic Merchandise Pack", 50.0 },
                    { "PKG011", "Premium cosplay collectibles", "Deluxe Merchandise Pack", 150.0 },
                    { "PKG012", "Limited edition cosplay items", "Ultimate Merchandise Pack", 300.0 },
                    { "PKG013", "Beginner-friendly cosplay training", "Cosplay Basics Workshop", 100.0 },
                    { "PKG014", "In-depth cosplay and makeup course", "Advanced Cosplay Training", 250.0 },
                    { "PKG015", "Professional-level training for cosplayers", "Master Cosplay Workshop", 500.0 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreateDate", "Description", "IsActive", "Price", "ProductName", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { "P001", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7871), "A wig for Naruto cosplay", true, 30.0, "Naruto Wig", 10, null },
                    { "P002", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7876), "A hat for Mario cosplay", true, 20.0, "Mario Hat", 15, null },
                    { "P003", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7879), "Complete costume for Sasuke cosplay", true, 80.0, "Sasuke Costume", 5, null },
                    { "P004", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7884), "Replica sword from The Legend of Zelda", true, 100.0, "Zelda Sword", 7, null },
                    { "P005", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7886), "Iconic straw hat from One Piece", true, 25.0, "One Piece Straw Hat", 20, null },
                    { "P006", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7890), "Hatsune Miku blue twin-tail wig", true, 40.0, "Miku Wig", 12, null },
                    { "P007", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7892), "Tanjiro's iconic hanafuda earrings", true, 15.0, "Demon Slayer Earrings", 30, null },
                    { "P008", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7895), "Survey Corps uniform jacket", true, 50.0, "Attack on Titan Jacket", 10, null },
                    { "P009", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7898), "Cozy Pikachu-themed onesie", true, 60.0, "Pikachu Onesie", 8, null },
                    { "P010", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7901), "Final Fantasy VII replica sword", true, 120.0, "Cloud's Buster Sword", 4, null },
                    { "P011", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7903), "LED Vision accessory from Genshin Impact", true, 35.0, "Genshin Impact Vision", 25, null },
                    { "P012", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7908), "Jinx cosplay wig from Arcane", true, 45.0, "Jinx Wig", 6, null },
                    { "P013", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7911), "Golden tiara from Sailor Moon", true, 18.0, "Sailor Moon Tiara", 15, null },
                    { "P014", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7914), "High-quality Spider-Man suit", true, 90.0, "Spider-Man Suit", 3, null },
                    { "P015", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7917), "Replica wand from Harry Potter series", true, 22.0, "Harry Potter Wand", 50, null }
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
                    { "S001", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7824), "Rent characters for events and parties", "Character Rental", null },
                    { "S002", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7830), "Live cosplay performances at events", "Cosplay Rental", null },
                    { "S003", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7832), "Professional photoshoot with cosplayers", "Create event", null }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AverageStar", "Birthday", "Code", "Description", "Email", "GoogleId", "Height", "IsActive", "Leader", "Name", "OnTask", "Password", "Phone", "RoleId", "SalaryIndex", "TaskQuantity", "UserName", "Weight" },
                values: new object[,]
                {
                    { "A001", 4.5, null, null, null, "john@example.com", null, 180f, true, null, "John Doe", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, null, 75f },
                    { "A002", null, null, null, null, "jane@example.com", null, null, true, null, "Jane Smith", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R001", null, null, null, null },
                    { "A003", null, null, null, null, "alice@example.com", null, null, true, null, "Alice Johnson", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A004", 4.2000000000000002, null, null, null, "bob@example.com", null, 175f, true, null, "Bob Brown", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, null, 80f },
                    { "A005", 3.5, null, null, null, "charlie@example.com", null, 182f, true, null, "Charlie White", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, null, 78f },
                    { "A006", null, null, null, null, "david@example.com", null, null, true, null, "David Black", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A007", 4.0999999999999996, null, null, null, "emma@example.com", null, 168f, true, null, "Emma Green", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, null, 60f },
                    { "A008", 4.5999999999999996, null, null, null, "frank@example.com", null, 185f, true, null, "Frank Blue", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.5, null, null, 85f },
                    { "A009", null, null, null, null, "grace@example.com", null, null, true, null, "Grace Pink", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R001", null, null, null, null },
                    { "A010", 2.5, null, null, null, "henry@example.com", null, 178f, true, null, "Henry Purple", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, null, 77f },
                    { "A011", null, null, null, null, "isla@example.com", null, null, true, null, "Isla Red", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A012", 3.7999999999999998, null, null, null, "jack@example.com", null, 172f, true, null, "Jack Yellow", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, null, 70f },
                    { "A013", 2.5899999999999999, null, null, null, "katie@example.com", null, 165f, true, null, "Katie Orange", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, null, 55f },
                    { "A014", null, null, null, null, "liam@example.com", null, null, true, null, "Liam Gray", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null, null },
                    { "A015", 1.5, null, null, null, "mia@example.com", null, 170f, true, null, "Mia Cyan", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, null, 65f },
                    { "A016", 3.7000000000000002, null, null, null, "noah@example.com", null, 175f, true, null, "Noah Silver", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, null, 70f },
                    { "A017", 4.7999999999999998, null, null, null, "olivia@example.com", null, 168f, true, null, "Olivia Gold", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, null, 55f },
                    { "A018", 3.2000000000000002, null, null, null, "william@example.com", null, 180f, true, null, "William Amber", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, null, 75f },
                    { "A019", 3.2999999999999998, null, null, null, "sophia@example.com", null, 165f, true, null, "Sophia Ivory", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, null, 50f },
                    { "A020", 3.3999999999999999, null, null, null, "james@example.com", null, 178f, true, null, "James Navy", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.5, null, null, 72f },
                    { "A021", 3.5, null, null, null, "ava@example.com", null, 162f, true, null, "Ava Teal", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, null, 48f },
                    { "A022", 3.6000000000000001, null, null, null, "benjamin@example.com", null, 177f, true, null, "Benjamin Lime", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, null, 70f },
                    { "A023", 3.7000000000000002, null, null, null, "charlotte@example.com", null, 164f, true, null, "Charlotte Beige", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, null, 52f },
                    { "A024", 3.7999999999999998, null, null, null, "lucas@example.com", null, 180f, true, null, "Lucas Maroon", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, null, 74f },
                    { "A025", 3.8999999999999999, null, null, null, "mia@example.com", null, 159f, true, null, "Mia Pearl", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, null, 47f },
                    { "A026", 2.5, null, null, null, "ethan@example.com", null, 176f, true, null, "Ethan Olive", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, null, 71f },
                    { "A027", 2.6000000000000001, null, null, null, "amelia@example.com", null, 167f, true, null, "Amelia Ruby", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, null, 53f },
                    { "A028", 2.7000000000000002, null, null, null, "henry@example.com", null, 182f, true, null, "Henry Saffron", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, null, 76f },
                    { "A029", 2.7999999999999998, null, null, null, "ella@example.com", null, 160f, true, null, "Ella Coral", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, null, 49f },
                    { "A030", 2.8999999999999999, null, null, null, "daniel@example.com", null, 175f, true, null, "Daniel Cyan", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, null, 72f },
                    { "A031", 3.0, null, null, null, "logan@example.com", null, 180f, true, null, "Logan Indigo", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, null, 73f },
                    { "A032", 4.0, null, null, null, "lily@example.com", null, 165f, true, null, "Lily Violet", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, null, 52f },
                    { "A033", 4.0999999999999996, null, null, null, "mason@example.com", null, 178f, true, null, "Mason Turquoise", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, null, 74f },
                    { "A034", 4.2000000000000002, null, null, null, "zoe@example.com", null, 160f, true, null, "Zoe Lavender", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, null, 48f },
                    { "A035", 4.2999999999999998, null, null, null, "elijah@example.com", null, 182f, true, null, "Elijah Crimson", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.5, null, null, 77f },
                    { "A036", 4.4000000000000004, null, null, null, "aria@example.com", null, 164f, true, null, "Aria Mint", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, null, 50f },
                    { "A037", 4.5, null, null, null, "sebastian@example.com", null, 179f, true, null, "Sebastian Bronze", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, null, 72f },
                    { "A038", 4.5999999999999996, null, null, null, "harper@example.com", null, 168f, true, null, "Harper Rose", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, null, 53f },
                    { "A039", 4.7000000000000002, null, null, null, "caleb@example.com", null, 181f, true, null, "Caleb Onyx", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, null, 75f },
                    { "A040", 4.7999999999999998, null, null, null, "scarlett@example.com", null, 162f, true, null, "Scarlett Magenta", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, null, 51f }
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "CategoryId", "CharacterName", "CreateDate", "Description", "IsActive", "MaxHeight", "MaxWeight", "MinHeight", "MinWeight", "Price", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { "CH001", "C3", "Naruto", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7339), "Ninja from Konoha", true, 180f, 80f, 160f, 50f, 100.0, 5, null },
                    { "CH002", "C3", "Sasuke", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7346), "Naruto’s rival", true, 185f, 85f, 165f, 55f, 120.0, 3, null },
                    { "CH003", "C3", "Goku", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7352), "Saiyan warrior", true, 190f, 90f, 170f, 60f, 150.0, 4, null },
                    { "CH004", "C4", "Luffy", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7356), "Pirate King", true, 175f, 70f, 155f, 45f, 110.0, 6, null },
                    { "CH005", "C4", "Ichigo", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7360), "Soul Reaper", true, 185f, 85f, 165f, 55f, 130.0, 3, null },
                    { "CH006", "C14", "Mario", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7363), "Plumber hero", true, 160f, 70f, 140f, 50f, 80.0, 5, null },
                    { "CH007", "C14", "Luigi", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7368), "Mario’s brother", true, 170f, 75f, 150f, 55f, 85.0, 4, null },
                    { "CH008", "C14", "Link", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7371), "Hero of Hyrule", true, 180f, 80f, 160f, 50f, 140.0, 2, null },
                    { "CH009", "C16", "Zelda", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7375), "Hyrule princess", true, 175f, 70f, 155f, 50f, 135.0, 3, null },
                    { "CH010", "C16", "Samus", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7378), "Bounty hunter", true, 185f, 85f, 165f, 55f, 145.0, 3, null },
                    { "CH011", "C13", "Cloud", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7383), "Ex-SOLDIER", true, 185f, 85f, 165f, 55f, 125.0, 3, null },
                    { "CH012", "C13", "Sephiroth", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7387), "One-Winged Angel", true, 190f, 90f, 170f, 60f, 155.0, 2, null },
                    { "CH013", "C8", "Kratos", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7391), "God of War", true, 195f, 100f, 175f, 70f, 160.0, 2, null },
                    { "CH014", "C8", "Pikachu", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7395), "Electric Pokemon", true, 50f, 20f, 30f, 10f, 90.0, 10, null },
                    { "CH015", "C8", "Kirby", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(7591), "Pink puffball", true, 60f, 25f, 40f, 15f, 95.0, 8, null }
                });

            migrationBuilder.InsertData(
                table: "EventActivity",
                columns: new[] { "EventActivityId", "ActivityId", "CreateBy", "CreateDate", "Description", "EventId", "UpdateDate" },
                values: new object[,]
                {
                    { "EA001", "ACT001", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9759), "Yoga for a fresh start", "E001", null },
                    { "EA002", "ACT005", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9762), "Tech trends in the new year", "E001", null },
                    { "EA003", "ACT004", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9764), "Painting cherry blossoms", "E002", null },
                    { "EA004", "ACT013", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9768), "AI and future coding", "E003", null },
                    { "EA005", "ACT009", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9770), "Dance battles live", "E004", null },
                    { "EA006", "ACT003", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9772), "Comic-Con live music", "E005", null },
                    { "EA007", "ACT007", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9774), "Anime and book discussions", "E006", null },
                    { "EA008", "ACT010", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9776), "Chess and gaming", "E007", null },
                    { "EA009", "ACT011", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9779), "Outdoor movie fun", "E008", null },
                    { "EA010", "ACT015", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9781), "Meditation for cosplayers", "E009", null },
                    { "EA011", "ACT012", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9783), "Science in filmmaking", "E010", null },
                    { "EA012", "ACT006", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9787), "Halloween charity run", "E011", null },
                    { "EA013", "ACT014", "Admin", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9789), "Christmas gardening", "E012", null },
                    { "EA014", "ACT002", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9792), "Cooking for music lovers", "E004", null },
                    { "EA015", "ACT008", "Manager", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9794), "Photography in tech", "E003", null }
                });

            migrationBuilder.InsertData(
                table: "EventImage",
                columns: new[] { "ImageId", "CreateDate", "EventId", "ImageUrl", "IsAvatar", "UpdateDate" },
                values: new object[,]
                {
                    { "EI001", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(265), "E001", "https://example.com/event1.jpg", null, null },
                    { "EI002", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(267), "E002", "https://example.com/event2.jpg", null, null },
                    { "EI003", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(269), "E003", "https://example.com/event3.jpg", null, null },
                    { "EI004", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(271), "E004", "https://example.com/event4.jpg", null, null },
                    { "EI005", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(342), "E005", "https://example.com/event5.jpg", null, null },
                    { "EI006", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(343), "E006", "https://example.com/event6.jpg", null, null },
                    { "EI007", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(345), "E007", "https://example.com/event7.jpg", null, null },
                    { "EI008", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(347), "E008", "https://example.com/event8.jpg", null, null },
                    { "EI009", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(350), "E009", "https://example.com/event9.jpg", null, null },
                    { "EI010", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(351), "E010", "https://example.com/event10.jpg", null, null },
                    { "EI011", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(353), "E011", "https://example.com/event11.jpg", null, null },
                    { "EI012", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(354), "E012", "https://example.com/event12.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "ProductImageId", "CreateDate", "IsAvatar", "ProductId", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "IMG001", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(984), null, "P001", null, "https://example.com/images/naruto_wig.jpg" },
                    { "IMG002", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(988), null, "P002", null, "https://example.com/images/mario_hat.jpg" },
                    { "IMG003", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(990), null, "P003", null, "https://example.com/images/sasuke_costume.jpg" },
                    { "IMG004", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(993), null, "P004", null, "https://example.com/images/zelda_sword.jpg" },
                    { "IMG005", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(996), null, "P005", null, "https://example.com/images/one_piece_hat.jpg" },
                    { "IMG006", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(998), null, "P006", null, "https://example.com/images/miku_wig.jpg" },
                    { "IMG007", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(1000), null, "P007", null, "https://example.com/images/demon_slayer_earrings.jpg" },
                    { "IMG008", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(1003), null, "P008", null, "https://example.com/images/aot_jacket.jpg" },
                    { "IMG009", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(1705), null, "P009", null, "https://example.com/images/pikachu_onesie.jpg" },
                    { "IMG010", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(1790), null, "P010", null, "https://example.com/images/buster_sword.jpg" },
                    { "IMG011", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(1796), null, "P011", null, "https://example.com/images/genshin_vision.jpg" },
                    { "IMG012", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(1801), null, "P012", null, "https://example.com/images/jinx_wig.jpg" },
                    { "IMG013", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(1804), null, "P013", null, "https://example.com/images/sailor_moon_tiara.jpg" },
                    { "IMG014", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(1808), null, "P014", null, "https://example.com/images/spiderman_suit.jpg" },
                    { "IMG015", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(1812), null, "P015", null, "https://example.com/images/harry_potter_wand.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "TicketId", "EventId", "Price", "Quantity" },
                values: new object[,]
                {
                    { "T001", "E001", 50.0, 500 },
                    { "T002", "E002", 40.0, 300 },
                    { "T003", "E003", 30.0, 200 },
                    { "T004", "E004", 60.0, 600 },
                    { "T005", "E005", 45.0, 400 },
                    { "T006", "E006", 55.0, 350 },
                    { "T007", "E007", 35.0, 250 },
                    { "T008", "E008", 50.0, 450 },
                    { "T009", "E009", 65.0, 550 },
                    { "T010", "E010", 70.0, 700 },
                    { "T011", "E011", 25.0, 150 },
                    { "T012", "E012", 75.0, 800 }
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
                    { "AI1", "A001", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9945), null, null, "https://example.com/admin.jpg" },
                    { "AI10", "A010", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9969), null, null, "https://example.com/user8.jpg" },
                    { "AI11", "A011", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9971), null, null, "https://example.com/user9.jpg" },
                    { "AI12", "A012", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9973), null, null, "https://example.com/user10.jpg" },
                    { "AI13", "A013", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9974), null, null, "https://example.com/user11.jpg" },
                    { "AI14", "A014", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9978), null, null, "https://example.com/user12.jpg" },
                    { "AI15", "A015", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9980), null, null, "https://example.com/user13.jpg" },
                    { "AI2", "A002", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9948), null, null, "https://example.com/manager.jpg" },
                    { "AI3", "A003", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9950), null, null, "https://example.com/user1.jpg" },
                    { "AI4", "A004", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9952), null, null, "https://example.com/user2.jpg" },
                    { "AI5", "A005", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9953), null, null, "https://example.com/user3.jpg" },
                    { "AI6", "A006", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9957), null, null, "https://example.com/user4.jpg" },
                    { "AI7", "A007", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9963), null, null, "https://example.com/user5.jpg" },
                    { "AI8", "A008", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9965), null, null, "https://example.com/user6.jpg" },
                    { "AI9", "A009", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(9966), null, null, "https://example.com/user7.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "AccountId", "CreateDate", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "C001", "A003", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8771), 0.0, new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8772) },
                    { "C002", "A006", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8775), 0.0, new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8775) },
                    { "C003", "A011", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8777), 0.0, new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8778) },
                    { "C004", "A014", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8780), 0.0, new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8780) }
                });

            migrationBuilder.InsertData(
                table: "CharacterImage",
                columns: new[] { "CharacterImageId", "CharacterId", "CreateDate", "IsAvatar", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "CI001", "CH001", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(201), null, null, "https://example.com/img1.jpg" },
                    { "CI002", "CH002", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(206), null, null, "https://example.com/img2.jpg" },
                    { "CI003", "CH003", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(208), null, null, "https://example.com/img3.jpg" },
                    { "CI004", "CH004", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(210), null, null, "https://example.com/img4.jpg" },
                    { "CI005", "CH005", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(212), null, null, "https://example.com/img5.jpg" },
                    { "CI006", "CH006", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(213), null, null, "https://example.com/img6.jpg" },
                    { "CI007", "CH007", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(215), null, null, "https://example.com/img7.jpg" },
                    { "CI008", "CH008", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(218), null, null, "https://example.com/img8.jpg" },
                    { "CI009", "CH009", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(220), null, null, "https://example.com/img9.jpg" },
                    { "CI010", "CH010", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(222), null, null, "https://example.com/img10.jpg" },
                    { "CI011", "CH011", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(223), null, null, "https://example.com/img11.jpg" },
                    { "CI012", "CH012", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(225), null, null, "https://example.com/img12.jpg" },
                    { "CI013", "CH013", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(226), null, null, "https://example.com/img13.jpg" },
                    { "CI014", "CH014", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(228), null, null, "https://example.com/img14.jpg" },
                    { "CI015", "CH015", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(231), null, null, "https://example.com/img15.jpg" }
                });

            migrationBuilder.InsertData(
                table: "EventCharacter",
                columns: new[] { "EventCharacterId", "CharacterId", "CreateDate", "Description", "EventId", "IsAssign", "UpdateDate" },
                values: new object[,]
                {
                    { "EC001", "CH001", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9634), null, "E001", true, null },
                    { "EC002", "CH002", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9637), null, "E002", true, null },
                    { "EC003", "CH003", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9640), null, "E003", true, null },
                    { "EC004", "CH004", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9642), null, "E004", true, null },
                    { "EC005", "CH005", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9644), null, "E005", true, null },
                    { "EC006", "CH006", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9647), null, "E006", true, null },
                    { "EC007", "CH007", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9649), null, "E007", true, null },
                    { "EC008", "CH008", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9653), null, "E008", true, null },
                    { "EC009", "CH009", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9716), null, "E009", true, null },
                    { "EC010", "CH010", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9719), null, "E010", true, null },
                    { "EC011", "CH011", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9722), null, "E011", true, null },
                    { "EC012", "CH012", new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9724), null, "E012", true, null }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "AccountId", "CreatedAt", "IsRead", "IsSentMail", "Message" },
                values: new object[,]
                {
                    { "N001", "A001", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8692), false, true, "Welcome to the system!" },
                    { "N002", "A002", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8695), false, true, "Your account has been upgraded." },
                    { "N003", "A003", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8697), true, true, "New promotional offer available!" },
                    { "N004", "A004", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8701), false, true, "Your request has been approved." },
                    { "N005", "A005", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8703), true, true, "System maintenance scheduled." },
                    { "N006", "A006", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8705), false, true, "Your order has been shipped!" },
                    { "N007", "A007", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8707), false, true, "New event registration open." },
                    { "N008", "A008", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8709), true, true, "Reminder: Payment due soon." },
                    { "N009", "A009", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8711), false, true, "Your password was changed." },
                    { "N010", "A010", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8713), false, true, "Admin announcement update." },
                    { "N011", "A011", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8715), true, true, "New message from support." },
                    { "N012", "A012", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8719), false, true, "Upcoming event invitation." },
                    { "N013", "A013", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8721), false, true, "New cosplayer contest." },
                    { "N014", "A014", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8723), true, true, "Loyalty points updated." },
                    { "N015", "A015", new DateTime(2025, 4, 1, 11, 38, 28, 702, DateTimeKind.Utc).AddTicks(8726), false, true, "Your subscription expired." }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "AccountId", "OrderDate", "OrderStatus", "TotalPrice" },
                values: new object[,]
                {
                    { "O001", "A003", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 250.0 },
                    { "O002", "A006", new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 150.5 },
                    { "O003", "A011", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 300.0 },
                    { "O004", "A014", new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 400.0 },
                    { "O005", "A003", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 175.0 },
                    { "O006", "A006", new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 225.0 },
                    { "O007", "A011", new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 350.0 },
                    { "O008", "A014", new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 275.0 },
                    { "O009", "A003", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 500.0 },
                    { "O010", "A006", new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 125.0 },
                    { "O011", "A011", new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 325.0 },
                    { "O012", "A014", new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 410.0 },
                    { "O013", "A003", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 280.0 },
                    { "O014", "A006", new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 350.0 },
                    { "O015", "A011", new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200.0 }
                });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "RequestId", "AccountCouponId", "AccountId", "Description", "EndDate", "Location", "Name", "PackageId", "Price", "ServiceId", "StartDate", "Status" },
                values: new object[,]
                {
                    { "R001", null, "A001", "RentCostumes", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Naruto Costume", "PKG001", 100.0, "S001", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R002", null, "A002", "RentCosplayer", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ĐN", "Rent Cosplayer for Event", null, 500.0, "S002", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R003", null, "A003", "CreateEvent", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "BD", "Create Anime Festival", null, 2000.0, "S003", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R004", null, "A004", "RentCostumes", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Rent Samurai Armor", null, 150.0, "S002", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R005", null, "A005", "RentCosplayer", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "BT", "Hire Professional Cosplayer", "PKG002", 700.0, "S002", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R006", null, "A006", "CreateEvent", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Organize Comic Convention", null, 5000.0, "S001", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R007", null, "A007", "RentCostumes", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Victorian Costume", null, 120.0, "S002", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R008", null, "A008", "RentCosplayer", new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "QN", "Book Cosplayer for Birthday Party", null, 350.0, "S003", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R009", null, "A009", "CreateEvent", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CM", "Plan Fantasy Fair", null, 3000.0, "S003", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R010", null, "A010", "RentCostumes", new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "LĐ", "Rent Halloween Costumes", null, 200.0, "S001", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R011", null, "A011", "RentCosplayer", new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "NT", "Hire Cosplayer for Wedding", "PKG010", 800.0, "S001", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R012", null, "A012", "CreateEvent", new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "VT", "Create Sci-Fi Convention", null, 4500.0, "S002", new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R013", null, "A013", "RentCostumes", new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Santa Claus Costume", null, 130.0, "S003", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R014", null, "A014", "RentCosplayer", new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Book Cosplayer for Product Launch", null, 600.0, "S001", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R015", null, "A015", "CreateEvent", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Host Christmas Event", "PKG015", 5500.0, "S002", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "TicketAccount",
                columns: new[] { "TicketAccountId", "AccountId", "Quantity", "TicketCode", "TicketId", "TotalPrice" },
                values: new object[,]
                {
                    { "TA001", "A003", 2, "TC001", "T001", 100.0 },
                    { "TA002", "A006", 1, "TC002", "T002", 40.0 },
                    { "TA003", "A011", 3, "TC003", "T003", 90.0 },
                    { "TA004", "A014", 2, "TC004", "T004", 120.0 },
                    { "TA005", "A003", 4, "TC005", "T005", 180.0 },
                    { "TA006", "A006", 2, "TC006", "T006", 110.0 },
                    { "TA007", "A011", 1, "TC007", "T007", 35.0 },
                    { "TA008", "A014", 3, "TC008", "T008", 150.0 },
                    { "TA009", "A003", 2, "TC009", "T009", 130.0 },
                    { "TA010", "A006", 1, "TC010", "T010", 70.0 },
                    { "TA011", "A011", 5, "TC011", "T011", 125.0 },
                    { "TA012", "A014", 2, "TC012", "T012", 150.0 },
                    { "TA013", "A003", 3, "TC013", "T003", 90.0 },
                    { "TA014", "A006", 2, "TC014", "T005", 90.0 },
                    { "TA015", "A011", 1, "TC015", "T007", 35.0 }
                });

            migrationBuilder.InsertData(
                table: "CartProduct",
                columns: new[] { "CartProductId", "CartId", "CreatedDate", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "15123ead-0ecf-429b-a76d-a3639f64c67e", "C003", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(153), 50.0, "P008", 2 },
                    { "23c74772-4f83-4fc7-b08f-f78d33157fe0", "C001", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(132), 80.0, "P003", 1 },
                    { "2828941d-965c-4871-8015-877b74e450f8", "C003", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(157), 60.0, "P009", 1 },
                    { "3ca8fe28-2bbe-457d-af3e-6e2c4ae2db55", "C001", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(124), 30.0, "P001", 2 },
                    { "4642f2e4-6942-4b05-9681-9ce3155e0336", "C002", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(141), 25.0, "P005", 3 },
                    { "78e39c7d-ba77-4c39-82e5-283701f61392", "C004", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(170), 45.0, "P012", 1 },
                    { "7d9eed02-98cb-4de9-ae3b-bf3dffd7e74b", "C001", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(128), 20.0, "P002", 1 },
                    { "b643bfca-4445-4bd4-9419-56000d138f4a", "C002", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(144), 40.0, "P006", 2 },
                    { "b7b9ebf1-16ee-4e46-9f68-775b4aef1461", "C004", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(164), 35.0, "P011", 2 },
                    { "d544dbef-14e6-4952-adc9-e5f82c11f97d", "C004", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(160), 120.0, "P010", 1 },
                    { "e3a72808-581c-454b-bcf6-ac1adb9439a6", "C003", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(148), 15.0, "P007", 5 },
                    { "fa62c51a-7b25-496b-90bf-10b1c560ec0e", "C002", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(137), 100.0, "P004", 1 }
                });

            migrationBuilder.InsertData(
                table: "Contract",
                columns: new[] { "ContractId", "Amount", "ContractName", "ContractStatus", "CreateBy", "CreateDate", "Deposit", "Reason", "RequestId", "TotalPrice", "UrlPdf" },
                values: new object[,]
                {
                    { "CT002", 0.0, "Character rental", 1, "Admin", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "100", null, "R002", 500.0, null },
                    { "CT005", 350.0, "Character rental", 1, "Admin", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", null, "R005", 700.0, null },
                    { "CT008", 175.0, "Character rental", 1, "Admin", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", null, "R008", 350.0, null },
                    { "CT010", 100.0, "Character rental", 3, "Admin", new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", null, "R010", 200.0, null },
                    { "CT014", 0.0, "Character rental", 1, "Admin", new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "100", null, "R014", 600.0, null }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "033b5380-30c1-4cc3-8834-934bdba739f4", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(412), "O004", 50.0, "P008", 2 },
                    { "17e8c193-27f2-4ace-a19a-257a8c76e577", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(399), "O002", 100.0, "P004", 1 },
                    { "279ee0c3-728d-4cc7-8341-30f055603e49", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(463), "O010", 25.0, "P005", 3 },
                    { "29ecf763-1e27-4c73-a58d-7ae39e0afda6", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(633), "O015", 90.0, "P014", 2 },
                    { "2bc304aa-fdcd-44ae-b05d-3b10825ef756", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(417), "O005", 60.0, "P009", 1 },
                    { "3e58c196-d8f0-49ef-ab97-29d6356b48a4", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(430), "O006", 45.0, "P012", 3 },
                    { "445c329d-bd1f-4ab5-9963-15f4a500afd4", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(614), "O013", 120.0, "P010", 1 },
                    { "4f4ea5a8-e63b-4533-a5f3-c314a49b75e9", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(402), "O003", 25.0, "P005", 2 },
                    { "61d84840-38ec-47f5-92f1-8aab531b69e4", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(409), "O004", 15.0, "P007", 4 },
                    { "69235731-722e-448c-83cd-50ed165d0198", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(438), "O007", 90.0, "P014", 2 },
                    { "6a5236fa-99af-4208-8231-b8012568320b", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(548), "O012", 60.0, "P009", 1 },
                    { "716ba3df-627a-41c2-8d2b-9864d2d7d581", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(397), "O002", 80.0, "P003", 1 },
                    { "77d0c092-4d6a-4073-89a3-b81e552aa143", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(483), "O011", 15.0, "P007", 4 },
                    { "87c55554-8e8d-42b1-b199-0141a9a49df3", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(405), "O003", 40.0, "P006", 3 },
                    { "9409f102-dce4-4118-9f35-2accb6eb5e92", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(543), "O012", 50.0, "P008", 2 },
                    { "960cf23b-c1cb-4afd-a2d3-97dafd9e08bd", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(618), "O013", 35.0, "P011", 2 },
                    { "98d75cd3-01a6-4d62-8ece-3d1773516e0c", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(454), "O009", 80.0, "P003", 2 },
                    { "9a0d3d03-1a3b-4dc9-be88-f6ac54d59971", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(447), "O008", 30.0, "P001", 1 },
                    { "9db0daaf-2972-4c57-be43-184fb9030fa5", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(466), "O011", 40.0, "P006", 2 },
                    { "9fdbc008-60e8-434f-a3c3-45984c91a8ea", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(450), "O009", 20.0, "P002", 6 },
                    { "a73dd2d9-8978-43b3-9b29-771f43222ec5", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(434), "O007", 18.0, "P013", 5 },
                    { "a741c90b-a4a3-4b09-933f-f79dac0b5a6e", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(443), "O008", 22.0, "P015", 4 },
                    { "a9d987c0-1813-4189-8fcc-fe4da680488e", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(392), "O001", 20.0, "P002", 5 },
                    { "c303a61a-6f4a-4efb-9d55-6d7f41966b7a", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(625), "O014", 45.0, "P012", 3 },
                    { "d659ba48-fff7-41f5-a67b-b7b70cdb2b5f", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(629), "O014", 18.0, "P013", 5 },
                    { "e3f9bd37-84bb-409a-a7d6-414f5fc9e98f", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(459), "O010", 100.0, "P004", 1 },
                    { "e8ec1e7d-c734-45d1-8795-c36ecc5be2fc", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(389), "O001", 30.0, "P001", 3 },
                    { "f71d379b-1b00-4259-b37d-3790a3739596", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(426), "O006", 35.0, "P011", 2 },
                    { "ff2c6e90-a310-4d3e-b3b7-47ae85216d25", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(420), "O005", 120.0, "P010", 1 },
                    { "ffd25f83-9dd8-4425-a8d3-9b3cdfbf36b1", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(636), "O015", 22.0, "P015", 4 }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "AccountCouponID", "Amount", "ContractId", "CreatAt", "OrderId", "Purpose", "Status", "TicketAccountId", "TransactionId", "Type" },
                values: new object[,]
                {
                    { "P001", "AC001", 250.0, null, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, "TA001", "TXN001", "Online" },
                    { "P002", null, 150.5, null, new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, "TA002", "TXN002", "Online" },
                    { "P003", null, 90.0, null, new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, "TA003", "TXN003", "Cash" },
                    { "P004", "AC012", 400.0, null, new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 1, "TA004", "TXN004", "Card" },
                    { "P005", null, 175.0, null, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 2, "TA005", "TXN005", "Online" },
                    { "P006", "AC003", 225.0, null, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "O006", 3, 1, null, "TXN006", "Cash" },
                    { "P007", null, 350.0, null, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "O007", 3, 0, null, "TXN007", "Online" },
                    { "P008", null, 150.0, null, new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "O008", 3, 1, null, "TXN008", "Card" },
                    { "P009", null, 500.0, null, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "O009", 3, 1, null, "TXN009", "Cash" },
                    { "P010", "AC004", 125.0, null, new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "O010", 3, 2, null, "TXN010", "Online" }
                });

            migrationBuilder.InsertData(
                table: "RequestCharacter",
                columns: new[] { "RequestCharacterId", "CharacterId", "CosplayerId", "CreateDate", "Description", "Quantity", "RequestId", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "RC01", "CH001", "A025", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2335), "Yêu cầu cosplay nhân vật CH001", 1, "R001", 50.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2336) },
                    { "RC02", "CH002", "A026", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2343), "Yêu cầu cosplay nhân vật CH002", 1, "R002", 60.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2343) },
                    { "RC03", "CH003", "A027", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2351), "Yêu cầu cosplay nhân vật CH003", 1, "R003", 70.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2352) },
                    { "RC04", "CH004", "A028", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2356), "Yêu cầu cosplay nhân vật CH004", 1, "R004", 80.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2356) },
                    { "RC05", "CH005", "A029", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2362), "Yêu cầu cosplay nhân vật CH005", 1, "R005", 90.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2362) },
                    { "RC06", "CH006", null, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2367), "Yêu cầu cosplay nhân vật CH006", 5, "R006", 100.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2368) },
                    { "RC07", "CH007", "A031", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2372), "Yêu cầu cosplay nhân vật CH007", 1, "R007", 110.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2373) },
                    { "RC08", "CH008", null, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2376), "Yêu cầu cosplay nhân vật CH008", 7, "R008", 120.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2377) },
                    { "RC09", "CH009", "A033", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2380), "Yêu cầu cosplay nhân vật CH009", 1, "R009", 130.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2381) },
                    { "RC10", "CH010", null, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2385), "Yêu cầu cosplay nhân vật CH010", 9, "R010", 140.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2386) },
                    { "RC11", "CH011", "A035", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2392), "Yêu cầu cosplay nhân vật CH011", 1, "R011", 150.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2392) },
                    { "RC12", "CH012", "A036", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2396), "Yêu cầu cosplay nhân vật CH012", 1, "R012", 160.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2398) },
                    { "RC13", "CH013", null, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2402), "Yêu cầu cosplay nhân vật CH013", 10, "R013", 170.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2402) },
                    { "RC14", "CH014", "A038", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2406), "Yêu cầu cosplay nhân vật CH014", 1, "R014", 180.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2406) },
                    { "RC15", "CH015", "A039", new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2410), "Yêu cầu cosplay nhân vật CH015", 1, "R015", 190.0, new DateTime(2025, 4, 1, 11, 38, 28, 703, DateTimeKind.Utc).AddTicks(2411) }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "AccountId", "ContractCharacterId", "CreateDate", "Description", "EndDate", "EventCharacterId", "IsActive", "Location", "StartDate", "Status", "TaskName", "Type", "UpdateDate" },
                values: new object[,]
                {
                    { "T001", "A001", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9242), "Cosplay as anime characters", new DateTime(2025, 4, 4, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9241), "EC001", true, "Tokyo", new DateTime(2025, 4, 3, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9222), 0, "CH001", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9243) },
                    { "T002", "A004", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9250), "Join cosplay contest", new DateTime(2025, 4, 6, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9250), "EC002", true, "Los Angeles", new DateTime(2025, 4, 5, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9249), 1, "CH002", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9251) },
                    { "T003", "A005", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9255), "Teach costume making", new DateTime(2025, 4, 8, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9255), "EC003", true, "New York", new DateTime(2025, 4, 7, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9254), 2, "CH003", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9256) },
                    { "T004", "A007", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9263), "Host a live event", new DateTime(2025, 4, 2, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9263), "EC004", true, "Online", new DateTime(2025, 4, 2, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9262), 3, "CH004", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9264) },
                    { "T005", "A008", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9268), "Professional cosplay photoshoot", new DateTime(2025, 4, 10, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9267), "EC005", true, "Paris", new DateTime(2025, 4, 9, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9267), 0, "CH005", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9269) },
                    { "T006", "A010", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9273), "Evaluate contestants", new DateTime(2025, 4, 12, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9272), "EC006", true, "Berlin", new DateTime(2025, 4, 11, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9271), 1, "CH006", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9273) },
                    { "T007", "A012", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9277), "Walk in parade", new DateTime(2025, 4, 14, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9276), "EC007", true, "Seoul", new DateTime(2025, 4, 13, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9276), 2, "CH007", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9278) },
                    { "T008", "A013", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9282), "Perform on live TV", new DateTime(2025, 4, 16, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9281), "EC008", true, "London", new DateTime(2025, 4, 15, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9280), 3, "CH008", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9282) },
                    { "T009", "A015", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9288), "Perform for charity", new DateTime(2025, 4, 18, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9287), "EC009", true, "Sydney", new DateTime(2025, 4, 17, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9287), 4, "CH008", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9289) },
                    { "T010", "A005", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9295), "Talk about cosplay industry", new DateTime(2025, 4, 20, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9294), "EC010", true, "San Diego", new DateTime(2025, 4, 19, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9293), 0, "CH009", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9296) },
                    { "T011", "A008", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9300), "New character shoot", new DateTime(2025, 4, 22, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9299), "EC011", true, "Bangkok", new DateTime(2025, 4, 21, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9298), 1, "CH010", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9301) },
                    { "T012", "A007", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9305), "Host main event", new DateTime(2025, 4, 24, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9304), "EC012", true, "Jakarta", new DateTime(2025, 4, 23, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9304), 2, "CH011", null, new DateTime(2025, 4, 1, 18, 38, 28, 702, DateTimeKind.Local).AddTicks(9306) }
                });

            migrationBuilder.InsertData(
                table: "ContractCharacter",
                columns: new[] { "ContractCharacterId", "CharacterId", "ContractId", "CosplayerId", "CreateDate", "Description", "Quantity", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "CC0021", "CH001", "CT002", null, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT002", 1, 150.0, null },
                    { "CC0022", "CH002", "CT002", null, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT002", 5, 180.0, null },
                    { "CC0023", "CH003", "CT002", null, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT002", 3, 170.0, null },
                    { "CC0051", "CH004", "CT005", null, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT005", 2, 200.0, null },
                    { "CC0052", "CH005", "CT005", null, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT005", 4, 250.0, null },
                    { "CC0053", "CH006", "CT005", null, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT005", 6, 250.0, null },
                    { "CC0081", "CH007", "CT008", "A001", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT008", 1, 120.0, null },
                    { "CC0082", "CH008", "CT008", "A008", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT008", 1, 130.0, null },
                    { "CC0083", "CH009", "CT008", "A040", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT008", 1, 100.0, null },
                    { "CC0101", "CH010", "CT010", "A040", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT010", 1, 70.0, null },
                    { "CC0102", "CH011", "CT010", "A039", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT010", 1, 80.0, null },
                    { "CC0103", "CH012", "CT010", "A038", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT010", 1, 50.0, null },
                    { "CC0141", "CH013", "CT014", "A035", new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT014", 1, 200.0, null },
                    { "CC0142", "CH014", "CT014", "A040", new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT014", 1, 250.0, null },
                    { "CC0143", "CH015", "CT014", "A005", new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT014", 1, 150.0, null }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "AccountCouponID", "Amount", "ContractId", "CreatAt", "OrderId", "Purpose", "Status", "TicketAccountId", "TransactionId", "Type" },
                values: new object[,]
                {
                    { "P011", null, 325.0, "CT002", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, null, "TXN011", "Online" },
                    { "P012", null, 410.0, "CT005", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0, null, "TXN012", "Card" },
                    { "P013", null, 90.0, "CT008", new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, null, "TXN013", "Cash" },
                    { "P014", null, 350.0, "CT010", new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, null, "TXN014", "Online" },
                    { "P015", null, 200.0, "CT002", new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 1, null, "TXN015", "Card" }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractCharacterId", "CreateBy", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "12fff374-af05-4e3c-9330-3883fc5f13a1", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", null, null },
                    { "286872f5-1674-421a-81bc-0b2d4ba12205", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", null, null },
                    { "38390af1-6d5b-4984-8d93-63726e7257d5", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", null, null },
                    { "3ed5149e-cbde-403d-8164-d47f8204f299", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", null, null },
                    { "54f879c9-13eb-4b89-8fe9-88a980c33fd1", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", null, null },
                    { "5bee9e2c-6617-44de-8fbc-78674f724f29", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", null, null },
                    { "c4b33a36-ccfd-4984-8587-612056c54ba2", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", null, null },
                    { "dfb217cb-ae29-4279-b616-5dd5a6332ad6", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", null, null },
                    { "ebfc422d-2ad7-4a1c-8b60-d5e349b14192", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", null, null }
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
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

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
                column: "EventId",
                unique: true,
                filter: "[EventId] IS NOT NULL");

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
                name: "RequestCharacter");

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
