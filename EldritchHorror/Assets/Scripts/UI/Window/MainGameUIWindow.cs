#region

using Entitas;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using Zenject;

#endregion

namespace EldritchHorror.UI
{
    public class MainGameUIWindow : EldritchWindow
    {
        [Inject] private EldritchCardContext _eldritchCardContext;
        [SerializeField] public CurrentCardDeckView MythosDeckView;
        [SerializeField] public OmenViewUI OmenView;
        [SerializeField] public EndrithCardUIView PreviewCardImage;
        [SerializeField] public RumorCardView[] RumorCardViews;
        [SerializeField] private TextMeshProUGUI _turnCounter;
        
        [FoldoutGroup("Control Panels")]
        [SerializeField] public MythosPhaseControlPanelUI MythosPhaseControlPanel;
        [FoldoutGroup("Control Panels")]
        [SerializeField] public EncountersPanelView EncountersPanelView;

       public int TurnCounter
        {
            set => _turnCounter.text = $"Turn {value}";
        }
       

       [Button]
        public void SetBtnEnableStateRumor(bool isEnable)
        {
            for (int i = 0; i < RumorCardViews.Length; i++) RumorCardViews[i].Interactable = isEnable;
        }


    }
}