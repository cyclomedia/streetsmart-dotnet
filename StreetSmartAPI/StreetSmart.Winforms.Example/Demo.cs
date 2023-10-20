using Demo.WinForms;
using StreetSmart.Common.Factories;
using StreetSmart.Common.Interfaces.API;
using StreetSmart.Common.Exceptions;
using StreetSmart.Common.Interfaces.Data;
using StreetSmart.Common.Interfaces.DomElement;

namespace StreetSmart.Winforms.Example
{
  public partial class Demo : Form
  {
    private readonly IStreetSmartAPI _api;
    private readonly Login _login;
    private IOptions _options;

    public Demo()
    {
      InitializeComponent();

      _login = Login.Instance;

      IAPISettings apiSettings = CefSettingsFactory.Create(@"D:\StreetSmartAPI\Cache");
      apiSettings.DisableGPUCache = true;
      apiSettings.AllowInsecureContent = true;

      _api = StreetSmartAPIFactory.Create(apiSettings);
      _api.APIReady += OnAPIReady;

      plStreetSmart.Controls.Add(_api.GUI);

      txtUsername.Text = _login.Username;
      txtPassword.Text = _login.Password;
      txtAPIKey.Text = _login.ApiKey;
      txtClientId.Text = _login.ClientId;
    }

    private void OnAPIReady(object sender, EventArgs args)
    {
      if (grLogin.InvokeRequired)
      {
        grLogin.Invoke(new MethodInvoker(() => grLogin.Enabled = true));
      }
      else
      {
        grLogin.Enabled = true;
      }
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
      IAddressSettings addressSettings = AddressSettingsFactory.Create("nl", "CMdatabase");
      IDomElement element = DomElementFactory.Create();

      _options = OptionsFactory.CreateOauth(
        txtClientId.Text,
        txtAPIKey.Text,
        txtSrs.Text,
        "en-US",
        addressSettings, // address settings
        element // target element
      );

      //_options = OptionsFactory.Create(txtUsername.Text, txtPassword.Text, txtClientId.Text, txtAPIKey.Text, txtSrs.Text, locale,
      //  ConfigurationUrl, addressSettings, element, true);

      try
      {
        await _api.Init(_options);

        MessageBox.Show("Login successfully");
      }
      catch (StreetSmartLoginFailedException ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}
