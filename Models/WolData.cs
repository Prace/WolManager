using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WolManagerApp.Models
{
	public class WolData
	{
		public int Id { get; set; }

		[Required]
		public string ComputerName { get; set; }

		[Required]
		public string MACAddress { get; set; }
	}
}
