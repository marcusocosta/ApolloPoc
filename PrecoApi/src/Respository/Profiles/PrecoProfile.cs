using AutoMapper;
using Entity.Preco;
using MongoDB.Bson;
using Respository.Models;

namespace Respository.Profiles
{
    public class PrecoProfile : Profile
    {
        public PrecoProfile()
        {
            CreateMap<Preco, PrecoModel>()
            .ForMember(dest=> dest.Id, opt=> ObjectId.GenerateNewId())
            .ForMember(dest=> dest.CodigoProduto, opt=> opt.MapFrom(x=> x.CodigoProduto))
            .ForMember(dest=> dest.Valor, opt=> opt.MapFrom(x=> x.Valor))
            .ForMember(dest=> dest.Data, opt=> opt.MapFrom(x=> x.Data));
        }
    }
}