using System;
using System.Collections.Generic;
using XLua;
using CSObjectWrapEditor;

/// <summary>
/// IL2CPP glue config for the SalvagePursuit fork.
///
/// Two jobs:
/// 1. Redirect generated code into the xLua assembly. The generator's default output is the project
///    root (Assets/XLua/Gen), which compiles into Assembly-CSharp; its wrappers reference xLua
///    internals (objectCasters, getTypeId) and fail there. Pointing GenPath under Src/ (covered by
///    xLua.asmdef) puts the generated code in the same assembly as the internals it uses.
/// 2. List the types that need generated wrappers: XLua.Spike (Lua calls C#) and Func&lt;int,int&gt;
///    (C# calls a Lua function as a delegate).
///
/// Regenerate with the XLua/Generate Code menu after any xLua update.
/// </summary>
static class SpikeConfig
{
    [GenPath]
    public static string genPath = "Assets/Submodules/xLua/Assets/XLua/Src/Gen";

    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp = new List<Type>
    {
        typeof(XLua.Spike),
    };

    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>
    {
        typeof(Func<int, int>),
    };
}
