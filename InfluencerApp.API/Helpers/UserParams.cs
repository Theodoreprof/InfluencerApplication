namespace InfluencerApp.API.Helpers
{
    public class UserParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 25;
        public int PageSize
        {
            get { return pageSize = 25; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value ; }
        }

        public int UserId { get; set; }
        public string InfluencerOrBrand { get; set; }
        public bool Likees { get; set; } = false;
        public bool Likers { get; set; } = false;
        
    }
}