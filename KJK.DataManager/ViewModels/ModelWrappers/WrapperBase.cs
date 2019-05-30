namespace KJK.DataManager.ViewModels.ModelWrappers {

	public class WrapperBase<T>:ViewModelBase {
		#region Fields,Properties,Events ##############################################################

		public T Model { get; protected set; }

		#endregion

		#region Methods, Tasks, commands ##############################################################

		public virtual void Presist() { }

		public virtual void Reset() { }

		#endregion

		#region Ctors #################################################################################

		

		#endregion
	}//clss

}//ns
