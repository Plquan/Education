using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel.Paging
{
    public class PagedResult<T> : PagedResultbase 
    {
        public List<T> Items { set; get; }
    }
}
