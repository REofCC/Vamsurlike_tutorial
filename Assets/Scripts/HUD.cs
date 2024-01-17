using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private enum InfoType { Exp, Level, Kill, Time, Hp}
    [SerializeField]
    InfoType type;

    private Text text;
    private Slider slider;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                {
                    float currentExp = GameManager.instance.exp;
                    float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
                    slider.value = currentExp / maxExp;
                }
                break;
            case InfoType.Level:
                text.text = string.Format("Lv{0:F0}",GameManager.instance.level);
                break;
            case InfoType.Kill:
                text.text = string.Format("{0:F0}", GameManager.instance.kill);
                break;
            case InfoType.Time:
                text.text = string.Format("{0:F0} Sec", GameManager.instance.level);
                break;
            case InfoType.Hp:
                break;
        }
    }
}
