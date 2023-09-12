using System.ComponentModel.DataAnnotations;

namespace DynaModel.Models
{
	public class Entity
	{
		[Key]
		public Guid Id { get; set; }

		public DateTime Created { get; set; } = DateTime.UtcNow;

		public DateTime Updated { get; set; } = DateTime.UtcNow;
	}
}
