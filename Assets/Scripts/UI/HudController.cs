using UnityEngine;
using UnityEngine.UI;

namespace Pokemon3D.UI
{
    public sealed class HudController : MonoBehaviour
    {
        [SerializeField] private Slider playerHp = default!;
        [SerializeField] private Slider activeCreatureHp = default!;
        [SerializeField] private Text regionLabel = default!;
        [SerializeField] private Text timeWeatherLabel = default!;

        public void SetPlayerHealth(float value01) => playerHp.value = Mathf.Clamp01(value01);
        public void SetCreatureHealth(float value01) => activeCreatureHp.value = Mathf.Clamp01(value01);
        public void SetRegion(string region) => regionLabel.text = region;
        public void SetTimeWeather(string value) => timeWeatherLabel.text = value;
    }
}
