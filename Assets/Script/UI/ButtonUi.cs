using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUi : MonoBehaviour
{
    // 버튼 리스트를 담아서 사용하기 버튼(컨테이너에 담아서 관리) 필요 시 불러서 사용 가능하게 해주기
    // - 확장적인 부분과 관리적인 부분들을 리스트로 정리 및 연결이 목적

    //무언가를 키는 버튼 리스트
    [SerializeField] private List<Button> gameSceneAllButton = new List<Button>();
    //[SerializeField] private List

    private bool change = true;
    public bool Change
    {
        get { return change; }
        set {
        
        
        }
    }


    void Start()
    {
        gameSceneAllButton[0].enabled = Change;

        //for (int i = 0; i < gameSceneAllButton.Count; i++)
        //{
        //    gameSceneAllButton[i].enabled = Change;
        //}
        // 내가 원하는 것은 원하는 List위치에 버튼을 찾아서 클릭이 되는거 확인 후 이미지 on/off 연결
    }


    // 버튼을 누르면 [메서드 : 버튼은 비활성화 되고] -> 버튼과 연결된 Ui가 활성화 되도록 하는 메서드 구현  
    // 키와 값으로 이루어져있는 Dic을 이용하는게 좀 더 효율적일 수 있따

    public void MenuOnClick(Button button)
    {
        Change = !Change;
    }



    void Update()
    {

    }
    

}
