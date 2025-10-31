using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GoalZone : MonoBehaviour
{
    private HashSet<GameObject> cubesInside = new HashSet<GameObject>();
    public string cubeTag = "Pickup";

    public GameObject winTextObject;
    public TextMeshProUGUI countText;

    private int totalCubes;

    void Start()
    {
        // Find all cubes at the start
        totalCubes = GameObject.FindGameObjectsWithTag(cubeTag).Length;

        // Hide the win text initially
        if (winTextObject != null)
            winTextObject.SetActive(false);

        UpdateCountText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(cubeTag))
        {
            cubesInside.Add(other.gameObject);
            Debug.Log("Cube entered goal zone. Total inside: " + cubesInside.Count);
            UpdateCountText();
            CheckWin();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(cubeTag))
        {
            cubesInside.Remove(other.gameObject);
            Debug.Log("Cube left goal zone. Total inside: " + cubesInside.Count);
            UpdateCountText();
            CheckWin();
        }
    }

    void UpdateCountText()
    {
        if (countText != null)
            countText.text = $"Cubes on goal: {cubesInside.Count}/{totalCubes}";
    }

    void CheckWin()
    {
        if (cubesInside.Count == totalCubes && totalCubes > 0)
        {
            Debug.Log("All cubes are on the goal plane! You win!");
            if (winTextObject != null)
                winTextObject.SetActive(true);
        }
        else
        {
            if (winTextObject != null)
                winTextObject.SetActive(false);
        }
    }
}
