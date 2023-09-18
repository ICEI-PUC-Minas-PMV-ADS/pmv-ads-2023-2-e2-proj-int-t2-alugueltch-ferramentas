# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Não deixe de enumerar os casos de teste de forma sequencial e de garantir que o(s) requisito(s) associado(s) a cada um deles está(ão) correto(s) - de acordo com o que foi definido na seção "2 - Especificação do Projeto". 

Por exemplo:
 
| **Caso de Teste** 	| **CT-01 – Gerenciar Ferramentas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| - RF-01: O sistema deve permitir o registro de ferramentas disponíveis para aluguel, incluindo descrição, preço, marca, tipo. <br> - RF-02: O sistema deve permitir a adição, edição e exclusão de ferramentas no sistema. |
| Objetivo do Teste 	| Verificar se as funcionalidades de adição, edição e exclusão de ferramentas estão funcionando corretamente e se as informações das ferramentas são armazenadas corretamente no sistema. |
| Passos 	| - Acessar o sistema de gerenciamento de aluguel de ferramentas. <br> - Realizar login como usuário. <br> - Navegar para a página de gerenciamento de ferramentas. <br> - Executar os seguintes casos de teste em sequência.|
|  	|  	|
| Caso de Teste 	| CT-01.1 – Adicionar Ferramenta	|
| Passos 	| - Clicar na opção "Novo Equipamento". <br> - Preencher o formulário de cadastro de nova ferramenta. <br> - Confirmar a adição da ferramenta. <br> - Verificar se a ferramenta é exibida na lista de ferramentas disponíveis. |
|  	|  	|
| Caso de Teste 	| CT-01.2 – Editar Ferramenta	|
| Passos 	| - Selecionar uma ferramenta existente na lista. <br> - Modificar a descrição, categoria ou condição da ferramenta. <br> - Confirmar a edição da ferramenta. <br> - Verificar se as informações da ferramenta foram atualizadas corretamente. |
| Caso de Teste 	| CT-01.3 – Excluir Ferramenta	|
| Passos 	| - Selecionar uma ferramenta existente na lista. <br> - Clicar na opção "Excluir Ferramenta". <br> - Confirmar a exclusão da ferramenta. <br> - Verificar se a ferramenta foi removida da lista de ferramentas disponíveis. |
| Critérios de Êxito 	| - Os casos de teste são executados sem erros ou falhas. <br> - As informações das ferramentas são armazenadas corretamente no sistema. <br> - As operações de adição, edição e exclusão são seguras e protegidas contra erros. <br> - As ações de adição, edição e exclusão resultam em atualizações corretas na lista de ferramentas disponíveis. |

| **Caso de Teste** 	| **CT-02 – Acompanhar Status de Ferramentas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-03: O sistema deve permitir o acompanhamento do status de cada ferramenta, que pode ser "disponível," "alugada," "manutenção", "inspeção" e "indisponível".|
| Objetivo do Teste 	| Verificar se o sistema é capaz de acompanhar o status de cada ferramenta. |
| Passos 	| - Acessar o sistema de gerenciamento de aluguel de ferramentas. <br> - Realizar login como usuário. <br> - Navegar para a página de gerenciamento de ferramentas. <br> - Selecionar uma ferramenta existente na lista. <br> - Verificar o status atual da ferramenta. <br> - Confirmar se o status da ferramenta está correto.|
| Critérios de Êxito 	| - Os casos de teste são executados sem erros ou falhas. <br> - O sistema é capaz de acompanhar o status de cada ferramenta corretamente. |

| **Caso de Teste** 	| **CT-03 – Atualizar Status de Ferramentas** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-04: O sistema deve permitir a atualização do status de cada ferramenta.|
| Objetivo do Teste 	| Verificar se as atualizações de status estão funcionando corretamente. |
| Passos 	| - Selecionar uma ferramenta existente na lista. <br> - Clicar na opção "Atualizar Status." <br> - Selecionar um novo status para a ferramenta (por exemplo, "alugada" ou "em manutenção"). <br> - Confirmar a atualização do status da ferramenta. <br> - Verificar se o status da ferramenta foi atualizado corretamente.|
| Critérios de Êxito 	| - Os casos de teste são executados sem erros ou falhas. <br> - As atualizações de status são realizadas com sucesso e refletem a mudança no sistema. |

| **Caso de Teste** 	| **CT-04 – Verificar Disponibilidade em Tempo Real** 	|
|:---:	|:---:	|
|	Requisito Associado 	| - RF-06: O sistema deve verificar a disponibilidade dos equipamentos em tempo real para evitar conflitos de reserva.|
| Objetivo do Teste 	| Verificar a disponibilidade em tempo real para evitar conflitos de reserva. |
| Passos 	| - Acessar o sistema de gerenciamento de aluguel de ferramentas. <br> - Realizar login como usuário. <br> - Navegar para a página de reserva de equipamentos. <br> - Tentar gerar uma reserva para um equipamento que já está reservado para a mesma data e hora. <br> - Verificar se o sistema impede a reserva devido à indisponibilidade do equipamento.|
| Critérios de Êxito 	| - Os casos de teste são executados sem erros ou falhas. <br> - O sistema verifica a disponibilidade em tempo real e evita conflitos de reserva. |

| **Caso de Teste** 	| **CT-0x – xxxxxxxxxxxxx** 	|
|:---:	|:---:	|
|	Requisito Associado 	| - RF-0x: xxxxxxx xxxxxxxxxx xxxxxxxxxxxxx xxxxxxxxxxx.|
| Objetivo do Teste 	| xxxxxxxxxxxxxxxxxxxxxxxxxx. |
| Passos 	| - Acessar o sistema de gerenciamento de aluguel de ferramentas. <br> - Realizar login como usuário. <br> - Navegar para a página de reserva de equipamentos. <br> - xxxxxxxxxxxxxxxxxxxxx. <br> - xxxxxxxxxxxxxxxxxxxx.|
| Critérios de Êxito 	| - Os casos de teste são executados sem erros ou falhas. <br> - xxxxxxxxxxxxxxxxx. |
 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
