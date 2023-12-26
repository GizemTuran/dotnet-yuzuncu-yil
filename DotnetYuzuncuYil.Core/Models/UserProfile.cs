using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYil.Core.Models
{
    public class UserProfile
    {
        //UserProfile'da BaseEntity'den inherit edilmesine gerek yok çünkü User'da edildiği için oradaki ile aynı zamanda proje oluşturulur veya güncellenir.
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }

        //foreign key
        public int UserId { get; set; }
        public int TeamId { get; set; }
        //birebir ilişki
        //bir kullanıcının bir profili ve bir takımı olacağından aşağıdaki implementasyonlar yapılır.
        public User User { get; set; }
        public Team Team { get; set; }
    }
}
