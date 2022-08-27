using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//gönderilen ıvalidator değilse
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//çalışma anında o validator type ın (carvalidator gibi) bir instancenı olustur bu bir reflection.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//basetype = abstractvalidator,,o validatorun çalışma tipini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);// validatorun tipine eşit olan parametreleri bul 
            foreach (var entity in entities) //paramaetlerin hepsini gez
            {
                ValidationTool.Validate(validator, entity); //validaiton tool ile validate et
            }
        }
    }
}
