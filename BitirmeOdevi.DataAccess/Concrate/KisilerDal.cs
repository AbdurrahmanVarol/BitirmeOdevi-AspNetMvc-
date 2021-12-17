using BitirmeOdevi.DataAccess.Abstract;
using BitirmeOdevi.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeOdevi.DataAccess.Concrate
{
    public class KisilerDal:IKisilerDal
    {
        SqlConnection _baglanti = new SqlConnection("Data Source=DESKTOP-OTMDOAG\\SQLEXPRESS;Initial Catalog=BitirmeOdevi;Integrated Security=True");
        SqlCommand _komut = new SqlCommand();
        SqlDataReader _dr;
        public void Add(Kisiler Kisi)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;

            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();

            _komut.CommandText = "insert into Kisiler(ad,soyad,maas,kullaniciId,agiId,sakatlikId,sigortaId) values(@ad,@soyad,@maas,@kullaniciId,@agiId,@sakatlikId,@sigortaId)";
            _komut.Parameters.AddWithValue("@ad",Kisi.ad );
            _komut.Parameters.AddWithValue("@soyad", Kisi.soyad);
            _komut.Parameters.AddWithValue("@maas", Kisi.maas.ToString()) ;
            _komut.Parameters.AddWithValue("@kullaniciId", Kisi.kullaniciId.ToString());
            _komut.Parameters.AddWithValue("@agiId", Kisi.agiId.ToString());
            _komut.Parameters.AddWithValue("@sakatlikId", Kisi.sakatlikId.ToString());
            _komut.Parameters.AddWithValue("@sigortaId", Kisi.sigortaId.ToString());
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
            _komut.CommandText = "delete from Kisiler where kisiId=@kisiId";
            _komut.Parameters.AddWithValue("@kisiId", id);
            _komut.ExecuteNonQuery();
            _baglanti.Close();
        }

        public Kisiler Get(string filter = null)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            if (string.IsNullOrEmpty(filter))
                _komut.CommandText = "select*from Kisiler";
            else
                _komut.CommandText = "select*from Kisiler where " + filter;
            _dr = _komut.ExecuteReader();
            _dr.Read();
            Kisiler kisi = new Kisiler()
            {
                kisiId = Convert.ToInt32(_dr["kisiId"]),
                ad = _dr["ad"].ToString(),
                soyad = _dr["soyad"].ToString(),
                maas = Convert.ToInt32(_dr["maas"]),
                kullaniciId = Convert.ToInt32(_dr["kullaniciId"]),
                agiId = Convert.ToInt32(_dr["agiId"]),
                sakatlikId = Convert.ToInt32(_dr["sakatlikId"]),
                sigortaId = Convert.ToInt32(_dr["sigortaId"])
            };
            _baglanti.Close();
            _dr.Close();
            return kisi;
        }

        public List<Kisiler> GetAll(string filter = null)
        {
            List<Kisiler> kisilers = new List<Kisiler>();
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            if (string.IsNullOrEmpty(filter))
                _komut.CommandText = "select * from Kisiler";
            else
                _komut.CommandText = "select * from Kisiler where " + filter;
            _dr = _komut.ExecuteReader();
            while (_dr.Read())
            {
                Kisiler kisi = new Kisiler()
                {
                    kisiId = Convert.ToInt32(_dr["kisiId"]),
                    ad = _dr["ad"].ToString(),
                    soyad = _dr["soyad"].ToString(),
                    maas = Convert.ToInt32(_dr["maas"]),
                    kullaniciId = Convert.ToInt32(_dr["kullaniciId"]),
                    agiId = Convert.ToInt32(_dr["agiId"]),
                    sakatlikId = Convert.ToInt32(_dr["sakatlikId"]),
                    sigortaId = Convert.ToInt32(_dr["sigortaId"])
                };
                kisilers.Add(kisi);
            }
            _baglanti.Close();
            _dr.Close();
            return kisilers;
        }

        public void Update(Kisiler kisi)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            _komut.CommandText = "Update Kisiler Set ad=@ad,soyad=@soyad,maas=@maas,kullaniciId=@kullaniciId,agiId=@agiId,sakatlikId=@sakatlikId,sigortaId=@sigortaId where kisiId=@kisiId";
            _komut.Parameters.AddWithValue("@kisiId", kisi.kisiId);
            _komut.Parameters.AddWithValue("@ad", kisi.ad);
            _komut.Parameters.AddWithValue("@soyad", kisi.soyad);
            _komut.Parameters.AddWithValue("@maas", kisi.maas.ToString());
            _komut.Parameters.AddWithValue("@kullaniciId", kisi.kullaniciId.ToString());
            _komut.Parameters.AddWithValue("@agiId", kisi.agiId.ToString());
            _komut.Parameters.AddWithValue("@sakatlikId", kisi.sakatlikId.ToString());
            _komut.Parameters.AddWithValue("@sigortaId", kisi.sigortaId.ToString());
            _komut.ExecuteNonQuery();
            _baglanti.Close();
        }      
    }
}
