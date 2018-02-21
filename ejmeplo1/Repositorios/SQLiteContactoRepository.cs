using System;
using System.Collections.Generic;
using System.Linq;
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
            db.Insert(contacto);
        }

        public void Inicializar()
        {
            //Crear tablas
            db.CreateTable<Contacto>();
        }

        public Contacto ObtenerContactoPorID(int contactoID)
        {
            return db.Find<Contacto>(x => x.ID == contactoID);
        }

        public List<Contacto> ObtenerContactos()
        {
            return db.Table<Contacto>().ToList();
        }
    }
}
