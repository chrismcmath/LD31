using System.Collections;

using UnityEngine;

using LD31;

namespace LD31.Controllers {
    public class TVObstacleController : MonoBehaviour {
        private Transform _PlayerTransform;

        public void Awake() {
            _PlayerTransform = Model.Instance.PlayerController.transform;
        }

        public void Update() {
            if (transform.position.z < _PlayerTransform.position.z) {
                GameObject.Destroy(gameObject);
            }
        }

        public void OnCollisionEnter(Collision collision) {
            SoundsController s = Model.Instance.SoundsController;
            s.TVHit.Play();
        }
    }
}

