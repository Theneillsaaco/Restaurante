using Microsoft.AspNetCore.Mvc;
using Restaurante.API.Extentions;
using Restaurante.API.Models.EmpleadoModels;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;

namespace Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        #region Context
        
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }
        
        #endregion
        
        // GET: api/<EmpleadoController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responseApi = new ResponseAPI<List<EmpleadoModel>>();

            try
            {
                var empleado = _empleadoRepository.GetEmpleado();

                responseApi.Success = true;
                responseApi.Data = await empleado;
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }
            
            return Ok(responseApi);
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var responseApi = new ResponseAPI<Empleado>();

            try
            {
                var empleado = _empleadoRepository.GetById(id);

                responseApi.Success = true;
                responseApi.Data = await empleado;
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] EmpleadoViewModel empleadoViewModel)
        {
            var responseApi = new ResponseAPI<EmpleadoViewModel>();

            try
            {
                var empleado = empleadoViewModel.ConvertToEntityEmpleado();

                await _empleadoRepository.Save(empleado);

                responseApi.Success = true;
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmpleadoViewModel empleadoViewModel)
        {
            var responseApi = new ResponseAPI<EmpleadoViewModel>();

            try
            {
                if (!await _empleadoRepository.Exists(cd => cd.IdEmpleado == id))
                {
                    responseApi.Success = false;
                    responseApi.Message = $"Empleado with Id {id} not found.";

                    return Ok(responseApi);
                }

                var empleado = empleadoViewModel.ConvertToEntityEmpleado();

                await _empleadoRepository.Update(empleado);

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
