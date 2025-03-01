using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using HotelReservationSystem.Data;
using System;
using HotelReservationSystem.Data.Entities;

namespace HotelReservationSystem.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T :BaseModel
    {

        private readonly ApplicationDbContext _dbContext;
        DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }


        public async Task AddAsync(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var Entity = await GetByIdWithTrackingAsync(id);
            Entity.IsDeleted = true;
            _dbContext.SaveChanges();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> Predicate)
        {
            return GetAll().Where(Predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().Where(E => !E.IsDeleted);

        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>()
                .Where(E => !E.IsDeleted && E.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T?> GetByIdWithTrackingAsync(int id)
        {
            return await _dbContext.Set<T>()
               .Where(E => !E.IsDeleted && E.Id == id)
               .AsTracking()
               .FirstOrDefaultAsync();
        }

        public void Update(T item)
        {
            _dbContext.Set<T>().Update(item);
            _dbContext.SaveChanges();
        }

        public void UpdateInclude(T item, params string[] modifiedProperties)
        {

            if (!_dbSet.Any(x => x.Id == item.Id))
                return;

            var Local = _dbSet.Local.FirstOrDefault(x => x.Id == item.Id);
            EntityEntry entityEntry;

            if (Local is null)
                entityEntry = _dbContext.Entry(item);
            else
                entityEntry = _dbContext.ChangeTracker.Entries<T>().FirstOrDefault(x => x.Entity.Id == item.Id);

            foreach (var property in entityEntry.Properties)
            {
                if (modifiedProperties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = item.GetType().GetProperty(property.Metadata.Name).GetValue(item);
                    property.IsModified = true;
                }
            }

            _dbContext.SaveChanges();
        }





    }
}
