using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYil.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        //user.GetAll(s => s.UserName == "kardel"); filtreleme yapmak için aşağıdaki expression parametresini function delege olarak tanımlamak gerekir.
        IQueryable<T> GetAll();

        //user.Where(s => s.Username == "kardel").ToList().OrderBy(); Veri tabanına gider sonra sıralama yapar.
        //user.Where(s => s.Username == "kardel").OrderBy(); Veri tabanına gitmeden ön bellekten sıralama yapar.
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities); //Liste halnde gelenleri tutmak için
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
