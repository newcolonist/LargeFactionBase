using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace RimWorld.BaseGen
{
    public class SymbolResolver_ChargeBatteries2 : SymbolResolver
    {
        private static List<CompPowerBattery> batteries = new List<CompPowerBattery>();

        public override void Resolve(ResolveParams rp)
        {
            Map map = BaseGen.globalSettings.map;
            SymbolResolver_ChargeBatteries2.batteries.Clear();
            CellRect.CellRectIterator iterator = rp.rect.GetIterator();
            while (!iterator.Done())
            {
                List<Thing> thingList = iterator.Current.GetThingList(map);
                for (int i = 0; i < thingList.Count; i++)
                {
                    CompPowerBattery compPowerBattery = thingList[i].TryGetComp<CompPowerBattery>();
                    if (compPowerBattery != null && !SymbolResolver_ChargeBatteries2.batteries.Contains(compPowerBattery))
                    {
                        SymbolResolver_ChargeBatteries2.batteries.Add(compPowerBattery);
                    }
                }
                iterator.MoveNext();
            }
            for (int j = 0; j < SymbolResolver_ChargeBatteries2.batteries.Count; j++)
            {
                float num = Rand.Range(0.6f, 0.95f);
                SymbolResolver_ChargeBatteries2.batteries[j].SetStoredEnergyPct(Mathf.Min(SymbolResolver_ChargeBatteries2.batteries[j].StoredEnergyPct + num, 1f));
            }
            SymbolResolver_ChargeBatteries2.batteries.Clear();
        }
    }
}
