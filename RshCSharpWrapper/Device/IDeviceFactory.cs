using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RshCSharpWrapper.Device
{
    public interface IDeviceFactory
    {
        List<string> GetRegisteredDeviceNames();
        Device GetDevice(string Name);
    }
}
