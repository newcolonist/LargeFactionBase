using System.Collections.Generic;
using System.Linq;
using RimWorld;
using RimWorld.BaseGen;
using Verse;
using LargeFactionBase;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Interior_PrisonCell3 : SymbolResolver
    {
        private const int FoodStockpileSize = 3;

        public override void Resolve(ResolveParams rp)
        {
            ThingSetMakerParams value = default(ThingSetMakerParams);
            value.techLevel = new TechLevel?((rp.faction == null) ? TechLevel.Spacer : rp.faction.def.techLevel);
            ResolveParams resolveParams = rp;
            resolveParams.thingSetMakerDef = ThingSetMakerDefOf.MapGen_PrisonCellStockpile;
            resolveParams.thingSetMakerParams = new ThingSetMakerParams?(value);
            resolveParams.innerStockpileSize = new int?(3);
            BaseGen.symbolStack.Push("innerStockpile", resolveParams);

            InteriorSymbolResolverUtility.PushBedroomHeatersCoolersAndLightSourcesSymbols(rp, false);
            BaseGen.symbolStack.Push("prisonerBed", rp);
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("prisonerBed", rp);
            }
            BaseGen.symbolStack.Push("prisonFilth", rp);

            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("prisonerBed", rp);
            }

            BaseGen.symbolStack.Push("prisonFilth", rp);
            BaseGen.symbolStack.Push("prisonFilth", rp);

            }
                /*BaseGen.symbolStack.Push("corpse", rp);
                BaseGen.symbolStack.Push("corpse", rp);
                BaseGen.symbolStack.Push("corpse", rp);
                if (Rand.Value > 0.5f)
                {
                    BaseGen.symbolStack.Push("corpse", rp);
                }
                if (Rand.Value > 0.5f)
                {
                    BaseGen.symbolStack.Push("corpse", rp);
                }
                if (Rand.Value > 0.5f)
                {
                    BaseGen.symbolStack.Push("corpse", rp);
                }*/

            }
}
