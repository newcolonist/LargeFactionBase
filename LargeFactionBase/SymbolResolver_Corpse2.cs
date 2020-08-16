using System;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Corpse2 : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            //ThingDef singleThingDef = rp.singleThingDef ?? Rand.Element<ThingDef>(ThingDefOf.Bed, ThingDefOf.Bedroll, ThingDefOf.SleepingSpot);
            //PawnKindDef kind = PawnKindDefOf.WildMan;
            PawnKindDef kind = PawnKindDefOf.Colonist;
            Faction faction = rp.faction;

            //1.0
            //PawnGenerationRequest request = new PawnGenerationRequest(kind, faction,
            //    PawnGenerationContext.NonPlayer, BaseGen.globalSettings?.map?.Tile ?? Find.CurrentMap.Tile, false, false, false, false, true, true, 1f, false, true, false,
            //    false, false, false, false, null, null, null, null, null, null, null);

            PawnGenerationRequest request = new PawnGenerationRequest(faction.RandomPawnKind(), faction, PawnGenerationContext.NonPlayer, -1, false, false, false, false, true, true, 1f, false, true, true, true, false, false, false, false, 0f, null, 1f, null, null, null, null, null, null, null, null, null, null, null, null);

            Pawn pawn = PawnGenerator.GeneratePawn(request);
            IntVec3 spawnLoc;
            var map = BaseGen.globalSettings?.map ?? Find.CurrentMap;
            CellFinderLoose.TryGetRandomCellWith((x => x.IsValid && rp.rect.Contains(x) && x.GetEdifice(map) == null && x.GetFirstItem(map) == null),
                map, 100, out spawnLoc);
            GenSpawn.Spawn(pawn, spawnLoc, map);
            pawn.Kill(null);
            if (pawn?.Corpse is Corpse c && c.TryGetComp<CompRottable>() is CompRottable comp)
            {
                int n = Rand.Range(0, 5);
                float m = Rand.Range(0.8f, 1.2f);
                c.Age += GenDate.TicksPerDay * n;
                //Log.Message("Rotted corpse");
                //comp.RotProgress += 9999999;
                comp.RotProgress += Rand.Range(8000, 12000) * n * m;
            }
        }
    }
}