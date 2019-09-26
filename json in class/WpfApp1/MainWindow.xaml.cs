using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTNgetquote_Click(object sender, RoutedEventArgs e)
        {
            //this is the source we are calling from
                //https://got-quotes.herokuapp.com/quotes

            using (HttpClient client = new HttpClient())
            {
                //tells the computer where to go
                HttpResponseMessage response = client.GetAsync(@"https://got-quotes.herokuapp.com/quotes").Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    //content is displayed because of the above line

                    var quote = JsonConvert.DeserializeObject<GOTQuote>(content);

                    TXTquote.Text = $"{quote.quote} \n\n -{quote.character}";
                    //var x = JsonConvert.SerializeObject();
                }
            }

        }
    }
}
