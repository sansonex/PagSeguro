using System;
using System.Collections.Generic;
using System.Net;
using Uol.PagSeguro.Models;

namespace Uol.PagSeguro.Exceptions
{
	public class PagSeguroException : Exception
	{
		public PagSeguroException(HttpStatusCode statusCode, List<Error> errors)
		{
			StatusCode = statusCode;
			Errors = errors;
		}

		public List<Error> Errors { get; set; }
		public HttpStatusCode StatusCode { get; }
	}
}