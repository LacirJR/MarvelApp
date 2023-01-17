using MarvelApp.Gateway.Interfaces;

namespace MarvelApp;

public partial class App : Application
{
    private readonly IHttpService _http;

    public App(IHttpService http)
	{
		InitializeComponent();
		_http= http;
		MainPage = new MainPage(_http);
	}
}
