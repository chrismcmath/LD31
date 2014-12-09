using System.Collections;

using UnityEngine;

using LD31.Controllers;

namespace LD31.GameBehaviours {
    public class MoveToDoor : PlayerBehaviour {
        public static readonly float MOVE_SPEED = 1f;
        public static readonly float CHANGE_BEHAVIOUR_THRESHOLD = -60f;
        public static readonly float CHANGE_BEHAVIOUR_TOLERANCE = -5f;

        public MoveToDoor() : base() {
            SoundsController s = Model.Instance.SoundsController;
            s.Intro.Play();
        }

        public override GameBehaviour Update() {
            _PlayerTransform.localPosition = new Vector3(
                    _PlayerTransform.localPosition.x,
                    _PlayerTransform.localPosition.y,
                    _PlayerTransform.localPosition.z + ((CHANGE_BEHAVIOUR_THRESHOLD - _PlayerTransform.localPosition.z) * (MOVE_SPEED * Time.deltaTime))
                    );

            if (_PlayerTransform.localPosition.z > (CHANGE_BEHAVIOUR_THRESHOLD + CHANGE_BEHAVIOUR_TOLERANCE)) {
                float speed = (CHANGE_BEHAVIOUR_THRESHOLD - _PlayerTransform.localPosition.z) * (MOVE_SPEED * Time.deltaTime);
                return new MoveThroughDoor(speed);
            }

            return this;
        }
    }
}

