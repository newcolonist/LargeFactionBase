using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld.BaseGen;
using RimWorld.Planet;
using Verse;

namespace LargeFactionBase
{
    public class GenStep_LargeFactionBase : GenStep
    {
        public FloatRange defaultPawnGroupPointsRange = SymbolResolver_Settlement2.DefaultPawnsPoints;
        
        private static List<CellRect> possibleRects = new List<CellRect>();

        public override int SeedPart
        {
            get
            {
                return 1806208471;
            }
        }

        bool flag;
        bool flag2;

        public override void Generate(Map map, GenStepParams parms)
        {
            CellRect rectToDefend;
            if (!MapGenerator.TryGetVar<CellRect>("RectOfInterest", out rectToDefend))
            {
                rectToDefend = CellRect.SingleCell(map.Center);
            }
            Faction faction;
            if (map.ParentFaction == null || map.ParentFaction == Faction.OfPlayer)
            {
                faction = Find.FactionManager.RandomEnemyFaction(false, false, true, TechLevel.Undefined);
            }
            else
            {
                faction = map.ParentFaction;
            }
            ResolveParams resolveParams = default(ResolveParams);
            resolveParams.rect = this.GetOutpostRect(rectToDefend, map);
            resolveParams.faction = faction;
            resolveParams.edgeDefenseWidth = new int?(4);
            resolveParams.thingSetMakerDef = LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile3;

            float num = GenDate.DaysPassed;
            float num7 = Mathf.Pow(num / 2f, 0.45f);
            int i = Mathf.FloorToInt(num7*1.5f);
            int j = Mathf.Min(Mathf.FloorToInt(num7 / 1.5f),5);
            int k = Mathf.Max(1, Mathf.FloorToInt(num7/1.5f));
            int l = Mathf.Max(1, Mathf.FloorToInt(num7/2.5f));
            resolveParams.edgeDefenseTurretsCount = new int?(Rand.RangeInclusive(k, i));
            resolveParams.edgeDefenseMortarsCount = new int?(Rand.RangeInclusive(l, j));

            float num2 = Mathf.Pow(num / 12f, 0.3f) *0.6f;
            float num3 = Mathf.Pow(num / 12f, 0.36f);
            float num6 = Mathf.Max(Rand.Range(num3, num2),1f);

            //difficulty setting
            float num8 = Mathf.Min(Find.Storyteller.difficulty.threatScale / 2.2f, 1);

            //cycles
            //trend
            float num9 = Find.StoryWatcher.statsRecord.numThreatBigs / 20f;
            float num10 = 0.4f * (Mathf.Pow(num9, 4f) / (1 + Mathf.Pow(num9, 4f)));

            //interference
            float num11 = GenDate.DaysPassed;
            int num16 = Find.World.info.persistentRandomValue;
            float num12 = Mathf.Sin(num11 / 10f + num16 / 2f);
            float num19 = num12 + 1f;

            float num13 = Find.StoryWatcher.statsRecord.numThreatBigs;
            float num14 = Mathf.Sin((num11 / 10f) * (num11 / num13) / 21.2f + num16);

            float num15 = Mathf.Abs(num14 * num19);
            float num18 = Mathf.Min(num15, 0.8f);

            //coeff
            float num17 = num10 * num18 + 0.85f;

                resolveParams.settlementPawnGroupPoints = new float?(this.defaultPawnGroupPointsRange.RandomInRange * num8 * num6 * num17);


            BaseGen.globalSettings.map = map;
            //BaseGen.globalSettings.minBuildings = 1;
            //BaseGen.globalSettings.minBarracks = 0;
            //BaseGen.globalSettings.basePart_emptyNodesResolved = 0;
            //BaseGen.globalSettings.basePart_barracksResolved = 1;
            //BaseGen.globalSettings.basePart_breweriesCoverage = 0.05f;
            //BaseGen.globalSettings.basePart_batteriesCoverage = 0.12f;
            //BaseGen.globalSettings.basePart_farmsCoverage = 0.5f;

            //permutation push pour salle centrale

            BaseGen.symbolStack.Push("settlement2", resolveParams);

            /*ResolveParams corpsesEverywhere = resolveParams;
            //corpsesEverywhere.rect = dragonRoomRect.ContractedBy(1);
            corpsesEverywhere.hivesCount = Rand.Range(12, 18);
            corpsesEverywhere.faction = Find.FactionManager.RandomEnemyFaction();
            BaseGen.symbolStack.Push("corpseMaker", corpsesEverywhere);*/

            ResolveParams resolveParams2 = default(ResolveParams);
            resolveParams2.rect = resolveParams.rect.ExpandedBy(20);

             int world = Find.World.info.persistentRandomValue;
            //int tile = Mathf.FloorToInt(Find.CurrentMap.TileInfo.elevation);
            int tile = Mathf.FloorToInt(Find.CurrentMap.TileInfo.temperature);
            //int tile = Find.CurrentMap.info.parent.ID;
            //int tile= Find.CurrentMap.ConstantRandSeed;
            int ent = Mathf.FloorToInt((tile + world) / 10f);
             int roll = (tile + world) - ent * 10;
             float rollwall = roll / 10f;

            float rnd = Rand.Value;
            //Random.Range(0f,1f);

            //if (rnd < 0.5f & resolveParams.faction.def.techLevel > TechLevel.Medieval)
                if (rollwall < 0.5f & resolveParams.faction.def.techLevel > TechLevel.Medieval)
                {
                BaseGen.symbolStack.Push("extWalls", resolveParams2);

                CellRect rect = resolveParams2.rect.ContractedBy(4);
                int width;
                width = Mathf.Clamp(rect.Width, 1, Mathf.Min(rect.Width, rect.Height) / 2);

                {
                    ResolveParams rp3 = resolveParams2;
                    rp3.faction = faction;
                    rp3.rect = rect;
                    BaseGen.symbolStack.Push("edgeGrain", rp3);

                }

                for (int n = 0; n < num7 * 2; n++)
                {


                    ResolveParams rp7 = resolveParams2;
                    rp7.rect = resolveParams2.rect.ContractedBy(20);
                    //BaseGen.symbolStack.Push("interior_storage2", rp7);

                    rp7.faction = faction;

                    rp7.singleThingDef = ThingDefOf.Turret_MiniTurret;

                    if (Rand.Chance(0.1f))
                    {
                        rp7.singleThingDef = Large_DefOf.Turret_Sniper;
                    }

                    if (Rand.Chance(0.1f))
                    {
                        rp7.singleThingDef = Large_DefOf.Turret_Autocannon;
                    }

                    rp7.rect = rp7.rect.ExpandedBy(16);
                    bool? edgeThingAvoidOtherEdgeThings = resolveParams2.edgeThingAvoidOtherEdgeThings;
                    rp7.edgeThingAvoidOtherEdgeThings = new bool?(!edgeThingAvoidOtherEdgeThings.HasValue || edgeThingAvoidOtherEdgeThings.Value);
                    BaseGen.symbolStack.Push("edgeThing", rp7);

                }
            }

            //if (rnd >= 0.5f & resolveParams.faction.def.techLevel > TechLevel.Medieval)
                if (rollwall >= 0.5f & resolveParams.faction.def.techLevel > TechLevel.Medieval)
                {
                CellRect rect = resolveParams2.rect.ExpandedBy(1);
                int width;
                width = Mathf.Clamp(rect.Width, 1, Mathf.Min(rect.Width, rect.Height) / 2);

                {
                    ResolveParams rp3 = resolveParams2;
                    rp3.faction = faction;
                    rp3.rect = rect;
                    BaseGen.symbolStack.Push("edgeIED", rp3);

                }

                for (int m = 0; m < width; m++)
                {
                    if (m % 2 == 0)
                    {
                        ResolveParams rp3 = resolveParams2;
                        rp3.faction = faction;
                        rp3.rect = rect;
                        BaseGen.symbolStack.Push("edgeWalls2", rp3);
                        if (!flag)
                        {
                            break;
                        }
                    }
                }

                CellRect rect4 = resolveParams2.rect.ContractedBy(1);
                int width2;
                width2 = Mathf.Clamp(rect4.Width, 1, Mathf.Min(rect4.Width, rect4.Height) / 2);

                {
                    ResolveParams rp3 = resolveParams2;
                    rp3.faction = faction;
                    rp3.rect = rect4;
                    BaseGen.symbolStack.Push("edgeIED", rp3);

                }

                for (int m = 0; m < width; m++)
                {
                    if (m % 2 == 0)
                    {
                        ResolveParams rp3 = resolveParams2;
                        rp3.faction = faction;
                        rp3.rect = rect4;
                        BaseGen.symbolStack.Push("edgeWalls2", rp3);
                        if (!flag)
                        {
                            break;
                        }
                    }
                }

                CellRect rect5 = resolveParams2.rect.ContractedBy(3);
                int width3;
                width3 = Mathf.Clamp(rect5.Width, 1, Mathf.Min(rect5.Width, rect5.Height) / 2);

                {
                    ResolveParams rp3 = resolveParams2;
                    rp3.faction = faction;
                    rp3.rect = rect5;
                    BaseGen.symbolStack.Push("edgeIED", rp3);

                }

                for (int m = 0; m < width; m++)
                {
                    if (m % 2 == 0)
                    {
                        ResolveParams rp3 = resolveParams2;
                        rp3.faction = faction;
                        rp3.rect = rect5;
                        BaseGen.symbolStack.Push("edgeWalls2", rp3);
                        if (!flag)
                        {
                            break;
                        }
                    }
                }

                CellRect rect2 = resolveParams2.rect.ContractedBy(17);
                ResolveParams rp4 = resolveParams2;
                rp4.faction = faction;
                rp4.rect = rect2;
                BaseGen.symbolStack.Push("edgeSandbags", rp4);

                CellRect rect3 = (!flag2) ? rect.ContractedBy(19) : rect;
                for (int n = 0; n < num7 * 2; n++)
                {
                    /*ResolveParams rp5 = resolveParams2;
                    rp5.faction = faction;

                    rp5.singleThingDef = ThingDefOf.Turret_MiniTurret;

                    if (Rand.Chance(0.1f))
                    {
                        rp5.singleThingDef = Large_DefOf.Turret_Sniper;
                    }

                    if (Rand.Chance(0.1f))
                    {
                        rp5.singleThingDef = Large_DefOf.Turret_Autocannon;
                    }

                    rp5.rect = rect3;
                    bool? edgeThingAvoidOtherEdgeThings = resolveParams2.edgeThingAvoidOtherEdgeThings;
                    rp5.edgeThingAvoidOtherEdgeThings = new bool?(!edgeThingAvoidOtherEdgeThings.HasValue || edgeThingAvoidOtherEdgeThings.Value);
                    BaseGen.symbolStack.Push("edgeThing", rp5);*/

                    ResolveParams rp6 = resolveParams2;
                    rp6.rect = resolveParams2.rect.ContractedBy(24);
                    //BaseGen.symbolStack.Push("interior_storage2", rp6);
                    //BaseGen.symbolStack.Push("extWalls2", resolveParams2);
                }
            }

            //if (rnd < 0.7f & resolveParams.faction.def.techLevel <= TechLevel.Medieval)
                if (rollwall < 0.7f & resolveParams.faction.def.techLevel <= TechLevel.Medieval)
                //else
                {

                    CellRect rect = resolveParams2.rect.ExpandedBy(1);
                    int width;
                    width = Mathf.Clamp(rect.Width, 1, Mathf.Min(rect.Width, rect.Height) / 2);

                    {
                        ResolveParams rp3 = resolveParams2;
                        rp3.faction = faction;
                        rp3.rect = rect;
                        BaseGen.symbolStack.Push("edgeSpikes", rp3);

                    }

                    for (int m = 0; m < width; m++)
                    {
                        if (m % 2 == 0)
                        {
                            ResolveParams rp3 = resolveParams2;
                            rp3.faction = faction;
                            rp3.rect = rect;
                            BaseGen.symbolStack.Push("edgeWalls2", rp3);
                            if (!flag)
                            {
                                break;
                            }
                        }
                    }

                    CellRect rect4 = resolveParams2.rect.ContractedBy(1);
                    int width2;
                    width2 = Mathf.Clamp(rect4.Width, 1, Mathf.Min(rect4.Width, rect4.Height) / 2);

                    {
                        ResolveParams rp3 = resolveParams2;
                        rp3.faction = faction;
                        rp3.rect = rect4;
                        BaseGen.symbolStack.Push("edgeSpikes", rp3);

                    }

                    for (int m = 0; m < width; m++)
                    {
                        if (m % 2 == 0)
                        {
                            ResolveParams rp3 = resolveParams2;
                            rp3.faction = faction;
                            rp3.rect = rect4;
                            BaseGen.symbolStack.Push("edgeWalls2", rp3);
                            if (!flag)
                            {
                                break;
                            }
                        }
                    }

                    CellRect rect5 = resolveParams2.rect.ContractedBy(3);
                    int width3;
                    width3 = Mathf.Clamp(rect5.Width, 1, Mathf.Min(rect5.Width, rect5.Height) / 2);

                    {
                        ResolveParams rp3 = resolveParams2;
                        rp3.faction = faction;
                        rp3.rect = rect5;
                        BaseGen.symbolStack.Push("edgeSpikes", rp3);

                    }

                    for (int m = 0; m < width; m++)
                    {
                        if (m % 2 == 0)
                        {
                            ResolveParams rp3 = resolveParams2;
                            rp3.faction = faction;
                            rp3.rect = rect5;
                            BaseGen.symbolStack.Push("edgeWalls2", rp3);
                            if (!flag)
                            {
                                break;
                            }
                        }
                    }
               
                    /*CellRect rect2 = resolveParams2.rect.ContractedBy(17);
                    ResolveParams rp4 = resolveParams2;
                    rp4.faction = faction;
                    rp4.rect = rect2;
                    BaseGen.symbolStack.Push("edgeSandbags", rp4);*/

                /*if (resolveParams.faction.def.techLevel > TechLevel.Medieval)
                {
                    CellRect rect3 = (!flag2) ? rect.ContractedBy(19) : rect;
                    for (int n = 0; n < num7 * 2; n++)
                    {*/
                        /*ResolveParams rp5 = resolveParams2;
                        rp5.faction = faction;

                        rp5.singleThingDef = ThingDefOf.Turret_MiniTurret;

                        if (Rand.Chance(0.15f))
                        {
                            rp5.singleThingDef = Large_DefOf.Turret_Sniper;
                        }

                        if (Rand.Chance(0.2f))
                        {
                            rp5.singleThingDef = Large_DefOf.Turret_Autocannon;
                        }

                        rp5.rect = rect3;
                        bool? edgeThingAvoidOtherEdgeThings = resolveParams2.edgeThingAvoidOtherEdgeThings;
                        rp5.edgeThingAvoidOtherEdgeThings = new bool?(!edgeThingAvoidOtherEdgeThings.HasValue || edgeThingAvoidOtherEdgeThings.Value);
                        BaseGen.symbolStack.Push("edgeThing", rp5);*/

                        //ResolveParams rp6 = resolveParams2;
                        //rp6.rect = resolveParams2.rect.ContractedBy(24);
                        //BaseGen.symbolStack.Push("interior_storage2", rp6);
                        //BaseGen.symbolStack.Push("extWalls2", resolveParams2);
                    //}
                //}
            }

            //if (rnd >= 0.7f & resolveParams.faction.def.techLevel <= TechLevel.Medieval)
                if (rollwall >= 0.7f & resolveParams.faction.def.techLevel <= TechLevel.Medieval)
                {

                CellRect rect = resolveParams2.rect.ExpandedBy(1);
                int width;
                width = Mathf.Clamp(rect.Width, 1, Mathf.Min(rect.Width, rect.Height) / 2);

                {
                    ResolveParams rp3 = resolveParams2;
                    rp3.faction = faction;
                    rp3.rect = rect;
                    BaseGen.symbolStack.Push("edgeSpikes2", rp3);

                }

                CellRect rect4 = resolveParams2.rect.ContractedBy(1);
                int width2;
                width2 = Mathf.Clamp(rect4.Width, 1, Mathf.Min(rect4.Width, rect4.Height) / 2);

                {
                    ResolveParams rp3 = resolveParams2;
                    rp3.faction = faction;
                    rp3.rect = rect4;
                    BaseGen.symbolStack.Push("edgeSpikes2", rp3);

                }

                CellRect rect5 = resolveParams2.rect.ContractedBy(3);
                int width3;
                width3 = Mathf.Clamp(rect5.Width, 1, Mathf.Min(rect5.Width, rect5.Height) / 2);

                {
                    ResolveParams rp3 = resolveParams2;
                    rp3.faction = faction;
                    rp3.rect = rect5;
                    BaseGen.symbolStack.Push("edgeSpikes2", rp3);

                }

                CellRect rect6 = resolveParams2.rect.ContractedBy(5);
                int width4;
                width4 = Mathf.Clamp(rect6.Width, 1, Mathf.Min(rect6.Width, rect6.Height) / 2);

                {
                    ResolveParams rp3 = resolveParams2;
                    rp3.faction = faction;
                    rp3.rect = rect6;
                    BaseGen.symbolStack.Push("edgeSpikes2", rp3);

                }

                CellRect rect7 = resolveParams2.rect.ContractedBy(7);
                int width5;
                width5 = Mathf.Clamp(rect7.Width, 1, Mathf.Min(rect7.Width, rect7.Height) / 2);

                {
                    ResolveParams rp3 = resolveParams2;
                    rp3.faction = faction;
                    rp3.rect = rect7;
                    BaseGen.symbolStack.Push("edgeSpikes2", rp3);

                }

                CellRect rect8 = resolveParams2.rect.ContractedBy(9);
                int width6;
                width6 = Mathf.Clamp(rect8.Width, 1, Mathf.Min(rect8.Width, rect8.Height) / 2);

                {
                    ResolveParams rp3 = resolveParams2;
                    rp3.faction = faction;
                    rp3.rect = rect8;
                    BaseGen.symbolStack.Push("edgeSpikes2", rp3);

                }

                CellRect rect9 = resolveParams2.rect.ContractedBy(11);
                int width7;
                width7 = Mathf.Clamp(rect9.Width, 1, Mathf.Min(rect9.Width, rect9.Height) / 2);

                {
                    ResolveParams rp3 = resolveParams2;
                    rp3.faction = faction;
                    rp3.rect = rect9;
                    BaseGen.symbolStack.Push("edgeSpikes2", rp3);

                }

            }
            BaseGen.Generate();
        }

       private CellRect GetOutpostRect(CellRect rectToDefend, Map map)
        {
            //float num4 = GenDate.DaysPassed;
            
            // version github
            float num4 = Mathf.Min(GenDate.DaysPassed, 120);

            float num = 1f + (num4 / 300f);
            //float num2 = Mathf.Pow(num, 0.7f);
            float num3 = Mathf.Min(2f, num);
            float rawsize = num3 * 48f;
            int size = Mathf.FloorToInt(rawsize);
            int half = Mathf.FloorToInt(rawsize / 2);
            GenStep_LargeFactionBase.possibleRects.Add(new CellRect(rectToDefend.minX - 1 - size, rectToDefend.CenterCell.z - half, size, size));
            GenStep_LargeFactionBase.possibleRects.Add(new CellRect(rectToDefend.maxX + 1, rectToDefend.CenterCell.z - half, size, size));
            GenStep_LargeFactionBase.possibleRects.Add(new CellRect(rectToDefend.CenterCell.x - half, rectToDefend.minZ - 1 - half, size, size));
            GenStep_LargeFactionBase.possibleRects.Add(new CellRect(rectToDefend.CenterCell.x - half, rectToDefend.maxZ + 1, size, size));
            CellRect mapRect = new CellRect(0, 0, map.Size.x, map.Size.z);
            GenStep_LargeFactionBase.possibleRects.RemoveAll((CellRect x) => !x.FullyContainedWithin(mapRect));
            if (GenStep_LargeFactionBase.possibleRects.Any<CellRect>())
            {
                return GenStep_LargeFactionBase.possibleRects.RandomElement<CellRect>();
            }
            return rectToDefend;
        }
    }
}

