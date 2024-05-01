using System;
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
    [SerializeField] private Button menuButton;
    [SerializeField] private GameObject allbuttonImage;
    [SerializeField] private List<Button> gameSceneAllButton = new List<Button>();
    [SerializeField] private List<GameObject> gameconnectedButton = new List<GameObject>();
   

    private bool buttonOnOff = false;
    public bool ButtonOnOff
    {
        get { return buttonOnOff; }
        set
        {
            buttonOnOff = value;
        }
    }

    private bool button0 = false;

    void Start()
    {
        MenuButton();
      
    }

    /// <summary>
    /// Menu버튼, state버튼,skill버튼,inven버튼,option버튼이 연결되어있는 함수이다.
    /// </summary>
    public void MenuButton()
    { 
        menuButton.onClick.AddListener(() => { MenuOnClick(menuButton, allbuttonImage, gameconnectedButton); }); // 선언을 통해 역어주고 event이기에 따로 업데이트 구문에서 진행하지 않아도 된다.
        gameSceneAllButton[0].onClick.AddListener(() => { UiOff(gameconnectedButton); gameconnectedButton[0].SetActive(true);});
        gameSceneAllButton[1].onClick.AddListener(() => { UiOff(gameconnectedButton); gameconnectedButton[1].SetActive(true); });
        gameSceneAllButton[2].onClick.AddListener(() => { UiOff(gameconnectedButton); gameconnectedButton[2].SetActive(true); });
        gameSceneAllButton[3].onClick.AddListener(() => { UiOff(gameconnectedButton); gameconnectedButton[3].SetActive(true); });
    }

    // 버튼을 누르면 [메서드 : 버튼은 비활성화 되고] -> 버튼과 연결된 Ui가 활성화 되도록 하는 메서드 구현  
    // 키와 값으로 이루어져있는 Dic을 이용하는게 좀 더 효율적일 수 있따

    public void MenuOnClick(Button Button, GameObject allbuttonImage, List<GameObject> gameconnectedButton)
    {
        UiOff(gameconnectedButton);

        ButtonOnOff = !ButtonOnOff;
        allbuttonImage.SetActive(ButtonOnOff);
    }

    public void UiOff(List<GameObject> gameconnectedButton)
    {
        foreach (var button in gameconnectedButton)
        {
            button.SetActive(false);
        }
    }



}
