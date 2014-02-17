using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Autofac;

namespace ReadXmlTreeViewAutofac.ViewModel
{
  public interface IMyTree
  {
    List<string> Read(string myFile);
  }
  public interface IReadXMLMyTree
  {
    List<string> ReadXML();
  }
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
  }

  public class DoMytree : IMyTree
  {
    public List<string> Read(string myFile)
    {
      List<string> TreeViewModels = new List<string>();
      //TreeViewModels.Add("test");
      XElement linqMyElement = XElement.Load(myFile);
      var elements =
        from name in linqMyElement.Elements("elementCS").Elements("elementC").Elements("elementU")
        select name;
      foreach (var element in elements)
      {
        TreeViewModels.Add(element.Value);
      }
      return TreeViewModels;
    }
  }

  public class TreeViewModel
  {
    public static List<string> ReadXML()
    {
      var scope = MainWindow.Container.BeginLifetimeScope();
      var writer = scope.Resolve<IReadXMLMyTree>();
      return writer.ReadXML();
    }
    public List<string> TreeViewModels { get; set; }
    public TreeViewModel()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<MyXmlReader>().As<IReadXMLMyTree>();
      builder.RegisterType<DoMytree>().As<IMyTree>();
      MainWindow.Container = builder.Build();

      TreeViewModels = ReadXML();
    }
  }
}