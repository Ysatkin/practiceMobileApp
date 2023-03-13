 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public Schedule scheduleOne;
    public Error error;
}

[System.Serializable]
public class Error
{
    public string errorText;
    public bool isError;
}

[System.Serializable]
public class Schedule
{
    public string GroupName;
    public string DayOfWeek;
    public string FirstPair;
    public string SecondPair;
    public string ThridPair;
    public string FourthPair;
    public string FifthPair;

    public Schedule(string GroupName, string DayOfWeek, string FirstPair = null, string SecondPair = null,
        string ThridPair = null, string FourthPair = null, string FifthPair = null)

    {
        this.GroupName = GroupName;
        this.DayOfWeek = DayOfWeek;
        this.FirstPair = FirstPair;
        this.SecondPair = SecondPair;
        this.ThridPair = ThridPair;
        this.FourthPair = FourthPair;
        this.FifthPair = FifthPair;
    }
} 
public class Manager : MonoBehaviour
{

    public static UserData userData= new UserData();


    public string GetUserData(UserData data)
    {
        return JsonUtility.ToJson(data);
    }
    public UserData SetUserData(string data)
    {
        return JsonUtility.FromJson<UserData>(data);
    }

    private void Start()
    {
        userData.error = new Error() { errorText = "text", isError = true };
    }
}
