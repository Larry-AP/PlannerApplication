namespace PlannerApplication.Models
{
    public interface IEvent
    {
        string Description { get; set; }
        DateTime EndTime { get; set; }
        int Id { get; set; }
        string Location { get; set; }
        DateTime StartTime { get; set; }
        string Title { get; set; }
        User User { get; set; }
        string UserId { get; set; }
    }
}