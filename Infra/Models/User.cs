namespace Infra.Models;

public record User(
    int Id,
    string Email,
    string Name,
    int? Age,
    bool IsActive,
    DateTime CreatedAt
);