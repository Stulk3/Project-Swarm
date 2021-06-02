using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VersionScript : MonoBehaviour
{
    public void Start()
    {
        TextMeshProUGUI GameVersion = GetComponent<TextMeshProUGUI>();
        GameVersion.text = ("Game Version: " + Application.version);
    }
}
