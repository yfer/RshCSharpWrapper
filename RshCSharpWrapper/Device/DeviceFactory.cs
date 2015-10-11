using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.Device
{
    public class DeviceFactory : IDeviceFactory
    {
        public List<string> GetRegisteredDeviceNames()
        {
            return Connector.GetRegisteredDeviceNames().ToList();
        }

        public Device GetDevice(string Name)
        {
            return new Device(Name);
        }
    }
}
