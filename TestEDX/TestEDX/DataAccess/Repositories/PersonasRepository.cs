using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEDX.Comunication;
using TestEDX.Models;

namespace TestEDX.DataAccess
{
    public class PersonasRepository : IPersona
    {
        private ApplicationDbContext context;

        public PersonasRepository(ApplicationDbContext db)
        {
            context = db;
        }
        public void CreatePersona(Personas persona)
        {
            context.Personas.Add(persona);
            context.SaveChanges();
           
        }

        public void DeletePersona(Personas persona)
        {
            context.Personas.Remove(persona);
            context.SaveChanges();
        }

        public Personas GetById(int id)
        {
            return context.Personas.Find(id);
        }

      
        public List<Personas> GetPersonas()
        {
            return context.Personas.ToList();
        }

        public void UpdatePersona(Personas personaN, Personas persona)
        {
            persona.Nombre = personaN.Nombre;
            persona.ApPaterno = personaN.ApPaterno;
            persona.ApMaterno = personaN.ApMaterno;
            context.Entry(persona).State = EntityState.Modified;
            context.SaveChanges();

        }

      
    }
}
