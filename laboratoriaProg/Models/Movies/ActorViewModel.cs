namespace laboratoriaProg.Models.ViewModels
{
    public class ActorViewModel
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int MovieCount { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}