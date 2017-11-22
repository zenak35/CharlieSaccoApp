using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Text;

namespace CharlieSaccoApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage ( )
        {
            InitializeComponent();
        }


        private void button1_Click ( object sender, RoutedEventArgs e )
        {
            string url = "http://localhost/sacco/add.php";
            Uri uri = new Uri(url, UriKind.Absolute); 
             StringBuilder postData = new StringBuilder();
            postData.AppendFormat("{0}={1}", "id", HttpUtility.UrlEncode(this.id.Text));
            postData.AppendFormat("&{0}={1}", "names", HttpUtility.UrlEncode(this.name.Text));
            postData.AppendFormat("&{0}={1}", "amount", HttpUtility.UrlEncode(this.amount.Text));

            WebClient client = default(WebClient);
            client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            client.Headers[HttpRequestHeader.ContentLength] = postData.Length.ToString();
            client.UploadStringAsync(uri, "POST", postData.ToString());
            client.UploadStringCompleted += ( s, ee ) =>
            {
                if (ee.Cancelled == false & ee.Error == null)
                {
                    string result = ee.Result.ToString();

                    if (result == "0")
                    {
                        MessageBox.Show("Error!!");
                    }
                    else
                    {

                        // MessageBox.Show(strError);
                        MessageBox.Show("Update Data Successfully");
                    }

                }
            };
        }





        private void button2_Click ( object sender, RoutedEventArgs e )
        {
            NavigationService.Navigate(new Uri("/search.xaml", UriKind.Relative));
        }




    }
}