using ApiPrimeraPracticaAzure.Data;
using ApiPrimeraPracticaAzure.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPrimeraPracticaAzure.Repositories
{
    public class RepositoryPersonajes
    {
        public PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }
        public async Task<Personaje> FindPersonajeAsync(int idPersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == idPersonaje);
        }
        public async Task InsertarPersonajeAsync(Personaje personaje)
        {
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdatePersonajeAsync(Personaje personaje)
        {
            this.context.Personajes.Update(personaje);
            await this.context.SaveChangesAsync();
        }
        public async Task DeletePeliculaAsync(int id)
        {
            Personaje personaje = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }
        public async Task<List<string>> GetSeries()
        {
            var series = await this.context.Personajes
                                .Select(p => p.Serie)
                                .Distinct()
                                .ToListAsync();
            return series;
        }


        public async Task<List<Personaje>> GetPersonajesSerie(string serie)
        {
            return await this.context.Personajes.Where(x => x.Serie == serie).ToListAsync();
        }

    }
}