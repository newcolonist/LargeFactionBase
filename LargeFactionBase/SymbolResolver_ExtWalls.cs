using RimWorld;
using RimWorld.BaseGen;
using System;
using System.Linq;
using Verse;
using UnityEngine;


namespace LargeFactionBase
{
    public class SymbolResolver_ExtWalls : SymbolResolver
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

            ResolveParams resolveParams21;
            ResolveParams resolveParams20;
            ResolveParams resolveParams10;
            ResolveParams resolveParams9;
            ResolveParams resolveParams8;
            ResolveParams resolveParams7 = resolveParams8 = (resolveParams9 = (resolveParams10 = (resolveParams20 = (resolveParams21 = rp))));

            CellRect cellRect = new CellRect(rp.rect.maxX, rp.rect.maxZ, 1, 1);
            resolveParams8.rect = cellRect.ExpandedBy(6);


            CellRect cellRect2 = new CellRect(rp.rect.minX, rp.rect.maxZ, 1, 1);
            resolveParams7.rect = cellRect2.ExpandedBy(6);

            CellRect cellRect3 = new CellRect(rp.rect.maxX, rp.rect.minZ, 1, 1);
            resolveParams9.rect = cellRect3.ExpandedBy(6);

            CellRect cellRect4 = new CellRect(rp.rect.minX, rp.rect.minZ, 1, 1);
            resolveParams10.rect = cellRect4.ExpandedBy(6);


            /*resolveParams21.rect = rp.rect.ContractedBy(12);
            CellRect cellRect6 = new CellRect(resolveParams21.rect.CenterCell.x, resolveParams21.rect.CenterCell.z, 1, 1);
            float num = 1f + GenDate.DaysPassed / 240;
            float num2 = Mathf.Pow(num, 0.8f);
            float num3 = Mathf.Min(2f, num2);
            int factor = Mathf.FloorToInt(num3 * 18);
            resolveParams21.rect = cellRect6.ExpandedBy(factor);

            resolveParams20.rect = rp.rect.ContractedBy(18);
            float val = UnityEngine.Random.Range(0f, 1f);
            int height = Mathf.FloorToInt(  val * resolveParams20.rect.Height);

            if (!Rand.Chance(0.5f))
            {
                CellRect cellRect5 = new CellRect(resolveParams20.rect.minX, resolveParams20.rect.minZ + height, 1, 1);

                //CellRect cellRect5 = new CellRect(resolveParams20.rect.CenterCell.x, resolveParams20.rect.CenterCell.z, 1, 1);
                int factor2 = Mathf.FloorToInt(num2 * 2);
                resolveParams20.rect = cellRect5.ExpandedBy(factor2);

                //resolveParams20.thingSetMakerDef = LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile2;
                //resolveParams20.innerStockpileSize = new int?(8);
                //------------------------------------------central room


                ResolveParams resolveParams22 = resolveParams20;
                BaseGen.symbolStack.Push("edgeWalls", resolveParams22);

                TerrainDef floorDef = rp.floorDef ?? BaseGenUtility.CorrespondingTerrainDef(thingDef, true);
                ResolveParams resolveParams = rp;
                resolveParams.rect = resolveParams20.rect;
                resolveParams.floorDef = floorDef;
                BaseGen.symbolStack.Push("floor", resolveParams);

                resolveParams20.thingSetMakerDef = (this.thingSetMakerDef ?? LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile2);
                resolveParams20.rect = resolveParams20.rect.ContractedBy(1);
                //BaseGen.symbolStack.Push("interior_storage2", resolveParams20);
                BaseGen.symbolStack.Push("stockpile2", resolveParams20);
            }
            else

            {
                CellRect cellRect5 = new CellRect(resolveParams20.rect.minX, resolveParams20.rect.minZ + height, 1, 1);

                //CellRect cellRect5 = new CellRect(resolveParams20.rect.CenterCell.x, resolveParams20.rect.CenterCell.z, 1, 1);
                int factor2 = Mathf.FloorToInt(num2 * 2);
                resolveParams20.rect = cellRect5.ExpandedBy(factor2);

                //resolveParams20.thingSetMakerDef = LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile2;
                //resolveParams20.innerStockpileSize = new int?(8);
                //------------------------------------------central room

                ResolveParams resolveParams22 = resolveParams20;
                BaseGen.symbolStack.Push("edgeWalls", resolveParams22);

                TerrainDef floorDef = rp.floorDef ?? BaseGenUtility.CorrespondingTerrainDef(thingDef, true);
                ResolveParams resolveParams = rp;
                resolveParams.rect = resolveParams20.rect;
                resolveParams.floorDef = floorDef;
                BaseGen.symbolStack.Push("floor", resolveParams);

                resolveParams20.thingSetMakerDef = (this.thingSetMakerDef ?? LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile2);
                resolveParams20.rect = resolveParams20.rect.ContractedBy(1);
                //BaseGen.symbolStack.Push("interior_storage2", resolveParams20);
                BaseGen.symbolStack.Push("stockpile2", resolveParams20);

            }*/

            /*resolveParams8.SetCustom<char[]>("hasDoor", new char[]
            {
                'S',
                'W'
            }, true);
            resolveParams7.SetCustom<char[]>("hasDoor", new char[]
            {
                'S',
                'E'
            }, true);
            resolveParams9.SetCustom<char[]>("hasDoor", new char[]
            {
                'N',
                'W'
            }, true);
            resolveParams10.SetCustom<char[]>("hasDoor", new char[]
            {
                'N',
                'E'
            }, true);*/

            //--------------------------------
            //BaseGen.symbolStack.Push("clear", resolveParams2);

            /*ThingSetMakerParams value = default(ThingSetMakerParams);
            float num4 = GenDate.DaysPassed / 6;
            float num5 = Mathf.Pow(num4, 0.45f);
            int i = Mathf.FloorToInt(num5);
            int premax = Mathf.Max(3, i);
            int max = Mathf.Min(10, premax);
            parms.countRange = new IntRange(max, max);
            parms.totalMarketValueRange = new FloatRange(max * 1000f, max * 2000f);*/
            //resolveParams21.thingSetMakerDef = (this.thingSetMakerDef ?? ThingSetMakerDefOf.Reward_ItemStashQuestContents);
            //resolveParams21.thingSetMakerDef = LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile2;
            //resolveParams21.thingSetMakerParams = new ThingSetMakerParams?(value);
            //resolveParams21.innerStockpileSize = new int?(8);
            // BaseGen.symbolStack.Push("emptyRoom", resolveParams21);
            //BaseGen.symbolStack.Push("interior_storage", resolveParams21);

            //nombre d'item dispersés
            /*float no = GenDate.DaysPassed / 6;
            float no2 = Mathf.Pow(no, 0.45f);
            int i = Mathf.FloorToInt(2*no2);
            int premax = Mathf.Max(3, i);
            int max = Mathf.Min(16, premax);

            resolveParams21.thingSetMakerDef = LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile2;
            resolveParams21.thingSetMakerParams = new ThingSetMakerParams?(new ThingSetMakerParams
            {
            //countRange = new IntRange(max, premax);
            //parms.totalMarketValueRange = new FloatRange(max * 1000f, max * 2000f);*/
            /*countRange = new IntRange?(new IntRange(premax,max)),
            maxThingMarketValue = new float?((float)Rand.Range(10000, 30000))
            });
            resolveParams21.singleThingStackCount = new int?(250);
            BaseGen.symbolStack.Push("stockpile", resolveParams21);*/

            //BaseGen.symbolStack.Push("emptyRoom", resolveParams20);
            //BaseGen.symbolStack.Push("storage", resolveParams20);
            /*foreach (IntVec3 current in resolveParams20.rect)
            {
                if (s.Chance(this.density))
                {
                    Thing thing = source.RandomElement<StockGenerator>().GenerateThings(s.map.Tile).FirstOrDefault<Thing>();
                    if (thing != null)
                    {
                        if (thing.stackCount > thing.def.stackLimit)
                        {
                            thing.stackCount = s.RandInclusive(1, thing.def.stackLimit);
                        }
                        GenSpawn.Spawn(thing, current, s.map, WipeMode.Vanish);
                        Pawn pawn;
                        if ((pawn = (thing as Pawn)) != null)
                        {
                            if (pawn.guest == null)
                            {
                                pawn.guest = new Pawn_GuestTracker(pawn);
                            }
                            pawn.guest.SetGuestStatus(s.map.ParentFaction, true);
                        }
                        else
                        {
                            thing.SetOwnedByCity(true, null);
                        }
                    }
                }
            };*/


            ResolveParams resolveParams11 = rp;
            resolveParams11.rect = resolveParams11.rect.ContractedBy(2);

            {
                BaseGen.symbolStack.Push("edgeWalls", resolveParams8);
                ResolveParams resolveParams82 = resolveParams8;
                resolveParams82.rect = resolveParams8.rect.ContractedBy(1); 
                BaseGen.symbolStack.Push("edgeWalls", resolveParams82);
                ResolveParams resolveParams83 = resolveParams8;
                resolveParams83.rect = resolveParams8.rect.ContractedBy(2);
                BaseGen.symbolStack.Push("edgWalls", resolveParams83);

                //ResolveParams resolveParams84 = resolveParams8;
                //resolveParams84.rect = resolveParams8.rect.ContractedBy(3);
                float rnd1 = Rand.Value;
                if (rnd1 < 0.2f)
                {
                    BaseGen.symbolStack.Push("prisonCell", resolveParams83);
                }
                else if (rnd1 >= 0.2f && rnd1 < 0.55f)
                {
                    BaseGen.symbolStack.Push("prisonCell2", resolveParams83);
                }
                else if (rnd1 >= 0.55f && rnd1 < 0.9f)
                {
                    BaseGen.symbolStack.Push("prisonCell3", resolveParams83);
                }
                else
                {
                    BaseGen.symbolStack.Push("storage2", resolveParams83);
                }

                BaseGen.symbolStack.Push("edgeWalls", resolveParams7);
                ResolveParams resolveParams72 = resolveParams7;
                resolveParams72.rect = resolveParams7.rect.ContractedBy(1);
                BaseGen.symbolStack.Push("edgeWalls", resolveParams72);
                ResolveParams resolveParams73 = resolveParams7;
                resolveParams73.rect = resolveParams7.rect.ContractedBy(2);
                BaseGen.symbolStack.Push("edgWalls", resolveParams73);

                //ResolveParams resolveParams74 = resolveParams8;
                //resolveParams74.rect = resolveParams8.rect.ContractedBy(3);
                float rnd2 = Rand.Value;
                if (rnd2 < 0.2f)
                {
                    BaseGen.symbolStack.Push("prisonCell", resolveParams73);
                }
                else if (rnd2 >= 0.2f && rnd2 < 0.55f)
                {
                    BaseGen.symbolStack.Push("prisonCell2", resolveParams73);
                }
                else if (rnd2 >= 0.55f && rnd2 < 0.9f)
                {
                    BaseGen.symbolStack.Push("prisonCell3", resolveParams73);
                }
                else
                {
                    BaseGen.symbolStack.Push("storage2", resolveParams73);
                }

                BaseGen.symbolStack.Push("edgeWalls", resolveParams9);
                ResolveParams resolveParams92 = resolveParams9;
                resolveParams92.rect = resolveParams9.rect.ContractedBy(1);
                BaseGen.symbolStack.Push("edgeWalls", resolveParams92);
                ResolveParams resolveParams93 = resolveParams9;
                resolveParams93.rect = resolveParams9.rect.ContractedBy(2);
                float rnd3 = Rand.Value;
                if (rnd3 < 0.2f)
                {
                    BaseGen.symbolStack.Push("prisonCell", resolveParams93);
                }
                else if (rnd3 >= 0.2f && rnd3 < 0.55f)
                {
                    BaseGen.symbolStack.Push("prisonCell2", resolveParams93);
                }
                else if (rnd3 >= 0.55f && rnd3 < 0.9f)
                {
                    BaseGen.symbolStack.Push("prisonCell3", resolveParams93);
                }
                else
                {
                    BaseGen.symbolStack.Push("storage2", resolveParams93);
                }


                BaseGen.symbolStack.Push("edgeWalls", resolveParams10);
                ResolveParams resolveParams102 = resolveParams10;
                resolveParams102.rect = resolveParams10.rect.ContractedBy(1);
                BaseGen.symbolStack.Push("edgeWalls", resolveParams102);
                ResolveParams resolveParams103 = resolveParams10;
                resolveParams103.rect = resolveParams10.rect.ContractedBy(2);
                float rnd4 = Rand.Value;
                if (rnd4 < 0.2f)
                {
                    BaseGen.symbolStack.Push("prisonCell", resolveParams103);
                }
                else if (rnd4 >= 0.2f && rnd4 < 0.55f)
                {
                    BaseGen.symbolStack.Push("prisonCell2", resolveParams103);
                }
                else if (rnd4 >= 0.55f && rnd4 < 0.9f)
                {
                    BaseGen.symbolStack.Push("prisonCell3", resolveParams103);
                }
                else
                {
                    BaseGen.symbolStack.Push("storage2", resolveParams103);
                }
            }


            BaseGen.symbolStack.Push("edgeWalls3", resolveParams11);
            
                ResolveParams resolveParams15 = rp;
                resolveParams15.rect = resolveParams11.rect.ContractedBy(1);

                BaseGen.symbolStack.Push("edgeWalls3", resolveParams15);
            

            ResolveParams resolveParams12 = rp;

      
                //BaseGen.symbolStack.Push("doors", resolveParams12);
                BaseGen.symbolStack.Push("edgeWalls3", resolveParams12);
            


            ResolveParams resolveParams13 = rp;

           

                resolveParams13.rect = resolveParams12.rect.ExpandedBy(2);
                BaseGen.symbolStack.Push("edgeWalls3", resolveParams13);
            

            ResolveParams resolveParams14 = rp;


                resolveParams14.rect = resolveParams13.rect.ExpandedBy(2);
            //BaseGen.symbolStack.Push("edgeShields2", resolveParams14);       
            BaseGen.symbolStack.Push("edgeWalls3", resolveParams14);

            ResolveParams resolveParams16 = rp;
                resolveParams16.rect = cellRect.ExpandedBy(4);
                CellRect cellRect16 = new CellRect(rp.rect.minX - 4, rp.rect.minZ - 4, rp.rect.Width + 8, rp.rect.Height + 8);
                resolveParams16.rect = cellRect16;
                resolveParams16.floorDef = TerrainDefOf.Bridge;
                bool? floor16OnlyIfTerrainSupports = rp.floorOnlyIfTerrainSupports;
                resolveParams16.floorOnlyIfTerrainSupports = new bool?(!floor16OnlyIfTerrainSupports.HasValue || floor16OnlyIfTerrainSupports.Value);
                BaseGen.symbolStack.Push("floor", resolveParams16);
            
            }
    }
}


