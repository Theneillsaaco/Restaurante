using Microsoft.AspNetCore.Mvc;
using Restaurante.API.Models.ClienteModels;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.API.Extentions;
using Restaurante.Domain.Models;

namespace Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responseApi = new ResponseAPI<List<ClienteModel>>();
            
            try
            {
                var clientes = _clienteRepository.GetClientes();

                responseApi.Success = true;
                responseApi.Data = await clientes;
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var responseApi = new ResponseAPI<Cliente>();

            try
            {
                var cliente = _clienteRepository.Get(id);
                
                responseApi.Success = true;
                responseApi.Data = await cliente;
            }
            catch (Exception ex)
            {
                responseApi.Success = true;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] ClienteUpdateModel clienteUpdateModel)
        {
            var responseApi = new ResponseAPI<ClienteUpdateModel>();

            try
            {
                var cliente = clienteUpdateModel.ConvertToEntityCliente();
                
                await _clienteRepository.Save(cliente);

                responseApi.Success = true;
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteViewModel clienteViewModel)
        {
            var responseApi = new ResponseAPI<ClienteViewModel>();

            try
            {
                var exists = await _clienteRepository.Exists(cd => cd.IdCliente == id);
                
                if (!exists)
                {
                    responseApi.Success = false;
                    responseApi.Message = $"Cliente with Id {id} not found.";
                    return Ok(responseApi);
                }
                
                var cliente = clienteViewModel.ConvertToEntityCliente();
                
                await _clienteRepository.Update(cliente);
                
                responseApi.Success = true;
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
