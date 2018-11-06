using Newtonsoft.Json;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace Emp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Button1_Click(object sender, System.EventArgs e)
        {
            activityIndicator.IsVisible = true;
            string url = "http://192.168.0.213:8080/emp/all";
            // 네트워크 연결 상태 확인
            if (CrossConnectivity.Current.IsConnected)
            {
                var client = new HttpClient();
                var res = await client.GetAsync(url);
                string ResponseStr = await
               res.Content.ReadAsStringAsync();
                //EmpList empList = new EmpList();
                if (ResponseStr != "")
                {
                    // 웹서비스에서 리턴하는 JSON 형식을 EmpList 형식으로 변환
                listView.ItemsSource = JsonConvert.DeserializeObject<List<Model.Emp>>(ResponseStr);
                }
                // 리스트뷰의 아이템소스로 emps 컬렉션을 할당 화면에 출력됨
               // listView.ItemsSource = empList.Emps;
            }
            else
            {
                await DisplayAlert("에러!", "네트워크 연결상태를 확인하세요.", "Ok");
            }
            //응답이 다 넘어온 경우 비활성화 시킴
            activityIndicator.IsVisible = false;
        }

        //선택한 사원을 다음 화면에 출력
        private async void listView_ItemSelected(object sender,SelectedItemChangedEventArgs e)
        {
            activityIndicator.IsVisible = true;
            var Emp = e.SelectedItem as Model.Emp;
            var nextPage = new View.EmpViewPage();

            //웹서비스 호출 URL 생성
            string url = "http://192.168.0.213:8080/emp/" + Emp.Empno;
            // 네트워크 연결 상태 확인
            if (CrossConnectivity.Current.IsConnected)
            {
                var client = new HttpClient();
                var res = await client.GetAsync(url);
                string ResponseStr = await
               res.Content.ReadAsStringAsync();
                if (ResponseStr != "")
                {
                    // 웹서비스에서 리턴하는 JSON 형식을 EmpList 형식으로 변환
                nextPage.BindingContext = JsonConvert.DeserializeObject<Model.Emp>(ResponseStr);
                }
            }
            else
            {
                await DisplayAlert("에러!", "네트워크 연결상태를 확인하세요.", "Ok");
            }
            //응답이 다 넘어온 경우 비활성화 시킴
            activityIndicator.IsVisible = false;
            await Navigation.PushAsync(nextPage);
        }
    }
}