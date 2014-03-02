using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Linq;
using ReadXmlTreeViewAutofac.Interfaces;

namespace ReadXmlTreeViewAutofac.ViewModel
{
  public class DoMytree : IMyTree
  {
    public List<string> Read(List<string> listMyElements)
    {
      if (listMyElements.Any())
      {
        return listMyElements;
        //List<string> TreeViewModels = new List<string>();


        //TreeViewModels.AddRange(elements.Select(element => element.Value));

        //return TreeViewModels;
      }
      else
      {
        return null;
      }
    }
  }
}