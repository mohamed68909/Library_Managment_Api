using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiibraryDataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublicationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdditionalDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LibraryCardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    CopyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    AvailabilityStatus = table.Column<bool>(type: "bit", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.CopyID);
                    table.ForeignKey(
                        name: "FK_BookCopies_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID");
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DefaultBorrowDays = table.Column<int>(type: "int", nullable: false),
                    DefaultFinePerDay = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingsID);
                    table.ForeignKey(
                        name: "FK_Settings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingRecords",
                columns: table => new
                {
                    BorrowingRecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CopyID = table.Column<int>(type: "int", nullable: false),
                    BorrowingDate = table.Column<DateTime>(type: "date", nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ActualReturnDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingRecords", x => x.BorrowingRecordID);
                    table.ForeignKey(
                        name: "FK_BorrowingRecords_BookCopies_CopyID",
                        column: x => x.CopyID,
                        principalTable: "BookCopies",
                        principalColumn: "CopyID");
                    table.ForeignKey(
                        name: "FK_BorrowingRecords_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CopyID = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservations_BookCopies_CopyID",
                        column: x => x.CopyID,
                        principalTable: "BookCopies",
                        principalColumn: "CopyID");
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    FineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    BorrowingRecordID = table.Column<int>(type: "int", nullable: false),
                    NumberOfLateDays = table.Column<short>(type: "smallint", nullable: false),
                    FineAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.FineID);
                    table.ForeignKey(
                        name: "FK_Fines_BorrowingRecords_BorrowingRecordID",
                        column: x => x.BorrowingRecordID,
                        principalTable: "BorrowingRecords",
                        principalColumn: "BorrowingRecordID");
                    table.ForeignKey(
                        name: "FK_Fines_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "AdditionalDetails", "Genre", "ISBN", "PublicationDate", "Title" },
                values: new object[] { 1, null, "Programming", "978-1234567890", new DateOnly(1, 1, 1), "C# Programming Basics" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "ContactInformation", "LibraryCardNumber", "Name", "PasswordHash", "Username" },
                values: new object[] { 1, "john@example.com", "LC123", "John Doe", "hashedpassword123", "johndoe" });

            migrationBuilder.InsertData(
                table: "BookCopies",
                columns: new[] { "CopyID", "AvailabilityStatus", "BookID" },
                values: new object[] { 1, false, 1 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "SettingsID", "DefaultBorrowDays", "DefaultFinePerDay", "UserID" },
                values: new object[] { 1, 7, 4m, 1 });

            migrationBuilder.InsertData(
                table: "BorrowingRecords",
                columns: new[] { "BorrowingRecordID", "ActualReturnDate", "BorrowingDate", "CopyID", "DueDate", "UserID" },
                values: new object[] { 1, null, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationID", "CopyID", "ReservationDate", "UserID" },
                values: new object[] { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Fines",
                columns: new[] { "FineID", "BorrowingRecordID", "FineAmount", "NumberOfLateDays", "PaymentStatus", "UserID" },
                values: new object[] { 1, 1, 0m, (short)0, true, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_BookID",
                table: "BookCopies",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRecords_CopyID",
                table: "BorrowingRecords",
                column: "CopyID");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRecords_UserID",
                table: "BorrowingRecords",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_BorrowingRecordID",
                table: "Fines",
                column: "BorrowingRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_UserID",
                table: "Fines",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CopyID",
                table: "Reservations",
                column: "CopyID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserID",
                table: "Reservations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_UserID",
                table: "Settings",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "BorrowingRecords");

            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
