using RimWorld;
using RimWorld.BaseGen;
using System;
using Verse;

namespace LargeFactionBase
{
    public class SymbolResolver_EdgeShields2 : SymbolResolver
    {
        public override bool CanResolve(ResolveParams rp)
        {
            return base.CanResolve(rp);
        }

        public override void Resolve(ResolveParams rp)
        {
            Map map = BaseGen.globalSettings.map;
            CellRect rect = rp.rect;
            if (rp.wallStuff == null)
            {
                rp.wallStuff = BaseGenUtility.RandomCheapWallStuff(Faction.OfPlayer, false);
            }
            int num = 1;
            foreach (IntVec3 current in rect.EdgeCells)
            {
                ThingDef thingDef = ThingDefOf.Wall;
                Thing thing = ThingMaker.MakeThing(thingDef, rp.wallStuff);
                if (num % 3 == 0)
                {
                    thingDef = ThingDefOf.Sandbags;
                    thing = ThingMaker.MakeThing(thingDef, null);
                }
                num++;
                GenSpawn.Spawn(thing, current, map);
            }
        }
    }
}

