namespace DemoConsole
{
	public interface IApiClient
	{
		void CallApi();
	}

	public sealed class RealApiClient : IApiClient
	{
		public void CallApi()
		{
			Console.WriteLine("Success");
		}
	}
}
