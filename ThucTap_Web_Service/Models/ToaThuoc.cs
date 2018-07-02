using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class ToaThuoc
    {
        public PSThuoc Toa { get; set; }
        public List<PSChiTietThuoc> Chitietthuoc { get; set; }
        public ToaThuoc()
        {

        }
        public ToaThuoc(PSThuoc toa, List<PSChiTietThuoc> chitietthuoc)
        {
            Toa = toa;
            Chitietthuoc = chitietthuoc;
        }
    }
}