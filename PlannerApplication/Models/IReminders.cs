namespace PlannerApplication.Models
{
    public interface IReminders
    {
        DateTime Date { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        string Title { get; set; }
    }
}