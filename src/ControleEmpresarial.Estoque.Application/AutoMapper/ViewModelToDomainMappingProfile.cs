using AutoMapper;
using ControleEmpresarial.Estoque.Application.ViewModel;
using ControleEmpresarial.Estoque.Domain.Entities;

namespace ControleEmpresarial.Estoque.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<MarcaViewModel, Marca>();
            CreateMap<CategoriaViewModel, Categoria>();
            CreateMap<MaterialViewModel, Material>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<AlertaViewModel, Alerta>();
            CreateMap<LocalidadeViewModel, Localidade>();
            CreateMap<SessaoViewModel, Sessao>();
        }
    }
}