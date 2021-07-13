﻿using System;
using Contact.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using Contact.Core;

namespace Contact.DataAccess
{
    public interface IEntityRepository<T>where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);  
    }
}