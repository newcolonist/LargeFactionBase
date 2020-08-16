using System;
using Verse;
using RimWorld;
using LargeFactionBase;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Corpse3 : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            //ThingDef singleThingDef = rp.singleThingDef ?? Rand.Element<ThingDef>(ThingDefOf.Bed, ThingDefOf.Bedroll, ThingDefOf.SleepingSpot);

            //PawnKindDef kind = (rp.faction != null && rp.faction.def.techLevel.IsNeolithicOrWorse()) ? (Rand.Chance(0.5f) ? LargeFactionBase.Large_PawnKindDefOf.Tribal_ChiefMelee :

            PawnKindDef kind = (rp.faction != null && rp.faction.def.techLevel < TechLevel.Industrial) ? (Rand.Chance(0.5f) ? LargeFactionBase.Large_PawnKindDefOf.Tribal_ChiefMelee :
                LargeFactionBase.Large_PawnKindDefOf.Tribal_HeavyArcher)
                : LargeFactionBase.Large_PawnKindDefOf.Soldier;
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
            HealthUtility.DamageUntilDowned(pawn, false);
            HealthUtility.DamageLegsUntilIncapableOfMoving(pawn, false);
        }
    }
}