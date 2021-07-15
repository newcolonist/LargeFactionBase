using System.Collections.Generic;
using System.Linq;
using RimWorld;
using RimWorld.BaseGen;
using Verse;
using LargeFactionBase;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Interior_PrisonCell2 : SymbolResolver
    {
        private const int FoodStockpileSize = 3;

        public override void Resolve(ResolveParams rp)
        {
            ThingSetMakerParams value = default(ThingSetMakerParams);
            value.techLevel = new TechLevel?((rp.faction == null) ? TechLevel.Spacer : rp.faction.def.techLevel);
            ResolveParams resolveParams = rp;
            resolveParams.thingSetMakerDef = LargeFactionBase.LargeFactionBase_ThingSetMakerDefOf.MapGen_PrisonCellStockpile2;
            resolveParams.thingSetMakerParams = new ThingSetMakerParams?(value);
            resolveParams.innerStockpileSize = new int?(3);
            BaseGen.symbolStack.Push("innerStockpile", resolveParams);
            BaseGen.symbolStack.Push("indoorLighting", rp);
            InteriorSymbolResolverUtility.PushBedroomHeatersCoolersAndLightSourcesSymbols(rp, false);
            BaseGen.symbolStack.Push("medicalPrisonerBed", rp);
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("medicalPrisonerBed", rp);
            }
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("medicalPrisonerBed", rp);
            }
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("medicalPrisonerBed", rp);
            }

            /*BaseGen.symbolStack.Push("corpse2", rp);
            BaseGen.symbolStack.Push("corpse2", rp);
            BaseGen.symbolStack.Push("corpse2", rp);
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("corpse2", rp);
            }
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("corpse2", rp);
            }
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("corpse2", rp);
            }*/
            BaseGen.symbolStack.Push("prisonDefense", rp);
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("prisonDefense", rp);
            }
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("prisonDefense", rp);
            }
        }
    }
}

