using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class BLL
    {
        public DataTable GetPersons()
        {
            try
            {
                DAL.DAL objdal = new DAL.DAL();
                return objdal.Read();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetPersons(int id)
        {
            try
            {
                DAL.DAL objdal = new DAL.DAL();
                return objdal.Read(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable Kayıt(string ad, string soyad,string no,string tel)
        {
            try
            {
                DAL.DAL objdal = new DAL.DAL();
                return objdal.Kaydet(ad, soyad,no,tel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable guncel(int id,string ad,string soyad,string no)
        {
            try
            {
                DAL.DAL objdal = new DAL.DAL();
                return objdal.Güncelle(id, ad, soyad,no);
            }
            catch (Exception)
            {                
                throw;
            }
        }
        public DataTable sil(int id)
        {
            try
            {
                DAL.DAL obj = new DAL.DAL();
                return obj.sil(id);
            }
            catch (Exception)
            {

                throw;
            }
        }       
    }
}
