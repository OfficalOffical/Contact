using Contact.Business;
using Contact.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace Contact.WebApi
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
            
            services.AddControllers();

            //services.AddCors();

            services.AddCors(options => options.AddPolicy("AllowAnyOrigins",
              builder => builder
                  .AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
          ));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact.WebApi", Version = "v1" });
            });
            services.AddDbContext<PhoneDBContext>();
            services.AddTransient<IContactDal, ContactDal>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IDetailedContactService, DetailedContactService>();
            services.AddTransient<IContactDetailsDal, ContactDetailsDal>();
            



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact.WebApi v1"));
            }

            //app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
            //app.UseCors();
            app.UseCors("AllowAnyOrigins");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()   
                .AllowAnyHeader());

            

        }
    }
}
