using System;
using UnityEngine;

namespace Health
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        
        private float currentHealth;

        public event Action<float, float> OnHealthChanged;
        public event Action OnDeath;

        private void Start()
        {
            CurrentHealth = maxHealth;

        }
        public float CurrentHealth
        {
            set
            {
                currentHealth = value;
                if (currentHealth < 0)
                {
                    OnDeath?.Invoke();
                }
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
                OnHealthChanged?.Invoke(currentHealth, maxHealth);
            }
            get
            {
                return currentHealth;
            }
        }

        public void ChangeHealth(float value)
        {
            CurrentHealth += value;
        }
    }
}
