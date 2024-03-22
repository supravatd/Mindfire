using Microsoft.AspNetCore.Mvc;
using StudentCrud.Business;
using StudentCrud.Models;

namespace StudentCrud.Controllers
{
    public class StudentController : Controller
    {
        private IService _service;

        public StudentController(IService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FetchAllData()
        {
            List<StudentModel> data = await _service.ListData();
            return Json(data);
        }

        public async Task<IActionResult> AddData(StudentModel s)
        {
            bool flag = await _service.AddData(s);
            return Json(flag);
        }

        public async Task<IActionResult> UpdateData(StudentModel s)
        {
            bool flag = await _service.UpdateData(s);
            return Json(flag);
        }

        public async Task<IActionResult> DeleteData(int id)
        {
            bool flag = await _service.DeleteData(new StudentModel { StudentId = id });
            return Json(flag);
        }
    }
}
