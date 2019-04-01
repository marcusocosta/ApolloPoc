using AutoMapper;
using Entity.Produto;
using MongoDB.Bson;
using Respository.Models;

namespace Respository.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoModel>()
            .ForMember(dest=> dest.Id, opt=> ObjectId.GenerateNewId())
            .ForMember(dest=> dest.Codigo, opt=> opt.MapFrom(x=> x.Codigo))
            .ForMember(dest=> dest.CodigoBarras, opt=> opt.MapFrom(x=> x.CodigoBarras))
            .ForMember(dest=> dest.Nome, opt=> opt.MapFrom(x=> x.Nome));
        }
    }
}