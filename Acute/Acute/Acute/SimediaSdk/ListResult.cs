using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Simedia.App.SDK
{
    public class ListResult<T> : ActionResult
    {
        public ListResult()
        {
            this.items = new List<T>();
        }
        public ListResult(List<T> items)
        {
            this.items = items;
        }
        public ListResult(IEnumerable<T> items, ListResultPaging pages)
        {
            this.items = items.ToList();
            this.paging = pages;
        }

        public virtual List<T> items { get; set; }

        public virtual ListResultPaging paging { get; set; }

        public virtual string more { get; set; }

    }

    public class ListResult<TData, TMeta> : ListResult<TData>
        where TMeta : new()
    {
        public ListResult()
        {
            this.meta = new TMeta();
        }

        public virtual TMeta meta { get; set; }
    }
}
