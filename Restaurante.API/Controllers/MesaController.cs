using Microsoft.AspNetCore.Mvc;
using Restaurante.API.Extentions;
using Restaurante.API.Models.ClienteModels;
using Restaurante.API.Models.MesaModels;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;

namespace Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaRepository _mesaRepository;

        public MesaController(IMesaRepository mesaRepository)
        {
            _mesaRepository = mesaRepository;
        }
        
        // GET: api/<MesaController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responseApi = new ResponseAPI<List<MesaModel>>();

            try
            {
                var mesa = _mesaRepository.GetMesa();
                
                responseApi.Success = true;
                responseApi.Data = await mesa;
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // GET api/<MesaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var responseApi = new ResponseAPI<Mesa>();

            try
            {
                var mesa = _mesaRepository.GetById(id);
                
                responseApi.Success = true;
                responseApi.Data = await mesa;
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }
            
            return Ok(responseApi);
        }

        // POST api/<MesaController>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] MesaViewModel mesaViewModel)
        {
            var responseApi = new ResponseAPI<MesaViewModel>();

            try
            {
                var mesa = mesaViewModel.ConvertToEntityMesa();

                await _mesaRepository.Save(mesa);

                responseApi.Success = true;
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // PUT api/<MesaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MesaViewModel mesaUpdateModel)
        {
            var responseApi = new ResponseAPI<MesaViewModel>();

            try
            {
                if (!await _mesaRepository.Exists(cd => cd.IdMesa == id))
                {
                    responseApi.Success = false;
                    responseApi.Message = $"Mesa with Id {id} not found.";

                    return Ok(responseApi);
                }

                var mesa = mesaUpdateModel.ConvertToEntityMesa();

                await _mesaRepository.Update(mesa);

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
