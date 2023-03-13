using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupNames : MonoBehaviour
{
    List<string> names = new List<string>() { "Âûáåðèòå ãðóïïó","ÈÒ-191", "ÈÒ-192", "ÈÒ-201"
        , "ÈÒ-202",  "ÈÒ-211", "ÈÒ-212","ÈÒ-221", "ÈÒ-222",  "ÈÒ-223"};

    public Dropdown dropdown;
    public Text selectedName;
    
    public void Dropdown_IndexChanged(int index)
    {
        selectedName.text = names[index];
    }
    void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        dropdown.AddOptions(names);
    }
}
