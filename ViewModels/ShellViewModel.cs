using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using ExchangeInstantAPI.Models;

namespace ExchangeInstantAPI.ViewModels;

public class ShellViewModel : Conductor<object>
{
    #region Constructor
    public ShellViewModel()
    {
        _apiData = new ApiData();
    }
    #endregion

    #region Fields

    private readonly ApiData _apiData;
    private float _euro;
    private float _usd;

    #endregion

    #region Notify

    public float Usd
    {
        get => _usd;
        set
        {
            _usd = value;
            NotifyOfPropertyChange(() => Usd);
        }
    }

    public float Euro
    {
        get => _euro;
        set
        {
            _euro = value;
            NotifyOfPropertyChange(() => Euro);
        }
    }

    #endregion

    #region OnViewLoaded

    public async Task GetValues()
    {
        while (true)
        {
            await Task.Delay(1000);
            var exchangeData = await _apiData.GetExchange();

            // Gelen Datayı Ayıklama
            foreach (var item in exchangeData)
                if (item.name == "USD")
                {
                    Usd = float.Parse(item.value) / 100f;
                }
                else if (item.name == "EURO")
                {
                    Euro = float.Parse(item.value) / 100f;
                }
        }
    }

    protected override void OnViewLoaded(object view)
    {
        base.OnViewLoaded(view);
        // Api.exe çalıştırılır.
        Process.Start("api.exe");

        // Saniyede 1 çalışan fonk. çağrılır.
        GetValues();
    }

    #endregion

    #region OnDeactiveSync
    // Program kapandığında api.exe yide kapatır.
    protected override async Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
    {
        if (close)
        {
            Process[] processes = Process.GetProcessesByName("api");
            foreach (Process process in processes)
            {
                process.Kill();
            }
        }

        await base.OnDeactivateAsync(close, cancellationToken);
    }
    #endregion


}