namespace AppUI.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int EId { get; set; } 
        public string Title { get; set; }
        public int SId { get; set; } 
        public string Desc { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Url { get; set; }
    }
}
