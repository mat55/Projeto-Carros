using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Carros.Models;

namespace Projeto_Carros.Services
{
    public class CarrosServicesImpl : ICarrosServices
    {
        private ApplicationContext _applicationContext;

        public CarrosServicesImpl(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Carros Create(Carros carros)
        {
            try
            {
                _applicationContext.Add(carros);
                _applicationContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return carros;
        }

        public IEnumerable<Carros> Lista()
        {
            return _applicationContext.Carros
                 .Include(d => d.Revisoes)   
                 .ToList();
        }

        public Carros FindById(int Codigo)
        {
            return _applicationContext.Carros
                .Include(i => i.Revisoes)
                .SingleOrDefault(i => i.Codigo.Equals(Codigo));
        }

        public Carros Update(Carros carros)
        {
            if (!_applicationContext.Carros.Any(p => p.Codigo == carros.Codigo))
            {
                return new Carros();
            }

            var result = _applicationContext.Carros.SingleOrDefault(b => b.Codigo == carros.Codigo);
            if (result != null)
            {
                try
                {
                    _applicationContext.Entry(result).CurrentValues.SetValues(carros);
                    _applicationContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public void Delete(int Codigo)
        {
            var result = _applicationContext.Carros.SingleOrDefault(p => p.Codigo.Equals(Codigo));
            try
            {
                if (result != null)
                {
                    _applicationContext.Carros.Remove(result);
                    _applicationContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
