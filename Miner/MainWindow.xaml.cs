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

namespace Miner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitBoard();
            SetMineLocation(4);
            //ImageSource imageSource =
            //    new BitmapImage(new Uri("Bomb.jpg", UriKind.Relative));
            //cell_img.image.Source = imageSource;

        }
        private List<Cell> cells = new List<Cell>(64);
        private void InitBoard()
        {
            var myGrid = new Grid();
            this.AddChild(myGrid);
            myGrid.ShowGridLines = true;
            for (int i = 0; i < 9; i++)
            {
                myGrid.RowDefinitions.Add(new RowDefinition());
                myGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            
            for (int i = 0; i < 64; i++)
            {
                var cell = new Cell($"cell_{i}", i % 8, i / 8, $"{i}"/*, true*/);
                cells.Add(cell);
                
                myGrid.Children.Add(cell.button);
                Grid.SetColumn(cell.button, cell.X);
                Grid.SetRow(cell.button, cell.Y);

            }
            // Добавление кнопки в правый нижний угол
            var cell_99 = new Cell("cell_99", 9, 9);
            myGrid.Children.Add(cell_99.button);
            Grid.SetColumn(cell_99.button, cell_99.X);
            Grid.SetRow(cell_99.button, cell_99.Y);
            cell_99.button.Click += Button_Click02;

            //cells[4].changeText("Bomb");

        }

        private void Button_Click02(object sender, RoutedEventArgs e)
        {
            foreach (var item in cells)
            {
                item.button.Content = item.reverse;
                item.MyButton_Click(sender, e);
            }
        }

        private void SetMineLocation(int _number)
        {
            Random random = new Random(DateTimeOffset.Now.Second);
            int rand;
            List<int> bomb_lst = new List<int>();
            for (int i = 0; i < _number; i++)
            {
                rand = random.Next() % (cells.Count - i);
                if (!bomb_lst.Contains(rand))
                {
                    bomb_lst.Add(rand);
                    cells[rand].setBomb();
                    modifyCountOfMineArround(rand);
                }
                
            }
            //cells[56].setBomb();
        }
        private void modifyCountOfMineArround(int _number)
        {

            if (_number > 0 & _number % 8 != 0)
                if (!cells[_number - 1].isMine)
                    cells[_number - 1].growCountOfMineArround();
            if (_number < 63 & _number % 8 != 7)
                if (!cells[_number + 1].isMine)
                    cells[_number + 1].growCountOfMineArround();
            if (_number > 7)
                if (!cells[_number - 8].isMine)
                    cells[_number - 8].growCountOfMineArround();
            if (_number < 55)
                if (!cells[_number + 8].isMine)
                    cells[_number + 8].growCountOfMineArround();
            if (_number > 8 & _number % 8 != 0)
                if (!cells[_number - 9].isMine)
                    cells[_number - 9].growCountOfMineArround();
            if (_number < 55 & _number % 8 != 7)
                if (!cells[_number + 9].isMine)
                    cells[_number + 9].growCountOfMineArround();
            if (_number > 7 & _number % 8 != 7)
                if (!cells[_number - 7].isMine)
                    cells[_number - 7].growCountOfMineArround();
            if (_number < 56 & _number % 8 != 0)
                if (!cells[_number + 7].isMine)
                    cells[_number + 7].growCountOfMineArround();

        }

    }
}
