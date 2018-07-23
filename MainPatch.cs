using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using System.Reflection;

namespace CustomLoadScreen
{
    public static class Entry
    {
        public static void Patch()
        {
            HarmonyInstance.Create("customload").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
