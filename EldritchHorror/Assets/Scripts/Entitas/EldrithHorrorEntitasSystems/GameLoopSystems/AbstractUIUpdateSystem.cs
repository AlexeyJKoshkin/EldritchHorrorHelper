#region

using EldritchHorror.UI;
using Entitas;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace EldritchHorror.EntitasSystems
{
    public abstract class AbstractUIUpdateSystem<TWindow, T> :  ICurrentWindowProvider<TWindow> where T : class, IEntity where TWindow : IEldritchWindow
    {

        TWindow ICurrentWindowProvider<TWindow>.Window => GetWindow();
        protected abstract TWindow GetWindow();

    }
}