using UnityEngine;

public static class UserDataManager
{
    private const string PROGRESS_KEY = "Progress";

    public static UserProgressData Progress;

    public static void Load()
    {
        // cek apakah ada data yang tersimpan sebagai PROGRESS_KEY
        if (!PlayerPrefs.HasKey(PROGRESS_KEY))
        {
            // jika tidak ada data, maka buat data yang baru
            Progress = new UserProgressData();
            Save();
        }
        else
        {
            // jika ada, maka timpa progress dengan yang sebelumnya
            string json = PlayerPrefs.GetString(PROGRESS_KEY);
            Progress = JsonUtility.FromJson<UserProgressData>(json);
        }
    }

    public static void Save()
    {
        string json = JsonUtility.ToJson(Progress);
        PlayerPrefs.SetString(PROGRESS_KEY, json);
    }

    public static bool HasResources(int index)
    {
        return index + 1 <= Progress.ResourcesLevels.Count;
    }
}
