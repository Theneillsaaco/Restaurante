using Microsoft.AspNetCore.Mvc;
using Restaurante.API.Extentions;
using Restaurante.API.Models.MenuModels;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;

namespace Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        #region Context

        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        #endregion
        
        // GET: api/<MenuController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responseApi = new ResponseAPI<List<MenuModel>>();
            
            try
            {
                var menu = _menuRepository.GetMenus();

                responseApi.Success = true;
                responseApi.Data = await menu;
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var responseApi = new ResponseAPI<Menu>();

            try
            {
                var menu = _menuRepository.GetById(id);
                
                responseApi.Success = true;
                responseApi.Data = await menu;
            }
            catch (Exception ex)
            {
                responseApi.Success = true;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // POST api/<MenuController>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] MenuViewModel menuViewModel)
        {
            var responseApi = new ResponseAPI<MenuViewModel>();

            try
            {
                var menu = menuViewModel.ConvertToEntityMenu();
                
                await _menuRepository.Save(menu);

                responseApi.Success = true;
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MenuViewModel menuViewModel)
        {
            var responseApi = new ResponseAPI<MenuViewModel>();

            try
            {
                if (!await _menuRepository.Exists(cd => cd.IdPlato == id))
                {
                    responseApi.Success = false;
                    responseApi.Message = $"Cliente with Id {id} not found.";
                    
                    return Ok(responseApi);
                }

                var menu = menuViewModel.ConvertToEntityMenu();
                
                await _menuRepository.Update(menu);
                
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
