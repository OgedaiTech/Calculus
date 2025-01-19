using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Calculus.Scenarios.Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.EnsureSchema(
        name: DataSchemaConstants.SCHEMA);

    migrationBuilder.CreateTable(
        name: "Scenarios",
        schema: "Scenario",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uuid", nullable: false),
          Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
          Author = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
          CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
          UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
          DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Scenarios", x => x.Id);
        });

    migrationBuilder.InsertData(
        schema: DataSchemaConstants.SCHEMA,
        table: "Scenarios",
        columns: ["Id", "Author", "CreatedAt", "DeletedAt", "Name", "UpdatedAt"],
        values: new object[,]
        {
                  { new Guid("e39d5974-39a6-4c53-bdbd-763f75872b2c"), "John Doe", new DateTime(2023, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "Sample Scenario 1", null },
                  { new Guid("e39d5974-39a6-4c53-bdbd-763f75872b2d"), "Jane Doe", new DateTime(2023, 9, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "Sample Scenario 2", null },
                  { new Guid("e39d5974-39a6-4c53-bdbd-763f75872b2e"), "John Doe", new DateTime(2023, 8, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "Sample Scenario 3", null }
        });
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Scenarios",
        schema: "Scenario");
  }
}
