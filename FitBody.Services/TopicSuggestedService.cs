using AutoMapper;
using FitBody.Common.Contracts;
using FitBody.DataBase;
using FitBody.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FitBody.Services
{
    public interface ITopicSuggestedService : IBaseDataService<TopicSuggested, TopicSuggestedDto, TopicSuggestedInsertModel>
    {
        IList<TopicSuggestedDto> SuggestedTopicsForUser(int userID);

    }

    public class TopicSuggestedService : BaseDataService<TopicSuggested, TopicSuggestedDto, TopicSuggestedInsertModel>, ITopicSuggestedService
    {
        public TopicSuggestedService(FitBodyContext context, IMapper mapper) : base(context, mapper)
        {
            
        }
        public IList<TopicSuggestedDto> SuggestedTopicsForUser(int userID)
        {
           var topics =  _context.TopicsSugested.Where(a => a.UserId == userID)
                .Include(a=>a.User)
                .ToList();
            return _mapper.Map<IList<TopicSuggestedDto>>(topics);
        }
        public override IList<TopicSuggestedDto> Get()
        {
            var topics = _context.TopicsSugested
                .Include(a => a.User)
                .ToList();
            return _mapper.Map<IList<TopicSuggestedDto>>(topics);
        }
        public override TopicSuggestedDto Get(int id)
        {
            var topics = _context.TopicsSugested
                 .Include(a => a.User)
                 .FirstOrDefault(a=>a.Id==id);
            return _mapper.Map<TopicSuggestedDto>(topics);
        }
        public override TopicSuggestedDto Insert(TopicSuggestedInsertModel obj)
        {
            obj.DateCreated = DateTime.UtcNow;
            return base.Insert(obj);
        }
    }
}
