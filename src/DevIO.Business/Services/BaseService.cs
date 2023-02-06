﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIO.Business.Models;
using FluentValidation;
using FluentValidation.Results;
namespace DevIO.Business.Services
{
    public abstract class BaseService
    {
        protected void Notificar(string mensagem)
        {

        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected bool ExecutarValidacao<TV,TE>(TV validacao,TE entidade) where TV : AbstractValidator<TE> where TE: Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }
    }
}
