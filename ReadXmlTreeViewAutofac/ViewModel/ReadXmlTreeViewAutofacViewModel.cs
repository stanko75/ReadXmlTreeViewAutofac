using System.Collections.Generic;

namespace ReadXmlTreeViewAutofac.ViewModel
{

  public interface IRead
  {
    List<string> Read();
  }

  public interface IReadXml
  {
    void ReadXml(string XmlFile);
  }

  public class ReadXmlImpl : IReadXml
  {
    private IRead _read;

    public ReadXmlImpl(IRead read)
    {
      this._read = read;
    }

    public void ReadXml(string XmlFile)
    {
      this._read.Read();
    }
  }

  public class MyReadXml : IRead
  {
    public List<string> Read()
    {
      throw new System.NotImplementedException();
    }
  }
}