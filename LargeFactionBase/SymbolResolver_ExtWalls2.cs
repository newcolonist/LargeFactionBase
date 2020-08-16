using RimWorld;
using RimWorld.BaseGen;
using System;
using System.Linq;
using Verse;
using UnityEngine;


namespace LargeFactionBase
{
    public class SymbolResolver_ExtWalls2 : SymbolResolver
    {
        public ThingSetMakerDef thingSetMakerDef;

        public override bool CanResolve(ResolveParams rp)
        {
            return base.CanResolve(rp);
        }

        public override void Resolve(ResolveParams rp)
        {
            ThingDef thingDef = GenCollection.RandomElementByWeight<ThingDef>((from d in DefDatabase<ThingDef>.AllDefs
                                                                               where d.IsStuff && d.stuffProps.CanMake(ThingDefOf.Wall) && d.stuffProps.categories.Contains(StuffCategoryDefOf.Stony) && d != ThingDef.Named("Jade")
                                                                               select d).ToList<ThingDef>(), (ThingDef x) => 3f + 1f / x.BaseMarketValue);
            rp.wallStuff = thingDef;
            rp.floorDef = BaseGenUtility.CorrespondingTerrainDef(thingDef, true);
            CellRect cellRect = new CellRect(rp.rect.maxX, rp.rect.maxZ, 1, 1);

            ResolveParams resolveParams = rp;
            resolveParams.rect = rp.rect.ExpandedBy(9);
            BaseGen.symbolStack.Push("edgeWalls", resolveParams);
        }
    }
}


