using System;
using prueba2pm.Entities;

namespace prueba2pm.Repository
{
    public abstract class RepositorioAbstrato<T>
    where T : IEntity
    {
        public abstract List<Proveedor> getProveedor();
        public abstract void addProveedor(Proveedor proveedor);
        public abstract Proveedor getProveedorByCodigo(String codigo); 
    }
}

