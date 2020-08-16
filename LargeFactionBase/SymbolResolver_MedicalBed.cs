using System;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_MedicalBed : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
            ResolveParams resolveParams = rp;
            Action<Thing> prevPostThingSpawn = resolveParams.postThingSpawn;
            resolveParams.postThingSpawn = delegate (Thing x)
            {
                if (prevPostThingSpawn != null)
                {
                    prevPostThingSpawn(x);
                }
                Building_Bed building_Bed = x as Building_Bed;
                if (building_Bed != null)
                {
                    building_Bed.Medical = true;

                }
            };
            BaseGen.symbolStack.Push("medBed", resolveParams);
        }
    }
}
