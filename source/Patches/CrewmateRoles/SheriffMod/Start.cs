using System;
using HarmonyLib;
using TownOfUs.Roles;

namespace TownOfUs.CrewmateRoles.SheriffMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__29), nameof(IntroCutscene._CoBegin_d__29.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__29 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Sheriff))
            {
                var sheriff = (Sheriff) role;
                sheriff.LastKilled = DateTime.UtcNow;
                sheriff.LastKilled = sheriff.LastKilled.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.SheriffKillCd);
            }
        }
    }
}