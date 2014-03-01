﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Autofac;
using ReadXmlTreeViewAutofac.Documentation;

namespace ReadXmlTreeViewAutofac.ViewModel
{
 public class TreeViewModel
  {
    public static List<string> ReadXML()
    {
      var scope = MainWindow.Container.BeginLifetimeScope();
      var writer = scope.Resolve<IReadXMLMyTree>();
      return writer.ReadXml();
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