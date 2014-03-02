using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using ReadXmlTreeViewAutofac.Interfaces;

namespace ReadXmlTreeViewAutofac.ViewModel
{
  public class DoMytree : IMyTree
  {
    public List<string> Read(XElement linqMyElement)
    {
      if (linqMyElement != null)
      {
        List<string> TreeViewModels = new List<string>();

        var elements =
          from name in linqMyElement.Elements("items").Elements("item").Elements("childItem").Elements("childName")
          select name;
        TreeViewModels.AddRange(elements.Select(element => element.Value));

        return TreeViewModels;
      }
      else
      {
        return null;
      }
    }
  }
}