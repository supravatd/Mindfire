using StudentCrud.DataAccess;
using StudentCrud.Models;

namespace StudentCrud.Business
{
    public class Service : IService
    {
        private IDataAccess _dataAccess;

        public Service(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<bool> AddData(StudentModel s)
        {
            return await _dataAccess.AddData(s);
        }

        public async Task<bool> DeleteData(StudentModel s)
        {
            return await _dataAccess.DeleteData(s);
        }

        public async Task<List<StudentModel>> ListData()
        {
            return await _dataAccess.ListData();
        }

        public async Task<bool> UpdateData(StudentModel s)
        {
            return await _dataAccess.UpdateData(s);
        }
    }
}
