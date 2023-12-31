﻿using DotnetYuzuncuYil.Core.DTOs;
using DotnetYuzuncuYil.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYil.Service.Validations
{
    public class UserProfileValidator : AbstractValidator<UserProfileDto>
    {
        public UserProfileValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Kullanıcının adı boş geçilemez.")
                .NotNull().WithMessage("Kullanıcının adı null olamaz.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Kullanıcının soyadı boş geçilemez.")
                .NotNull().WithMessage("Kullanıcının soyadı null olamaz.");
        }
    }
}
