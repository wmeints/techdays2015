using System;

namespace Catalog {
  public class UpdateBookData {
    public String Title { get; set; }
    public String Description { get; set; }
    public String Genre { get; set; }
    public DateTime PublicationDate { get; set; }
    public Author Author { get; set; }
  }
}
