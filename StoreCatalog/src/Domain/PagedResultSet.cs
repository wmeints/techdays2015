using System;
using System.Collections.Generic;
using MongoDB;
using MongoDB.Bson;

namespace Catalog {
  public class PagedResultSet<TEntity> {

    public PagedResultSet(IEnumerable<TEntity> items, int pageIndex, int pageSize, long totalItemCount) {
      this.Items = items;
      this.PageIndex = pageIndex;
      this.PageSize = pageSize;
      this.TotalItemCount = totalItemCount;
    }

    public long TotalItemCount { get; private set; }
    public int PageSize { get; private set; }
    public int PageIndex { get; private set; }
    public IEnumerable<TEntity> Items { get; private set; }
  }
}
