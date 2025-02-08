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
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Character_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventCategory",
                columns: table => new
                {
                    EventCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategory", x => x.EventCategoryId);
                    table.ForeignKey(
                        name: "FK_EventCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCategory_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTask",
                columns: table => new
                {
                    AccountTaskId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaskId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTask", x => x.AccountTaskId);
                    table.ForeignKey(
                        name: "FK_AccountTask_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTask_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Signature = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deposit = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contract_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedback_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CharacterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Image_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { "category1", "This is Category 1", "Category 1" },
                    { "category2", "This is Category 2", "Category 2" }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "CreateDate", "Description", "Name", "Status", "Type", "UpdateDate" },
                values: new object[,]
                {
                    { "event1", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8482), "This is event 1", "Event 1", 1, "Conference", null },
                    { "event2", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8632), "This is event 2", "Event 2", 2, "Workshop", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8632) }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Description", "RoleName" },
                values: new object[,]
                {
                    { "1", "Administrator role", 1 },
                    { "2", "Regular user role", 2 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CreateDate", "Description", "IsActive", "Location", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { "task1", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(6739), "This is task 1", true, "Location 1", "Task 1", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(6746) },
                    { "task2", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(6761), "This is task 2", true, "Location 2", "Task 2", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8016) }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "Address", "Birthday", "CreateDate", "Description", "Email", "Gender", "IsActive", "Name", "Password", "Phone", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { "account1", "123 Admin Street", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 9, 57, 39, 936, DateTimeKind.Utc).AddTicks(8141), null, "admin@example.com", true, true, "Admin User", "$2a$11$pwYMx3B/cQ1gqUfdXWWDwePJR3Z61S4evCMSegbd.x4ZXP0tquzji", 1234567890, "1", null },
                    { "account2", "456 User Lane", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 9, 57, 40, 62, DateTimeKind.Utc).AddTicks(7068), null, "user@example.com", false, true, "Regular User", "$2a$11$mVJVBp4KkdxnK9DstzSuxuixNj0.b54OO4O4grG.3SnNJ/CX587Fm", 987654321, "2", null }
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "CharacterId", "CategoryId", "CreateDate", "Description", "IsActive", "Name", "Price", "UpdateDate" },
                values: new object[,]
                {
                    { "character1", "category1", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8412), "Description for Character 1", "true", "Character 1", 100.5, null },
                    { "character2", "category2", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8415), "Description for Character 2", "true", "Character 2", 200.75, null }
                });

            migrationBuilder.InsertData(
                table: "EventCategory",
                columns: new[] { "EventCategoryId", "CategoryId", "CreateDate", "EventId", "UpdateDate" },
                values: new object[,]
                {
                    { "eventcategory1", "category1", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8702), "event1", null },
                    { "eventcategory2", "category2", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8707), "event2", null }
                });

            migrationBuilder.InsertData(
                table: "AccountTask",
                columns: new[] { "AccountTaskId", "AccountId", "TaskId" },
                values: new object[,]
                {
                    { "accountTask1", "account1", "task1" },
                    { "accountTask2", "account2", "task2" }
                });

            migrationBuilder.InsertData(
                table: "Contract",
                columns: new[] { "ContractId", "AccountId", "Amount", "CreateDate", "Deposit", "Description", "EventId", "Name", "Price", "Signature", "UpdateDate" },
                values: new object[,]
                {
                    { "contract1", "account1", 400.0, new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8749), 100, "Contract for Event 1", "event1", "Contract 1", 500.0, true, null },
                    { "contract2", "account2", 600.0, new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8754), 200, "Contract for Event 2", "event2", "Contract 2", 800.0, false, null }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "FeedbackId", "AccountId", "CreateDate", "Description", "Star", "UpdateDate" },
                values: new object[,]
                {
                    { "feedback1", "account1", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8826), "Great service, highly recommended!", 5, null },
                    { "feedback2", "account2", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8828), "Good service, but there's room for improvement.", 4, null }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "AccountId", "CharacterId", "CreateDate", "ImageUrl", "UpdateDate" },
                values: new object[,]
                {
                    { "image1", "account1", null, new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8858), "https://example.com/image1.jpg", null },
                    { "image2", "account2", null, new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8860), "https://example.com/image2.jpg", null },
                    { "image3", null, "character1", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8863), "https://example.com/image3.jpg", null },
                    { "image4", null, "character2", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8865), "https://example.com/image4.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "ContractId", "CreateDate", "Status", "TransactionId", "Type" },
                values: new object[,]
                {
                    { "payment1", "contract1", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8988), 1, "TXN123456", "Credit Card" },
                    { "payment2", "contract2", new DateTime(2025, 2, 8, 9, 57, 40, 190, DateTimeKind.Utc).AddTicks(8991), 0, "TXN789012", "Bank Transfer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTask_AccountId",
                table: "AccountTask",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTask_TaskId",
                table: "AccountTask",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_CategoryId",
                table: "Character",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_AccountId",
                table: "Contract",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_EventId",
                table: "Contract",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventCategory_CategoryId",
                table: "EventCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCategory_EventId",
                table: "EventCategory",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_AccountId",
                table: "Feedback",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_AccountId",
                table: "Image",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CharacterId",
                table: "Image",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ContractId",
                table: "Payment",
                column: "ContractId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTask");

            migrationBuilder.DropTable(
                name: "EventCategory");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
