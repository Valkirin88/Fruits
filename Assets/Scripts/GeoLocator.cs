using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GeoLocator : MonoBehaviour
{
    private string apiUrl = "http://ip-api.com/json/";

    IEnumerator Start()
    {
        yield return StartCoroutine(GetCountry());
    }

    private IEnumerator GetCountry()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(webRequest.error);
        }
        else
        {
            string jsonResponse = webRequest.downloadHandler.text;
            // ��������� JSON ��� ���������� ������
            ParseJson(jsonResponse);
        }
    }

    private void ParseJson(string json)
    {
        // ������� ������ ��������� JSON
        var jsonObject = JsonUtility.FromJson<GeoResponse>(json);
        Debug.Log("Country: " + jsonObject.country);
    }

    [System.Serializable]
    public class GeoResponse
    {
        public string country;
        // �������� ������ ����, ���� �����
    }
}
