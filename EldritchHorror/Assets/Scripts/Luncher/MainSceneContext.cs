#region

using EldritchHorror.EntitasSystems;
using Luncher;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

#endregion

namespace EldritchHorror
{
    public class MainSceneContext : EldritchHorrorSceneContext<IEldritchHorrorSceneLauncher>
    {
        protected override void LunchScene(IEldritchHorrorSceneLauncher launcher)
        {
            base.LunchScene(launcher); //тут запускаются все логические системы
            launcher.ActivateScene();
        }
    }

    public class UnitActionHandler : MonoBehaviour
    {
    }
}