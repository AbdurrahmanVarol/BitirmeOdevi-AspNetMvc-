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
    public class AgiDal:IAgiDal
    {
        SqlConnection _baglanti = new SqlConnection("Data Source=DESKTOP-OTMDOAG\\SQLEXPRESS;Initial Catalog=BitirmeOdevi;Integrated Security=True");
        SqlCommand _komut = new SqlCommand();
        SqlDataReader _dr;
        public void Add(Agi agi)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;

            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();

            _komut.CommandText = "insert into Agi(agiId,medeniDurum,cocukSayisi,agiMiktari,yil) values(@agiId,@medeniDurum,@cocukSayisi,@agiMiktari,@yil)";
            _komut.Parameters.AddWithValue("@agiId", agi.agiId.ToString());
            _komut.Parameters.AddWithValue("@medeniDurum", agi.medeniDurum);
            _komut.Parameters.AddWithValue("@cocukSayisi", agi.cocukSayisi.ToString());
            _komut.Parameters.AddWithValue("@agiMiktari", agi.agiMiktari.ToString());
            _komut.Parameters.AddWithValue("@yil", agi.yil.ToString());
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
            _komut.CommandText = "delete from Agi where kisiId=@kisiId";
            _komut.Parameters.AddWithValue("@kisiId", id);
            _komut.ExecuteNonQuery();
            _baglanti.Close();
        }

        public Agi Get(string filter = null)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            if (string.IsNullOrEmpty(filter))
                _komut.CommandText = "select*from Agi";
            else
                _komut.CommandText = "select*from Agi where " + filter;
            _dr = _komut.ExecuteReader();
            _dr.Read();
            Agi agi = new Agi()
            {
               agiId = Convert.ToInt32(_dr["agiId"]),
                medeniDurum = _dr["medeniDurum"].ToString(),
                cocukSayisi = Convert.ToInt32(_dr["cocukSayisi"]),
                agiMiktari = Convert.ToDouble(_dr["agiMiktari"]),
                yil = Convert.ToInt32(_dr["yil"])
            };
            _baglanti.Close();
            _dr.Close();
            return agi;
        }

        public List<Agi> GetAll(string filter = null)
        {
            List<Agi> agis = new List<Agi>();
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            if (string.IsNullOrEmpty(filter))
                _komut.CommandText = "select * from Agi";
            else
                _komut.CommandText = "select * from Agi where " + filter;
            _dr = _komut.ExecuteReader();
            while (_dr.Read())
            {
                Agi agi = new Agi()
                {
                    agiId = Convert.ToInt32(_dr["agiId"]),
                    medeniDurum = _dr["medeniDurum"].ToString(),
                    cocukSayisi = Convert.ToInt32(_dr["cocukSayisi"]),
                    agiMiktari = Convert.ToDouble(_dr["agiMiktari"]),
                    yil = Convert.ToInt32(_dr["yil"])
                };
                agis.Add(agi);
            }
            _baglanti.Close();
            _dr.Close();
            return agis;
        }

        public void Update(Agi agi)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            _komut.CommandText = "Update Agi Set medeniDurum=@medeniDurum,cocukSayisi=@cocukSayisi,agiMiktari=@agiMiktari,yil=@yil where agiId=@agiId";
            _komut.Parameters.AddWithValue("@agiId", agi.agiId.ToString());
            _komut.Parameters.AddWithValue("@medeniDurum", agi.medeniDurum);
            _komut.Parameters.AddWithValue("@cocukSayisi", agi.cocukSayisi.ToString());
            _komut.Parameters.AddWithValue("@agiMiktari", agi.agiMiktari.ToString());
            _komut.Parameters.AddWithValue("@yil", agi.yil.ToString());
            _komut.ExecuteNonQuery();
            _baglanti.Close();
        }
    }
}
