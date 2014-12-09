using System.Collections;

using UnityEngine;

using LD31;

namespace LD31.Controllers {
    public class CameraShakeController : MonoBehaviour {
        public float ShakeAmount = 0f;
        public float BaseShakeAmount = 0f;

        public void Update() {
            transform.localRotation = Quaternion.Euler(
                    new Vector3(GetRandom(), GetRandom(), transform.localRotation.z));

            ShakeAmount *= 0.9f;
        }

        private float GetRandom() {
            float r = Random.Range(BaseShakeAmount, ShakeAmount);
            r *= (r % 2 == 0) ? 1 : -1;
            return r;
        }
    }
}

