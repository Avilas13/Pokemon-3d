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

        public void Initialize(GameplayEventBus eventBus) => _eventBus = eventBus;

        private void Update()
        {
            _clock = (_clock + Time.deltaTime / dayLengthSeconds) % 1f;
            _eventBus?.Publish(new TimeWeatherChangedEvent(_clock, currentWeather));
        }

        public void SetWeather(WeatherType weather)
        {
            currentWeather = weather;
            _eventBus?.Publish(new TimeWeatherChangedEvent(_clock, currentWeather));
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
