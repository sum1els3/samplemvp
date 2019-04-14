using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePersonCrud.Model.Objects
{
    interface ICUD
    {
        void Create();
        void Update();
        void Delete();
    }
}
