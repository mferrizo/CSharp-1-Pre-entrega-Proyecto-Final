using CursoCoder.Helper;
using CursoCoder.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Proyecto1;

namespace CursoCoder.Controller
{
    internal class SaleController
    {
        public static List<Sale> GetSales(string saleId)
        {
            List<Sale> sales = new List<Sale>();
            DataSet dsSales = new DataSet();

            SqlCommand selectCommand = new SqlCommand("select vta.Id SaleId, u.NombreUsuario UserName, vta.Comentarios SaleComments, pv.Stock SaleAmount, p.Descripciones Product, p.Costo Cost, p.PrecioVenta Price, p.Stock Stock from Venta vta inner join ProductoVendido pv on pv.IdVenta = vta.Id inner join Producto p on p.Id = pv.IdProducto inner join Usuario u on vta.IdUsuario = u.id ");

            string sCond = "";
            if (saleId != "")
            {
                selectCommand.CommandText = selectCommand.CommandText + " where vta.Id = @saleId";
                var parameter = new SqlParameter();
                parameter.ParameterName = "saleId";
                parameter.SqlDbType = SqlDbType.BigInt;
                parameter.Value = saleId;
                selectCommand.Parameters.Add(parameter);
            }

            Program.sqlHandler.GetCommand(dsSales, selectCommand);

            if (dsSales.Tables.Contains("DAT") && dsSales.Tables["DAT"].Rows.Count > 0)
            {
                DataTable dtDAT = dsSales.Tables["DAT"];
                foreach (DataRow dr in dtDAT.Rows)
                {
                    Sale sale = new Sale();

                    sale.Id = Convert.ToInt32(dr["SaleId"]);
                    if (dr["UserName"] != DBNull.Value) sale.UserId = Convert.ToString(dr["UserName"]).Trim();
                    if (dr["SaleComments"] != DBNull.Value) sale.SaleComments = Convert.ToString(dr["SaleComments"]).Trim();
                    sale.SaleAmount = Convert.ToInt32(dr["SaleAmount"]);
                    if (dr["Product"] != DBNull.Value) sale.Product = Convert.ToString(dr["Product"]).Trim();
                    sale.Cost = Convert.ToDecimal(dr["Cost"]);
                    sale.Price = Convert.ToDecimal(dr["Price"]);
                    sale.Stock = Convert.ToInt32(dr["Stock"]);

                    sales.Add(sale);

                }
            }

            return sales;
        }
    }
}
