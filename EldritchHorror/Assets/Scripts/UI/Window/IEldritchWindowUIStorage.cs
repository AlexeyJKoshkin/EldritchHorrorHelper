using System.Collections.Generic;

namespace EldritchHorror.UI
{
    public interface IEldritchWindowUIStorage
    {
        IReadOnlyList<IEldritchWindow> AllWindows { get; }
    }
}