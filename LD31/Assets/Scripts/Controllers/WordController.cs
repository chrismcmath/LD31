using System.Collections;

using UnityEngine;

using LD31;

namespace LD31.Controllers {
    public class WordController : MonoBehaviour {
        private Transform _PlayerTransform;

        private float lifeSpan = 0f;

        public void Awake() {
            _PlayerTransform = Model.Instance.PlayerController.transform;
        }

        public void Update() {
            if (transform.position.z < _PlayerTransform.position.z) {
                GameObject.Destroy(gameObject);
            } else if (lifeSpan > Config.MAX_WORD_LIFESPAN) {
                GameObject.Destroy(gameObject);
            }

            Debug.Log("life span " + lifeSpan);
            lifeSpan += Time.deltaTime;
        }

        public void OnCollisionEnter(Collision collision) {
            //Debug.Log("HIT " + collision);
            //TODO: play sound
        }
    }
}

