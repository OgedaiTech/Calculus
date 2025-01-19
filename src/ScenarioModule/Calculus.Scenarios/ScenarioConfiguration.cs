using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calculus.Scenarios;

internal class ScenarioConfiguration : IEntityTypeConfiguration<Scenario>
{
  public void Configure(EntityTypeBuilder<Scenario> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.Property(p => p.Author)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.HasData(GetSampleScenarioData());
  }

  private static IEnumerable<Scenario> GetSampleScenarioData()
  {
    yield return new Scenario(
      new Guid("e39d5974-39a6-4c53-bdbd-763f75872b2c"),
      "Sample Scenario 1",
      "John Doe",
      new DateTime(2023, 10, 1, 12, 0, 0, DateTimeKind.Utc),
      null,
      null
    );
    yield return new Scenario(
      new Guid("e39d5974-39a6-4c53-bdbd-763f75872b2d"),
      "Sample Scenario 2",
      "Jane Doe",
      new DateTime(2023, 9, 1, 12, 0, 0, DateTimeKind.Utc),
      null,
      null
    );
    yield return new Scenario(
      new Guid("e39d5974-39a6-4c53-bdbd-763f75872b2e"),
      "Sample Scenario 3",
      "John Doe",
      new DateTime(2023, 8, 1, 12, 0, 0, DateTimeKind.Utc),
      null,
      null
    );
  }
}
