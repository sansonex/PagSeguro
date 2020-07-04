using System;
using System.Collections.Generic;
using System.Net;

namespace Uol.PagSeguro.Exceptions
{
	public class PagSeguroException : Exception
	{
		public HttpStatusCode StatusCode { get; }

		public List<Error> Errors { get; set; }

		public PagSeguroException(HttpStatusCode statusCode, List<Error> errors)
		{
			StatusCode = statusCode;
			Errors = errors;
		}
	}
}