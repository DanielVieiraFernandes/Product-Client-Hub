﻿using ProductsClientHub.API.Entities;
using ProductsClientHub.API.Infra;
using ProductsClientHub.API.UseCases.Clients.SharedValidator;
using ProductsClientHub.Communication.Requests;
using ProductsClientHub.Communication.Responses;
using ProductsClientHub.Exceptions.ExceptionsBase;

namespace ProductsClientHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseShortClientJson Execute(RequestClientJson request)
    {
        Validate(request);

        var dbContext = new ProductsClientsHubDbContext();

        var entity = new Client()
        {
            Name = request.Name,
            Email = request.Email,
        };

        dbContext.Clients.Add(entity);

        dbContext.SaveChanges();

        return new ResponseShortClientJson()
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

    private void Validate(RequestClientJson request)
    {
        var validator = new RequestClientValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
