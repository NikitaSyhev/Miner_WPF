using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Runtime.Remoting.Contexts;

namespace Miner
{
    internal class Cell
    {
        private Button myButton;
        public Button button { get { return myButton;} }
        private string Name;
        public string name { get { return Name; } }
        private int x;
        public int X {get {return x;} }
        private int y;
        public int Y { get { return y; } }
        private bool IsMine = false;
        public bool isMine { get { return IsMine; } }
        private string Reverse = " ";
        public string reverse { get { return Reverse; } }
        private int CountMineArround = 0;
        public int countMineArround { get { return CountMineArround; } }
        public Cell(string name, int x, int y, string _content = " ", bool printMine = false)
        {
            this.myButton = new Button();
            this.x = x;
            this.y = y;
            this.myButton.Height = 70;
            this.myButton.Width = 70;
            this.myButton.FontSize = 20;
            this.myButton.HorizontalAlignment = HorizontalAlignment.Center;
            this.myButton.VerticalAlignment = VerticalAlignment.Center;
            this.Name = name;  
            this.myButton.Content = _content;
            this.myButton.Click += MyButton_Click;
        }
        private void setReverse(string _reverse)
        {
            this.Reverse = _reverse;
        }

        public void MyButton_Click(object sender, RoutedEventArgs e)
        {
            this.myButton.Content = this.Reverse;
            switch (reverse)
            {
                case "1":
                    this.myButton.Background = Brushes.LightGreen;
                    break;
                case "2":
                    this.myButton.Background = Brushes.LightPink;
                    break;
                case "3":
                    this.myButton.Background = Brushes.LightSkyBlue;
                    break;
                case "4":
                    this.myButton.Background = Brushes.LightYellow;
                    break;
                case "5":
                    this.myButton.Background = Brushes.LightSlateGray;
                    break;
                case "B":
                    this.myButton.Background = Brushes.IndianRed;
                    break;
                default:
                    break;
            }
            
        }
        public void growCountOfMineArround()
        {
            this.CountMineArround++;
            this.Reverse = $"{CountMineArround}";
        }
        public void setBomb()
        {
            this.IsMine = true;
            this.Reverse = "B";
        }
    }
}
