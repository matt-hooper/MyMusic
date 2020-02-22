using System.ComponentModel.DataAnnotations;

namespace MyMusic.Api.Resources
{
    public class SaveMusicResource
    {
        //[Required]
        public string Name { get; set; }
        public int ArtistId { get; set; }
    }
}