# Ambev Developer Evaluation

## Tecnologias Usadas

- **.NET Core** (ou outra tecnologia que esteja utilizando)
- **PostgreSQL** (ou outro banco de dados que está utilizando)

## Banco de Dados e Dados Iniciais

Este projeto utiliza um banco de dados **PostgreSQL** e inclui um script SQL para facilitar a inserção de dados iniciais, como categorias, produtos e companhias.

O script SQL necessário para a configuração inicial do banco de dados está localizado no seguinte caminho:

/Adapters/Drivers/Infrastructure/Ambev.DeveloperEvaluation.ORM/SaleSeed.sql

### Como Executar o Script SQL

1. **Localize o arquivo `SaleSeed.sql`** no caminho indicado acima.

2. **Conecte-se ao seu banco de dados** utilizando uma ferramenta de sua preferência, como:
   - [pgAdmin](https://www.pgadmin.org/) (para PostgreSQL)
   - [DBeaver](https://dbeaver.io/)
   - Linha de comando do PostgreSQL (`psql`)

3. **Execute o script** no banco de dados. O script irá inserir as categorias, produtos e companhias iniciais.

4. **Verifique se os dados foram inseridos corretamente** nas tabelas `Categorys`, `Products` e `Companys`.

### Exemplo de Dados Inseridos

O script SQL irá inserir os seguintes dados:

- **Categorias**: Refrigerantes, Sucos, Águas
- **Produtos**: Coca-Cola, Fanta Laranja, Suco de Laranja, etc.
- **Companhias**: Ambev S.A., Ambev Filial Rio de Janeiro


## Como Configurar a String de Conexão

A string de conexão é essencial para que o seu projeto se conecte ao banco de dados PostgreSQL. Para configurá-la, siga os passos abaixo:

1. **Abra o arquivo de configuração**:
   
   O arquivo de configuração geralmente é o `appsettings.json` ou o arquivo equivalente dependendo da estrutura do seu projeto.

2. **Localize a seção de conexões**:

   Encontre a seção `"ConnectionStrings"`, onde você verá uma chave chamada `DefaultConnection` ou algo semelhante.

3. **Edite a string de conexão**:

   Substitua os valores de `Host`, `Database`, `Username` e `Password` com as informações do seu banco de dados. Aqui está um exemplo de como a string de conexão pode ficar:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=seubancodedados;Username=seuusuario;Password=suasenha"
   }
   
## Como Executar o Projeto

Após configurar o projeto e a string de conexão, você pode executar o projeto no **Visual Studio** ou **Visual Studio Code**.

### No Visual Studio

1. **Abra o projeto no Visual Studio**:
   - Clique duas vezes no arquivo `.sln` para abrir o projeto.
   
2. **Inicie a execução**:
   - Clique no botão **"Iniciar"** ou pressione `F5` no teclado.
   - O Visual Studio irá compilar e executar o projeto.

3. **Acesse a API**:
   - Após o projeto ser executado, a API estará disponível na URL configurada no arquivo `Properties/launchSettings.json`.
   - Você pode verificar a URL e a porta lá e acessar a API usando o navegador ou ferramentas como o **Postman**.

### No Visual Studio Code

1. **Abra o projeto no VS Code**:
   - Abra a pasta do projeto no VS Code utilizando o menu **File > Open Folder** ou o comando no terminal:

     ```bash
     code .
     ```

2. **Abra o terminal integrado**:
   - No VS Code, abra o terminal integrado através de **View > Terminal** ou utilizando o atalho `Ctrl + ~`.

3. **Execute o projeto**:
   - No terminal integrado, execute o comando:

     ```bash
     dotnet run
     ```

4. **Acesse a API**:
   - Após a execução, a API estará disponível na URL configurada no arquivo `Properties/launchSettings.json`.
   - Utilize o **Postman**, **curl** ou o navegador para fazer as requisições à API.

  
## Reflexões sobre a Implementação do Domínio e a Utilização de AggregateRoot

Durante o desenvolvimento, apliquei o conceito de **AggregateRoot** na **entidade `Sale`**, o que permitiu controlar toda a lógica de negócios relacionada à venda de forma centralizada. No entanto, é importante destacar que essa é apenas uma abordagem para organizar a lógica de negócios, e existem outras maneiras de estruturar esse comportamento.

### O que é um AggregateRoot?

No **Domain-Driven Design (DDD)**, um **AggregateRoot** é uma entidade central dentro de um agregado que garante que as regras de negócios sejam aplicadas corretamente e mantém a consistência do agregado. Um AggregateRoot fornece o ponto de entrada para todas as operações no agregado e controla a validade de seus dados e comportamentos.

### A Entidade `Sale` como AggregateRoot

Escolhi a **entidade `Sale`** como o **AggregateRoot** . Ela centraliza as operações relacionadas a vendas, como a adição de itens à venda, o cálculo de descontos e o controle do estado da venda. Aqui estão algumas responsabilidades que a entidade `Sale` assume:

- **Controle de Estado**: Métodos como `InitiateSale()`, `CancelSale()` e `FinishSale()` controlam os estados da venda, aplicando transições conforme as regras de negócios.
- **Gestão de Itens**: O método `AddOrRemoveSaleItem()` valida a quantidade e a aplicação de descontos, centralizando a lógica de inclusão/remoção de itens.
- **Cálculos de Valor**: A venda recalcula o valor total, descontos e valor a pagar sempre que um item é adicionado ou removido.
- **Validação de Regras de Negócio**: Regras como o número máximo de itens idênticos permitidos ou as condições para aplicar descontos são todas controladas pela própria **entidade `Sale`**.

### Alternativas à Implementação de `Sale` como AggregateRoot

Embora tenha seguido o padrão de **AggregateRoot** para a entidade **Sale**, há outras maneira(s) de organizar a lógica de negócios:

1. **Separar Lógica de Cálculos em um Serviço**
   - **Alternativa**: Em vez de centralizar a lógica de cálculo de preços, descontos e regras de negócio dentro da entidade **Sale**, poderíamos ter criado um **serviço de domínio** para essas operações.
   - **Exemplo**: Um serviço que aceita uma venda e seus itens, e então aplica todas as regras de negócio necessárias.
   - **Vantagens**: Maior flexibilidade para manipular o cálculo de preços e descontos em uma camada separada. A entidade **Sale** seria mais simples e focada apenas nos dados.
   - **Desvantagens**: A lógica de negócios ficaria espalhada entre a entidade e o serviço, o que poderia dificultar a manutenção e garantir a consistência de regras complexas.

### Justificativa para Usar `Sale` como AggregateRoot

Optar por **AggregateRoot** para a entidade **Sale** foi uma escolha que trouxe clareza e coesão ao modelo. Como a venda é o conceito central e envolve várias operações críticas (como o controle de itens e o cálculo de descontos), essa abordagem permitiu manter as regras de negócio bem definidas dentro de um único local, garantindo que a consistência fosse sempre mantida.

### Conclusão

Embora existam outras formas de modelar o comportamento de vendas e aplicar as regras de negócios, usar **AggregateRoot** para a **entidade `Sale`** proporcionou uma solução coesa e consistente. A escolha de seguir uma abordagem centralizada com **DDD** não apenas facilitou a manutenção do código, mas também proporcionou um caminho claro para futuras extensões e melhorias no sistema.


### Utilização do Padrão CQRS

Para lidar com a separação entre leitura e escrita no sistema, implementei o padrão **CQRS**. No caso das consultas (queries), criei um serviço específico para lidar com operações de leitura, permitindo:

- Consultas otimizadas e específicas para atender às necessidades do cliente.
- Separação clara entre a lógica de atualização e a lógica de consulta, simplificando a manutenção e a escalabilidade.
- Garantia de que a lógica de domínio permanecesse focada apenas nas operações de escrita.

Essa abordagem contribuiu para melhorar o desempenho do sistema ao reduzir a complexidade das entidades e otimizar os acessos às informações de venda.

### Conclusão Final

A utilização de **AggregateRoot** para a entidade **Sale** e a aplicação do padrão **CQRS** foram decisões que trouxeram clareza, eficiência e coesão ao modelo de domínio. Ambas as abordagens ajudaram a manter as regras de negócio centralizadas e a lógica de leitura otimizada, proporcionando uma base sólida para o crescimento e a evolução do sistema.

Além disso, durante o desenvolvimento, me esforcei para seguir ao máximo o template padrão definido, garantindo consistência com os demais componentes do projeto e facilitando a manutenção do código.

Entendo que a escolha de padrões e estratégias como essas pode gerar diferentes opiniões e abordagens alternativas. Ficaria muito feliz em discutir esse ponto com mais profundidade, explorar outras perspectivas e, quem sabe, identificar novas formas de aprimorar ainda mais a solução.
