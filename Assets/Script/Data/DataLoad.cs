using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Parser 
{   // ����Ʈ ������ Ÿ���� �����ؼ� �ۼ��غ��� ��... Ÿ�Ը� ���� �Ǹ� �Ǵϱ� ���⿡ �� ���� �ϴ� �Լ��̰�..�� 
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
    
    Item item1;
    ITEMDETAIL detail;
    
    public Dictionary<int, Item> itemDic = new Dictionary<int, Item>(); 
    

    void Start()
    {   
        List<Item> valuesList  =  Parser.Parse(path);

        for (int i = 0; i < valuesList.Count; i++)
            itemDic.Add(valuesList[i].itemindex, valuesList[i]);

        
        //��Ǿ ���� Ű ������ �����

    }

    //public void ItemDetail()
    //{
    //    //if ((int)ITEMDETAIL.HP_POTION == itemDic[1].detail)
    //    Item hpPotion;
        
    //    for (int i = 0; i < itemDic.Count; i++)
    //    {
    //        if (itemDic[i].detail == (int)ITEMDETAIL.HP_POTION)
    //            hpPotion = itemDic[i];

    //        //if ((int)ITEMDETAIL.MP_POTION == itemDic[i].detail) 


    //        //if ((int)ITEMDETAIL.WEAPON == itemDic[i].detail) 
    //    }
    //}



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
///// �Ű�ü
///// </summary>
//public enum ITEMDETAIL
//{
//    WEAPON = 0,
//    HP_POTION = 5,
//    MP_POTION = 6
//}
