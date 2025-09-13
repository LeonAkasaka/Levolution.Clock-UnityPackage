namespace Levolution.Clock
{
    /// <summary>
    /// Generic clock implementation that scales time from another clock.
    /// </summary>
    /// <typeparam name="T">The type of the base clock.</typeparam>
    public readonly struct ScaledClock<T> : IClock where T : IClock
    {
        private readonly T _baseClock;
        private readonly float _scale;

        /// <summary>
        /// Initializes a new instance of ScaledClock.
        /// </summary>
        /// <param name="baseClock">The base clock to scale.</param>
        /// <param name="scale">The scale factor.</param>
        public ScaledClock(T baseClock, float scale)
        {
            _baseClock = baseClock;
            _scale = scale;
        }

        /// <summary>
        /// Gets the scaled time from the base clock.
        /// </summary>
        /// <returns>Scaled elapsed time in seconds.</returns>
        public float GetTime() => _baseClock.GetTime() * _scale;
    }

    /// <summary>
    /// Generic clock implementation that adds an offset to time from another clock.
    /// </summary>
    /// <typeparam name="T">The type of the base clock.</typeparam>
    public readonly struct OffsetClock<T> : IClock where T : IClock
    {
        private readonly T _baseClock;
        private readonly float _offset;

        /// <summary>
        /// Initializes a new instance of OffsetClock.
        /// </summary>
        /// <param name="baseClock">The base clock to offset.</param>
        /// <param name="offset">The offset to add.</param>
        public OffsetClock(T baseClock, float offset)
        {
            _baseClock = baseClock;
            _offset = offset;
        }

        /// <summary>
        /// Gets the offset time from the base clock.
        /// </summary>
        /// <returns>Offset elapsed time in seconds.</returns>
        public float GetTime() => _baseClock.GetTime() + _offset;
    }

    /// <summary>
    /// Generic clock implementation that loops time from another clock.
    /// </summary>
    /// <typeparam name="T">The type of the base clock.</typeparam>
    public readonly struct LoopClock<T> : IClock where T : IClock
    {
        private readonly T _baseClock;
        private readonly float _duration;

        /// <summary>
        /// Initializes a new instance of LoopClock.
        /// </summary>
        /// <param name="baseClock">The base clock to loop.</param>
        /// <param name="duration">The loop duration.</param>
        public LoopClock(T baseClock, float duration)
        {
            _baseClock = baseClock;
            _duration = duration;
        }

        /// <summary>
        /// Gets the looped time from the base clock.
        /// </summary>
        /// <returns>Looped elapsed time in seconds.</returns>
        public float GetTime()
        {
            var time = _baseClock.GetTime();
            return _duration > 0 ? time % _duration : 0;
        }
    }

    /// <summary>
    /// Generic clock implementation that clamps time from another clock.
    /// </summary>
    /// <typeparam name="T">The type of the base clock.</typeparam>
    public readonly struct ClampedClock<T> : IClock where T : IClock
    {
        private readonly T _baseClock;
        private readonly float _min;
        private readonly float _max;

        /// <summary>
        /// Initializes a new instance of ClampedClock.
        /// </summary>
        /// <param name="baseClock">The base clock to clamp.</param>
        /// <param name="min">The minimum time value.</param>
        /// <param name="max">The maximum time value.</param>
        public ClampedClock(T baseClock, float min, float max)
        {
            _baseClock = baseClock;
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Gets the clamped time from the base clock.
        /// </summary>
        /// <returns>Clamped elapsed time in seconds.</returns>
        public float GetTime()
        {
            var time = _baseClock.GetTime();
            return time < _min ? _min : time > _max ? _max : time;
        }
    }

    /// <summary>
    /// Generic clock implementation that limits time to a minimum value from another clock.
    /// </summary>
    /// <typeparam name="T">The type of the base clock.</typeparam>
    public readonly struct MinClock<T> : IClock where T : IClock
    {
        private readonly T _baseClock;
        private readonly float _minValue;

        /// <summary>
        /// Initializes a new instance of MinClock.
        /// </summary>
        /// <param name="baseClock">The base clock to limit.</param>
        /// <param name="minValue">The minimum time value.</param>
        public MinClock(T baseClock, float minValue)
        {
            _baseClock = baseClock;
            _minValue = minValue;
        }

        /// <summary>
        /// Gets the minimum-limited time from the base clock.
        /// </summary>
        /// <returns>Time limited to the minimum value in seconds.</returns>
        public float GetTime()
        {
            var time = _baseClock.GetTime();
            return time < _minValue ? _minValue : time;
        }
    }

    /// <summary>
    /// Generic clock implementation that limits time to a maximum value from another clock.
    /// </summary>
    /// <typeparam name="T">The type of the base clock.</typeparam>
    public readonly struct MaxClock<T> : IClock where T : IClock
    {
        private readonly T _baseClock;
        private readonly float _maxValue;

        /// <summary>
        /// Initializes a new instance of MaxClock.
        /// </summary>
        /// <param name="baseClock">The base clock to limit.</param>
        /// <param name="maxValue">The maximum time value.</param>
        public MaxClock(T baseClock, float maxValue)
        {
            _baseClock = baseClock;
            _maxValue = maxValue;
        }

        /// <summary>
        /// Gets the maximum-limited time from the base clock.
        /// </summary>
        /// <returns>Time limited to the maximum value in seconds.</returns>
        public float GetTime()
        {
            var time = _baseClock.GetTime();
            return time > _maxValue ? _maxValue : time;
        }
    }

    /// <summary>
    /// Generic clock implementation that creates a bouncing (oscillating) time from another clock.
    /// The time bounces between 0 and the specified duration like a ball bouncing between two walls.
    /// </summary>
    /// <typeparam name="T">The type of the base clock.</typeparam>
    public readonly struct BounceClock<T> : IClock where T : IClock
    {
        private readonly T _baseClock;
        private readonly float _duration;

        /// <summary>
        /// Initializes a new instance of BounceClock.
        /// </summary>
        /// <param name="baseClock">The base clock to create bouncing effect from.</param>
        /// <param name="duration">The duration for one complete cycle.</param>
        public BounceClock(T baseClock, float duration)
        {
            _baseClock = baseClock;
            _duration = duration;
        }

        /// <summary>
        /// Gets the bouncing time from the base clock.
        /// </summary>
        /// <returns>Bouncing time between 0 and duration in seconds.</returns>
        public float GetTime()
        {
            if (_duration <= 0) return 0;

            var time = _baseClock.GetTime();
            var cycle = time / _duration;
            var normalizedTime = cycle % 2;

            // First half of cycle: 0 to 1, Second half: 1 to 0
            return normalizedTime <= 1 
                ? normalizedTime * _duration 
                : (2 - normalizedTime) * _duration;
        }
    }
}