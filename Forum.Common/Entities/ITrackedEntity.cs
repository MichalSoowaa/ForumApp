namespace Forum.Common.Entities
{
	public interface ITrackedEntity
	{
		DateTime CreatedOn { get; set; }
		DateTime ModifiedOn { get; set; }
		Guid CreatedByUserId { get; set; }
		Guid ModifiedByUserId { get; set; }
	}
}
