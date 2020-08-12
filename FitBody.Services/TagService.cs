using AutoMapper;
using FitBody.Common.Contracts;
using FitBody.DataBase;
using FitBody.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FitBody.Services
{
    public interface ITagService : IBaseDataService<Tag, TagDto, TagInsertModel>
    {
        IList<TagDto> GetPerPost(int postId);
        IList<TagDto> Get(TagSearchRequest request);

    }

    public class TagService : BaseDataService<Tag, TagDto, TagInsertModel>, ITagService
    {
        public TagService(FitBodyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IList<TagDto> GetPerPost(int postId)
        {
            return _context.PostTags.Where(x => x.PostId == postId).Select(x => new TagDto
            {
                Id = x.TagId,
                Title = x.Tag.Title
            }).AsNoTracking().ToList();
        }
        public IList<TagDto> Get(TagSearchRequest request)
        {
            var tags = _context.Tags.Where(a => a.Title.Contains(request.Title)).ToList();
            return _mapper.Map<IList<TagDto>>(tags);
        }
    }
}
