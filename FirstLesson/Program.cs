using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

//sia center
//artifactory
/*
---- Create ----
- Host
- Configuration File
- Middleware

*/
namespace FirstLesson
{
	class Program
	{
		static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
		
		public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
		
	}
	
	internal class Startup
	{
		private readonly IConfiguration _configuration;
		
		public Startup(IConfiguration configuration){
		 	_configuration = configuration;
		}
		
		public void Configure(IApplicationBuilder app){
		 var ordem = string.Empty;
		 
		 //Middleware function
		 app.Use(async (context, next) => {
			  ordem += "1";
			  await next.Invoke();
              ordem += "4";
			  await context.Response.WriteAsync($"Ordem: {ordem} ");
			  //await context.Response.WriteAsync( _configuration["Application"]);    			  
		  });
		  
		  //Middleware function
		  app.Use(async (context, next) => {
			  ordem += "2";
			  await next.Invoke();
			  ordem += "3";
              await context.Response.WriteAsync($"Ordem: {ordem} ");
			  //await context.Response.WriteAsync( _configuration["Application"]);    			  
		  });
		   
		  app.Run(async context => {
              await context.Response.WriteAsync($"Ordem: {ordem} ");    			  
		  });
		}
	}
	
}