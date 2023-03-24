using PlanningPoker.Api.Data;

namespace PlanningPoker.Api.Models;

public class StoryDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool InProgress { get; set; }
    public bool IsEstimated { get; set; }

    public IList<VoteDto> Votes { get; set; }
}