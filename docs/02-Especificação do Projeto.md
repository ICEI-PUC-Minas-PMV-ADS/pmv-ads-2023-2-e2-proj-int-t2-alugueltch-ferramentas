# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

<p align="justify">A determinação do problema a ser tratado surgiu a partir de pesquisas e principalmente da observação dos métodos de operação e trabalho de comerciantes locais do ramo de aluguel de instrumentos e utensílios para atividades de bricolagem. Foi identificado que em sua maioria, os processos utilizados são ainda muito manuais e pouco efetivos. Diante disso, notamos a necessidade de um sistema interativo capaz de, além de oferecer auxílio, promover de maneira efetiva uma modernização na maneira de operar, realizando a automatização dos processos, trazendo organização, eficácia, aumentando a produtividade, e permitindo que esses empreendedores alcancem maior sucesso em seus negócios.

## Personas

#### Maria - Empreendedora iniciante
Idade: 30 anos

Profissão: Microempreendedora no ramo de aluguel de ferramentas

Experiência: Maria começou seu negócio recentemente e está aprendendo a administrar sua operação. Ela tem conhecimentos básicos de informática, mas não é especialista em tecnologia.

Desafios: Maria tem dificuldade em controlar seu estoque manualmente e às vezes enfrenta problemas com reservas de ferramentas em datas conflitantes. Além disso, criar orçamentos que possam ser enviados por e-mail, WhatsApp ou impressos para o cliente é uma tarefa complicada para ela, pois não possui um método eficiente para isso.

Objetivos: Ela deseja um software simples que a ajude a organizar seu estoque, emitir orçamentos rapidamente e evitar erros em seus contratos de aluguel. A facilidade de criar e compartilhar orçamentos com os clientes seria uma grande vantagem para seu negócio.

#### João - Comerciante Autônomo
Idade: 35 anos

Profissão: Comerciante autônomo de aluguel de ferramentas

Experiência: João tem experiência em seu setor, mas é novo no uso de softwares de gestão. Ele possui um computador que usa para o gerenciamento e está familiarizado com o uso de planilhas.

Desafios: João costuma perder o controle das manutenções necessárias para suas ferramentas e tem dificuldades em gerenciar os pagamentos e vencimentos dos contratos.

Objetivos: Ele busca um software amigável que o ajude a acompanhar as manutenções de suas ferramentas, emitir relatórios financeiros simples e automatizar lembretes de devolução. Também valoriza que esses relatórios possam ser exportados em forma de planilha já que tem costume de utilizá-las.

#### Ana - Proprietária de Loja de Ferramentas
Idade: 40 anos

Profissão: Proprietária de uma loja de ferramentas e aluguel

Experiência: Ana possui um negócio estabelecido e um pouco de experiência em gestão de estoque, mas não tem muito tempo para lidar com detalhes administrativos.

Desafios: Ela enfrenta dificuldades em rastrear as ferramentas mais populares e suas taxas de aluguel. Manter os registros financeiros atualizados é um desafio constante.

Objetivos: Ana procura um software que simplifique a gestão do estoque, forneça insights sobre as ferramentas mais alugadas e ajude a automatizar tarefas financeiras.


#### André - Empreendedor
Idade: 28 anos

Profissão: Empreendedor que gerencia um pequeno negócio de aluguel de ferramentas, além de outras atividades

Experiência: André é um empreendedor que tenta equilibrar várias tarefas ao mesmo tempo. Ele tem alguma experiência em softwares, mas valoriza a simplicidade.

Desafios: Ele luta para lembrar-se de agendamentos regulares e têm dificuldade em organizar sua papelada e finanças.

Objetivos: André procura um software intuitivo que possa gerenciar suas locações, gerir documentos e oferecer relatórios financeiros claros para simplificar as operações diárias.


## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Maria  | Criar orçamentos de forma fácil e rápida para os clientes e enviá-los por e-mail, WhatsApp ou impressos          | Garantir que os orçamentos sejam precisos e profissionais, melhorando seu retorno e comunicação com o cliente               |
|João       |   Acompanhar manutenções de ferramentas, emitir relatórios financeiros e receber lembretes automatizados               | Gerenciar melhor a manutenção das ferramentas, obter insights financeiros e manter um fluxo de trabalho mais organizado |
|Ana      | Simplificar a gestão do estoque, obter dados sobre ferramentas populares e aprimorar tarefas financeiras                 | Agilizar o controle do estoque, melhorar a eficiência do negócio e tomar decisões baseadas em dados |
|André      | Gerenciar de forma organizada as locações, obter relatórios financeiros claros e simplificar as operações diárias                 | Aumentar a eficiência das  operações, gerenciamento e visualização financeira |


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Registrar as ferramentas disponíveis para aluguel, incluindo descrição, categoria e condição. Permitindo adição, edição e exclusão de ferramentas no sistema. | ALTA | 
|RF-002| Acompanhar o status de cada ferramenta (disponível, alugada, em manutenção, etc.).   | ALTA |
|RF-003| O usuário deve ser capaz de gerar reservas equipamentos para datas específicas. A disponibilidade dos equipamentos deve ser verificada em tempo real para evitar conflitos. | ALTA |
|RF-004| Gerar contratos de aluguel com detalhes do cliente, ferramentas, dados e termos.   | MÉDIA |
|RF-005| Registrar as manutenções realizadas em cada equipamento, incluindo datas e detalhes.   | ALTA |
|RF-006| Agendar automaticamente manutenções regulares para as ferramentas. | MÉDIA |
|RF-007| Tela contendo as informações sobre datas de retirada, devolução e manutenção. | ALTA |
|RF-008| Gerar relatórios detalhados de gastos,ferramentas mais alugadas e alocação de recursos. | ALTA |




### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| A interface deve ser intuitiva e fácil de usar, considerando diferentes perfis de usuários. | ALTA | 
|RNF-002| Garantir a segurança dos dados dos usuários e informações confidenciais. | ALTA | 
|RNF-003| A plataforma deve ser flexível o suficiente para se adaptar a mudanças nos processos internos da empresa.| MÉDIA |
|RNF-004| Implementar backups regulares dos dados para evitar perda de informações. | ALTA | 
|RNF-005| Oferecer suporte técnico para lidar com problemas e dúvidas dos usuários. | ALTA | 
|RNF-006| A plataforma deve estar disponível a maior parte do tempo para garantir que os usuários possam acessar quando necessário. | ALTA | 

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |



## Diagrama de Casos de Uso

(docs/img/Fluxogramas.png)

