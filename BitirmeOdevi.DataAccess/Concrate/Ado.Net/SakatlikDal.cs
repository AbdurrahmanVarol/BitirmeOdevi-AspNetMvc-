using BitirmeOdevi.DataAccess.Abstract;
using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Linq.Expressions;

namespace BitirmeOdevi.DataAccess.Concrate
{
    public class SakatlikDal : ISakatlikDal
    {
        //SqlConnection _baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["BitirmeOdevi_SqlConnection"].ConnectionString);
        //SqlCommand _komut = new SqlCommand();
        //SqlDataReader _dr;
        //public void Add(Sakatlik sakatlik)
        //{
        //    _komut.Connection = _baglanti;
        //    _komut.CommandType = CommandType.Text;

        //    if (_baglanti.State == ConnectionState.Open)
        //        _baglanti.Close();

        //    _baglanti.Open();

        //    _komut.CommandText = "insert into Sakatlik(sakatlikId,sakatlikDerece,indirim,yil) values(@sakatlikId,@sakatlikDerece,@indirim,@yil)";
        //    _komut.Parameters.AddWithValue("@sakatlikId", sakatlik.sakatlikId.ToString());
        //    _komut.Parameters.AddWithValue("@sakatlikDerece", sakatlik.sakatlikDerece);
        //    _komut.Parameters.AddWithValue("@indirim", sakatlik.indirim.ToString());
        //    _komut.Parameters.AddWithValue("@yil", sakatlik.yil.ToString());
        //    _komut.ExecuteNonQuery();
        //    _baglanti.Close();
        //}
        //public void Delete(int id)
        //{
        //    _komut.Connection = _baglanti;
        //    _komut.CommandType = CommandType.Text;

        //    if (_baglanti.State == ConnectionState.Open)
        //        _baglanti.Close();

        //    _baglanti.Open();
        //    _komut.CommandText = "delete from Sakatlik where sakatlikId=@sakatlikId";
        //    _komut.Parameters.AddWithValue("@sakatlikId", id);
        //    _komut.ExecuteNonQuery();
        //    _baglanti.Close();
        //}

        //public Sakatlik Get(string filter = null)
        //{
        //    _komut.Connection = _baglanti;
        //    _komut.CommandType = CommandType.Text;
        //    if (_baglanti.State == ConnectionState.Open)
        //        _baglanti.Close();

        //    _baglanti.Open();
        //    if (string.IsNullOrEmpty(filter))
        //        _komut.CommandText = "select*from Sakatlik";
        //    else
        //        _komut.CommandText = "select*from Sakatlik where " + filter;
        //    _dr = _komut.ExecuteReader();
        //    _dr.Read();
        //    Sakatlik sakatlik = new Sakatlik()
        //    {
        //        sakatlikId = Convert.ToInt32(_dr["sakatlikId"]),
        //        sakatlikDerece = _dr["sakatlikDerece"].ToString(),
        //        indirim = Convert.ToInt32(_dr["indirim"]),
        //        yil = Convert.ToInt32(_dr["yil"])
        //    };
        //    _baglanti.Close();
        //    _dr.Close();
        //    return sakatlik;
        //}

        //public List<Sakatlik> GetAll(string filter = null)
        //{
        //    List<Sakatlik> sakatliks = new List<Sakatlik>();
        //    _komut.Connection = _baglanti;
        //    _komut.CommandType = CommandType.Text;
        //    if (_baglanti.State == ConnectionState.Open)
        //        _baglanti.Close();

        //    _baglanti.Open();
        //    if (string.IsNullOrEmpty(filter))
        //        _komut.CommandText = "select * from Sakatlik";
        //    else
        //        _komut.CommandText = "select * from Sakatlik where " + filter;
        //    _dr = _komut.ExecuteReader();
        //    while (_dr.Read())
        //    {
        //        Sakatlik sakatlik = new Sakatlik()
        //        {
        //            sakatlikId = Convert.ToInt32(_dr["sakatlikId"]),
        //            sakatlikDerece = _dr["sakatlikDerece"].ToString(),
        //            indirim = Convert.ToInt32(_dr["indirim"]),
        //            yil = Convert.ToInt32(_dr["yil"])
        //        };
        //        sakatliks.Add(sakatlik);
        //    }
        //    _baglanti.Close();
        //    _dr.Close();
        //    return sakatliks;
        //}

        //public void Update(Sakatlik sakatlik)
        //{
        //    _komut.Connection = _baglanti;
        //    _komut.CommandType = CommandType.Text;
        //    if (_baglanti.State == ConnectionState.Open)
        //        _baglanti.Close();

        //    _baglanti.Open();
        //    _komut.CommandText = "Update Sakatlik Set sakatlikDerece=@sakatlikDerece,indirim=@indirim,yil=@yil where sakatlikId=@sakatlikId ";
        //    _komut.Parameters.AddWithValue("@sakatlikId", sakatlik.sakatlikId.ToString());
        //    _komut.Parameters.AddWithValue("@sakatlikDerece", sakatlik.sakatlikDerece);
        //    _komut.Parameters.AddWithValue("@indirim", sakatlik.indirim.ToString());
        //    _komut.Parameters.AddWithValue("@yil", sakatlik.yil.ToString());
        //    _komut.ExecuteNonQuery();
        //    _baglanti.Close();
        //}
        public void Add(Sakatlik entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Sakatlik entity)
        {
            throw new NotImplementedException();
        }

        public Sakatlik Get(Expression<Func<Sakatlik, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Sakatlik> GetAll(Expression<Func<Sakatlik, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Sakatlik entity)
        {
            throw new NotImplementedException();
        }
    }
}
