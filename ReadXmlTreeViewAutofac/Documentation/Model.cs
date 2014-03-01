using System;
using System.Collections.Generic;

namespace ReadXmlTreeViewAutofac.Documentation
{
  public class MyXmlReader : IReadXMLMyTree
  {
    private readonly IMyTree _output;
    public MyXmlReader(IMyTree output)
    {
      this._output = output;
    }

    public List<string> ReadXml()
    {
      return this._output.Read(AppDomain.CurrentDomain.BaseDirectory + @"..\..\MyXML.xml");
    }

    public List<string> ReadMySql()
    {
      throw new NotImplementedException();
    }
  }
}
