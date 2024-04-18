using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Logica
{
    public class FacturaService
    {
        FacturaRepository facturaRepository;

        public FacturaService(string connectionString)
        {
            facturaRepository = new FacturaRepository(connectionString);
        }
        
        public ResponseEntity add(FacturaModel factura)
        {
            if (validaciones(factura))
            {
                if (facturaRepository.add(factura))
                {
                    return new ResponseEntity { Success = true, Message = "Factura registrada correctamente." };

                }
                else
                    return new ResponseEntity { Success = false, Message = "Error al agregar la factura." };
            }
            else
            {
                return new ResponseEntity { Success = false, Message = "Error al validar la factura." };
            }
            
        }


        public ResponseEntity update(FacturaModel factura)
        {
            if (validaciones(factura))
            {
                if (facturaRepository.update(factura))
                {
                    return new ResponseEntity { Success = true, Message = "Factura actualizada correctamente." };
                }
                else
                    return new ResponseEntity { Success = false, Message = "Error al actualizar la factura." };          
            }
            else
            {
                return new ResponseEntity { Success = false, Message = "Error al validar la factura." };
            }
        }

        public ResponseEntity delete(int Id)
        {
            if (facturaRepository.delete(Id))
            {
                return new ResponseEntity { Success = true, Message = "Factura eliminada correctamente." };
            }
            else
                return new ResponseEntity { Success = false, Message = "Error al eliminar la factura." };
        }

        public FacturaModel get(int Id)
        {
            return facturaRepository.get(Id);
        }
        public List<FacturaModel> list()
        {
            return facturaRepository.list();
        }
        public bool validaciones(FacturaModel factura)
        {
            if (!Regex.IsMatch(factura.Nro_Factura, @"^\d{3}-\d{3}-\d{6}$"))
            {
                return false;
            }

            if (factura.Total == 0 || factura.Total_iva5 == 0 || factura.Total_iva10 == 0 || factura.Total_iva == 0)
            {
                return false;
            }

            if (factura.Total_letras.Length < 6)
            {
                return false;
            }
            return true;
        }
    }
}
