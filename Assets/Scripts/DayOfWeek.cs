using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayOfWeek : MonoBehaviour
{

    List<string> days = new List<string>() { "Выбор дня","Понедельник", "Вторник", "Среда"
        , "Четверг",  "Пятница", "Суббота"};

    public Dropdown dropdown2;
    public Text selectedDay;

    public void Dropdown_IndexDayChanged(int index)
    {
        selectedDay.text = days[index];
    }
    void Start()
    {
        PopulateListDay();
    }

    void PopulateListDay()
    {
        dropdown2.AddOptions(days);
    }
}
