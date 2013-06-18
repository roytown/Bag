using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    [InheritedExport]
    public interface IDbContextProvider
    {
        DatabaseContext Get();
    }
}
