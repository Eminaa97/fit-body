using AutoMapper;
using FitBody.Common.Contracts;
using FitBody.DataBase;
using FitBody.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitBody.Services
{
    public interface ICommentService : IBaseDataService<Comment, CommentDto, CommentInsertModel>
    {
        IList<CommentDto> GetByThread(int threadId);
        IList<CommentDto> GetByPost(int postId);
    }

    public class CommentService : BaseDataService<Comment, CommentDto, CommentInsertModel>, ICommentService
    {
        public CommentService(FitBodyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IList<CommentDto> GetByThread(int threadId)
        {
            var data = _context.ThreadComments
                .Include(a=>a.Comment)
                .ThenInclude(a=>a.User)
                .Where(x => x.ThreadId == threadId)
                .Select(x => x.Comment)
                .ToList();

            return _mapper.Map<IList<CommentDto>>(data);
        }

        public IList<CommentDto> GetByPost(int postId)
        {
            var data = _context.PostComments
                .Include(a => a.Comment)
                .ThenInclude(a => a.User)
                .Where(x => x.PostId == postId)
                .Select(x => x.Comment)
                .ToList();

            return _mapper.Map<IList<CommentDto>>(data);
        }

        public override CommentDto Insert(CommentInsertModel obj)
        {
            if (!obj.UserId.HasValue)
            {
                return null;
            }

            if (obj.ThreadId.HasValue)
            {
                var comment = _mapper.Map<Comment>(obj);
                _context.Add(comment);

                _context.ThreadComments.Add(new ThreadComment
                {
                    Comment = comment,
                    ThreadId = obj.ThreadId.Value
                });
                comment.DatePosted = DateTime.UtcNow;
                _context.SaveChanges();

                comment = _context.Comments.Include(x => x.User).FirstOrDefault(y => y.Id == comment.Id);

                return _mapper.Map<CommentDto>(comment);
            }
            else if (obj.PostId.HasValue)
            {
                var comment = _mapper.Map<Comment>(obj);
                _context.Add(comment);

                _context.PostComments.Add(new PostComment
                {
                    Comment = comment,
                    PostId = obj.PostId.Value
                });
                comment.DatePosted = DateTime.UtcNow;
                _context.SaveChanges();

                comment = _context.Comments.Include(x => x.User).FirstOrDefault(y => y.Id == comment.Id);

                return _mapper.Map<CommentDto>(comment);
            }
            else return null;
        }
    }
}
