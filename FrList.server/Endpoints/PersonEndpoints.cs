using FrList.server.Dtos;
using FrList.server.Repositories;
using FrList.server.Validation;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;

namespace FrList.server.Endpoints;

public static class PersonEndpoints {
    public static void MapPersonEndpoints(this WebApplication app) {
        app.MapGet("/persons", async (
            IPersonRepository repository
        ) => {
            var persons = await repository.GetAllPersons();

            return Results.Ok(persons);
        });


        app.MapGet("/persons/{id}", async (
            int id,
            IPersonRepository repository
        ) => {
            var personResult = await repository.GetPerson(id);

            return personResult.Match(
                person => Results.Ok(person),
                err => Results.Problem(err.Message, statusCode: StatusCodes.Status400BadRequest)
            );
        });


        app.MapPost("/persons", async (
            IPersonRepository repository,
            [FromBody] CreatePersonDto dto,
            CreatePersonDtoValidator validator
        ) => {
            var validationResult = await validator.ValidateAsync(dto); 
            
            if (!validationResult.IsValid) return Results.ValidationProblem(validationResult.ToDictionary());
            
            var person = await repository.CreatePerson(dto);

            return Results.Created($"/persons/{person.PersonId}", person);
        });
    }
}