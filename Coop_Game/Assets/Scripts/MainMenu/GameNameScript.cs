using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameNameScript : MonoBehaviour
{
    
    public void Start()
    {
        TextMeshProUGUI GameName = GetComponent<TextMeshProUGUI>();
        GameName.text = Application.productName;
    }
}
