using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi5shirleyrios.Model;

namespace WebApi5shirleyrios.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get(); 
        
        Task<Book> Get(int id);

        Task<Book> Create(Book book);

        Task update(Book book);
       
        Task Delete(int id);



    }
}
