﻿using System;

namespace Uol.PagSeguro
{
	public class PagSeguroBoletoRequest
	{
		public PagSeguroAddress Address { get; set; }

		public decimal Amount { get; set; }

		public PagSeguroCustomer Customer { get; set; }

		public string Description { get; set; }

		public DateTime FirstDueDate { get; set; }

		public string Instructions { get; set; }

		public string NumberOfPayments { get; set; }

		public string Periodicity { get; set; }

		public string Reference { get; set; }
	}
}