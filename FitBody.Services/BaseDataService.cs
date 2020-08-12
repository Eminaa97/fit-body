﻿using AutoMapper;
using FitBody.DataBase;
using FitBody.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitBody.Services
{
    public interface IBaseDataService<TModel, TDto, TInsertModel>
        where TModel : class, IEntity
        where TDto : class
        where TInsertModel : class
    {
        void Delete(int id);
        void Delete(TModel model);
        IList<TDto> Get();
        IList<TDto> Get(Func<TModel, bool> predicate);
        TDto Get(int id);
        TDto Insert(TModel obj);
        TDto Insert(TInsertModel obj);
        void Update(TModel entity);
    }

    public class BaseDataService<TModel, TDto, TInsertModel> : IBaseDataService<TModel, TDto, TInsertModel>
        where TModel : class, IEntity
        where TDto : class
        where TInsertModel : class
    {
        protected DbSet<TModel> _table;
        protected readonly FitBodyContext _context;
        protected readonly IMapper _mapper;

        public BaseDataService(
            FitBodyContext context,
            IMapper mapper
            )
        {
            _table = context.Set<TModel>();
            _context = context;
            _mapper = mapper;
        }

        public virtual IList<TDto> Get()
        {
            return _mapper.Map<IList<TDto>>(_table.AsNoTracking().ToList());
        }

        public virtual IList<TDto> Get(Func<TModel, bool> predicate)
        {
            return _mapper.Map<IList<TDto>>(_table.Where(predicate).ToList());
        }

        public virtual TDto Get(int id)
        {
            return _mapper.Map<TDto>(_table.AsNoTracking().FirstOrDefault(a => a.Id == id));
        }

        public virtual TDto Insert(TInsertModel obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Entity");
            }

            var entity = _mapper.Map<TModel>(obj);

            _table.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<TDto>(entity);
        }

        public virtual TDto Insert(TModel obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Entity");
            }

            _table.Add(obj);
            _context.SaveChanges();
            return _mapper.Map<TDto>(obj);
        }

        public virtual void Delete(int id)
        {
            var deleted = _table.FirstOrDefault(a => a.Id == id);
            if (deleted == null)
                return;

            Delete(deleted);
        }

        public virtual void Delete(TModel model)
        {
            if (_context.Entry(model).State == EntityState.Detached)
            {
                _table.Attach(model);
            }
            _table.Remove(model);
            _context.SaveChanges();
        }

        public virtual void Update(TModel entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
