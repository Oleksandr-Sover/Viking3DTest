using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreHandler : MonoBehaviour
    {
        ILocalUIData LocalUIData;

        TextMeshProUGUI scoreTextMesh;

        string scoreText;

        int score = 0;

        void Awake()
        {
            LocalUIData = GetComponentInParent<ILocalUIData>();
            scoreTextMesh = GetComponent<TextMeshProUGUI>();
        }

        void Start()
        {
            scoreText = score.ToString();
            scoreTextMesh.text = scoreText;
        }

        void Update()
        {
            if (score != LocalUIData.Score)
            {
                score = LocalUIData.Score;
                scoreText = score.ToString();
                scoreTextMesh.text = scoreText;
            }
        }
    }
}