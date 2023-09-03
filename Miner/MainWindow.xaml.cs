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

        private List<Cell> cells = new List<Cell>(64);
        TextBox Score = new TextBox();
        Grid myGrid = new Grid();
        Button buttonExit = new Button();
        Button label  = new Button();
        int score = Cell.ButtonClick;



        public MainWindow()
        {
            InitializeComponent();
            InitBoard();
            SetMineLocation(4);
            addMenu();

        }
       
    
        private void InitBoard()
        {
            
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
                Grid.SetRow(cell.button, cell.Y+1);

            }
         }

        private void addMenu()
        {
            Score = new TextBox();
            Score.Width = 70;
            Score.Text = String.Empty;

            Score.FontSize = 25;
           
            myGrid.Children.Add(Score);
            Grid.SetColumn(Score, 1);
            Grid.SetRow(Score, 0);

            buttonExit = new Button();
            buttonExit.Content = "EXIT";
            myGrid.Children.Add(buttonExit);
            Grid.SetColumn(buttonExit, 1);
            Grid.SetColumn(buttonExit, 2);
            buttonExit.Click += ButtonExit_Click;
            label = new Button();
            label.Content = "Score";
            myGrid.Children.Add(label);
            Grid.SetColumn(label, 0);
            Grid.SetRow(label,0);

        }

       

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      

        private void Button_Click02(object sender, RoutedEventArgs e)
        {
            foreach (var item in cells)
            {
                item.button.Content = item.reverse;
                item.MyButton_Click(sender, e);
                Score.Text = score.ToString();

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
