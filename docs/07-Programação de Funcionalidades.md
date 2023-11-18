# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

Durante o desenvolvimento do projeto foram realizadas alterações em seu escopo que refletiram principalmente no design das telas. Portanto, as funcionalidades serão acompanhadas das imagens de cada sessão atualizadas.

|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-001| Permitir login de usuários | Login.cshtml / FuncionariosController.cs / login.css | 
|RF-002| Acesso de usuário admin   | Funcionarios[Create.cshtml / Edit.cshtml / Delete.cshtml] /  FuncionariosController.cs / FuncionariosAPIController |
|RF-003 RF-004 RF-005 RF-006| Criar orçamentos | Orcamentos[Create.cshtml] /  OrcamentosController.cs / OrcamentosAPIController.cs / orcamentos.js / orcamentos.css |
|RF-007 RF-008 RF-009 RF-010| Cadastrar, visualizar, editar e excluir clientes | Clientes[Create.cshtml] /  ClientesController.cs / ClientesAPIController.cs / Clientes[create.js] / Clientes[index.js] |
|RF-011 RF-012 RF-015 RF-016 RF-017| Registro e gestão de ferramentas | Ferramentums[Index.cshtml / Edit.cshtml / Details.cshtml / Delete.cshtml] /  FerramentumsController.cs / FerramentumsAPIController.cs |
|RF-013 e RF-014| Gerar aluguel | Orcamentos[Index.cshtml / Create.cshtml / Edit.cshtml / Details.cshtml / Delete.cshtml] /  OrcamentosController.cs / OrcamentosAPIController.cs / orcamentos.js / orcamentos_detalhes.js / orcamentos.css |
|RF-018| Relatórios | Relatorios[Index.cshtml] /  RelatoriosController.cs |

![1 home](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/124e1adf-b75a-4782-bef3-1721b5914c08)
![2 Home e gerenciamento de funcionarios](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/4569284f-92e8-406a-833d-6244409172a1)
![3 visualizacao de funcionarios](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/3efadbb5-19b8-4c05-8446-b52f34d3cd9d)
![4 cadastrar novo funcionario](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/2d5e12c2-35ff-4bc8-b784-9b2fdbdc506a)
![5 editar funcionario](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/c841188d-ff58-4c8b-b560-af4f23987f87)
![6 detalhes funcionario](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/6449486b-2959-43fe-a78a-26869fcf5766)
![7 deletar funcionario](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/b58607c8-13b8-4ee3-ae14-95237f4cc182)
![7 ver clientes](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/fae3203e-c930-456b-8f3b-6006e8d2a461)
![9 cadastrar novo cliente](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/a3e33f6a-c239-46d5-a7d4-848d6cd5e10c)
![10 editar cliente](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/a2534abc-a582-4ece-af8d-c78e10517319)
![11 detalhes cliente](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/fe1692b2-4e59-4c5a-99df-1d09b5b2e1ff)
![12 deletar cliente](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/b1379cb7-890e-4c64-809b-5231e160fe49)
![13 ver ferramentas](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/5c954d57-1305-431f-a6dc-20722fae536b)
![14 cadastrar ferramenta](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/c28df1f2-0293-4805-b629-89870c6fd310)
![15 editar ferramenta](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/8959f894-5df8-4a3e-ae78-c221cc6543a4)
![16 detalhes ferramenta](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/233f07ad-5555-4c08-8ba2-365e5b6e8823)
![17 deletar ferramenta](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/25d4fe76-a49e-4672-b77b-5c12e238e0b9)
![18 visualizacao de aluguel](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/5fb7a3df-b9e8-4bea-bfee-6b90a15f8396)
![19 novo orcamento aluguel](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/6ba3d10b-8503-4857-83e7-5f5a1712c1bf)
![20 orcamento pdf](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/ec042b9e-2b14-494c-a37b-dbdb55fa59b3)
![21 detalhes orcamento](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/4d992b14-a18a-43f1-9329-894ed2d044b8)
![22 deletar orcamento aluguel](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/128100886/bed546c7-c7d9-4bfd-8efc-bea4c488d751)



# Instruções de acesso

Não deixe de informar o link onde a aplicação estiver disponível para acesso (por exemplo: https://adota-pet.herokuapp.com/src/index.html).

Para login no sistema utilize um dos usuários abaixo:<br>
Login de usuário administrador: FUNC012 Senha: puc123<br>
Login de usuário: FUNC005 Senha: puc123<br>


> **Links Úteis**:
>
> - [Trabalhando com HTML5 Local Storage e JSON](https://www.devmedia.com.br/trabalhando-com-html5-local-storage-e-json/29045)
> - [JSON Tutorial](https://www.w3resource.com/JSON)
> - [JSON Data Set Sample](https://opensource.adobe.com/Spry/samples/data_region/JSONDataSetSample.html)
> - [JSON - Introduction (W3Schools)](https://www.w3schools.com/js/js_json_intro.asp)
> - [JSON Tutorial (TutorialsPoint)](https://www.tutorialspoint.com/json/index.htm)
