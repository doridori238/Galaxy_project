using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image image;
    public Button button;
    public GameObject detailUi;

    public 


    void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => {  });
    }

    void Update()
    {
        if (image.sprite == null)
        {
            button.enabled = false;
        }
        else if (image.sprite != null)
        {
            button.enabled = true;
        }
    }



}
