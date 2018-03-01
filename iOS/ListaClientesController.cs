using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using ejmeplo1.Entidades;
using ejmeplo1.Repositorios;

namespace ejmeplo1.iOS
{
    public partial class ListaClientesController : UIViewController
    {
        SQLiteContactoRepository repositorio = new SQLiteContactoRepository(ViewController.path);
        public ListaClientesController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var clientes = new List<Contacto>();
            Contacto contacto = new Contacto();
            contacto.Nombre = "Pruebas!";
            contacto.Correo = "jofer_bz20@hotmail.com";
            contacto.Telefono = "6671896358";
            contacto.TipoCliente = Enumeradores.TipoCliente.ClientePotencial;

            List<Contacto> contactos = repositorio.ObtenerContactos(Enumeradores.TipoCliente.ClientePotencial);
            foreach(Contacto obj in contactos){
                clientes.Add(obj);
            }
            clientes.Add(contacto);

            ClientesTableView.Source = new ClientesTVS(clientes);

            ClientesTableView.RowHeight = UITableView.AutomaticDimension;
            ClientesTableView.EstimatedRowHeight = 40f;
            ClientesTableView.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}