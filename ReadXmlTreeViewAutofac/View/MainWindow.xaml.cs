using System.Windows;
using Autofac;

namespace ReadXmlTreeViewAutofac
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public static IContainer Container { get; set; }
    public MainWindow()
    {
      InitializeComponent();
    }
  }
}