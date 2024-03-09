using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Transactions;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Parser 
{
    public static List<Item> Parse(string path)
    {
        List<Item> valuesList = new List<Item>();
        TextAsset loadData = Resources.Load<TextAsset>(path);
        string allText = loadData.text;
        string[] lines = allText.Split('\n');
        
        Item items = new Item();
        //int itemSwtich = 0;

        Dictionary<int, string> itemDic = new Dictionary<int, string>();
        //items.itemindex = int.Parse(lines[0]);
        CultureInfo cultureInfo = CultureInfo.InvariantCulture;
        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(",");
            //int value;
            // 파서 이유 
            for (int j = 0; j < values.Length; j++)
            { 
              items.itemindex = int.Parse(values[j]);
                
              itemDic.Add(items.itemindex, lines[i]);            
            }
            
            //switch(itemSwtich)
            //{
            //    case 0:
            //        items.itemindex = int.Parse(values[0]);
            //        break;
            //    case 1:
            //        items.itemname = values[1];
            //        break;
            //    case 2:
            //        items.itemtype = int.Parse(values[2]);
            //        break;
            //}

            ////string[] values = lines[i].Split(",");
            //itemDic.Add(items.itemindex, int.Parse(items[i]));
            //items =  int.Parse(lines[0]);
            //valuesList.Add(items);
        }
        valuesList.Add(items);
        return valuesList;


    }





}


public class DataLoad : Singleton<DataLoad>
{
    string path = "ITEM_INFO";
    Item items = new Item();
    Dictionary<List<string[]>, Item> itemDic = new Dictionary<List<string[]>, Item>();

    void Start()
    {
        List<Item> valuesList  =  Parser.Parse(path);
    
        //Debug.Log(valuesList.Count.ToString());
        //foreach (string[] values in valuesList)
        //{

        //    itemDic.Add(values[i], items);
            
        //}
        //Debug.Log(itemDic.);


        //딕션어리 통한 키 벨류로 만들기
    }


    
}



public struct Item
{

    public int itemindex;
    public string itemname;
    public int itemtype;
    public int detail;
    public int lvlimit;
    public int option1;
    public int value1;
    public int option2;
    public int value2;
    public int option3;
    public int value3;
    public int option4;
    public int value4;

}

///// <summary>
///// 매개체
///// </summary>
//enum ItemDetail
//{ 
//    ITEM_INDEX = 1,
//    ITEM_NAME = 2,
//    ITEM_TYPE = 3,
//    DETAIL = 4,
//    LVLIMIT = 5,
//    OPTION1 = 6, 
//    VALUE1 = 7,
//    OPTION2 = 8,
//    VALUE2 = 9,
//    OPTION3 = 10,
//    VALUE3 = 11,
//    OPTION4 = 12,
//    VALUE4 = 13,
//}
