# Sistema de Gestão de Festas

Uma aplicação de console desenvolvida em C# para gerenciar a organização de eventos, como casamentos, formaturas, festas de empresa, aniversários e eventos livres. O sistema permite cadastrar clientes, agendar festas, selecionar tipos de festas e espaços disponíveis, além de calcular o custo total do evento com base nos serviços e itens selecionados.

## Funcionalidades
- Cadastro de clientes e convidados
- Agendamento de festas em datas disponíveis
- Seleção do tipo de festa (Casamento, Formatura, Festa de empresa, Festa de aniversário, Livre)
- Seleção de espaços disponíveis para o evento
- Solicitação de comidas e bebidas para todos os tipos de festa, exceto "Livre"
- Cálculo do custo total da festa

## Tipos de Festa
1. **Casamento**
2. **Formatura**
3. **Festa de empresa**
4. **Festa de aniversário**
5. **Livre** (Apenas aluguel do espaço, sem opção de adicionar comidas e bebidas)

## Regras de Negócio
- Festas do tipo "Livre" não podem incluir comidas e bebidas.
- As festas são marcadas com base no número de convidados e na disponibilidade dos espaços.
- Cada espaço tem uma capacidade máxima de convidados:
  - Espaços A, B, C, D: 100 pessoas cada
  - Espaços E, F: 200 pessoas cada
  - Espaço G: 50 pessoas
  - Espaço H: 500 pessoas

## Estrutura do Projeto
O projeto está organizado nas seguintes classes principais:

- **Program**: Classe principal que contém o ponto de entrada do aplicativo.
- **GestorFesta**: Classe responsável pela gestão dos eventos, incluindo a marcação de festas e busca de espaços disponíveis.
- **Agendar**: Classe que lida com o agendamento de datas para os eventos.
- **Festa**: Classe base para diferentes tipos de festas.
- **Casamento**, **Formatura**, **FestaEmpresa**, **Aniversario**, **Livre**: Classes derivadas de `Festa` que representam os diferentes tipos de festas.
- **Salgados**: Classe que gerencia a solicitação de salgados.
- **GerenciadorBebidas**: Classe que gerencia a solicitação de bebidas.
- **CalculoPreco**: Classe que calcula o preço total do evento.

## Configuração do Projeto
Siga os passos abaixo para configurar e executar o projeto:

### 1. Clone este repositório em sua máquina local:
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   ```

- Certifique-se de ter o ambiente de desenvolvimento .NET configurado.

- Clone o banco de dados no seu servidor local.

- Configure a conexão com o banco de dados:

  No código da aplicação, ajuste a string de conexão na classe ConexaoBanco.
- Abra o arquivo ConexaoBanco.cs e localize a propriedade data_source.
- Altere a string de conexão conforme necessário, inserindo seu usuário e senha para acessar o servidor local.
- Execute o projeto em seu ambiente de desenvolvimento.

### Observação
O Sistema de Gerenciamento de Banco de Dados (SGBD) utilizado no projeto, e no qual a lista de comandos se baseia, é o MySQL Workbench.

### Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

### Licença
Este projeto está licenciado sob a Licença MIT. Consulte o arquivo LICENSE para obter mais informações.

## Autores

- [@Gustavo-gcr](https://github.com/Gustavo-gcr)
