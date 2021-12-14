using EldritchHorror.Entitas.Components;
using EldritchHorror.GameplayStateMachine;
using EldritchHorror.UI;
using Entitas;
using UnityEngine.Events;

namespace EldritchHorror.EntitasSystems {
    public class MasterRolePlayerUILayoutHandler : AbstractRolePlayerUILayoutHandler
    {
        private MythosPhaseControlPanelUI MythosPhaseControlPanel => Window.MythosPhaseControlPanel;
        private readonly IEldritchOmen _omen;
        public MasterRolePlayerUILayoutHandler(Contexts context, IEldritchOmen omen) : base(context)
        {
            _omen = omen;
        }

        protected override void UpdateGeneralGameStateUI(GameLoopEntity entity, int index, IComponent component)
        {
            switch (index)
            {
                case GameLoopComponentsLookup.OmenState : MythosPhaseControlPanel.OmenStateSelector.SetValueWithoutNotify(_omen.Position);
                    break;
            }
        }
        

        public override void ExitMythosPhase(GameLoopEntity stateEntity)
        {
            MythosPhaseControlPanel.Hide();
            MythosPhaseControlPanel.OmenStateSelector.onValueChanged.RemoveListener(_omen.SetTo);
            MythosPhaseControlPanel.EndTurnBtn.onClick.RemoveAllListeners();
        }

        public override void EnterMythosPhase(GameLoopEntity stateEntity)
        {
            MythosPhaseControlPanel.Show();
            MythosPhaseControlPanel.OmenStateSelector.onValueChanged.AddListener(_omen.SetTo);
            MythosPhaseControlPanel.EndTurnBtn.onClick.AddListener(()=>stateEntity.isPhaseReady = true);
        }

    }
}