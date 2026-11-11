using EventBus;
using UnityEngine;

namespace XP
{
    public class XpPublisher : MonoBehaviour
    {
        public void OnXPPickedUp(int xp)
        {
            EventBus<GetXPEvent>.Publish(new GetXPEvent(xp));
        }
    }
}
