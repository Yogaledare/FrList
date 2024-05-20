using FrList.server.Dtos;
using FrList.server.Entities;

namespace FrList.server.Mappers;

public interface IPersonMapper {
    PersonDto Person_PersonDto(Person person);
    Person CreatePersonDto_Person(CreatePersonDto dto);
}

public class PersonMapper : IPersonMapper {
    
    public PersonDto Person_PersonDto(Person person) {
        return new PersonDto(
            person.PersonId,
            person.Name,
            person.Age,
            person.Nick,
            person.Date
        );
    }

    public Person CreatePersonDto_Person(CreatePersonDto dto) {

        if (dto.Age == null || dto.Date == null || dto.Name == null || dto.Nick == null) {
            throw new ArgumentException("Nulls in the Dto"); 
        }

        var success = DateOnly.TryParse(dto.Date, out var date);

        if (!success) {
            throw new ArgumentException("date in dto couldn't be parsed"); 
        }
        
        return new Person {
            Name = dto.Name, 
            Age = dto.Age!.Value, 
            Nick = dto.Nick, 
            Date = date
        }; 
    }
}
