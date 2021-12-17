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
    public class VergiDilimiDal:IVergiDilimiDal
    {
        SqlConnection _baglanti = new SqlConnection("Data Source=DESKTOP-OTMDOAG\\SQLEXPRESS;Initial Catalog=BitirmeOdevi;Integrated Security=True");
        SqlCommand _komut = new SqlCommand();
        SqlDataReader _dr;
        public void Add(VergiDilimi vergiDilimi)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;

            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();

            _komut.CommandText = "insert into VergiDilimi (minMaas,maxMaas,vergiDilimi) values(@minMaas,@maxMaas,@vergiDilimi)";
            _komut.Parameters.AddWithValue("@minMaas", vergiDilimi.minMaas);
            _komut.Parameters.AddWithValue("@maxMaas", vergiDilimi.maxMaas);
            _komut.Parameters.AddWithValue("@vergiDilimi", vergiDilimi.vergiDilimi);
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
            _komut.CommandText = "delete from VergiDilimi where id=@id";
            _komut.Parameters.AddWithValue("@id", id);
            _komut.ExecuteNonQuery();
            _baglanti.Close();
        }

        public VergiDilimi Get(string filter = null)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            if (string.IsNullOrEmpty(filter))
                _komut.CommandText = "select*from VergiDilimi";
            else
                _komut.CommandText = "select * from VergiDilimi where " + filter;
            _dr = _komut.ExecuteReader();
            _dr.Read();
            VergiDilimi vergiDilimi = new VergiDilimi()
            {
                id = Convert.ToInt32(_dr["id"]),
                minMaas = Convert.ToDouble(_dr["minMaas"]),
                maxMaas = Convert.ToDouble(_dr["maxMaas"]),
                vergiDilimi = Convert.ToDouble(_dr["vergiDilimi"])
            };
            _baglanti.Close();
            _dr.Close();
            return vergiDilimi;
        }

        public List<VergiDilimi> GetAll(string filter = null)
        {
            List<VergiDilimi> vergiDilimis = new List<VergiDilimi>();
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            if (string.IsNullOrEmpty(filter))
                _komut.CommandText = "select*from VergiDilimi";
            else
                _komut.CommandText = "select*from VergiDilimi where " + filter;
            _dr = _komut.ExecuteReader();
            while (_dr.Read())
            {
                VergiDilimi vergiDilimi = new VergiDilimi()
                {
                    id = Convert.ToInt32(_dr["id"]),
                    minMaas = Convert.ToDouble(_dr["minMaasad"]),
                    maxMaas = Convert.ToDouble(_dr["maxMaas"]),
                    vergiDilimi = Convert.ToDouble(_dr["vergiDilimi"])
                };
                vergiDilimis.Add(vergiDilimi);
            }
            _baglanti.Close();
            _dr.Close();
            return vergiDilimis;
        }

        public void Update(VergiDilimi vergiDilimi)
        {
            _komut.Connection = _baglanti;
            _komut.CommandType = CommandType.Text;
            if (_baglanti.State == ConnectionState.Open)
                _baglanti.Close();

            _baglanti.Open();
            _komut.CommandText = "Update VergiDilimi Set minMaas=@minMaas,maxMaas=@maxMaas,vergiDilimi=@vergiDilimi where id=@id)";
            _komut.Parameters.AddWithValue("@id", vergiDilimi.id);
            _komut.Parameters.AddWithValue("@minMaas", vergiDilimi.minMaas);
            _komut.Parameters.AddWithValue("@maxMaas", vergiDilimi.maxMaas);
            _komut.Parameters.AddWithValue("@vergiDilimi", vergiDilimi.vergiDilimi);
            _baglanti.Close();
        }
    }
}
