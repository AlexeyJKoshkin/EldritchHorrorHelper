using EldritchHorror.Data.Provider;
using System;

namespace EldritchHorror.Cards
{
    public class GameVersionHolder : DataBox<GameBoxDef>
    {
    }

    [Flags]
    public enum GameVersion
    {
        None = 0,
        BaseBox = 1 << 1,
        Forgotten = 1 << 2
    }
}