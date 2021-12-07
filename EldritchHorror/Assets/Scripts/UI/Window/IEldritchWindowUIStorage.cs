using System.Collections.Generic;
using System.Linq;

namespace EldritchHorror.UI
{
    public interface IEldritchWindowUIStorage
    {
        IReadOnlyList<IEldritchWindow> AllWindows { get; }
    }

    public interface IEldritchWindowUIProvider
    {
        T GetWindow<T>() where T : IEldritchWindow;
    }

    public class EldritchWindowUIProvider : IEldritchWindowUIProvider
    {
        public IEldritchWindowUIStorage Storage;

        public T GetWindow<T>() where T : IEldritchWindow
        {
            if (Storage == null) return default;
            return (T) Storage.AllWindows.FirstOrDefault(o => o is T);
        }
    }
}