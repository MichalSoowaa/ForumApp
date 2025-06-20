using System.ComponentModel.DataAnnotations;

namespace Forum.Common.Entities
{
	public abstract class BaseEntity
	{
		[Key] public long Id { get; set; }
	}
}
