## Descrição
Este projeto foi desenvolvido como parte do teste de avaliação para vaga da Bitzen.

## Projetos da solução
	
### General
Coloquei todos os componentes, que não estão ligados diretamente ao negócio do projeto, nesta biblioteca.

Criei apenas um projeto para o teste, mas ele poderia ser divído em outras bibliotecas menores e mais específicas, de acordo com os tipos de componentes nela (como gerais, web, api, autenticação) ou de suas dependências.
	
### Domain
Toda a regra de negócio principal fica nessa biblioteca.

O propósito é criar uma camada tanto para isolamento, quanto reuso e organização, já que projetos client possuem muitos arquivos apenas para seu próprio funcionamento.

Também omiti o "Domain" do namespace no projeto, assim o nome da biblioteca fica claro para organização na solução de projetos, mas o namespace flui junto com as outras aplicações, permitindo estendê-los apesar de estarem em projetos diferentes.

Um exemplo é a interface "IContextoDeDados" que está na organização física "BtzTransports.Domain.Context", mas no namespace "BtzTransports.Context".

A classe de implementação "ContextoDeDados" está dentro do mesmo namespace, apesar de estar numa biblioteca diferente.

### Context
Todo o código para mapeamento do banco de dados, e das classes como entidades, está nessa biblioteca.

### Web
Contém todo código para interação da aplicação client com as regras de negócios.

Mantive regras simples de consulta de dados, mas a partir do momento que se tornarem muito complexas, o ideal é movê-las para o Domain. Dependendo da complexidade, até em classes únicas responsáveis apenas pela consulta.

## Injeção de dependência
Todo o projeto está configurado com injeção de dependência pelo SimpleInjector.

O container é configurado no projeto web em "InjectionConfig" e os modulos de registros estão em cada projeto na pasta "Properties".

O ContextoDeDados está configurado como uma única instância por requisição, então a materialização de entidades do banco é feita por uma única conexão, independente de local que ele serve como dependência.

Isso também permitiria criar escopos de transação aninhados, sem a preocupação de qual parte do código iniciaria a transação.

## Códificação
Mantive o código de componentes não ligados ao negócio em inglês.

Para o código em português, utilizei inclusive pronomes em nomes de variáveis, métodos e classes, para uma melhor leitura do código.

A linaguem já não possui um tamanho curto para nomes como antigamente. O intellisense da IDE também é muito robusto, não tendo dificuldades com isso.
