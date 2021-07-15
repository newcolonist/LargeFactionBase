using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Interior_DiningRoom2 : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            /*ThingSetMakerParams value = default(ThingSetMakerParams);
            value.techLevel = new TechLevel?((rp.faction == null) ? TechLevel.Spacer : rp.faction.def.techLevel);
            ResolveParams resolveParams = rp;
            resolveParams.thingSetMakerDef = LargeFactionBase.LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile3;
            resolveParams.thingSetMakerParams = new ThingSetMakerParams?(value);
            resolveParams.innerStockpileSize = new int?(6);
            BaseGen.symbolStack.Push("innerStockpile", resolveParams);*/ //2021-07-15

            BaseGen.symbolStack.Push("indoorLighting", rp);
            BaseGen.symbolStack.Push("randomlyPlaceDrugOnTables", rp);
            BaseGen.symbolStack.Push("randomlyPlaceJointOnTables", rp);
            BaseGen.symbolStack.Push("randomlyPlaceDrugOnTables", rp);
            BaseGen.symbolStack.Push("randomlyPlaceJointOnTables", rp);
            BaseGen.symbolStack.Push("randomlyPlaceHumanMeat", rp);
            BaseGen.symbolStack.Push("placeHumanLeatherArmchair", rp);

            int num = Mathf.Max(GenMath.RoundRandom((float)rp.rect.Area / 20f), 1);
            for (int i = 0; i < num; i++)
            {
                ResolveParams resolveParams3 = rp;
                resolveParams3.singleThingDef = ThingDefOf.Table2x2c;
                BaseGen.symbolStack.Push("thing", resolveParams3);
            }
        }
    }
}
