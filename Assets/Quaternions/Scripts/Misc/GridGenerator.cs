using UnityEngine;
using System.Collections;

public class GridGenerator : MonoBehaviour
{
    #region Attributes

        // Prefab to spawn
        [SerializeField]
        private GameObject m_PrefabToSpawn          = null;

        // Grid size
        [SerializeField]
        private Vector3     m_GridSize              = Vector3.zero;

        // Space between objects
        [SerializeField]
        private float       m_SpaceBetweenObjects   = 3;

    #endregion

    #region MonoBehaviour

        // Use this for initialization
        void Start()
        {
            // Generate the grid
            GenerateGrid();
        }

    #endregion

    #region Private Manipulators

        /// <summary>
        /// Generate a grid of prefab instances
        /// </summary>
        private void GenerateGrid()
        {
            if (m_PrefabToSpawn != null)
            {
                for (int i = 0; i < m_GridSize.x; i++)
                {
                    for (int j = 0; j < m_GridSize.y; j++)
                    {
                        for (int k = 0; k < m_GridSize.z; k++)
                        {
                        Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180))); 
                        GameObject obj = GameObject.Instantiate(m_PrefabToSpawn, transform.position + new Vector3(i * m_SpaceBetweenObjects, j * m_SpaceBetweenObjects, k * m_SpaceBetweenObjects), rot) as GameObject;
                            obj.transform.parent = transform.parent;

                        }
                    }
                }
            }
        }

    #endregion
}
