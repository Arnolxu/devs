using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ArtadoDevs
{
    public class GetProduct
    {
        //List all the products
        public static void Products(Repeater DataProduct, string type, string dev)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection baglanti = new SqlConnection(con);

            if (type == "all")
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from artadoco_admin.Products where DevID='" + dev + "' order by ID desc", baglanti);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataProduct.DataSource = dt;
                DataProduct.DataBind();
            }
            else
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from artadoco_admin.Products where Type='" + type + "' and DevID='" + dev + "' order by ID desc", baglanti);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataProduct.DataSource = dt;
                DataProduct.DataBind();
            }
        }

        //Get the info of the product
        public static string Info(string info, string product, string dev)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection baglanti = new SqlConnection(con);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlCommand productinfo = new SqlCommand("select " + info + " from artadoco_admin.Products where ID='" + product + "' and DevID='" + dev + "'", baglanti);
            string reinfo = (string)productinfo.ExecuteScalar();

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

            return reinfo;
        }

        //List all the APIs
        public static void APIs(Repeater DataProduct, string type, string dev)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection baglanti = new SqlConnection(con);

            if (type == "all")
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from artadoco_admin.APIs where DevID='" + dev + "' order by ID desc", baglanti);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataProduct.DataSource = dt;
                DataProduct.DataBind();

            }
            else
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from artadoco_admin.APIs where Type='" + type + "' and DevID='" + dev + "' order by ID desc", baglanti);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataProduct.DataSource = dt;
                DataProduct.DataBind();
            }
        }

        //List all the Versions
        public static void Versions(Repeater DataProduct, string product)
        {
            //Connection Strings
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["admin"].ConnectionString.ToString();

            //Setting Sql Connection
            SqlConnection baglanti = new SqlConnection(con);

            SqlDataAdapter adp = new SqlDataAdapter("select * from artadoco_admin.Versions where ProductID='" + product + "' order by ID desc", baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DataProduct.DataSource = dt;
            DataProduct.DataBind();
        }
    }
}