using System;
using System.Collections.Generic;
using System.Text;

namespace Simedia.App.SDK
{
    public class ItemResult<T> : ActionResult
    {
        public T item { get; set; }
        public string meta { get; set; }

        public ItemResult()
        {
        }

        public ItemResult(T item, string meta = null)
        {
            this.item = item;
            this.meta = meta;
        }
    }

    public class ItemResult<TData, TMeta> : ActionResult
    {
		public TData item { get; set; }
        public virtual TMeta meta { get; set; }

        public ItemResult()
        {
            this.meta = default(TMeta);
        }

        public ItemResult(TData item, TMeta meta)
        {
            this.item = item;
            this.meta = meta;
        }
    }
}
