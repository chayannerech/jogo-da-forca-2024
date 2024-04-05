
# Jogo da Forca

<p align="center">
	<img width="650" src="docs/img/jogo-da-forca-2.gif">
</p>

## Projeto

Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2024

---
## Detalhes

O computador escolher�, de maneira aleat�ria, uma palavra entre v�rias possibilidades*, e o jogador deve chutar, letra por letra, at� adivinh�-la.

Se o jogador chutar 5 letras erradas, ele perde.

Ao final de cada jogo, o computador informa a pontua��o do jogador.

---
## Entrada

Os jogadores s�o solicitados a inserir uma letra por vez atrav�s do console. Se a letra estiver presente na palavra, ela ser� revelada nas posi��es correspondentes. Se a letra n�o estiver presente na palavra, uma parte do boneco da forca ser� desenhada.

---
## Funcionalidades

- __Escolha de Palavra Secreta__: Uma palavra � escolhida aleatoriamente no in�cio de cada jogo;
- __Dica__: O jogo conta com uma dica inicial acerca da palavra secreta;
- __Representa��o da Forca__: A forca � desenhada progressivamente no console, com cada erro do jogador;
- __Hist�rico de Tentativas__: As letras que j� foram testadas s�o vis�veis ao usu�rio;
- __Feedback Visual__: As letras corretamente adivinhadas s�o exibidas na posi��o correta, enquanto as n�o descobertas permanecem ocultas;
- __Contagem de Erros__: O jogo acompanha o n�mero de erros cometidos pelo jogador e termina quando o m�ximo permitido � alcan�ado;
- __Pontua��o__: Ao final de cada jogo, o computador informa as pontua��es anteriores e a pontua��o atual do jogador.

---
## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compila��o e execu��o do projeto.
---
## Como Usar

#### Clone o Reposit�rio
```
git clone https://github.com/academia-do-programador/jogo-da-forca-2024.git
```

#### Navegue at� a pasta raiz da solu��o
```
cd jogo-da-forca-2024
```

#### Restaure as depend�ncias
```
dotnet restore
```

#### Navegue at� a pasta do projeto
```
cd JogoDaForca.ConsoleApp
```

#### Execute o projeto
```
dotnet run
```