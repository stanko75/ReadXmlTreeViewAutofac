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
    public List<string> Read(string myFile)
    {
      List<string> TreeViewModels = new List<string>();
      if (File.Exists(myFile))
      {
        //TreeViewModels.Add("test");
        XElement linqMyElement = XElement.Load(myFile);
        var elements =
          from name in linqMyElement.Elements("items").Elements("item").Elements("childItem").Elements("childName")
          select name;
        TreeViewModels.AddRange(elements.Select(element => element.Value));
      }
      else
      {
        MessageBox.Show("File: " + myFile + " does not exist");
      }
      return TreeViewModels;
    }
  }
}
