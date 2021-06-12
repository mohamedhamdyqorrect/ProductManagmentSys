using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Core
{

    public class PagedListWithCountsResult<TList>
    {
        public List<TList> List { get; set; }
        public int ListCount { get { return List == null ? 0 : List.Count; } }
        public long TotalCount { get; set; }
        public long TotalCountWithoutFilter { get; set; }

        public PagedListWithCountsResult(List<TList> list, long totalCount)
        {
            List = list;
            TotalCount = totalCount;
        }

        public PagedListWithCountsResult(List<TList> list, long totalCount, long totalCountWithoutFilter)
        {
            List = list;
            TotalCount = totalCount;
            TotalCountWithoutFilter = totalCountWithoutFilter;
        }
    }
}
