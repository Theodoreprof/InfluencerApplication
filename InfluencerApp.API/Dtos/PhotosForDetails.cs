using InfluencerApp.API.Models;

namespace InfluencerApp.API.Dtos
{
    public class PhotosForDetails
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool MainPhoto { get; set; }

    }
}