using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class FacturaRepository : IFactura
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection conexionDB;
        public FacturaRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.conexionDB = new Npgsql.NpgsqlConnection(this._connectionString);
        }

        string deleteQuery = "DELETE FROM Factura WHERE id = @id";

        string addQuery = "Insert into Factura(Id, Id_cliente, Nro_Factura, Fecha_Hora, Total, Total_iva5, Total_iva10, Total_iva, Total_letras, Sucursal) values (@Id, @Id_cliente, @Nro_Factura, @Fecha_Hora, @Total, @Total_iva5, @Total_iva10, @Total_iva, @Total_letras, @Sucursal)";

        string updateQuery = "UPDATE Factura SET Id_cliente=@Id_cliente, Nro_Factura=@Nro_Factura, Fecha_Hora=@Fecha_Hora, Total=@Total, Total_iva5=@Total_iva5, Total_iva10=@Total_iva10, Total_iva=@Total_iva, Total_letras=@Total_letras, Sucursal=@Sucursal WHERE Id= ";

        string getQuery = "SELECT * FROM Factura WHERE Id = @Id";

        string listQuery = "SELECT * FROM Factura";

        public bool add(FacturaModel facturaModel)
        {
            try
            {
                if (conexionDB.Execute(addQuery, facturaModel) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool update(FacturaModel facturaModel)
        {
            try
            {
                if (conexionDB.Execute(updateQuery + facturaModel.Id, facturaModel) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool delete(int Id)
        {
            try
            {
                if (conexionDB.Execute(deleteQuery, new { id = Id }) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public FacturaModel get(int Id)
        {
            try
            {
                var factura = conexionDB.QuerySingleOrDefault<FacturaModel>(getQuery, new { Id });
                if (factura == null)
                {
                    throw new Exception("No se encontraron registros para el ID proporcionado.");
                }
                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<FacturaModel> list()
        {
            try
            {
                return conexionDB.Query<FacturaModel>(listQuery).ToList();
            }
            catch (Exception ex)
            {
                return new List<FacturaModel>();
            }
        }
    }
}
