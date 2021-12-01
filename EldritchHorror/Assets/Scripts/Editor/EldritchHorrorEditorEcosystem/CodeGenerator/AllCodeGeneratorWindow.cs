using Editor.EldritchHorrorEditorEcosystem;
using GameKit.Editor;
using Sirenix.Utilities;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace EldritchHorrorEditorEcosystem
{
    public class AllCodeGeneratorWindow : EditorWindow
    {
        private readonly GridSelector<IEldritchHorrorCodeGenerator> _selector;

        public AllCodeGeneratorWindow()
        {
            var codeGenerators = ReflectionHelper.GetAllTypesInSolutionWithInterface<IEldritchHorrorCodeGenerator>()
                                                 .Select(Activator.CreateInstance)
                                                 .Cast<IEldritchHorrorCodeGenerator>()
                                                 .ToArray();
            _selector = new GridSelector<IEldritchHorrorCodeGenerator>(codeGenerators, GetContentForGenerator) {ItemDrawerCallback = DrawCodeGenerator};
        }

        public string TabName => "CodeGenerator";

        [MenuItem("Tools/Generation")]
        private static void ShowGeneratorWindow()
        {
            GetWindow<AllCodeGeneratorWindow>().Show();
        }


        private bool DrawCodeGenerator(IEldritchHorrorCodeGenerator element, int index, GUIContent name, bool isselected)
        {
            using (new GUILayout.HorizontalScope())
            {
                GUILayout.Label(name);
                if (GUILayout.Button("Generate"))
                {
                    element.GenerateToFile();
                    AssetDatabase.Refresh();
                }
            }

            return false;
        }

        private GUIContent GetContentForGenerator(IEldritchHorrorCodeGenerator value, int index)
        {
            return new GUIContent(value.FileType.Name);
        }

        private void OnGUI()
        {
            DrawTabGUI();
        }

        public void DrawTabGUI()
        {
            _selector.DoSelectGUI("All Generator");
            if (GUILayout.Button("Generate All"))
            {
                _selector.ForEach(e => e.Generate());
                AssetDatabase.Refresh();
            }
        }
    }
}