namespace Levolution.Clock
{
    /// <summary>
    /// Clock that guarantees returning the same time within the same frame.
    /// </summary>
    public class CachedClock : IClock
    {
        private readonly IClock _innerClock;
        private float _cachedTime;

        /// <summary>
        /// Initializes a new instance of CachedClock.
        /// </summary>
        /// <param name="innerClock">The inner clock to get actual time from.</param>
        public CachedClock(IClock innerClock)
        {
            _innerClock = innerClock ?? throw new System.ArgumentNullException(nameof(innerClock));
            Update();
        }

        /// <summary>
        /// Gets the current time. Returns the same value until the <see cref="Update"/> method is called.
        /// </summary>
        /// <returns>Current time in seconds.</returns>
        public float GetTime() => _cachedTime;

        /// <summary>
        /// Updates the time.
        /// </summary>
        public void Update() => _cachedTime = _innerClock.GetTime();
    }
}