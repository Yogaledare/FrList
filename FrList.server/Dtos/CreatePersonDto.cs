namespace FrList.server.Dtos;

public record CreatePersonDto(
    string Name,
    int Age,
    string Nick,
    DateOnly Date
);