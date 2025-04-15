using MySqlConnector;
using Protocolo_User_DataEntry.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocolo_User_DataEntry.Repository
{
    public class BaseRepository
    {
        private readonly string connectionString;

        public BaseRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["conexionAriel"].ToString();
        }
        internal List<Usuario> GetAuditores()
        {
            List<Usuario> us = new List<Usuario>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT u.idusuario, u.legajo, u.nombre, u.apellido, u.area
                                        FROM usuarios u
                                        WHERE u.baja= 0 AND u.Auditor = 1;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario u = new Usuario
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Legajo = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                            Nombre = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Apellido = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        };
                        us.Add(u);
                    }
                }
            }
            return us;
        }

        internal Especificacion GetFichaTecnicaConfeccionAncho(int idCodigo)
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
                        esp.Minimo = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1) * 10;
                        esp.Maximo = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2) * 10;
                    }

                }

                return esp;
            }
        }

        internal Muestreo VerificarMuestreo(int idOrden, int aConfeccionar)
        {
            Muestreo m = new Muestreo();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT count(id_op) AS valor FROM formato_ensayo WHERE id_op=@pIdOrden GROUP BY id_op;";
                command.Parameters.Add("@pIdOrden", MySqlDbType.Int32).Value = idOrden;
                var muestrasTotales = command.ExecuteScalar() != DBNull.Value ? Convert.ToInt32(command.ExecuteScalar()) : 0;

                command.CommandText = @"select muestras,desde,hasta,pedir_cada from cantidadmuestreo where @pCantidadDeBosasRequeridas between desde and hasta and sector = 'c';";
                command.Parameters.Add("@pCantidadDeBosasRequeridas", MySqlDbType.Int32).Value = aConfeccionar;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        m.Requeridas = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        m.Desde = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        m.Hasta = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        m.PedirCada = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        m.Realizadas = muestrasTotales;
                    }
                }
            }
            return m;
        }

        internal Especificacion GetFichaTecnicaConfeccionLargo(int idCodigo)
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
                        esp.Minimo = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1) * 10;
                        esp.Maximo = reader.IsDBNull(2) ? 0.0 : reader.GetDouble(2) * 10;
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
                command.CommandText = @"SELECT fi.id,fi.nombre,fi.unidad,fi.certifica,fi.simbolo,fi.sector,fpie.especificacion,fpie.especificacion_min,fpie.especificacion_max,fi.constante
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
                            Id= reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            Medida = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            EsCertificado = reader.IsDBNull(3) ? false : Convert.ToBoolean(reader.GetInt32(3)),
                            Simbolo = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            Proceso = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Especificacion = reader[6] != DBNull.Value ? reader.GetDouble(6) : 0.0,
                            EspecificacionMin = reader[7] != DBNull.Value ? reader.GetDouble(7) : 0.0,
                            EspecificacionMax = reader[8] != DBNull.Value ? reader.GetDouble(8) : 0.0,
                            EsConstante = reader[9] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(9)) : false,

                        };
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal bool UpdateItem(string qryUpdate, ProtocoloItem pi)
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
                            command.CommandText = @"UPDATE formato_item SET nombre = @pNombre,
                                                                            unidad = @pMedida,
                                                                            usuario = @pUsuario,
                                                                            certifica = @pCertifica,
                                                                            constante = @pConstante,
                                                                            simbolo = @pSimbolo,
                                                                            maquina = @pMaquina                                                                                     
                                                                            WHERE id = (@pId);";
                            command.Parameters.Add("@pNombre", MySqlDbType.String).Value = pi.Nombre;
                            command.Parameters.Add("@pMedida", MySqlDbType.String).Value = pi.Medida;
                            command.Parameters.Add("@pUsuario", MySqlDbType.String).Value = pi.Auditor;
                            command.Parameters.Add("@pCertifica", MySqlDbType.Int32).Value = pi.EsCertificado;
                            command.Parameters.Add("@pConstante", MySqlDbType.Double).Value = pi.EsConstante;
                            command.Parameters.Add("@pSimbolo", MySqlDbType.String).Value = pi.Simbolo;
                            command.Parameters.Add("@pMaquina", MySqlDbType.Double).Value = pi.Maquina;
                            command.Parameters.Add("@pId", MySqlDbType.Int32).Value = pi.Id;
                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al modificar ITEM");
                            }

                            if (qryUpdate != "NO")
                            {
                                command.CommandText = qryUpdate;
                                if (command.ExecuteNonQuery() <= 0)
                                {
                                    throw new Exception("Error al actualizar SCRAPS");
                                }
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

        internal bool DeleteItem(string qryUpdate, int idItem)
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
                            command.CommandText = @"DELETE FROM formato_item WHERE (id = @pId);";
                            command.Parameters.Add("@pId", MySqlDbType.Int32).Value = idItem;
                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al modificar TX");
                            }

                            if (qryUpdate != "NO")
                            {
                                command.CommandText = qryUpdate;
                                if (command.ExecuteNonQuery() <= 0)
                                {
                                    throw new Exception("Error al actualizar SCRAPS");
                                }
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
        internal List<ProtocoloItem> GetItems()
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT fi.id,fi.nombre,fi.unidad,fi.certifica,fi.constante,fi.simbolo,fi.posicion,fi.maquina
                                        FROM formato_item fi;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var esCertificado = reader[3] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(3)) : false;
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            Medida = reader.IsDBNull(2) ? "Constante" : reader.GetString(2),
                            EsCertificado = esCertificado,
                            EsConstante = reader[4] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(4)) : false,
                            EsCertificadoSiNo = esCertificado ? "SI" : "NO",
                            Simbolo = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Posicion = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                            Maquina = reader.IsDBNull(7) ? "" : reader.GetString(7),
                        };
                        if (pi.Id == 9) {
                            pi.EspecificacionDato = FormVistaAuditor.instancia.espAncho.Medio + "±" + FormVistaAuditor.instancia.espAncho.Maximo;
                        }
                        if (pi.Id == 7)
                        {
                            pi.EspecificacionDato = FormVistaAuditor.instancia.espLargo.Medio + "±" + FormVistaAuditor.instancia.espLargo.Maximo;
                        }
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal List<ProtocoloItem> GetItemsPorMaquina(string maquina)
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = $@"SELECT fi.id,fi.nombre,fi.unidad,fi.certifica,fi.constante,fi.simbolo,fi.posicion,fi.sector
                                        FROM formato_item fi 
                                        WHERE fi.maquina like '%{maquina}%';";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var esCertificado = reader[3] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(3)) : false;
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            Medida = reader.IsDBNull(2) ? "Constante" : reader.GetString(2),
                            EsCertificado = esCertificado,
                            EsConstante = reader[4] != DBNull.Value ? Convert.ToBoolean(reader.GetInt32(4)) : false,
                            EsCertificadoSiNo = esCertificado ? "SI" : "NO",
                            Simbolo = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Posicion = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                            Proceso = reader.IsDBNull(7) ? "" : reader.GetString(7),
                        };
                        if (pi.Id == 9)
                        {
                            pi.EspecificacionDato = FormVistaAuditor.instancia.espAncho.Medio + "±" + FormVistaAuditor.instancia.espAncho.Maximo;
                        }
                        if (pi.Id == 7)
                        {
                            pi.EspecificacionDato = FormVistaAuditor.instancia.espLargo.Medio + "±" + FormVistaAuditor.instancia.espLargo.Maximo;
                        }
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal List<OP> GetOps(string maquina)
        {
            List<OP> pis = new List<OP>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT cantidaddeproduccion,numeroOrden,codigoOrden,MaquinaAlternativa,cantidad_realizada,prioridadMaquina,fecha_cargado
                                        FROM produccion_confeccion
                                        WHERE (MaquinaAlternativa <> 'Terminada' AND MaquinaAlternativa=@pMaquina) AND (YEAR(fecha_cargado) = YEAR(CURDATE()) AND
										cantidad_bolsa_conf > cantidad_realizada)
										ORDER BY prioridadMaquina;";
                command.Parameters.Add("@pMaquina", MySqlDbType.String).Value = maquina;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OP pi = new OP
                        {
                            CantProduccion = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Orden = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                            Codigo = reader.IsDBNull(2) ? 0 : Convert.ToInt32(reader.GetDouble(2)),
                            Maquina = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Cantidad = reader.IsDBNull(4) ? 0 : Convert.ToInt32(reader.GetDouble(4)),
                            Prioridad = reader.IsDBNull(5) ? 0 : Convert.ToInt32(reader.GetDouble(5)),
                        };
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal OP GetOp(int orden,int codigo)
        {
            OP p = new OP();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT cantidaddeproduccion,numeroOrden,codigoOrden,MaquinaAlternativa,cantidad_realizada,prioridadMaquina,fecha_cargado
                                        FROM produccion_confeccion
                                        WHERE numeroOrden=@pOrden AND codigoOrden=@pCodigo";
                command.Parameters.Add("@pOrden", MySqlDbType.Int32).Value = orden;
                command.Parameters.Add("@pCodigo", MySqlDbType.Int32).Value = codigo;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p = new OP
                        {
                            CantProduccion = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Orden = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                            Codigo = reader.IsDBNull(2) ? 0 : Convert.ToInt32(reader.GetDouble(2)),
                            Maquina = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Cantidad = reader.IsDBNull(4) ? 0 : Convert.ToInt32(reader.GetDouble(4)),
                            Prioridad = reader.IsDBNull(5) ? 0 : Convert.ToInt32(reader.GetDouble(5)),
                        };
                    }
                }
            }
            return p;
        }

        internal List<Maquina> GetMaquinas()
        {
            List<Maquina> pis = new List<Maquina>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT DISTINCT maquina
                                        FROM ponderaciones
                                        WHERE maquina NOT IN ('Otra', '-', '-11 (Pers.1)', 'Comexi (Pistas: 2)', 'FASON', 'MG (Pistas: 2)')
                                        ORDER BY maquina;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Maquina pi = new Maquina
                        {
                            Nombre = reader.IsDBNull(0) ? "" : reader.GetString(0),
                            Seleccionado = CheckState.Unchecked,
                        };
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal bool InsertEnsayoLote(List<ItemValor> valores, ProtocoloItem pi)
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
                            command.CommandText = @"INSERT INTO formato_ensayo (creado,turno,id_op,id_nt,legajo,paquete_numero) 
                                                                        VALUES (@pCreado,@pTurno,@pIdOp,@pIdNt,@pLegajo,@pPaqueteNum); SELECT LAST_INSERT_ID();";
                            command.Parameters.Add("@pCreado", MySqlDbType.Newdate).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            command.Parameters.Add("@pTurno", MySqlDbType.String).Value = pi.Turno;
                            command.Parameters.Add("@pIdOp", MySqlDbType.String).Value = pi.OP;
                            command.Parameters.Add("@pIdNt", MySqlDbType.Int32).Value = 0;
                            command.Parameters.Add("@pLegajo", MySqlDbType.Int32).Value = pi.Legajo;
                            command.Parameters.Add("@pPaqueteNum", MySqlDbType.Int32).Value = pi.PaqueteNum;

                            var ultimoID  =  Convert.ToInt32(command.ExecuteScalar());

                            if (ultimoID <= 0)
                            {
                                throw new Exception("Error al insertar ensayo");
                            }
                            command.CommandText = QryInsertarEnsayo(valores,ultimoID);

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
        internal bool InsertEnsayoLoteAuditor(List<ItemValor> valores, ProtocoloItem pi)
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
                            command.CommandText = @"INSERT INTO formato_ensayo_auditor (creado,turno,id_op,id_nt,legajo,paquete_numero) 
                                                                        VALUES (@pCreado,@pTurno,@pIdOp,@pIdNt,@pLegajo,@pPaqueteNum); SELECT LAST_INSERT_ID();";
                            command.Parameters.Add("@pCreado", MySqlDbType.Newdate).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            command.Parameters.Add("@pTurno", MySqlDbType.String).Value = pi.Turno;
                            command.Parameters.Add("@pIdOp", MySqlDbType.String).Value = pi.OP;
                            command.Parameters.Add("@pIdNt", MySqlDbType.Int32).Value = 0;
                            command.Parameters.Add("@pLegajo", MySqlDbType.Int32).Value = pi.Legajo;
                            command.Parameters.Add("@pPaqueteNum", MySqlDbType.Int32).Value = pi.PaqueteNum;

                            var ultimoID = Convert.ToInt32(command.ExecuteScalar());

                            if (ultimoID <= 0)
                            {
                                throw new Exception("Error al insertar ensayo");
                            }
                            command.CommandText = QryInsertarEnsayoAuditor(valores, ultimoID);

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
        internal string QryInsertarEnsayo(List<ItemValor> valores,int idEnsayo) {
            string sqlInsertarProtocoloItem = "INSERT INTO formato_item_valor (id_item,valor,valor_constante,id_bobina_madre,id_ensayo) VALUES ";
            string sqlInsertarProtocoloItem2 = "";

            foreach (ItemValor item in valores) {
                sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{item.IdItem}','{item.Valor}','{item.ValorConstante}','{item.IdBobinaMadre}','{idEnsayo}'),";
            }
            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
            sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;

            return sqlInsertarProtocoloItem;
        }
        internal string QryInsertarEnsayoAuditor(List<ItemValor> valores, int idEnsayo)
        {
            string sqlInsertarProtocoloItem = "INSERT INTO formato_item_valor_auditor (id_item,valor,valor_constante,id_bobina_madre,id_ensayo) VALUES ";
            string sqlInsertarProtocoloItem2 = "";

            foreach (ItemValor item in valores)
            {
                sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2 + $"('{item.IdItem}','{item.Valor}','{item.ValorConstante}','{item.IdBobinaMadre}','{idEnsayo}'),";
            }
            sqlInsertarProtocoloItem2 = sqlInsertarProtocoloItem2.TrimEnd(',') + ";";
            sqlInsertarProtocoloItem = sqlInsertarProtocoloItem + sqlInsertarProtocoloItem2;

            return sqlInsertarProtocoloItem;
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

        internal int GetIdProtocoloItem(int idItem, int idProtocolo)
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
                                        WHERE fpi.id_protocolo=@pIdProtocolo AND fpi.id_item=@pIdItem; ";
                command.Parameters.Add("@pIdProtocolo", MySqlDbType.Int32).Value = idProtocolo;
                command.Parameters.Add("@pIdItem", MySqlDbType.Int32).Value = idItem;
                idProtocoloItem = Convert.ToInt32(command.ExecuteScalar());
            }
            return idProtocoloItem;
        }
        internal bool GetNombreItemDuplicado(string nombre)
        {
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT id FROM formato_item where nombre = @pNombre;";
                command.Parameters.Add("@pNombre", MySqlDbType.String).Value = nombre;
                var pp = command.ExecuteScalar();
                if (pp == null) return true;
                else return false;
            }
        }
        internal bool AgregarItem(ProtocoloItem pi)
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
                            command.CommandText = @"INSERT INTO formato_item (nombre,unidad,usuario,certifica,constante,simbolo,maquina) 
                                                                      VALUES (@pNombre,@pUnidad,@pUsuario,@pCertifica,@pConstante,@pSimbolo,@pMaquina); SELECT LAST_INSERT_ID();";
                            command.Parameters.Add("@pNombre", MySqlDbType.String).Value = pi.Nombre;
                            command.Parameters.Add("@pUnidad", MySqlDbType.String).Value = pi.Medida;
                            command.Parameters.Add("@pUsuario", MySqlDbType.String).Value = pi.Auditor;
                            command.Parameters.Add("@pCertifica", MySqlDbType.Int32).Value = pi.EsCertificado;
                            command.Parameters.Add("@pConstante", MySqlDbType.Int32).Value = pi.EsConstante;
                            command.Parameters.Add("@pSimbolo", MySqlDbType.String).Value = pi.Simbolo;
                            command.Parameters.Add("@pMaquina", MySqlDbType.String).Value = pi.Maquina;

                            if (command.ExecuteNonQuery() != 1)
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
        internal List<ProtocoloItem> GetEnsayosPorPaqueteAuditoria(string op, int numPaquete, int esPorPaquete)
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                if (esPorPaquete != 0)
                {
                    command.CommandText = @"SELECT fi.nombre,fiv.valor,fe.creado,fiv.id_bobina_madre,fe.turno,fi.constante,fiv.valor_constante,fiv.id_ensayo,fe.paquete_numero
                                            FROM formato_ensayo_auditor fe
											JOIN formato_item_valor_auditor fiv ON fe.id = fiv.id_ensayo
                                            JOIN formato_item fi ON fiv.id_item = fi.id
                                            WHERE fe.id_op = @pOP AND fe.paquete_numero = @pPaquete;";
                }
                else
                {
                    command.CommandText = @"SELECT fi.nombre,fiv.valor,fe.creado,fiv.id_bobina_madre,fe.turno,fi.constante,fiv.valor_constante,fiv.id_ensayo,fe.paquete_numero
                                            FROM formato_ensayo_auditor fe
											JOIN formato_item_valor_auditor fiv ON fe.id = fiv.id_ensayo
                                            JOIN formato_item fi ON fiv.id_item = fi.id
                                            WHERE fe.id_op = @pOP;";

                }

                command.Parameters.Add("@pOP", MySqlDbType.String).Value = op;
                command.Parameters.Add("@pPaquete", MySqlDbType.String).Value = numPaquete;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var esCertificado = reader.IsDBNull(5) ? false : Convert.ToBoolean(reader.GetInt32(5));
                        var valorNormal = reader.IsDBNull(1) ? "0.0" : reader.GetDouble(1).ToString();
                        var valorConstante = reader.IsDBNull(6) ? "0.0" : reader.GetString(6);
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            Nombre = reader.IsDBNull(0) ? "" : reader.GetString(0),
                            Valor = !esCertificado ? valorNormal : valorConstante,
                            Creado = reader.IsDBNull(2) ? new DateTime(1993, 1, 20) : reader.GetDateTime(2),
                            Turno = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            IdEnsayo = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                            PaqueteNum = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                        };
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal List<ProtocoloItem> GetEnsayos(string op,string tipo)
        {
            List<ProtocoloItem> pis = new List<ProtocoloItem>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                if (tipo == "Produccion")
                {
                    command.CommandText = @"SELECT fi.nombre,fiv.valor,fe.creado,fiv.id_bobina_madre,fe.turno,fi.constante,fiv.valor_constante,fiv.id_ensayo
                                            FROM formato_ensayo fe
											JOIN formato_item_valor fiv ON fe.id = fiv.id_ensayo
                                            JOIN formato_item fi ON fiv.id_item = fi.id
                                            WHERE fe.id_op = @pOP AND fi.constante <> 1;";
                }
                else {
                    command.CommandText = @"SELECT fi.nombre,fiv.valor,fe.creado,fiv.id_bobina_madre,fe.turno,fi.constante,fiv.valor_constante,fiv.id_ensayo
                                            FROM formato_ensayo fe
											JOIN formato_item_valor fiv ON fe.id = fiv.id_ensayo
                                            JOIN formato_item fi ON fiv.id_item = fi.id
                                            WHERE fe.id_op = @pOP;";

                }
               
                command.Parameters.Add("@pOP", MySqlDbType.String).Value = op;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var esCertificado = reader.IsDBNull(5) ? false : Convert.ToBoolean(reader.GetInt32(5));
                        var valorNormal = reader.IsDBNull(1) ? "0.0" : reader.GetDouble(1).ToString();
                        var valorConstante = reader.IsDBNull(6) ? "0.0" : reader.GetString(6);
                        ProtocoloItem pi = new ProtocoloItem
                        {
                            Nombre = reader.IsDBNull(0) ? "" : reader.GetString(0),
                            Valor = !esCertificado?valorNormal:valorConstante,
                            Creado = reader.IsDBNull(2) ? new DateTime(1993, 1, 20) : reader.GetDateTime(2),
                            Turno = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            IdEnsayo = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                        };
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal List<Paquete> GetPaquetesPorOP(int cantProduccion)
        {
            List<Paquete> pis = new List<Paquete>();
            using (var conexion = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand())
            {
                conexion.Open();
                command.Connection = conexion;
                command.CommandText = @"SELECT num_bulto,legajo,cant_bolsas 
                                        FROM bultos 
                                        WHERE id_orden = @pIdOrden;";
                command.Parameters.Add("@pIdOrden", MySqlDbType.String).Value = cantProduccion;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Paquete pi = new Paquete
                        {
                            Numero = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Legajo = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            Cantidad = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),

                        };
                        pis.Add(pi);
                    }
                }
            }
            return pis;
        }

        internal bool CambiarPosicionItem(int id,int posicion)
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
                            command.CommandText = @"UPDATE formato_item SET posicion=@pPosicion
                                                    WHERE id = @pID";
                            command.Parameters.Add("@pID", MySqlDbType.Int32).Value = id;
                            command.Parameters.Add("@pPosicion", MySqlDbType.Int32).Value = posicion;
                            if (command.ExecuteNonQuery() != 1)
                            {
                                throw new Exception("Error al actualizar posicion item");
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
    }
}
