using System;
using UnityEngine;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Interior_BatteryRoom2 : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            BaseGen.symbolStack.Push("indoorLighting", rp);
            BaseGen.symbolStack.Push("chargeBatteries2", rp);
            ResolveParams resolveParams2 = rp;
            resolveParams2.singleThingDef = ThingDefOf.Battery;
            resolveParams2.thingRot = new Rot4?((!Rand.Bool) ? Rot4.East : Rot4.North);
            int? fillWithThingsPadding = rp.fillWithThingsPadding;
            resolveParams2.fillWithThingsPadding = new int?((!fillWithThingsPadding.HasValue) ? 1 : fillWithThingsPadding.Value);
            BaseGen.symbolStack.Push("fillWithThings", resolveParams2);
        }
    }
}

