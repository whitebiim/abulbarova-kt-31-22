
//Какие методы можно вызывать (через интерфейс)
//Какие параметры передавать



using abulbarovakt_31_22.Interfaces.DepartmentInterfaces;
using abulbarovakt_31_22.Interfaces.TeachersInterfaces;
using abulbarovakt_31_22.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections;


namespace abulbarovakt_31_22.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : Controller
    {

        private readonly ITeacherService _teacherService;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(ITeacherService teacherService, IDepartmentService departmentService)
        {
            _teacherService = teacherService;
            _departmentService = departmentService;
        }


        // GetDepartment() - Получение всех кафедр
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Department>))]
        public IActionResult GetDepartment()
        {
            return Ok(_departmentService.GetDepartment());
        }


        // AddDepartment() - Добавление кафедры
        [HttpPost("add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddDepartment([FromBody] Department department)
        {
            return Ok(await _departmentService.AddDepartment(department));
        }

        [HttpPut("{departmentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        // UpdateDepartment() - Обновление кафедры
        public IActionResult UpdateDepartment(Department department)
        {
            if (department == null)
            {
                return BadRequest(ModelState);
            }

            if (!_departmentService.DepartmentExists(department.DepartmentId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_departmentService.UpdateDepartment(department))
            {
                ModelState.AddModelError("", "Something went wrong updating department");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        // DeleteDepartment() - Удаление кафедры
        [HttpDelete("{departmentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDepartment(int departmentId)
        {
            if (!_departmentService.DepartmentExists(departmentId))
            {
                return NotFound();
            }

            var departmentToDelete = _departmentService.GetDepartmentById(departmentId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_departmentService.DeleteDepartment(departmentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting department");
            }

            return NoContent();
        }


        [HttpGet("error")]
        public IActionResult TriggerError()
        {
            throw new Exception("Исключение для проверки middleware");
        }


    }
}