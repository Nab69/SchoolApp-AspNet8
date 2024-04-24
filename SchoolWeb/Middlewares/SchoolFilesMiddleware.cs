using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.Threading.Tasks;

namespace SchoolWeb.Middlewares
{
    public static class SchoolFilesExtensions
    {
        public static IApplicationBuilder UseSchoolFiles(this IApplicationBuilder builder, string contentRootPath)
        {
            string path = Path.Join(contentRootPath, "files");
            var fileProvider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions();
            options.RequestPath = "/myfiles";
            options.FileProvider = fileProvider;

            return builder.UseStaticFiles(options);
        }
    }
}
