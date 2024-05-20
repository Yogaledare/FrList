namespace FrList.server.Dtos;

public record PersonDto(
    int PersonId,
    string Name,
    int Age,
    string Nick,
    DateOnly Date
);