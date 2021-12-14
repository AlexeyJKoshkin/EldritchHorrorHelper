#region

using CodeGenerator;
using System;

#endregion

namespace Editor.EldritchHorrorEditorEcosystem
{
    public interface IEldritchHorrorCodeGenerator : ICodeGenerator
    {
        Type FileType { get; }
        void GenerateToFile();
    }
}