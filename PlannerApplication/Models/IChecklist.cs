namespace PlannerApplication.Models
{
    public interface IChecklist
    {
        int Id { get; set; }
        List<ChecklistItem> Items { get; set; }
        string Title { get; set; }
    }
}