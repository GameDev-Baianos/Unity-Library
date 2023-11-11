using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingTextScript> floatingTexts = new List<FloatingTextScript>();

    private void Update()
    {
        foreach(FloatingTextScript txt in floatingTexts)
            txt.UpdateFloatingText();
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingTextScript floatingText = GetFloatingText();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        
        floatingText.txt.transform.position = Camera.main.WorldToScreenPoint(position); // Transfer world space to screen space to use in the UI
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    private FloatingTextScript GetFloatingText()
    {
        FloatingTextScript txt = floatingTexts.Find(t => !t.active);

        if(txt == null)
        {
            txt = new FloatingTextScript();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<TextMeshProUGUI>();

            floatingTexts.Add(txt);
        }

        return txt;
    }
}
