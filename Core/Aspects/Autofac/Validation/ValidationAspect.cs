﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect'imiz - Methodun başında,
        //sonunda, hata verdiğinde çalışacak method
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding 

            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;
        }

        //invocation = method demek

        //Doğrulama class olduğu için onbefore u ezdik sadece
        protected override void OnBefore(IInvocation invocation)
        {
            //çalışma anında instance oluşturmak istersek activator ile yaparız
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
