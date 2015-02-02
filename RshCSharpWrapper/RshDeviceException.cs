using System;

namespace RshCSharpWrapper
{
    public class RshDeviceException : Exception
    {
        public API Api;

        public RshDeviceException(API api)
            : base(Connector.GetError(api))
        {
            Api = api;            
        }
    }
}
