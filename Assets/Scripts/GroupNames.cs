using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupNames : MonoBehaviour
{
    List<string> names = new List<string>() { "�������� ������","��-191", "��-192", "��-201"
        , "��-202",  "��-211", "��-212","��-221", "��-222",  "��-223"};

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
