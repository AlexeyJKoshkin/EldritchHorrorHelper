using EldritchHorror.GameplayStateMachine;
using EldritchHorror.UI;
using Luncher;
using Sirenix.OdinInspector;
using UnityEngine;

namespace EldritchHorror
{
    public class MainSceneContext : EldritchHorrorSceneContext<IEldritchHorrorEntitasRuntimeSystemBuilder>
    {
        private MythosPhase _mythosPhase;
        [SerializeField, ReadOnly]
        private bool _isEnter;
        
        protected override void LunchScene(IEldritchHorrorEntitasRuntimeSystemBuilder launcher)
        {
            base.LunchScene(launcher);
            //((EldritchWindowUIProvider) Container.Resolve<IEldritchWindowUIProvider>()).Storage = _uiStorage;
            _mythosPhase = Container.Resolve<IMainGamePlayState>() as MythosPhase;
        }

        [Button, ShowIf("_isEnter")]
        void Exit()
        {
            if(!_isEnter) return;
                _mythosPhase.Exit();
                _isEnter = false;
        }

        [Button, HideIf("_isEnter", true)]
        void Enter()
        {
            if(_isEnter) return;
            _mythosPhase.Enter();
            _isEnter = true;
        }
    }
}