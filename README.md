
##  PagSeguro .NET API

.NET Core Project that consume PagSeguro API that support ILogger and use IHttpClientFactory

## Motivation

This project was created to consume a specific PagSeguro Api in a .NET Core Project. That API can create "Boleto" with specific due date D+1 configuration.

## Features

- Create "Boleto" with a D+1 due date. 

##  Informations
#### Built with:
 .NET Core 3.1

## Install
Install package using .NET CLI:
` dotnet add package Sansone.Uol.PagSeguro `

## Setup
Create a new PagSeguroSettings as follow and pass it to ExtensionMethod from IServiceCollection ``AddPagSeguro``

![settings](https://user-images.githubusercontent.com/22122007/86544835-a6f1ef80-bf00-11ea-9f56-26d893f4b1b8.png)

## How to Use

 -  Inject IPagSeguroBoletoService in your service.
![image](https://user-images.githubusercontent.com/22122007/86545634-78771300-bf06-11ea-99bb-95c25d2116a4.png)

 -  Pass a new PagSeguroBoletoRequest.
![image](https://user-images.githubusercontent.com/22122007/86545652-9a709580-bf06-11ea-89e3-42721f91e7d3.png)

 -  If the request fails, it throws a new PagSeguro Exception with a list of errors from PagSeguro.
![image](https://user-images.githubusercontent.com/22122007/86545704-ec192000-bf06-11ea-9a80-b000ff1a9c80.png)
