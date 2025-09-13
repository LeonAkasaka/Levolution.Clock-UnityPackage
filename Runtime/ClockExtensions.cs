namespace Levolution.Clock
{
    /// <summary>
    /// Extension methods for IClock interface.
    /// </summary>
    public static partial class ClockExtensions
    {
        /// <summary>
        /// Creates a scaled version of the clock that multiplies the time by the specified scale factor.
        /// This generic version avoids boxing for value type clocks.
        /// </summary>
        /// <typeparam name="T">The type of the clock.</typeparam>
        /// <param name="clock">The source clock.</param>
        /// <param name="scale">The scale factor to apply to the time.</param>
        /// <returns>A new ScaledClock instance that returns scaled time.</returns>
        public static ScaledClock<T> Scale<T>(this T clock, float scale) where T : IClock
            => new(clock, scale);

        /// <summary>
        /// Creates a negative version of the clock that reverses the time direction.
        /// This is equivalent to calling Scale(-1.0f).
        /// </summary>
        /// <typeparam name="T">The type of the clock.</typeparam>
        /// <param name="clock">The source clock.</param>
        /// <returns>A new ScaledClock instance that returns negative time.</returns>
        public static ScaledClock<T> Negative<T>(this T clock) where T : IClock
            => new(clock, -1.0f);

        /// <summary>
        /// Creates an offset version of the clock that adds the specified offset to the time.
        /// </summary>
        /// <typeparam name="T">The type of the clock.</typeparam>
        /// <param name="clock">The source clock.</param>
        /// <param name="offset">The offset to add to the time.</param>
        /// <returns>A new OffsetClock instance that returns offset time.</returns>
        public static OffsetClock<T> Offset<T>(this T clock, float offset) where T : IClock
            => new(clock, offset);

        /// <summary>
        /// Creates a looping version of the clock that repeats every specified duration.
        /// </summary>
        /// <typeparam name="T">The type of the clock.</typeparam>
        /// <param name="clock">The source clock.</param>
        /// <param name="duration">The loop duration in seconds.</param>
        /// <returns>A new LoopClock instance that returns looped time.</returns>
        public static LoopClock<T> Loop<T>(this T clock, float duration) where T : IClock
            => new(clock, duration);

        /// <summary>
        /// Creates a clamped version of the clock that limits the time to the specified range.
        /// </summary>
        /// <typeparam name="T">The type of the clock.</typeparam>
        /// <param name="clock">The source clock.</param>
        /// <param name="min">The minimum time value.</param>
        /// <param name="max">The maximum time value.</param>
        /// <returns>A new ClampedClock instance that returns clamped time.</returns>
        public static ClampedClock<T> Clamp<T>(this T clock, float min, float max) where T : IClock
            => new(clock, min, max);

        /// <summary>
        /// Creates a version of the clock that limits the time to a minimum value.
        /// </summary>
        /// <typeparam name="T">The type of the clock.</typeparam>
        /// <param name="clock">The source clock.</param>
        /// <param name="minValue">The minimum time value.</param>
        /// <returns>A new MinClock instance that returns time limited to the minimum.</returns>
        public static MinClock<T> Min<T>(this T clock, float minValue) where T : IClock
            => new(clock, minValue);

        /// <summary>
        /// Creates a version of the clock that limits the time to a maximum value.
        /// </summary>
        /// <typeparam name="T">The type of the clock.</typeparam>
        /// <param name="clock">The source clock.</param>
        /// <param name="maxValue">The maximum time value.</param>
        /// <returns>A new MaxClock instance that returns time limited to the maximum.</returns>
        public static MaxClock<T> Max<T>(this T clock, float maxValue) where T : IClock
            => new(clock, maxValue);

        /// <summary>
        /// Creates a bouncing version of the clock that oscillates between 0 and the specified duration.
        /// The time value goes from 0 to duration, then back to 0, repeating this pattern like a bouncing ball.
        /// </summary>
        /// <typeparam name="T">The type of the clock.</typeparam>
        /// <param name="clock">The source clock.</param>
        /// <param name="duration">The duration for one complete cycle (0 to duration and back to 0).</param>
        /// <returns>A new BounceClock instance that returns bouncing time.</returns>
        public static BounceClock<T> Bounce<T>(this T clock, float duration) where T : IClock
            => new(clock, duration);

        /// <summary>
        /// Creates a normalized version of the clock that returns time as a value between 0 and 1.
        /// The time is divided by the specified duration and clamped to the range [0, 1].
        /// </summary>
        /// <typeparam name="T">The type of the clock.</typeparam>
        /// <param name="clock">The source clock.</param>
        /// <param name="duration">The duration used for normalization.</param>
        /// <returns>A new NormalizedClock instance that returns normalized time.</returns>
        public static NormalizedClock<T> Normalize<T>(this T clock, float duration) where T : IClock
            => new(clock, duration);
    }
}