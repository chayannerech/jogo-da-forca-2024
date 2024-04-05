
# Jogo da Forca

<p align="center">
	<img width="650" src="docs/img/jogo-da-forca-2.gif">
</p>

## Projeto

Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2024

---
## Detalhes

O computador escolherá, de maneira aleatória, uma palavra entre várias possibilidades*, e o jogador deve chutar, letra por letra, até adivinhá-la.

Se o jogador chutar 5 letras erradas, ele perde.

Ao final de cada jogo, o computador informa a pontuação do jogador.

---
## Entrada

Os jogadores são solicitados a inserir uma letra por vez através do console. Se a letra estiver presente na palavra, ela será revelada nas posições correspondentes. Se a letra não estiver presente na palavra, uma parte do boneco da forca será desenhada.

---
## Funcionalidades

- __Escolha de Palavra Secreta__: Uma palavra é escolhida aleatoriamente no início de cada jogo;
- __Dica__: O jogo conta com uma dica inicial acerca da palavra secreta;
- __Representação da Forca__: A forca é desenhada progressivamente no console, com cada erro do jogador;
- __Histórico de Tentativas__: As letras que já foram testadas são visíveis ao usuário;
- __Feedback Visual__: As letras corretamente adivinhadas são exibidas na posição correta, enquanto as não descobertas permanecem ocultas;
- __Contagem de Erros__: O jogo acompanha o número de erros cometidos pelo jogador e termina quando o máximo permitido é alcançado;
- __Pontuação__: Ao final de cada jogo, o computador informa as pontuações anteriores e a pontuação atual do jogador.

---
## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.
---
## Como Usar

#### Clone o Repositório
```
git clone https://github.com/academia-do-programador/jogo-da-forca-2024.git
```

#### Navegue até a pasta raiz da solução
```
cd jogo-da-forca-2024
```

#### Restaure as dependências
```
dotnet restore
```

#### Navegue até a pasta do projeto
```
cd JogoDaForca.ConsoleApp
```

#### Execute o projeto
```
dotnet run
```