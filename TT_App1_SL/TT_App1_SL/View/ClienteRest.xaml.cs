using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TT_App1_SL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClienteRest : ContentPage
	{
        //private const string Url = "http://10.100.72.173:5010/api/v1/admin/page/0";
        private const string Url = "http://jsonplaceholder.typicode.com/posts";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Model_Post> _post;

		public ClienteRest ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            var credenciales  = ("angularjwtclientid"+":"+"12345");
            //var httpHeaders = new
            string content = await client.GetStringAsync(Url);
            List<Model_Post> posts = JsonConvert.DeserializeObject<List<Model_Post>>(content);
            _post = new ObservableCollection<Model_Post>(posts);
            ListMenu.ItemsSource = _post;
            base.OnAppearing();     
        }
	}
}