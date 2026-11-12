# 🏃‍♂️ Infinity Runner — CSJ Academy

<p align="center">
  <img src="https://img.shields.io/badge/Unity-6000.6.8f1-black?style=for-the-badge&logo=unity" alt="Unity Version" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/Render%20Pipeline-URP%202D-blue?style=for-the-badge" alt="URP 2D" />
  <img src="https://img.shields.io/badge/Status-Em%20Desenvolvimento-orange?style=for-the-badge" alt="Status" />
  <img src="https://img.shields.io/badge/Curso-CSJ%20Academy-purple?style=for-the-badge" alt="CSJ Academy" />
</p>

---

## 📖 Sobre o Projeto

Este repositório contém o desenvolvimento prático do módulo de **Infinity Runner (Endless Runner 2D)** ministrado no curso da **CSJ Academy**.

O objetivo do projeto é aprender e consolidar os principais conceitos e padrões de desenvolvimento de jogos em **Unity 6**, com foco especial em:
- Geração procedural e infinita de cenários.
- Boas práticas de arquitetura em C# (métodos desacoplados, reaproveitamento de objetos).
- Otimização de desempenho com reciclagem contínua de plataformas.
- Organização profissional de projeto e versionamento com Git.

---

## 🎮 Mecânicas e Funcionalidades

### 🔄 Sistema de Plataformas Infinitas & Reciclagem
Em vez de instanciar e destruir GameObjects continuamente durante a gameplay (o que causaria picos de *Garbage Collector* e quedas de frame), o jogo utiliza uma técnica inteligente de **reciclagem de plataformas**:

1. **Instanciação Inicial:** Um conjunto predefinido de prefabs de plataformas (`PlataformA`, `PlataformB`, `PlataformC`) é instanciado em sequência com espaçamento calculado (`_offSet`).
2. **Detecção de Passagem:** Cada plataforma possui um componente `Plataform` que indica o seu ponto final (`FinalPoint`).
3. **Reposicionamento Dinâmico:** Conforme o jogador avança e alcança a distância de ativação (`TriggerDistance`), a plataforma que ficou para trás é reposicionada automaticamente à frente da fila (`Recycle`), garantindo que o cenário nunca termine.

---

## 🛠️ Tecnologias Utilizadas

- **Engine:** [Unity 6 (v6000.6.8f1)](https://unity.com/)
- **Linguagem:** C# (.NET Standard)
- **Pipeline Gráfico:** Universal Render Pipeline (URP 2D)
- **Pacotes & Módulos Unity:**
  - 2D Sprite, 2D Tilemap & 2D Tooling
  - Input System
  - Universal RP
- **Versionamento:** Git & GitHub com padrão de *Conventional Commits*

---

## 📂 Estrutura do Projeto

A organização dos arquivos no diretório `Assets/` segue uma estrutura limpa e modular:

```text
Assets/
├── Prefabs/
│   └── Plataforms/        # Prefabs modulares das plataformas (PlataformA, B, C)
├── Scenes/
│   └── SampleScene.unity  # Cena principal de desenvolvimento e testes
├── Scripts/
│   └── Plataforms/
│       ├── Plataform.cs       # Define pontos de referência da plataforma (FinalPoint)
│       ├── SpawnMethods.cs    # Lógica estática de cálculo, instanciação e reciclagem
│       └── SpawnPlataforms.cs # MonoBehaviour que gerencia o ciclo do spawn
├── Settings/              # Configurações do URP 2D e Renderers
└── Sprites/
    └── Flat Jetpack/      # Pacote de sprites (Backgrounds, Personagens, Inimigos, UI)
```

---

## 🗺️ Roadmap de Estudos

- [x] Configuração inicial do projeto em Unity 6 e URP 2D
- [x] Importação e organização do pacote de sprites (Flat Jetpack)
- [x] Criação dos prefabs das plataformas modulares
- [x] Implementação do gerador e reciclador procedural de plataformas infinitas
- [ ] Implementação da física e movimentação do jogador (corrida e pulo/jetpack)
- [ ] Configuração de câmera de acompanhamento (Cinemachine ou Script de Follow)
- [ ] Sistema de camadas com efeito Parallax no fundo
- [ ] Adição de obstáculos, inimigos e armadilhas dinâmicas
- [ ] Sistema de itens colecionáveis e pontuação (Score / Highscore)
- [ ] Interface de usuário (HUD, Game Over, botão de Restart)
- [ ] Efeitos sonoros (SFX) e música de fundo (BGM)

---

## 🚀 Como Executar o Projeto

### Pré-requisitos
- Ter o **[Unity Hub](https://unity.com/download)** instalado.
- Ter a versão **Unity 6 (6000.6.8f1)** ou superior instalada via Unity Hub.

### Passos
1. Clone este repositório:
   ```bash
   git clone https://github.com/xX-Mill3r-Xx/InfinityRunner-CSJAcademy.git
   ```
2. Abra o **Unity Hub**, clique em **Add** e selecione a pasta interna do projeto:
   ```text
   InfinityRunner-CSJAcademy/InfinityRunner-CSJAcademy
   ```
3. Abra o projeto na versão `6000.6.8f1`.
4. No painel de `Project`, navegue até `Assets/Scenes/` e abra a cena **`SampleScene`**.
5. Clique no botão **Play** no topo do editor da Unity para testar a cena.

---

## 👨‍💻 Autor

Desenvolvido por **[xX-Mill3r-Xx](https://github.com/xX-Mill3r-Xx)** como parte dos estudos de desenvolvimento de jogos na **CSJ Academy**.

---

⭐ *Se você gostou deste projeto ou está estudando desenvolvimento de jogos, sinta-se à vontade para acompanhar o repositório!*
