using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB
{
    public sealed class RequestScopingStartupFilter : IStartupFilter
    {
        private readonly Func<IDisposable> _requestScopeProvider;

        public RequestScopingStartupFilter(Func<IDisposable> requestScopeProvider)
        {
            _requestScopeProvider = requestScopeProvider ?? throw new ArgumentNullException(nameof(requestScopeProvider));
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> nextFilter)
        {
            return builder =>
            {
                ConfigureRequestScoping(builder);

                nextFilter(builder);
            };
        }

        private void ConfigureRequestScoping(IApplicationBuilder builder)
        {
            builder.Use(async (context, next) =>
            {
                using (var scope = _requestScopeProvider())
                {
                    await next();
                }
            });
        }
    }
}
