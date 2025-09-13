namespace Levolution.Clock
{
    /// <summary>
    /// Generic clock implementation that normalizes time from another clock to the 0-1 range.
    /// </summary>
    /// <typeparam name="T">The type of the base clock.</typeparam>
    public readonly struct NormalizedClock<T> : INormalizedClock where T : IClock
    {
        private readonly T _baseClock;
        private readonly float _duration;

        /// <summary>
        /// Initializes a new instance of NormalizedClock.
        /// </summary>
        /// <param name="baseClock">The base clock to normalize.</param>
        /// <param name="duration">The duration used for normalization.</param>
        public NormalizedClock(T baseClock, float duration)
        {
            _baseClock = baseClock;
            _duration = duration;
        }

        /// <summary>
        /// Gets the normalized time from the base clock.
        /// </summary>
        /// <returns>Normalized time (time / duration), not clamped to any range.</returns>
        public float GetTime()
        {
            if (_duration <= 0) return 0;
            return _baseClock.GetTime() / _duration;
        }
    }

    /// <summary>
    /// Generic clock implementation that applies an easing function to normalized time.
    /// </summary>
    /// <typeparam name="T">The type of the base normalized clock.</typeparam>
    public readonly struct EasedClock<T> : INormalizedClock where T : INormalizedClock
    {
        private readonly T _baseClock;
        private readonly EasingFunction _easingFunction;

        /// <summary>
        /// Initializes a new instance of EasedClock.
        /// </summary>
        /// <param name="baseClock">The base normalized clock.</param>
        /// <param name="easingFunction">The easing function to apply.</param>
        public EasedClock(T baseClock, EasingFunction easingFunction)
        {
            _baseClock = baseClock;
            _easingFunction = easingFunction ?? throw new System.ArgumentNullException(nameof(easingFunction));
        }

        /// <summary>
        /// Gets the eased time from the base clock.
        /// </summary>
        /// <returns>Eased time in the range [0, 1].</returns>
        public float GetTime()
        {
            var time = _baseClock.GetTime();
            return _easingFunction(time);
        }
    }

    /// <summary>
    /// Generic clock implementation that loops normalized time (0-1 range).
    /// </summary>
    /// <typeparam name="T">The type of the base normalized clock.</typeparam>
    public readonly struct NormalizedLoopClock<T> : IClock where T : INormalizedClock
    {
        private readonly T _baseClock;

        /// <summary>
        /// Initializes a new instance of NormalizedLoopClock.
        /// </summary>
        /// <param name="baseClock">The normalized clock (produces 0-1 values).</param>
        public NormalizedLoopClock(T baseClock)
        {
            _baseClock = baseClock;
        }

        /// <summary>
        /// Gets the looped normalized time from the base clock.
        /// </summary>
        /// <returns>Looped time in the range [0, 1].</returns>
        public float GetTime()
        {
            var time = _baseClock.GetTime();
            return time % 1;
        }
    }

    /// <summary>
    /// Generic clock implementation that bounces normalized time (0-1 range).
    /// </summary>
    /// <typeparam name="T">The type of the base normalized clock.</typeparam>
    public readonly struct NormalizedBounceClock<T> : IClock where T : INormalizedClock
    {
        private readonly T _baseClock;

        /// <summary>
        /// Initializes a new instance of NormalizedBounceClock.
        /// </summary>
        /// <param name="baseClock">The normalized clock (produces 0-1 values).</param>
        public NormalizedBounceClock(T baseClock)
        {
            _baseClock = baseClock;
        }

        /// <summary>
        /// Gets the bouncing normalized time from the base clock.
        /// </summary>
        /// <returns>Bouncing time in the range [0, 1].</returns>
        public float GetTime()
        {
            var time = _baseClock.GetTime();
            var cycle = time % 2;
            return cycle <= 1 ? cycle : 2 - cycle;
        }
    }
}