using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPoker.Api.Data;

public class Vote
{
    public int Id { get; set; }
    public int Value { get; set; }

    
    [ForeignKey(nameof(StoryId))]
    public int StoryId { get; set; }
    public Story Story { get; set; }
}