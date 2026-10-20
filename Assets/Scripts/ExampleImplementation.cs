using UnityEngine;

namespace EventBus
{
    public class ExampleImplementationPublisher : MonoBehaviour
    {
        public void onXPDropped(int droppedXP)
        {
            EventBus<GetXPEvent>.Publish(new GetXPEvent(droppedXP));
        }
    }

    public class ExampleImplementationSubscriber : MonoBehaviour
    {
        int xp;
        public void DisplayXP(GetXPEvent getXPEvent)
        {
            xp += getXPEvent.xp;
            //xpText.text = "xp: " + xp.ToString();
        }

        private void OnEnable()
        {
            EventBus<GetXPEvent>.OnEvent += DisplayXP;
        }

        private void OnDisable()
        {
            EventBus<GetXPEvent>.OnEvent -= DisplayXP;
        }
    }
}
