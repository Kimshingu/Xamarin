using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace WebServiceTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            string url = "http://192.168.0.213:8080/hello";
            if (CrossConnectivity.Current.IsConnected)
            {
                var client = new System.Net.Http.HttpClient();
                if (!string.IsNullOrEmpty(txtName.Text)) url +=
               "?name=" + txtName.Text;
                var response = await client.GetAsync(url);

                string helloString = await
               response.Content.ReadAsStringAsync();
                if (helloString != "")
                {
                    label1.Text = helloString;
                }
                else
                {
                    await DisplayAlert("경고", "데이터가 없습니다.", "OK");
                }
            }
            else
            {
                await DisplayAlert("경고", "네크워크 에러! 인터넷 연결 확인 바랍니다.", "OK");
            }
        }
    }
}