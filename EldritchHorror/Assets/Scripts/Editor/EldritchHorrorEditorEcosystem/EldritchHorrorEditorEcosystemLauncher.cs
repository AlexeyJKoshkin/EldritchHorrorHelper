#region

using GameKit.EditorContext;

#endregion

namespace EldritchHorrorEditorEcosystem
{
    public class EldritchHorrorEditorEcosystemLauncher : GameEditorLauncher<EldritchHorrorEditorEcosystem>
    {
        public IEldritchHorrorEditorEcosystem Current => IsWork ? (IEldritchHorrorEditorEcosystem) CustomGameEditor : null;
    }
}