using System.Collections.Generic;
using Autofac;
using ReadXmlTreeViewAutofac.Interfaces;
using ReadXmlTreeViewAutofac.Model;
using ReadXmlTreeViewAutofac.View;

namespace ReadXmlTreeViewAutofac.ViewModel
{
  public class ReadMySqlTreeViewAutofacViewModel
  {
    public static List<string> ReadMySql()
    {
      var scope = MainWindow.Container.BeginLifetimeScope();
      var writer = scope.Resolve<IReadMyTree>();
      return writer.ReadMySql();
    }
    public List<string> TreeMySqlViewModels { get; set; }
    public ReadMySqlTreeViewAutofacViewModel()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<MyReader>().As<IReadMyTree>();
      builder.RegisterType<DoMytree>().As<IMyTree>();
      MainWindow.Container = builder.Build();

      TreeMySqlViewModels = ReadMySql();
    }
  }
}