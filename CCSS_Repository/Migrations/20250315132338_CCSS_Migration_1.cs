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
                name: "Package",
                columns: table => new
                {
                    PackageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Package_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId");
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
                    Description = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_Feedback_Contract_ContractId",
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
                    EventCharacterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    { "ACT001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8228), "A relaxing yoga session", "Yoga Class", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8228) },
                    { "ACT002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8230), "Learn to cook delicious meals", "Cooking Workshop", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8231) },
                    { "ACT003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8233), "Live music performance", "Music Concert", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8234) },
                    { "ACT004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8236), "Showcase of local artists", "Art Exhibition", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8237) },
                    { "ACT005", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8239), "Discussion on latest technology trends", "Tech Talk", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8239) },
                    { "ACT006", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8241), "5K run for a good cause", "Charity Run", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8241) },
                    { "ACT007", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8243), "Monthly book discussion", "Book Club", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8243) },
                    { "ACT008", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8247), "Learn photography skills", "Photography Workshop", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8247) },
                    { "ACT009", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8248), "Dance battle for all ages", "Dance Competition", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8249) },
                    { "ACT010", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8252), "Competitive chess matches", "Chess Tournament", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8252) },
                    { "ACT011", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8254), "Outdoor movie screening", "Movie Night", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8254) },
                    { "ACT012", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8256), "Showcase of scientific projects", "Science Fair", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8256) },
                    { "ACT013", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8258), "Intensive coding workshop", "Coding Bootcamp", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8258) },
                    { "ACT014", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8261), "Learn gardening techniques", "Gardening Workshop", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8261) },
                    { "ACT015", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8264), "Guided meditation practice", "Meditation Session", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8264) }
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
                    { "E001", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7113), "A grand celebration to welcome the new year", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Year Festival", true, "Times Square, New York", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E002", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7118), "Experience the beauty of cherry blossoms", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring Blossom Fest", true, "Kyoto, Japan", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E003", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7120), "Showcasing the latest in technology and AI", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Innovation Summit", true, "Silicon Valley", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E004", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7123), "Live performances from top artists", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music Fest", true, "Coachella, California", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E005", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7125), "A must-attend event for comic book fans", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comic-Con International", true, "San Diego Convention Center", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E006", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7152), "Largest anime convention in the world", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anime Expo", true, "Los Angeles Convention Center", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E007", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7154), "Latest trends and releases in gaming", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Expo", true, "Las Vegas Convention Center", new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E008", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7157), "A fun-filled summer celebration", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Festival", true, "Miami Beach, Florida", new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E009", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7160), "A paradise for cosplayers", new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosplay Festival", true, "Tokyo Big Sight", new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E010", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7163), "Showcasing the best movies of the year", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Festival", true, "Cannes, France", new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E011", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7165), "Spooky celebrations and costume parties", new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween Night", true, "Salem, Massachusetts", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E012", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7168), "Festive shopping and holiday cheer", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Market", true, "Nuremberg, Germany", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreateDate", "Description", "IsActive", "Price", "ProductName", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { "P001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7019), "A wig for Naruto cosplay", true, 30.0, "Naruto Wig", 10, null },
                    { "P002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7026), "A hat for Mario cosplay", true, 20.0, "Mario Hat", 15, null },
                    { "P003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7032), "Complete costume for Sasuke cosplay", true, 80.0, "Sasuke Costume", 5, null },
                    { "P004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7035), "Replica sword from The Legend of Zelda", true, 100.0, "Zelda Sword", 7, null },
                    { "P005", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7040), "Iconic straw hat from One Piece", true, 25.0, "One Piece Straw Hat", 20, null },
                    { "P006", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7043), "Hatsune Miku blue twin-tail wig", true, 40.0, "Miku Wig", 12, null },
                    { "P007", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7050), "Tanjiro's iconic hanafuda earrings", true, 15.0, "Demon Slayer Earrings", 30, null },
                    { "P008", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7054), "Survey Corps uniform jacket", true, 50.0, "Attack on Titan Jacket", 10, null },
                    { "P009", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7057), "Cozy Pikachu-themed onesie", true, 60.0, "Pikachu Onesie", 8, null },
                    { "P010", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7060), "Final Fantasy VII replica sword", true, 120.0, "Cloud's Buster Sword", 4, null },
                    { "P011", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7064), "LED Vision accessory from Genshin Impact", true, 35.0, "Genshin Impact Vision", 25, null },
                    { "P012", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7067), "Jinx cosplay wig from Arcane", true, 45.0, "Jinx Wig", 6, null },
                    { "P013", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7072), "Golden tiara from Sailor Moon", true, 18.0, "Sailor Moon Tiara", 15, null },
                    { "P014", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7075), "High-quality Spider-Man suit", true, 90.0, "Spider-Man Suit", 3, null },
                    { "P015", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7078), "Replica wand from Harry Potter series", true, 22.0, "Harry Potter Wand", 50, null }
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
                    { "S001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6950), "Rent characters for events and parties", "Character Rental", null },
                    { "S002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6981), "Live cosplay performances at events", "Cosplay Performance", null },
                    { "S003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6985), "Professional photoshoot with cosplayers", "Photography Session", null },
                    { "S004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6987), "Selling exclusive cosplay-related merchandise", "Merchandise Selling", null },
                    { "S005", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6990), "Cosplay and makeup training sessions", "Workshop & Training", null }
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
                    { "CH001", "C3", "Naruto", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6867), "Ninja from Konoha", true, 180f, 80f, 160f, 50f, 100.0, 5, null },
                    { "CH002", "C3", "Sasuke", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6874), "Naruto’s rival", true, 185f, 85f, 165f, 55f, 120.0, 3, null },
                    { "CH003", "C3", "Goku", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6877), "Saiyan warrior", true, 190f, 90f, 170f, 60f, 150.0, 4, null },
                    { "CH004", "C4", "Luffy", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6883), "Pirate King", true, 175f, 70f, 155f, 45f, 110.0, 6, null },
                    { "CH005", "C4", "Ichigo", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6887), "Soul Reaper", true, 185f, 85f, 165f, 55f, 130.0, 3, null },
                    { "CH006", "C14", "Mario", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6891), "Plumber hero", true, 160f, 70f, 140f, 50f, 80.0, 5, null },
                    { "CH007", "C14", "Luigi", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6895), "Mario’s brother", true, 170f, 75f, 150f, 55f, 85.0, 4, null },
                    { "CH008", "C14", "Link", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6899), "Hero of Hyrule", true, 180f, 80f, 160f, 50f, 140.0, 2, null },
                    { "CH009", "C16", "Zelda", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6902), "Hyrule princess", true, 175f, 70f, 155f, 50f, 135.0, 3, null },
                    { "CH010", "C16", "Samus", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6905), "Bounty hunter", true, 185f, 85f, 165f, 55f, 145.0, 3, null },
                    { "CH011", "C13", "Cloud", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6909), "Ex-SOLDIER", true, 185f, 85f, 165f, 55f, 125.0, 3, null },
                    { "CH012", "C13", "Sephiroth", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6914), "One-Winged Angel", true, 190f, 90f, 170f, 60f, 155.0, 2, null },
                    { "CH013", "C8", "Kratos", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6917), "God of War", true, 195f, 100f, 175f, 70f, 160.0, 2, null },
                    { "CH014", "C8", "Pikachu", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6920), "Electric Pokemon", true, 50f, 20f, 30f, 10f, 90.0, 10, null },
                    { "CH015", "C8", "Kirby", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(6924), "Pink puffball", true, 60f, 25f, 40f, 15f, 95.0, 8, null }
                });

            migrationBuilder.InsertData(
                table: "EventActivity",
                columns: new[] { "EventActivityId", "ActivityId", "CreateBy", "CreateDate", "Description", "EventId", "UpdateDate" },
                values: new object[,]
                {
                    { "EA001", "ACT001", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8035), "Yoga for a fresh start", "E001", null },
                    { "EA002", "ACT005", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8037), "Tech trends in the new year", "E001", null },
                    { "EA003", "ACT004", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8039), "Painting cherry blossoms", "E002", null },
                    { "EA004", "ACT013", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8041), "AI and future coding", "E003", null },
                    { "EA005", "ACT009", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8044), "Dance battles live", "E004", null },
                    { "EA006", "ACT003", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8046), "Comic-Con live music", "E005", null },
                    { "EA007", "ACT007", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8048), "Anime and book discussions", "E006", null },
                    { "EA008", "ACT010", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8049), "Chess and gaming", "E007", null },
                    { "EA009", "ACT011", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8051), "Outdoor movie fun", "E008", null },
                    { "EA010", "ACT015", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8053), "Meditation for cosplayers", "E009", null },
                    { "EA011", "ACT012", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8055), "Science in filmmaking", "E010", null },
                    { "EA012", "ACT006", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8057), "Halloween charity run", "E011", null },
                    { "EA013", "ACT014", "Admin", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8060), "Christmas gardening", "E012", null },
                    { "EA014", "ACT002", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8062), "Cooking for music lovers", "E004", null },
                    { "EA015", "ACT008", "Manager", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8064), "Photography in tech", "E003", null }
                });

            migrationBuilder.InsertData(
                table: "EventImage",
                columns: new[] { "ImageId", "CreateDate", "EventId", "ImageUrl", "UpdateDate" },
                values: new object[,]
                {
                    { "EI001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8441), "E001", "https://example.com/event1.jpg", null },
                    { "EI002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8444), "E002", "https://example.com/event2.jpg", null },
                    { "EI003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8446), "E003", "https://example.com/event3.jpg", null },
                    { "EI004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8447), "E004", "https://example.com/event4.jpg", null },
                    { "EI005", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8449), "E005", "https://example.com/event5.jpg", null },
                    { "EI006", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8450), "E006", "https://example.com/event6.jpg", null },
                    { "EI007", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8452), "E007", "https://example.com/event7.jpg", null },
                    { "EI008", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8453), "E008", "https://example.com/event8.jpg", null },
                    { "EI009", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8455), "E009", "https://example.com/event9.jpg", null },
                    { "EI010", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8458), "E010", "https://example.com/event10.jpg", null },
                    { "EI011", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8459), "E011", "https://example.com/event11.jpg", null },
                    { "EI012", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8461), "E012", "https://example.com/event12.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "PackageId", "Description", "PackageName", "Price", "ServiceId" },
                values: new object[,]
                {
                    { "PKG001", "Rent a single character for an event", "Basic Character Rental", 100.0, "S001" },
                    { "PKG002", "Rent multiple characters with costumes", "Deluxe Character Rental", 250.0, "S001" },
                    { "PKG003", "Full-day character rental service", "Ultimate Character Rental", 500.0, "S001" },
                    { "PKG004", "Basic cosplay performance at an event", "Standard Cosplay Performance", 150.0, "S002" },
                    { "PKG005", "Advanced performance with choreography", "Premium Cosplay Performance", 300.0, "S002" },
                    { "PKG006", "Exclusive show with audience interaction", "VIP Cosplay Performance", 500.0, "S002" },
                    { "PKG007", "30-minute photoshoot with cosplayers", "Mini Photography Session", 80.0, "S003" },
                    { "PKG008", "1-hour professional photoshoot", "Standard Photography Session", 150.0, "S003" },
                    { "PKG009", "Complete photoshoot with editing", "Full Photography Package", 300.0, "S003" },
                    { "PKG010", "Includes exclusive cosplay merchandise", "Basic Merchandise Pack", 50.0, "S004" },
                    { "PKG011", "Premium cosplay collectibles", "Deluxe Merchandise Pack", 150.0, "S004" },
                    { "PKG012", "Limited edition cosplay items", "Ultimate Merchandise Pack", 300.0, "S004" },
                    { "PKG013", "Beginner-friendly cosplay training", "Cosplay Basics Workshop", 100.0, "S005" },
                    { "PKG014", "In-depth cosplay and makeup course", "Advanced Cosplay Training", 250.0, "S005" },
                    { "PKG015", "Professional-level training for cosplayers", "Master Cosplay Workshop", 500.0, "S005" }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "ProductImageId", "CreateDate", "ProductId", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "IMG001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8690), "P001", null, "https://example.com/images/naruto_wig.jpg" },
                    { "IMG002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8692), "P002", null, "https://example.com/images/mario_hat.jpg" },
                    { "IMG003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8695), "P003", null, "https://example.com/images/sasuke_costume.jpg" },
                    { "IMG004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8697), "P004", null, "https://example.com/images/zelda_sword.jpg" },
                    { "IMG005", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8698), "P005", null, "https://example.com/images/one_piece_hat.jpg" },
                    { "IMG006", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8700), "P006", null, "https://example.com/images/miku_wig.jpg" },
                    { "IMG007", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8702), "P007", null, "https://example.com/images/demon_slayer_earrings.jpg" },
                    { "IMG008", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8703), "P008", null, "https://example.com/images/aot_jacket.jpg" },
                    { "IMG009", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8705), "P009", null, "https://example.com/images/pikachu_onesie.jpg" },
                    { "IMG010", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8706), "P010", null, "https://example.com/images/buster_sword.jpg" },
                    { "IMG011", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8710), "P011", null, "https://example.com/images/genshin_vision.jpg" },
                    { "IMG012", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8711), "P012", null, "https://example.com/images/jinx_wig.jpg" },
                    { "IMG013", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8713), "P013", null, "https://example.com/images/sailor_moon_tiara.jpg" },
                    { "IMG014", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8714), "P014", null, "https://example.com/images/spiderman_suit.jpg" },
                    { "IMG015", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8716), "P015", null, "https://example.com/images/harry_potter_wand.jpg" }
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
                    { "AI1", "A001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8149), null, "https://example.com/admin.jpg" },
                    { "AI10", "A010", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8189), null, "https://example.com/user8.jpg" },
                    { "AI11", "A011", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8191), null, "https://example.com/user9.jpg" },
                    { "AI12", "A012", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8192), null, "https://example.com/user10.jpg" },
                    { "AI13", "A013", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8194), null, "https://example.com/user11.jpg" },
                    { "AI14", "A014", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8196), null, "https://example.com/user12.jpg" },
                    { "AI15", "A015", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8199), null, "https://example.com/user13.jpg" },
                    { "AI2", "A002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8151), null, "https://example.com/manager.jpg" },
                    { "AI3", "A003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8152), null, "https://example.com/user1.jpg" },
                    { "AI4", "A004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8176), null, "https://example.com/user2.jpg" },
                    { "AI5", "A005", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8180), null, "https://example.com/user3.jpg" },
                    { "AI6", "A006", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8181), null, "https://example.com/user4.jpg" },
                    { "AI7", "A007", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8185), null, "https://example.com/user5.jpg" },
                    { "AI8", "A008", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8186), null, "https://example.com/user6.jpg" },
                    { "AI9", "A009", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8188), null, "https://example.com/user7.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "AccountId", "CreateDate", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "C001", "A003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7576), 0.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7576) },
                    { "C002", "A006", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7578), 0.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7579) },
                    { "C003", "A011", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7581), 0.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7581) },
                    { "C004", "A014", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7583), 0.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7583) }
                });

            migrationBuilder.InsertData(
                table: "CharacterImage",
                columns: new[] { "CharacterImageId", "CharacterId", "CreateDate", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "CI001", "CH001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8391), null, "https://example.com/img1.jpg" },
                    { "CI002", "CH002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8393), null, "https://example.com/img2.jpg" },
                    { "CI003", "CH003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8395), null, "https://example.com/img3.jpg" },
                    { "CI004", "CH004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8397), null, "https://example.com/img4.jpg" },
                    { "CI005", "CH005", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8398), null, "https://example.com/img5.jpg" },
                    { "CI006", "CH006", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8400), null, "https://example.com/img6.jpg" },
                    { "CI007", "CH007", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8401), null, "https://example.com/img7.jpg" },
                    { "CI008", "CH008", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8403), null, "https://example.com/img8.jpg" },
                    { "CI009", "CH009", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8406), null, "https://example.com/img9.jpg" },
                    { "CI010", "CH010", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8407), null, "https://example.com/img10.jpg" },
                    { "CI011", "CH011", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8409), null, "https://example.com/img11.jpg" },
                    { "CI012", "CH012", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8410), null, "https://example.com/img12.jpg" },
                    { "CI013", "CH013", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8412), null, "https://example.com/img13.jpg" },
                    { "CI014", "CH014", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8414), null, "https://example.com/img14.jpg" },
                    { "CI015", "CH015", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8415), null, "https://example.com/img15.jpg" }
                });

            migrationBuilder.InsertData(
                table: "EventCharacter",
                columns: new[] { "EventCharacterId", "CharacterId", "CreateDate", "Description", "EventId", "IsAssign", "UpdateDate" },
                values: new object[,]
                {
                    { "EC001", "CH001", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7958), null, "E001", true, null },
                    { "EC002", "CH002", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7963), null, "E002", true, null },
                    { "EC003", "CH003", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7965), null, "E003", true, null },
                    { "EC004", "CH004", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7967), null, "E004", true, null },
                    { "EC005", "CH005", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7968), null, "E005", true, null },
                    { "EC006", "CH006", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7970), null, "E006", true, null },
                    { "EC007", "CH007", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7972), null, "E007", true, null },
                    { "EC008", "CH008", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7974), null, "E008", true, null },
                    { "EC009", "CH009", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7977), null, "E009", true, null },
                    { "EC010", "CH010", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7980), null, "E010", true, null },
                    { "EC011", "CH011", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7982), null, "E011", true, null },
                    { "EC012", "CH012", new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7984), null, "E012", true, null }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "AccountId", "CreatedAt", "IsRead", "Message" },
                values: new object[,]
                {
                    { "N001", "A001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7519), false, "Welcome to the system!" },
                    { "N002", "A002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7522), false, "Your account has been upgraded." },
                    { "N003", "A003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7524), true, "New promotional offer available!" },
                    { "N004", "A004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7525), false, "Your request has been approved." },
                    { "N005", "A005", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7529), true, "System maintenance scheduled." },
                    { "N006", "A006", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7531), false, "Your order has been shipped!" },
                    { "N007", "A007", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7533), false, "New event registration open." },
                    { "N008", "A008", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7534), true, "Reminder: Payment due soon." },
                    { "N009", "A009", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7536), false, "Your password was changed." },
                    { "N010", "A010", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7538), false, "Admin announcement update." },
                    { "N011", "A011", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7540), true, "New message from support." },
                    { "N012", "A012", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7542), false, "Upcoming event invitation." },
                    { "N013", "A013", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7545), false, "New cosplayer contest." },
                    { "N014", "A014", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7547), true, "Loyalty points updated." },
                    { "N015", "A015", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(7548), false, "Your subscription expired." }
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
                columns: new[] { "RequestId", "AccountCouponId", "AccountId", "ContractId", "Description", "EndDate", "Location", "Name", "Price", "ServiceId", "StartDate", "Status" },
                values: new object[,]
                {
                    { "R001", null, "A001", "CT001", 0, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Naruto Costume", 100.0, "S001", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R002", null, "A002", "CT002", 1, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ĐN", "Rent Cosplayer for Event", 500.0, "S002", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R003", null, "A003", "CT003", 2, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "BD", "Create Anime Festival", 2000.0, "S003", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R004", null, "A004", "CT004", 0, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Rent Samurai Armor", 150.0, "S004", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R005", null, "A005", "CT005", 1, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "BT", "Hire Professional Cosplayer", 700.0, "S005", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R006", null, "A006", "CT006", 2, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Organize Comic Convention", 5000.0, "S001", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R007", null, "A007", "CT007", 0, new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Victorian Costume", 120.0, "S002", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R008", null, "A008", "CT008", 1, new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "QN", "Book Cosplayer for Birthday Party", 350.0, "S003", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R009", null, "A009", "CT009", 2, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CM", "Plan Fantasy Fair", 3000.0, "S004", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R010", null, "A010", "CT010", 0, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "LĐ", "Rent Halloween Costumes", 200.0, "S005", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R011", null, "A011", "CT011", 1, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "NT", "Hire Cosplayer for Wedding", 800.0, "S001", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R012", null, "A012", "CT012", 2, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "VT", "Create Sci-Fi Convention", 4500.0, "S002", new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R013", null, "A013", "CT013", 0, new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Santa Claus Costume", 130.0, "S003", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R014", null, "A014", "CT014", 1, new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Book Cosplayer for Product Launch", 600.0, "S004", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R015", null, "A015", "CT015", 2, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Host Christmas Event", 5500.0, "S005", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
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
                    { "216c9331-d512-4c07-8a61-cc85a3c4e91a", "C004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8361), 45.0, "P012", 1 },
                    { "3ce6fe97-5b85-42ce-8bfa-d65e4d3524a1", "C001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8306), 80.0, "P003", 1 },
                    { "5f022f30-1220-4b46-b99d-8ec436dd6cfb", "C001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8303), 20.0, "P002", 1 },
                    { "78876ba3-507c-49c9-831c-962e8c19a598", "C002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8314), 25.0, "P005", 3 },
                    { "879ddb34-a9eb-42ac-b04f-c1f6d1f99e4c", "C001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8295), 30.0, "P001", 2 },
                    { "c4cc7ae2-9551-4bfb-b873-0efab3fda057", "C003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8351), 60.0, "P009", 1 },
                    { "d331c684-d384-4522-ba04-5a77776fc4ac", "C004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8357), 35.0, "P011", 2 },
                    { "dc3bc23c-4308-42b0-b8bb-c1e33dcc2caa", "C002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8317), 40.0, "P006", 2 },
                    { "dde0cc74-9533-4ab1-a397-740bcd01ce73", "C003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8346), 50.0, "P008", 2 },
                    { "e5a27dd6-43ed-4f8b-bd1a-62487686cbfc", "C002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8309), 100.0, "P004", 1 },
                    { "f0854555-ab37-4e7b-adb3-33b400e595c9", "C004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8354), 120.0, "P010", 1 },
                    { "f99949af-9048-4895-860f-ff03e9d1a32b", "C003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8343), 15.0, "P007", 5 }
                });

            migrationBuilder.InsertData(
                table: "Contract",
                columns: new[] { "ContractId", "Amount", "ContractStatus", "CreateBy", "CreateDate", "Deposit", "RequestId", "TotalPrice", "UrlPdf" },
                values: new object[,]
                {
                    { "CT002", null, 1, "Admin", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "100", "R002", 500.0, null },
                    { "CT005", null, 1, "Admin", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "150", "R005", 700.0, null },
                    { "CT008", null, 1, "Admin", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "70", "R008", 350.0, null },
                    { "CT010", null, 3, "Admin", new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", "R010", 200.0, null },
                    { "CT014", null, 1, "Admin", new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "120", "R014", 600.0, null }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0895f568-362c-4fab-abb5-110fd23cde46", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8545), "O007", 18.0, "P013", 5 },
                    { "19a889ac-b8f6-473d-ab6a-71d83cdcbffa", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8512), "O001", 20.0, "P002", 5 },
                    { "22aff957-a0e1-451d-a25d-4159ac1c2398", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8558), "O009", 80.0, "P003", 2 },
                    { "382b8c4b-fc65-4c7e-87b0-94cb7ef4a13c", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8588), "O015", 90.0, "P014", 2 },
                    { "3a023da0-78ab-4643-861c-5e3bfa690fb8", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8540), "O006", 35.0, "P011", 2 },
                    { "3d481a02-5f56-4ff2-ad73-acfe9294370f", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8534), "O005", 60.0, "P009", 1 },
                    { "4a39d04a-6ffe-410b-801a-6bdcdd4d2d16", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8547), "O007", 90.0, "P014", 2 },
                    { "61b6d7d7-ccbb-4c12-8741-4cddc1bfacb2", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8516), "O002", 80.0, "P003", 1 },
                    { "66b92d14-affe-45a3-acd8-648c5abd8f2d", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8578), "O013", 120.0, "P010", 1 },
                    { "675de58d-a16d-46e6-8359-6206888427f5", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8521), "O003", 25.0, "P005", 2 },
                    { "6d927d50-d0d8-46f1-ad1e-3859f57c3eca", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8508), "O001", 30.0, "P001", 3 },
                    { "778e5671-deeb-410b-8cd0-2fbd25cb346b", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8564), "O010", 25.0, "P005", 3 },
                    { "79e79426-90a3-43f0-89ac-39b3a06b45da", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8569), "O011", 15.0, "P007", 4 },
                    { "7a07b0a0-f501-42e5-90bf-1cc4ddd3d48e", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8566), "O011", 40.0, "P006", 2 },
                    { "7ecca7c7-a67c-4c8c-a6c3-21a5dffdc04e", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8573), "O012", 50.0, "P008", 2 },
                    { "7fb5afc8-7a56-44c8-a90c-6b532e802cf8", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8584), "O014", 45.0, "P012", 3 },
                    { "849112e9-e2e7-4627-81b4-7b68ed2addc2", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8556), "O009", 20.0, "P002", 6 },
                    { "89d1ada9-ca4b-4843-b59a-34d2cafdb15a", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8531), "O004", 50.0, "P008", 2 },
                    { "8ac4a2d4-9f5f-46a8-bd71-f201da9378b7", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8604), "O015", 22.0, "P015", 4 },
                    { "9323fdd0-c6c5-45ad-aead-eb8032b3a9ee", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8536), "O005", 120.0, "P010", 1 },
                    { "9b825f9b-f3c7-41ed-8243-b2c815a18167", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8529), "O004", 15.0, "P007", 4 },
                    { "a4ca2c33-700d-4243-9fc4-e275bc6aa6b1", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8519), "O002", 100.0, "P004", 1 },
                    { "a73b3abb-29b1-4c2f-bef7-e0b810d77f13", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8562), "O010", 100.0, "P004", 1 },
                    { "b08003a4-325d-4f42-9f5c-3a24f7028bfe", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8553), "O008", 30.0, "P001", 1 },
                    { "bacce133-07e9-4e3d-b3b2-52c911f0f7d9", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8551), "O008", 22.0, "P015", 4 },
                    { "cfc82a16-cdc8-4e6f-9fee-4e814de201ec", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8586), "O014", 18.0, "P013", 5 },
                    { "d79ae459-7521-44df-81ca-255a12e0c81a", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8525), "O003", 40.0, "P006", 3 },
                    { "ddeb462b-73d3-4c3f-8feb-5d0707d9e29e", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8575), "O012", 60.0, "P009", 1 },
                    { "f794adae-6c21-45b6-863a-3ca2720a214d", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8542), "O006", 45.0, "P012", 3 },
                    { "fd5ba95e-48af-41db-b193-6424f9146571", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8580), "O013", 35.0, "P011", 2 }
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
                    { "RC01", "CH001", "C001", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8745), "Yêu cầu cosplay nhân vật CH001", null, "R001", 50.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8746) },
                    { "RC02", "CH002", "C002", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8800), "Yêu cầu cosplay nhân vật CH002", null, "R002", 60.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8800) },
                    { "RC03", "CH003", "C003", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8803), "Yêu cầu cosplay nhân vật CH003", null, "R003", 70.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8803) },
                    { "RC04", "CH004", "C004", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8807), "Yêu cầu cosplay nhân vật CH004", null, "R004", 80.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8808) },
                    { "RC05", "CH005", "C005", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8811), "Yêu cầu cosplay nhân vật CH005", null, "R005", 90.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8811) },
                    { "RC06", "CH006", "C006", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8814), "Yêu cầu cosplay nhân vật CH006", null, "R006", 100.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8814) },
                    { "RC07", "CH007", "C007", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8816), "Yêu cầu cosplay nhân vật CH007", null, "R007", 110.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8817) },
                    { "RC08", "CH008", "C008", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8819), "Yêu cầu cosplay nhân vật CH008", null, "R008", 120.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8819) },
                    { "RC09", "CH009", "C009", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8822), "Yêu cầu cosplay nhân vật CH009", null, "R009", 130.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8822) },
                    { "RC10", "CH010", "C010", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8824), "Yêu cầu cosplay nhân vật CH010", null, "R010", 140.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8825) },
                    { "RC11", "CH011", "C011", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8827), "Yêu cầu cosplay nhân vật CH011", null, "R011", 150.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8827) },
                    { "RC12", "CH012", "C012", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8832), "Yêu cầu cosplay nhân vật CH012", null, "R012", 160.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8832) },
                    { "RC13", "CH013", "C013", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8835), "Yêu cầu cosplay nhân vật CH013", null, "R013", 170.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8835) },
                    { "RC14", "CH014", "C014", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8837), "Yêu cầu cosplay nhân vật CH014", null, "R014", 180.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8838) },
                    { "RC15", "CH015", "C015", new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8840), "Yêu cầu cosplay nhân vật CH015", null, "R015", 190.0, new DateTime(2025, 3, 15, 13, 23, 37, 769, DateTimeKind.Utc).AddTicks(8840) }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "AccountId", "ContractCharacterId", "CreateDate", "Description", "EndDate", "EventCharacterId", "IsActive", "Location", "StartDate", "Status", "TaskName", "Type", "UpdateDate" },
                values: new object[,]
                {
                    { "T001", "A001", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7726), "Cosplay as anime characters", new DateTime(2025, 3, 18, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7725), "EC001", true, "Tokyo", new DateTime(2025, 3, 17, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7711), 0, "Perform at Anime Fest", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7727) },
                    { "T002", "A004", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7731), "Join cosplay contest", new DateTime(2025, 3, 20, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7731), "EC002", true, "Los Angeles", new DateTime(2025, 3, 19, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7730), 1, "Comic Con Appearance", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7732) },
                    { "T003", "A005", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7738), "Teach costume making", new DateTime(2025, 3, 22, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7738), "EC003", true, "New York", new DateTime(2025, 3, 21, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7737), 2, "Cosplay Workshop", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7739) },
                    { "T004", "A007", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7742), "Host a live event", new DateTime(2025, 3, 16, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7742), "EC004", true, "Online", new DateTime(2025, 3, 16, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7741), 3, "Live Stream Cosplay", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7743) },
                    { "T005", "A008", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7752), "Professional cosplay photoshoot", new DateTime(2025, 3, 24, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7746), "EC005", true, "Paris", new DateTime(2025, 3, 23, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7745), 0, "Photoshoot Session", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7755) },
                    { "T006", "A010", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7759), "Evaluate contestants", new DateTime(2025, 3, 26, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7759), "EC006", true, "Berlin", new DateTime(2025, 3, 25, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7758), 1, "Guest Judge at Cosplay Contest", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7760) },
                    { "T007", "A012", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7763), "Walk in parade", new DateTime(2025, 3, 28, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7763), "EC007", true, "Seoul", new DateTime(2025, 3, 27, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7762), 2, "Cosplay Parade", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7764) },
                    { "T008", "A013", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7768), "Perform on live TV", new DateTime(2025, 3, 30, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7768), "EC008", true, "London", new DateTime(2025, 3, 29, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7767), 3, "TV Show Cosplay Segment", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7769) },
                    { "T009", "A015", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7772), "Perform for charity", new DateTime(2025, 4, 1, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7772), "EC009", true, "Sydney", new DateTime(2025, 3, 31, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7771), 4, "Cosplay Charity Event", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7773) },
                    { "T010", "A005", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7776), "Talk about cosplay industry", new DateTime(2025, 4, 3, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7776), "EC010", true, "San Diego", new DateTime(2025, 4, 2, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7775), 0, "Cosplay Panel Discussion", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7777) },
                    { "T011", "A008", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7782), "New character shoot", new DateTime(2025, 4, 5, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7781), "EC011", true, "Bangkok", new DateTime(2025, 4, 4, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7781), 1, "Cosplay Photoshoot", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7782) },
                    { "T012", "A007", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7786), "Host main event", new DateTime(2025, 4, 7, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7785), "EC012", true, "Jakarta", new DateTime(2025, 4, 6, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7785), 2, "Anime Convention Hosting", null, new DateTime(2025, 3, 15, 20, 23, 37, 769, DateTimeKind.Local).AddTicks(7786) }
                });

            migrationBuilder.InsertData(
                table: "ContractCharacter",
                columns: new[] { "ContractCharacterId", "CharacterId", "ContractId", "CreateDate", "Description", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "CC0021", "CH001", "CT002", new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT002", 150.0, null },
                    { "CC0022", "CH002", "CT002", new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT002", 180.0, null },
                    { "CC0023", "CH003", "CT002", new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT002", 170.0, null },
                    { "CC0051", "CH004", "CT005", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT005", 200.0, null },
                    { "CC0052", "CH005", "CT005", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT005", 250.0, null },
                    { "CC0053", "CH006", "CT005", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT005", 250.0, null },
                    { "CC0081", "CH007", "CT008", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT008", 120.0, null },
                    { "CC0082", "CH008", "CT008", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT008", 130.0, null },
                    { "CC0083", "CH009", "CT008", new DateTime(2025, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT008", 100.0, null },
                    { "CC0101", "CH010", "CT010", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT010", 70.0, null },
                    { "CC0102", "CH011", "CT010", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT010", 80.0, null },
                    { "CC0103", "CH012", "CT010", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT010", 50.0, null },
                    { "CC0141", "CH013", "CT014", new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 1 for CT014", 200.0, null },
                    { "CC0142", "CH014", "CT014", new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 2 for CT014", 250.0, null },
                    { "CC0143", "CH015", "CT014", new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Character 3 for CT014", 150.0, null }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "ContractId", "CreateBy", "CreateDate", "Description", "UpdateDate" },
                values: new object[,]
                {
                    { "02d591bc-2788-4033-b077-b4d35221a862", "A007", "CT010", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", null },
                    { "437c58b8-4e06-4650-af7e-717c03768161", "A005", "CT008", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", null },
                    { "43e9c5a2-edfb-49e6-8f10-40da6f4b3228", "A004", "CT005", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", null },
                    { "4668464d-50d8-4190-ab10-cc9d5b0ad487", "A008", "CT014", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", null },
                    { "5490c7f6-e53e-4e38-a6b8-ae72f14bf19c", "A015", "CT010", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", null },
                    { "759a96e4-5a3d-497b-8fcd-56c70a9365bc", "A013", "CT008", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", null },
                    { "aa940baa-6382-4a31-be59-4d02b3281c80", "A001", "CT002", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", null },
                    { "c24fef93-93fc-4c5f-b066-62415f35572b", "A012", "CT005", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", null },
                    { "e4f01bd6-6265-4fbf-aa64-729dff35b870", "A010", "CT002", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", null }
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
                name: "IX_Feedback_ContractId",
                table: "Feedback",
                column: "ContractId");

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
                name: "IX_Package_ServiceId",
                table: "Package",
                column: "ServiceId");

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
                unique: true);

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
                name: "Package");

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
