using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;


public static class Parser 
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
            
            //if(������ ������ ����ġ������ �ؼ� ��簡 �ƴϸ� if������ ��Ƽ� ó���ϸ� �ɰ��̴�.)
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
        item.itemtype = (ITEMTYPE)int.Parse(values[2]);
        item.detail = (ITEMDETAIL)int.Parse(values[3]);
        item.lvlimit = (LV_LIMIT)int.Parse(values[4]);
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
    
   
    public Dictionary<int, Item> itemDic = new Dictionary<int, Item>();
    public  List<Item> valuesList;

    public override void Awake()
    {
        base.Awake();
        valuesList = Parser.Parse(path);


        for (int i = 1; i < valuesList.Count; i++)
            itemDic.Add(valuesList[i].itemindex, valuesList[i]);
        
        
        //��Ǿ ���� Ű ������ �����
    }

}

[Serializable]
public struct Item
{
    public int itemindex;
    public string itemname;
    public ITEMTYPE itemtype;
    public ITEMDETAIL detail;
    public LV_LIMIT lvlimit;
    public int option1;
    public int value1;
    public int option2;
    public int value2;
    public int option3;
    public int value3;
    public int option4;
    public int value4;
    public Sprite sprite;
}

public enum ITEMTYPE
{
    CONSUMPTION = 1, // �Ҹ��� ������
    MOUNTING = 0     // ������ ������ 
}

public enum ITEMDETAIL
{
    WEAPON = 0,
    HP_POTION = 5,
    MP_POTION = 6
}

public enum LV_LIMIT
{
    ONE_LV = 1,
    FIVE_LV = 5,
    TEN_LV = 10,
}