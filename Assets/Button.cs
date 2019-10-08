using System.Collections;
using System.Collections.Generic;
using Unity.UNetWeaver;
using UnityEngine;

public class Button : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        Debug.Log("onClick");
    }
}
