
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
using ejmeplo1.Interfaces;
using ejmeplo1.Repositorios;

namespace ejmeplo1.Droid
{
    [Activity(Label = "Añadir Contacto")]
    public class AddContacto : Activity
    {
        IContacto iContacto = new SQLiteContactoRepository(MainActivity.path);
        //private Button btnAñadirContacto;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Referencias de las vistas
            SetContentView(Resource.Layout.AddContacto);
            Button btnAñadirContacto = FindViewById<Button>(Resource.Id.btnAddContacto);
            EditText edtApellidoP = FindViewById<EditText>(Resource.Id.etApellidoP);
            EditText edtApellidoM = FindViewById<EditText>(Resource.Id.etApellidoM);
            EditText edtNombre = FindViewById<EditText>(Resource.Id.etNombre);
            EditText edtCorreo = FindViewById<EditText>(Resource.Id.etCorreo);
            EditText edtTelefono = FindViewById<EditText>(Resource.Id.etTelefono);
            TextView tvEstatusCliente = FindViewById<TextView>(Resource.Id.tvEstatus);
            tvEstatusCliente.Visibility = ViewStates.Gone;
            Spinner spnEstatusCliente = FindViewById<Spinner>(Resource.Id.spnTipoCliente);
            spnEstatusCliente.Visibility = ViewStates.Gone;

            //Evento onClick del boton de agregar cliente
            btnAñadirContacto.Click += delegate
            {
                Contacto contacto = new Contacto();
                contacto.ApellidoPaterno = edtApellidoP.Text;
                contacto.ApellidoMaterno = edtApellidoM.Text;
                contacto.Nombre = edtNombre.Text;
                contacto.Correo = edtCorreo.Text;
                contacto.Telefono = edtTelefono.Text;
                contacto.TipoCliente = Enumeradores.TipoCliente.ClientePotencial;
                //Guardar el contacto en base de datos
                iContacto.CrearContacto(contacto);
                Finish();
            };
        }

    }
}
