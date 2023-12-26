using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AiAttack : AiState

{

    public UnityEvent takedmg;
    float attackCooldown = 2.0f; // Tempo de recarga entre ataques
    float timeSinceLastAttack = 0.0f;

    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }

    public void Enter(AiAgent agent)
    {
        // Coloque aqui qualquer c�digo de inicializa��o do estado de ataque
    }

    public void Update(AiAgent agent)
    {
        timeSinceLastAttack += Time.deltaTime;

        if (timeSinceLastAttack >= attackCooldown)
        {
            float distanceToTarget = Vector3.Distance(agent.transform.position, agent.playerTransform.position);
            float attackRange = 3.0f;

            if (distanceToTarget <= attackRange)
            {
                // Ativar a anima��o de ataque
                agent.animator.SetBool("attack", true);
                
                // Execute a l�gica de causar dano ao jogador aqui
                // Por exemplo, voc� pode chamar uma fun��o no jogador para aplicar dano
                // Certifique-se de que o jogador tenha um script que lide com a aplica��o de dano

                // Ap�s o ataque, redefina o tempo desde o �ltimo ataque
                timeSinceLastAttack = 0.0f;
                timer1.Instance.Takedmg();
            }
            else
            {
                // Desativar a anima��o de ataque se o alvo estiver fora de alcance
                agent.animator.SetBool("attack", false);
            }
            Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
            Vector3 agentDirection = agent.transform.forward;
            float angle = Vector3.Angle(playerDirection, agentDirection);


            float distanceToPlayer = Vector3.Distance(agent.transform.position, agent.playerTransform.position);

            // Defina uma dist�ncia limite para mudar para o estado de ataque
            float attackDistance = 1.0f; // Ajuste conforme necess�rio
            // Defina um �ngulo m�ximo para a mudan�a para o estado de ataque
            if (distanceToPlayer >= attackDistance)
            {
                agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
            }
        }

        // Se necess�rio, adicione condi��es para sair do estado de ataque e transi��o para outros estados
    }

    public void Exit(AiAgent agent)
    {

        // Coloque aqui qualquer c�digo de sa�da do estado de ataque
    }
}

