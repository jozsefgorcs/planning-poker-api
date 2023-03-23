namespace PlanningPoker.Api.Data;

public class Story
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public IList<Vote> Votes { get; set; }
}