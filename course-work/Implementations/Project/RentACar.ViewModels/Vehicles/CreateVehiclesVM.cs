﻿using System;
using RentACar.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentACar.ViewModels.Vehicles
{
	public class CreateVehiclesVM
	{
		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
		[Display(Name = "Brand")]
		public string Brand { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
		[Display(Name = "Model")]
		public string Model { get; set; }
		[Required]
		[DataType(DataType.Date)]
		[YearAfter1886Validation]
		[Display(Name = "Year")]
		public DateTime Year { get; set; }
		[Required]
		[Range(1, 12)]
		[Display(Name = "Passenger Seats")]
		public int PassengerSeats { get; set; }
		[MaxLength(255)]
		public string Description { get; set; }
		[Required]
		[Range(30, 100000)]
		[Display(Name = "Price per day")]
		public decimal PricePerDay { get; set; }
		public string Url { get; set; }
		[BindProperty]
		public IFormFile Picture { get; set; }

		public Guid VehicleTypeId { get; set; }
		public IEnumerable<SelectListItem> VehicleTypes { get; set; }
	}
}
