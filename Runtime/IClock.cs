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
}