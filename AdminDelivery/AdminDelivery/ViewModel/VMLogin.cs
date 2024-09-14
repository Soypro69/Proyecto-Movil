using Acr.UserDialogs;
using AdminDelivery.Conexion;
using AdminDelivery.Vistas;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Essentials;


namespace AdminDelivery.ViewModel
{
    public class VMLogin : BaseViewModel
    {
        #region VARIABLES
        string correo;
        string pass;
        #endregion
        #region OBJETOS
        public string txtCorreo
        {
            get { return correo; }
            set { SetValue(ref correo, value); }
        }

        public string txtPass
        {
            get { return pass; }
            set { SetValue(ref pass, value); }
        }
        #endregion
        #region PROCESO
        private async Task<bool> IniciarSesionAdmin()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Validando Datos...");
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConexionFirebase.TokenAuthentication));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(txtCorreo, txtPass);
                var controltoken = JsonConvert.SerializeObject(auth);
                Preferences.Set("MyFirebaseRefreshToken", controltoken);
                return true;
            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("Error de Inicio", "Usuario o Contraseña Incorrecta", "OK");
                return false;
            }
        }
        private async Task ValidarLogin()
        {
            bool estado = await IniciarSesionAdmin();
            if (estado)
            {
                Application.Current.MainPage = new NavigationPage(new Vinicio());
                UserDialogs.Instance.HideLoading();
            } 
        }
        public async Task resPass(string correo)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Conexion.ConexionFirebase.TokenAuthentication));
            await authProvider.SendPasswordResetEmailAsync(correo);
            try
            {
                await DisplayAlert("Enviado", "Se envio un mensaje a tu correo ", "Ok");
            }
            catch
            {
                await DisplayAlert("Error", "Error al enviar correo", "Ok");
            }
        }

        #endregion
        #region COMANDOS
        public Command IniciarSesion { get; set; }
        public Command ComandoCambiarPass { get; }

        #endregion
        #region CONSTRUCTOR
        public VMLogin(INavigation navigation)
        {
            Navigation = navigation;
            IniciarSesion = new Command(async () => await ValidarLogin());
            ComandoCambiarPass = new Command(async () => await resPass(correo));

        }
        #endregion
    }
}