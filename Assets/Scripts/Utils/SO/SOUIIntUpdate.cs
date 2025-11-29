using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{
   public SOInt soInt;
   public TextMeshProUGUI uiTextValue;

    void Start()
    {
        uiTextValue.text = soInt.Value.ToString();
    }

    void Update()
    {
         uiTextValue.text = soInt.Value.ToString();
    }
}
