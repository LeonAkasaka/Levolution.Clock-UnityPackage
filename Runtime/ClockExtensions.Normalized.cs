namespace Levolution.Clock
{
    /// <summary>
    /// Extension methods for normalized clocks (operating on 0-1 range).
    /// </summary>
    public static partial class ClockExtensions
    {
        /// <summary>
        /// Applies an easing function to a normalized clock.
        /// </summary>
        /// <typeparam name="T">The type of the normalized clock.</typeparam>
        /// <param name="clock">The normalized clock (produces 0-1 values).</param>
        /// <param name="easingFunction">The easing function to apply.</param>
        /// <returns>A new EasedClock instance with the easing function applied.</returns>
        public static EasedClock<T> Ease<T>(this T clock, EasingFunction easingFunction) where T : INormalizedClock
            => new(clock, easingFunction);

        /// <summary>
        /// Creates a looping version of a normalized clock that repeats the 0-1 cycle.
        /// This method is designed for use with normalized clocks (0-1 range).
        /// </summary>
        /// <typeparam name="T">The type of the normalized clock.</typeparam>
        /// <param name="clock">The normalized clock (produces 0-1 values).</param>
        /// <returns>A new NormalizedLoopClock instance that loops the 0-1 range.</returns>
        public static NormalizedLoopClock<T> Loop<T>(this T clock) where T : INormalizedClock
            => new(clock);

        /// <summary>
        /// Creates a bouncing version of a normalized clock that oscillates between 0 and 1.
        /// This method is designed for use with normalized clocks (0-1 range).
        /// </summary>
        /// <typeparam name="T">The type of the normalized clock.</typeparam>
        /// <param name="clock">The normalized clock (produces 0-1 values).</param>
        /// <returns>A new NormalizedBounceClock instance that bounces in the 0-1 range.</returns>
        public static NormalizedBounceClock<T> Bounce<T>(this T clock) where T : INormalizedClock
            => new(clock);

        // Standard easing function extension methods

        /// <summary>
        /// Applies linear easing (no easing) to a normalized clock.
        /// </summary>
        /// <typeparam name="T">The type of the normalized clock.</typeparam>
        /// <param name="clock">The normalized clock (produces 0-1 values).</param>
        /// <returns>A new EasedClock instance with linear easing applied.</returns>
        public static EasedClock<T> Linear<T>(this T clock) where T : INormalizedClock
            => new(clock, Easing.Linear);

        /// <summary>
        /// Applies ease-in quadratic easing to a normalized clock.
        /// </summary>
        /// <typeparam name="T">The type of the normalized clock.</typeparam>
        /// <param name="clock">The normalized clock (produces 0-1 values).</param>
        /// <returns>A new EasedClock instance with ease-in easing applied.</returns>
        public static EasedClock<T> EaseIn<T>(this T clock) where T : INormalizedClock
            => new(clock, Easing.EaseIn);

        /// <summary>
        /// Applies ease-out quadratic easing to a normalized clock.
        /// </summary>
        /// <typeparam name="T">The type of the normalized clock.</typeparam>
        /// <param name="clock">The normalized clock (produces 0-1 values).</param>
        /// <returns>A new EasedClock instance with ease-out easing applied.</returns>
        public static EasedClock<T> EaseOut<T>(this T clock) where T : INormalizedClock
            => new(clock, Easing.EaseOut);

        /// <summary>
        /// Applies ease-in-out quadratic easing to a normalized clock.
        /// </summary>
        /// <typeparam name="T">The type of the normalized clock.</typeparam>
        /// <param name="clock">The normalized clock (produces 0-1 values).</param>
        /// <returns>A new EasedClock instance with ease-in-out easing applied.</returns>
        public static EasedClock<T> EaseInOut<T>(this T clock) where T : INormalizedClock
            => new(clock, Easing.EaseInOut);

        /// <summary>
        /// Applies sine wave easing to a normalized clock.
        /// </summary>
        /// <typeparam name="T">The type of the normalized clock.</typeparam>
        /// <param name="clock">The normalized clock (produces 0-1 values).</param>
        /// <returns>A new EasedClock instance with sine easing applied.</returns>
        public static EasedClock<T> Sine<T>(this T clock) where T : INormalizedClock
            => new(clock, Easing.Sine);

        /// <summary>
        /// Applies smoothstep easing (3t² - 2t³) to a normalized clock.
        /// </summary>
        /// <typeparam name="T">The type of the normalized clock.</typeparam>
        /// <param name="clock">The normalized clock (produces 0-1 values).</param>
        /// <returns>A new EasedClock instance with smoothstep easing applied.</returns>
        public static EasedClock<T> Smoothstep<T>(this T clock) where T : INormalizedClock
            => new(clock, Easing.Smoothstep);
    }
}