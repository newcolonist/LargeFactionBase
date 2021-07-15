using System;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Corpse : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {

            var count = rp.hivesCount ?? 10;

            for (int i = 0; i < count; i++)
            {
                //ThingDef singleThingDef = rp.singleThingDef ?? Rand.Element<ThingDef>(ThingDefOf.Bed, ThingDefOf.Bedroll, ThingDefOf.SleepingSpot);
                //PawnKindDef kind = (Rand.Value > 0.7f) ? ((Rand.Value > 0.7f) ? PawnKindDefOf.SpaceRefugee : PawnKindDefOf.AncientSoldier) : PawnKindDefOf.Slave;

                PawnKindDef kind = PawnKindDefOf.Slave;

                Faction faction = rp.faction;
                //1.0 PawnGenerationRequest request = new PawnGenerationRequest(kind, faction, PawnGenerationContext.NonPlayer, BaseGen.globalSettings?.map?.Tile ?? Find.CurrentMap.Tile, false, false, false, false, true, true, 1f, false, true, false, false, false, false, false, null, null, null, null, null, null, null);
                //1.2 PawnGenerationRequest request = new PawnGenerationRequest(kind, faction, PawnGenerationContext.NonPlayer, -1, false, false, false, false, true, true, 1f, false, true, true, true, false, false, false, false, 0f, null, 1f, null, null, null, null, null, null, null, null, null, null, null, null);

                PawnGenerationRequest request = new PawnGenerationRequest(kind, // KindDef
                    faction, //Faction
                    PawnGenerationContext.NonPlayer,  //Context 
                    -1, //Tile
                    false, //ForceGenerateNewPawn
                    false, //Newborn
                    false, //AllowDead 
                    false, //AllowDowned
                    false, //CanGeneratePawnRelations
                    true, //MustBeCapaleOfViolence 
                    1f, //ColonistRelationChanceFactor
                    true, // ForceAddFreeWarmLayerIfNeeded
                    true, //AllowGay 
                    true, //AllowFood
                    true, //AllowAddiction
                    false, //Inhabitant
                    false, //CertainlyBeenInCryptoSleep
                    false, //ForceRedressWorldPawnIfFormerColonist
                    false, //WorldPawnFactionDoesntMatter
                    0f, //BioCodeWeaponChance
                    0f, //BioCodeApparelChance
                    null, //ExtraPawnForExtraRelationChance 
                    1f, //RelationWithExtraPawn
                    null, //ValidatorPreGear 
                    null, //ValidatorPostGear
                    null, //forcedTraits  
                    null, //ProhibitedTraits
                    null, //minChanceToRedressWorldPawn 
                    null, //FixedBiologicalAge
                    null, //FixedChronologicalAge
                    null, //FixedGender
                    null, //FixedMelanin
                    null, //FixedLastName
                    null, //FixedBirthName
                    null, //FixedTitle
                    null, //FixedIdeo
                    false, //ForceNoIdeo
                    false, //FordeNoBackstory
                    false //ForbidAnyTitle
                    );

                Pawn pawn = PawnGenerator.GeneratePawn(request);
                IntVec3 spawnLoc;
                //CellFinder.TryFindBestPawnStandCell(pawn, out spawnLoc);
                var map = BaseGen.globalSettings?.map ?? Find.CurrentMap;

                CellFinderLoose.TryGetRandomCellWith((x => x.IsValid && rp.rect.Contains(x) && x.GetEdifice(map) == null && x.GetFirstItem(map) == null),
                    map, 100000, out spawnLoc);

                GenSpawn.Spawn(pawn, spawnLoc, map);

                pawn.Kill(null);

                if (pawn?.Corpse is Corpse c && c.TryGetComp<CompRottable>() is CompRottable comp)
                {
                    int n = Rand.Range(0, 45);
                    float m = Rand.Range(0.75f, 1.25f);
                    c.Age += GenDate.TicksPerDay * n;
                    //Log.Message("Rotted corpse");
                    //comp.RotProgress += 9999999;
                    comp.RotProgress += Rand.Range(8000, 12000) * n * m;
                }
            }
        }


        private bool IsWallOrRock(Building b)
        {
            return b != null && (b.def == ThingDefOf.Wall || b.def.building.isNaturalRock);
        }
    }
}
