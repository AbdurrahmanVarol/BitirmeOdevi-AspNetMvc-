using BitirmeOdevi.DataAccess.Abstract;
using BitirmeOdevi.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.DataAccess.Concrate
{
    public class KullaniciDal : IKullaniciDal
    {
        SqlConnection _baglanti = new SqlConnection("Data Source=DESKTOP-OTMDOAG\\SQLEXPRESS;Initial Catalog=BitirmeOdevi;Integrated Security=True");
        SqlCommand _komut = new SqlCommand();
        SqlDataReader _dr;
        public void Add(Kullanici kullanici)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;

            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();

            _komut.CommandText = "insert into Kullanici(ad,soyad,kullaniciAd,sifre,email,yetkiId) values(@ad,@soyad,@kullaniciAd,@sifre,@email,@yetkiId)";
            _komut.Parameters.AddWithValue("@ad", kullanici.ad);
            _komut.Parameters.AddWithValue("@soyad", kullanici.soyad);
            _komut.Parameters.AddWithValue("@kullaniciAd", kullanici.kullaniciAd);
            _komut.Parameters.AddWithValue("@sifre", kullanici.sifre);
            _komut.Parameters.AddWithValue("@email", kullanici.email);
            _komut.Parameters.AddWithValue("@yetkiId", kullanici.yetkiId.ToString());
            _komut.ExecuteNonQuery();
            _baglanti.Close();
        }

        public void Delete(int id)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;

            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            _komut.CommandText = "delete from Kullanici where id=@id";
            _komut.Parameters.AddWithValue("@id", id);
            _komut.ExecuteNonQuery();
            _baglanti.Close();
        }

        public Kullanici Get(string filter = null)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            if (string.IsNullOrEmpty(filter))
                _komut.CommandText = "select*from Kullanici";
            else
                _komut.CommandText = "select * from Kullanici where " + filter;
            _dr = _komut.ExecuteReader();
            Kullanici kullanici = new Kullanici();
            if (_dr.Read())
            {
                kullanici.id = Convert.ToInt32(_dr["id"]);
                kullanici.ad = _dr["ad"].ToString();
                kullanici.soyad = _dr["soyad"].ToString();
                kullanici.kullaniciAd = _dr["kullaniciAd"].ToString();
                kullanici.sifre = _dr["sifre"].ToString();
                kullanici.email = _dr["email"].ToString();
                kullanici.yetkiId = Convert.ToInt32(_dr["yetkiId"]);
            }            
            _baglanti.Close();
            _dr.Close();
            return kullanici;
        }

        public List<Kullanici> GetAll(string filter = null)
        {
            List<Kullanici> kullanicis = new List<Kullanici>();
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            if (string.IsNullOrEmpty(filter))
                _komut.CommandText = "select*from Kullanici";
            else
                _komut.CommandText = "select*from Kullanici where " + filter;
            _dr = _komut.ExecuteReader();
            while (_dr.Read())
            {
                Kullanici kullanici = new Kullanici
                {
                    id = Convert.ToInt32(_dr["id"]),
                    ad = _dr["ad"].ToString(),
                    soyad = _dr["soyad"].ToString(),
                    kullaniciAd = _dr["kullaniciAd"].ToString(),
                    sifre = _dr["sifre"].ToString(),
                    email = _dr["email"].ToString(),
                    yetkiId = Convert.ToInt32(_dr["yetkiId"])
                };
                kullanicis.Add(kullanici);
            }
            _baglanti.Close();
            _dr.Close();
            return kullanicis;
        }

        public void Update(Kullanici kullanici)
        {
            List<Kullanici> kullanicis = new List<Kullanici>();
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            _komut.CommandText = "Update Kullanici Set ad=@ad,soyad=@soyad,kullaniciAd=@kullaniciAd,sifre=@sifre,email=@email,yetkiId=@yetkiId where id=@id)";
            _komut.Parameters.AddWithValue("@id", kullanici.id);
            _komut.Parameters.AddWithValue("@ad", kullanici.ad);
            _komut.Parameters.AddWithValue("@soyad", kullanici.soyad);
            _komut.Parameters.AddWithValue("@kullaniciAd", kullanici.kullaniciAd);
            _komut.Parameters.AddWithValue("@sifre", kullanici.sifre);
            _komut.Parameters.AddWithValue("@email", kullanici.email);
            _komut.Parameters.AddWithValue("@yetkiId", kullanici.yetkiId.ToString());
            _komut.ExecuteNonQuery();
            _baglanti.Close();
        }
    }
}
