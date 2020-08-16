using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using RimWorld.BaseGen;

namespace LargeFactionBase
{
    public class SymbolResolver_EdgeGrain : SymbolResolver
    {
        private static readonly IntRange LineLengthRange = new IntRange(1, 1);

        private static readonly IntRange GapLengthRange = new IntRange(12, 16);

        public override void Resolve(ResolveParams rp)
        {
            Map map = BaseGen.globalSettings.map;
            int num = 0;
            int num2 = 0;
            int num3 = -1;
            if (rp.rect.EdgeCellsCount < (SymbolResolver_EdgeGrain.LineLengthRange.max + SymbolResolver_EdgeGrain.GapLengthRange.max) * 2)
            {
                num = rp.rect.EdgeCellsCount;
            }
            else if (Rand.Bool)
            {
                num = SymbolResolver_EdgeGrain.LineLengthRange.RandomInRange;
            }
            else
            {
                num2 = SymbolResolver_EdgeGrain.GapLengthRange.RandomInRange;
            }
            foreach (IntVec3 current in rp.rect.EdgeCells)
            {
                num3++;
                if (num2 > 0)
                {
                    num2--;
                    if (num2 == 0)
                    {
                        if (num3 == rp.rect.EdgeCellsCount - 2)
                        {
                            num2 = 1;
                        }
                        else
                        {
                            num = SymbolResolver_EdgeGrain.LineLengthRange.RandomInRange;
                        }
                    }
                }
                else if (current.Standable(map) && !current.Roofed(map) && current.SupportsStructureType(map, ThingDefOf.Sandbags.terrainAffordanceNeeded))
                {
                    if (!GenSpawn.WouldWipeAnythingWith(current, Rot4.North, ThingDefOf.Sandbags, map, (Thing x) => x.def.category == ThingCategory.Building || x.def.category == ThingCategory.Item))
                    {
                        if (num > 0)
                        {
                            num--;
                            if (num == 0)
                            {
                                num2 = SymbolResolver_EdgeGrain.GapLengthRange.RandomInRange;
                            }
                        }
                        if (Rand.Chance(0.2f))
                        {
                            Thing thing = ThingMaker.MakeThing(Large_DefOf.TrapIED_HighExplosive, null);
                            thing.SetFaction(rp.faction, null);
                            GenSpawn.Spawn(thing, current, map, WipeMode.Vanish);
                        }
                        else
                        {
                            if (Rand.Chance(0.2f))
                            {
                                Thing thing = ThingMaker.MakeThing(Large_DefOf.TrapIED_Incendiary, null);
                                thing.SetFaction(rp.faction, null);
                                GenSpawn.Spawn(thing, current, map, WipeMode.Vanish);
                            }
                            else
                            {
                                Thing thing = ThingMaker.MakeThing(Large_DefOf.TrapIED_AntigrainWarhead_Large, null);
                                thing.SetFaction(rp.faction, null);
                                GenSpawn.Spawn(thing, current, map, WipeMode.Vanish);

                            }
                        }
                    }
                }
            }
        }
    }
}
