using System.Collections;

using UnityEngine;

using LD31.Controllers;

namespace LD31.GameBehaviours {
    public class MoveStraightToTV : TVBehaviour {
        public static readonly float CHANGE_BEHAVIOUR_THRESHOLD = 5f;

        private float _Speed;

        public MoveStraightToTV(float speed) : base() {
            Debug.Log("MoveStraightToTV");
            _Speed = speed;
        }

        public override GameBehaviour Update() {
            Debug.Log("_PlayerTransform: " + _PlayerTransform.localPosition + " _TVTransform: " + _TVTransform.localPosition);
            /*
            Vector3 direction = _TVTransform.localPosition - _PlayerTransform.localPosition;
            Vector3 moveVector = direction * _Speed;
            _PlayerTransform.localPosition += moveVector;

            */
            if (_PlayerTransform.localPosition.z > (_TVTransform.localPosition.z - CHANGE_BEHAVIOUR_THRESHOLD)) {
                Debug.Log("move to game move!!!!!!");
                return new TVGame();
            }

            return this;
        }
    }
}
