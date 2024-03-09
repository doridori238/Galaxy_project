using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
       
        for (int i = 1; i < lines.Length - 1; i++)
        {            
            string[] values = lines[i].Split(",");  
            //if(들어오는 정보로 스위치문으로 해서 담든가 아니면 if문으로 잡아서 처리하면 될것이다.)
            items = Input(values);       
            valuesList.Add(items);
                
        }
        return valuesList;

    }

    public static Item Input(string[] values)
    {  
        Item item = new Item();
        
        item.itemindex = int.Parse(values[0]);
        item.itemname = values[1];
        item.itemtype = int.Parse(values[2]);
        item.detail = int.Parse(values[3]);
        item.lvlimit = int.Parse(values[4]);
        item.option1 = int.Parse(values[5]);
        item.value1 = int.Parse(values[6]);
        item.option2 = int.Parse(values[7]);
        item.value2 = int.Parse(values[8]);
        item.option3 = int.Parse(values[9]);
        item.value3 = int.Parse(values[10]);
        item.option4 = int.Parse(values[11]);
        item.value4 = int.Parse(values[12]);
       
        return item;
    }
            
}


public class DataLoad : Singleton<DataLoad>
{
    string path = "ITEM_INFO";
    Dictionary<int, Item> itemDic = new Dictionary<int, Item>();
    Item item1;
    void Start()
    {   
        List<Item> valuesList  =  Parser.Parse(path);

        for (int i = 0; i < valuesList.Count; i++)
            itemDic.Add(valuesList[i].itemindex, valuesList[i]);

        item1 = itemDic[1];
        Debug.Log(item1.itemname);

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
