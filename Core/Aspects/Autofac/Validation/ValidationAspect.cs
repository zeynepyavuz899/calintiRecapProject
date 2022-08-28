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
    public class ValidationAspect : MethodInterception //Validation asppect(methodun neresinde isetersek orada calışacak yapı) bir method interceptiondur
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        { //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//gönderilen ıvalidator değilse
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) //on before üstüne yazıyoruz onbefore yani methoda çalışmadan önce kullanıcaz diyoruz
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//çalışma anında o validator type ın (carvalidator gibi) bir instancenı olustur bu bir reflection. (car validator newlendi )
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//basetype = abstractvalidator generic tip alıyor(car,brand gibi),,o validatorun çalışma tipini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);// methodun argümanlarını/paramaetrelerini gez eğer ordakiler validatorun tipine eşitse foreach ile gez 
            foreach (var entity in entities) //paramaetlerin hepsini gez
            {
                ValidationTool.Validate(validator, entity); //validaiton tool ile validate et
            }
        }
    }
}
