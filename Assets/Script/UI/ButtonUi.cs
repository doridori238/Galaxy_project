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
        // ���� ���ϴ� ���� ���ϴ� List��ġ�� ��ư�� ã�Ƽ� Ŭ���� �Ǵ°� Ȯ�� �� �̹��� on/off ����
    }


    // ��ư�� ������ [�޼��� : ��ư�� ��Ȱ��ȭ �ǰ�] -> ��ư�� ����� Ui�� Ȱ��ȭ �ǵ��� �ϴ� �޼��� ����  
    // Ű�� ������ �̷�����ִ� Dic�� �̿��ϴ°� �� �� ȿ������ �� �ֵ�

    public void MenuOnClick(Button button)
    {
        Change = !Change;
    }



    void Update()
    {

    }
    

}
