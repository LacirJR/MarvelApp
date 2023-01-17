using MarvelApp.Gateway.Interfaces;

namespace MarvelApp;

public partial class MainPage : ContentPage
{
    private readonly IHttpService _http;

    public MainPage(IHttpService http)
    {

        InitializeComponent();
        _http = http;


    }

    async void OnButtonClicked(object sender, EventArgs args)
    {
        var teste = await _http.GetCharacters();
        Console.WriteLine(teste.attributionText);
    }

}

