using System;
using MongoDB.Bson;

namespace Catalog {
  public class Author {
    public Author() {

    }

    public Author(string name, string biography) {
      this.Name = name;
      this.Biography = biography;
    }

    public String Name { get; set; }
    public String Biography { get; set; }
  }
}
