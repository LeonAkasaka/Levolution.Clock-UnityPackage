namespace Levolution.Clock
{
    /// <summary>
    /// Clock that allows manual control of time.
    /// Used for testing and pseudo time manipulation.
    /// </summary>
    public class ManualClock : IClock
    {
        /// <summary>
        /// Sets or gets the current time.
        /// </summary>
        public float CurrentTime { get; set; }

        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <returns>Current time.</returns>
        public float GetTime() => CurrentTime;
    }
}