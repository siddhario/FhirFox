using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Threading.Tasks;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;
using Hl7.Fhir.Rest;

namespace FhirFox.Handlers.Formatters
{
    public class FhirJsonFormatter:MediaTypeFormatter
    {
        public FhirJsonFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json+fhir"));
        }

        public override bool CanReadType(Type type)
        {
            if (type==typeof(Base))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool CanWriteType(Type type)
        {
            if (type == typeof(Base))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override Task WriteToStreamAsync(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {         
            byte[] bytes = FhirSerializer.SerializeToJsonBytes((Base)value);

            return writeStream.WriteAsync(bytes, 0, bytes.Length);
        }

        public async override System.Threading.Tasks.Task<object> ReadFromStreamAsync(Type type, System.IO.Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
            string ts = await content.ReadAsStringAsync();
            try
            {
                Base b = FhirParser.ParseFromJson(ts);
              
        

                return b;
            }
            catch(Exception e)
            {
                return null;
            }
        
        }
    }
}