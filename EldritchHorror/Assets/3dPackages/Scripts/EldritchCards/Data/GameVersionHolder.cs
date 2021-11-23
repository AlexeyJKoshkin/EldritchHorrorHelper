using EldritchHorror.Data.Provider;
using System;

namespace Editor.EldrtichHorrorEditorEcosystem.EldritchCards
{
    public class GameVersionHolder : DataBox<GamePartSO>
    {
    }

    [Flags]
    public enum GameVersion
    {
        None = 0,
        BaseBox = 1<<1,
        Forgotten = 1<<2
    }
}