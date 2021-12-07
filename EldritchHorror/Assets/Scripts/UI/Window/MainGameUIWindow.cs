using Sirenix.OdinInspector;
using UnityEngine;


namespace EldritchHorror.UI
{
    public class MainGameUIWindow : EldritchWindow
    {
        [SerializeField]
        public OmenViewUI OmenView;
        [SerializeField]
        public CurrentMythosDeckView MythosDeckView;
        
        [SerializeField]
        public RumorCardView[] RumorCardViews;
        
        [SerializeField]
        public MythosCardUIView PreviewCardImage;

        [Button]
        public void SetBtnEnableStateRumor(bool isEnable)
        {
            for (int i = 0; i < RumorCardViews.Length; i++)
            {
                RumorCardViews[i].Interactable = isEnable;
            }
        }
    }
}