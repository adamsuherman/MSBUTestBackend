namespace MSBUTestBackend.Helper
{
    public class Result
    {
        public string RESULT_CODE { get; set; }
        public string RESULT_MESSAGE { get; set;}
        public object DATA { get; set; }
    }

    public class TrBpkbObjectRequest
    {
        public string bpkb_no { get; set; }
        public string branch_id { get; set; }
        public string bpkb_date { get; set; }
        public string faktur_no { get; set; }
        public string faktur_date { get; set; }
        public string location_id { get; set; }
        public string police_no { get; set; }
        public string bpkb_date_in { get; set; }
    }
}
