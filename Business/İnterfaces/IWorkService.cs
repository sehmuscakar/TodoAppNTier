

using Common.ResponseObjects;
using Dtos.Interfaces;
using Dtos.WorkDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.İnterfaces
{
    public interface IWorkService
    {
        Task<IResponse<List<WorkListDtos>>> GetAll();

        Task<IResponse<WorkCreateDto>>Create(WorkCreateDto dto);//bu IResponse validasyonlarla ilgili işerleri yürtsün dye
        Task<IResponse<IDto>> GetById<IDto>(int id);//yani ben getbyıd de Idto olarak ne verirsem bana onu getirsin 

        Task<IResponse> Remove(int id);// örnek id bulunamadı diye bi hata olursa IResponse onu döndürecek

        Task<IResponse<WorkUpdateDto>>Update(WorkUpdateDto dto);




    }
}
