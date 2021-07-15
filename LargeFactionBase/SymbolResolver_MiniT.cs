using System;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_MiniT : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            ThingDef singleThingDef = (rp.faction != null && rp.faction.def.techLevel.IsNeolithicOrWorse()) ?
                rp.singleThingDef ?? Rand.Element<ThingDef>(ThingDefOf.Filth_Blood, ThingDefOf.Filth_CorpseBile, ThingDefOf.Filth_DriedBlood) :
                rp.singleThingDef ?? Rand.Element<ThingDef>(ThingDefOf.Turret_MiniTurret, ThingDefOf.Filth_DriedBlood);
            ResolveParams resolveParams = rp;
            resolveParams.singleThingDef = singleThingDef;
            bool? skipSingleThingIfHasToWipeBuildingOrDoesntFit = rp.skipSingleThingIfHasToWipeBuildingOrDoesntFit;
            resolveParams.skipSingleThingIfHasToWipeBuildingOrDoesntFit = new bool?(!skipSingleThingIfHasToWipeBuildingOrDoesntFit.HasValue || skipSingleThingIfHasToWipeBuildingOrDoesntFit.Value);
            BaseGen.symbolStack.Push("thing", resolveParams);
        }
    }
}