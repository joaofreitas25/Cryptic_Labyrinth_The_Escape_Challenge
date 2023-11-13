//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerAttack : MonoBehaviour
//{
//    public Player FirstPersonController;

//    void Update()
//    {
//        if (Input.GetButtonDown("Attack"))
//        {
//            // Find all AI agents within a certain range
//            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5.0f, LayerMask.GetMask("AI"));

//            foreach (Collider collider in hitColliders)
//            {
//                // Check the distance to each AI agent before dealing damage
//                float distanceToAI = Vector3.Distance(transform.position, collider.transform.position);

//                if (distanceToAI <= 5.0f)
//                {
//                    AiAgent aiAgent = collider.GetComponent<AiAgent>();

//                    if (aiAgent != null)
//                    {
//                        // Deal damage only if the AI agent is within the attack range
//                        FirstPersonController.DealDamageToAI(aiAgent.gameObject, 20);
//                    }
//                }
//            }
//        }
//    }
//}
