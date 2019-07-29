namespace InfluencerApp.API.Helpers
{
    public class UserParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize = 10; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value ; }
        }
        
    }
}