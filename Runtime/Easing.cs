namespace Levolution.Clock
{
    /// <summary>
    /// Delegate for easing functions that operate on normalized time (0-1).
    /// </summary>
    /// <param name="t">Normalized time in the range [0, 1].</param>
    /// <returns>Eased time value.</returns>
    public delegate float EasingFunction(float t);

    /// <summary>
    /// Interface for clocks that produce normalized time values in the range [0, 1].
    /// </summary>
    public interface INormalizedClock : IClock { }

    /// <summary>
    /// Provides commonly used easing functions for normalized time values (0-1).
    /// </summary>
    public static class Easing
    {
        /// <summary>
        /// Linear easing (no easing).
        /// </summary>
        /// <param name="t">Normalized time [0, 1].</param>
        /// <returns>Linear interpolated value.</returns>
        public static float Linear(float t) => t;

        /// <summary>
        /// Ease-in quadratic easing.
        /// </summary>
        /// <param name="t">Normalized time [0, 1].</param>
        /// <returns>Ease-in interpolated value.</returns>
        public static float EaseIn(float t) => t * t;

        /// <summary>
        /// Ease-out quadratic easing.
        /// </summary>
        /// <param name="t">Normalized time [0, 1].</param>
        /// <returns>Ease-out interpolated value.</returns>
        public static float EaseOut(float t) => 1 - (1 - t) * (1 - t);

        /// <summary>
        /// Ease-in-out quadratic easing.
        /// </summary>
        /// <param name="t">Normalized time [0, 1].</param>
        /// <returns>Ease-in-out interpolated value.</returns>
        public static float EaseInOut(float t) => t < 0.5f ? 2 * t * t : 1 - 2 * (1 - t) * (1 - t);

        /// <summary>
        /// Sine wave easing.
        /// </summary>
        /// <param name="t">Normalized time [0, 1].</param>
        /// <returns>Sine interpolated value.</returns>
        public static float Sine(float t) => (float)System.Math.Sin(t * System.Math.PI * 2);

        /// <summary>
        /// Smoothstep easing (3t² - 2t³).
        /// </summary>
        /// <param name="t">Normalized time [0, 1].</param>
        /// <returns>Smoothstep interpolated value.</returns>
        public static float Smoothstep(float t) => t * t * (3 - 2 * t);
    }
}