using FrList.server.Data;
using FrList.server.Dtos;
using FrList.server.Entities;
using FrList.server.Mappers;
using LanguageExt.Common;
using Microsoft.EntityFrameworkCore;

namespace FrList.server.Repositories;

public interface IPersonRepository {
    Task<ICollection<PersonDto>> GetAllPersons();
    Task<PersonDto> CreatePerson(CreatePersonDto dto);
    Task<Result<PersonDto>> GetPerson(int id);
}

public class PersonRepository : IPersonRepository {
    private readonly FrListDbContext _context;
    private readonly IPersonMapper _mapper;

    public PersonRepository(FrListDbContext context, IPersonMapper mapper) {
        _context = context;
        _mapper = mapper;
    }


    public async Task<ICollection<PersonDto>> GetAllPersons() {
        var persons = await _context.Persons
            .Select(p => _mapper.Person_PersonDto(p))
            .ToListAsync();

        return persons;
    }


    public async Task<Result<PersonDto>> GetPerson(int id) {
        var person = await _context.Persons.FirstOrDefaultAsync(p => p.PersonId == id);

        if (person == null) {
            var error = new ArgumentException($"Cannot find user {id}");
            return new Result<PersonDto>(error); 
        }

        var personDto = _mapper.Person_PersonDto(person);
        
        return personDto; 
    }


    public async Task<PersonDto> CreatePerson(CreatePersonDto dto) {
        var person = _mapper.CreatePersonDto_Person(dto);
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();

        var createdPersonDto = _mapper.Person_PersonDto(person);

        return createdPersonDto;
    }
}