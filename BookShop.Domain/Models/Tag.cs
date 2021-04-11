using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Models
{
    public class Tag
    {
        public string TagId { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
