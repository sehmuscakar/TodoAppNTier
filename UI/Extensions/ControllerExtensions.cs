using Common.ResponseObjects;
using Microsoft.AspNetCore.Mvc;

namespace UI.Extensions
{
	public static class ControllerExtensions //biz burda contoller ı genişletik  
	{
		//listeleme ve creat,güncelleme,remove işe göre kullanacan aslında 
		public static IActionResult ResponseRedirectToAction<T>(this Controller controller,IResponse<T> response,string actionName)//eger T verirsen Normal metotdu T vermen lazım generic yapıyorsun,eğer başarılı ise string actionName bunu döndürür
		{
			if (response.ResponseType == ResponseType.NotFound)
			{
				return controller.NotFound();
			}
			if (response.ResponseType == ResponseType.ValidationError)
			{
				foreach(var error in response.ValidationErrors)
				{
					controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
				}
				return controller.View(response.Data);
			}

			return controller.RedirectToAction(actionName);
		}

		//güncelleme
		public static IActionResult ResponseView<T>(this Controller controller,IResponse<T> response)
		{
			if (response.ResponseType == ResponseType.NotFound)
			{
				return controller.NotFound();
			}
			return controller.View(response.Data);
		}
		//remove
		public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName)
		{
			if (response.ResponseType == ResponseType.NotFound)
			{
				return controller.NotFound();
			}
			return controller.RedirectToAction(actionName);
		}
	}
}
