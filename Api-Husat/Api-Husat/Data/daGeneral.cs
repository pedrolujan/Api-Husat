using System.Data.SqlClient;
using System.Data;
using Api_Husat.Models;
using System.Collections.Generic;

namespace Api_Husat.Data
{
    public class daGeneral
    {
        public daGeneral() { }
        public List<Combobox> daDevolverTablaCodTipoCon(String cCodTab, Boolean buscar)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            Connection objCnx = null;

            try
            {

                pa[0] = new SqlParameter("@pecCodTab", SqlDbType.NVarChar, 8);
                pa[0].Value = cCodTab;


                objCnx = new Connection("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarTablaCod", pa);

                List<Combobox> lstCargo = new List<Combobox>();
                lstCargo.Add(new Combobox(
                        Convert.ToString("0"),
                        Convert.ToString(buscar ? "TODOS" : "Selecc. opcion"),
                        Convert.ToString("1")));

                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstCargo.Add(new Combobox(
                        Convert.ToString(drMenu["cCodTab"]),
                        Convert.ToString(drMenu["cNomTab"]),
                        Convert.ToString(drMenu["cValor"])));
                }

                return lstCargo;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CerrarConnection();
                objCnx = null;
            }

        }
        public List<Consultas> daBuscarConsultas(String pcBuscar, Int32 tipoCon)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtEquipo = new DataTable();
            Connection objCnx = null;
            List<Consultas> lstConsultas = new List<Consultas>();
            Consultas consultas = new Consultas();

            try
            {
                pa[0] = new SqlParameter("@pcBuscar", SqlDbType.VarChar, 30);
                pa[0].Value = pcBuscar;
                pa[1] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[1].Value = tipoCon;
                objCnx = new Connection("");
                dtEquipo = objCnx.EjecutarProcedimientoDT("uspBuscarConsultas", pa);
                if (tipoCon==0)
                {
                    foreach (DataRow dt in dtEquipo.Rows)
                    {
                        lstConsultas.Add(new Consultas
                        {
                            Id = Convert.ToInt32(dt["id"].ToString()),
                            Description = dt["nombre"].ToString()

                        });
                    }
                }else if (tipoCon == 1)
                {
                    Equipos equipos = new Equipos();
                    MarcaEquipo marcaEquipo = new MarcaEquipo();
                    ModeloEquipo modeloEquipo = new ModeloEquipo();
                    Vehiculo vehiculo= new Vehiculo();
                    MarcaVehiculo marcaVehiculo = new MarcaVehiculo();
                    ModeloVehiculo modeloVehiculo= new ModeloVehiculo();
                    ModoUso modoUso =new ModoUso();
                    ClaseVehiculo claseVehiculo = new ClaseVehiculo();
                    Cliente cliente = new Cliente();
                    SimCard simCard= new SimCard();
                    Plan plan = new Plan();
                    TipoTarifa tipoTarifa = new TipoTarifa();
                    TipoPlan tipoPlan = new TipoPlan();
                    Ciclo ciclo = new Ciclo();
                    Plataforma plataforma=new Plataforma();
                    Operador operador = new Operador();
                    

                    foreach (DataRow dt in dtEquipo.Rows)
                    {
                        simCard.Id= Convert.ToInt32(dt["idChip"].ToString());
                        simCard.cSimCard = dt["cSimCard"].ToString();
                        simCard.NumRecibo = dt["numeroRecibo"].ToString();
                        operador.Name = dt["operador"].ToString();
                        simCard.operador= operador;

                        equipos.Id= Convert.ToInt32(dt["idEquipoImeis"].ToString());
                        equipos.codDocCompra= dt["cDocCompra"].ToString();
                        equipos.Nombre= dt["NombreEquipo"].ToString();
                        equipos.Imei= dt["Imei"].ToString();
                        equipos.Serie = dt["nSerieEquipo"].ToString();

                        marcaEquipo.Nombre = Convert.ToString(dt["cNombreMarca"]);
                        modeloEquipo.Nombre = Convert.ToString(dt["cNombreModelo"]);

                        equipos.modeloEquipo= modeloEquipo;
                        equipos.marcaEquipo= marcaEquipo;

                        cliente.Id= Convert.ToInt32(dt["idCliente"].ToString());
                        cliente.nombres = dt["nombreCliente"].ToString();
                        cliente.ApellidosPaterno = dt["cApePat"].ToString();
                        cliente.ApellidosMaterno = dt["cApeMat"].ToString();
                        cliente.documentoIdentidad = dt["cDocumento"].ToString();
                        cliente.Celular = dt["cTelCelular"].ToString();
                        cliente.Contacto1 = dt["cContactoNom1"].ToString();
                        cliente.CelularContacto1 = dt["cContactoCel1"].ToString();

                        vehiculo.Id= Convert.ToInt32(dt["idVehiculo"].ToString());
                        vehiculo.Placa = dt["vPlaca"].ToString();
                        vehiculo.Serie = dt["vSerie"].ToString();
                        vehiculo.Anio = dt["vAnio"].ToString();
                        vehiculo.Color = dt["vColor"].ToString();

                        claseVehiculo.Nombre= dt["cNombreClaseV"].ToString();
                        marcaVehiculo.Nombre= dt["nombreMarcaV"].ToString();
                        modeloVehiculo.Nombre= dt["nombreModeloV"].ToString();

                        modoUso.Nombre= dt["cUsoV"].ToString();

                        vehiculo.claseVehiculo = claseVehiculo;
                        vehiculo.marcaVehiculo= marcaVehiculo;
                        vehiculo.modeloVehiculo = modeloVehiculo;
                        vehiculo.modoUso=modoUso;

                        tipoTarifa.Nombre= dt["TipoTarifa"].ToString();
                        tipoPlan.nombre= dt["contrato"].ToString();
                        plan.Name = dt["nombrePlan"].ToString();
                        plan.tipoContrato = dt["tipoContrato"].ToString();

                        ciclo.nombre= dt["cDia"].ToString();
                        plataforma.Nombre= dt["nombrePlataforma"].ToString();
                        
                        plan.tipoPlan = tipoPlan;
                        plan.tipoTarifa= tipoTarifa;
                        plan.ciclo= ciclo;


                        consultas.cliente = cliente;
                        consultas.equipo = equipos;
                        consultas.plan = plan;
                        consultas.vehiculo= vehiculo;
                        consultas.simCard= simCard;
                    }

                lstConsultas.Add(consultas);
                }

                return lstConsultas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CerrarConnection();
                objCnx = null;
            }

        }
        public DataTable daDevolverSoloUsuario(Boolean chk, String dtI, String dtFin, Int32 tipCOn)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtVehiculo = new DataTable();
            Connection objCnx = null;
            List<Usuario> lstUsuario = null;

            try
            {
                pa[0] = new SqlParameter("@dtInicio", SqlDbType.Date);
                pa[0].Value = dtI;
                pa[1] = new SqlParameter("@dtFin", SqlDbType.Date);
                pa[1].Value = dtFin;
                pa[2] = new SqlParameter("@chk", SqlDbType.Bit);
                pa[2].Value = chk;
                pa[3] = new SqlParameter("@tipoCOn", SqlDbType.Int);
                pa[3].Value = tipCOn;


                objCnx = new Connection("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarUsuariosConTrandiarias", pa);



                return dtVehiculo;

            }
            catch (Exception ex)
            {
                lstUsuario = null;
                
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CerrarConnection();
                objCnx = null;
                lstUsuario = null;
            }

        }
        public List<CajaChica> daObtenerImporteCaja(String dtFecha, Int32 idUsuario)
        {
            SqlParameter[] pa = new SqlParameter[3];
            DataTable dtResult = new DataTable();
            Connection objCnx = null;
            List<CajaChica> lstImporte = new List<CajaChica>();

            try
            {
                pa[0] = new SqlParameter("@fechaBusqueda", SqlDbType.Date);
                pa[0].Value = dtFecha;
                pa[1] = new SqlParameter("@fechaActual", SqlDbType.Date);
                pa[1].Value = DateTime.Now;
                pa[2] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[2].Value = idUsuario;



                objCnx = new Connection("");
                dtResult = objCnx.EjecutarProcedimientoDT("uspObtenerImporteEnCaja", pa);
                foreach (DataRow dt in dtResult.Rows)
                {
                    lstImporte.Add(new CajaChica
                    {
                        IdMoneda=1,
                        Usuario = dt["Usuario"].ToString(),
                        importe = Convert.ToDecimal(dt["ImporteCaja"])
                    });
                }


                return lstImporte;

            }
            catch (Exception ex)
            {
                lstImporte = null;
                
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CerrarConnection();
                objCnx = null;
                lstImporte = null;
            }

        }

        public DataSet DACargarMenu(Int32 pstrUsuario, Int32 pintAplicacion)
        {
            SqlParameter[] pa = new SqlParameter[2];
            Connection objCon = null;
            DataSet dtb = null;
            try
            {
                objCon = new Connection("");
                pa[0] = new SqlParameter("@peiUsuario", SqlDbType.Int);
                pa[0].Value = pstrUsuario;
                pa[1] = new SqlParameter("@peiAplicacion", SqlDbType.Int);
                pa[1].Value = pintAplicacion;

                dtb = objCon.EjecutarProcedimientoDS("uspObtenerMenu", pa);

                return dtb;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCon != null)
                    objCon.CerrarConnection();
                objCon = null;
                dtb = null;
            }


        }
        public List<Combobox> daLlenarCboSegunTablaTipoCon(String nomCampoId, String nomCampoNombre, String nomTabla, String nomEstado, String condicionDeEstado, Boolean buscar)
        {


            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtUsuario = new DataTable();
            Connection objCnx = null;

            try
            {

                pa[0] = new SqlParameter("@id", SqlDbType.NVarChar, 80);
                pa[0].Value = nomCampoId;
                pa[1] = new SqlParameter("@nombre", SqlDbType.NVarChar, 80);
                pa[1].Value = nomCampoNombre;
                pa[2] = new SqlParameter("@tabla", SqlDbType.NVarChar, 1000);
                pa[2].Value = nomTabla;
                pa[3] = new SqlParameter("@estado", SqlDbType.NVarChar, 80);
                pa[3].Value = nomEstado;
                pa[4] = new SqlParameter("@conEstado", SqlDbType.NVarChar, 20);
                pa[4].Value = condicionDeEstado;


                objCnx = new Connection("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspLlenarComboboxSegunTabla", pa);

                List<Combobox> lstCargo = new List<Combobox>();
                lstCargo.Add(new Combobox(
                        Convert.ToString("0"),
                        Convert.ToString(buscar ? "TODOS" : "Selecc. opcion"),
                        Convert.ToString("1")));
                if (nomCampoId == "CONSULTA")
                {
                    foreach (DataRow drMenu in dtUsuario.Rows)
                    {
                        lstCargo.Add(new Combobox(
                            Convert.ToString(drMenu["id"]),
                            Convert.ToString(drMenu["nombre"]),
                            Convert.ToString(drMenu["estado"])));
                    }
                }
                else
                {
                    foreach (DataRow drMenu in dtUsuario.Rows)
                    {
                        lstCargo.Add(new Combobox(
                            Convert.ToString(drMenu["" + nomCampoId + ""]),
                            Convert.ToString(drMenu["" + nomCampoNombre + ""]),
                            Convert.ToString(drMenu["" + nomEstado + ""])));
                    }
                }


                return lstCargo;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CerrarConnection();
                objCnx = null;
            }

        }

    }
}
