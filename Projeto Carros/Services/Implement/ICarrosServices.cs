using Projeto_Carros.Models;
using System.Collections.Generic;

namespace Projeto_Carros.Services
{
    public interface ICarrosServices
    {
        IEnumerable<Carros> Lista();
        Carros Create(Carros carros);
        Carros FindById(int Codigo);
        Carros Update(Carros carros);
        void Delete(int Codigo);
    }
}
