using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Autofac;
using ReadXmlTreeViewAutofac.Interfaces;
using ReadXmlTreeViewAutofac.Model;
using ReadXmlTreeViewAutofac.View;

namespace ReadXmlTreeViewAutofac.ViewModel
{
 public class TreeViewModel
 {
    public static List<string> ReadXml()
    {
      var scope = MainWindow.Container.BeginLifetimeScope();
      var writer = scope.Resolve<IReadXMLMyTree>();
      return writer.ReadXml();
    }
    public List<string> TreeXmlViewModels { get; set; }
    public TreeViewModel()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<MyXmlReader>().As<IReadXMLMyTree>();
      builder.RegisterType<DoMytree>().As<IMyTree>();
      MainWindow.Container = builder.Build();

      TreeXmlViewModels = ReadXml();
    }
  }
}