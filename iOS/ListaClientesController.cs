using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using ejmeplo1.Entidades;

namespace ejmeplo1.iOS
{
    public partial class ListaClientesController : UIViewController
    {
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