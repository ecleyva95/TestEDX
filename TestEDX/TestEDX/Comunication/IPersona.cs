using TestEDX.Models;

namespace TestEDX.Comunication
{
    public interface IPersona
    {
        List<Personas> GetPersonas();
        void CreatePersona(Personas persona);
        Personas GetById(int id);
        void UpdatePersona(Personas personaN, Personas personaV);
        void DeletePersona(Personas persona);



    }
}
