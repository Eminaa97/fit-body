using AutoMapper;
using FitBody.Common.Contracts;
using FitBody.DataBase;
using FitBody.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FitBody.Services
{
    public interface IThreadService : IBaseDataService<Thread, ThreadDto, ThreadInsertModel>
    {
        IList<ThreadDto> Get(ThreadSearchRequest request);

    }

    public class ThreadService : BaseDataService<Thread, ThreadDto, ThreadInsertModel>, IThreadService
    {
        public ThreadService(FitBodyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<ThreadDto> Get()
        {
            return _mapper.Map<IList<ThreadDto>>(_context.Threads.Include(x => x.User).ToList());
        }

        public override ThreadDto Get(int id)
        {
            return _mapper.Map<ThreadDto>(_context.Threads.Include(x => x.User).FirstOrDefault(x => x.Id == id));
        }

        public IList<ThreadDto> Get(ThreadSearchRequest request)
        {
            var list = _context.Threads.Include(x => x.User).Where(a => a.Title.Contains(request.Title)).ToList();
            return _mapper.Map<IList<ThreadDto>>(list);
        }

        public override void Delete(int id)
        {
            var comments = _context.ThreadComments.Where(a => a.ThreadId == id).ToList();
            _context.ThreadComments.RemoveRange(comments);
            base.Delete(id);
        }
    }
}
