using FitBody.Api.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;

namespace FitBody.Api
{
    public static class Extensions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            var claim = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (claim != null)
                return int.Parse(claim.Value);

            throw new ArgumentNullException("userId");
        }

        public static IMvcBuilder AddExcelOutputFormatter(this IMvcBuilder builder)
        {
            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, ExcelOutputFormatterSetup>());
            return builder;
        }
    }

    public class ExcelOutputFormatterSetup : IConfigureOptions<MvcOptions>
    {
        void IConfigureOptions<MvcOptions>.Configure(MvcOptions options)
        {
            options.OutputFormatters.Add(new ExcelOutputFormatter());
        }
    }
}
