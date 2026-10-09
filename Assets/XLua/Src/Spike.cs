using System;

namespace XLua
{
    /// <summary>
    /// Minimal IL2CPP glue probe. It is the smallest surface that exercises both generated-code
    /// directions: Lua calling a C# static method (LuaCallCSharp) and C# calling a Lua function as a
    /// delegate (CSharpCallLua). Under IL2CPP these need generated wrappers; under the Editor they
    /// work through reflection. Keep this tiny — it is a build-time proof, not a feature.
    /// </summary>
    public static class Spike
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Apply(Func<int, int> f)
        {
            return f(21);
        }
    }
}
