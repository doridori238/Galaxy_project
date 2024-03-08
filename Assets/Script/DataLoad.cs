using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UIElements;

public struct Parser
{
    public static List<string[]> Parse(string path)
    {
        List<string[]> valuesList = new List<string[]>();
        TextAsset loadData = Resources.Load<TextAsset>(path);
        string allText = loadData.text;
        string[] lines = allText.Split('\n');
  
        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(",");
            valuesList.Add(values);
        }
            return valuesList;
    }

}



public class DataLoad : Singleton<DataLoad>
{
    string path = "ITEM_INFO";
   
    void Start()
    {
        List<string[]> valuesList  =  Parser.Parse(path);
        
    }

    
}



//struct Item
//{

//    public int itemindex;
//    public string itemName;
//    public int itemType;
//    public int detail;
//    public int lvLimit;
//    public int option1;
//    public int value1;
//    public int option2;
//    public int value2;
//    public int option3;
//    public int value3;
//    public int option4;
//    public int value4;

//}

///// <summary>
///// ¸Å°³Ã¼
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
