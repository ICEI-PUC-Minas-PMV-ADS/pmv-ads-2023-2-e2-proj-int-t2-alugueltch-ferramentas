# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

## Diagrama de Classes



![DiagramaDeclassesAluguelTech _resized](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/126488218/43d2e738-73ab-4a9b-a6a8-7eb6c9c9f2db)



<div align = "center">
Diagrama de Classes AluguelTech
</div>

## Modelo ER (Projeto Conceitual)

![Diagrama ER AluguelTech - Diagrama ER AluguelTech (1)](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/65717646/f6eab44e-5bcc-4842-8e0c-be4ce6c8e9d4)

## Projeto da Base de Dados

![WhatsApp Image 2023-09-23 at 17 53 54](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t2-alugueltch-ferramentas/assets/65717646/f2fd9fd2-4428-40b0-88b3-2f51ccacbe5c)

## Tecnologias Utilizadas

<div align ="justify"> O projeto AluguelTech é um sistema de gerenciamento de aluguéis de ferramentas que utiliza um conjunto de tecnologias modernas e eficientes para oferecer uma experiência completa e eficaz para os usuários. Aqui está uma visão geral das tecnologias utilizadas em cada camada do sistema.

### Front-end

- **Prototipagem:** Para criar protótipos de interfaces de usuário, a equipe utilizou o Figma. Essa ferramenta permitiu projetar e validar a aparência e o fluxo de interação do sistema antes da implementação.
- **Construção das telas:** A implementação das interfaces de usuário foi realizada utilizando o Visual Studio Code, onde foram escritos códigos HTML, CSS e Javascript para criar as páginas web do sistema. Além disso, o Bootstrap foi utilizado para agilizar o desenvolvimento e garantir um design responsivo e moderno.
  
### Armazenamento

- **Diagrama de classes e Modelo conceitual:** Para projetar a estrutura do banco de dados e suas relações, a equipe utilizou a ferramenta Lucidchart para criar diagramas de classes e o modelo conceitual do sistema. Isso ajudou a visualizar e planejar a estrutura de dados de forma clara.
- **Modelo físico:** O modelo físico do banco de dados foi criado e gerenciado utilizando o PgAdmin 4, uma interface gráfica para o PostgreSQL. Isso permitiu a criação de tabelas, índices e relacionamentos de forma eficiente.
- **Sistema de gerenciamento de banco de dados (SGBD):** O banco de dados utilizado foi o PostgreSQL, um sistema de gerenciamento de banco de dados relacional de código aberto e altamente confiável. O pgAdmin 4 foi usado para administrar e interagir com o banco de dados.
  
### Back-end

- **Linguagem de programação:** O back-end do AluguelTech foi desenvolvido utilizando a linguagem de programação C#, que é conhecida por sua robustez e desempenho.
- **Framework:** O framework escolhido foi o .NET 6, que oferece um ambiente de desenvolvimento poderoso e flexível para criar aplicativos web e serviços.
- **Entity Framework:** O Entity Framework foi utilizado para a camada de acesso a dados, permitindo que a aplicação interaja com o banco de dados de forma eficiente e simplificada, utilizando objetos e consultas LINQ.
  
Essas tecnologias foram cuidadosamente escolhidas para garantir que o AluguelTech seja uma solução sólida e escalável para o gerenciamento de aluguéis de ferramentas, oferecendo uma experiência de usuário intuitiva e confiável, enquanto mantém um banco de dados robusto e de alto desempenho no backend. </div>
