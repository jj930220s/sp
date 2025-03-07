using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData item;
    public UIInventory inventory;

    public int index;

    public bool equipped;

    public int quantity;

    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityText;
    private Outline outLine;




    // Start is called before the first frame update
    void Awake()
    {
        outLine=GetComponent<Outline>();
    }

    private void OnEnable()
    {
        outLine.enabled = equipped;
        
    }

    public void Set()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
        quantityText.text = quantity > 1 ? quantity.ToString():string.Empty;
    
    
        if(outLine!=null)
        {
            outLine.enabled = equipped;
        }
    }


    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
        icon.sprite = null;
        quantityText.text =  string.Empty;
    }

    public void OnclickButton()
    {
        inventory.SelectItem(index);
    }

}
