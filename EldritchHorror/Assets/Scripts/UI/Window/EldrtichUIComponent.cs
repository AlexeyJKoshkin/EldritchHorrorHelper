using UnityEngine;

namespace EldritchHorror.UI 
{
    public abstract class EldrtichUIComponent : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}