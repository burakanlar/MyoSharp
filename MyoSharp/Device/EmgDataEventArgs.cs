using System;
using System.Collections.Generic;
using System.Text;

namespace MyoSharp.Device
{
    public class EmgDataEventArgs : MyoEventArgs
    {
        #region Constructors
        public EmgDataEventArgs(IMyo myo, DateTime timestamp, Int32[] emg)
            : base(myo, timestamp)
        {
            this.EMG = emg;
        }
        #endregion

        #region Properties
        public Int32[] EMG { get; private set; }
        #endregion
    }
}
