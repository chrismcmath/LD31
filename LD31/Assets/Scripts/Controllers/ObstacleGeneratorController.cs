using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using LD31;

namespace LD31.Controllers {
    public class ObstacleGeneratorController : MonoBehaviour {
        public GameObject TVObstacle;
        public GameObject Word;

        public string Let = @"Thank you for your timely response, the appointment is booked for 2pm this thursday.
            Please make sure Alex brings all required paper work so that we not need procrastinate further on matters of payments and such.
            The test itself lasts no more than ten minutes, and is purely designed to measure intellectual aptitude and emotional intelligence.
            The results will give us great confidence on the next course of action. I am confident that we can deal with this anxiety business quickly indeed.

            Yours,

            Dr. Bevan,
            Twickenham Wards
                London.";

        public bool On = false;
        public string[] words;

        private float _Counter = 0f;

        private float _WordCounter = 0f;
        private int _WordIndex = 0;

        public void Awake() {
            words = Let.Split(' ');
            Debug.Log("got " + words.Length + " words");
        }

        public void Update() {
            if (!On) return;

            if (_Counter < 0f) {
                CreateNewTVObstacle();
                _Counter = Config.TV_OBSTACLE_INTVERAL;
            }

            if (_WordCounter < 0f) {
                CreateWord();
                _WordCounter = Config.WORD_INTERVAL;
            }

            _Counter -= Time.deltaTime;
            _WordCounter -= Time.deltaTime;
        }

        private void CreateNewTVObstacle() {
            float radius = Random.Range(Config.OBSTACLE_GENERATION_MIN_RADIUS, Config.OBSTACLE_GENERATION_MAX_RADIUS);
            float angle = Random.Range(0f, 360f);
            Vector3 position = new Vector3(
                    transform.position.x + radius * Mathf.Cos(angle),
                    transform.position.y + radius * Mathf.Sin(angle),
                    transform.position.z);
            GameObject go = Instantiate(TVObstacle, position, Quaternion.identity) as GameObject;
            Rigidbody tvRigidbody = go.GetComponent<Rigidbody>();

            float speed = Random.Range(Config.OBSTACLE_MIN_SPEED, Config.OBSTACLE_MAX_SPEED);
            Vector3 rotationalVelocity = new Vector3(
                    Random.Range(Config.OBSTACLE_ROTATION_MIN_SPEED, Config.OBSTACLE_ROTATION_MAX_SPEED),
                    Random.Range(Config.OBSTACLE_ROTATION_MIN_SPEED, Config.OBSTACLE_ROTATION_MAX_SPEED),
                    Random.Range(Config.OBSTACLE_ROTATION_MIN_SPEED, Config.OBSTACLE_ROTATION_MAX_SPEED));

            Transform playerTransform = Model.Instance.PlayerController.transform;
            Vector3 target = playerTransform.position - tvRigidbody.transform.position;
            tvRigidbody.AddForce(target.normalized * speed, ForceMode.Impulse);
            tvRigidbody.angularVelocity = rotationalVelocity;
        }

        private void CreateWord() {
            float radius = Random.Range(Config.OBSTACLE_GENERATION_MIN_RADIUS, Config.OBSTACLE_GENERATION_MAX_RADIUS * 3);
            float angle = Random.Range(0f, 360f);
            Vector3 position = new Vector3(
                    transform.position.x + radius * Mathf.Cos(angle),
                    transform.position.y + radius * Mathf.Sin(angle),
                    transform.position.z);
            GameObject go = Instantiate(Word, position, Quaternion.identity) as GameObject;
            GameObject go2 = Instantiate(Word, position, Quaternion.identity) as GameObject;
            go.transform.SetParent(Model.Instance.WordTransform, false);
            go2.transform.SetParent(Model.Instance.WordTransform, false);

            Rigidbody wordRigidbody = go.GetComponent<Rigidbody>();
            Text wordText = go.GetComponent<Text>();
            Text wordText2 = go2.GetComponent<Text>();
            wordText.text = words[_WordIndex];
            wordText2.text = words[_WordIndex];
            _WordIndex++;
            if (_WordIndex >= words.Length) {
                _WordIndex = 0;
            }

            float speed = Random.Range(Config.OBSTACLE_MIN_SPEED, Config.OBSTACLE_MAX_SPEED);

            Vector3 rotationalVelocity = new Vector3(0f, 0f, Random.Range(-1f, 1f));

            Transform playerTransform = Model.Instance.PlayerController.transform;
            Vector3 target = playerTransform.position - wordRigidbody.transform.position;
            wordRigidbody.AddForce(target.normalized * speed, ForceMode.Impulse);
            wordRigidbody.angularVelocity = rotationalVelocity;
        }
    }
}
