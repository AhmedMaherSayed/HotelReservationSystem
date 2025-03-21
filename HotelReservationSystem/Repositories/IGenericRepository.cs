﻿using HotelReservationSystem.Data.Entities;
using System.Linq.Expressions;

namespace HotelReservationSystem.Repositories
{
    public interface IGenericRepository<T> where T : BaseModel
    {

        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdWithTrackingAsync(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> Predicate);
        Task AddAsync(T item);
        void Update(T item);
        void UpdateInclude(T item, params string[] modifiedProperties);
        Task Delete(int id);

    }
}
