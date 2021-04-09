using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Interfaces
{
    public interface IBookShopRepository
    {
        void ListAll();
        void ChangeWebURL();
    }
}
