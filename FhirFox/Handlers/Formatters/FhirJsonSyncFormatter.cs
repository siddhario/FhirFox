using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;

namespace FhirFox.Handlers.Formatters
{
    public class FhirJsonSyncFormatter:BufferedMediaTypeFormatter
    {
        public FhirJsonSyncFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json+fhir"));
        }

        public override bool CanReadType(Type type)
        {
            if (type.BaseType == typeof(DomainResource))
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
            if (type.BaseType == typeof(DomainResource))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void WriteToStream(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content)
        {            
            byte[] bytes = FhirSerializer.SerializeToJsonBytes((Base)value);
            writeStream.Write(bytes, 0, bytes.Length);
        }

      
        public override object ReadFromStream(Type type, System.IO.Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
            Task<string> ts = content.ReadAsStringAsync();
            string res = ts.Result;
            return FhirParser.ParseResourceFromJson(res);
        }
    }

}