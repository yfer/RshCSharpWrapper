using System.Dynamic;
using System.Runtime.InteropServices;

namespace RshCSharpWrapper.Types
{
    /// <summary>
    /// настройка канала платы
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Channel
    {
        private uint _gain;

        /// <summary>
        /// коэффициент усиления
        /// </summary>
        public uint Gain
        {
            get { return _gain; }
            set { _gain = value; }
        }

        private uint _control;
        /// <summary>
        /// специфические настройки канала
        /// </summary>
        public ChannelControl Control
        {
            get { return (ChannelControl)_control; }
            set { _control = (uint)value; }
        }

        private double _delta;
        /// <summary>
        /// смещениe (в вольтах)
        /// </summary>
        public double Delta
        {
            get { return _delta; }
            set { _delta = value; }
        }        
    };
}
