using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DAL
    {

        public string constring = "Data Source=LAPTOP-IM113RBU;Initial Catalog=Ogrenci;Integrated Security=True";
        SqlConnection con = new SqlConnection();
        DataTable dt = new DataTable();

        public DataTable Read()
        {
            con.ConnectionString = constring;
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from Ogrencibilgi", con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }                     
        }
        public DataTable Read(int id)
        {
            con.ConnectionString = constring;
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from Employees where EmployeeID=" + id + "", con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable Kaydet(string ad,string soyad,string no,string tel)
        {
            con.ConnectionString = constring;
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            try
            {
                SqlCommand komut = new SqlCommand("OgrSorgu", con);
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@Action", "insert");
                komut.Parameters.AddWithValue("@ogrAd", ad);
                komut.Parameters.AddWithValue("@ogrSoyad", soyad);
                komut.Parameters.AddWithValue("@ogrNo", no);
                komut.Parameters.AddWithValue("@ogrTel", tel);
                komut.ExecuteNonQuery();//insert,update,delete
                SqlCommand cmd1 = new SqlCommand("select * from ogrencibilgi ", con);
                SqlDataReader rd = cmd1.ExecuteReader();
                dt.Load(rd);
                con.Close();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Güncelle(int id,string ad,string soyad,string no)
        {
            con.ConnectionString = constring;
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            try
            {
                SqlCommand gncll = new SqlCommand("OgrSorgu", con);
                gncll.CommandType = CommandType.StoredProcedure;
                gncll.Parameters.AddWithValue("@Action", "update");
                gncll.Parameters.AddWithValue("@ogrAd", ad);
                gncll.Parameters.AddWithValue("@ogrsoyad", soyad);
                gncll.Parameters.AddWithValue("@ogrno", no);
                gncll.Parameters.AddWithValue("@ogrenciID", id);
                gncll.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select * from ogrencibilgi", con);
                SqlDataReader rd = cmd1.ExecuteReader();
                dt.Load(rd);
                con.Close();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable sil(int id)
        {
            con.ConnectionString = constring;
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }
            try
            {
             
                SqlCommand sil = new SqlCommand("OgrSorgu", con);
                sil.CommandType = CommandType.StoredProcedure;
                sil.Parameters.AddWithValue("@Action", "Delete");
                sil.Parameters.AddWithValue("@ogrenciId", id);
                sil.ExecuteNonQuery();
                //SqlCommand sil = new SqlCommand("Delete from ogrencibilgi where OgrenciAd=@ad",baglanti);
                //sil.Parameters.AddWithValue("@ad", textBox1.Text);
                //sil.ExecuteNonQuery();
                //SqlDataAdapter adp = new SqlDataAdapter("Select * from ogrencibilgi", baglanti);
                //DataTable dt = new DataTable();
                //adp.Fill(dt);
                //dataGridView1.DataSource = dt;
                SqlCommand cmd1 = new SqlCommand("select * from ogrencibilgi", con);
                SqlDataReader rd = cmd1.ExecuteReader();
                dt.Load(rd);
                con.Close();
                return dt;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
