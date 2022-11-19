using keyboard_v7;
using System;
using System.Collections.Generic;
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
namespace KeyBoardTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            Application.Current.MainWindow.Height = 620;
            Application.Current.MainWindow.MaxHeight = 620;
            Application.Current.MainWindow.MinHeight = 620;
            Application.Current.MainWindow.Width = 1160;
            Application.Current.MainWindow.MaxWidth = 1160;
            Application.Current.MainWindow.MinWidth = 1160;
            MyKeyBoard kb = new MyKeyBoard(GetWindow(this));
            kb.ShowTrainer();
        }
    }
}