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
    public class SigortaDal:ISigortaDal
    {
        SqlConnection _baglanti = new SqlConnection("Data Source=DESKTOP-OTMDOAG\\SQLEXPRESS;Initial Catalog=BitirmeOdevi;Integrated Security=True");
        SqlCommand _komut = new SqlCommand();
        SqlDataReader _dr;
        public void Add(Sigorta sigorta)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;

            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();

            _komut.CommandText = "insert into Sigorta(sigortaId,sigortaDurum,miktar,yil) values(@sigortaId,@sigortaDurum,@miktar,@yil)";
            _komut.Parameters.AddWithValue("@sigortaId", sigorta.sigortaId.ToString());
            _komut.Parameters.AddWithValue("@sigortaDurum", sigorta.sigortaDurun);
            _komut.Parameters.AddWithValue("@miktar", sigorta.miktar.ToString());
            _komut.Parameters.AddWithValue("@yil", sigorta.ToString());
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
            _komut.CommandText = "delete from Sigorta where sigortaId=@sigortaId";
            _komut.Parameters.AddWithValue("@sigortaId", id);
            _komut.ExecuteNonQuery();
            _baglanti.Close();
        }

        public Sigorta Get(string filter = null)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            if (string.IsNullOrEmpty(filter))
                _komut.CommandText = "select*from Sigorta";
            else
                _komut.CommandText = "select*from Sigorta where " + filter;
            _dr = _komut.ExecuteReader();
            _dr.Read();
            Sigorta sigorta = new Sigorta()
            {
                sigortaId = Convert.ToInt32(_dr["sigortaId"]),
                sigortaDurun = _dr["sigortaDurun"].ToString(),
                miktar = Convert.ToInt32(_dr["miktar"]),
                yil = Convert.ToInt32(_dr["yil"])
            };
            _baglanti.Close();
            _dr.Close();
            return sigorta;
        }

        public List<Sigorta> GetAll(string filter = null)
        {
            List<Sigorta> sigortas = new List<Sigorta>();
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
                Sigorta sigorta = new Sigorta()
                {
                    sigortaId = Convert.ToInt32(_dr["sigortaId"]),
                    sigortaDurun = _dr["sigortaDurun"].ToString(),
                    miktar = Convert.ToInt32(_dr["miktar"]),
                    yil = Convert.ToInt32(_dr["yil"])
                };
                sigortas.Add(sigorta);
            }
            _baglanti.Close();
            _dr.Close();
            return sigortas;
        }

        public void Update(Sigorta sigorta)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            _komut.CommandText = "Update Sigorta Set sigortaDurum=@sigortaDurum,miktar=@miktar,yil=@yil where sigortaId=@sigortaId";
            _komut.Parameters.AddWithValue("@sigortaId", sigorta.sigortaId.ToString());
            _komut.Parameters.AddWithValue("@sigortaDurum", sigorta.sigortaDurun);
            _komut.Parameters.AddWithValue("@miktar", sigorta.miktar.ToString());
            _komut.Parameters.AddWithValue("@yil", sigorta.ToString());
            _komut.ExecuteNonQuery();
            _baglanti.Close();
        }

    }
}
