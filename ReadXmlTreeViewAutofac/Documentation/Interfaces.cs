using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXmlTreeViewAutofac.Documentation
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
