using System.Collections.Generic;
using System.Windows.Documents;
using System.Xml.Linq;

namespace ReadXmlTreeViewAutofac.Interfaces
{
  public interface IMyTree
  {
    List<string> Read(List<string> listMyElements);
  }
  public interface IReadXMLMyTree
  {
    List<string> ReadXml();
    List<string> ReadMySql();
  }
}
