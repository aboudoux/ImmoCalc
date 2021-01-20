using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using BlazorState;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ImmoCalc {
	public class Program {
		public static async Task Main(string[] args) {
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("ion-app");

			builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			ConfigureServices(builder.Services);
			await builder.Build().RunAsync();
		}

		public static void ConfigureServices(IServiceCollection aServiceCollection) {

			aServiceCollection.AddBlazorState
			(
				(aOptions) =>

					aOptions.Assemblies =
						new[]
						{
							typeof(Program).GetTypeInfo().Assembly,
						}
			);
		}
	}
}
