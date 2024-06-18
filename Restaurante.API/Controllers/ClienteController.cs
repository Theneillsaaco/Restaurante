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
        #region Context
        private readonly IClienteRepository _clienteRepository;
        
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        #endregion
        
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
        public async Task<IActionResult> GetById(int id)
        {
            var responseApi = new ResponseAPI<Cliente>();

            try
            {
                var cliente = _clienteRepository.GetById(id);
                
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
        public async Task<IActionResult> Save([FromBody] ClienteViewModel clienteUpdateModel)
        {
            var responseApi = new ResponseAPI<ClienteViewModel>();

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
                if (!await _clienteRepository.Exists(cd => cd.IdCliente == id))
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
    }
}
