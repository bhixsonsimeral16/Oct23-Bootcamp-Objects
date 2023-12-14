[System.Serializable]

public class JSONObject
{
    public int ID;
    public string name;
    public float grade;
    public int[] classIDs;
    public JSONObject(int _ID, string _name, float _grade, int[] _classIDs)
    {
        ID = _ID;
        name = _name;
        grade = _grade;
        classIDs = _classIDs;
    }
}
