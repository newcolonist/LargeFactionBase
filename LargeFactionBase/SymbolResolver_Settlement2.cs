using System;
using Verse;
using Verse.AI.Group;
using RimWorld;
using RimWorld.BaseGen;

namespace LargeFactionBase
{
    public class SymbolResolver_Settlement2 : SymbolResolver
    {
        public static readonly FloatRange DefaultPawnsPoints = new FloatRange(1150f, 1600f);

        public override void Resolve(ResolveParams rp)
        {
            //SymbolResolver_Settlement2.resolveParams settlementPawnGroupPoints = new SymbolResolver_Settlement2.ResolveParams();

            Map map = BaseGen.globalSettings.map;
            Faction faction = rp.faction ?? Find.FactionManager.RandomEnemyFaction(false, false, true, TechLevel.Undefined);
            int num = 0;
            int? edgeDefenseWidth = rp.edgeDefenseWidth;
            if (edgeDefenseWidth.HasValue)
            {
                num = rp.edgeDefenseWidth.Value;
            }
            else if (rp.rect.Width >= 20 && rp.rect.Height >= 20 && (faction.def.techLevel >= TechLevel.Industrial || Rand.Bool))
            {
                num = ((!Rand.Bool) ? 4 : 2);
            }
            float num2 = (float)rp.rect.Area / 144f * 0.17f;
            BaseGen.globalSettings.minEmptyNodes = ((num2 >= 1f) ? GenMath.RoundRandom(num2) : 0);
            Lord singlePawnLord2 = rp.singlePawnLord ?? LordMaker.MakeNewLord(faction, new LordJob_DefendBase2(faction, rp.rect.CenterCell), map, null);
            Lord singlePawnLord3 = rp.singlePawnLord ?? LordMaker.MakeNewLord(faction, new LordJob_DefendBase3(faction, rp.rect.CenterCell), map, null);

            TraverseParms traverseParms = TraverseParms.For(TraverseMode.PassDoors, Danger.Deadly, false);

            if (Rand.Value > 0.5f)
            {
                ResolveParams resolveParams = rp;
                resolveParams.rect = rp.rect.ExpandedBy(12);
                resolveParams.faction = faction;
                resolveParams.thingSetMakerDef = LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile3;
                resolveParams.singlePawnLord = singlePawnLord3;
                resolveParams.pawnGroupKindDef = (rp.pawnGroupKindDef ?? PawnGroupKindDefOf.Settlement);
                resolveParams.singlePawnSpawnCellExtraPredicate = (rp.singlePawnSpawnCellExtraPredicate ?? ((IntVec3 x) => map.reachability.CanReachMapEdge(x, traverseParms)));
                if (resolveParams.pawnGroupMakerParams == null)
                {
                    resolveParams.pawnGroupMakerParams = new PawnGroupMakerParms();
                    resolveParams.pawnGroupMakerParams.tile = map.Tile;
                    resolveParams.pawnGroupMakerParams.faction = faction;
                    PawnGroupMakerParms pawnGroupMakerParms = resolveParams.pawnGroupMakerParams;
                    float? settlementPawnGroupPoints = rp.settlementPawnGroupPoints;
                    resolveParams.pawnGroupMakerParams.points = ((!settlementPawnGroupPoints.HasValue) ? SymbolResolver_Settlement.DefaultPawnsPoints.RandomInRange : settlementPawnGroupPoints.Value) / 2;
                    resolveParams.pawnGroupMakerParams.inhabitants = true;
                    resolveParams.pawnGroupMakerParams.seed = rp.settlementPawnGroupSeed;
                }
                BaseGen.symbolStack.Push("pawnGroup", resolveParams);

                ResolveParams resolveParams8 = rp;
                resolveParams8.rect = rp.rect.ExpandedBy(12);
                resolveParams8.faction = faction;
                resolveParams8.thingSetMakerDef = LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile3;
                resolveParams8.singlePawnLord = singlePawnLord2;
                resolveParams8.pawnGroupKindDef = (rp.pawnGroupKindDef ?? PawnGroupKindDefOf.Combat);
                resolveParams8.singlePawnSpawnCellExtraPredicate = (rp.singlePawnSpawnCellExtraPredicate ?? ((IntVec3 x) => map.reachability.CanReachMapEdge(x, traverseParms)));
                if (resolveParams8.pawnGroupMakerParams == null)
                {
                    resolveParams8.pawnGroupMakerParams = new PawnGroupMakerParms();
                    resolveParams8.pawnGroupMakerParams.tile = map.Tile;
                    resolveParams8.pawnGroupMakerParams.faction = faction;
                    PawnGroupMakerParms pawnGroupMakerParms = resolveParams8.pawnGroupMakerParams;
                    float? settlementPawnGroupPoints = rp.settlementPawnGroupPoints;
                    resolveParams8.pawnGroupMakerParams.points = ((!settlementPawnGroupPoints.HasValue) ? SymbolResolver_Settlement.DefaultPawnsPoints.RandomInRange : settlementPawnGroupPoints.Value) / 2;
                    resolveParams8.pawnGroupMakerParams.inhabitants = true;
                    resolveParams8.pawnGroupMakerParams.seed = rp.settlementPawnGroupSeed;
                }
                BaseGen.symbolStack.Push("pawnGroup", resolveParams8);
            }
            else
            {
                ResolveParams resolveParams = rp;
                resolveParams.rect = rp.rect.ExpandedBy(12);
                resolveParams.faction = faction;
                resolveParams.thingSetMakerDef = LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile3;
                resolveParams.singlePawnLord = singlePawnLord2;
                resolveParams.pawnGroupKindDef = (rp.pawnGroupKindDef ?? PawnGroupKindDefOf.Settlement);
                resolveParams.singlePawnSpawnCellExtraPredicate = (rp.singlePawnSpawnCellExtraPredicate ?? ((IntVec3 x) => map.reachability.CanReachMapEdge(x, traverseParms)));
                if (resolveParams.pawnGroupMakerParams == null)
                {
                    resolveParams.pawnGroupMakerParams = new PawnGroupMakerParms();
                    resolveParams.pawnGroupMakerParams.tile = map.Tile;
                    resolveParams.pawnGroupMakerParams.faction = faction;
                    PawnGroupMakerParms pawnGroupMakerParms = resolveParams.pawnGroupMakerParams;
                    float? settlementPawnGroupPoints = rp.settlementPawnGroupPoints;
                    resolveParams.pawnGroupMakerParams.points = ((!settlementPawnGroupPoints.HasValue) ? SymbolResolver_Settlement.DefaultPawnsPoints.RandomInRange : settlementPawnGroupPoints.Value);
                    resolveParams.pawnGroupMakerParams.inhabitants = true;
                    resolveParams.pawnGroupMakerParams.seed = rp.settlementPawnGroupSeed;
                }
                BaseGen.symbolStack.Push("pawnGroup", resolveParams);
            }
            /*ResolveParams resolveParams7 = rp;
            resolveParams7.rect = rp.rect.ExpandedBy(12);
            resolveParams7.faction = faction;
            resolveParams7.thingSetMakerDef = LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile3;
            resolveParams7.singlePawnLord = singlePawnLord3;
            resolveParams7.pawnGroupKindDef = (rp.pawnGroupKindDef ?? PawnGroupKindDefOf.Trader);
            resolveParams7.singlePawnSpawnCellExtraPredicate = (rp.singlePawnSpawnCellExtraPredicate ?? ((IntVec3 x) => map.reachability.CanReachMapEdge(x, traverseParms)));
            if (resolveParams7.pawnGroupMakerParams == null)
            {
                resolveParams7.pawnGroupMakerParams = new PawnGroupMakerParms();
                resolveParams7.pawnGroupMakerParams.tile = map.Tile;
                resolveParams7.pawnGroupMakerParams.faction = faction;
                PawnGroupMakerParms pawnGroupMakerParms = resolveParams7.pawnGroupMakerParams;
                float? settlementPawnGroupPoints = rp.settlementPawnGroupPoints;
                resolveParams7.pawnGroupMakerParams.points = (float)Rand.Range(35, 90);
                resolveParams7.pawnGroupMakerParams.inhabitants = true;
                resolveParams7.pawnGroupMakerParams.seed = rp.settlementPawnGroupSeed;
            }
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("pawnGroup", resolveParams7);
            }
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("pawnGroup", resolveParams7);
            }
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("pawnGroup", resolveParams7);
            }*/

            BaseGen.symbolStack.Push("outdoorLighting", rp);
            if (faction.def.techLevel >= TechLevel.Industrial)
            {
                int num3 = (!Rand.Chance(0.75f)) ? 0 : GenMath.RoundRandom((float)rp.rect.Area / 400f);
                for (int i = 0; i < num3; i++)
                {
                    ResolveParams resolveParams2 = rp;
                    resolveParams2.faction = faction;
                    BaseGen.symbolStack.Push("firefoamPopper", resolveParams2);
                }
            }
            if (num > 0)
            {
                ResolveParams resolveParams3 = rp;
                resolveParams3.faction = faction;
                resolveParams3.edgeDefenseWidth = new int?(num);
                BaseGen.symbolStack.Push("edgeDefense2", resolveParams3);
            }
            ResolveParams resolveParams4 = rp;
            resolveParams4.rect = rp.rect.ContractedBy(num);
            resolveParams4.faction = faction;
            BaseGen.symbolStack.Push("ensureCanReachMapEdge", resolveParams4);
            ResolveParams resolveParams5 = rp;
            resolveParams5.rect = rp.rect.ContractedBy(num);
            resolveParams5.faction = faction;
            BaseGen.symbolStack.Push("basePart_outdoors", resolveParams5);
            ResolveParams resolveParams6 = rp;
            resolveParams6.floorDef = TerrainDefOf.Bridge;
            bool? floorOnlyIfTerrainSupports = rp.floorOnlyIfTerrainSupports;
            resolveParams6.floorOnlyIfTerrainSupports = new bool?(!floorOnlyIfTerrainSupports.HasValue || floorOnlyIfTerrainSupports.Value);
            BaseGen.symbolStack.Push("floor", resolveParams6);
        }
    }
}
