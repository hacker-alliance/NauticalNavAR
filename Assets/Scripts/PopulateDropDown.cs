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
        string []arr = {"men's restroom", "women's restroom", "floor 4", "floor 2", "elevators", "Aisle 1"};

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
