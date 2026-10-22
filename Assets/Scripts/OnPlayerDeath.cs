using System.Runtime.InteropServices;
using UnityEngine;

namespace Health {
    public class OnPlayerDeath : MonoBehaviour
    {
        [SerializeField] private HealthContainer health;

        public void OnDeath()
        {
            // TODO: actually implement ondeath
            Debug.Log("Player has died, try again");
        }

        private void OnEnable()
        {
            health.OnDeath += OnDeath;
        }

        private void OnDisable()
        {
            health.OnDeath -= OnDeath;
        }
    }
}
