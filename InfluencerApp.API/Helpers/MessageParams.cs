namespace InfluencerApp.API.Helpers
{
    public class MessageParams
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
        public string MessageContainer { get; set; } = "Unread";
    }
}