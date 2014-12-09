using System.Collections;

using UnityEngine;
using TinyTween;

using LD31;

namespace LD31.Controllers {
    public class DoorController : MonoBehaviour {
        public static readonly float OPEN_SPEED = 10f;
        public static readonly Vector3 OPEN_TO_ROTATION = new Vector3(0f, 133.91f, 0f);

        public Transform DoorTransform = null;

        protected QuaternionTween _RotationTween = new QuaternionTween();

        public void Update() {
            _RotationTween.Update(Time.deltaTime);

            if (_RotationTween.State == TweenState.Running) {
                DoorTransform.localRotation = _RotationTween.CurrentValue;
            }
        }

        public void Open() {
            _RotationTween.Start(Quaternion.identity, Quaternion.Euler(OPEN_TO_ROTATION), OPEN_SPEED, ScaleFuncs.CubicEaseInOut);
        }
    }
}
