namespace FrList.server.Dtos;

public record PersonDto(
    int Id,
    string Name,
    int Age,
    string Nick,
    DateOnly Date
);