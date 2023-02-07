﻿using CursoCoder.Helper;
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
    internal class ProductSaleController
    {
        public static List<SoldProduct> GetSales(string saleId)
        {
            List<SoldProduct> sales = new List<SoldProduct>();
            DataSet dsSales = new DataSet();

            SqlCommand selectCommand = new SqlCommand("select pv.Id ProductSaleId, pv.Stock Amount, pv.IdVenta SaleId, p.Descripciones Product, p.Costo Cost, p.PrecioVenta Price, p.Stock Stock from ProductoVendido pv inner join Producto p on pv.IdProducto = p.Id ");

            string sCond = "";
            if (saleId != "")
            {
                selectCommand.CommandText = selectCommand.CommandText + " where pv.Id = @saleId";
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
                    SoldProduct sale = new SoldProduct();

                    sale.Id = Convert.ToInt32(dr["ProductSaleId"]);
                    sale.Amount = Convert.ToInt32(dr["Amount"]);
                    sale.SaleId = Convert.ToInt32(dr["SaleId"]);
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
