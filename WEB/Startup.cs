using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Config.Automapper;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Ninject;
using Ninject.Activation;
using Ninject.Infrastructure.Disposal;
using Ninject.Modules;
using WEB.Config.Automapper;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

[assembly: OwinStartup(typeof(WEB.Startup))]
namespace WEB
{
    public class Startup
    {

        private readonly AsyncLocal<Scope> _scopeProvider = new AsyncLocal<Scope>();
        private IKernel Kernel { get; set; }

        private object Resolve(Type type) => Kernel.Get(type);
        private object RequestScope(IContext context) => _scopeProvider.Value;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddRequestScopingMiddleware(() => _scopeProvider.Value = new Scope());
            services.AddCustomControllerActivation(Resolve);
            services.AddCustomViewComponentActivation(Resolve);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            Kernel = RegisterApplicationComponents(app);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }

        private IKernel RegisterApplicationComponents(IApplicationBuilder app)
        {
            NinjectModule serviceModule = new ServiceModule(Configuration.GetConnectionString("DefaultConnection"));

            var kernel = new StandardKernel(serviceModule);

            // Register application services
            foreach (var ctrlType in app.GetControllerTypes())
            {
                kernel.Bind(ctrlType).ToSelf().InScope(RequestScope);
            }

            kernel.Bind<IMemberService>().To<MemberService>().InScope(RequestScope);
            kernel.Bind<IOfficeService>().To<OfficeService>().InScope(RequestScope);
            kernel.Bind<IUserService>().To<UserService>().InScope(RequestScope);

            kernel.BindToMethod(app.GetRequestService<IViewBufferScope>);


            kernel.Bind<IMapper>()
                .ToMethod(context =>
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        //BLL
                        cfg.AddProfile<CandidateInfoProfile>();
                        cfg.AddProfile<EmployeeInfoProfile>();
                        cfg.AddProfile<MemberProfile>();
                        cfg.AddProfile<PersonalInfoProfile>();
                        cfg.AddProfile<ContactsProfile>();

                        //WEB
                        cfg.AddProfile<CandidateViewModelProfile>();
                        cfg.AddProfile<PersonalInfoViewModelProfile>();
                        cfg.AddProfile<ContactsViewModelProfile>();
                        cfg.AddProfile<EmployeeViewModelProfile>();

                        cfg.ConstructServicesUsing(t => kernel.Get(t));
                    });
                    return config.CreateMapper();
                }).InSingletonScope();

            return kernel;
        }

        private sealed class Scope : DisposableObject { }
    }
}
