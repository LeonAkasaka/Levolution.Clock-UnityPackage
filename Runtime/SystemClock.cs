using System;

namespace Levolution.Clock
{
    /// <summary>
    /// Clock that uses the system clock's real time.
    /// </summary>
    public readonly struct SystemClock : IClock
    {
        private readonly DateTime _startTime;

        /// <summary>
        /// Default instance.
        /// Uses <c>default(DateTime)</c> (January 1, 0001 00:00:00) as the start time.
        /// </summary>
        public static readonly SystemClock Default = new(default);

        /// <summary>
        /// Initializes a new instance of SystemClock with the specified start time.
        /// </summary>
        /// <param name="startTime">The reference start time.</param>
        public SystemClock(DateTime startTime)
        {
            _startTime = startTime;
        }

        /// <summary>
        /// Gets the elapsed time from the system clock's real time.
        /// </summary>
        /// <returns>Elapsed time from the start point in seconds.</returns>
        public float GetTime()
        {
            var elapsed = DateTime.UtcNow - _startTime;
            return (float)elapsed.TotalSeconds;
        }
    }
}