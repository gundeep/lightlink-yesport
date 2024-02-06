using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class QRNG : MonoBehaviour
{
    private string url = "https://api3.example.com/qrng"; // Replace with the actual API endpoint

    void Start()
    {
        StartCoroutine(GetRandomNumber());
    }

    IEnumerator GetRandomNumber()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Parse the response, depends on the API response format
            string rawNumber = request.downloadHandler.text;
            Debug.Log("Random number: " + rawNumber);
        }
        else
        {
            Debug.Log("Error: " + request.error);
        }
    }
}