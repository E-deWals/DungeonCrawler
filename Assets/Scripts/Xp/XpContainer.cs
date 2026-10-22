using EventBus;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace XP
{
    public class XpContainer : MonoBehaviour
    {
        [SerializeField] private List<int> levelUpXp = new();

        private int currentLevel;
        private int currentXP;


        public event Action<int, int> OnXpChanged;
        public event Action<int> OnLevelUp;
        public event Action OnLevelMax;

        private void Start()
        {
            CurrentXP = 0;
        }
        public int CurrentXP // changes currentXP and checks value on change
        {
            set
            {
                currentXP = value;

                if (currentLevel < levelUpXp.Count - 1)
                {
                    if (currentXP >= levelUpXp[currentLevel])
                    {
                        currentXP -= levelUpXp[currentLevel];
                        currentLevel++;
                        OnLevelUp?.Invoke(currentLevel);
                    }
                }
                else
                {
                    if (currentXP >= levelUpXp[currentLevel])
                    {
                        currentXP = levelUpXp[currentLevel];
                        OnLevelMax?.Invoke();
                    }
                }

                OnXpChanged?.Invoke(currentXP, levelUpXp[currentLevel]);
            }
            get
            {
                return currentXP;
            }
        }

        public void ChangeXP(GetXPEvent getXPEvent)
        {
            CurrentXP += getXPEvent.xp;
        }

        private void OnEnable()
        {
            EventBus<GetXPEvent>.OnEvent += ChangeXP;
        }

        private void OnDisable()
        {
            EventBus<GetXPEvent>.OnEvent -= ChangeXP;
        }
    }
}

