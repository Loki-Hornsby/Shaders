/// <summary>
/// Made by Loki Alexander Button Hornsby
/// Licensed under the BSD 3-Clause "New" or "Revised" License
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loki.Shader.Demo {
    public class Generator : MonoBehaviour {
        [Header("Prefab")]
        public GameObject prefab;

        [Header("Config")]
        public Vector2Int amount;
        public float pos_size;

        [Header("Random Offsets")]
        public Vector2 position;
        public Vector2 scale;

        IEnumerator Generate(){
            // Loop through x axis
            for (int x = 0; x < amount.x; x++){
                // Loop through y axis
                for (int y = 0; y < amount.y; y++){
                    // Choose a random position
                    Vector2 pos = new Vector2(
                        Random.Range(position.x, position.y), 
                        Random.Range(position.x, position.y)
                    );

                    // Create object at a random position with a random rotation defined by parameters
                    GameObject obj = Instantiate(
                        prefab, 

                        // Randomise position
                        this.transform.position + new Vector3(
                            ((x * pos_size) + pos.x),
                            0f, 
                            ((y * pos_size) + pos.y)
                        ), 

                        // Randomise rotation
                        prefab.transform.rotation
                    );

                    // Randomise scale
                    float random = Random.Range(scale.x, scale.y);

                    obj.transform.localScale = new Vector3(
                        prefab.transform.localScale.x * random,
                        prefab.transform.localScale.y * random,
                        prefab.transform.localScale.z * random
                    );

                    // Parent to this object
                    obj.transform.parent = this.transform;

                    yield return null;
                }
            }
        }

        void Start(){
            // Start our co routine to generate the items
            StartCoroutine(Generate());
        }
    }
}
