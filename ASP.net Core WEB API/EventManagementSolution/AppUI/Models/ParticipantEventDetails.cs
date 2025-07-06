namespace AppUI.Models
{
    public class ParticipantEventDetails
    {
        public int ParticipantId { get; set; }
        public string ParticipantEmailId { get; set; }
        public int EventId { get; set; }
        public bool isAttended { get; set; }
    }
}
