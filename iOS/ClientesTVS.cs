using System;
using System.Collections.Generic;
using ejmeplo1.Entidades;
using Foundation;
using UIKit;

namespace ejmeplo1.iOS
{
    internal class ClientesTVS : UITableViewSource
    {
        private List<Contacto> clientes;

        public ClientesTVS(List<Contacto> clientes)
        {
            this.clientes = clientes;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (ClienteCell)tableView.DequeueReusableCell("cliente_id", indexPath);
            var cliente = clientes[indexPath.Row];
            cell.UpdateCell(cliente);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return clientes.Count;
        }
    }
}