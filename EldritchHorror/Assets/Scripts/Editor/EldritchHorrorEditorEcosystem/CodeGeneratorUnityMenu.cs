#region

using CodeGenerator.EnumGenerator;
using EldritchHorror;
using GameKit.Editor;
using System;
using System.Linq;
using UnityEditor;

#endregion

namespace CodeGenerator
{
    /// <summary>
    ///     Тут описываем методы для юнити меню редактора. не надо раскидывать их по всему проекту
    /// </summary>
    internal static class CodeGeneratorUnityMenu
    {
        [MenuItem("Tools/Generate/Add Values to Enum")]
        public static void GetGenerateEnumWindow()
        {
            var window = EditorWindow.GetWindow<EnumGeneratorWindow>(true, "EnumGenerator");
            window.Show();
        }

        /// <summary>
        ///     находит все енумы с атрибутом Flags в дефолтном неймспейсе и генерирует код расширение
        ///     SetFlag, UnsetFlag ....
        /// </summary>
        [MenuItem("Tools/Generate/GenerateEnumExtension")]
        public static void GenerateEnumExtension()
        {
            var types = ReflectionHelper.GetAllTypesInSolution<Enum>()
                                        .Where(o => o.HasAttribute<FlagsAttribute>() &&
                                                    o.IsPublic &&
                                                    o.Namespace != null &&
                                                    o.Namespace.Contains(CodeGeneratorConst.DefaultNameSpace))
                                        .ToArray();
            var generator = new EnumExtensionGenerator(types);

            GeneratorUtils.WriteCode(typeof(EldritchEnumExtension).Name, generator);
        }
    }
}