
##  PagSeguro .NET API

.NET Core Project that consume PagSeguro API that support ILogger and use IHttpClientFactory

## Motivation

This project was created to consume a specific PagSeguro Api that can create "Boleto" with specific due date D+1 configuration.

## Features

- Create "Boleto" with a D+1 due date. 

##  Informations
#### Built with:
 .NET Core 3.1

## Install
Install package using .NET CLI:
` dotnet add package Sansone.Uol.PagSeguro `

## Setup
Create a new PagSeguroSettings as follow and pass it to Extension Method from IServiceCollection ``` AddPagSeguro```

``` c# 
services.AddPagSeguro(new PagSeguroSettings()
			 {
				  BoletoRequestUrl = "https://ws.pagseguro.uol.com.br/recurring-payment/boletos",
				  Email = "email@gmail.com",
				  Token = "<TOKEN PAGSEGURO>"
			});
 ```

## How to Use

 -  Inject IPagSeguroBoletoService in your service.
``` c# 
IPagSeguroBoletoService boletoService
```

 -  Pass a new PagSeguroBoletoRequest.
``` c#

var response = await _boletoService.CreateBoletoAsync(new PagSeguroBoletoRequest()
				{
					Reference = "123456789",
					FirstDueDate = "2020-10-30",
					Amount = 5,
					Periodicity = "monthly",
					Instructions = "Teste",
					NumberOfPayments = "1",
					Address = new PagSeguroAddress()
					{
						City = "2",
						District = "3",
						Number = "2",
						PostalCode = "3",
						State = "2",
						Street = "1"
					},
					Customer = new PagSeguroCustomer()
					{
						Email = "teste@123.com",
						Document = new PagSeguroDocument() { Type = "CPF", Value = "00000000000" },
						Name = "Lucas",
						Phone = new PagSeguroPhone() { Number = "23123456789", AreaCode = "1234567890" }
					},
					Description = "Description"
				});

````

 -  If the request fails, it throws a new PagSeguro Exception with a list of errors from PagSeguro.
``` c#
public class PagSeguroException : Exception
	{
		public PagSeguroException(HttpStatusCode statusCode, List<Error> errors);

		public List<Error> Errors { get; set; }
		public HttpStatusCode StatusCode { get; }
	}
 
 public class Error
	{
		public Error();

		public int Code { get; set; }
		public string Message { get; set; }
	}
 
```
