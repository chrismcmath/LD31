using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using LD31;
using LD31.Controllers;

namespace LD31.GameBehaviours {
    public class FallingBehaviour : TVBehaviour {
        //NOTE: Distance to TV
        public static readonly float CHANGE_BEHAVIOUR_TOLERANCE = 0f;

        protected Rigidbody _PlayerRigidbody;
        protected Renderer _TVRenderer;
        protected SoundsController _SoundsController;

        public bool IsFirstUpdate = true;

        public FallingBehaviour() : base() {
            _SoundsController = Model.Instance.SoundsController;

            _PlayerRigidbody = _PlayerController.GetComponent<Rigidbody>();
            _TVRenderer = _TVTransform.GetComponentInChildren<Renderer>();
            _PlayerRigidbody.isKinematic = false;
            _PlayerTransform.GetComponent<BoxCollider>().enabled = true;
            Model.Instance.CameraShakeController.BaseShakeAmount = Config.BASE_FALL_SHAKE_AMOUNT;
        }

        public override GameBehaviour Update() {
            //NOTE: I'm tired.
            if (IsFirstUpdate) {
                _PlayerRigidbody.angularVelocity = Vector3.forward * 500f;
                IsFirstUpdate = false;
            }

            //_PlayerRigidbody.angularVelocity = Vector3.forward * 100f;
            _PlayerRigidbody.AddForce(Vector3.forward * Config.MOVE_FORWARD_SPEED);

            if (_PlayerTransform.localPosition.z > (Config.TV_LOCK_POSITION.z - Config.TO_TV_Z_THRESHOLD)) {
                float speed = _PlayerRigidbody.velocity.magnitude;
                _PlayerRigidbody.isKinematic = true;
                _PlayerTransform.GetComponent<BoxCollider>().enabled = true;
                Model.Instance.CameraShakeController.BaseShakeAmount = 0f;
                return new TweenToTV(speed);
            } else if (!_TVRenderer.isVisible) {
                //NOTE: Hack- will not work if TV is in Editor window
                MoveToCenter();
            }

            if (Input.GetButton("Right")) {
                ForceTurn(-1f);
            } else if (Input.GetButton("Left")) {
                ForceTurn(1f);
            } else if (Input.GetButtonDown("Up")) {
                ImpulseMove(1f);
            } else if (Input.GetButtonDown("Down")) {
                ImpulseMove(-1f);
            } else {
                _PlayerRigidbody.angularVelocity *= 0.9f;
            }

            return this;
        }

        public void MoveToCenter() {
            Vector3 target = new Vector3(0f, 0f, _PlayerTransform.localPosition.z) - _PlayerTransform.localPosition;
            _PlayerRigidbody.AddForce(target.normalized * Config.CORRECTION_SPEED, ForceMode.Force);
            _PlayerRigidbody.AddForce(_PlayerTransform.forward * Config.CORRECTION_PENALTY_FORCE, ForceMode.Impulse);
            _PlayerRigidbody.angularVelocity *= 0.9f;
        }

        public void ImpulseMove(float multiplier) {
            _SoundsController.Thrust.Play();
            _PlayerRigidbody.AddForce(_PlayerTransform.up * Config.THRUST_SPEED * multiplier, ForceMode.Impulse);
        }

        public void ForceTurn(float multiplier) {
            _PlayerRigidbody.angularVelocity = Vector3.forward * Config.ROTATION_SPEED * multiplier;
        }
    }
}
