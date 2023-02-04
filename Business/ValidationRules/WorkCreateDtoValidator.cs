using Dtos.WorkDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
	public class WorkCreateDtoValidator:AbstractValidator<WorkCreateDto>//niçin yazdık WorkCreateDto için yazdık
	{

		public WorkCreateDtoValidator()
		{
			RuleFor(x => x.Definition).NotEmpty();
		}

		//ctor kısacası yaz otomatik gelir taba bas 
		//public WorkCreateDtoValidator()
		//{
		//	//property için kural :	RuleFor 
		//	RuleFor(x => x.Definition).NotEmpty().WithMessage("Defination is required").When(x=>x.IsCompleted).Must(NotBeYavuz).WithMessage("Defination şehmus,Şehmus olamaz");
		//	//Must(NotBeYavuz); biz burda must ile NotBeYavuz metodunu oluşturduk
		//	//When(x=>x.IsCompleted) buda iscomleted true iken defination boş olamaz o anlamada yoksa Defination is required bu uyarıyı verir 
		//}

		//private bool NotBeYavuz(string arg)
		//{
		//	return arg != "Şehmus" && arg != "şehmus"; // eğer şehmus ve Şehmus olarak girilirse Defination şehmus,Şehmus olamaz bu uyarıyı verir
		//}
	}
}
