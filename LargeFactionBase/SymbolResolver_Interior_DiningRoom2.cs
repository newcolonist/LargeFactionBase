﻿using System;
using UnityEngine;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_Interior_DiningRoom2 : SymbolResolver
    {
        public override void Resolve(ResolveParams rp)
        {
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
                ResolveParams resolveParams = rp;
                resolveParams.singleThingDef = ThingDefOf.Table2x2c;
                BaseGen.symbolStack.Push("thing", resolveParams);
            }
        }
    }
}
