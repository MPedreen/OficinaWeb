using AutoMapper;
using OficinaWeb.Domain;
using OficinaWeb.Models;

namespace OficinaWeb.API.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain   
            CreateMap<ProdutoViewModel, Produto>();
            #endregion

            #region DomainToViewModel 
            CreateMap<Produto, ProdutoViewModel>();
            #endregion

            #region ViewModelToDomain   
            CreateMap<CarroViewModel, Carro>();
            #endregion

            #region DomainToViewModel 
            CreateMap<Carro, CarroViewModel>();
            #endregion
        }
    }
}