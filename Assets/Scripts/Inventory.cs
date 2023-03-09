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
    void Start() {
        inventory = new GameObject[slots];
        for (int i = 0; i< slots; i++) {
            inventory[i] = Instantiate(itemPrefab, new Vector3(inventoryText.GetComponent<RectTransform>().position.x + inventoryText.GetComponent<RectTransform>().rect.width - (itemPrefab.GetComponent<RectTransform>().rect.width *  itemPrefab.GetComponent<RectTransform>().localScale.x * (i+1.75f)), inventoryText.GetComponent<RectTransform>().position.y - inventoryText.GetComponent<RectTransform>().rect.height , itemPrefab.GetComponent<RectTransform>().position.z), itemPrefab.GetComponent<RectTransform>().rotation, inventoryText.transform);
        }
    }
    public void setSlot(string name, Sprite sprite, int pos) {
        inventory[pos].GetComponent<Image>().sprite = sprite;
        inventory[pos].name = name;
    }
}
