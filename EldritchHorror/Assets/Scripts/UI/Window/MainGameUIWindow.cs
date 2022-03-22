using EldritchHorror.Entitas.Components;
using Entitas;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using Zenject;


namespace EldritchHorror.UI
{
    public class MainGameUIWindow : EldritchWindow
    {
        [Inject] private EldritchCardContext _eldritchCardContext;

        private EntityUIBinder<GameLoopEntity> _entityUiBinder;

        /// <summary>
        ///     Панель с событиями
        /// </summary>
        [FoldoutGroup("Control Panels"), SerializeField]
        private GameMasterCardDeckPanelView _gameMasterCardDeckPanelView;
        [FoldoutGroup("Control Panels"), SerializeField]
        public MythosPhaseControlPanelUI MythosPhaseControlPanel;
        
        [SerializeField] private TextMeshProUGUI _turnCounter;

        /// <summary>
        /// </summary>
        [SerializeField] public OmenViewUI OmenView;
        [SerializeField] public EndrithCardUIView PreviewCardImage;
        [SerializeField] public RumorCardView[] RumorCardViews;

        public int TurnCounter
        {
            set => _turnCounter.text = $"Turn {value}";
        }


        [Button]
        public void SetBtnEnableStateRumor(bool isEnable)
        {
            for (int i = 0; i < RumorCardViews.Length; i++) RumorCardViews[i].Interactable = isEnable;
        }

        public void SubScribeMasterEntityEvents(GameLoopEntity masterEntityEntity)
        {
            _entityUiBinder = new EntityUIBinder<GameLoopEntity>(OnUpdateMainEntity, OnSetEntity, null);
            _entityUiBinder.Bind(masterEntityEntity);
        }

        private void OnUpdateMainEntity(IEntity e, int index, IComponent component)
        {
            switch (index)
            {
                case GameLoopComponentsLookup.OmenState:
                    OmenView.CurrentPlace = ((OmenStateComponent) component).CurrentState;
                    return;
                case GameLoopComponentsLookup.TurnCounter:
                    TurnCounter = ((TurnCounterComponent) component).Turn;
                    return;
            }

            _gameMasterCardDeckPanelView.TryUpdateDeckView((GameLoopEntity) e, index);
        }

        private void OnSetEntity()
        {
            var e = _entityUiBinder.Current;
            _gameMasterCardDeckPanelView.UpdateAllDeck(e);
        }
    }
}