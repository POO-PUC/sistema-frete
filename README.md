# Estrutura do Projeto

Este projeto utiliza uma arquitetura multicamadas em C# para uma aplicação MVC, facilitando a organização do código e promovendo separação de responsabilidades.

## Estrutura das Camadas

### 1. Dominio
Contém as classes das entidades do banco de dados, que representam os modelos do domínio do sistema.

### 2. DTO
Armazena as classes das entidades em formato de Data Transfer Object (DTO), utilizadas para transferência de dados entre as camadas sem expor diretamente as entidades do domínio.

### 3. Repositorio
Esta camada gerencia o acesso aos dados e é composta por três seções principais:

   - **Conversor**: Inclui classes responsáveis pela conversão entre DTOs e Objetos do domínio e vice-versa. Essas conversões são realizadas para que os serviços trabalhem com o formato adequado.

   - **Validações**: Contém classes para validar atributos das entidades. Cada método de validação é chamado na classe Conversor, assegurando que o objeto esteja pronto para ser persistido no banco de dados antes de chegar ao serviço.

   - **Repositorio**: Implementa as funções de CRUD (Create, Read, Update, Delete) para as entidades. Futuramente, também será adicionado um método para verificar se uma entidade já existe no banco, aumentando a eficiência e consistência dos dados.

#### ConfigBanco
Inclui a configuração da conexão com o banco de dados, centralizando os parâmetros de acesso e facilitando a manutenção e a troca de ambiente.

### 4. Serviço
A camada de serviço contém classes que chamam as operações do repositório para executar ações de CRUD. Estas classes serão chamadas pelas controllers para executar as regras de negócio e manipulação de dados.

### 5. Mvc
Contém a interface da aplicação, organizada em:

   - **Controller**: Responsável por receber as requisições do usuário, invocar os serviços apropriados e retornar as respostas necessárias.
   
   - **View**: Armazena as interfaces visuais (não implementadas ainda) que serão apresentadas ao usuário final.

### 6. Teste
Contém testes que realizam o crud de cada entidade da nossa aplicação definida na cmada de Dominio.
Usamos uma classe para testes e uma Fabrica de objetos para produzir os dados que vamos enviar para o banco durante o teste.

---

Esta estrutura modular facilita a escalabilidade e manutenção do projeto, promovendo a reutilização de código e a aplicação de boas práticas de desenvolvimento.
