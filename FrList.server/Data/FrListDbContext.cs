using FrList.server.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrList.server.Data;

public class FrListDbContext : DbContext{

    public FrListDbContext(DbContextOptions<FrListDbContext> options) : base(options) {
        
    }

    public DbSet<Person> Persons { get; set; }



}