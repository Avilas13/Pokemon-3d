using Pokemon3D.Core;
using UnityEngine;

namespace Pokemon3D.World
{
    public enum WeatherType { Clear, Rain, Storm, Fog, Snow }

    public readonly struct TimeWeatherChangedEvent
    {
        public TimeWeatherChangedEvent(float dayProgress, WeatherType weather)
        {
            DayProgress = dayProgress;
            Weather = weather;
        }

        public float DayProgress { get; }
        public WeatherType Weather { get; }
    }

    public sealed class WorldTimeWeatherSystem : MonoBehaviour
    {
        [SerializeField] private float dayLengthSeconds = 1200f;
        [SerializeField] private WeatherType currentWeather = WeatherType.Clear;

        private GameplayEventBus _eventBus = default!;
        private float _clock;
        private float _nextPublishTime;
        private float _lastPublishedClock;
        private WeatherType _lastPublishedWeather;

        public void Initialize(GameplayEventBus eventBus) => _eventBus = eventBus;

        private void Update()
        {
            _clock = (_clock + Time.deltaTime / dayLengthSeconds) % 1f;
            if (Time.time < _nextPublishTime && Mathf.Abs(_clock - _lastPublishedClock) < 0.02f && _lastPublishedWeather == currentWeather)
            {
                return;
            }

            _eventBus?.Publish(new TimeWeatherChangedEvent(_clock, currentWeather));
            _nextPublishTime = Time.time + 1f;
            _lastPublishedClock = _clock;
            _lastPublishedWeather = currentWeather;
        }

        public void SetWeather(WeatherType weather)
        {
            currentWeather = weather;
            _eventBus?.Publish(new TimeWeatherChangedEvent(_clock, currentWeather));
            _nextPublishTime = Time.time + 1f;
            _lastPublishedClock = _clock;
            _lastPublishedWeather = currentWeather;
        }

        public string GetTimeWindow()
        {
            if (_clock < 0.25f) return "Dawn";
            if (_clock < 0.5f) return "Day";
            if (_clock < 0.75f) return "Dusk";
            return "Night";
        }
    }
}
