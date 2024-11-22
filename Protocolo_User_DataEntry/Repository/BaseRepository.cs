using MySqlConnector;
using Protocolo_User_DataEntry.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocolo_User_DataEntry.Repository
{
    public class BaseRepository
    {
        private readonly string connectionString;

        public BaseRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["conexionAriel"].ToString();
        }
        internal Especificacion GetFichaLogisticaConfeccionAncho(int idCodigo)
        {
            Especificacion esp = new Especificacion();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT ancho,ancho_min,ancho_max
                                        FROM confeccion 
                                        WHERE idcodigo = @pIdCodigo;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Double).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        esp.Medio = reader.IsDBNull(0) ? 0.0 : reader.GetDouble(0) * 10;
                        esp.Minimo = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1);
                        esp.Maximo = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2);
                    }

                }

                return esp;
            }
        }
        internal Especificacion GetFichaLogisticaConfeccionLargo(int idCodigo)
        {
            Especificacion esp = new Especificacion();

            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT largo,largo_min,largo_max
                                        FROM confeccion 
                                        WHERE idcodigo = @pIdCodigo;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Double).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        esp.Medio = reader.IsDBNull(0) ? 0.0 : reader.GetDouble(0) * 10;
                        esp.Minimo = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1);
                        esp.Maximo = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2);
                    }

                }

                return esp;
            }
        }
        internal Codigo GetDatosDelCodigo(int idCodigo)
        {
            Codigo pis = new Codigo();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT e.IdCodigo,fl.Razon_Social,e.id_formato_protocolo,fp.nombre,fp.disposicion
                                        FROM extrusion e 
                                        JOIN formato_protocolo fp ON e.id_formato_protocolo=fp.id
                                        JOIN ficha_logistica fl ON e.NumeroCliente = fl.Num_Cliente
                                        WHERE e.IdCodigo = @pIdCodigo;";
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pis.Id = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader.GetDouble(0));
                        pis.Cliente = reader.IsDBNull(1) ? "" : reader.GetString(1);
                        pis.IdProtocolo = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        pis.ProtocoloNombre = reader.IsDBNull(3) ? "" : reader.GetString(3);
                        pis.Disposicion = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);

                    }
                }
            }
            return pis;
        }
        internal List<OrdenCodigo> GetCodigosEnProduccion(string maquina)
        {
            List<OrdenCodigo> ops = new List<OrdenCodigo>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT pc.NumeroOrden, pc.CodigoOrden, pc.PrioridadMaquina, pc.cantidad_bolsa_conf, pc.cantidad_realizada, pc.MaquinaAlternativa, pc.CantidadDeproduccion
                                        FROM produccion_confeccion pc
                                        WHERE pc.cantidad_bolsa_conf>pc.cantidad_realizada AND pc.MaquinaAlternativa=@pMaquina
                                        ORDER BY pc.PrioridadMaquina limit 10;";
                command.Parameters.Add("@pMaquina", MySqlDbType.String).Value = maquina;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var orden = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        var codigo = reader.IsDBNull(1) ? 0 : Convert.ToInt32(reader.GetDouble(1));
                        OrdenCodigo op = new OrdenCodigo
                        {
                            Orden = orden,
                            Codigo = codigo,
                            O_P = orden+"/"+codigo,
                        };
                        ops.Add(op);
                    }
                }
            }
            return ops;
        }
        internal List<ProtocoloItem> GetItemsPorProceso(string sector, int idCodigo)
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fpi.id,fi.nombre,fi.unidad,fi.certifica,fi.simbolo,fi.sector,fpie.especificacion,fpie.especificacion_min,fpie.especificacion_max
                                        FROM formato_protocolo_item fpi
                                        JOIN formato_protocolo_item_especificacion fpie on fpi.id = fpie.id_formato_protocolo_item
                                        JOIN formato_item fi on fpi.id_item = fi.id
                                        WHERE id_codigo = @pIdCodigo and fi.sector = @pSector;";
                command.Parameters.Add("@pSector", MySqlDbType.String).Value = sector;
                command.Parameters.Add("@pIdCodigo", MySqlDbType.Int32).Value = idCodigo;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            IdProtocoloItem= reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            Medida = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            EsCertificado = reader.IsDBNull(3) ? false : Convert.ToBoolean(reader.GetInt32(3)),
                            Simbolo = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Sector = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Especificacion = reader[6] != DBNull.Value ? reader.GetDouble(6) : 0.0,
                            EspecificacionMin = reader[7] != DBNull.Value ? reader.GetDouble(7) : 0.0,
                            EspecificacionMax = reader[8] != DBNull.Value ? reader.GetDouble(8) : 0.0,
                        };
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal bool InsertEnsayo(string op,int idNt, int idProtocoloItem, double valor, int correcto)
        {
            bool res = false;
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    using (var command = conexion.CreateCommand())
                    {
                        command.Transaction = transaction;
                        try
                        {
                            command.CommandText = @"INSERT INTO formato_ensayo (op,id_nt,id_protocolo_item,valor_ensayo,correcto) 
                                                                        VALUES (@pOp,@pIdNt,@pIdProtocoloItem,@pValor,@pCorrecto);";
                            command.Parameters.Add("@pOp", MySqlDbType.String).Value = op;
                            command.Parameters.Add("@pIdNt", MySqlDbType.Int32).Value = idNt;
                            command.Parameters.Add("@pIdProtocoloItem", MySqlDbType.Int32).Value = idProtocoloItem;
                            command.Parameters.Add("@pValor", MySqlDbType.Double).Value = valor;
                            command.Parameters.Add("@pCorrecto", MySqlDbType.Int32).Value = correcto;

                            if (command.ExecuteNonQuery() <= 0)
                            {
                                throw new Exception("Error al insertar itemProtocolo");
                            }

                            transaction.Commit();
                            res = true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            res = false;
                        }
                    }
                }
            }
            return res;
        }
        internal bool InsertEnsayoLote(string Qry)
        {
            bool res = false;
            using (var conexion = new MySqlConnection(connectionString))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    using (var command = conexion.CreateCommand())
                    {
                        command.Transaction = transaction;
                        try
                        {
                            command.CommandText = Qry;

                            if (command.ExecuteNonQuery() <= 0)
                            {
                                throw new Exception("Error al insertar ensayo");
                            }

                            transaction.Commit();
                            res = true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            res = false;
                        }
                    }
                }
            }
            return res;
        }
        internal List<Maquina> GetMaquinasConfeccion()
        {
            List<Maquina> ms = new List<Maquina>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT maquina,sector
                                        FROM ponderaciones 
                                        WHERE sector = 'Confeccion' AND Maquina NOT IN ('Wick1','Wick2','Wick3');";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Maquina m = new Maquina
                        {
                            Nombre = reader.IsDBNull(0) ? "" : reader.GetString(0),
                            Sector = reader.IsDBNull(1) ? "" : reader.GetString(1),
                        };
                        ms.Add(m);
                    }
                }
            }
            return ms;
        }

        internal int GetIdProtocoloItem(int idItem)
        {
            var idProtocoloItem = 0;
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fpi.id,fi.nombre,fi.unidad,fi.simbolo
                                        FROM formato_protocolo_item fpi
                                        JOIN formato_item fi ON fpi.id_item = fi.id
                                        WHERE fpi.id_item =@pIdItem; ";
                command.Parameters.Add("@pIdItem", MySqlDbType.String).Value = idItem;
                idProtocoloItem = Convert.ToInt32(command.ExecuteScalar());
            }
            return idProtocoloItem;
        }
    }
}
