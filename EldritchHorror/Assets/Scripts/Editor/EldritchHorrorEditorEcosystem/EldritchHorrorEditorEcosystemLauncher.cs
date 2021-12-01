using GameKit.EditorContext;
using Sirenix.OdinInspector;


namespace EldritchHorrorEditorEcosystem
{
    public class EldritchHorrorEditorEcosystemLauncher : GameEditorLauncher<EldritchHorrorEditorEcosystem>
    {
        public IEldritchHorrorEditorEcosystem Current => IsWork ? (IEldritchHorrorEditorEcosystem) CustomGameEditor : null;
    }
}