using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBase.Infrastracture
{
    public class BaseService<T> where T:BaseEntity
    {
        private DataContext _ctx;
        public BaseService(DataContext ctx)
        {
            _ctx = ctx;
        }
        protected IQueryable<T> GetNotDeleted()
        {
           return _ctx.Set<T>().Where(e => e.IsDeleted == false);
        }
        public IEnumerable<T> GetAll()
        {
            return GetNotDeleted().AsNoTracking().ToList();
        }
        public async Task<int> Add(T t)
        {
            _ctx.Set<T>().Add(t);
           await _ctx.SaveChangesAsync();
            return t.Id;
        }
        public T GetById(int id)
        {
           var entity= _ctx.Set<T>().SingleOrDefault(e => e.Id == id);
            if (entity == null)
                throw new ArgumentException($"未找到id={ id}的数据");
            return entity;
        }
        public async Task SoftDeleted(int id)
        {
            var entity = _ctx.Set<T>().SingleOrDefault(e => e.Id == id);
            if (entity == null)
                throw new ArgumentException($"未找到id={ id}的数据");
            entity.IsDeleted = true;
            await _ctx.SaveChangesAsync();
        }
    }
}
