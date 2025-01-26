namespace Calculus.Scenarios;

public class Scenario
{
  public Guid Id { get; private set; }
  public string Name { get; private set; }
  public string Author { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public DateTime? UpdatedAt { get; private set; }
  public DateTime? DeletedAt { get; private set; }

  public Scenario(Guid id, string name, string author, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt)
  {
    Id = id;
    Name = Guard.AgainstNullOrEmpty(name);
    Author = author;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
    DeletedAt = deletedAt;
  }
}
