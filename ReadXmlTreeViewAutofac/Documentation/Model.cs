using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXmlTreeViewAutofac.Documentation
{
  public class MyXmlReader : IReadXMLMyTree
  {
    private IMyTree _output;
    public MyXmlReader(IMyTree output)
    {
      this._output = output;
    }

    public List<string> ReadXML()
    {
      return this._output.Read(@"somePath");
    }

    public List<string> ReadMySql()
    {
      throw new NotImplementedException();
    }
  }
}
