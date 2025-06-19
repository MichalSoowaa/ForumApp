using System.ComponentModel.DataAnnotations;

namespace Forum.Common.Entities
{
	public abstract class BaseEntity : ITrackedEntity
	{
		[Key] public long Id { get; set; }

		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public Guid CreatedByUserId { get; set; }
		public Guid ModifiedByUserId { get; set; }
	}
}
