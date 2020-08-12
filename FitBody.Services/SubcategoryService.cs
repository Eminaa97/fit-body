using AutoMapper;
using FitBody.Common.Contracts;
using FitBody.DataBase;
using FitBody.Models;

namespace FitBody.Services
{
    public interface ISubcategoryService : IBaseDataService<Subcategory, SubcategoryDto, SubcategoryInsertModel>
    {
    }

    public class SubcategoryService : BaseDataService<Subcategory, SubcategoryDto, SubcategoryInsertModel>, ISubcategoryService
    {
        public SubcategoryService(FitBodyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
