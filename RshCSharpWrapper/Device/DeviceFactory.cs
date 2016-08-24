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
            try
            {
                return Connector.GetRegisteredDeviceNames().ToList();
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        public Device GetDevice(string Name)
        {
            return new Device(Name);
        }
    }
}
