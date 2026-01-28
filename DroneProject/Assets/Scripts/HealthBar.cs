using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;//public Image fill;
    public TextMeshProUGUI hpText;

    public void SetHealth(int current,int max)
    {
        float pct = (float) current/max;//pct = percentage
        healthSlider.value = pct;
        hpText.text = current +"/"+max;    
    }

}
