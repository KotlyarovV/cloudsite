using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TagsCloudVisualization;
using YandexMystem.Wrapper;
using YandexMystem.Wrapper.Enums;

namespace CloudWeb
{
    public class Startup
    {
        private GramPartsEnum[] _excludedGramParts = new[]
        {
            GramPartsEnum.Conjunction,
            GramPartsEnum.NounPronoun,
            GramPartsEnum.Pretext,
            GramPartsEnum.Part,
            GramPartsEnum.PronounAdjective
        };

        private  readonly char[] _excludedChars = new[] { '!', ',', '"', '\r', '\n' };

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<Mysteam>();
            services.AddTransient<ISpiral, ArchimedeanSpiral>();
            services.AddTransient<IAnalysator, Analysator>();

            services.AddTransient<IFilter>(provider => new Filter(_excludedGramParts));
            services.AddTransient<ITextCleaner>(provider => new TextCleaner(_excludedChars));

            services.AddTransient<IWordExtractor, WordExtractor>();
            services.AddTransient<IFormatter, Formatter>();
            services.AddTransient<ICloudLayouter, CircularCloudLayouter>();
            services.AddTransient<ITextVisualisator, TextVisualisator>();

            services.AddTransient<ICloudPainter, CloudPainter>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

    }
}
