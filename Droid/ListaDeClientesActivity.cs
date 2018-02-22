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
using ejmeplo1.Enumeradores;
using ejmeplo1.Interfaces;
using ejmeplo1.Repositorios;

namespace ejmeplo1.Droid
{
    [Activity(Label = "Lista de clientes")]
    public class ListaDeClientesActivity : Activity
    {
        //Iniciarlizar la lista, interfaz, variables y adaptador.
        ListView lvClientes;
        IContacto iContacto = new SQLiteContactoRepository(MainActivity.path);
        string tipoClientes;
        ContactoAdapter adapter;

        //OnCreate de la actividad
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.listaDeClientes);
            //Recibir que tipo de cliente a buscar de los botones del main.
            tipoClientes = Intent.GetStringExtra("MyData") ?? "";

            lvClientes = FindViewById<ListView>(Resource.Id.lvClientes);
            lvClientes.ItemClick += onItemClick;
        }

        //OnResume que se ejecuta despues del OnCreate
        protected override void OnResume()
        {
            base.OnResume();
            TipoCliente tipo;
            if(lvClientes != null)
            {
                //Switch para seleccionar que tipo de cliente es por el numero
                switch (tipoClientes)
                {
                    case "0": tipo = TipoCliente.ClienteDescartado;
                        break;
                    case "1":
                        tipo = TipoCliente.ClientePotencial;
                        break;
                    case "2":
                        tipo = TipoCliente.ClienteProspecto;
                        break;
                    case "3":
                        tipo = TipoCliente.Cliente;
                        break;
                    default:
                        tipo = TipoCliente.Cliente;
                        break;
                }
                //Obtener los clientes de base de datos buscando por su tipo
                var clientes = iContacto.ObtenerContactos(tipo);
                //Añadir un adaptador con los clientes encontrados
                adapter = new ContactoAdapter(this, clientes);
                //Asignar a la lista
                lvClientes.Adapter = adapter;
            }

        }

        //Evento onClick de un objecto de la lista a seleccionar
        private void onItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var detallesIntent = new Intent(this, typeof(MainActivity));
            detallesIntent.PutExtra("id", adapter[e.Position].ID);
            StartActivity(detallesIntent);
        }
    }
}