## Descrição do Jogo:
Neste jogo o objetivo principal é escapar do labirinto para ganhar o prêmio. Você começará em uma zona segura, que terá um local onde você poderá conseguir comida e outro para descansar.

A “Safezone” possui quatro portões que irão fechar ou abrir, dependendo do tempo, levando ao labirinto.

Dentro do labirinto possui armadilhas e inimigos que dificultam a progressão do jogador.

## Controlos:
Button/Touch Input-Action it Performs
W/Andar para a frente
S/Andar para trás
A/Andar para a esquerda
D/Andar para a direita
Shift/Correr
E/Interagir com os objetos
Space/Saltar
Mouse movement/Olhar á volta


## Técnicas de AI usadas

Para melhorar o funcionamento e otimização do jogo foram utilizadas diferentes técnicas de AI, principalmente na criação de inimigos e melhoramentos visuais.

### Máquina de Estados:

Uma máquina de estados é um modelo comportamental que permite que um objeto (no caso, um inimigo) mude seu comportamento com base em seu estado interno. Cada estado representa um conjunto específico de ações e transições entre os estados ocorrem em resposta a determinados eventos ou condições.

No jogo eram necessários 2 tipos de inimigos, chasers e patrollers ou seja era necessário que os inimigos contivessem uma máquina de estados com 3 estados diferentes(Attack, Chase,Patrol) que continham cada uma as suas condições. Os Patrollers como o nome indica movimentavam se entre pontos de patrulha previamente definidos, já os Chasers usando os métodos de Pathfinding que serão posteriormente explicados perseguiam o jogador. Caso um Patroller detectasse o jogador numa distância predefinida o seu estado passaria de patrol para chase, e caso em ambos os casos a distância fosse relativamente próxima o inimigo passaria para o estado de Attack e atacaria o jogador, se o jogador se afastasse ele voltaria então para um estado de perseguição(chase), estas verificações são feitas a cada frame do jogo permitindo assim que o AI faça a ação correta em cada momento do jogo

![StateMachine 1](https://github.com/joaofreitas25/Cryptic_Labyrinth_The_Escape_Challenge/assets/131669709/07125269-de85-48f4-8a1f-249e8778e99c)

![StateMachine2](https://github.com/joaofreitas25/Cryptic_Labyrinth_The_Escape_Challenge/assets/131669709/c8886597-713b-4974-9026-0e8854194afb)

### NavMesh e PathFinding

Para os chasers, ou quando o inimigo começa a perseguir o jogador é utilizado o NavMesh ou uma malha que contém uma representação simplificada do ambiente, indicando áreas acessíveis e navegáveis que neste caso seriam o labirinto e zonas inacessíveis que neste caso seria a “Safezone”.

Depois antes de poder iniciar a sua perseguição é necessário definir o alvo da perseguição, que neste caso seria o jogador, após determinado o inimigo fará o cálculo do caminho mais curto a percorrer até ao alvo e tendo sempre em atenção obstáculos que possam dificultar a sua trajetória, estes cálculos são sempre feitos em tempo real/frame a frame permitindo assim se adaptar às mudanças de posição do jogador e a obstáculos que poderão surgir pelo caminho. 

Esta perseguição só será interrompida se o inimigo se encontrar relativamente perto do jogador, utilizando assim a máquina de estados anteriormente referida para transitar para um estado de ataque.
![NavMesh](https://github.com/joaofreitas25/Cryptic_Labyrinth_The_Escape_Challenge/assets/131669709/ab1982ce-7df4-46ed-8b0f-99f01b464c29)

### A* (A Estrela)

Devido ao tamanho do mapa, foi utilizado um algoritmo que nos permitisse gerar relva/vegetação pelo mapa de forma aleatória, o algoritmo utilizado foi o A* que é um algoritmo de busca informada utilizado para encontrar o caminho mais curto entre dois pontos em um grafo.
O A* é constituído pelos seguintes elementos:

* Grid: O ambiente de jogo é representado por uma grade (grid) na qual cada célula representa uma posição no espaço. Cada célula pode ser acessível (walkable) ou bloqueada por obstáculo(obstacle);

* Nós (Nodes): Cada célula da grade é um nó (node) no grafo e cada nó armazena informações como sua posição,e custos.

* Lista Aberta: Contém os nós que precisam ser avaliados;

* Lista Fechada: Contém os nós que já foram avaliados;

Para iniciar adicionasse um node à lista aberta verifica se os seus custos, e movimenta se para os seus vizinhos verificando os seus custos e adicionando os à lista aberta, continuando até ao node final seja encontrado, quando isso acontece o caminho é reconstruído a partir do node final até ao inicial .

Utilizando este conhecimento foi implementada uma função (CreateGrid()) que cria a grid e os nodes, depois através da função SpawnVegetation() que executa o pathfinding calculamos os locais onde a vegetação pode ser gerada, utilizando também um sistema de deteção de obstáculos(IsPositionWalkable()) , que verifica se existem colisões com objetos com a tag de “obstacle”.

Para gerar a vegetação foi criada uma matriz de matrizes(batches) que armazena matrizes de transformação que contêm posição, rotação e tamanho. Depois com a função  GeneratePosition(), a vegetação é gerada de forma aleatória dentro da grade usando um loop duplo para percorrer todas as posições da grade, previamente definidas e usando o DrawMesh para “desenhar” a vegetação na cena.


![Aestrela1](https://github.com/joaofreitas25/Cryptic_Labyrinth_The_Escape_Challenge/assets/131669709/3da19522-a4b8-4926-93fe-1814e1fa343a)
![Aestrela2](https://github.com/joaofreitas25/Cryptic_Labyrinth_The_Escape_Challenge/assets/131669709/38b23cc7-5a11-4e6a-92a7-2fc1b99a062a)
![Aestrela3](https://github.com/joaofreitas25/Cryptic_Labyrinth_The_Escape_Challenge/assets/131669709/da2ce77b-dabc-4f2d-9f0f-1afb922fb70a)
