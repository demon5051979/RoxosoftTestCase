﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roxosoft.Models
{
	public class OrderStatus
	{
		[Key]
		public long Id { get; set; }
		public string Name { get; set; }
	}
}
