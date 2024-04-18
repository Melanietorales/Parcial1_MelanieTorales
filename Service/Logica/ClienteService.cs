using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Data;

namespace Service.Logica
{
    public class ClienteService
    {
        ClienteRepository clienteRepository;
        public ClienteService(string connectionString) {
            clienteRepository = new ClienteRepository(connectionString);
        }

        public ResponseEntity add(ClienteModel cliente)
        {
            if (validacionesCliente(cliente))
            {
                if (clienteRepository.add(cliente))
                {
                    return new ResponseEntity { Success = true, Message = "Cliente registrado correctamente." };

                } else
                    return new ResponseEntity { Success = false, Message = "Error al agregar el cliente." };

            }
            else
            {
                return new ResponseEntity { Success = false, Message = "Error al validar el cliente." };
            }
        }

        public ResponseEntity update(ClienteModel cliente)
        {
            if (validacionesCliente(cliente))
            {
                if (clienteRepository.update(cliente))
                {
                    return new ResponseEntity { Success = true, Message = "Cliente modificado correctamente." };

                }
                else
                    return new ResponseEntity { Success = false, Message = "Error al modificar el cliente." };

            }
            else
            {
                return new ResponseEntity { Success = false, Message = "Error al validar el cliente." };
            }
        }

        public ResponseEntity delete(int Id)
        {
            if (clienteRepository.delete(Id))
            {
                return new ResponseEntity { Success = true, Message = "Cliente eliminado correctamente." };

            }
            else
                return new ResponseEntity { Success = false, Message = "Error al eliminar el cliente." };
        }

        public ClienteModel get(int Id)
        {
            return clienteRepository.get(Id);

        }


        public List<ClienteModel> list()
        {
            return clienteRepository.list();
        }

        public bool validacionesCliente(ClienteModel cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre) || cliente.Nombre.Length < 3 ||
        string.IsNullOrWhiteSpace(cliente.Apellido) || cliente.Apellido.Length < 3 ||
        string.IsNullOrWhiteSpace(cliente.Documento) || cliente.Documento.Length < 3)
            {
                return false;
            }
            if (cliente.Celular.ToString().Length != 10)
            {
                return false;
            }
            return true;
        }
    }
       
}

