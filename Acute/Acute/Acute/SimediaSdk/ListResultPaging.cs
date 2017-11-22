using System;
using System.Collections.Generic;
using System.Text;

namespace Simedia.App.SDK
{
    public class ListResultPaging
    {

        public ListResultPaging() { }


        public ListResultPaging(int skip, long take, long total)
        {

            total_items = total;
            page_size = take;

            //make sure it rounds up wihtout dropping a page
            if (total < 1 || take < 1)
            {
                total_pages = 0; // avoid divide by 0 or just junk work 
            }
            else
            {
                total_pages = (int)Math.Ceiling((double)total / (double)take);
            }

            //pages start at 1
            if (skip + take <= take)
            {
                //should never happen, but want to avoid returning -1 in any case
                current_page = 1;
            }
            else
            {
                current_page = (int)Math.Ceiling((double)(skip + take) / (double)take);
            }
        }

        public long total_items { get; set; }
        public long total_pages { get; set; }
        public long page_size { get; set; }
        public long current_page { get; set; }
        public DateTime? paging_utc { get; set; }
    }
}
