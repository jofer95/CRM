using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ejmeplo1.Droid.Adaptadores;
using ejmeplo1.Interfaces;
using ejmeplo1.Repositorios;

namespace ejmeplo1.Droid
{
    [Activity(Label = "Lista de clientes")]
    public class ListaDeClientesActivity : Activity
    {
        ListView lvClientes;
        IContacto iContacto = new SQLiteContactoRepository(MainActivity.path);
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.listaDeClientes);

            lvClientes = FindViewById<ListView>(Resource.Id.lvClientes);
        }

        protected override void OnResume()
        {
            base.OnResume();
            if(lvClientes != null)
            {
                var clientes = iContacto.ObtenerContactos();
                var adapter = new ContactoAdapter(this, clientes);
                lvClientes.Adapter = adapter;
            }
        }
    }
}