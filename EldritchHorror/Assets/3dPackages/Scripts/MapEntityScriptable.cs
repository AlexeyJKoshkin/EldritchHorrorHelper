using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Tst
{
    [CreateAssetMenu]
    public class MapEntityScriptable : ScriptableObject
    {
        [SerializeReference]
        List<IComponent> _components = new List<IComponent>();
    }

}