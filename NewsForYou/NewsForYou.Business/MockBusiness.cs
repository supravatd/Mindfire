using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewsForYou.Model.Model;

namespace NewsForYou.Business
{
    public class MockBusiness
    {
        public static bool IsUser(SignInModel model)
        {
            return model.Email == "test@gmail.com" && model.Password == "test123";
        }
    }
}
