using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
        public Transform[] defaultTarget;
        public float changeTargetTime = 3f;

        private float localTime = 0f;
        private int currentTargetIndex = 0;
        private Transform lastSettedTarget;
        
        IAstarAI ai;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			if (target != null && ai != null) ai.destination = target.position;
            if (target == null)
            {
                target = defaultTarget[currentTargetIndex];
            }
            if (localTime >= changeTargetTime)
            {
                localTime = 0f;
                this.ChangeTarget();
            }
            else
            {
                localTime += 1 * Time.deltaTime;
            }
        }

        private void ChangeTarget()
        {
            if (lastSettedTarget == null)
            {
                currentTargetIndex = Random.Range(0, defaultTarget.Length);
                target = defaultTarget[currentTargetIndex];
            }
        }

        public void SetTarget(Transform t)
        {
            //if (Vector2.Distance(transform.position, target.position)>Vector2.Distance(transform.position, t.position))
            //{
            //    target = t;
            //} 

            lastSettedTarget = t;
            target = t;
        }
    }
}
