namespace PlanningPoker.Api.Models.Story;

public class FinishedStoryDto : IBaseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double VoteValue { get; set; }
}