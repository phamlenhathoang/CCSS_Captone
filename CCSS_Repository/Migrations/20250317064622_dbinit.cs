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
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    AccountCouponId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Deposit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contract_AccountCoupon_AccountCouponId",
                        column: x => x.AccountCouponId,
                        principalTable: "AccountCoupon",
                        principalColumn: "AccountCouponId");
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
                    CosplayerId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    { "ACT001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3859), "A relaxing yoga session", "Yoga Class", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3860) },
                    { "ACT002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3892), "Learn to cook delicious meals", "Cooking Workshop", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3892) },
                    { "ACT003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3895), "Live music performance", "Music Concert", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3895) },
                    { "ACT004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3898), "Showcase of local artists", "Art Exhibition", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3899) },
                    { "ACT005", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3901), "Discussion on latest technology trends", "Tech Talk", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3902) },
                    { "ACT006", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3907), "5K run for a good cause", "Charity Run", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3907) },
                    { "ACT007", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3911), "Monthly book discussion", "Book Club", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3912) },
                    { "ACT008", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3914), "Learn photography skills", "Photography Workshop", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3915) },
                    { "ACT009", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3917), "Dance battle for all ages", "Dance Competition", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3918) },
                    { "ACT010", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3920), "Competitive chess matches", "Chess Tournament", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3921) },
                    { "ACT011", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3923), "Outdoor movie screening", "Movie Night", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3924) },
                    { "ACT012", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3926), "Showcase of scientific projects", "Science Fair", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3927) },
                    { "ACT013", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3931), "Intensive coding workshop", "Coding Bootcamp", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3931) },
                    { "ACT014", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3935), "Learn gardening techniques", "Gardening Workshop", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3935) },
                    { "ACT015", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3938), "Guided meditation practice", "Meditation Session", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3938) }
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
                    { "E001", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2653), "A grand celebration to welcome the new year", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Year Festival", true, "Times Square, New York", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E002", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2658), "Experience the beauty of cherry blossoms", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring Blossom Fest", true, "Kyoto, Japan", new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E003", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2660), "Showcasing the latest in technology and AI", new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Innovation Summit", true, "Silicon Valley", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E004", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2664), "Live performances from top artists", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music Fest", true, "Coachella, California", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E005", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2667), "A must-attend event for comic book fans", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comic-Con International", true, "San Diego Convention Center", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E006", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2669), "Largest anime convention in the world", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anime Expo", true, "Los Angeles Convention Center", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E007", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2672), "Latest trends and releases in gaming", new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Expo", true, "Las Vegas Convention Center", new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E008", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2674), "A fun-filled summer celebration", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Festival", true, "Miami Beach, Florida", new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E009", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2678), "A paradise for cosplayers", new DateTime(2025, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosplay Festival", true, "Tokyo Big Sight", new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E010", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2680), "Showcasing the best movies of the year", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film Festival", true, "Cannes, France", new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E011", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2682), "Spooky celebrations and costume parties", new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halloween Night", true, "Salem, Massachusetts", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "E012", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2721), "Festive shopping and holiday cheer", new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christmas Market", true, "Nuremberg, Germany", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreateDate", "Description", "IsActive", "Price", "ProductName", "Quantity", "UpdateDate" },
                values: new object[,]
                {
                    { "P001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2555), "A wig for Naruto cosplay", true, 30.0, "Naruto Wig", 10, null },
                    { "P002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2558), "A hat for Mario cosplay", true, 20.0, "Mario Hat", 15, null },
                    { "P003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2562), "Complete costume for Sasuke cosplay", true, 80.0, "Sasuke Costume", 5, null },
                    { "P004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2580), "Replica sword from The Legend of Zelda", true, 100.0, "Zelda Sword", 7, null },
                    { "P005", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2584), "Iconic straw hat from One Piece", true, 25.0, "One Piece Straw Hat", 20, null },
                    { "P006", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2587), "Hatsune Miku blue twin-tail wig", true, 40.0, "Miku Wig", 12, null },
                    { "P007", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2589), "Tanjiro's iconic hanafuda earrings", true, 15.0, "Demon Slayer Earrings", 30, null },
                    { "P008", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2592), "Survey Corps uniform jacket", true, 50.0, "Attack on Titan Jacket", 10, null },
                    { "P009", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2594), "Cozy Pikachu-themed onesie", true, 60.0, "Pikachu Onesie", 8, null },
                    { "P010", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2597), "Final Fantasy VII replica sword", true, 120.0, "Cloud's Buster Sword", 4, null },
                    { "P011", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2601), "LED Vision accessory from Genshin Impact", true, 35.0, "Genshin Impact Vision", 25, null },
                    { "P012", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2603), "Jinx cosplay wig from Arcane", true, 45.0, "Jinx Wig", 6, null },
                    { "P013", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2606), "Golden tiara from Sailor Moon", true, 18.0, "Sailor Moon Tiara", 15, null },
                    { "P014", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2610), "High-quality Spider-Man suit", true, 90.0, "Spider-Man Suit", 3, null },
                    { "P015", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2612), "Replica wand from Harry Potter series", true, 22.0, "Harry Potter Wand", 50, null }
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
                    { "S001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2514), "Rent characters for events and parties", "Character Rental", null },
                    { "S002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2519), "Live cosplay performances at events", "Cosplay Performance", null },
                    { "S003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2520), "Professional photoshoot with cosplayers", "Photography Session", null },
                    { "S004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2521), "Selling exclusive cosplay-related merchandise", "Merchandise Selling", null },
                    { "S005", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2522), "Cosplay and makeup training sessions", "Workshop & Training", null }
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
                    { "CH001", "C3", "Naruto", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2409), "Ninja from Konoha", true, 180f, 80f, 160f, 50f, 100.0, 5, null },
                    { "CH002", "C3", "Sasuke", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2437), "Naruto’s rival", true, 185f, 85f, 165f, 55f, 120.0, 3, null },
                    { "CH003", "C3", "Goku", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2442), "Saiyan warrior", true, 190f, 90f, 170f, 60f, 150.0, 4, null },
                    { "CH004", "C4", "Luffy", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2446), "Pirate King", true, 175f, 70f, 155f, 45f, 110.0, 6, null },
                    { "CH005", "C4", "Ichigo", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2450), "Soul Reaper", true, 185f, 85f, 165f, 55f, 130.0, 3, null },
                    { "CH006", "C14", "Mario", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2453), "Plumber hero", true, 160f, 70f, 140f, 50f, 80.0, 5, null },
                    { "CH007", "C14", "Luigi", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2457), "Mario’s brother", true, 170f, 75f, 150f, 55f, 85.0, 4, null },
                    { "CH008", "C14", "Link", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2462), "Hero of Hyrule", true, 180f, 80f, 160f, 50f, 140.0, 2, null },
                    { "CH009", "C16", "Zelda", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2467), "Hyrule princess", true, 175f, 70f, 155f, 50f, 135.0, 3, null },
                    { "CH010", "C16", "Samus", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2471), "Bounty hunter", true, 185f, 85f, 165f, 55f, 145.0, 3, null },
                    { "CH011", "C13", "Cloud", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2475), "Ex-SOLDIER", true, 185f, 85f, 165f, 55f, 125.0, 3, null },
                    { "CH012", "C13", "Sephiroth", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2478), "One-Winged Angel", true, 190f, 90f, 170f, 60f, 155.0, 2, null },
                    { "CH013", "C8", "Kratos", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2481), "God of War", true, 195f, 100f, 175f, 70f, 160.0, 2, null },
                    { "CH014", "C8", "Pikachu", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2485), "Electric Pokemon", true, 50f, 20f, 30f, 10f, 90.0, 10, null },
                    { "CH015", "C8", "Kirby", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(2489), "Pink puffball", true, 60f, 25f, 40f, 15f, 95.0, 8, null }
                });

            migrationBuilder.InsertData(
                table: "EventActivity",
                columns: new[] { "EventActivityId", "ActivityId", "CreateBy", "CreateDate", "Description", "EventId", "UpdateDate" },
                values: new object[,]
                {
                    { "EA001", "ACT001", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3607), "Yoga for a fresh start", "E001", null },
                    { "EA002", "ACT005", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3610), "Tech trends in the new year", "E001", null },
                    { "EA003", "ACT004", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3613), "Painting cherry blossoms", "E002", null },
                    { "EA004", "ACT013", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3615), "AI and future coding", "E003", null },
                    { "EA005", "ACT009", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3617), "Dance battles live", "E004", null },
                    { "EA006", "ACT003", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3619), "Comic-Con live music", "E005", null },
                    { "EA007", "ACT007", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3620), "Anime and book discussions", "E006", null },
                    { "EA008", "ACT010", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3622), "Chess and gaming", "E007", null },
                    { "EA009", "ACT011", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3624), "Outdoor movie fun", "E008", null },
                    { "EA010", "ACT015", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3626), "Meditation for cosplayers", "E009", null },
                    { "EA011", "ACT012", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3629), "Science in filmmaking", "E010", null },
                    { "EA012", "ACT006", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3631), "Halloween charity run", "E011", null },
                    { "EA013", "ACT014", "Admin", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3694), "Christmas gardening", "E012", null },
                    { "EA014", "ACT002", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3697), "Cooking for music lovers", "E004", null },
                    { "EA015", "ACT008", "Manager", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3699), "Photography in tech", "E003", null }
                });

            migrationBuilder.InsertData(
                table: "EventImage",
                columns: new[] { "ImageId", "CreateDate", "EventId", "ImageUrl", "UpdateDate" },
                values: new object[,]
                {
                    { "EI001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4129), "E001", "https://example.com/event1.jpg", null },
                    { "EI002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4132), "E002", "https://example.com/event2.jpg", null },
                    { "EI003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4134), "E003", "https://example.com/event3.jpg", null },
                    { "EI004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4135), "E004", "https://example.com/event4.jpg", null },
                    { "EI005", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4137), "E005", "https://example.com/event5.jpg", null },
                    { "EI006", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4138), "E006", "https://example.com/event6.jpg", null },
                    { "EI007", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4140), "E007", "https://example.com/event7.jpg", null },
                    { "EI008", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4143), "E008", "https://example.com/event8.jpg", null },
                    { "EI009", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4145), "E009", "https://example.com/event9.jpg", null },
                    { "EI010", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4146), "E010", "https://example.com/event10.jpg", null },
                    { "EI011", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4147), "E011", "https://example.com/event11.jpg", null },
                    { "EI012", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4149), "E012", "https://example.com/event12.jpg", null }
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
                    { "IMG001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4404), "P001", null, "https://example.com/images/naruto_wig.jpg" },
                    { "IMG002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4406), "P002", null, "https://example.com/images/mario_hat.jpg" },
                    { "IMG003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4408), "P003", null, "https://example.com/images/sasuke_costume.jpg" },
                    { "IMG004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4410), "P004", null, "https://example.com/images/zelda_sword.jpg" },
                    { "IMG005", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4412), "P005", null, "https://example.com/images/one_piece_hat.jpg" },
                    { "IMG006", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4414), "P006", null, "https://example.com/images/miku_wig.jpg" },
                    { "IMG007", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4416), "P007", null, "https://example.com/images/demon_slayer_earrings.jpg" },
                    { "IMG008", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4418), "P008", null, "https://example.com/images/aot_jacket.jpg" },
                    { "IMG009", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4422), "P009", null, "https://example.com/images/pikachu_onesie.jpg" },
                    { "IMG010", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4424), "P010", null, "https://example.com/images/buster_sword.jpg" },
                    { "IMG011", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4426), "P011", null, "https://example.com/images/genshin_vision.jpg" },
                    { "IMG012", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4428), "P012", null, "https://example.com/images/jinx_wig.jpg" },
                    { "IMG013", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4430), "P013", null, "https://example.com/images/sailor_moon_tiara.jpg" },
                    { "IMG014", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4431), "P014", null, "https://example.com/images/spiderman_suit.jpg" },
                    { "IMG015", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4433), "P015", null, "https://example.com/images/harry_potter_wand.jpg" }
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
                    { "AI1", "A001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3786), null, "https://example.com/admin.jpg" },
                    { "AI10", "A010", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3807), null, "https://example.com/user8.jpg" },
                    { "AI11", "A011", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3809), null, "https://example.com/user9.jpg" },
                    { "AI12", "A012", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3811), null, "https://example.com/user10.jpg" },
                    { "AI13", "A013", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3816), null, "https://example.com/user11.jpg" },
                    { "AI14", "A014", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3819), null, "https://example.com/user12.jpg" },
                    { "AI15", "A015", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3821), null, "https://example.com/user13.jpg" },
                    { "AI2", "A002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3788), null, "https://example.com/manager.jpg" },
                    { "AI3", "A003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3790), null, "https://example.com/user1.jpg" },
                    { "AI4", "A004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3792), null, "https://example.com/user2.jpg" },
                    { "AI5", "A005", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3795), null, "https://example.com/user3.jpg" },
                    { "AI6", "A006", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3797), null, "https://example.com/user4.jpg" },
                    { "AI7", "A007", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3799), null, "https://example.com/user5.jpg" },
                    { "AI8", "A008", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3802), null, "https://example.com/user6.jpg" },
                    { "AI9", "A009", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3805), null, "https://example.com/user7.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "AccountId", "CreateDate", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "C001", "A003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3140), 0.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3141) },
                    { "C002", "A006", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3143), 0.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3144) },
                    { "C003", "A011", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3145), 0.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3146) },
                    { "C004", "A014", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3149), 0.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3149) }
                });

            migrationBuilder.InsertData(
                table: "CharacterImage",
                columns: new[] { "CharacterImageId", "CharacterId", "CreateDate", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { "CI001", "CH001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4049), null, "https://example.com/img1.jpg" },
                    { "CI002", "CH002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4052), null, "https://example.com/img2.jpg" },
                    { "CI003", "CH003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4054), null, "https://example.com/img3.jpg" },
                    { "CI004", "CH004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4078), null, "https://example.com/img4.jpg" },
                    { "CI005", "CH005", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4079), null, "https://example.com/img5.jpg" },
                    { "CI006", "CH006", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4081), null, "https://example.com/img6.jpg" },
                    { "CI007", "CH007", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4085), null, "https://example.com/img7.jpg" },
                    { "CI008", "CH008", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4086), null, "https://example.com/img8.jpg" },
                    { "CI009", "CH009", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4088), null, "https://example.com/img9.jpg" },
                    { "CI010", "CH010", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4089), null, "https://example.com/img10.jpg" },
                    { "CI011", "CH011", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4091), null, "https://example.com/img11.jpg" },
                    { "CI012", "CH012", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4093), null, "https://example.com/img12.jpg" },
                    { "CI013", "CH013", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4094), null, "https://example.com/img13.jpg" },
                    { "CI014", "CH014", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4096), null, "https://example.com/img14.jpg" },
                    { "CI015", "CH015", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4099), null, "https://example.com/img15.jpg" }
                });

            migrationBuilder.InsertData(
                table: "EventCharacter",
                columns: new[] { "EventCharacterId", "CharacterId", "CreateDate", "Description", "EventId", "IsAssign", "UpdateDate" },
                values: new object[,]
                {
                    { "EC001", "CH001", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3555), null, "E001", true, null },
                    { "EC002", "CH002", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3557), null, "E002", true, null },
                    { "EC003", "CH003", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3559), null, "E003", true, null },
                    { "EC004", "CH004", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3561), null, "E004", true, null },
                    { "EC005", "CH005", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3564), null, "E005", true, null },
                    { "EC006", "CH006", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3565), null, "E006", true, null },
                    { "EC007", "CH007", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3569), null, "E007", true, null },
                    { "EC008", "CH008", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3571), null, "E008", true, null },
                    { "EC009", "CH009", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3573), null, "E009", true, null },
                    { "EC010", "CH010", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3576), null, "E010", true, null },
                    { "EC011", "CH011", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3578), null, "E011", true, null },
                    { "EC012", "CH012", new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3580), null, "E012", true, null }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "AccountId", "CreatedAt", "IsRead", "Message" },
                values: new object[,]
                {
                    { "N001", "A001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3047), false, "Welcome to the system!" },
                    { "N002", "A002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3049), false, "Your account has been upgraded." },
                    { "N003", "A003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3052), true, "New promotional offer available!" },
                    { "N004", "A004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3055), false, "Your request has been approved." },
                    { "N005", "A005", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3057), true, "System maintenance scheduled." },
                    { "N006", "A006", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3058), false, "Your order has been shipped!" },
                    { "N007", "A007", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3060), false, "New event registration open." },
                    { "N008", "A008", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3062), true, "Reminder: Payment due soon." },
                    { "N009", "A009", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3095), false, "Your password was changed." },
                    { "N010", "A010", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3097), false, "Admin announcement update." },
                    { "N011", "A011", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3100), true, "New message from support." },
                    { "N012", "A012", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3102), false, "Upcoming event invitation." },
                    { "N013", "A013", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3104), false, "New cosplayer contest." },
                    { "N014", "A014", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3106), true, "Loyalty points updated." },
                    { "N015", "A015", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3108), false, "Your subscription expired." }
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
                columns: new[] { "RequestId", "AccountId", "ContractId", "Description", "EndDate", "Location", "Name", "Price", "ServiceId", "StartDate", "Status" },
                values: new object[,]
                {
                    { "R001", "A001", "CT001", 0, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Naruto Costume", 100.0, "S001", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R002", "A002", "CT002", 1, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ĐN", "Rent Cosplayer for Event", 500.0, "S002", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R003", "A003", "CT003", 2, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "BD", "Create Anime Festival", 2000.0, "S003", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R004", "A004", "CT004", 0, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Rent Samurai Armor", 150.0, "S004", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R005", "A005", "CT005", 1, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "BT", "Hire Professional Cosplayer", 700.0, "S005", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R006", "A006", "CT006", 2, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Organize Comic Convention", 5000.0, "S001", new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R007", "A007", "CT007", 0, new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Victorian Costume", 120.0, "S002", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R008", "A008", "CT008", 1, new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "QN", "Book Cosplayer for Birthday Party", 350.0, "S003", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R009", "A009", "CT009", 2, new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CM", "Plan Fantasy Fair", 3000.0, "S004", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R010", "A010", "CT010", 0, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "LĐ", "Rent Halloween Costumes", 200.0, "S005", new DateTime(2025, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R011", "A011", "CT011", 1, new DateTime(2025, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "NT", "Hire Cosplayer for Wedding", 800.0, "S001", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R012", "A012", "CT012", 2, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "VT", "Create Sci-Fi Convention", 4500.0, "S002", new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "R013", "A013", "CT013", 0, new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Rent Santa Claus Costume", 130.0, "S003", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { "R014", "A014", "CT014", 1, new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "Book Cosplayer for Product Launch", 600.0, "S004", new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "R015", "A015", "CT015", 2, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "HCM", "Host Christmas Event", 5500.0, "S005", new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
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
                    { "01176ba3-5025-4e8a-84ce-a9c14514782c", "C003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3996), 15.0, "P007", 5 },
                    { "410ab8e7-df19-47e0-8365-39f328d3dc56", "C004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4015), 45.0, "P012", 1 },
                    { "4549c662-77f6-485d-9a87-205c80feff28", "C003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4004), 60.0, "P009", 1 },
                    { "620c31af-1c3f-4cde-a9a6-0643eca67d59", "C003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4001), 50.0, "P008", 2 },
                    { "6821a3ed-18b2-43bb-b765-82eb7c7dad3a", "C004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4007), 120.0, "P010", 1 },
                    { "69d54bdd-a3f4-488b-b1c8-3c631d462bff", "C004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4010), 35.0, "P011", 2 },
                    { "900689eb-b689-44d1-ba8e-90683acfb318", "C002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3990), 25.0, "P005", 3 },
                    { "a2f9e402-c855-4c8e-b5af-04d829b5c3f6", "C001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3980), 20.0, "P002", 1 },
                    { "db170c95-3891-4e07-a938-d138cbedbd2c", "C001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3976), 30.0, "P001", 2 },
                    { "e158f4c8-bc86-48e6-bbb5-b35de1b9d2c2", "C002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3988), 100.0, "P004", 1 },
                    { "f0f284d1-4715-43d6-9f64-93ef92b132a3", "C001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3983), 80.0, "P003", 1 },
                    { "f3074dbf-3d34-46a6-87e5-57470097d3d7", "C002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(3993), 40.0, "P006", 2 }
                });

            migrationBuilder.InsertData(
                table: "Contract",
                columns: new[] { "ContractId", "AccountCouponId", "ContractStatus", "CreateBy", "CreateDate", "Deposit", "RequestId", "TotalPrice" },
                values: new object[,]
                {
                    { "CT002", null, 1, "Admin", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "100", "R002", 500.0 },
                    { "CT005", null, 1, "Admin", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "150", "R005", 700.0 },
                    { "CT008", null, 1, "Admin", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "70", "R008", 350.0 },
                    { "CT010", null, 3, "Admin", new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "50", "R010", 200.0 },
                    { "CT014", null, 1, "Admin", new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "120", "R014", 600.0 }
                });

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "OrderProductId", "CreateDate", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "0b4131ab-85d9-411b-bfcb-63da86abef33", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4225), "O006", 45.0, "P012", 3 },
                    { "0d3106fd-ed28-41cd-ba09-973902993d00", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4182), "O001", 20.0, "P002", 5 },
                    { "113e5267-f8a8-4322-a577-d607b3534c77", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4190), "O003", 25.0, "P005", 2 },
                    { "14fcd582-d1c8-448d-bf42-46b217e23936", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4187), "O002", 100.0, "P004", 1 },
                    { "230fe7e0-4d9f-4e4a-8755-d5e74d8f9759", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4234), "O008", 22.0, "P015", 4 },
                    { "25b5d7f1-adcc-451b-9356-f1afc53ce08b", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4227), "O007", 18.0, "P013", 5 },
                    { "2de2e6c8-5512-4d7f-a216-b7df0e3456fd", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4248), "O010", 25.0, "P005", 3 },
                    { "31390e55-6b65-4b32-8f26-5311a31e34e3", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4231), "O007", 90.0, "P014", 2 },
                    { "33f638ea-c33a-4fd7-b963-bec202f797a6", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4196), "O004", 15.0, "P007", 4 },
                    { "3724838f-d40f-4aff-996f-ebe4b18ff3a3", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4246), "O010", 100.0, "P004", 1 },
                    { "3a40ea93-fc17-445a-9e1f-8eb181d28b21", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4271), "O013", 35.0, "P011", 2 },
                    { "3e302580-0fe5-4953-8123-cf191f4edafa", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4251), "O011", 40.0, "P006", 2 },
                    { "405d59e9-e846-4e27-b330-a0e81a12efce", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4276), "O014", 18.0, "P013", 5 },
                    { "41c3ac97-3845-431d-812c-fa29eebe748b", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4279), "O015", 90.0, "P014", 2 },
                    { "489441f4-dfc1-4157-bd0e-b5502c578fa9", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4219), "O005", 120.0, "P010", 1 },
                    { "4f2b9923-12aa-4cbd-9ae3-24c863c17047", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4239), "O009", 20.0, "P002", 6 },
                    { "50cb1250-05dc-46d5-95cb-1781b5ba892a", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4243), "O009", 80.0, "P003", 2 },
                    { "6ef5b6a9-5a00-4916-9deb-d9625ee412ad", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4282), "O015", 22.0, "P015", 4 },
                    { "7bb01f35-8f12-4b6e-b46b-738ee52a67c5", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4258), "O012", 50.0, "P008", 2 },
                    { "8a994840-7fc5-4662-9327-4cc482a6218f", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4274), "O014", 45.0, "P012", 3 },
                    { "8fcbb84f-451b-4373-a36f-88d0ff92d20e", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4222), "O006", 35.0, "P011", 2 },
                    { "a32a3932-3f7d-4daa-8614-8376fc82260b", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4185), "O002", 80.0, "P003", 1 },
                    { "a931c61d-b346-4dd6-9365-3ffa026c8791", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4178), "O001", 30.0, "P001", 3 },
                    { "b44043a7-8299-45b5-8b3a-26c26d1656f1", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4198), "O004", 50.0, "P008", 2 },
                    { "b8a81aab-b044-4208-8e07-cbd6963cbdda", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4193), "O003", 40.0, "P006", 3 },
                    { "c56a48fb-0eb3-45fc-aa15-c8ca4716030a", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4236), "O008", 30.0, "P001", 1 },
                    { "cedd8b89-4a10-4745-9986-4c0ee210a666", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4201), "O005", 60.0, "P009", 1 },
                    { "e2240e27-ecad-4ea8-9ff7-229fab54a284", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4261), "O012", 60.0, "P009", 1 },
                    { "f6c27665-b105-41b3-a788-dc388ad1a49b", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4267), "O013", 120.0, "P010", 1 },
                    { "fa771d21-1518-4c93-9634-016b841c4e85", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4255), "O011", 15.0, "P007", 4 }
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
                columns: new[] { "RequestCharacterId", "CharacterId", "CosplayerId", "CreateDate", "Description", "RequestId", "TotalPrice", "UpdateDate" },
                values: new object[,]
                {
                    { "RC01", "CH001", "C001", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4460), "Yêu cầu cosplay nhân vật CH001", "R001", 50.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4460) },
                    { "RC02", "CH002", "C002", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4465), "Yêu cầu cosplay nhân vật CH002", "R002", 60.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4466) },
                    { "RC03", "CH003", "C003", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4468), "Yêu cầu cosplay nhân vật CH003", "R003", 70.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4469) },
                    { "RC04", "CH004", "C004", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4471), "Yêu cầu cosplay nhân vật CH004", "R004", 80.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4471) },
                    { "RC05", "CH005", "C005", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4474), "Yêu cầu cosplay nhân vật CH005", "R005", 90.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4475) },
                    { "RC06", "CH006", "C006", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4477), "Yêu cầu cosplay nhân vật CH006", "R006", 100.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4477) },
                    { "RC07", "CH007", "C007", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4480), "Yêu cầu cosplay nhân vật CH007", "R007", 110.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4480) },
                    { "RC08", "CH008", "C008", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4483), "Yêu cầu cosplay nhân vật CH008", "R008", 120.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4483) },
                    { "RC09", "CH009", "C009", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4485), "Yêu cầu cosplay nhân vật CH009", "R009", 130.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4486) },
                    { "RC10", "CH010", "C010", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4490), "Yêu cầu cosplay nhân vật CH010", "R010", 140.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4490) },
                    { "RC11", "CH011", "C011", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4493), "Yêu cầu cosplay nhân vật CH011", "R011", 150.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4493) },
                    { "RC12", "CH012", "C012", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4495), "Yêu cầu cosplay nhân vật CH012", "R012", 160.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4496) },
                    { "RC13", "CH013", "C013", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4502), "Yêu cầu cosplay nhân vật CH013", "R013", 170.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4502) },
                    { "RC14", "CH014", "C014", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4505), "Yêu cầu cosplay nhân vật CH014", "R014", 180.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4505) },
                    { "RC15", "CH015", "C015", new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4535), "Yêu cầu cosplay nhân vật CH015", "R015", 190.0, new DateTime(2025, 3, 17, 6, 46, 22, 435, DateTimeKind.Utc).AddTicks(4535) }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "AccountId", "ContractCharacterId", "CreateDate", "Description", "EndDate", "EventCharacterId", "IsActive", "Location", "StartDate", "Status", "TaskName", "Type", "UpdateDate" },
                values: new object[,]
                {
                    { "T001", "A001", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3276), "Cosplay as anime characters", new DateTime(2025, 3, 20, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3275), "EC001", true, "Tokyo", new DateTime(2025, 3, 19, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3255), 0, "Perform at Anime Fest", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3277) },
                    { "T002", "A004", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3285), "Join cosplay contest", new DateTime(2025, 3, 22, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3285), "EC002", true, "Los Angeles", new DateTime(2025, 3, 21, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3284), 1, "Comic Con Appearance", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3286) },
                    { "T003", "A005", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3312), "Teach costume making", new DateTime(2025, 3, 24, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3311), "EC003", true, "New York", new DateTime(2025, 3, 23, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3310), 2, "Cosplay Workshop", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3312) },
                    { "T004", "A007", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3316), "Host a live event", new DateTime(2025, 3, 18, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3316), "EC004", true, "Online", new DateTime(2025, 3, 18, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3315), 3, "Live Stream Cosplay", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3317) },
                    { "T005", "A008", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3320), "Professional cosplay photoshoot", new DateTime(2025, 3, 26, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3320), "EC005", true, "Paris", new DateTime(2025, 3, 25, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3319), 0, "Photoshoot Session", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3321) },
                    { "T006", "A010", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3325), "Evaluate contestants", new DateTime(2025, 3, 28, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3324), "EC006", true, "Berlin", new DateTime(2025, 3, 27, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3323), 1, "Guest Judge at Cosplay Contest", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3325) },
                    { "T007", "A012", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3331), "Walk in parade", new DateTime(2025, 3, 30, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3330), "EC007", true, "Seoul", new DateTime(2025, 3, 29, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3329), 2, "Cosplay Parade", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3331) },
                    { "T008", "A013", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3335), "Perform on live TV", new DateTime(2025, 4, 1, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3334), "EC008", true, "London", new DateTime(2025, 3, 31, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3334), 3, "TV Show Cosplay Segment", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3335) },
                    { "T009", "A015", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3341), "Perform for charity", new DateTime(2025, 4, 3, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3340), "EC009", true, "Sydney", new DateTime(2025, 4, 2, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3339), 4, "Cosplay Charity Event", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3341) },
                    { "T010", "A005", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3345), "Talk about cosplay industry", new DateTime(2025, 4, 5, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3345), "EC010", true, "San Diego", new DateTime(2025, 4, 4, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3344), 0, "Cosplay Panel Discussion", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3346) },
                    { "T011", "A008", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3350), "New character shoot", new DateTime(2025, 4, 7, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3349), "EC011", true, "Bangkok", new DateTime(2025, 4, 6, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3348), 1, "Cosplay Photoshoot", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3350) },
                    { "T012", "A007", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3354), "Host main event", new DateTime(2025, 4, 9, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3353), "EC012", true, "Jakarta", new DateTime(2025, 4, 8, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3353), 2, "Anime Convention Hosting", null, new DateTime(2025, 3, 17, 13, 46, 22, 435, DateTimeKind.Local).AddTicks(3354) }
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
                    { "1ac2b019-33ed-4101-87de-e142e5a6fe9c", "A013", "CT008", "A013", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice crowd and management!", null },
                    { "1b2cf103-fa81-4ce4-9a66-8550fc1119f5", "A008", "CT014", "A008", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Would love to join again!", null },
                    { "608d6f50-88ec-4a8e-8421-ef72822c3292", "A005", "CT008", "A005", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice cosplay session!", null },
                    { "6206c103-9519-4963-a9b0-d96e9614ee5f", "A004", "CT005", "A004", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loved the event!", null },
                    { "a46f5af3-09cd-4aaf-9b3f-3242077cc737", "A010", "CT002", "A010", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The atmosphere was amazing!", null },
                    { "b2584344-ee3a-4e54-9c04-88287879f572", "A012", "CT005", "A012", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Best cosplay event!", null },
                    { "d9a39080-1d1d-41ad-aa05-4a86f17fa409", "A015", "CT010", "A015", new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazing experience!", null },
                    { "f1e62f36-af4a-4cb5-9539-1a4deb233e42", "A007", "CT010", "A007", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enjoyed the event!", null },
                    { "f30b86ba-e218-48ab-abc2-9b7b4d1c6a7e", "A001", "CT002", "A001", new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Great experience!", null }
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
                name: "IX_Contract_AccountCouponId",
                table: "Contract",
                column: "AccountCouponId",
                unique: true,
                filter: "[AccountCouponId] IS NOT NULL");

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
                name: "AccountCoupon");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
