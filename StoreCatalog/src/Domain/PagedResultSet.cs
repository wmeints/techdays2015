using System;
using System.Collections.Generic;
using MongoDB;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Catalog {
  public class PagedResultSet<TEntity> {

    public PagedResultSet(IEnumerable<TEntity> items, int pageIndex, int pageSize, long totalItemCount) {
      this.Items = items;
      this.PageIndex = pageIndex;
      this.PageSize = pageSize;
      this.TotalItemCount = totalItemCount;
    }

    [JsonProperty("totalItemCount")]
    public long TotalItemCount { get; private set; }

    [JsonProperty("pageSize")]
    public int PageSize { get; private set; }

    [JsonProperty("pageIndex")]
    public int PageIndex { get; private set; }

    [JsonProperty("items")]
    public IEnumerable<TEntity> Items { get; private set; }
  }
}
