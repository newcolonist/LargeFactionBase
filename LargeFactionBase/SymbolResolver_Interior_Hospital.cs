using System.Collections.Generic;
using System.Linq;
using RimWorld;
using RimWorld.BaseGen;
using Verse;
using LargeFactionBase;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Interior_Hospital : SymbolResolver
    {
        private const int FoodStockpileSize = 3;

        public override void Resolve(ResolveParams rp)
        {
            List<Thing> list = (rp.faction != null && rp.faction.def.techLevel.IsNeolithicOrWorse()) ? LargeFactionBase.LargeFactionBase_ThingSetMakerDefOf.MapGen_TribalHospitalStockpile.root.Generate() :
                LargeFactionBase.LargeFactionBase_ThingSetMakerDefOf.MapGen_HospitalStockpile.root.Generate();
            for (int i = 0; i < list.Count; i++)
            {
                ResolveParams resolveParams = rp;
                resolveParams.singleThingToSpawn = list[i];
                BaseGen.symbolStack.Push("thing", resolveParams);
            }
            
            BaseGen.symbolStack.Push("indoorLighting", rp);
            BaseGen.symbolStack.Push("indoorLighting", rp);

            InteriorSymbolResolverUtility.PushBedroomHeatersCoolersAndLightSourcesSymbols(rp, false);
            BaseGen.symbolStack.Push("medicalBed", rp);
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("medicalBed", rp);
            }
            if (Rand.Value > 0.5f)
            {
                BaseGen.symbolStack.Push("medicalBed", rp);
            }

            if (rp.faction.def.techLevel <= TechLevel.Medieval)
            {
                rp.floorDef = TerrainDefOf.MetalTile;
            }
            else
            {
                rp.floorDef = LargeFactionBase.Large_DefOf.SterileTile;
            }

            BaseGen.symbolStack.Push("floor", rp);

        }
    }
}