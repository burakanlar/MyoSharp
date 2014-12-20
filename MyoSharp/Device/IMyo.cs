using System;

namespace MyoSharp.Device
{
    public interface IMyo : IMyoEventGenerator, IMyoDeviceState, IDisposable
    {
        #region Properties
        IntPtr Handle { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Causes the Myo to vibrate.
        /// </summary>
        /// <param name="type">The type of vibration.</param>
        void Vibrate(VibrationType type);

        /// <summary>
        /// Causes the Myo to unlock.
        /// </summary>
        /// <param name="type">The type of unlock.</param>
        void Unlock(UnlockType type);

        /// <summary>
        /// Causes the Myo to lock.
        /// </summary>
        void Lock();

        /// <summary>
        /// Set whether or not to stream EMG data for a given myo.
        /// </summary>
        /// <param name="type">The type of unlock.</param>
        void StreamEmg(StreamEmgType type);

        /// <summary>
        /// Requests RSSI from the Myo.
        /// </summary>
        void RequestRssi();
        #endregion
    }
}