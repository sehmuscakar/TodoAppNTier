using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Business.Extensions;
using Business.İnterfaces;
using Business.ValidationRules;
using Common.ResponseObjects;
using DataAccess.UnitofWork;
using Dtos.Interfaces;
using Dtos.WorkDtos;
using Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   

    //manager de olabilir ismi 
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;//bunu ctrl+. ile add paremteres ile eklyebkirisn constractıra
		private readonly IValidator<WorkCreateDto> _createDtoValidator; // new lemeye gerek kalmadı artık 
		private readonly IValidator<WorkUpdateDto> _updateDtoValidator;

		public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator, IValidator<WorkUpdateDto> updateDtoValidator)
		{
			_uow = uow;
			_mapper = mapper;
			_createDtoValidator = createDtoValidator;
			_updateDtoValidator = updateDtoValidator;
		}

		public  async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {

		
			var validationResult = _createDtoValidator.Validate(dto);
			if (validationResult.IsValid)
			{
				await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));//burda oluşturacahım creatı worke cevirmek istiyorum neyi work e cevirecem dto yu 
				await _uow.SaveChanges();
				return new Response<WorkCreateDto>(ResponseType.Success, dto);
			}
			else
			{
				
				return new Response<WorkCreateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());//biz burda ConvertToCustomValidationError 

			}


			
		}

        public async Task<IResponse<List<WorkListDtos>>> GetAll()
        {
			

			var data= _mapper.Map<List<WorkListDtos>>(await _uow.GetRepository<Work>().GetAll());//List Şeklinde döndür neyi WorkListDtos neyin (await _uow.GetRepository<Work>().GetAll()); bunun
			return new Response<List<WorkListDtos>>(ResponseType.Success, data);
		}

        public  async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
			var data= _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));

			if (data == null)
			{
				return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
			}
			return new Response<IDto>(ResponseType.Success,data);
			
		}

        

        public async  Task<IResponse> Remove(int id)
        {
			var removeEntity = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);
			if (removeEntity != null)
			{
				_uow.GetRepository<Work>().Remove(removeEntity);
				await _uow.SaveChanges();
				return new Response(ResponseType.Success);
			}
			return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
		}

        public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {
			var result = _updateDtoValidator.Validate(dto);
			if (result.IsValid)
			{
				var updatedEntity = await _uow.GetRepository<Work>().Find(dto.Id);
				if (updatedEntity != null)
				{
					_uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto),updatedEntity);
					await _uow.SaveChanges();
					return new Response<WorkUpdateDto>(ResponseType.Success, dto);
				}
				return new Response<WorkUpdateDto>(ResponseType.NotFound, $"{dto.Id} ye ait data bulunamadı");
			}
			else
			{
				return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto,result.ConvertToCustomValidationError());
			}
		}
      }
   }

