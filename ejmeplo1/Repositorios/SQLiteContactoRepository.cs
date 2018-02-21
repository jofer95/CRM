using System;
using System.Collections.Generic;
using ejmeplo1.Interfaces;
using SQLite;

namespace ejmeplo1.Repositorios
{
    public class SQLiteContactoRepository : IContacto
    {
        SQLiteConnection db;
        public SQLiteContactoRepository(String path)
        {
            db = new SQLiteConnection(path);
        }

        public void ActualizarContacto(Contacto contacto)
        {
            throw new NotImplementedException();
        }

        public void BorrarContactoPorID(int contactoID)
        {
            throw new NotImplementedException();
        }

        public void CrearContacto(Contacto contacto)
        {
            throw new NotImplementedException();
        }

        public void Inicializar()
        {
            db.CreateTable<Contacto>();
        }

        public Contacto ObtenerContactoPorID(int contactoID)
        {
            throw new NotImplementedException();
        }

        public List<Contacto> ObtenerContactos()
        {
            throw new NotImplementedException();
        }
    }
}
