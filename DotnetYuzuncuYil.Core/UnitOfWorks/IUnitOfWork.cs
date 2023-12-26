using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYil.Core.UnitOfWorks
{
    //Burada savechanges işlemleri gerçekleşir bunun sonucunda yapılan değişikler veri tabanına yansır.
    public interface IUnitOfWork //Amaç: Farklı repolarda yapılan transaction işlemini tek bir repoda toplamak
    {
        Task CommitAsync();
        void Commit();
    }
}
