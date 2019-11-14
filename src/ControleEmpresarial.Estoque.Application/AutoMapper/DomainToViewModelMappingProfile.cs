using AutoMapper;
using ControleEmpresarial.Estoque.Application.ViewModel;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Marca, MarcaViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Material, MaterialViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Alerta, AlertaViewModel>();
            CreateMap<Localidade, LocalidadeViewModel>();
            CreateMap<Sessao, SessaoViewModel>();
        }
    }
}