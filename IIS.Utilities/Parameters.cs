using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIS.Utilities
{
    public static class Parameters
    {
        public static ApiKeys ApiKey;
        public static ApiUris ApiUri;
    }

    public class ApiKeys
    {
        public string ApiKey;
    }

    public class ApiUris
    {
        public string Select;
        public string Create;
        public string Delete;
        public string Update;
    }
}