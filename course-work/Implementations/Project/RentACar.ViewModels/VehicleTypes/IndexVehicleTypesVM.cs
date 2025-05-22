namespace RentACar.ViewModels.VehicleTypes
{
	using RentACar.ViewModels.Shared;
	using System.Collections.Generic;

	public class IndexVehicleTypesVM : PagingVM
	{
		public ICollection<IndexVehicleTypeVM> VehicleTypes { get; set; }
	}
}
