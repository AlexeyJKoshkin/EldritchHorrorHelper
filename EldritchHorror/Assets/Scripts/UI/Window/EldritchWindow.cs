#region

using UnityEngine;

#endregion

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

    public abstract class EldritchWindow : EldrtichUIComponent, IEldritchWindow
    {
    
    }
}