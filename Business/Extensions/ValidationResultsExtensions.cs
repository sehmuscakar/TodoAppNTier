using Common.ResponseObjects;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
	public static class ValidationResultsExtensions //biz bu classı genişletik
	{
		public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)//fluent validasiondaki 
		{
			List<CustomValidationError> errors = new();
			foreach (var error in validationResult.Errors)
			{
				errors.Add(new()
				{
					ErrorMessage = error.ErrorMessage,
					PropertyName = error.PropertyName
				});
			}
			return errors;
		}
	}
}
