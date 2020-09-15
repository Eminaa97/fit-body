using AutoMapper;
using FitBody.Common.Contracts;
using FitBody.DataBase;
using FitBody.Models;
using System.Linq;

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

        public override SubcategoryDto Insert(SubcategoryInsertModel obj)
        {
            var existing = _context.SubCategories
                .FirstOrDefault(x => x.Title == obj.Title && x.CategoryId == obj.CategoryId);

            if (existing == null)
            {
                return base.Insert(obj);
            }
            return null;
        }
    }
}
