//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CSVParser
//{
//    public static List<string[]> Parse(string path)
//    {
//        List<string[]> valuesList = new List<string[]>();
//        TextAsset loadData = Resources.Load<TextAsset>(path);
//        string allText = loadData.text;
//        string[] lines = allText.Split("|n");
//        for (int i = 1; i < lines.Length; i++)
//        {
//            if (i == int.Parse("!"))
//                continue;
//            string[] values = lines[i].Split(",");
//            valuesList.Add(values);
//        }
//        return valuesList;
//    }

//}


//public class Conversation
//{
//    private int spriteId;
//    private string name;
//    private string contents;

//    public Conversation(int spriteId, string name, string contents)
//    {
//        this.spriteId = spriteId;
//        this.name = name;
//        this.contents = contents;

//    }

//    public void Show()
//    {
//        Debug.Log(name + " : " + contents);
//    }


//}



//public class Test : MonoBehaviour
//{
//    string path = "D:\\새 폴더 (2)\\speed_project\\Assets\\Resources";

//    void Start()
//    {
//        List<string[]> valuesList = CSVParser.Parse(path);
//        string[] values = valuesList[0];
//        Conversation conversation = new Conversation(int.Parse(values[0]), values[1], values[2]);




//        // 체크용
//        //foreach (string[] values in valuesList)
//        //{
//        //    foreach (string value in values)
//        //    { 
//        //      Debug.Log(value);
//        //    }
//        //    Debug.Log("-----------------------");
//        //}



//        //TextAsset loadData = Resources.Load<TextAsset>("");
//        //Debug.Log(loadData.text);  아마 파일 출력 부분! 들어왔나 확인!
//    }


//}
