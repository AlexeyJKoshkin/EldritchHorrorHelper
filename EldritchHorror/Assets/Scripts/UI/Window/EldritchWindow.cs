using UnityEngine;

namespace EldritchHorror.UI
{
    public abstract class EldritchWindow : MonoBehaviour, IEldritchWindow
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