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

namespace WPF9Puzzle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime dt;
        Random r = new Random();

        public MainWindow()
        {
            System.Threading.Thread.Sleep(1000);
            InitializeComponent();
            dt = DateTime.Now;
        }

        private void RotatePath(Rectangle r)
        {
            RotateTransform rotateTransform = r.LayoutTransform as RotateTransform;
            rotateTransform.Angle += 90;
            if (rotateTransform.Angle >= 360) rotateTransform.Angle = 0;
            CheckAll();
        }

        private void CheckAll()
        {
            if ((p1.LayoutTransform as RotateTransform).Angle == 0 &&
                (p2.LayoutTransform as RotateTransform).Angle == 0 &&
                (p3.LayoutTransform as RotateTransform).Angle == 0 &&
                (p4.LayoutTransform as RotateTransform).Angle == 0 &&
                (p5.LayoutTransform as RotateTransform).Angle == 0 &&
                (p6.LayoutTransform as RotateTransform).Angle == 0 &&
                (p7.LayoutTransform as RotateTransform).Angle == 0 &&
                (p8.LayoutTransform as RotateTransform).Angle == 0 &&
                (p9.LayoutTransform as RotateTransform).Angle == 0)
            {
                MessageBox.Show(((DateTime.Now - dt).ToString()).Substring(3, 7));
                Environment.Exit(0);
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RotatePath((Rectangle)sender);
        }

        private void pLoaded(object sender, RoutedEventArgs e)
        {
            ((Rectangle)sender).LayoutTransform = new RotateTransform(0);
            RotateTransform rotateTransform = ((Rectangle)sender).LayoutTransform as RotateTransform;
            rotateTransform.Angle = r.Next(0, 4) * 90;
        }
    }
}
