using System.Collections.Generic;

namespace ReadXmlTreeViewAutofac.Interfaces
{
  public interface IMyTree
  {
    List<string> Read(string myFile);
  }
  public interface IReadXMLMyTree
  {
    List<string> ReadXml();
    List<string> ReadMySql();
  }
}
