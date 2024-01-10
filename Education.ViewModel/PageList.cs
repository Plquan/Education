using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel
{
    public class PageList
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }

    }
}
