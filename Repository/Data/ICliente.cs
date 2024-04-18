using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface ICliente
    {
        bool add(ClienteModel cliente);
        bool update(ClienteModel cliente);
        bool delete(int Id);
        ClienteModel get(int Id);
        List<ClienteModel> list();
    }
}
