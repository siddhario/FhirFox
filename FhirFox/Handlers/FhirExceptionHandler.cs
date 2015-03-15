using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Hl7.Fhir.Model;

namespace FhirFox.Handlers
{
    public class FhirExceptionHandler: ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            OperationOutcome oo = new OperationOutcome();
            oo.Text = new Hl7.Fhir.Model.Narrative() { Div = "This is unhandled FHIR exception !" };
            oo.Issue.Add(new OperationOutcome.OperationOutcomeIssueComponent() { Severity = OperationOutcome.IssueSeverity.Fatal });

            string content = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToJson(oo, false);
            

            context.Result = new TextPlainErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = content
            };
        }

        private class TextPlainErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response =
                                 new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(Content);
                response.RequestMessage = Request;
                return Task.FromResult(response);
            }
        }
    }
}