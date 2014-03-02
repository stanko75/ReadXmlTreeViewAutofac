using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using ReadXmlTreeViewAutofac.Interfaces;

namespace ReadXmlTreeViewAutofac.Model
{
  public class MyReader : IReadMyTree
  {
    private readonly IMyTree _output;
    public MyReader(IMyTree output)
    {
      this._output = output;
    }

    public List<string> ReadXml()
    {
      var treeViewModels = new List<string>();
      string myFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\MyXML.xml";

      if (File.Exists(myFile))
      {
        //TreeViewModels.Add("test");
        XElement linqMyElement = XElement.Load(myFile);

        var elements =
          from name in linqMyElement.Elements("items").Elements("item").Elements("childItem").Elements("childName")
          select name;

        var pom = elements.Select(xElement => xElement.Value).ToList();

        return _output.Read(pom);
      }
      else
      {
        return null;
      }
    }

    public List<string> ReadMySql()
    {
      string MyConString =
      "SERVER=server;" +
      "DATABASE=db;" +
      "UID=user;" +
      "PASSWORD=pass;Convert Zero Datetime=True";

      string sql = "select * from jos_categories";

      try
      {
        var connection = new MySqlConnection(MyConString);
        var cmdSel = new MySqlCommand(sql, connection);

        connection.Open();

        MySqlDataReader dataReader = cmdSel.ExecuteReader();

        var pom = new List<string>();

        while (dataReader.Read())
        {
            object bugId = dataReader["title"];
            pom.Add(bugId.ToString());
        }

        return _output.Read(pom);
      }
      catch (Exception e)
      {
        MessageBox.Show("Error: " + e);
      }
      return null;
    }
  }
}
