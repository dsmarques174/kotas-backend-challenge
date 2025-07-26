# Backend Challenge - Pokémons




## Estrutura base do Projeto PokemonChallenge

PokemonChallenge
|
|-- Controllers
|   |-- PokemonController (Get por ID e Lista aleatória)
|   |-- MestreController (Post, Get por ID e Lista)
|   |-- CapturaController (Post, Get por ID e Lista)
|
|-- Models (Modelos de dados)
|   |-- Pokemon (Sem uso já que é recuperado da PokeAPI)
│   |-- Mestre
│   |-- CapturaPokemon 
|
|-- Services (Classes de serviços dos processos especificos)
|   |-- PokemonService
|   |-- MestreService
|   |-- CapturaPokemonService
|
|-- DTOs
|   |-- PokemonDto
|   |-- MestreDto
|   |-- CapturaPokemonDto
|   |-- PokemonGeradoDto (Gerado com o colar especial Json as classes, apenas para agilizar)
|
|── Data
|   |-- AppDbContext (contexto de dados da API usando o Entity Framework Core)
|
|-- Program (Comecei o desenvolvimento com o InMemoryDatabase pra agilizar e posteriormente configurei o SQLite, também fiz a configuração do HttpCliente para a PokeAPI e optei pelo Swagger por ter mais facilidade de utilizar e poder testar os EndPoints)


## Backend-end

- Get para 10 Pokémon aleatórios 
  ### (Montei uma lista com 10 ids escolhidos com Random)
- GetByID para 1 Pokémon específico 
  ### (Um simples Get na PokeAPI com o id)
- Cadastro do mestre pokemon (dados básicos como nome, idade e cpf) em SQLite 
  ### (Feito cadastro dos dados básicos com simples validação de CPF já cadastrado)
- Post para informar que um Pokémon foi capturado.
  ### (Feito cadastro de captura de pokemon com validação de integridade de Mestre e Pokemon)
- Listagem dos Pokémon já capturados.
  ### (Listagem de todos os capturados)
