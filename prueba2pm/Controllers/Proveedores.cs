using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using prueba2pm.Entities;
using prueba2pm.Repository;

namespace prueba2pm.Controllers
{
    [Route("api/[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly RepositorioAbstrato<Proveedor> _proveedorRepository;
        public ProveedorController(RepositorioAbstrato<Proveedor> proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        [HttpGet]
        public List<Proveedor> ListaDeAlunos()
        {
            List<Proveedor> proveedor = _proveedorRepository.getProveedor();
            return proveedor;
        }

        [HttpPost]
        public IActionResult addProveedor(Proveedor proveedor)
        {
            _proveedorRepository.addProveedor(proveedor);
            return Ok("Listo");
        }

        [HttpGet]
        [Route("getProveedoresByCodigo")]
        public Proveedor getProveedorByCodigo(String codigo)
        {
            Proveedor proveedor = _proveedorRepository.getProveedorByCodigo(codigo);
            return proveedor;
        }
    }
}