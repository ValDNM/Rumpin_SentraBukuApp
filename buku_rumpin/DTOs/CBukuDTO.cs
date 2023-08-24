using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buku_rumpin.DTOs
{
    public class CBukuDTO
    {
        [Key]
        public Guid buku_id { get; set; }
        public string judul { get; set; }
        public string penulis { get; set; }
        public string penerbit { get; set; }
        public string tempat_terbit { get; set; }
        public int tahun_terbit { get; set; }
        public string ed_cet { get; set; }
        public string bahasa { get; set; }
        public string isbn_issn { get; set; }
        public string uri_gambar { get; set; }
        public int kategori { get; set; }
        public string keterangan { get; set; }
        public string id_lama { get; set; }

    }
}
