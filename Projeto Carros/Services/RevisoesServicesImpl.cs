using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Carros.Models;

namespace Projeto_Carros.Services.Implementation
{
    public class RevisoesServicesImpl : IRevisoesServices
    {
        ApplicationContext _applicationContext;

        public RevisoesServicesImpl(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Revisoes Create(Revisoes revisoes)
        {
            try
            {
                _applicationContext.Add(revisoes);
                _applicationContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return revisoes;
        }
    }
}
