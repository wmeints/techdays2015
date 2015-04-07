using System;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Catalog {
  public class Author {
    public Author() {

    }

    public Author(string name, string biography) {
      this.Name = name;
      this.Biography = biography;
    }

    [JsonProperty("name")]
    public String Name { get; set; }

    [JsonProperty("biography")]
    public String Biography { get; set; }
  }
}
