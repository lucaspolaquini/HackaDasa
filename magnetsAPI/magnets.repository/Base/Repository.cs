using magnets.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace magnets.repository.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected AvaliaFacilDB Db = new AvaliaFacilDB();

        public void Add(TEntity obj)
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }
        public TEntity GetById(int id)
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            return Db.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            return Db.Set<TEntity>().ToList();
        }
        public void Update(TEntity obj)
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
        public void Remove(TEntity obj)
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, Boolean>> filtro)
        {
            return Db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, Boolean>> filtro)
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            return Db.Set<TEntity>().Where(filtro).ToList();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        
    }
}
