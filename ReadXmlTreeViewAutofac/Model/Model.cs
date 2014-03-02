using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using ReadXmlTreeViewAutofac.Interfaces;

namespace ReadXmlTreeViewAutofac.Model
{
  public class MyXmlReader : IReadXMLMyTree
  {
    private readonly IMyTree _output;
    public MyXmlReader(IMyTree output)
    {
      this._output = output;
    }

    public List<string> ReadXml()
    {
      List<string> TreeViewModels = new List<string>();
      string myFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\MyXML.xml";

      if (File.Exists(myFile))
      {
        //TreeViewModels.Add("test");
        XElement linqMyElement = XElement.Load(myFile);
        return this._output.Read(linqMyElement);
      }
      else
      {
        return null;
      }
    }

    public List<string> ReadMySql()
    {
      string MyConString =
      "SERVER=server" +
      "DATABASE=dn" +
      "UID=user;" +
      "PASSWORD=pass;Convert Zero Datetime=True";

      string sql = "select * from jos_categories";

      try
      {
        var connection = new MySqlConnection(MyConString);
        var cmdSel = new MySqlCommand(sql, connection);
        var dt = new DataTable();
        var da = new MySqlDataAdapter(cmdSel);
        da.Fill(dt);
        //dataGrid1.DataContext = dt;
      }
      catch
      {
        MessageBox.Show("No connection to database");
      }
      return null;
    }
  }
}
