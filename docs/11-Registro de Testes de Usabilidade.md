# Registro de Testes de Usabilidade

## Propósito do teste
O propósito é verificar se a interface e a performance da solução proporcionam uma boa experiência para o usuário, ao identificar se há necessidade de alterações antes da entrega do projeto.

## Teste Heurístico

Foi definida a seguinte escala para definição dos níveis de problemas de usabilidade a serem resolvidos pela equipe:

| Escala       | Descrição                                         
|--------|-
|Nível 01  |Não há um problema de usabilidade         | 
|Nível 02 | Problema estético que só será corrigido caso haja tempo disponível.
|Nível 03 | Problema de usabilidade com baixa prioridade na correção.  
|Nível 04 | Problema com média/alta prioridade de correção.  
|Nível 05 | Problema com altíssima necessidade de correção, inviabilizando a entrega da funcionalidade.


## Resultados Iniciais (Etapa 3)

Os primeiros testes realizados foram relacionados as telas de visualização, cadastro, edição e exclusão de Clientes e Funcionários.
Os avaliadores receberam um roteiro onde deveriam logar no sistema com as credenciais fornecidas e, no caso dos usuários administradores, navegar pela plataforma e realizar o cadastro, edição, visualização das edições e exclusão de um novo funcionário.
Para os avaliadores que receberam credenciais de um funcionário, deveriam realizar as mesmas ações porém, cadastrando, editando, visualizando alterações e excluindo um cliente do sistema.

#### Nota: Nem todas as heurísticas foram levadas em consideração para os testes iniciais devido a fase atual do projeto.


| Heurísticas (Nielsen)   |  Notas dos avaliadores   | Consenso | Considerações   | Melhorias   |
| ------------------- | :---------------------: | :-----------: | -------------------- | -------------------- |
| 01-Visibilidade do Status do Sistema | Avaliador 1: 1  <br> Avaliador 2: 3 <br> Avaliador 3: 1 | 3 | O sistema apresenta informações de onde o usuário está com títulos e subtítulos como por exemplo "Cadastro de Cliente" mas em algumas telas não há contraste suficiente entre o título e o conteúdo ou há ausência de título em telas como o painel inicial dos clientes.  | 1. Melhorar o contraste entre o título das páginas e seu conteúdo. <br> 2. Adicionar títulos ou subtítulos que indiquem melhor onde o usuário se encontra. |
| 02-Correspondência entre o sistema e o mundo real | Avaliador 1: 1  <br> Avaliador 2: 1 <br> Avaliador 3: 1 | 1 | O sistema apresenta linguagem cotidiana, de fácil entendimento além de símbolos de fácil compreensão. | N/A |
| 03-Controle e liberdade para o usuário | Avaliador 1: 1  <br> Avaliador 2: 1 <br> Avaliador 3: 1 | 1 | O sistema apresenta opções que trazem liberdade ao usuário, podendo desfazer ações ou voltar atrás de uma decisão. | N/A |
| 04- Consistência e padronização | Avaliador 1: 1  <br> Avaliador 2: 1 <br> Avaliador 3: 1 | 1 | O sistema utiliza os mesmos padrões de cores e estilos para botões de ação primários e secundários, assim como trás padronização em formulários e em elementos que se repetem pelas telas. | N/A |
| 05-Prevenção de erros | Avaliador 1: 1  <br> Avaliador 2: 1 <br> Avaliador 3: 1 | 1 | O sistema informa através de mensagens na cor vermelha, exatamente abaixo do erro cometido além de marcá-lo com uma borda, indicando onde o usuário errou e dando a oportunidade de corrigir. O envio do formulário também é interrompido caso tenha dados errados ou não preenchidos. | N/A |
| 06-Reconhecimento em vez de recordação | Avaliador 1: 1  <br> Avaliador 2: 1 <br> Avaliador 3: 1 | 1 | O sistema é direto e seu conteúdo é organizado de forma relevante para o usuário, além de ser consistente na aprensentação de informações seguindo padrões estéticos e de posição na tela.  | N/A |
| 07-Eficiência e flexibilidade de uso | Avaliador 1: 1  <br> Avaliador 2: 1 <br> Avaliador 3: 1 | 1 | O sistema é intuitivo, trazendo apenas as informações necessárias ao usuário, além de possibilitar o uso de alguns atalhos no menu lateral que fazem o direcionamento para as opções mais relevantes. O sistema também trás barras de pesquisa em páginas com conteúdo extenso, facilitando o trabalho de procurar. | N/A |
| 08-Estética e design minimalista | Avaliador 1: 1  <br> Avaliador 2: 1 <br> Avaliador 3: 1 | 1 | O sistema possui uma interface minimalista com boa relação de contraste e apresenta somente informações relevantes ao usuário. O menu lateral é simples e intuitivo, servindo como guia e atalho para as telas do sistema. | N/A |
| 09-Ajude os usuários a reconhecer, diagnosticar e recuperar erros | Avaliador 1: 1  <br> Avaliador 2: 1 <br> Avaliador 3: 1 | 1 | O sistema informa através de mensagens na cor vermelha, exatamente abaixo do erro cometido além de marcá-lo com uma borda, indicando onde o usuário errou e dando a oportunidade de corrigir. O envio do formulário também é interrompido caso tenha dados errados ou não preenchidos. | N/A |
| 10-Ajuda e documentação | Este teste não foi realizado devido a esta funcionalidade ainda não ter sido implementada no sistema. Todas as dúvidas registradas durante o uso do sistema foram sanadas diretamente com o monitor responsável.  | -/- | -/- | -/- |

## Etapa 4 - Resultados

Conforme os testes da Etapa 3, foram feitas alterações no contraste dos títulos das páginas e seu conteúdo, além disso, foram adicionados títulos ou subtítulos especificando em qual tela do sistema o usuário se encontra no momento. Devido a isso o teste foi repetido e os resultados estão a seguir:

Atualização:

| Heurísticas (Nielsen)   |  Notas dos avaliadores   | Consenso | Considerações   | Melhorias   |
| ------------------- | :---------------------: | :-----------: | -------------------- | -------------------- |
| 01-Visibilidade do Status do Sistema | Avaliador 1: 0  <br> Avaliador 2: 0 <br> Avaliador 3: 1 | 1 | O sistema apresenta informações de onde o usuário está com títulos e subtítulos como por exemplo "Cadastro de Cliente" e nas telas onde essas informações estavam ausentes, foi feita a adição. | N/A |

Para esta etapa, foram implementadas novas telas ao escopo dos testes, portanto além das anteriores, foram incluídas as telas de Ferramentas, Orçamentos e Relatórios.
Os avaliadores receberam um roteiro onde deveriam: 
- logar no sistema com as credenciais fornecidas
- navegar pela plataforma e realizar o cadastro, edição, visualização das edições e exclusão de uma nova ferramenta.
- cadastrar um novo aluguel e, na tela de cadastro, verificar a possibilidade de gerar um orçamento em PDF que deve conter as informações preenchidas no aluguel. E também as demais ações listadas: visualizar, editar e excluir.
- Verificar se o sistema gera o relatório selecionado em formato PDF conforme a seleção do usuário.
