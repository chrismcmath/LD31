using System.Collections;

using UnityEngine;

using LD31;

namespace LD31.Controllers {
    public class PlayerController : MonoBehaviour {
        private Rigidbody _Rigidbody;

        public void Awake() {
            _Rigidbody = GetComponent<Rigidbody>();
        }

        public void FixedUpdate() {
            if (_Rigidbody.velocity.magnitude > Config.MAX_FORWARD_SPEED) {
                //Debug.Log("reached max forward speed");
                _Rigidbody.velocity = _Rigidbody.velocity.normalized * Config.MAX_FORWARD_SPEED;
            }

            if (_Rigidbody.angularVelocity.magnitude > Config.MAX_ROTATION_SPEED) {
                //Debug.Log("reached max rotation speed");
                _Rigidbody.angularVelocity = _Rigidbody.angularVelocity.normalized * Config.MAX_ROTATION_SPEED;
            }
        }

        public void OnTriggerEnter(Collider col) {
            SoundsController s = Model.Instance.SoundsController;
            s.PlayerHit.Play();

            _Rigidbody.AddForce(transform.up * Config.COLLISION_PENALTY_FORCE, ForceMode.Impulse);
            _Rigidbody.AddTorque(transform.forward * Random.Range(-100f, 100f), ForceMode.Impulse);
            Model.Instance.FlashController.FlashWhite();
            Model.Instance.CameraShakeController.ShakeAmount = Config.COLLISION_SHAKE_CAMERA_AMOUNT;
        }
    }
}

