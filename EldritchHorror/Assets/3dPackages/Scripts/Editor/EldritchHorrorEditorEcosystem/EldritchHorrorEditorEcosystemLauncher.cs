using GameKit.Editor;
using GameKit.EditorContext;
using UnityEditor;


namespace EldritchHorrorEditorEcosystem
{
    public class EldritchHorrorEditorEcosystemLauncher : GameEditorLauncher<EldritchHorrorEditorEcosystem>
    {
        public IEldritchHorrorEditorEcosystem Current => IsWork ? (IEldritchHorrorEditorEcosystem) CustomGameEditor : null;
        
        [InitializeOnLoadMethod]
        static void LunchAtStart()
        {
            if(EditorApplication.isPlaying) return;
            EditorUtils.FindAsset<EldritchHorrorEditorEcosystemLauncher>().Lunch();
        }
    }
}