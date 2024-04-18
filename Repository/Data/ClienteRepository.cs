using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace Repository.Data
{
    public class ClienteRepository : ICliente
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection conexionDB;
        public ClienteRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.conexionDB = new Npgsql.NpgsqlConnection(this._connectionString);
        }

        string deleteQuery = "DELETE FROM Cliente WHERE id = @id";

        string addQuery = "Insert into Cliente(Id, Id_banco, Nombre, Apellido, Documento, Direccion, Mail, Celular, Estado) values (@Id, @Id_banco, @Nombre, @Apellido, @Documento, @Direccion, @Mail, @Celular, @Estado)";

        string updateQuery = "UPDATE Cliente SET Id_banco=@Id_banco, Nombre=@Nombre, Apellido=@Apellido, Documento=@Documento, Direccion=@Direccion, Mail=@Mail, Celular=@Celular, Estado=@Estado WHERE Id = ";

        string getQuery = "SELECT * FROM Cliente WHERE Id = @Id";

        string listQuery = "SELECT * FROM Cliente";

        public bool add(ClienteModel cliente)
        {
            try
            {
                if (conexionDB.Execute(addQuery, cliente) > 0)
                return true;
                else
                return false;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool update(ClienteModel cliente)
        {
            try
            {
                if (conexionDB.Execute(updateQuery + cliente.Id, cliente) > 0)
                    return true;
                else
                    return false;
            }catch(Exception ex)
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
            }catch(Exception ex)
            {
               throw new Exception (ex.Message);
            }
        }

        public ClienteModel get(int Id)
        {
            try
            {
                var cliente = conexionDB.QuerySingleOrDefault<ClienteModel>(getQuery, new { Id });

                if (cliente == null)
                {
                    throw new Exception("No se encontraron registros para el ID proporcionado.");
                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ClienteModel> list()
        {
            try
            {
                return conexionDB.Query<ClienteModel>(listQuery).ToList();

            }catch (Exception ex)
            {
                return new List<ClienteModel>();
            }
        }
    }
}
