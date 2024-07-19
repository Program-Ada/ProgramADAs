# **O jogo ProgramADAs**

## **ProgramAda: Mulheres na Programação - DCC/UFJF**

| **Sumário** |
|-------------|
| [Desenvolvedoras](#Desenvolvedoras) |
| [Descrição do Projeto](#Descrição-do-Projeto) |
| [Como executar o projeto inicial](#Para-executar-o-projeto) |
| [Git Tutorial - Devs](#Git-tutorial) |

#### Desenvolvedoras:

* [Eduarda Pereira Mourão Nunes](https://github.com/EduardaNunes)
* [Luana Lauschner Avilez Vilarinho](https://github.com/luanalauschner)
* [Victoria Tiemi Ferreira Yamashita](https://github.com/yamashita-tiemi)


#### Coordenadoras:

* [Alessandreia Marta de Oliveira](https://github.com/Alessandreia)
* Barbara Quintela
* Luciana Brugiolo

#### Links Úteis:

* [Linktree](https://linktr.ee/program_ada)

* [Instagram](https://www.instagram.com/program_ada_ufjf/)



## Descrição do Projeto:

Esse trabalho tem como objetivos despertar a motivação das alunas de graduação para o estudo de programação, reduzir as taxas de desistência e reprovação na disciplina de Algoritmos.
Para alcançar esses objetivos, foi desenvolvido o jogo ProgramADAs, com aspectos lúdicos e fácil customização, para ser utilizado ao longo do semestre como um projeto de programação motivador e enriquecedor para as alunas que cursam a disciplina de Algoritmos no início da graduação na UFJF.
Essa iniciativa busca promover a equidade de gênero e respeito à diversidade, a integração do jogo como uma ferramenta pedagógica alternativa ao currículo acadêmico convencional e o sucesso e satisfação das alunas na área.

* O jogo está sendo desenvolvido utilizando a engine [Unity](https://unity.com/pt);


## Para executar o projeto:
 
Clique neste link para acessar a página de PlayTest, onde uma versão do jogo está disponível para ser jogada online, sem a necessidade de qualquer instalação:
* [ProgramADAs - PLayTest](https://program-ada.github.io/ProgramADAs-PLayTest/)


## Git Tutorial

### Instalação

Pra instalar, basta acessar a página de [downloads](https://git-scm.com/downloads) e seguir as instruções\
Pra se conectar, utilize os seguinte comandos: <sub>(Substitua o nome e o e-mail para o seu)<sub/>
```
git config --global user.name "nomeDeUsuario"
```
```
git config --global user.email email@exemplo.com
```



### Primeira Configuração

* Pelo terminal entre na pasta onde irá guardar o projeto: cd /caminho/para/a/pasta, depois inicialize o git na pasta com o comando: `git init`

* Outro jeito de fazer o citado acima: clique com o botão direito na pasta e selecione "Git Bash Here" para abrir o terminal do git

* Crie um clone do repositório: `git clone https://github.com/link-do-repositorio`

* Entre na pasta criada pelo comando clone: cd /caminho/para/a/pasta/nova

* Crie sua branch usando como o padrão o nome da feature que você está a desenvolver: `git checkout -b nome_da_feature`

* Após criada a branch você será redirecionado automaticamente a ela, neste espaço que você desenvolverá sua parte do projteto




### Rotina

* Adicione as alterações feitas: `git add .`

* Cheque em qual branch você está e quais alterações foram adicionadas: `git status`

* Dê um commit com uma mensagem especificando as alterações realizadas: `git commit -m "mensagem especificando o que foi feito"`

* Envie o commit feito para sua branch: `git push origin suabranch`



### Merge - unindo branchs

* Volte para a main: `git checkout main`

* Atualize a main: `git pull`

* Volte para a sua branch: `git checkout nomedabranch`

* Mescle a main com a sua branch : `git merge main`

* Corrija os possíveis conflitos

* Confirme o merge (apenas quando solicitado pelo Scrum Master): `git push origin suabranch`

* Espera a confirmação do seu SCRUM

* Volte para a main: `git checkout main`

* Mescle a main com as alterações enviadas para sua branch (apenas quando solicitado pelo Scrum Master): `git merge suabranch`

* Confirme o merge (apenas quando solicitado pelo Scrum Master): `git push origin main`



### Comandos Básicos

* Para atualizar a main: `git pull`

* Para atualizar alguma branch: `git pull origin branch`

* Ver informações da branch: `git status`

* Para trocar de branch: `git checkout branch_desejada`

* Adicionar todas as alterações feitas: `git add .`

* Adicionar alteração específica: `git add arquivo-especifico`

* Para mesclar sua branch com a main (estando dentro da sua branch): `git merge main`

* Para confirmar o merge: `git push origin suabranch`

