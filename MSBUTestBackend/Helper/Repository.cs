using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace MSBUTestBackend.Helper
{
    public class Repository
    {
        public IConfiguration Configuration { get; set; }
        Configuration config;

        public Repository(IConfiguration configuration)
        {
            Configuration = configuration;
            config = new Configuration(configuration);
        }

        public string GetLocation()
        {
            Result res = new Result();
            string Result = string.Empty;
            try
            {
                string query = QUERY.SELECT_LOCATION;

                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(config.getConnectionString());
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    res.RESULT_CODE = "00";
                    res.RESULT_MESSAGE = "SUCCESS";
                    res.DATA = dt;
                }
            }
            catch(Exception ex)
            {
                res.RESULT_CODE = "99";
                res.RESULT_MESSAGE = ex.Message.ToString();
                res.DATA = null;
            }

            Result = JsonConvert.SerializeObject(res);
            return Result;
            
        }
        public string SaveTrBpkb(TrBpkbObjectRequest objReq)
        {
            Result res = new Result();
            DataTable dt = new DataTable();
            string agreement_number = string.Empty;
            string _result = string.Empty;
            try
            {
                string query = QUERY.INSERT_TRBPKB;
                string CheckId = QUERY.CHECKID;

                SqlConnection conn = new SqlConnection(config.getConnectionString());
                SqlCommand cmd = new SqlCommand(CheckId, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                if (dt.Rows.Count <= 0)
                    agreement_number = "TR001";
                else
                {
                    string NoAwal = dt.Rows[0][0].ToString();
                    int _NoAwal = Convert.ToInt32(NoAwal.Replace("TR", ""));
                    string NoBaru = Convert.ToString(_NoAwal + 1);
                    if (NoBaru.Length == 1)
                        NoBaru = "TR00" + NoBaru;
                    else if (NoBaru.Length == 2)
                        NoBaru = "TR0" + NoBaru;
                    else
                        NoBaru = "TR" + NoBaru;

                    agreement_number = NoBaru;
                }

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@agreement_number", agreement_number);
                cmd.Parameters.AddWithValue("@bpkb_no", objReq.bpkb_no);
                cmd.Parameters.AddWithValue("@branch_id", objReq.branch_id);
                cmd.Parameters.AddWithValue("@bpkb_date", objReq.bpkb_date);
                cmd.Parameters.AddWithValue("@faktur_no", objReq.faktur_no);
                cmd.Parameters.AddWithValue("@faktur_date", objReq.faktur_date);
                cmd.Parameters.AddWithValue("@location_id", objReq.location_id);
                cmd.Parameters.AddWithValue("@police_no", objReq.police_no);
                cmd.Parameters.AddWithValue("@bpkb_date_in", objReq.bpkb_date_in);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if(i == 1)
                {
                    res.RESULT_CODE = "00";
                    res.RESULT_MESSAGE = "SAVE SUCCESS";
                    res.DATA = null;
                }
                else
                {
                    res.RESULT_CODE = "99";
                    res.RESULT_MESSAGE = "SAVE FAILED";
                    res.DATA = null;
                }
            }
            catch(Exception ex)
            {
                res.RESULT_CODE = "99";
                res.RESULT_MESSAGE = ex.Message.ToString();
                res.DATA = null;
            }

            _result = JsonConvert.SerializeObject(res);
            return _result;
        }
    }
}
