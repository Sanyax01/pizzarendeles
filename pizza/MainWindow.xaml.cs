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

namespace pizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> pizzak = new List<string> { "Margherita", "Sonkás", "Hawaii", "Gombás", "Négy Sajtos", "Magyaros" };
        List<string> rendelt = new List<string> ();
        public MainWindow()
        {
            InitializeComponent();
            lbox_pizza.ItemsSource = pizzak;
        }

        private void ujPizzaHozzadas(object sender, RoutedEventArgs e)
        {
            if (tbox_hozzadas.Text != "")
            {
                string ujPizza = tbox_hozzadas.Text;
                pizzak.Add(ujPizza);
                tbox_hozzadas.Text = "";
                lbox_pizza.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Hiba: A pizza neve nem lehet üres!","Figyelmeztetés");
            }
           
        }

        private void pizzaTorles(object sender, RoutedEventArgs e)
        {
            string pizzaTorlesre = ""+lbox_pizza.SelectedItem;
            if (pizzaTorlesre != null)
            {
                if (MessageBox.Show($"Biztosan kivánja törölni a {pizzaTorlesre}", "Figyelmeztetés", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    pizzak.Remove(pizzaTorlesre);
                    lbox_pizza.ItemsSource = pizzak;
                    lbox_pizza.Items.Refresh();
                }
            }


        }
        private void kivalsztas(object sender, SelectionChangedEventArgs e)
        {
            string kivalasztottPizza = "" + lbox_pizza.SelectedItem;
            if (kivalasztottPizza != null)
            {
                tbox_kivalasztott.Text = "" + kivalasztottPizza;
            }
            else
            {
                tbox_kivalasztott.Text = "Nincs kiválasztott elem!";
            }
        }

        private void ujRendeles(object sender, RoutedEventArgs e)
        {
            if (tbox_kivalasztott.Text != "")
            {
                if (tbox_meret.Text == "kicsi")
                {  
                    rendelt.Add(tbox_kivalasztott.Text + " - " + tbox_meret.Text);
                    lbox_rendelesek.ItemsSource = rendelt;
                    lbox_pizza.Items.Refresh();
                }
                if (tbox_meret.Text == "közepes")
                { 
                    rendelt.Add(tbox_kivalasztott.Text + " - " + tbox_meret.Text);
                    lbox_rendelesek.ItemsSource = rendelt;
                    lbox_pizza.Items.Refresh();
                }
                if (tbox_meret.Text == "nagy")
                { 
                    rendelt.Add(tbox_kivalasztott.Text + " - " + tbox_meret.Text);
                    lbox_rendelesek.ItemsSource = rendelt;
                    lbox_pizza.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Hiba: A pizza neve nem lehet üres!", "Figyelmeztetés");
                }
            }

        }

        
    }
}