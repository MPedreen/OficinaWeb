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

        }
    }
}