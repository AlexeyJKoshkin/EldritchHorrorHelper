#region

using System.Collections.Generic;
using System.Linq;
using GameKit.EditorContext;
using UnityEngine;

#endregion

namespace EldritchHorrorEditorEcosystem
{
    public class EldritchHorrorEditorEcosystemLauncher : GameEditorLauncher<EldritchHorrorEditorEcosystem,DiContainerWrapper >
    {
        public IEldritchHorrorEditorEcosystem Current => IsWork ? (IEldritchHorrorEditorEcosystem) CustomGameEditor : null;
        
        [SerializeField] private List<BaseCustomEditorInstaller> _editorInstallers;

        protected override void Binding(DiContainerWrapper diContainer)
        {
            foreach (var installer in _editorInstallers.Where(o => o != null))
            {
                installer.Initialize(diContainer.Container);
                installer.InstallBindings();
            }
        }
    }
}