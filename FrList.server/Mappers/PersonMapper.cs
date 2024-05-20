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
        return new Person {
            Name = dto.Name, 
            Age = dto.Age, 
            Nick = dto.Nick, 
            Date = dto.Date
        }; 
    }
}
