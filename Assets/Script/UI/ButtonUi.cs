using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUi : MonoBehaviour
{
    // ��ư ����Ʈ�� ��Ƽ� ����ϱ� ��ư(�����̳ʿ� ��Ƽ� ����) �ʿ� �� �ҷ��� ��� �����ϰ� ���ֱ�
    // - Ȯ������ �κа� �������� �κе��� ����Ʈ�� ���� �� ������ ����

    //���𰡸� Ű�� ��ư ����Ʈ
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
    /// Menu��ư, state��ư,skill��ư,inven��ư,option��ư�� ����Ǿ��ִ� �Լ��̴�.
    /// </summary>
    public void MenuButton()
    { 
        menuButton.onClick.AddListener(() => { MenuOnClick(menuButton, allbuttonImage, gameconnectedButton); }); // ������ ���� �����ְ� event�̱⿡ ���� ������Ʈ �������� �������� �ʾƵ� �ȴ�.
        gameSceneAllButton[0].onClick.AddListener(() => { UiOff(gameconnectedButton); gameconnectedButton[0].SetActive(true);});
        gameSceneAllButton[1].onClick.AddListener(() => { UiOff(gameconnectedButton); gameconnectedButton[1].SetActive(true); });
        gameSceneAllButton[2].onClick.AddListener(() => { UiOff(gameconnectedButton); gameconnectedButton[2].SetActive(true); });
        gameSceneAllButton[3].onClick.AddListener(() => { UiOff(gameconnectedButton); gameconnectedButton[3].SetActive(true); });
    }

    // ��ư�� ������ [�޼��� : ��ư�� ��Ȱ��ȭ �ǰ�] -> ��ư�� ����� Ui�� Ȱ��ȭ �ǵ��� �ϴ� �޼��� ����  
    // Ű�� ������ �̷�����ִ� Dic�� �̿��ϴ°� �� �� ȿ������ �� �ֵ�

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
