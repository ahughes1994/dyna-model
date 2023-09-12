namespace DynaModel.Models
{
	public class Parent : Entity
	{
		public string Name { get; set; }

		public string? Description { get; set; }
		
		public List<IntProperty> IntProperties { get; set; } = new List<IntProperty>();

		public List<StringProperty> StringProperties { get; set;} = new List<StringProperty>();

		public List<BoolProperty> BoolProperties { get; set; } = new List<BoolProperty>();

		public List<FloatProperty> FloatProperties { get; set; } = new List<FloatProperty>();
	}
}
