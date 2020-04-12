using KJK.Data.Models;

namespace KJK.Server.ViewModels
{
	public class BaseViewModel<T> where T : BaseModel
	{
		internal T Model { get; set; }

		public BaseViewModel(T model)
		{
			Model = model;
		}
	}
}
