using UnityEngine;
using UnityEngine.UI;

namespace Health
{
    public class HealthDisplaySubscriber : MonoBehaviour
    {
        [SerializeField] Slider healthSlider;
        [SerializeField] HealthContainer health;
        public void DisplayHP( float currentHealth, float maxHealth)
        {
            healthSlider.value = currentHealth / maxHealth;
        }

        private void OnEnable()
        {
            health.OnHealthChanged += DisplayHP;
        }

        private void OnDisable()
        {
            health.OnHealthChanged -= DisplayHP;
        }
    }
}
