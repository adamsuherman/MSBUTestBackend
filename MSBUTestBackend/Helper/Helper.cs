namespace MSBUTestBackend.Helper
{
    public class Helper
    {
    }

    public class QUERY
    {
        public static string SELECT_LOCATION = "SELECT location_id, location_name FROM [dbo].[ms_storage_location]";
        public static string INSERT_TRBPKB = @"INSERT INTO dbo.tr_bpkb(
	    	[agreement_number]
          ,[bpkb_no]
          ,[branch_id]
          ,[bpkb_date]
          ,[faktur_no]
          ,[faktur_date]
          ,[location_id]
          ,[police_no]
          ,[bpkb_date_in]
            )
           SELECT @agreement_number,
            @bpkb_no,
            @branch_id,
            @bpkb_date,
            @faktur_no,
            @faktur_date,
            @location_id,
            @police_no,
            @bpkb_date_in";
        public static string CHECKID = "SELECT TOP (1) [agreement_number] FROM [MSBU].[dbo].[tr_bpkb] ORDER BY agreement_number DESC";
    }
}
