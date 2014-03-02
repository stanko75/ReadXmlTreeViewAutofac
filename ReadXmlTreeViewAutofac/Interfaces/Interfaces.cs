using System.Collections.Generic;
using System.Xml.Linq;

namespace ReadXmlTreeViewAutofac.Interfaces
{
  public interface IMyTree
  {
    List<string> Read(XElement linqMyElement);
  }
  public interface IReadXMLMyTree
  {
    List<string> ReadXml();
    List<string> ReadMySql();
  }
}
