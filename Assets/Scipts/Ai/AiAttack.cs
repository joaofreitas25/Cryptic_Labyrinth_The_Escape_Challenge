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
        // Coloque aqui qualquer código de inicialização do estado de ataque
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
                // Ativar a animação de ataque
                agent.animator.SetBool("attack", true);
                
                // Execute a lógica de causar dano ao jogador aqui
                // Por exemplo, você pode chamar uma função no jogador para aplicar dano
                // Certifique-se de que o jogador tenha um script que lide com a aplicação de dano

                // Após o ataque, redefina o tempo desde o último ataque
                timeSinceLastAttack = 0.0f;
                timer1.Instance.Takedmg();
            }
            else
            {
                // Desativar a animação de ataque se o alvo estiver fora de alcance
                agent.animator.SetBool("attack", false);
            }
            Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
            Vector3 agentDirection = agent.transform.forward;
            float angle = Vector3.Angle(playerDirection, agentDirection);


            float distanceToPlayer = Vector3.Distance(agent.transform.position, agent.playerTransform.position);

            // Defina uma distância limite para mudar para o estado de ataque
            float attackDistance = 1.0f; // Ajuste conforme necessário
            // Defina um ângulo máximo para a mudança para o estado de ataque
            if (distanceToPlayer >= attackDistance)
            {
                agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
            }
        }

        // Se necessário, adicione condições para sair do estado de ataque e transição para outros estados
    }

    public void Exit(AiAgent agent)
    {
        // Coloque aqui qualquer código de saída do estado de ataque
    }
}

