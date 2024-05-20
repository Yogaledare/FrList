namespace FrList.server.Entities;

public class Person {

    public int PersonId { get; set; }
    
    public string Name { get; set; } = default!;
    
    public int Age { get; set; }

    public string Nick { get; set; } = default!;

    public DateOnly Date { get; set; }
}

