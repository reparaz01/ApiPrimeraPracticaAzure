using Microsoft.EntityFrameworkCore;
using ApiPrimeraPracticaAzure.Models;
using System.Collections.Generic;

namespace ApiPrimeraPracticaAzure.Data
{
    public class PersonajesContext : DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options) : base(options) { }
        public DbSet<Personaje> Personajes { get; set; }

    }
}

