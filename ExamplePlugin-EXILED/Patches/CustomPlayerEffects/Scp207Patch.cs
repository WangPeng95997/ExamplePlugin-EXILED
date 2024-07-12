using System.Collections.Generic;
using System.Reflection.Emit;
using CustomPlayerEffects;
using NorthwoodLib.Pools;
using HarmonyLib;

namespace ExamplePlugin.Patches.CustomPlayerEffects
{
    // SCP-207不掉血补丁
    [HarmonyPatch(typeof(Scp207), nameof(Scp207.OnTick))]
    internal static class OnTickPatch
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Shared.Rent(instructions);

            newInstructions.Clear();
            newInstructions.Add(new CodeInstruction(OpCodes.Ret));

            for (int z = 0; z < newInstructions.Count; z++)
                yield return newInstructions[z];

            ListPool<CodeInstruction>.Shared.Return(newInstructions);
        }
    }
}