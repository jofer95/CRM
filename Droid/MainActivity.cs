using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;
using ejmeplo1.Repositorios;

namespace ejmeplo1.Droid
{
    [Activity(Label = "Menu principal", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        public static String path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "crm.db3");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //Creando las tablas e inicializando
            SQLiteContactoRepository repositorio = new SQLiteContactoRepository(path);
            repositorio.Inicializar();

            //Referencias
            Button btnAddContacto = FindViewById<Button>(Resource.Id.btnAddContacto);
            Button btnClientesPotenciales = FindViewById<Button>(Resource.Id.btnClientesPotenciales);

            btnAddContacto.Click += delegate {
                var activityAddContacto = new Intent(this, typeof(AddContacto));
                activityAddContacto.PutExtra("MyData", "Data from Activity1");
                StartActivity(activityAddContacto);                
            };

            btnClientesPotenciales.Click += delegate {
                var activityListaClientes = new Intent(this, typeof(ListaDeClientesActivity));
                activityListaClientes.PutExtra("MyData", "Data from Activity1");
                StartActivity(activityListaClientes);
            };
        }
    }
}

