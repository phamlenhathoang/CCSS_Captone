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
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    OrderDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { "ACT001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8227), "A relaxing yoga session", "Yoga Class", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8227) },
                    { "ACT002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8230), "Learn to cook delicious meals", "Cooking Workshop", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8230) },
                    { "ACT003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8232), "Live music performance", "Music Concert", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8233) },
                    { "ACT004", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8234), "Showcase of local artists", "Art Exhibition", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8235) },
                    { "ACT005", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8237), "Discussion on latest technology trends", "Tech Talk", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8237) },
                    { "ACT006", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8240), "5K run for a good cause", "Charity Run", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8240) },
                    { "ACT007", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8243), "Monthly book discussion", "Book Club", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8244) },
                    { "ACT008", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8246), "Learn photography skills", "Photography Workshop", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8246) },
                    { "ACT009", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8280), "Dance battle for all ages", "Dance Competition", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8280) },
                    { "ACT010", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8282), "Competitive chess matches", "Chess Tournament", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8282) },
                    { "ACT011", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8285), "Outdoor movie screening", "Movie Night", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8285) },
                    { "ACT012", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8288), "Showcase of scientific projects", "Science Fair", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8288) },
                    { "ACT013", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8290), "Intensive coding workshop", "Coding Bootcamp", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8291) },
                    { "ACT014", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8293), "Learn gardening techniques", "Gardening Workshop", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8293) },
                    { "ACT015", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8296), "Guided meditation practice", "Meditation Session", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8297) }
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
                    { "E001", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7030), "A grand celebration to welcome the new year", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Year Festival", true, "Times Square, New York", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E002", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7034), "Experience the beauty of cherry blossoms", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring Blossom Fest", true, "Kyoto, Japan", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E003", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7036), "Showcasing the latest in technology and AI", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Innovation Summit", true, "Silicon Valley", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E004", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7039), "Live performances from top artists", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music Fest", true, "Coachella, California", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E005", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7044), "A must-attend event for comic book fans", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comic-Con International", true, "San Diego Convention Center", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E006", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7047), "Largest anime convention in the world", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anime Expo", true, "Los Angeles Convention Center", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E007", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7050), "Latest trends and releases in gaming", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Expo", true, "Las Vegas Convention Center", new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E008", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7052), "A fun-filled summer celebration", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Festival", true, "Miami Beach, Florida", new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E009", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7055), "A paradise for cosplayers", new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosplay Festival", true, "Tokyo Big Sight", new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E010", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7058), "Showcasing the best movies of the year", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Festival", true, "Cannes, France", new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E011", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7060), "Spooky celebrations and costume parties", new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween Night", true, "Salem, Massachusetts", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E012", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7063), "Festive shopping and holiday cheer", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Market", true, "Nuremberg, Germany", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
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
                    { "P001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6907), "A wig for Naruto cosplay", true, 30.0, "Naruto Wig", 10, null },
                    { "P002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6911), "A hat for Mario cosplay", true, 20.0, "Mario Hat", 15, null },
                    { "P003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6913), "Complete costume for Sasuke cosplay", true, 80.0, "Sasuke Costume", 5, null },
                    { "P004", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6918), "Replica sword from The Legend of Zelda", true, 100.0, "Zelda Sword", 7, null },
                    { "P005", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6920), "Iconic straw hat from One Piece", true, 25.0, "One Piece Straw Hat", 20, null },
                    { "P006", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6923), "Hatsune Miku blue twin-tail wig", true, 40.0, "Miku Wig", 12, null },
                    { "P007", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6925), "Tanjiro's iconic hanafuda earrings", true, 15.0, "Demon Slayer Earrings", 30, null },
                    { "P008", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6928), "Survey Corps uniform jacket", true, 50.0, "Attack on Titan Jacket", 10, null },
                    { "P009", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6931), "Cozy Pikachu-themed onesie", true, 60.0, "Pikachu Onesie", 8, null },
                    { "P010", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6934), "Final Fantasy VII replica sword", true, 120.0, "Cloud's Buster Sword", 4, null },
                    { "P011", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6937), "LED Vision accessory from Genshin Impact", true, 35.0, "Genshin Impact Vision", 25, null },
                    { "P012", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6941), "Jinx cosplay wig from Arcane", true, 45.0, "Jinx Wig", 6, null },
                    { "P013", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6974), "Golden tiara from Sailor Moon", true, 18.0, "Sailor Moon Tiara", 15, null },
                    { "P014", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6977), "High-quality Spider-Man suit", true, 90.0, "Spider-Man Suit", 3, null },
                    { "P015", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6980), "Replica wand from Harry Potter series", true, 22.0, "Harry Potter Wand", 50, null }
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
                    { "S001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6872), "Rent characters for events and parties", "Character Rental", null },
                    { "S002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6877), "Live cosplay performances at events", "Cosplay Rental", null },
                    { "S003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6878), "Professional photoshoot with cosplayers", "Create event", null }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AverageStar", "Birthday", "Code", "Description", "Email", "Height", "IsActive", "Leader", "Name", "OnTask", "Password", "Phone", "RoleId", "SalaryIndex", "TaskQuantity", "Weight" },
                values: new object[,]
                {
                    { "A001", null, null, null, null, "john@example.com", 180f, true, null, "John Doe", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, 75f },
                    { "A002", null, null, null, null, "jane@example.com", null, true, null, "Jane Smith", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R001", null, null, null },
                    { "A003", null, null, null, null, "alice@example.com", null, true, null, "Alice Johnson", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null },
                    { "A004", null, null, null, null, "bob@example.com", 175f, true, null, "Bob Brown", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, 80f },
                    { "A005", null, null, null, null, "charlie@example.com", 182f, true, null, "Charlie White", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, 78f },
                    { "A006", null, null, null, null, "david@example.com", null, true, null, "David Black", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null },
                    { "A007", null, null, null, null, "emma@example.com", 168f, true, null, "Emma Green", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, 60f },
                    { "A008", null, null, null, null, "frank@example.com", 185f, true, null, "Frank Blue", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.5, null, 85f },
                    { "A009", null, null, null, null, "grace@example.com", null, true, null, "Grace Pink", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R001", null, null, null },
                    { "A010", null, null, null, null, "henry@example.com", 178f, true, null, "Henry Purple", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, 77f },
                    { "A011", null, null, null, null, "isla@example.com", null, true, null, "Isla Red", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null },
                    { "A012", null, null, null, null, "jack@example.com", 172f, true, null, "Jack Yellow", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, 70f },
                    { "A013", null, null, null, null, "katie@example.com", 165f, true, null, "Katie Orange", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, 55f },
                    { "A014", null, null, null, null, "liam@example.com", null, true, null, "Liam Gray", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R005", null, null, null },
                    { "A015", null, null, null, null, "mia@example.com", 170f, true, null, "Mia Cyan", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, 65f },
                    { "A016", null, null, null, null, "noah@example.com", 175f, true, null, "Noah Silver", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, 70f },
                    { "A017", null, null, null, null, "olivia@example.com", 168f, true, null, "Olivia Gold", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, 55f },
                    { "A018", null, null, null, null, "william@example.com", 180f, true, null, "William Amber", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, 75f },
                    { "A019", null, null, null, null, "sophia@example.com", 165f, true, null, "Sophia Ivory", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, 50f },
                    { "A020", null, null, null, null, "james@example.com", 178f, true, null, "James Navy", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.5, null, 72f },
                    { "A021", null, null, null, null, "ava@example.com", 162f, true, null, "Ava Teal", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, 48f },
                    { "A022", null, null, null, null, "benjamin@example.com", 177f, true, null, "Benjamin Lime", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, 70f },
                    { "A023", null, null, null, null, "charlotte@example.com", 164f, true, null, "Charlotte Beige", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, 52f },
                    { "A024", null, null, null, null, "lucas@example.com", 180f, true, null, "Lucas Maroon", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, 74f },
                    { "A025", null, null, null, null, "mia@example.com", 159f, true, null, "Mia Pearl", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, 47f },
                    { "A026", null, null, null, null, "ethan@example.com", 176f, true, null, "Ethan Olive", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, 71f },
                    { "A027", null, null, null, null, "amelia@example.com", 167f, true, null, "Amelia Ruby", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, 53f },
                    { "A028", null, null, null, null, "henry@example.com", 182f, true, null, "Henry Saffron", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, 76f },
                    { "A029", null, null, null, null, "ella@example.com", 160f, true, null, "Ella Coral", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, 49f },
                    { "A030", null, null, null, null, "daniel@example.com", 175f, true, null, "Daniel Cyan", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, 72f },
                    { "A031", null, null, null, null, "logan@example.com", 180f, true, null, "Logan Indigo", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, 73f },
                    { "A032", null, null, null, null, "lily@example.com", 165f, true, null, "Lily Violet", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, 52f },
                    { "A033", null, null, null, null, "mason@example.com", 178f, true, null, "Mason Turquoise", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, 74f },
                    { "A034", null, null, null, null, "zoe@example.com", 160f, true, null, "Zoe Lavender", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, 48f },
                    { "A035", null, null, null, null, "elijah@example.com", 182f, true, null, "Elijah Crimson", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.5, null, 77f },
                    { "A036", null, null, null, null, "aria@example.com", 164f, true, null, "Aria Mint", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, 50f },
                    { "A037", null, null, null, null, "sebastian@example.com", 179f, true, null, "Sebastian Bronze", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3, null, 72f },
                    { "A038", null, null, null, null, "harper@example.com", 168f, true, null, "Harper Rose", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.2, null, 53f },
                    { "A039", null, null, null, null, "caleb@example.com", 181f, true, null, "Caleb Onyx", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.3999999999999999, null, 75f },
                    { "A040", null, null, null, null, "scarlett@example.com", 162f, true, null, "Scarlett Magenta", null, "ZkmcwLVZC7B06TE7qd/qoA==", null, "R004", 1.1000000000000001, null, 51f }
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "CategoryId", "CharacterName", "CreateDate", "Description", "IsActive", "MaxHeight", "MaxWeight", "MinHeight", "MinWeight", "Price", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { "CH001", "C3", "Naruto", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6678), "Ninja from Konoha", true, 180f, 80f, 160f, 50f, 100.0, 5, null },
                    { "CH002", "C3", "Sasuke", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6754), "Naruto’s rival", true, 185f, 85f, 165f, 55f, 120.0, 3, null },
                    { "CH003", "C3", "Goku", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6760), "Saiyan warrior", true, 190f, 90f, 170f, 60f, 150.0, 4, null },
                    { "CH004", "C4", "Luffy", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6763), "Pirate King", true, 175f, 70f, 155f, 45f, 110.0, 6, null },
                    { "CH005", "C4", "Ichigo", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6768), "Soul Reaper", true, 185f, 85f, 165f, 55f, 130.0, 3, null },
                    { "CH006", "C14", "Mario", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6772), "Plumber hero", true, 160f, 70f, 140f, 50f, 80.0, 5, null },
                    { "CH007", "C14", "Luigi", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6776), "Mario’s brother", true, 170f, 75f, 150f, 55f, 85.0, 4, null },
                    { "CH008", "C14", "Link", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6779), "Hero of Hyrule", true, 180f, 80f, 160f, 50f, 140.0, 2, null },
                    { "CH009", "C16", "Zelda", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6813), "Hyrule princess", true, 175f, 70f, 155f, 50f, 135.0, 3, null },
                    { "CH010", "C16", "Samus", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6817), "Bounty hunter", true, 185f, 85f, 165f, 55f, 145.0, 3, null },
                    { "CH011", "C13", "Cloud", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6824), "Ex-SOLDIER", true, 185f, 85f, 165f, 55f, 125.0, 3, null },
                    { "CH012", "C13", "Sephiroth", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6828), "One-Winged Angel", true, 190f, 90f, 170f, 60f, 155.0, 2, null },
                    { "CH013", "C8", "Kratos", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6832), "God of War", true, 195f, 100f, 175f, 70f, 160.0, 2, null },
                    { "CH014", "C8", "Pikachu", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6835), "Electric Pokemon", true, 50f, 20f, 30f, 10f, 90.0, 10, null },
                    { "CH015", "C8", "Kirby", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(6838), "Pink puffball", true, 60f, 25f, 40f, 15f, 95.0, 8, null }
                });

            migrationBuilder.InsertData(
                table: "EventActivity",
                columns: new[] { "EventActivityId", "ActivityId", "CreateBy", "CreateDate", "Description", "EventId", "UpdateDate" },
                values: new object[,]
                {
                    { "EA001", "ACT001", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8030), "Yoga for a fresh start", "E001", null },
                    { "EA002", "ACT005", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8032), "Tech trends in the new year", "E001", null },
                    { "EA003", "ACT004", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8034), "Painting cherry blossoms", "E002", null },
                    { "EA004", "ACT013", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8038), "AI and future coding", "E003", null },
                    { "EA005", "ACT009", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8040), "Dance battles live", "E004", null },
                    { "EA006", "ACT003", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8042), "Comic-Con live music", "E005", null },
                    { "EA007", "ACT007", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8044), "Anime and book discussions", "E006", null },
                    { "EA008", "ACT010", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8045), "Chess and gaming", "E007", null },
                    { "EA009", "ACT011", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8047), "Outdoor movie fun", "E008", null },
                    { "EA010", "ACT015", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8049), "Meditation for cosplayers", "E009", null },
                    { "EA011", "ACT012", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8051), "Science in filmmaking", "E010", null },
                    { "EA012", "ACT006", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8054), "Halloween charity run", "E011", null },
                    { "EA013", "ACT014", "Admin", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8056), "Christmas gardening", "E012", null },
                    { "EA014", "ACT002", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8058), "Cooking for music lovers", "E004", null },
                    { "EA015", "ACT008", "Manager", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8060), "Photography in tech", "E003", null }
                });

            migrationBuilder.InsertData(
                table: "EventImage",
                columns: new[] { "ImageId", "CreateDate", "EventId", "ImageUrl", "UpdateDate" },
                values: new object[,]
                {
                    { "EI001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8482), "E001", "https://example.com/event1.jpg", null },
                    { "EI002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8484), "E002", "https://example.com/event2.jpg", null },
                    { "EI003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8486), "E003", "https://example.com/event3.jpg", null },
                    { "EI004", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8487), "E004", "https://example.com/event4.jpg", null },
                    { "EI005", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8489), "E005", "https://example.com/event5.jpg", null },
                    { "EI006", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8490), "E006", "https://example.com/event6.jpg", null },
                    { "EI007", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8492), "E007", "https://example.com/event7.jpg", null },
                    { "EI008", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8493), "E008", "https://example.com/event8.jpg", null },
                    { "EI009", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8496), "E009", "https://example.com/event9.jpg", null },
                    { "EI010", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8498), "E010", "https://example.com/event10.jpg", null },
                    { "EI011", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8500), "E011", "https://example.com/event11.jpg", null },
                    { "EI012", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8501), "E012", "https://example.com/event12.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "ProductImageId", "CreateDate", "ProductId", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "IMG001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8759), "P001", null, "https://example.com/images/naruto_wig.jpg" },
                    { "IMG002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8763), "P002", null, "https://example.com/images/mario_hat.jpg" },
                    { "IMG003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8765), "P003", null, "https://example.com/images/sasuke_costume.jpg" },
                    { "IMG004", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8767), "P004", null, "https://example.com/images/zelda_sword.jpg" },
                    { "IMG005", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8768), "P005", null, "https://example.com/images/one_piece_hat.jpg" },
                    { "IMG006", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8770), "P006", null, "https://example.com/images/miku_wig.jpg" },
                    { "IMG007", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8772), "P007", null, "https://example.com/images/demon_slayer_earrings.jpg" },
                    { "IMG008", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8773), "P008", null, "https://example.com/images/aot_jacket.jpg" },
                    { "IMG009", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8775), "P009", null, "https://example.com/images/pikachu_onesie.jpg" },
                    { "IMG010", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8778), "P010", null, "https://example.com/images/buster_sword.jpg" },
                    { "IMG011", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8780), "P011", null, "https://example.com/images/genshin_vision.jpg" },
                    { "IMG012", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8782), "P012", null, "https://example.com/images/jinx_wig.jpg" },
                    { "IMG013", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8783), "P013", null, "https://example.com/images/sailor_moon_tiara.jpg" },
                    { "IMG014", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8786), "P014", null, "https://example.com/images/spiderman_suit.jpg" },
                    { "IMG015", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8787), "P015", null, "https://example.com/images/harry_potter_wand.jpg" }
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
                columns: new[] { "AccountImageId", "AccountId", "CreateDate", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "AI1", "A001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8173), null, "https://example.com/admin.jpg" },
                    { "AI10", "A010", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8190), null, "https://example.com/user8.jpg" },
                    { "AI11", "A011", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8192), null, "https://example.com/user9.jpg" },
                    { "AI12", "A012", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8193), null, "https://example.com/user10.jpg" },
                    { "AI13", "A013", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8195), null, "https://example.com/user11.jpg" },
                    { "AI14", "A014", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8198), null, "https://example.com/user12.jpg" },
                    { "AI15", "A015", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8200), null, "https://example.com/user13.jpg" },
                    { "AI2", "A002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8176), null, "https://example.com/manager.jpg" },
                    { "AI3", "A003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8177), null, "https://example.com/user1.jpg" },
                    { "AI4", "A004", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8179), null, "https://example.com/user2.jpg" },
                    { "AI5", "A005", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8181), null, "https://example.com/user3.jpg" },
                    { "AI6", "A006", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8184), null, "https://example.com/user4.jpg" },
                    { "AI7", "A007", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8185), null, "https://example.com/user5.jpg" },
                    { "AI8", "A008", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8187), null, "https://example.com/user6.jpg" },
                    { "AI9", "A009", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8189), null, "https://example.com/user7.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "AccountId", "CreateDate", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "C001", "A003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7513), 0.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7513) },
                    { "C002", "A006", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7515), 0.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7516) },
                    { "C003", "A011", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7518), 0.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7518) },
                    { "C004", "A014", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7520), 0.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7520) }
                });

            migrationBuilder.InsertData(
                table: "CharacterImage",
                columns: new[] { "CharacterImageId", "CharacterId", "CreateDate", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "CI001", "CH001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8393), null, "https://example.com/img1.jpg" },
                    { "CI002", "CH002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8396), null, "https://example.com/img2.jpg" },
                    { "CI003", "CH003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8398), null, "https://example.com/img3.jpg" },
                    { "CI004", "CH004", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8399), null, "https://example.com/img4.jpg" },
                    { "CI005", "CH005", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8401), null, "https://example.com/img5.jpg" },
                    { "CI006", "CH006", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8403), null, "https://example.com/img6.jpg" },
                    { "CI007", "CH007", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8404), null, "https://example.com/img7.jpg" },
                    { "CI008", "CH008", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8408), null, "https://example.com/img8.jpg" },
                    { "CI009", "CH009", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8410), null, "https://example.com/img9.jpg" },
                    { "CI010", "CH010", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8411), null, "https://example.com/img10.jpg" },
                    { "CI011", "CH011", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8413), null, "https://example.com/img11.jpg" },
                    { "CI012", "CH012", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8444), null, "https://example.com/img12.jpg" },
                    { "CI013", "CH013", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8445), null, "https://example.com/img13.jpg" },
                    { "CI014", "CH014", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8448), null, "https://example.com/img14.jpg" },
                    { "CI015", "CH015", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8449), null, "https://example.com/img15.jpg" }
                });

            migrationBuilder.InsertData(
                table: "EventCharacter",
                columns: new[] { "EventCharacterId", "CharacterId", "CreateDate", "Description", "EventId", "IsAssign", "UpdateDate" },
                values: new object[,]
                {
                    { "EC001", "CH001", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7962), null, "E001", true, null },
                    { "EC002", "CH002", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7967), null, "E002", true, null },
                    { "EC003", "CH003", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7969), null, "E003", true, null },
                    { "EC004", "CH004", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7972), null, "E004", true, null },
                    { "EC005", "CH005", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7974), null, "E005", true, null },
                    { "EC006", "CH006", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7976), null, "E006", true, null },
                    { "EC007", "CH007", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7978), null, "E007", true, null },
                    { "EC008", "CH008", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7981), null, "E008", true, null },
                    { "EC009", "CH009", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7986), null, "E009", true, null },
                    { "EC010", "CH010", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7989), null, "E010", true, null },
                    { "EC011", "CH011", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7991), null, "E011", true, null },
                    { "EC012", "CH012", new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7993), null, "E012", true, null }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "AccountId", "CreatedAt", "IsRead", "IsSentMail", "Message" },
                values: new object[,]
                {
                    { "N001", "A001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7450), false, true, "Welcome to the system!" },
                    { "N002", "A002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7453), false, true, "Your account has been upgraded." },
                    { "N003", "A003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7455), true, true, "New promotional offer available!" },
                    { "N004", "A004", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7459), false, true, "Your request has been approved." },
                    { "N005", "A005", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7461), true, true, "System maintenance scheduled." },
                    { "N006", "A006", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7462), false, true, "Your order has been shipped!" },
                    { "N007", "A007", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7464), false, true, "New event registration open." },
                    { "N008", "A008", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7466), true, true, "Reminder: Payment due soon." },
                    { "N009", "A009", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7468), false, true, "Your password was changed." },
                    { "N010", "A010", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7470), false, true, "Admin announcement update." },
                    { "N011", "A011", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7472), true, true, "New message from support." },
                    { "N012", "A012", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7476), false, true, "Upcoming event invitation." },
                    { "N013", "A013", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7478), false, true, "New cosplayer contest." },
                    { "N014", "A014", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7480), true, true, "Loyalty points updated." },
                    { "N015", "A015", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(7482), false, true, "Your subscription expired." }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "AccountId", "OrderDate", "OrderStatus", "TotalPrice" },
                values: new object[,]
                {
                    { "O001", "A003", "2024-03-01", 0, 250.0 },
                    { "O002", "A006", "2024-03-05", 0, 150.5 },
                    { "O003", "A011", "2024-03-10", 1, 300.0 },
                    { "O004", "A014", "2024-03-12", 0, 400.0 },
                    { "O005", "A003", "2024-03-15", 1, 175.0 },
                    { "O006", "A006", "2024-03-18", 0, 225.0 },
                    { "O007", "A011", "2024-03-20", 0, 350.0 },
                    { "O008", "A014", "2024-03-22", 1, 275.0 },
                    { "O009", "A003", "2024-03-25", 0, 500.0 },
                    { "O010", "A006", "2024-03-28", 1, 125.0 },
                    { "O011", "A011", "2024-03-30", 0, 325.0 },
                    { "O012", "A014", "2024-04-02", 0, 410.0 },
                    { "O013", "A003", "2024-04-05", 1, 280.0 },
                    { "O014", "A006", "2024-04-07", 0, 350.0 },
                    { "O015", "A011", "2024-04-10", 0, 200.0 }
                });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "RequestId", "AccountCouponId", "AccountId", "Description", "EndDate", "Location", "Name", "PackageId", "Price", "ServiceId", "StartDate", "Status" },
                values: new object[,]
                {
                    { "R001", null, "A001", "RentCostumes", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Naruto Costume", null, 100.0, "S001", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R002", null, "A002", "RentCosplayer", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ĐN", "Rent Cosplayer for Event", null, 500.0, "S002", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R003", null, "A003", "CreateEvent", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "BD", "Create Anime Festival", null, 2000.0, "S003", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R004", null, "A004", "RentCostumes", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Rent Samurai Armor", null, 150.0, "S002", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R005", null, "A005", "RentCosplayer", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "BT", "Hire Professional Cosplayer", null, 700.0, "S002", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R006", null, "A006", "CreateEvent", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Organize Comic Convention", null, 5000.0, "S001", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R007", null, "A007", "RentCostumes", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Victorian Costume", null, 120.0, "S002", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R008", null, "A008", "RentCosplayer", new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "QN", "Book Cosplayer for Birthday Party", null, 350.0, "S003", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R009", null, "A009", "CreateEvent", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CM", "Plan Fantasy Fair", null, 3000.0, "S003", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R010", null, "A010", "RentCostumes", new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "LĐ", "Rent Halloween Costumes", null, 200.0, "S001", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R011", null, "A011", "RentCosplayer", new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "NT", "Hire Cosplayer for Wedding", null, 800.0, "S001", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R012", null, "A012", "CreateEvent", new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "VT", "Create Sci-Fi Convention", null, 4500.0, "S002", new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R013", null, "A013", "RentCostumes", new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Santa Claus Costume", null, 130.0, "S003", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R014", null, "A014", "RentCosplayer", new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Book Cosplayer for Product Launch", null, 600.0, "S001", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R015", null, "A015", "CreateEvent", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Host Christmas Event", null, 5500.0, "S002", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
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
                    { "10af5217-91d5-4d29-9455-8d5ab46a501a", "C004", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8358), 35.0, "P011", 2 },
                    { "1635e715-311d-4d51-80fe-2a070d6b5bba", "C001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8330), 20.0, "P002", 1 },
                    { "381785c9-6d8e-4df9-a21c-80d570bedf48", "C004", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8356), 120.0, "P010", 1 },
                    { "49d06924-0732-45b4-bf52-13c9f8b7bf23", "C002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8337), 100.0, "P004", 1 },
                    { "4e962fcf-f7e5-41bf-8a29-0d34f23499c1", "C001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8326), 30.0, "P001", 2 },
                    { "51579ef5-ec4b-45aa-93ed-aba9e94bf333", "C002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8340), 25.0, "P005", 3 },
                    { "5b46d15c-4cc7-4ce6-8f98-0d186e9ddf53", "C003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8350), 50.0, "P008", 2 },
                    { "62a7b32f-407e-4428-9f54-caabe86251c8", "C003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8346), 15.0, "P007", 5 },
                    { "936ee3cb-7e92-4185-befb-b35eeb2ddc1c", "C002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8343), 40.0, "P006", 2 },
                    { "957ee92b-d64c-427e-85a2-e3eef6d0989f", "C003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8353), 60.0, "P009", 1 },
                    { "a4f13179-b24a-4676-b95a-7b46f3db7b6c", "C001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8333), 80.0, "P003", 1 },
                    { "eaf87be0-7263-4544-9576-a44292b73467", "C004", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8363), 45.0, "P012", 1 }
                });

            migrationBuilder.InsertData(
                table: "Contract",
                columns: new[] { "ContractId", "Amount", "ContractName", "ContractStatus", "CreateBy", "CreateDate", "Deposit", "Reason", "RequestId", "TotalPrice", "UrlPdf" },
                values: new object[,]
                {
                    { "CT002", null, "Character rental", 1, "Admin", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "100", null, "R002", 500.0, null },
                    { "CT005", null, "Character rental", 1, "Admin", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "150", null, "R005", 700.0, null },
                    { "CT008", null, "Character rental", 1, "Admin", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "70", null, "R008", 350.0, null },
                    { "CT010", null, "Character rental", 3, "Admin", new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", null, "R010", 200.0, null },
                    { "CT014", null, "Character rental", 1, "Admin", new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "120", null, "R014", 600.0, null }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0041672e-9be8-4ce7-bee8-eea4fa089ec0", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8538), "O001", 20.0, "P002", 5 },
                    { "0334984f-d925-4a76-8ae9-7678ac8dded9", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8622), "O011", 15.0, "P007", 4 },
                    { "0d931cdc-9cf6-479c-92ba-2c3dc5eb144e", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8564), "O005", 120.0, "P010", 1 },
                    { "21fddfa3-605e-4051-86f7-657862326d55", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8534), "O001", 30.0, "P001", 3 },
                    { "22af5e39-ef0c-40a8-b0c6-4f3d41b50cdf", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8576), "O007", 90.0, "P014", 2 },
                    { "26d2c57e-74ad-48c5-abb8-9e6f148ac9cb", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8608), "O009", 20.0, "P002", 6 },
                    { "3baac278-63ad-4819-9d11-2f2eec40afbe", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8617), "O010", 25.0, "P005", 3 },
                    { "3fdc58d2-cfe9-4352-8fe8-ea85844b8143", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8556), "O004", 15.0, "P007", 4 },
                    { "4c359caf-12de-4cfe-98cb-081c954a5982", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8546), "O002", 100.0, "P004", 1 },
                    { "4d668293-9083-44e4-98ee-119f21f19675", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8639), "O014", 45.0, "P012", 3 },
                    { "52009197-78af-4b3c-8089-6e665c2d1712", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8580), "O008", 22.0, "P015", 4 },
                    { "5ca5a762-b182-405e-b32c-46561d9d6a4a", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8559), "O004", 50.0, "P008", 2 },
                    { "66705d11-9525-4cf3-9ad4-2f3b066b84d2", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8549), "O003", 25.0, "P005", 2 },
                    { "77b9c4e4-e7eb-468f-b752-f2a7d00d123d", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8562), "O005", 60.0, "P009", 1 },
                    { "78ada73a-5672-4b39-ac26-fa8ee3a05d13", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8552), "O003", 40.0, "P006", 3 },
                    { "81983d36-9f08-4473-b808-35436d17b2fd", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8619), "O011", 40.0, "P006", 2 },
                    { "8aa42890-e43d-475c-928a-65f87b718638", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8626), "O012", 50.0, "P008", 2 },
                    { "8cef16ec-32d4-4a32-8bad-d454f35970f5", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8633), "O013", 35.0, "P011", 2 },
                    { "a46c89d1-b3d5-4b7a-b435-948b5c576d91", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8643), "O015", 90.0, "P014", 2 },
                    { "a738e818-df8b-4af1-8c88-d815a41ea2fe", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8610), "O009", 80.0, "P003", 2 },
                    { "ba6deb5f-6001-423b-bdc8-c6b46227858a", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8571), "O006", 45.0, "P012", 3 },
                    { "bc3f06c6-7c8a-4862-bc7d-678a25a4f62a", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8641), "O014", 18.0, "P013", 5 },
                    { "bc9d9de8-c27d-4b8a-b7ff-96019c7c17d5", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8544), "O002", 80.0, "P003", 1 },
                    { "bd41cf80-fe91-45b5-a72d-4a5a563d0a18", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8605), "O008", 30.0, "P001", 1 },
                    { "cc2863cf-2abc-44c5-838e-2adbf1691427", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8631), "O013", 120.0, "P010", 1 },
                    { "d018398f-24ff-4626-8f01-66e7429f0cef", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8568), "O006", 35.0, "P011", 2 },
                    { "db8fdf89-1b1c-4bfd-8748-e355e4f406d8", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8646), "O015", 22.0, "P015", 4 },
                    { "ea85be2b-25c8-4e13-8ded-f8df45a729b2", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8614), "O010", 100.0, "P004", 1 },
                    { "eb2e511e-81ad-4991-b40b-dfc5377f8b47", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8629), "O012", 60.0, "P009", 1 },
                    { "f806282f-d616-4ef9-aef8-dd7c582ca4ea", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8573), "O007", 18.0, "P013", 5 }
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
                    { "RC01", "CH001", "C001", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8818), "Yêu cầu cosplay nhân vật CH001", null, "R001", 50.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8818) },
                    { "RC02", "CH002", "C002", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8821), "Yêu cầu cosplay nhân vật CH002", null, "R002", 60.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8822) },
                    { "RC03", "CH003", "C003", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8826), "Yêu cầu cosplay nhân vật CH003", null, "R003", 70.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8826) },
                    { "RC04", "CH004", "C004", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8828), "Yêu cầu cosplay nhân vật CH004", null, "R004", 80.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8829) },
                    { "RC05", "CH005", "C005", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8831), "Yêu cầu cosplay nhân vật CH005", null, "R005", 90.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8831) },
                    { "RC06", "CH006", "C006", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8834), "Yêu cầu cosplay nhân vật CH006", null, "R006", 100.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8834) },
                    { "RC07", "CH007", "C007", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8836), "Yêu cầu cosplay nhân vật CH007", null, "R007", 110.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8837) },
                    { "RC08", "CH008", "C008", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8839), "Yêu cầu cosplay nhân vật CH008", null, "R008", 120.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8839) },
                    { "RC09", "CH009", "C009", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8841), "Yêu cầu cosplay nhân vật CH009", null, "R009", 130.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8842) },
                    { "RC10", "CH010", "C010", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8844), "Yêu cầu cosplay nhân vật CH010", null, "R010", 140.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8844) },
                    { "RC11", "CH011", "C011", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8848), "Yêu cầu cosplay nhân vật CH011", null, "R011", 150.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8848) },
                    { "RC12", "CH012", "C012", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8851), "Yêu cầu cosplay nhân vật CH012", null, "R012", 160.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8851) },
                    { "RC13", "CH013", "C013", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8853), "Yêu cầu cosplay nhân vật CH013", null, "R013", 170.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8853) },
                    { "RC14", "CH014", "C014", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8855), "Yêu cầu cosplay nhân vật CH014", null, "R014", 180.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8856) },
                    { "RC15", "CH015", "C015", new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8858), "Yêu cầu cosplay nhân vật CH015", null, "R015", 190.0, new DateTime(2025, 3, 22, 16, 7, 33, 351, DateTimeKind.Utc).AddTicks(8859) }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "AccountId", "ContractCharacterId", "CreateDate", "Description", "EndDate", "EventCharacterId", "IsActive", "Location", "StartDate", "Status", "TaskName", "Type", "UpdateDate" },
                values: new object[,]
                {
                    { "T001", "A001", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7695), "Cosplay as anime characters", new DateTime(2025, 3, 25, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7694), "EC001", true, "Tokyo", new DateTime(2025, 3, 24, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7676), 0, "Perform at Anime Fest", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7695) },
                    { "T002", "A004", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7703), "Join cosplay contest", new DateTime(2025, 3, 27, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7702), "EC002", true, "Los Angeles", new DateTime(2025, 3, 26, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7701), 1, "Comic Con Appearance", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7703) },
                    { "T003", "A005", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7710), "Teach costume making", new DateTime(2025, 3, 29, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7707), "EC003", true, "New York", new DateTime(2025, 3, 28, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7706), 2, "Cosplay Workshop", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7710) },
                    { "T004", "A007", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7714), "Host a live event", new DateTime(2025, 3, 23, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7713), "EC004", true, "Online", new DateTime(2025, 3, 23, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7712), 3, "Live Stream Cosplay", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7715) },
                    { "T005", "A008", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7719), "Professional cosplay photoshoot", new DateTime(2025, 3, 31, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7718), "EC005", true, "Paris", new DateTime(2025, 3, 30, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7717), 0, "Photoshoot Session", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7720) },
                    { "T006", "A010", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7724), "Evaluate contestants", new DateTime(2025, 4, 2, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7723), "EC006", true, "Berlin", new DateTime(2025, 4, 1, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7722), 1, "Guest Judge at Cosplay Contest", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7724) },
                    { "T007", "A012", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7728), "Walk in parade", new DateTime(2025, 4, 4, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7727), "EC007", true, "Seoul", new DateTime(2025, 4, 3, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7726), 2, "Cosplay Parade", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7728) },
                    { "T008", "A013", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7732), "Perform on live TV", new DateTime(2025, 4, 6, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7731), "EC008", true, "London", new DateTime(2025, 4, 5, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7731), 3, "TV Show Cosplay Segment", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7732) },
                    { "T009", "A015", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7737), "Perform for charity", new DateTime(2025, 4, 8, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7735), "EC009", true, "Sydney", new DateTime(2025, 4, 7, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7735), 4, "Cosplay Charity Event", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7737) },
                    { "T010", "A005", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7743), "Talk about cosplay industry", new DateTime(2025, 4, 10, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7743), "EC010", true, "San Diego", new DateTime(2025, 4, 9, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7742), 0, "Cosplay Panel Discussion", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7744) },
                    { "T011", "A008", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7747), "New character shoot", new DateTime(2025, 4, 12, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7747), "EC011", true, "Bangkok", new DateTime(2025, 4, 11, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7746), 1, "Cosplay Photoshoot", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7748) },
                    { "T012", "A007", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7776), "Host main event", new DateTime(2025, 4, 14, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7775), "EC012", true, "Jakarta", new DateTime(2025, 4, 13, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7774), 2, "Anime Convention Hosting", null, new DateTime(2025, 3, 22, 23, 7, 33, 351, DateTimeKind.Local).AddTicks(7776) }
                });

            migrationBuilder.InsertData(
                table: "ContractCharacter",
                columns: new[] { "ContractCharacterId", "CharacterId", "ContractId", "CosplayerId", "CreateDate", "Description", "Quantity", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "CC0021", "CH001", "CT002", null, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT002", null, 150.0, null },
                    { "CC0022", "CH002", "CT002", null, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT002", null, 180.0, null },
                    { "CC0023", "CH003", "CT002", null, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT002", null, 170.0, null },
                    { "CC0051", "CH004", "CT005", null, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT005", null, 200.0, null },
                    { "CC0052", "CH005", "CT005", null, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT005", null, 250.0, null },
                    { "CC0053", "CH006", "CT005", null, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT005", null, 250.0, null },
                    { "CC0081", "CH007", "CT008", null, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT008", null, 120.0, null },
                    { "CC0082", "CH008", "CT008", null, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT008", null, 130.0, null },
                    { "CC0083", "CH009", "CT008", null, new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT008", null, 100.0, null },
                    { "CC0101", "CH010", "CT010", null, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT010", null, 70.0, null },
                    { "CC0102", "CH011", "CT010", null, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT010", null, 80.0, null },
                    { "CC0103", "CH012", "CT010", null, new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT010", null, 50.0, null },
                    { "CC0141", "CH013", "CT014", null, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT014", null, 200.0, null },
                    { "CC0142", "CH014", "CT014", null, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT014", null, 250.0, null },
                    { "CC0143", "CH015", "CT014", null, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT014", null, 150.0, null }
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
                    { "5fc95e83-b988-4d91-84f4-78d150e4415f", "A007", "CC0051", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", null, null },
                    { "6a681926-3928-432c-bbd7-6ef0b547f66b", "A008", "CC0052", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", null, null },
                    { "857dd2c8-eaea-4fee-923a-b23fbbdd53d3", "A015", "CC0083", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", null, null },
                    { "8c797987-30b1-4b01-81e9-fbe9a451304f", "A001", "CC0021", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", null, null },
                    { "9b38c18d-3a7d-48da-9af0-7d71f8052a81", "A005", "CC0023", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", null, null },
                    { "da1f28b7-336d-4c8d-af0b-88fff249a482", "A004", "CC0022", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", null, null },
                    { "dc91670d-8905-4816-9a7d-05ab54950044", "A010", "CC0053", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", null, null },
                    { "eca45e64-6187-47e6-b7b4-3abf738c2ce1", "A013", "CC0082", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", null, null },
                    { "f9f02bbe-76ca-4da5-b3d0-3a7776d059ab", "A012", "CC0081", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", null, null }
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
