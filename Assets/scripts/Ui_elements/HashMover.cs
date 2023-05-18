using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HashMover : MonoBehaviour {

    public float moveSpeed = 20f;
    public float fadeSpeed = 1;
    public float spawnOffsetRange = 10f;
    public Button buttonClicked;
    public GameObject hashPrefab;

    void Start() {
        buttonClicked.onClick.AddListener(SpawnText);
        hashPrefab.SetActive(false);
    }

    private void SpawnText() {
        // Instantiate a new text object from the prefab with random offset
        float randomOffsetX = Random.Range(-spawnOffsetRange, spawnOffsetRange);
        float randomOffsetY = Random.Range(-spawnOffsetRange, spawnOffsetRange);
        Vector2 spawnOffset = new Vector2(randomOffsetX, randomOffsetY);

        GameObject newText = Instantiate(hashPrefab, transform);
        newText.SetActive(true);

        RectTransform rectTransform = newText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition += spawnOffset;

        // Start the fade-out coroutine
        StartCoroutine(FadeOutText(newText));
    }

    private System.Collections.IEnumerator FadeOutText(GameObject textObject)
    {
        RectTransform rectTransform = textObject.GetComponent<RectTransform>();
        CanvasRenderer canvasRenderer = textObject.GetComponent<CanvasRenderer>();

        while (canvasRenderer.GetAlpha() > 0f)
        {
            // Move hash up
            Vector2 newPosition = rectTransform.anchoredPosition + new Vector2(0f, moveSpeed) * Time.deltaTime;
            rectTransform.anchoredPosition = newPosition;

            // Change alpha from 1 to 0
            float newAlpha = canvasRenderer.GetAlpha() - fadeSpeed * Time.deltaTime;
            newAlpha = Mathf.Clamp01(newAlpha);
            canvasRenderer.SetAlpha(newAlpha);

            yield return null;
        }

        // Destroy the text object when it has completely faded out
        Destroy(textObject);
    }
}
