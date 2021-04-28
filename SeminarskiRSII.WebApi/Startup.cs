using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SeminarskiRSII.WebApi.Database;
using SeminarskiRSII.WebApi.Security;
using SeminarskiRSII.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace SeminarskiRSII.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().AddJsonOptions(o =>
            { // s ovim smo omoguićili da nemamo problema s pocentim malim ili velikim slovom
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });

            

            var connection = @"Server=.;Database=SeminarskiRSIIBaza;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<SeminarskiRSIIBazaContext>(options => options.UseSqlServer(connection));
            services.AddAuthentication("BasicAuthentication")
           .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new Info { Title = "My Api", Version = "V1" });
                c.SwaggerDoc("My_Api", new OpenApiInfo { Version = "1.0", Description = "my api " });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
            });
            services.AddScoped<ILoginService, LoginService>();

            //services.AddScoped<IService<Model.VrstaOsoblja, object>, BaseService<Model.VrstaOsoblja, object, Database.VrstaOsoblja>>();
            services.AddScoped<IVrstaOsobljaService, VrstaOsobljaService>();

            services.AddScoped<IOsobljeService, OsobljeService>();

            //services.AddScoped<IService<Model.SobaStatus, object>, BaseService<Model.SobaStatus, object, Database.SobaStatus>>();
            services.AddScoped<ISobaStatusService, SobaStatusService>();

            //services.AddScoped<ICRUDService<Model.Soba, SobaSearchRequest, SobaInsertRequest, SobaInsertRequest>, SobaService>();
            services.AddScoped<ISobaService, SobaService>();

            //services.AddScoped<IService<Model.SobaOsoblje, object>, BaseService<Model.SobaOsoblje, object, Database.SobaOsoblje>>();
            services.AddScoped<ISobaOsobljeService, SobaOsobljeService>();
            services.AddScoped<IDrzavaService, DrzavaService>();
            services.AddScoped<IGradService, GradService>();

            //services.AddScoped<ICRUDService<Model.Notifikacije, NotifikacijeSearchRequest, NotifikacijeInsertRequest, NotifikacijeInsertRequest>, NotifikacijaService>();
            services.AddScoped<INotifikacijeService, NotifikacijeService>();

            services.AddScoped<INovostiService, NovostiService>();
            services.AddScoped<IGostService, GostService>();
            services.AddScoped<ICjenovnikService, CjenovnikService>();
            services.AddScoped<IRezervacijaService, RezervacijaService>();
            services.AddScoped<IRecenzijaService, RecenzijaService>();

            services.AddScoped<IGostiNotifikacijeService, GostiNotifikacijeService>();
          

            // Enable CORS         KORS OMOGUĆAVA DA POKRENEMO API NA VISE RAZLICITIH PROJEKATA
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("EnableCORS");       // OVDE MORAMO UKLJUCITI ISTO
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();


            app.UseStaticFiles(); // Za sliku
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
                RequestPath = new PathString("/Images")
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/My_Api/swagger.json", "My API V1");    // EndPoint mora odgovarati swaggeru u configurationu
            });
        }
    }
}
