// <auto-generated/>
#pragma warning disable
using Marten;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;

namespace Internal.Generated.WolverineHandlers
{
    // START: POST_orders_create3
    public class POST_orders_create3 : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _options;
        private readonly Marten.ISessionFactory _sessionFactory;

        public POST_orders_create3(Wolverine.Http.WolverineHttpOptions options, Marten.ISessionFactory sessionFactory) : base(options)
        {
            _options = options;
            _sessionFactory = sessionFactory;
        }



        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            await using var documentSession = _sessionFactory.OpenSession();
            var (command, jsonContinue) = await ReadJsonAsync<WolverineWebApi.Marten.StartOrder>(httpContext);
            if (jsonContinue == Wolverine.HandlerContinuation.Stop) return;
            (var creationResponse, var startStream) = WolverineWebApi.Marten.MarkItemEndpoint.StartOrder3(command);
            
            // Placed by Wolverine's ISideEffect policy
            startStream.Execute(documentSession);

            ((Wolverine.Http.IHttpAware)creationResponse).Apply(httpContext);
            await WriteJsonAsync(httpContext, creationResponse);

            // Commit the unit of work
            await documentSession.SaveChangesAsync(httpContext.RequestAborted).ConfigureAwait(false);
        }

    }

    // END: POST_orders_create3
    
    
}
