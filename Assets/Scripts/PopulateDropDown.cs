using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateDropDown : MonoBehaviour
{
    public static int destination;
    void Start()
    {
        Dropdown drop =  gameObject.GetComponent<Dropdown>();
        int n = 6;
        string []arr = {"Men's Restroom", "Women's Restroom", "Floor 4", "Floor 2", "Elevators", "Bookshelf Aisle"};

        for (int i = 0; i < n; i++)
        {
            drop.options.Add(new Dropdown.OptionData() { text = (arr[i]).ToString() });
        }

        drop.onValueChanged.AddListener(delegate
        {
            setDestination(drop);
        });
    }

    void Update()
    {

    }

    void setDestination(Dropdown drop)
    {
        destination = drop.value;
        Debug.Log(destination);
    }
}
