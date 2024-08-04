﻿using IDP.Application.Command.Auth;
using IDP.Domain.IRepository.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Application.Handler.Command.Auth
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, bool>
    {
        private readonly IOtpRedisRepository _otpRedisRepository;

        public AuthCommandHandler(IOtpRedisRepository otpRedisRepository)
        {
            _otpRedisRepository = otpRedisRepository;
        }

        public async Task<bool> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            _otpRedisRepository.AddAsync(new Domain.DTO.Otp { UserId = 210, OtpCode = "2212", IsUse = false });
            return true;
        }
    }
}
