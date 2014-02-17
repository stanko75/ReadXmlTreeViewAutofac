using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReadXmlTreeViewAutofac.Documentation
{
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
}
