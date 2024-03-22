using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCrud.Utils
{
    public interface ILogger
    {
        public void AddException(Exception data);
    }
}
