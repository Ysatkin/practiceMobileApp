using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;
using System.IO;


public class Connection : MonoBehaviour
{

    public SqliteConnection dbconnection;
    private string path;
    public Dropdown dropdown;
    public Text selectedName;
    public Dropdown dropdown2;
    public Text selectedDay;
    public Text pair1;
    public Text pair2;
    public Text pair3;
    public Text pair4;
    public Text dayOf;
    private object group;
    private object day;

    public void Dropdown_IndexChanged(int index)
    {
        selectedName.text = names[index];
    }
    public void Dropdown_IndexDayChanged(int index)
    {
        selectedDay.text = days[index];
    }
    List<string> names = new List<string>() { "�������� ������","��-191", "��-192", "��-201"
        , "��-202",  "��-211", "��-212","��-221", "��-222",  "��-223"};
    List<string> days = new List<string>() { "����� ���","�����������", "�������", "�����"
        , "�������",  "�������", "�������"};
    // Start is called before the first frame update
    void Start()
    {

 
    }
    void PopulateList()
    {
        dropdown.AddOptions(names);
    }
    void PopulateListDay()
    {
        dropdown2.AddOptions(days);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //NamesGroups
    public void setConnection()
    {
        

        path = Application.dataPath + "/StreamingAssets/mydb.bytes";
        dbconnection = new SqliteConnection("Data Source=" + path);
        string sqlExpression = $"SELECT firstPair,secondPair,thirdPair,fourthPair,fifthPair FROM shedulegroup WHERE (groupName = '{selectedName.text}' and dayOfWeek = '{selectedDay.text}' )";
        using (var connection = dbconnection)
        {
            connection.Open();

            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // ���� ���� ������
                {
                   
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        var firstPair = reader.GetValue(0);
                        var secondPair = reader.GetValue(1);
                        var thirdPair = reader.GetValue(2);
                        var fourthPair = reader.GetValue(3);
                        if ((string)firstPair == "NULL")
                        {
                            firstPair = "��� ���";
                        }
                        if ((string)secondPair == "NULL")
                        {
                            secondPair = "��� ���";
                        }
                        if ((string)thirdPair == "NULL")
                        {
                            thirdPair = "��� ���";
                        }
                        if ((string)fourthPair == "NULL")
                        {
                            fourthPair = "��� ���";
                        }

                        dayOf.text = selectedDay.text;
                        pair1.text = (string)firstPair;
                        pair2.text = (string)secondPair;
                        pair3.text = (string)thirdPair;
                        pair4.text = (string)fourthPair;

                        //var fifthPair = reader.GetValue(4);
                        //$"\t '{secondPair}' \t '{thirdPair}' \t '{fourthPair}' \t '{fifthPair}'" +
                    }
                    
                }
                else
                {              
                    Debug.Log("Don't connection");
                }
            }
        }
    }
}
