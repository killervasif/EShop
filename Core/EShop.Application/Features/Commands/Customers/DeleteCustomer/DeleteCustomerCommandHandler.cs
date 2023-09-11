﻿using EShop.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerReadRepository.GetAsync(request.Id);
            if (customer is not null)
            {
                _unitOfWork.CustomerWriteRepository.Remove(customer);
                await _unitOfWork.CustomerWriteRepository.SaveChangesAsync();
                return new() { Result = true };
            }
            return new() { Result = false };
        }
    }
}
