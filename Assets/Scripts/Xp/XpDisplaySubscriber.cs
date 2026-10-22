using Health;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace XP
{
    public class XpDisplaySubscriber : MonoBehaviour
    {
        [SerializeField] XpContainer xp;
        [SerializeField] Slider XpSlider;
        [SerializeField] TMP_Text LevelDisplay;
        [SerializeField] TMP_Text XpDisplay;
        public void DisplayXP(int currentXP, int levelUpXp)
        {
            XpSlider.value = (float)currentXP / (float)levelUpXp;
            XpDisplay.text = currentXP.ToString() + " / " + levelUpXp.ToString();
        }

        public void DisplayMaxXp()
        {
            LevelDisplay.text = "lvl: max";
        }

        public void DisplayLevel(int level)
        {
            LevelDisplay.text = "lvl: " + level;
        }

        private void OnEnable()
        {
            xp.OnXpChanged += DisplayXP;
            xp.OnLevelMax += DisplayMaxXp;
            xp.OnLevelUp += DisplayLevel;
        }

        private void OnDisable()
        {
            xp.OnXpChanged -= DisplayXP;
            xp.OnLevelMax -= DisplayMaxXp;
            xp.OnLevelUp -= DisplayLevel;
        }
    }
}
