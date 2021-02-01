using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using BlazorAnimation;
using BlazorState;
using ImmoCalc.Infrastructures;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ImmoCalc {
	public class Program {
		public static async Task Main(string[] args) {
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("ion-app");

			builder.Services.Configure<AnimationOptions>(Guid.NewGuid().ToString(), c => { });
			builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			ConfigureServices(builder.Services);
			await builder.Build().RunAsync();
		}

		public static void ConfigureServices(IServiceCollection serviceCollection) {

			serviceCollection.AddBlazorState(options => options.Assemblies = new[] { typeof(Program).GetTypeInfo().Assembly, });
			serviceCollection.AddSingleton<IProjectRepository, InMemoryProjectRepository>();
		}
	}
}
