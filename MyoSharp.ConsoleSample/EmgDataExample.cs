using System;

using MyoSharp.Device;
using MyoSharp.ConsoleSample.Internal;

namespace MyoSharp.ConsoleSample
{
    /// <summary>
    /// This example will show you how to hook onto the EMG data events on
    /// the Myo and each of the eight sensor pods values from it. 
    /// </summary>
    /// <remarks>
    /// Not sure how to use this example?
    /// - Open Visual Studio
    /// - Go to the solution explorer
    /// - Find the project that this file is contained within
    /// - Right click on the project in the solution explorer, go to "properties"
    /// - Go to the "Application" tab
    /// - Under "Startup object" pick this example from the list
    /// - Hit F5 and you should be good to go!
    /// </remarks>
    internal class EmgDataExample
    {
        #region Methods
        private static void Main(string[] args)
        {
            // create a hub that will manage Myo devices for us
            using (var hub = Hub.Create())
            {
                // listen for when the Myo connects
                hub.MyoConnected += (sender, e) =>
                {
                    Console.WriteLine("Myo {0} has connected!", e.Myo.Handle);
                    e.Myo.Vibrate(VibrationType.Short);
                    e.Myo.EmgDataAcquired += Myo_EmgDataAcquired;
                    e.Myo.StreamEmg(StreamEmgType.Enabled);
                };

                // listen for when the Myo disconnects
                hub.MyoDisconnected += (sender, e) =>
                {
                    Console.WriteLine("Oh no! It looks like {0} arm Myo has disconnected!", e.Myo.Arm);
                    e.Myo.EmgDataAcquired -= Myo_EmgDataAcquired;
                };

                // wait on user input
                ConsoleHelper.UserInputLoop(hub);
            }
        }

        #endregion

        #region Event Handlers
        static void Myo_EmgDataAcquired(object sender, EmgDataEventArgs e)
        {
            Console.Clear();
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(@"POD-{1}: {0}", e.EMG[i], i + 1);
            }
        }
        #endregion
    }
}