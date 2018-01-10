using Harmony;
using System;
using System.Xml;

namespace BetterStart
{
    //StartGear
    [HarmonyPatch(typeof(StartGear), "AddAllToInventory")]
    public class BetterStart
    {

        static void Postfix()
        {
            //this mod is for Survival only and should not affect story mode
            if (GameManager.IsStoryMode()) return;


            //loaditems

            XmlDocument items = new XmlDocument();

            items.Load("BetterStart.xml");

            XmlNodeList list = items.GetElementsByTagName("item");

            for (int i = 0; i < list.Count; i++)
            {
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(list[i]["name"].InnerText, int.Parse(list[i]["quantity"].InnerText));
            }
         
        }
    }
}
