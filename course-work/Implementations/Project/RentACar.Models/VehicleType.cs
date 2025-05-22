namespace RentACar.Models
{
	using System;
	public class VehicleType
	{
		public VehicleType()
		{
			this.Id = Guid.NewGuid().ToString();
		}
		public string Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

	}
}
