using GameKit.Editor;
using GameKit.EditorContext;
using Sirenix.OdinInspector;
using UnityEditor;


namespace EldritchHorrorEditorEcosystem
{
    public class EldritchHorrorEditorEcosystemLauncher : GameEditorLauncher<EldritchHorrorEditorEcosystem>
    {
        public IEldritchHorrorEditorEcosystem Current => IsWork ? (IEldritchHorrorEditorEcosystem) CustomGameEditor : null;
        
        [InitializeOnLoadMethod]
        static void LunchAtStart()
        {
            EditorUtils.FindAsset<EldritchHorrorEditorEcosystemLauncher>().Lunch();
        }

        [Button, ShowIf("IsWork")]
        void CreateInfrastructure()
        {
            Current.CreateInfrastructure();
        }
    }
}