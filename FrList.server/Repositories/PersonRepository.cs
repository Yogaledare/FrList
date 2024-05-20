using FrList.server.Data;
using FrList.server.Dtos;
using FrList.server.Mappers;
using Microsoft.EntityFrameworkCore;

namespace FrList.server.Repositories;

public interface IPersonRepository {
    Task<ICollection<PersonDto>> GetAllPersons();
    Task<PersonDto> CreatePerson(CreatePersonDto dto);
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


    public async Task<PersonDto> CreatePerson(CreatePersonDto dto) {
        var person = _mapper.CreatePersonDto_Person(dto);
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();

        var createdPersonDto = _mapper.Person_PersonDto(person);

        return createdPersonDto; 
    }
    
    

}