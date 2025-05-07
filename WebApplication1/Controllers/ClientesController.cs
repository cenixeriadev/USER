using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class ClientesController : Controller
    {
       
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult IndexC()
        {
            var clientes = _clienteService.ObtenerClientes();
            return View(clientes);
        }

        public IActionResult Delete(int id)
        {
            _clienteService.EliminarCliente(id);
            return RedirectToAction(nameof(IndexC));
        }
    }
}
