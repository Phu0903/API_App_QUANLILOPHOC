using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XamarinWebApi.Models
{
    public class Thongbao
    {
        public int Id_thongbao { get; set; }
        public string Tieude { get; set; }
        public string Noidung { get; set; }
        public DateTime Time {get;set;}
    }
}