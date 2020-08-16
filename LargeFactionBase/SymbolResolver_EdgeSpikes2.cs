using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using RimWorld.BaseGen;

namespace LargeFactionBase
{
    public class SymbolResolver_EdgeSpikes2 : SymbolResolver
    {
        private static readonly IntRange LineLengthRange = new IntRange(1, 1);

        private static readonly IntRange GapLengthRange = new IntRange(2, 8);

        public override void Resolve(ResolveParams rp)
        {
            Map map = BaseGen.globalSettings.map;
            int num = 0;
            int num2 = 0;
            int num3 = -1;
            if (rp.rect.EdgeCellsCount < (SymbolResolver_EdgeSpikes2.LineLengthRange.max + SymbolResolver_EdgeSpikes2.GapLengthRange.max) * 2)
            {
                num = rp.rect.EdgeCellsCount;
            }
            else if (Rand.Bool)
            {
                num = SymbolResolver_EdgeSpikes2.LineLengthRange.RandomInRange;
            }
            else
            {
                num2 = SymbolResolver_EdgeSpikes2.GapLengthRange.RandomInRange;
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
                            num = SymbolResolver_EdgeSpikes2.LineLengthRange.RandomInRange;
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
                                num2 = SymbolResolver_EdgeSpikes2.GapLengthRange.RandomInRange;
                            }
                        }
                        Thing thing = ThingMaker.MakeThing(ThingDefOf.TrapSpike, ThingDefOf.WoodLog);
                        thing.SetFaction(rp.faction, null);
                        GenSpawn.Spawn(thing, current, map, WipeMode.Vanish);
                    }
                }
            }
        }
    }
}

