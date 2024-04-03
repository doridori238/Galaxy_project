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
    [SerializeField] private List<Button> gameSceneAllButton = new List<Button>();
    [SerializeField] private List<Component> gameconnectedButton = new List<Component>();

    
    private bool change = true;
    public bool Change
    {
        get { return change; }
        set {
                change = value;
        }
    }


    void Start()
    {
        menuButton.onClick.AddListener(()=> { MenuOnClick(menuButton); });
    
           
    
        // ���� ���ϴ� ���� ���ϴ� List��ġ�� ��ư�� ã�Ƽ� Ŭ���� �Ǵ°� Ȯ�� �� �̹��� on/off ����
    }


    // ��ư�� ������ [�޼��� : ��ư�� ��Ȱ��ȭ �ǰ�] -> ��ư�� ����� Ui�� Ȱ��ȭ �ǵ��� �ϴ� �޼��� ����  
    // Ű�� ������ �̷�����ִ� Dic�� �̿��ϴ°� �� �� ȿ������ �� �ֵ�

    public void MenuOnClick(Button menuButton)
    {
        foreach (var button in gameSceneAllButton)
        {
            button.enabled = Change;
        }
        
        Debug.Log("��ư ����");
    }



    void Update()
    {
        

    }
       

}
