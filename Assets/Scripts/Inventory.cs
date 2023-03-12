using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject inventoryText;
    public int slots = 6;
    public GameObject[] inventory;
    public Sprite[] sprites;
    void Start() {
        inventory = new GameObject[6];
        for (int i = 0; i < slots; i++) {
            if (inventory[i] == null || inventory[i].GetComponent<Image>().sprite == itemPrefab.GetComponent<Image>().sprite) 
                inventory[i] = Instantiate(itemPrefab, new Vector3(inventoryText.GetComponent<RectTransform>().position.x + inventoryText.GetComponent<RectTransform>().rect.width - (itemPrefab.GetComponent<RectTransform>().rect.width *  itemPrefab.GetComponent<RectTransform>().localScale.x * (i+2.65f)), inventoryText.GetComponent<RectTransform>().position.y - inventoryText.GetComponent<RectTransform>().rect.height  + 15, itemPrefab.GetComponent<RectTransform>().position.z), itemPrefab.GetComponent<RectTransform>().rotation, inventoryText.transform);
        }
        if (PlayerVars.Instance.hasFlower) {
            setSlot("Potion", sprites[0], 0);
        }
        if (PlayerVars.Instance.hasMagician) {
            setSlot("Magician", sprites[1], 0);
        }
        if (PlayerVars.Instance.hasEmperor) {
            setSlot("Emperor", sprites[2], 1);
        }
        if (PlayerVars.Instance.hasDeath) {
            setSlot("Death", sprites[3], 2);
        }
        if (PlayerVars.Instance.hasWorld) {
            setSlot("World", sprites[4], 3);
        }
        if (PlayerVars.Instance.hasSun) {
            setSlot("Sun", sprites[5], 4);
        }
        if (PlayerVars.Instance.hasFool) {
            setSlot("Sun", sprites[6], 5);
        }
        
    }
    public void setSlot(string name, Sprite sprite, int pos) {
        inventory[pos].GetComponent<Image>().sprite = sprite;
        inventory[pos].name = name;
    }
}
