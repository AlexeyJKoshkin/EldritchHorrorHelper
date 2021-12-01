using CodeGenerator;
using System;

namespace Editor.EldritchHorrorEditorEcosystem
{
    public interface IEldritchHorrorCodeGenerator : ICodeGenerator
    {
        Type FileType { get; }
        void GenerateToFile();
    }
}