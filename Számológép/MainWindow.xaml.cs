using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Számológép
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Operator = "";
        double backcalc = 0;
        double tempcalc = 0;
        bool opnextno = true;
        bool numnextclc = false;

        public MainWindow()
        {
            InitializeComponent();
            GombokElhelyezése();
        }

        private void GombokElhelyezése()
        {
            for (int i = 0; i < 4; i++)
            {
                ButtonGrid.RowDefinitions.Add(new RowDefinition());
                ButtonGrid.ColumnDefinitions.Add(new ColumnDefinition());
                
            }
            string[,] feliratok =
                {
                {"7","8","9","/"},
                {"4","5","6","*"},
                {"1","2","3","-"},
                {"C","0","=","+"}

            };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    string label = feliratok[i, j];
                    Button btn = new Button
                    {
                        Content = label,
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(3)
                    };
                    if (char.IsDigit(label[0]))
                    {
                        btn.Background = System.Windows.Media.Brushes.WhiteSmoke;
                    }
                    else if (label == "C")
                    {
                        btn.Background = System.Windows.Media.Brushes.IndianRed;
                        btn.Foreground = System.Windows.Media.Brushes.White;
                    }
                    else
                    {
                        btn.Background = System.Windows.Media.Brushes.DodgerBlue;
                        btn.Foreground = System.Windows.Media.Brushes.White;
                    }

                    btn.Click += Button_Click;

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);


                    ButtonGrid.Children.Add(btn);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content == "C" && !opnextno)
            {
                tb_kijelzo.Text = "0";
                backcalc = 0;
                tempcalc = 0;
                Operator = "";
                numnextclc = false;
                opnextno = true;
            }

            else if (button.Content == "+" && !opnextno)
            {
                tb_kijelzo.Text = "";
                opnextno = true;
                Operator = "+";
                numnextclc = true;
            }

            else if (button.Content == "-" && !opnextno)
            {
                tb_kijelzo.Text = "";
                opnextno = true;
                Operator = "-";
                numnextclc = true;
            }
            else if (button.Content == "*" && !opnextno)
            {
                tb_kijelzo.Text = "";
                opnextno = true;
                Operator = "*";
                numnextclc = true;
            }
            else if (button.Content == "/" && !opnextno)
            {
                tb_kijelzo.Text = "";
                opnextno = true;
                Operator = "/";
                numnextclc = true;
            }
            else if (button.Content == "=" && !opnextno)
            {
                switch (Operator)
                {
                    case "+":
                        tb_kijelzo.Text = (backcalc + tempcalc).ToString();
                        tempcalc = 0;
                        numnextclc = false;
                        backcalc = Convert.ToDouble(tb_kijelzo.Text);
                        break;

                    case "-":
                        tb_kijelzo.Text = (backcalc - tempcalc).ToString();
                        tempcalc = 0;
                        numnextclc = false;
                        backcalc = Convert.ToDouble(tb_kijelzo.Text);
                        break;

                    case "*":
                        tb_kijelzo.Text = (backcalc * tempcalc).ToString();
                        tempcalc = 0;
                        numnextclc = false;
                        backcalc = Convert.ToDouble(tb_kijelzo.Text);
                        break;

                    case "/":
                        tb_kijelzo.Text = (backcalc / tempcalc).ToString();
                        tempcalc = 0;
                        numnextclc = false;
                        backcalc = Convert.ToDouble(tb_kijelzo.Text);
                        break;
                }
            }
            else
            {
                if (tb_kijelzo.Text == "0") tb_kijelzo.Text = "";

                if (numnextclc)
                {
                    tb_kijelzo.Text += button.Content;
                    tempcalc = Convert.ToDouble(tb_kijelzo.Text);
                }
                else
                {
                    tb_kijelzo.Text += button.Content;
                    backcalc = Convert.ToDouble(tb_kijelzo.Text);
                }
                opnextno = false;
            }

        }
    }
}