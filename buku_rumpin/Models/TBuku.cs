using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace buku_rumpin.Models
{
    public class TBuku
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private string constr = "server=127.0.0.1;uid=root;pwd=;database=db_rumpin_buku";

        public TBuku()
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = constr;
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DataTable SelectAllBuku()
        {
            try
            {
                string queryString = "SELECT * FROM buku_t;";
                using (conn)
                {
                    cmd = new MySqlCommand(queryString, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public void InsertBuku(CBuku cbuku)
        {
            try
            {
                string queryString = "INSERT INTO buku_t (judul, penulis, tempat_terbit, tahun_terbit, ed_cet, bahasa, isbn_issn, uri_gambar, kategori, keterangan) VALUES (?judul, ?penulis, ?tempat_terbit, ?tahun_terbit, ?ed_cet, ?bahasa, ?isbn_issn, ?uri_gambar, ?kategori, ?keterangan);";

                using (conn)
                {
                    cmd = new MySqlCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("?judul", cbuku.Judul);
                    cmd.Parameters.AddWithValue("?penulis", cbuku.Penulis);
                    cmd.Parameters.AddWithValue("?tempat_terbit", cbuku.TempatTerbit);
                    cmd.Parameters.AddWithValue("?tahun_terbit", cbuku.TahunTerbit);
                    cmd.Parameters.AddWithValue("?ed_cet", cbuku.EdCet);
                    cmd.Parameters.AddWithValue("?bahasa", cbuku.Bahasa);
                    cmd.Parameters.AddWithValue("?isbn_issn", cbuku.IsbnIssn);
                    cmd.Parameters.AddWithValue("?uri_gambar", cbuku.UriGambar);
                    cmd.Parameters.AddWithValue("?kategori", cbuku.Kategori);
                    cmd.Parameters.AddWithValue("?keterangan", cbuku.Keterangan);
                    cmd.Parameters.AddWithValue("?id_lama", cbuku.Id_lama);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Error " + ex.Message);
            }
        }

        public void UpdateBuku(CBuku cbuku)
        {
            try
            {
                string queryString = "UPDATE buku_t SET judul = ?judul, penulis = ?penulis, tempat_terbit = ?tempat_terbit, tahun_terbit = ?tahun_terbit, ed_cet = ?ed_cet, bahasa = ?bahasa, isbn_issn = ?isbn_issn, uri_gambar = ?uri_gambar, kategori = ?kategori, keterangan = ?keterangan WHERE buku_id = ?buku_id;";

                using (conn)
                {
                    cmd = new MySqlCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("?judul", cbuku.Judul);
                    cmd.Parameters.AddWithValue("?penulis", cbuku.Penulis);
                    cmd.Parameters.AddWithValue("?tempat_terbit", cbuku.TempatTerbit);
                    cmd.Parameters.AddWithValue("?tahun_terbit", cbuku.TahunTerbit);
                    cmd.Parameters.AddWithValue("?ed_cet", cbuku.EdCet);
                    cmd.Parameters.AddWithValue("?bahasa", cbuku.Bahasa);
                    cmd.Parameters.AddWithValue("?isbn_issn", cbuku.IsbnIssn);
                    cmd.Parameters.AddWithValue("?uri_gambar", cbuku.UriGambar);
                    cmd.Parameters.AddWithValue("?kategori", cbuku.Kategori);
                    cmd.Parameters.AddWithValue("?keterangan", cbuku.Keterangan);
                    cmd.Parameters.AddWithValue("?buku_id", cbuku.Buku_id);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Error " + ex.Message);
            }
        }
    }
}
