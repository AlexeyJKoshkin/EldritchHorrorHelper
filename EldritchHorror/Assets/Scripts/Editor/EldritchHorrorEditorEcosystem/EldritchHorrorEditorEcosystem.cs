using EldritchHorror;
using EldritchHorror.Core;
using System;
using UnityEngine;

namespace EldritchHorrorEditorEcosystem
{
    public class EldritchHorrorEditorEcosystem : IEldritchHorrorEditorEcosystem
    {
        private readonly EldritchHorrorEditorEcosystemGuiDrawer _gui;

        public EldritchHorrorEditorEcosystem(IEldritchHorrorEditorEcosystemGUI[] gui)
        {

            _gui = new EldritchHorrorEditorEcosystemGuiDrawer(gui, this);
        }

        public event Action OnFinishWorkingEvent;


        public void StartWork()
        {
            Debug.LogError("Start Editor Eco System");
        }

        public void StopWork()
        {
            Debug.LogError("StopWork World");
            OnFinishWorkingEvent?.Invoke();
        }

        public void DrawGUI()
        {
            _gui.DrawGUI();
        }
    }
}