using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld.BaseGen;
using RimWorld;

namespace LargeFactionBase
{
    public class SymbolResolver_Stockpile2 : SymbolResolver
    {
        private List<IntVec3> cells = new List<IntVec3>();

        private const float FreeCellsFraction = 0.05f;

        public override void Resolve(ResolveParams rp)
        {
            Map map = BaseGen.globalSettings.map;
            if (rp.stockpileConcreteContents != null)
            {
                this.CalculateFreeCells(rp.rect, 0f);
                int num = 0;
                for (int i = rp.stockpileConcreteContents.Count - 1; i >= 0; i--)
                {
                    if (num >= this.cells.Count)
                    {
                        break;
                    }
                    GenSpawn.Spawn(rp.stockpileConcreteContents[i], this.cells[num], map, WipeMode.Vanish);
                    num++;
                }
                for (int j = rp.stockpileConcreteContents.Count - 1; j >= 0; j--)
                {
                    if (!rp.stockpileConcreteContents[j].Spawned)
                    {
                        rp.stockpileConcreteContents[j].Destroy(DestroyMode.Vanish);
                    }
                }
                rp.stockpileConcreteContents.Clear();
            }
            else
            {
                this.CalculateFreeCells(rp.rect, 0.99995f);
                //ThingSetMakerDef thingSetMakerDef = rp.thingSetMakerDef ?? ThingSetMakerDefOf.MapGen_DefaultStockpile;
                ThingSetMakerDef thingSetMakerDef = rp.thingSetMakerDef ?? LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile2;
                //ThingSetMakerDef thingSetMakerDef = LargeFactionBase_ThingSetMakerDefOf.MapGen_DefaultStockpile2;
                ThingSetMakerParams? thingSetMakerParams = rp.thingSetMakerParams;
                ThingSetMakerParams value;
                if (thingSetMakerParams.HasValue)
                {
                    value = rp.thingSetMakerParams.Value;
                }
                else
                {
                    value = default(ThingSetMakerParams);
                    value.techLevel = new TechLevel?((rp.faction == null) ? TechLevel.Undefined : rp.faction.def.techLevel);
                    value.validator = ((ThingDef x) => rp.faction == null || x.techLevel >= rp.faction.def.techLevel || !x.IsWeapon || x.GetStatValueAbstract(StatDefOf.MarketValue, GenStuff.DefaultStuffFor(x)) >= 100f);
                    float? stockpileMarketValue = rp.stockpileMarketValue;
                    float num2 = (!stockpileMarketValue.HasValue) ? Mathf.Min((float)this.cells.Count * 130f, 1800f) : stockpileMarketValue.Value;
                    value.totalMarketValueRange = new FloatRange?(new FloatRange(num2, num2));
                }
                IntRange? countRange = value.countRange;
                if (!countRange.HasValue)
                {
                    value.countRange = new IntRange?(new IntRange(this.cells.Count, this.cells.Count));
                }
                ResolveParams rp2 = rp;
                rp2.thingSetMakerDef = thingSetMakerDef;
                rp2.thingSetMakerParams = new ThingSetMakerParams?(value);
                BaseGen.symbolStack.Push("thingSet2", rp2);
            }
        }

        private void CalculateFreeCells(CellRect rect, float freeCellsFraction)
        {
            Map map = BaseGen.globalSettings.map;
            this.cells.Clear();
            foreach (IntVec3 current in rect)
            {
                if (current.Standable(map) && current.GetFirstItem(map) == null)
                {
                    this.cells.Add(current);
                }
            }
            int num = (int)(freeCellsFraction * (float)this.cells.Count);
            for (int i = 0; i < num; i++)
            {
                this.cells.RemoveAt(Rand.Range(0, this.cells.Count));
            }
            this.cells.Shuffle<IntVec3>();
        }
    }
}
