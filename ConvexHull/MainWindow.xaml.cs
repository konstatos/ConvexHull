using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConvexHull
{
  /// <summary> Отображение работы </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void _bOpen_Click(object sender, RoutedEventArgs e)
    {
      var ctrl = new ConvexHullControl(new OpenImageToBitmap("p.png"), new JarvisMatch(), new OutputToCanvas(_cSource));
    }
  }
}
