using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : CollectableScript
{
    public Sprite emptyChest;
    public int pesosAmount = 5;
    protected override void OnCollect()
    {
        if(!collected)
        {
            base.OnCollect();
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.pesos += pesosAmount;
            GameManager.instance.ShowText("Grant " + pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }
    }
}
