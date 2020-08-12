using AutoMapper;
using FitBody.Common.Contracts;
using FitBody.DataBase;
using FitBody.Models;
using System.Collections.Generic;
using System.Linq;

namespace FitBody.Services
{
    public interface ICategoryService : IBaseDataService<Category, CategoryDto, CategoryInsertModel>
    {
        IList<CategoryDto> Get(CategorySearchRequest request);

    }

    public class CategoryService : BaseDataService<Category, CategoryDto, CategoryInsertModel>, ICategoryService
    {
        public CategoryService(FitBodyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public IList<CategoryDto> Get(CategorySearchRequest request)
        {
            var categories = _context.Categories.Where(a => a.Title.Contains(request.Title)).ToList();
            return _mapper.Map<IList<CategoryDto>>(categories);
        }
    }
}
