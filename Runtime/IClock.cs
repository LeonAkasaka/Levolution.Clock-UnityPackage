namespace Levolution.Clock
{
    /// <summary>
    /// Interface that abstracts time acquisition.
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// Gets the elapsed time from an arbitrary epoch time.
        /// </summary>
        /// <returns>Elapsed time in seconds.</returns>
        float GetTime();
    }

    /// <summary>
    /// Static class that provides convenient access to standard clocks.
    /// </summary>
    public static class Clocks
    {
        /// <summary>
        /// Gets the system clock.
        /// </summary>
        /// <value>
        /// A clock based on the system's real time.
        /// Suitable when accurate time measurement unaffected by Unity's time scale is required.
        /// </value>
        public static SystemClock System => SystemClock.Default;
    }

    /// <summary>
    /// Internal clock implementation that scales time from another clock.
    /// </summary>
    internal class ScaledClock : IClock
    {
        private readonly IClock _baseClock;
        private readonly float _scale;

        /// <summary>
        /// Initializes a new instance of ScaledClock.
        /// </summary>
        /// <param name="baseClock">The base clock to scale.</param>
        /// <param name="scale">The scale factor.</param>
        public ScaledClock(IClock baseClock, float scale)
        {
            _baseClock = baseClock;
            _scale = scale;
        }

        /// <summary>
        /// Gets the scaled time from the base clock.
        /// </summary>
        /// <returns>Scaled elapsed time in seconds.</returns>
        public float GetTime()
        {
            return _baseClock.GetTime() * _scale;
        }
    }
}