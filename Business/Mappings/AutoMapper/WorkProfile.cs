using AutoMapper;
using Dtos.WorkDtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappings.AutoMapper
{
	public class WorkProfile:Profile
	{
		public WorkProfile()
		{
			CreateMap<Work, WorkListDtos>().ReverseMap();//work u worklistdtos a cevir
			CreateMap<Work, WorkCreateDto>().ReverseMap();// work u workcreatedto a cevir
			CreateMap<Work, WorkUpdateDto>().ReverseMap();// work u workupdatedto a cevir
			CreateMap<WorkListDtos, WorkUpdateDto>().ReverseMap(); // worklistdtos u workupdatedto a cevir

		}
	}
}
