using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface IFactura
    {
        bool add(FacturaModel factura);
        bool update(FacturaModel factura);
        bool delete(int Id);
        FacturaModel get(int Id);
        List<FacturaModel> list();
    }
}
